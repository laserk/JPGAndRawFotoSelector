using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using JPGRawFotoSelector;

static internal class StatusBarHelper
{
    public static void InitialToolStripStatusLabel(ref ToolStripStatusLabel toolStripStatusLabel1,string strDefaultFileList)
    {
        toolStripStatusLabel1.Text = strDefaultFileList;
        toolStripStatusLabel1.ForeColor = Color.Black;
    }

    public static void SetErrorMessage(ref ToolStripStatusLabel toolStripStatusLabel1, Exception exception)
    {
        toolStripStatusLabel1.Text = exception.Message;
        toolStripStatusLabel1.ForeColor = Color.Red;
    }

    public static void SetRemovedMessage(ref ToolStripStatusLabel toolStripStatusLabel1, int totalRemove,int fileCleaned)
    {
        toolStripStatusLabel1.Text = "TotalFileCount:" + totalRemove + " files be removed, remain:" + fileCleaned + " files to Select";
        toolStripStatusLabel1.ForeColor = Color.Blue;
    }
}