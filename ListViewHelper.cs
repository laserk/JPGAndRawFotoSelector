using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JPGRawFotoSelector.Properties;

internal static class ListViewHelper
{
    public static void InitialListView(ListView fileCleanList)
    {
        ColumnHeader ch=new ColumnHeader();
        ch.Name = Resources.Column_Header_Files;
        ch.Text = Resources.Column_Header_Files;
        ch.TextAlign = HorizontalAlignment.Left;
        ch.Width = fileCleanList.Width - 20;
        ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        fileCleanList.Columns.Add(ch);
        fileCleanList.FullRowSelect = true;
        fileCleanList.HideSelection = false;
    }

    public static void FillListBaseOnReference(ref ListView fileCleanList, string referenceSuffix, string targetSuffix, IEnumerable<string> referenceList,
        IEnumerable<string> targetList)
    {
        var query = targetList
            .Where(f => !referenceList.Contains(f.Replace(targetSuffix, referenceSuffix)));
        if (!query.Any()) return;
        fileCleanList.BeginUpdate();
        foreach (var file in query)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = file;
            fileCleanList.Items.Add(lvi);
        }
        fileCleanList.EndUpdate();
    }

    public static void SelectAllFiles(ref ListView fileCleanList)
    {
        for (int i = 0; i < fileCleanList.Items.Count; i++)
        {
            fileCleanList.Items[i].Selected= true;
        }
    }

    public static void RemoveDeletedItems(ref ListView fileCleanList, List<int> removeList)
    {
        fileCleanList.BeginUpdate();
        foreach (var removefile in removeList)
            fileCleanList.Items.RemoveAt(removefile);
        fileCleanList.EndUpdate();
    }
}