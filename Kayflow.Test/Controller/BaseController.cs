using System;
using Kayflow.Controller;
using Kayflow.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kayflow.Test.Controller
{
    public class BaseController<TC, TM>: BaseTestController
        where TC : KayflowController<TM>, new()
        where TM : BaseModel, new()

    {
        [TestMethod]
        public virtual void Test_GetAll()
        {
            var controller = CreateController<TC>();
            var list = controller.GetAll();
            Assert.IsNotNull(list); 
        }

        [TestMethod]
        public virtual void TestNull_Get()
        {
            var contoller = CreateController<TC>();
            var model = contoller.Get(Guid.Empty);
            Assert.IsNull(model);
        }
    }
}
