using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class StateHistoryController: KayflowController<StateHistory>
    {
        #region -= Constructors =-

        public StateHistoryController() : this(null, null, false) { }
        public StateHistoryController(StateHistory model) : this(model, null, false) { }
        public StateHistoryController(StateHistory model, DALCBase parent) : this(model, parent, true) { }
        public StateHistoryController(StateHistory model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select h.*, s.StateName, e.DisplayName EmployeeName, s.OfficeID
                        from StateHistory h
                        join [State] s on s.StateID=h.StateID
                        join vEmployee e on e.EmployeeID=h.EmployeeID
                    ) x
                ";
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
        
    }
}