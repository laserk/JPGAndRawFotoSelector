using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JPGRawFotoSelector;
namespace MTestJPGAndRawFotoSelector
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void canGetSettings()
        {
            var file = @"G:\work\GitRepository\GitHub\JPGAndRawFotoSelector\JPGAndRawFotoSelector.xml";
            var settings = JPGRawFotoSelectorSettings.GetSettings(file);
            Assert.IsNotNull(settings);
            Assert.AreEqual(2,settings.Cameras.Length);
        }
    }
}
