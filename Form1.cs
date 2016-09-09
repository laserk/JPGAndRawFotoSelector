using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JPGRawFotoSelector.Properties;

namespace JPGRawFotoSelector
{
    public partial class FotoSelectorMainWindow : Form
    {
        string _path;
        readonly DefaultSetting _defaultSetting;

        string strDefaultFileList = Resources.SelectFileToDelete;
        public FotoSelectorMainWindow()
        {
            InitializeComponent();
            _defaultSetting = JPGRawFotoSelectorSettings.GetSettings(Helper.GetFullPath("JPGAndRawFotoSelector.xml"));
            if (_defaultSetting == null)
            {
                MessageBox.Show(Resources.Configration_file_is_missing);
                return;
            }

            InitialCameraList();
            InitialFileListLabel();
            InitializeCheckBoxes();
        }

        private void InitializeCheckBoxes()
        {
            baseOnJpgCheckBox.Checked = _defaultSetting.CheckJPG;
            jpgModeCheckBox.Checked = _defaultSetting.JPGView;
            selectAllCheckBox.Checked = _defaultSetting.SelectAll;
        }

        private void InitialFileListLabel()
        {
            toolStripStatusLabel1.Text = strDefaultFileList;
            toolStripStatusLabel1.ForeColor = Color.Black;
        }

        private void InitialCameraList()
        {
            foreach (var item in _defaultSetting.Cameras)
                cobCamera.Items.Add(item.CameraName) ;
            cobCamera.SelectedIndex = 0;
        }

        private void ReFreshUi()
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }

        void detectButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = _defaultSetting.DetectFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textPath.Text = folderBrowserDialog1.SelectedPath;
            _path = folderBrowserDialog1.SelectedPath;
            if (!StartDetecteFiles()) return;
            toolStripStatusLabel1.Text = "Total:" + FileCleanList.Items.Count + " files to Select";
        }

        bool StartDetecteFiles()
        {
            if(string.IsNullOrEmpty(_path))
                return false;
            var strJpg = textBoxJPG.Text.Trim();
            var strRaw = textBoxRAW.Text.Trim();
            InitialFileListLabel();
            FileCleanList.Items.Clear();
            try
            {
                var fileListJpg = Directory.EnumerateFiles(_path, "*." + strJpg, SearchOption.TopDirectoryOnly);

                var fileListRaw = Directory.EnumerateFiles(_path, "*." + strRaw, SearchOption.TopDirectoryOnly);
                    if (baseOnJpgCheckBox.Checked && !jpgModeCheckBox.Checked)
                        FillListBaseOnReference(strJpg, strRaw, fileListJpg, fileListRaw);
                    else
                        FillListBaseOnReference(strRaw,strJpg , fileListRaw, fileListJpg);
            }
            catch (Exception exception)
            {
                SetErrorMessage(exception);
                return false;
            }
            return true;
        }

        private void SetErrorMessage(Exception exception)
        {
            toolStripStatusLabel1.Text = exception.Message;
            toolStripStatusLabel1.ForeColor = Color.Red;
        }

        void FillListBaseOnReference(string referenceSuffix, string targetSuffix, IEnumerable<string> referenceList,
            IEnumerable<string> targetList)
        {
            var query = targetList
                .Where(f => !referenceList.Contains(f.Replace(targetSuffix, referenceSuffix)));
            if (!query.Any()) return;
            foreach (var file in query)
                FileCleanList.Items.Add(file);
        }

        void cleanButton_Click(object sender, EventArgs e)
        {
            var removeList = new List<string>();
             string destPath = _path + "\\"+_defaultSetting.DeleteFolderName+"\\";
            CheckDeleteFolder(destPath);
            int totalRemove = FileCleanList.SelectedItems.Count;

            foreach (var file in FileCleanList.SelectedItems)
            {
                var sourcePath = file.ToString();
                if (!File.Exists(sourcePath)) continue;
                var fInfo = new FileInfo(sourcePath);
                try
                {
                    File.Move(sourcePath, destPath + fInfo.Name);
                    removeList.Add(sourcePath);
                }
                catch (Exception exception)
                {
                    SetErrorMessage(exception);
                    return;
                }
            }
            foreach (var removefile in removeList)
                FileCleanList.Items.Remove(removefile);
            toolStripStatusLabel1.Text = "Total:" + totalRemove + " files be removed, remain:" + FileCleanList.Items.Count + " files to Select";
            toolStripStatusLabel1.ForeColor = Color.Blue;
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
                Helper.OpenJpgFile(FileCleanList.SelectedItems[0].ToString());
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (FileCleanList.SelectedItems.Count > 0)
                Helper.OpenJpgFile(FileCleanList.SelectedItems[0].ToString());
        }

        private void modeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ModeSelected();
        }

        private void ModeSelected()
        {
            viewButton.Enabled = jpgModeCheckBox.Checked;
            selectAllCheckBox.Enabled = cleanButton.Enabled = !jpgModeCheckBox.Checked;
            toolStripStatusLabel1.Text = jpgModeCheckBox.Checked ? Resources.ViewMode : Resources.CleanMode;
            toolStripStatusLabel1.ForeColor = Color.Green;
            FileCleanList.SelectionMode = jpgModeCheckBox.Checked ? SelectionMode.One : SelectionMode.MultiExtended;
            ReSetSelectAll();
            ReFreshUi();
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!selectAllCheckBox.Enabled)
                return;
            SelectAllSelected();
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
                SelectAllFiles();
            else
                FileCleanList.ClearSelected();
        }

        private void SelectAllFiles()
        {
            for (int i = 0; i < FileCleanList.Items.Count; i++)
            {
                FileCleanList.SetSelected(i, true);
            }
        }
    }
}
