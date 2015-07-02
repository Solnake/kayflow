using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class EmployeeOfficesManager : KayflowMultiManager<EmployeeOfficesController, EmployeeOffices>
    {
        public List<EmployeeOffices> GetByEmployeeID(Guid employeeId)
        {
            Filter.AddCondition("EmployeeID", eOperationType.Equal, employeeId);
            return GetAll("OfficeName");
        } 
    }
}
