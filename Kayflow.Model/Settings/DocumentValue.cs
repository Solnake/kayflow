using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class DocumentValue : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid DocumentValueID { get; set; }

        [DBMaping]
        [Required]
        public Guid ValueSetID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string DocValue { get; set; }

        [DBMaping]
        [Required]
        [StringLength(16)]
        public int DocColor { get; set; }
    
    }
}