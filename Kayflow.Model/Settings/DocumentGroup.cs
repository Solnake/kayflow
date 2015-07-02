using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class DocumentGroup : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid DocumentGroupID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string GroupName { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        public int OrdNum { get; set; }

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

        public List<Document> Documents { get; set; }

    }
}