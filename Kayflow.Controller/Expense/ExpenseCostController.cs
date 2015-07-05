using System;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ExpenseCostController: KayflowLinkController<ExpenseCost>
    {
        #region -= Constructors =-

        public ExpenseCostController() : this(null, null, false) { }
        public ExpenseCostController(ExpenseCost model) : this(model, null, false) { }
        public ExpenseCostController(ExpenseCost model, DALCBase parent) : this(model, parent, true) { }
        public ExpenseCostController(ExpenseCost model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"SELECT *
                    FROM (
                        SELECT c.*, em.OfficeID
						FROM vExpenseCost c
						join Expense e on e.ExpenseID=c.ExpenseID
						join Employee em on em.EmployeeID=e.EmployeeID
                    ) x ";
            }
        }        

        protected override string m_GetQueryTemplate
        {
            get { return m_GetAllQueryTemplate + "where {1} = @{1}"; }
        }
        
        #endregion
        
        #region override methods for parameters name binding

        public override ExpenseCost Get(Guid ExpenseID, Guid CostID)
        {
            return base.Get(ExpenseID, CostID);
        }
        public override void Delete(Guid ExpenseID, Guid CostID)
        {
            base.Delete(ExpenseID, CostID);
        }
        public void DeleteByExpenseID(Guid ExpenseID)
        {
            base.DeleteByPK1(ExpenseID);
        }
        public void DeleteByCostID(Guid CostID)
        {
            base.DeleteByPK2(CostID);
        }

        #endregion

    }
}