using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActController: KayflowController<Act>
    {
        #region -= Constructors =-

        public ActController() : this(null, null, false) { }
        public ActController(Act model) : this(model, null, false) { }
        public ActController(Act model, DALCBase parent) : this(model, parent, true) { }
        public ActController(Act model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"select * from v_Acts ";
            }
        }        

        protected override string m_GetQueryTemplate
        {
            get
            {
                return m_GetAllQueryTemplate + "where {1} = @{1}";
            }
        }
        
        #endregion

        public List<Act> GetByOfficeEx(Guid pOfficeId)
        {
            StProcedure.ProcedureName = "Acts_GetAll";
            StProcedure["@OfficeID"].Value = pOfficeId;
            return StProcedure.ExecuteListAttr<Act>();
        }

        public Act GetByIDEx(Guid pOfficeId, Guid pActId)
        {
            StProcedure.ProcedureName = "Acts_GetAll";
            StProcedure["@OfficeID"].Value = pOfficeId;
            StProcedure["@ActID"].Value = pActId;
            return StProcedure.ExecuteSingleAttr<Act>();
        }

        public List<Act> GetByStatusForEmployeeEx(Guid pOfficeId, bool pIsClosed, Guid? pEmployeeID = null)
        {
            StProcedure.ProcedureName = "Acts_GetAll";
            StProcedure["@OfficeID"].Value = pOfficeId;
            StProcedure["@IsClosed"].Value = pIsClosed;
            StProcedure["@EmployeeID"].Value = pEmployeeID;
            return StProcedure.ExecuteListAttr<Act>();
        }
        
    }
}