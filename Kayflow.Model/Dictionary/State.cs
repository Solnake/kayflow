using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class State : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid StateID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBFieldInfo(IsName = true)]
        [DBMaping]
        [Required]
        [StringLength(256)]
        public string StateName { get; set; }
    }
}