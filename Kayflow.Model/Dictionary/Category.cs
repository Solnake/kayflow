using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Category : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid CategoryID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string CategoryName { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

    }
}