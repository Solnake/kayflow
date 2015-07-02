using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class TerritorialUnitManager : KayflowManager<TerritorialUnitController, TerritorialUnit>
    {
        public override List<TerritorialUnit> GetByOffice(Guid pOfficeID)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll("UnitType, UnitName");
        }

        public List<TerritorialUnit> GetByType(Guid pOfficeID, eUnitType pType)
        {
            Filter.AddCondition("UnitType", eOperationType.Equal, pType);
            return Controller.GetAllByOffice(pOfficeID).OrderBy(t => t.UnitName).ToList();
        }

        public List<TerritorialUnit> GetByType(eUnitType pType)
        {
            Filter.AddCondition("UnitType", eOperationType.Equal, pType);
            return GetAll("UnitType, UnitName");
        }

        public override TerritorialUnit Save()
        {
            return TransactionOverlay<TerritorialUnit>(SaveHandler);
        }

        private TerritorialUnit SaveHandler()
        {
            base.Save();
            if (Model.IsNew)
            {
                var manager = CreateManager<OfficeTerritorialUnitManager>();
                manager.Model = new OfficeTerritorialUnit
                {
                    TerritorialUnitID = Model.ID,
                    OfficeID = Model.OfficeID
                };
                manager.Save();
            }

            return Model;
        }
    }
}