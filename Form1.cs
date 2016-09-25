using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using JPGRawFotoSelector.Properties;

namespace JPGRawFotoSelector
{
    public partial class FotoSelectorMainWindow : Form
    {
        string _path;
        DefaultSetting _defaultSetting;
        delegate void ProgressDelegate(int progress);
        public FotoSelectorMainWindow()
        {
            InitializeComponent();
            if (!InitialSettings())
                return;
            InitialCameraList();
            StatusBarHelper.InitialToolStripStatusLabel(ref toolStripStatusLabel1);
            InitializeCheckBoxes();
            InitializeToolStripProgressBar();
        }

        private void InitializeToolStripProgressBar()
        {
            progressBar1.Visible = false;
            progressBar1.Maximum = 100;
            ListViewHelper.ProgressChanged += OnProgressChanged;
        }

        private bool InitialSettings()
        {
            _defaultSetting = JPGRawFotoSelectorSettings.GetSettings(Helper.GetFullPath("JPGAndRawFotoSelector.xml"));
            if (_defaultSetting == null)
            {
                MessageBox.Show(Resources.Configration_file_is_missing);
                return false;
            }
            return true;
        }

        private void InitializeCheckBoxes()
        {
            baseOnJpgCheckBox.Checked = _defaultSetting.CheckJPG;
            jpgModeCheckBox.Checked = _defaultSetting.JPGView;
            selectAllCheckBox.Checked = _defaultSetting.SelectAll;
        }

        private void InitialCameraList()
        {
            foreach (var item in _defaultSetting.Cameras)
                cobCamera.Items.Add(item.CameraName);
            cobCamera.SelectedIndex = 0;
        }

        private void ReFreshUi()
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }

        void detectButton_Click(object sender, EventArgs e)
        {
            _path = textPath.Text.Trim();
            if (string.IsNullOrEmpty(_path))
            {
                folderBrowserDialog1.SelectedPath = _defaultSetting.DetectFolder;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                textPath.Text = folderBrowserDialog1.SelectedPath;
                _path = folderBrowserDialog1.SelectedPath;
                ListViewHelper.ClearExifList();
            }
            if (!StartDetecteFiles()) return;
         
        }

        public void SetProgress(int progress)
        {
            if (this.InvokeRequired)
            {
                ProgressDelegate d = new ProgressDelegate(SetProgress);
                this.Invoke(d, new object[] { progress });
            }
            else
                this.progressBar1.Value = progress;
        }

        void OnProgressChanged(object sender, ProgressChangedArgs args)
        {
            if (args.TotalProcess > 0 & args.TotalProcess < 0.11)
                SetProgress(10);

            if (args.TotalProcess > 0.1 & args.TotalProcess < 1)
                if (args.TotalFileCount > 0)
                {
                    int temp = (int)(((double)args.ProcessedFiles / (double)args.TotalFileCount * 80));
                    SetProgress(10 + temp);
                }
            if (args.TotalProcess > 0.9)
                SetProgress(100);
            Thread.Sleep(25);
        }
        bool StartDetecteFiles()
        {
            if (string.IsNullOrEmpty(_path))
                return false;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            var strJpg = textBoxJPG.Text.Trim();
            var strRaw = textBoxRAW.Text.Trim();

            FileCleanList.Items.Clear();
            try
            {
                var fileListJpg = Directory.EnumerateFiles(_path, "*." + strJpg, SearchOption.TopDirectoryOnly);

                var fileListRaw = Directory.EnumerateFiles(_path, "*." + strRaw, SearchOption.TopDirectoryOnly);
                IEnumerable<string> fileList;
                bool isSimpleHeader;
                if (!jpgModeCheckBox.Checked)
                    if (baseOnJpgCheckBox.Checked)
                    {
                        isSimpleHeader = true;
                        fileList = ListViewHelper.FillListBaseOnReference(strJpg, strRaw, fileListJpg, fileListRaw);
                        StatusBarHelper.SetFileDetectionResult(ref toolStripStatusLabel1,fileList==null?0:fileList.Count(),false);
                    }
                    else
                    {
                        isSimpleHeader = false;
                        fileList = ListViewHelper.FillListBaseOnReference(strRaw, strJpg, fileListRaw, fileListJpg);
                        StatusBarHelper.SetFileDetectionResult(ref toolStripStatusLabel1, fileList == null ? 0 : fileList.Count(), false);
                    }
                else
                {
                    isSimpleHeader = false;
                    fileList = ListViewHelper.FillListBaseOnReference(strRaw, strJpg, new List<string>(), fileListJpg);
                    StatusBarHelper.SetFileDetectionResult(ref toolStripStatusLabel1, fileList == null ? 0 : fileList.Count(), true);
                }
                ListViewHelper.FillCleanList(ref FileCleanList, fileList, isSimpleHeader);

                ListViewHelper.AutoResizeColumnWidth(ref FileCleanList);
                progressBar1.Value = 100;
                progressBar1.Visible = false;

            }
            catch (Exception exception)
            {
                StatusBarHelper.SetErrorMessage(ref toolStripStatusLabel1, exception);
                return false;
            }
            return true;
        }

