using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ActHistoryManager : KayflowManager<ActHistoryController, ActHistory>
    {
        public List<ActHistory> GetForAct(Guid pActID)
        {
            Filter.AddCondition("ActID", eOperationType.Equal, pActID);
            return GetAll();
        }
    }
}