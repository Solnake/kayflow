using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Cost : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid CostID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string CostName { get; set; }

        [DBMaping]
        [Required]
        public bool Hidden { get; set; }

        public bool Show
        {
            get
            {
                return !Hidden;
            }  
            set
            {
                Hidden = !value;
            }
        }

        public Cost()
        {
            Show = true;
        }

    }
}