        void cleanButton_Click(object sender, EventArgs e)
        {
            var removeList = new List<ListViewItem>();
            string destPath = _path + "\\" + _defaultSetting.DeleteFolderName + "\\";
            CheckDeleteFolder(destPath);
            int totalRemove = FileCleanList.SelectedItems.Count;

            foreach (ListViewItem file in FileCleanList.SelectedItems)
            {
                var sourcePath = file.Text;
                if (!File.Exists(sourcePath)) continue;
                var fInfo = new FileInfo(sourcePath);
                try
                {
                    File.Move(sourcePath, destPath + fInfo.Name);
                    removeList.Add(file);
                }
                catch (Exception exception)
                {
                    StatusBarHelper.SetErrorMessage(ref toolStripStatusLabel1, exception);
                    return;
                }
            }
            ListViewHelper.RemoveDeletedItems(ref FileCleanList, removeList);
            StatusBarHelper.SetRemovedMessage(ref toolStripStatusLabel1, totalRemove, FileCleanList.Items.Count);
        }

        static void CheckDeleteFolder(string destPath)
        {
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);
        }

        void FillFileTextBoxes()
        {
            var camera = SelectedCamera();
            if (camera?.FileSetting != null)
            {
                textBoxRAW.Text = camera.FileSetting.RawFile;
                textBoxJPG.Text = camera.FileSetting.JpgFile;
            }
        }

        CameraSetting SelectedCamera()
        {
            return _defaultSetting.Cameras.FirstOrDefault(camera => string.CompareOrdinal(camera.CameraName, cobCamera.SelectedItem.ToString()) == 0);
        }


        void cobCamera_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ReFreshUi();
        }

        void checkBaseOnJPG_CheckedChanged(object sender, EventArgs e)
        {
            ReFreshUi();
        }


        private void FileCleanList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FileCleanList.SelectedItems.Count > 0)
                Helper.OpenJpgFile(FileCleanList.SelectedItems[0].Text);
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (FileCleanList.SelectedItems.Count > 0)
                Helper.OpenJpgFile(FileCleanList.SelectedItems[0].Text);
        }

        private void modeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ModeSelected();
        }

        private void ModeSelected()
        {
            viewButton.Enabled = jpgModeCheckBox.Checked;
            selectAllCheckBox.Enabled = cleanButton.Enabled = !jpgModeCheckBox.Checked;
            StatusBarHelper.SetModeName(ref lblModelLabel, jpgModeCheckBox.Checked);
            FileCleanList.MultiSelect = !jpgModeCheckBox.Checked;
            ReSetSelectAll();
            ReFreshUi();
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!selectAllCheckBox.Enabled)
                return;
            SelectAllSelected();
            FileCleanList.Focus();
        }

        private void ReSetSelectAll()
        {
            selectAllCheckBox.Checked = false;
            SelectAllSelected();
        }

        private void SelectAllSelected()
        {
            selectAllCheckBox.Text = selectAllCheckBox.Checked ? Resources.UnSelect_All : Resources.Select_All;
            if (FileCleanList.Items.Count < 1)
                return;
            if (selectAllCheckBox.Checked)
                ListViewHelper.SelectAllFiles(ref FileCleanList);
            else
                FileCleanList.SelectedItems.Clear();
        }

    }
}
