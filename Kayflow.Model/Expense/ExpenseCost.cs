using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class ExpenseCost: ModelBaseMultiPK
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ExpenseID { get; set; }

        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid CostID { get; set; }

        [DBMaping]
        [Required]
        public double Amount { get; set; }

        public string CostName { get; set; }

    }
}