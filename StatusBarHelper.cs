using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JPGRawFotoSelector.Properties;

static internal class StatusBarHelper
{
    public static void InitialToolStripStatusLabel(ref ToolStripStatusLabel toolStripStatusLabel1)
    {
        toolStripStatusLabel1.Text = Resources.SelectFileToDelete;
        toolStripStatusLabel1.ForeColor = Color.Black;
    }

    public static void SetErrorMessage(ref ToolStripStatusLabel toolStripStatusLabel1, Exception exception)
    {
        toolStripStatusLabel1.Text = exception.Message;
        toolStripStatusLabel1.ForeColor = Color.Red;
    }

    public static void SetRemovedMessage(ref ToolStripStatusLabel toolStripStatusLabel1, int totalRemove,
        int fileCleaned)
    {
        toolStripStatusLabel1.Text = "TotalFileCount:" + totalRemove + " files be removed, remain:" + fileCleaned +
                                     " files to Select";
        toolStripStatusLabel1.ForeColor = Color.Blue;
    }

    public static void SetModeName(ref Label lblModelLabel, bool isJpgModeChecked)
    {
        lblModelLabel.Text = isJpgModeChecked ? Resources.ViewMode : Resources.CleanMode;
    }

    public static void SetFileDetectionResult(ref ToolStripStatusLabel toolStripStatusLabel1, int fileCleanListCount,bool isViewMode)
    {
        StringBuilder sbText = new StringBuilder("Detected :");
        if (isViewMode)
            toolStripStatusLabel1.Text = sbText .Append( fileCleanListCount + " JPG files, select on and double click  to view").ToString();
        else
            toolStripStatusLabel1.Text = sbText.Append(fileCleanListCount + " files do not have reference file which can be cleaned").ToString();
        toolStripStatusLabel1.ForeColor = Color.Black;
    }
}