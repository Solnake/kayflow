using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class DocumentValueManager : KayflowManager<DocumentValueController, DocumentValue>
    {
        public List<DocumentValue> GetBySet(Guid pValueSet)
        {
            Filter.AddCondition("ValueSetID", eOperationType.Equal, pValueSet);
            return GetAll();
        }
    }
}