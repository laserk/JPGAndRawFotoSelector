using System.Xml.Serialization;

namespace JPGRawFotoSelector
{

    
    [XmlRoot("JPGRawFotoSelector")]
    public class DefaultSetting
    {
        [XmlAttribute]
        public bool CheckJPG;
        public bool JPGView;
        public bool SelectAll;
        public string DetectFolder;
        public string DeleteFolderName;
        public CameraSetting[] Cameras;
    }

    public class CameraSetting
    {
        public string CameraName;
        public FileSetting FileSetting;
    }

    public class FileSetting
    {
        public string RawFile;
        public string JpgFile;
    }
}
