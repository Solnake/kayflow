using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Expense : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ExpenseID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        public Guid? OfficeID { get; set; }

        [DBMaping]
        [Required]
        [DBFieldInfo(IsName =true)]
        public DateTime OnDate { get; set; }

        [DBMaping]
        public int? Distance { get; set; }

        public string EmployeeName { get; set; }
        public double? Summ { get; set; }

        /// <summary>
        /// For Export/Import only
        /// </summary>
        public List<ExpenseCost> Costs { get; set; }
    }
}