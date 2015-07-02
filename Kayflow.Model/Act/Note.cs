using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Note : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid NoteID { get; set; }

        [DBMaping]
        [Required]
        public Guid ActID { get; set; }

        [DBMaping]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        [Required]
        public DateTime OnDate { get; set; }

        [DBMaping]
        [Required]
        [StringLength(1024)]
        [DBFieldInfo(IsName = true)]
        public string Description { get; set; }

        public string EmployeeName { get; set; }

    }
}