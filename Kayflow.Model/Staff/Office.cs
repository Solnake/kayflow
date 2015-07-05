using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Office : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string OfficeName { get; set; }
    }
}