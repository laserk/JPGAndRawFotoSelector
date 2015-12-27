using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JPGRawFotoSelector.Properties;

namespace JPGRawFotoSelector
{
    public partial class Form1 : Form
    {
        private string m_Path;
        enum enumCamera
        { 
            Sony,
            Canon
        }
        private const string strDefaultFileList = "Select Files To Delete";
        public Form1()
        {
            InitializeComponent();
            //m_Path = Util.GetFullPath("JPGRawFotoSelector");
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

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            if(folderBrowserDialog1.ShowDialog()==DialogResult.Cancel)
                return;
            textPath.Text = folderBrowserDialog1.SelectedPath;
            string strJpg = textBoxJPG.Text.Trim();
            string strRaw = textBoxRAW.Text.Trim();
            m_Path = folderBrowserDialog1.SelectedPath;
            InitialFileListLabel();
            FileCleanList.Items.Clear();
            try
            {
                var fileListJpg = Directory.EnumerateFiles(m_Path, "*." + strJpg, SearchOption.TopDirectoryOnly);

                var fileListRaw = Directory.EnumerateFiles(m_Path, "*." + strRaw, SearchOption.TopDirectoryOnly);

                if (checkBaseOnJPG.Checked)
                    FillListBaseOnJPG(strJpg, strRaw, fileListJpg, fileListRaw);
                else
                    FillListBaseOnRAW(strJpg, strRaw, fileListJpg, fileListRaw);
                
            }
            catch (Exception exception)
            {
                SetErrorMessage(exception);
                return;
            }


            lblFileList.Text = "Total:"+FileCleanList.Items.Count+" files to Select";
        }

        private void SetErrorMessage(Exception exception)
        {
            lblFileList.Text = exception.Message;
            lblFileList.ForeColor = Color.Red;
        }

        private void FillListBaseOnRAW(string strJPG, string strRAW, IEnumerable<string> fileListJPG, IEnumerable<string> fileListRAW)
        {
            foreach (var file in fileListJPG)
            {
                string fileRAW = file.Replace(strJPG, strRAW);
                if (!fileListRAW.Contains(fileRAW))
                    FileCleanList.Items.Add(file);
            }
        }

        private void FillListBaseOnJPG(string strJPG, string strRAW, IEnumerable<string> fileListJPG, IEnumerable<string> fileListRAW)
        {
            foreach (var file in fileListRAW)
            {
                string fileJPG = file.Replace(strRAW, strJPG);
                if (!fileListJPG.Contains(fileJPG))
                    FileCleanList.Items.Add(file);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            IList<string> removeList = new List<string>();
            string destPath=m_Path+"\\Remove\\";
            CheckDeleteFolder(destPath);
            int totalRemove = FileCleanList.SelectedItems.Count;
            
            foreach(var file in FileCleanList.SelectedItems)
            {
                string sourcePath=file.ToString();
                if (File.Exists(sourcePath))
                {
                    var finfo =new  FileInfo(sourcePath);
                    try
                    {
                        File.Move(sourcePath, destPath + finfo.Name);
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

        private static void CheckDeleteFolder(string destPath)
        {
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);
        }


        private void FillFileTextBoxes()
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

        private void cobCamera_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FillFileTextBoxes();
        }
  
    }
}
