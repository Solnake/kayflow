using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Step : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid StepID { get; set; }

        [DBMaping]
        [Required]
        public Guid ActID { get; set; }

        [DBMaping]
        [Required]
        public Guid ActActionID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        public DateTime? Delivered { get; set; }

        [DBMaping]
        public DateTime? Received { get; set; }

        [DBFieldInfo(IsName = true)]
        public string ActionName { get; set; }
        public int? AlertDays { get; set; }
        public int? AlertColor { get; set; }
        public int OrdNum { get; set; }
    }
}