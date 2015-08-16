using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Act : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ActID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        [Required]
        [DBFieldInfo(IsName = true)]
        [CustomizeInfo(Customizable = true, DisplayName = "Дата")]
        public DateTime MeteringDate { get; set; }

        [DBMaping]
        [Required]
        public Guid TerritorialUnitID { get; set; }

        [DBMaping]
        [StringLength(512)]
        [CustomizeInfo(Customizable = true, DisplayName = "Адреса")]
        public string Address { get; set; }

        [DBMaping]
        [Required]
        [StringLength(512)]
        [CustomizeInfo(Customizable = true, DisplayName = "Замовник")]
        public string CustomerName { get; set; }

        [DBMaping]
        [StringLength(72)]
        [CustomizeInfo(Customizable = true, DisplayName = "Телефон")]
        public string CustomerPhone { get; set; }

        [DBMaping]
        [Required]
        [CustomizeInfo(Customizable = true, DisplayName = "К-сть ділянок")]
        public int AreaAmount { get; set; }

        [DBMaping]
        [Required]
        [CustomizeInfo(Customizable = true, DisplayName = "К-сть актів")]
        public int ActAmount { get; set; }

        [DBMaping]
        [Required]
        public Guid CategoryID { get; set; }

        [DBMaping]
        public double? TotalCost { get; set; }

        [DBMaping]
        public double? PaidOn { get; set; }

        [DBMaping]
        public double? LeftOn { get; set; }

        [DBMaping]
        public double? Approval1 { get; set; }

        [DBMaping]
        public double? KailasPaid1 { get; set; }

        [DBMaping]
        public double? KailasDue { get; set; }

        [DBMaping]
        public double? PaidDue { get; set; }

        [DBMaping]
        public double? Approval2 { get; set; }

        [DBMaping]
        public double? KailasPaid2 { get; set; }

        [DBMaping]
        public double? SalaryCalculated { get; set; }

        [DBMaping]
        public DateTime? SalaryPaidDate { get; set; }

        [DBMaping]
        public double? CalculatedMain { get; set; }

        [DBMaping]
        public DateTime? PaidMainDate { get; set; }

        [DBMaping]
        [CustomizeInfo(Customizable = true, DisplayName = "Дата договору")]
        public DateTime? ActDate { get; set; }

        [DBMaping]
        [StringLength(12)]
        [CustomizeInfo(Customizable = true, DisplayName = "№ договору")]
        public string ActNum { get; set; }

        [DBMaping]
        [StringLength(256)]
        public string Description { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        public bool IsClosed { get; set; }

        [DBMaping]
        public bool IgnoreTherms { get; set; }

        [CustomizeInfo(Customizable = true, DisplayName = "Землевпорядник")]
        public string EmployeeName { get; set; }

        [CustomizeInfo(Customizable = true, DisplayName = "Нас. пункт")]
        public string UnitName { get; set; }

        [CustomizeInfo(Customizable = true, DisplayName = "Категорія")]
        public string CategoryName { get; set; }
        
        public Guid StateID { get; set; }
        public string StateName { get; set; }

        public string AlertStep { get; set; }
        public int? AlertDays { get; set; }
        public int? AlertColor { get; set; }

        #region -= For Export/Import =-

        /// <summary>
        /// For Export/Import use only
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// For Export/Import use only
        /// </summary>
        public List<ActHistory> History { get; set; }

        /// <summary>
        /// For Export/Import use only
        /// </summary>
        public List<StateHistory> States { get; set; }

        /// <summary>
        /// For Export/Import use only
        /// </summary>
        public List<ActDocument> DocumentList { get; set; }

        /// <summary>
        /// For Export/Import use only
        /// </summary>
        public List<Step> StepList { get; set; }

        #endregion
    }
}