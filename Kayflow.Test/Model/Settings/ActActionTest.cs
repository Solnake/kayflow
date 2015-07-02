using System.Drawing;
using Kayflow.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kayflow.Test.Model.Settings
{
    [TestClass]
    public class ActActionTest
    {
        [TestMethod]
        public void Test_SysColor()
        {
            var color = Color.Black;
            var actAction = new ActAction
            {
                AlertColor = color.ToArgb()
            };

            Assert.AreEqual("#000000", actAction.SysColor);
        }
    }
}
