using System;
using System.IO;

namespace JPGRawFotoSelector
{
    public class JPGRawFotoSelectorSettings
    {
        public static Setting GetSettings(string settingFilePath)
        {
            if (String.IsNullOrEmpty(settingFilePath))
                return null;
            if(!File.Exists(settingFilePath))
                return null;
            Setting settings = Helper.DeserializeContent<Setting>(File.ReadAllText(settingFilePath));
            return settings;
        }
    }
}
