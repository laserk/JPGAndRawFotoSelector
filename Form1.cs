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
        readonly Setting _setting;

        const string strDefaultFileList = "Select Files To Delete";
        public FotoSelectorMainWindow()
        {
            InitializeComponent();
            _setting = JPGRawFotoSelectorSettings.GetSettings(Helper.GetFullPath("JPGAndRawFotoSelector.xml"));
            if (_setting == null)
            {
                MessageBox.Show("Configration file is missing!!!");
                return;
            }

            InitialCameraList();

            InitialFileListLabel();
        }

        private void InitialFileListLabel()
        {
            lblFileList.Text = strDefaultFileList;
            lblFileList.ForeColor = Color.Black;
        }

        private void InitialCameraList()
        {
            foreach (var item in _setting.Cameras)
                cobCamera.Items.Add(item.CameraName) ;
            cobCamera.SelectedIndex = 0;
        }

        void detectButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = _setting.DefaultDetectFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textPath.Text = folderBrowserDialog1.SelectedPath;
            _path = folderBrowserDialog1.SelectedPath;
            if (!StartDetecteFiles()) return;
            lblFileList.Text = "Total:" + FileCleanList.Items.Count + " files to Select";
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

                if (checkBaseOnJPG.Checked)
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
            lblFileList.Text = exception.Message;
            lblFileList.ForeColor = Color.Red;
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

        void button2_Click(object sender, EventArgs e)
        {
            var removeList = new List<string>();
             string destPath = _path + "\\"+_setting.DefaultDeleteFolderName+"\\";
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
            lblFileList.Text = "Total:" + totalRemove + " files be removed, remain:" + FileCleanList.Items.Count + " files to Select";
            lblFileList.ForeColor = Color.Blue;
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
            return _setting.Cameras.FirstOrDefault(camera => string.CompareOrdinal(camera.CameraName, cobCamera.SelectedItem.ToString()) == 0);
        }


        void cobCamera_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }

        void checkBaseOnJPG_CheckedChanged(object sender, EventArgs e)
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }

        private void FileCleanList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FileCleanList.SelectedItems.Count > 0)
                openJpgFile(FileCleanList.SelectedItems[0].ToString());
        }

        private void openJpgFile(string filePathName)
        {
            if (!filePathName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) && !filePathName.EndsWith(".jpge", StringComparison.OrdinalIgnoreCase))
                return;
            System.Diagnostics.Process process = new System.Diagnostics.Process();

     
            process.StartInfo.FileName = filePathName;


            process.StartInfo.Arguments = "rundl132.exe C://WINDOWS//system32//shimgvw.dll,ImageView_Fullscreen";


            process.StartInfo.UseShellExecute = true;

            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();
            process.Close();

        }

    }
}
