using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class OfficeTerritorialUnitManager : KayflowMultiManager<OfficeTerritorialUnitController, OfficeTerritorialUnit>
    {
        public List<OfficeTerritorialUnit> GetByOffice(Guid officeId)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, officeId);
            return GetAll();
        }

        public void SaveAll(IEnumerable<OfficeTerritorialUnit> listUnits, Guid officeId)
        {
            Controller.TransactionOverlay(delegate
            {
                Controller.DeleteByOfficeID(officeId);
                foreach (var unit in listUnits)
                {
                    Model = unit;
                    Save();
                }
            });
        }
    }
}