using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ExpenseCostManager : KayflowMultiManager<ExpenseCostController, ExpenseCost>
    {
        public List<ExpenseCost> GetAll(Guid pExpenseID)
        {
            Filter.AddCondition("ExpenseID", eOperationType.Equal, pExpenseID);
            return GetAll("CostName");
        }

        public List<ExpenseCost> GetByOffice(Guid pOfficeID)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll();
        }
    }
}