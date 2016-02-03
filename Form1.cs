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
        enum enumCamera
        { 
            Sony,
            Canon
        }
        const string strDefaultFileList = "Select Files To Delete";
        public FotoSelectorMainWindow()
        {
            InitializeComponent();
            //_path = Util.GetFullPath("JPGRawFotoSelector");
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
            foreach (var item in Enum.GetNames(typeof(enumCamera)))
                cobCamera.Items.Add(item) ;
            cobCamera.SelectedIndex = 0;
        }

        void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
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
            string strJpg = textBoxJPG.Text.Trim();
            string strRaw = textBoxRAW.Text.Trim();
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
            if (query.Any())
                foreach (var file in query)
                {
                    FileCleanList.Items.Add(file);
                }
            // no LINQ version
        //foreach (var file in targetList)
            //{
            //    string fileJPG = file.Replace(targetSuffix, referenceSuffix);
            //    if (!referenceList.Contains(fileJPG))
            //        FileCleanList.Items.Add(file);
            //}
        }

        void button2_Click(object sender, EventArgs e)
        {
            var removeList = new List<string>();
            string destPath = _path + "\\Remove\\";
            CheckDeleteFolder(destPath);
            int totalRemove = FileCleanList.SelectedItems.Count;

            foreach (var file in FileCleanList.SelectedItems)
            {
                string sourcePath = file.ToString();
                if (File.Exists(sourcePath))
                {
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
            if (cobCamera.SelectedItem.ToString() == enumCamera.Sony.ToString())
            {
                textBoxRAW.Text = Resources.Form1_FillFileTextBoxes_ARW;
                textBoxJPG.Text = Resources.Form1_FillFileTextBoxes_JPG;
            }
            if (cobCamera.SelectedItem.ToString() == enumCamera.Canon.ToString())
            {
                textBoxRAW.Text = Resources.Form1_FillFileTextBoxes_CR2;
                textBoxJPG.Text = Resources.Form1_FillFileTextBoxes_JPG;
            }
        }

        void cobCamera_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }

        private void checkBaseOnJPG_CheckedChanged(object sender, EventArgs e)
        {
            FillFileTextBoxes();
            StartDetecteFiles();
        }
    }
}
