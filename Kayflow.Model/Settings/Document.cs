using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Document : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid DocumentID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string DocumentName { get; set; }

        [DBMaping]
        [Required]
        public Guid DocumentGroupID { get; set; }

        [DBMaping]
        [Required]
        public int OrdNum { get; set; }

        [DBMaping]
        [Required]
        public bool Hidden { get; set; }

        [DBMaping]
        [Required]
        public Guid ValueSetID { get; set; }

        [DBMaping]
        [Required]
        public bool ShowComments { get; set; }

        public string SetName { get; set; }
        public string GroupName { get; set; }
        public int GroupOrdNum { get; set; }

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
    }
}