using System;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ActListSettingManager : KayflowManager<ActListSettingController, ActListSetting>
    {
        public new ActListSetting GetByOffice(Guid pOfficeID)
        {
            Filter.Clear();
            Filter.AddCondition("EmployeeID", eOperationType.IsNull);
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll().FirstOrDefault();
        }

        public ActListSetting GetForEmployee(Guid pOfficeID, Guid pEmployeeID)
        {
            return GetByEmployee(pOfficeID, pEmployeeID) ?? GetByOffice(pOfficeID);
        }

        public ActListSetting GetByEmployee(Guid pOfficeID, Guid pEmployeeID)
        {
            Filter.Clear();
            Filter.AddCondition("EmployeeID", eOperationType.Equal, pEmployeeID);
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll().FirstOrDefault();
        } 
    }
}