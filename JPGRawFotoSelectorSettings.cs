using System;
using System.IO;

namespace JPGRawFotoSelector
{
    public class JPGRawFotoSelectorSettings
    {
        public static DefaultSetting GetSettings(string settingFilePath)
        {
            if (String.IsNullOrEmpty(settingFilePath))
                return null;
            if(!File.Exists(settingFilePath))
                return null;
            DefaultSetting defaultSettings = Helper.DeserializeContent<DefaultSetting>(File.ReadAllText(settingFilePath));
            return defaultSettings;
        }
    }
}
