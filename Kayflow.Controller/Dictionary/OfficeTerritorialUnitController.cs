using System;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class OfficeTerritorialUnitController : KayflowLinkController<OfficeTerritorialUnit>
    {
        #region -= Constructors =-

        public OfficeTerritorialUnitController() : this(null, null, false) { }
        public OfficeTerritorialUnitController(OfficeTerritorialUnit model) : this(model, null, false) { }
        public OfficeTerritorialUnitController(OfficeTerritorialUnit model, DALCBase parent) : this(model, parent, true) { }
        public OfficeTerritorialUnitController(OfficeTerritorialUnit model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
        #region override methods for parameters name binding

        public override OfficeTerritorialUnit Get(Guid OfficeID, Guid TerritorialUnitID)
        {
            return base.Get(OfficeID, TerritorialUnitID);
        }
        public override void Delete(Guid OfficeID, Guid TerritorialUnitID)
        {
            base.Delete(OfficeID, TerritorialUnitID);
        }
        public void DeleteByOfficeID(Guid OfficeID)
        {
            base.DeleteByPK1(OfficeID);
        }
        public void DeleteByTerritorialUnitID(Guid TerritorialUnitID)
        {
            base.DeleteByPK2(TerritorialUnitID);
        }

        #endregion

    }
}