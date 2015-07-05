using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ExpenseController: KayflowController<Expense>
    {
        #region -= Constructors =-

        public ExpenseController() : this(null, null, false) { }
        public ExpenseController(Expense model) : this(model, null, false) { }
        public ExpenseController(Expense model, DALCBase parent) : this(model, parent, true) { }
        public ExpenseController(Expense model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select e.*, ee.DisplayName EmployeeName
	                        , sum(c.Amount) Summ
                        from Expense e
                        join vEmployee ee on ee.EmployeeID=e.EmployeeID
                        left join vExpenseCost c on c.ExpenseID=e.ExpenseID
                        group by
                        	e.ExpenseID, e.EmployeeID, e.OnDate, e.Distance, ee.DisplayName, e.OfficeID
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