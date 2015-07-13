using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class schEvent : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid EventID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        [Required]
        public DateTime StartDate { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string Subject { get; set; }
    }
}