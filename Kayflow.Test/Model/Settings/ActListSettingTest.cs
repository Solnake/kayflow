using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kayflow.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kayflow.Test.Model.Settings
{
    [TestClass]
    public class ActListSettingTest
    {
        [TestMethod]
        public void Test_DisplayFields_All()
        {
            var settings = new ActListSetting();
            Assert.AreEqual(11, settings.DisplayFields.Count);
        }

        [TestMethod]
        public void Test_DisplayFields_Visible()
        {
            var settings = new ActListSetting
            {
                Fields = "Address,CustomerName,CustomerPhone"
            };
            Assert.AreEqual(3, settings.DisplayFields.Count(s => s.Show));
        }
    }
}
