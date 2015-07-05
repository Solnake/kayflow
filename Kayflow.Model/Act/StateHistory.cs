using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class StateHistory : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid StateHistoryID { get; set; }

        [DBMaping]
        [Required]
        public Guid ActID { get; set; }

        [DBMaping]
        [Required]
        public Guid StateID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        [Required]
        public DateTime OnDate { get; set; }

        [DBMaping]
        [StringLength(1024)]
        public string Description { get; set; }

        [DBFieldInfo(IsName = true)]
        public string StateName { get; set; }
        public string EmployeeName { get; set; }
    }
}