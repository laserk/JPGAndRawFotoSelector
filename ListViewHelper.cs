using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JPGRawFotoSelector;
using JPGRawFotoSelector.Properties;

internal static class ListViewHelper
{
    static ConcurrentDictionary<string,ListViewItem> _exifInfoList = new ConcurrentDictionary<string,ListViewItem>();
    private static int intProgress;
    public static void ClearExifList()
    {
        _exifInfoList.Clear();
    }
    public static void AutoResizeColumnWidth(ref ListView lv)

    {

        int count = lv.Columns.Count;

        int MaxWidth = 0;

        Graphics graphics = lv.CreateGraphics();

        Font font = lv.Font;

        ListView.ListViewItemCollection items = lv.Items;

        string str;

        int width;


        lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        for (int i = 0; i < count; i++)

        {

            str = lv.Columns[i].Text;

            MaxWidth = lv.Columns[i].Width;



            foreach (ListViewItem item in items)

            {

                str = item.SubItems[i].Text;

                width = (int)graphics.MeasureString(str, font).Width;

                if (width > MaxWidth)

                {

                    MaxWidth = width;

                }

            }

            if (i == 0)

            {
                if (lv.SmallImageList == null)
                    lv.Columns[i].Width = MaxWidth;
                else
                    lv.Columns[i].Width = lv.SmallImageList.ImageSize.Width + MaxWidth;

            }

            lv.Columns[i].Width = MaxWidth;

        }

    }
    
    public static void InitialListView(ref ListView fileCleanList)
    {
       // SimpleHeader(ref fileCleanList);
        ComplexHeader(ref fileCleanList);
        fileCleanList.FullRowSelect = true;
        fileCleanList.HideSelection = false;
    }

    private static void SimpleHeader(ref ListView fileCleanList)
    {
        ColumnHeader ch = new ColumnHeader();
        ch.Name = Resources.Column_Header_Files;
        ch.Text = Resources.Column_Header_Files;
        ch.TextAlign = HorizontalAlignment.Left;
        ch.Width = (fileCleanList.Width) - 20;
        ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        fileCleanList.Columns.Clear();
        fileCleanList.Columns.Add(ch);
        fileCleanList.FullRowSelect = true;
    }

    private static void ComplexHeader(ref ListView fileCleanList)
    {
        ColumnHeader ch0 = new ColumnHeader();
        ch0.Name = Resources.Column_Header_Files;
        ch0.Text = Resources.Column_Header_Files;
        ch0.TextAlign = HorizontalAlignment.Left;
        ch0.Width = (fileCleanList.Width) / 7 - 20;
        ch0.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        ColumnHeader ch1 = new ColumnHeader();
        ch1.Name = "Create Data";
        ch1.Text = "Create Data";
        ch1.TextAlign = HorizontalAlignment.Left;
        ch1.Width = (fileCleanList.Width) / 7 - 20;
        ch1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        ColumnHeader ch2 = new ColumnHeader();
        ch2.Name = "Aperture";
        ch2.Text = "Aperture";
        ch2.TextAlign = HorizontalAlignment.Left;
        ch2.Width = (fileCleanList.Width) / 7 - 20;
        ch2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        ColumnHeader ch3 = new ColumnHeader();
        ch3.Name = "Exposure Time";
        ch3.Text = "Exposure Time";
        ch3.TextAlign = HorizontalAlignment.Left;
        ch3.Width = (fileCleanList.Width) / 7 - 20;
        ch3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        ColumnHeader ch4 = new ColumnHeader();
        ch4.Name = "ISO";
        ch4.Text = "ISO";
        ch4.TextAlign = HorizontalAlignment.Left;
        ch4.Width = (fileCleanList.Width) / 7 - 20;
        ch4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
  
        ColumnHeader ch5 = new ColumnHeader();
        ch5.Name = "Orientation";
        ch5.Text = "Orientation";
        ch5.TextAlign = HorizontalAlignment.Left;
        ch5.Width = (fileCleanList.Width) / 7 - 20;
        ch5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        fileCleanList.Columns.Clear();
        fileCleanList.Columns.Add(ch0);
        fileCleanList.Columns.Add(ch1);
        fileCleanList.Columns.Add(ch2);
        fileCleanList.Columns.Add(ch3);
        fileCleanList.Columns.Add(ch4);
        fileCleanList.Columns.Add(ch5);
        fileCleanList.FullRowSelect = true;
    }



    public static IEnumerable<string> FillListBaseOnReference(string referenceSuffix, string targetSuffix, IEnumerable<string> referenceList, IEnumerable<string> targetList)
    {
        var query = targetList
            .Where(f => !referenceList.Contains(f.Replace(targetSuffix, referenceSuffix)));
        if (!query.Any()) return null;
        return query;
    }

    public static void FillCleanList(ref ListView fileCleanList, IEnumerable<string> fileList,bool isSimpleHeader)
    {
        intProgress = 0;
        if (fileList==null)
            return;
        fileCleanList.BeginUpdate();
        if (isSimpleHeader)
        {
            SimpleHeader(ref fileCleanList);
            foreach (var file in fileList)
            {
                ListViewItem lvi = new ListViewItem { Text = file };
                fileCleanList.Items.Add(lvi);
            }
        }
        else
        {
            ComplexHeader(ref fileCleanList);
            GetExifList(fileList);
            foreach (var lvi in _exifInfoList.Values)
            {
                fileCleanList.Items.Add(lvi);
            }
        }

        fileCleanList.EndUpdate();
        intProgress = 100;
    }

    private static void GetExifList(IEnumerable<string> fileList)
    {
        int processors = Environment.ProcessorCount;
        int maxTasks = (fileList.Count()>10) ? processors * 2 : 1;
        var fatrory= new TaskFactory(new LimitedTaskScheduler(maxTasks));
        var tasks = fileList.Select(file => fatrory.StartNew(Handle, file));
        Task.WaitAll(tasks.ToArray());
    }

    private static void Handle (object state)
    {
        try
        {
            var file = state.ToString();
            if(!_exifInfoList.Keys.Contains(file))
            using (ExifManager exif = new ExifManager(file))
            {
                ListViewItem lvi = new ListViewItem { Text = file };
                lvi.SubItems.Add(exif.DateTimeOriginal.ToString("MM/dd/yy H:mm:ss zzz"));
                lvi.SubItems.Add(exif.Aperture.ToString());
                lvi.SubItems.Add(exif.ExposureTime.ToString());
                lvi.SubItems.Add(exif.ISO.ToString());
                lvi.SubItems.Add(exif.Orientation.ToString());
                lock (lvi)
                {
                    _exifInfoList.TryAdd(lvi.Text, lvi);
                }

                exif.Dispose();
            }
        }
        catch (Exception e)
        {
            Trace.WriteLine(e.ToString());
        }
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