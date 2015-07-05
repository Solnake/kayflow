using System;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class EmployeeOfficesController : KayflowLinkController<EmployeeOffices>
    {
        #region constructors

        public EmployeeOfficesController() : this(null, null, false) { }
        public EmployeeOfficesController(EmployeeOffices model) : this(model, null, false) { }
        public EmployeeOfficesController(EmployeeOffices model, DALCBase parent) : this(model, parent, true) { }
        public EmployeeOfficesController(EmployeeOffices model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region SQL

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    select * from
                    (
                    select e.*, o.OfficeName from EmployeeOffices e
                    join Office o on o.OfficeID=e.OfficeID           
                    ) x
                ";
            }
        }

        protected override string m_GetQueryTemplate
        {
            get
            {
                return m_GetAllQueryTemplate + " WHERE {1} = @{1}";
            }
        }


        #endregion
        
        #region override methods for parameters name binding

        public override EmployeeOffices Get(Guid EmployeeID, Guid OfficeID)
        {
            return base.Get(EmployeeID, OfficeID);
        }
        public override void Delete(Guid EmployeeID, Guid OfficeID)
        {
            base.Delete(EmployeeID, OfficeID);
        }
        public void DeleteByEmployeeID(Guid EmployeeID)
        {
            base.DeleteByPK1(EmployeeID);
        }
        public void DeleteByOfficeID(Guid OfficeID)
        {
            base.DeleteByPK2(OfficeID);
        }

        #endregion
    }
}
