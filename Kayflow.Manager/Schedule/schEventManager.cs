using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class schEventManager : KayflowManager<schEventController, schEvent>
    {
        public List<schEvent> GetForEmployee(Guid pEmployeeId, Guid pOfficeId)
        {
            Filter.AddCondition("EmployeeID", eOperationType.Equal, pEmployeeId);
            return GetByOffice(pOfficeId);
        } 
    }
}