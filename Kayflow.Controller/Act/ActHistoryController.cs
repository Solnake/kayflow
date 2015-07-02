using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActHistoryController: KayflowController<ActHistory>
    {
        #region -= Constructors =-

        public ActHistoryController() : this(null, null, false) { }
        public ActHistoryController(ActHistory model) : this(model, null, false) { }
        public ActHistoryController(ActHistory model, DALCBase parent) : this(model, parent, true) { }
        public ActHistoryController(ActHistory model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select h.*, e.DisplayName EmployeeName, em.OfficeID
                        from ActHistory h
						join Act a on a.ActID=h.ActID
						join Employee em on em.EmployeeID=a.EmployeeID
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