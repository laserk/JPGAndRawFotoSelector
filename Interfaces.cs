using System.Xml.Serialization;

namespace JPGRawFotoSelector
{

    
    [XmlRoot("JPGRawFotoSelector")]
    public class Setting
    {
        [XmlAttribute]
        public bool DefaultCheckJPG;
        public string DefaultDetectFolder;
        public string DefaultDeleteFolderName;
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
