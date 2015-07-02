using System.Collections.Generic;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ExpenseManager : KayflowManager<ExpenseController, Expense>
    {
        public Expense SaveAll(List<ExpenseCost> pList)
        {
            return TransactionOverlay(delegate
                {
                    Save();
                    var manager = CreateManager<ExpenseCostManager>();
                    foreach (var cost in pList)
                    {
                        cost.ExpenseID = Model.ID;
                        manager.Model = cost;
                        manager.Save();
                    }

                    return Model;
                });
        }
    }
}