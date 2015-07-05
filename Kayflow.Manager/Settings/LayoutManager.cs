using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class LayoutManager : KayflowManager<LayoutController, Layout>
    {
        public List<Layout> GetAll(Guid pOffice)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOffice);
            return GetAll();
        }

        public Layout Get(Guid pOffice, eLayoutType pType)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOffice);
            Filter.AddCondition("LayoutType", eOperationType.Equal, pType);
            return GetAll().FirstOrDefault();
        }
    }
}