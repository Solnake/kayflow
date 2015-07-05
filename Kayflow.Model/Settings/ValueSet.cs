using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class ValueSet : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ValueSetID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string SetName { get; set; }

    }
}