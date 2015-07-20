using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class schEventController: KayflowController<schEvent>
    {
        #region -= Constructors =-

        public schEventController() : this(null, null, false) { }
        public schEventController(schEvent model) : this(model, null, false) { }
        public schEventController(schEvent model, DALCBase parent) : this(model, parent, true) { }
        public schEventController(schEvent model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select e.*, em.OfficeID
                        from schEvent e
                        join EmployeeOffices em on em.EmployeeID=e.EmployeeID
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