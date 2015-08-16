using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class ActDocument : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ActDocumentID { get; set; }

        [DBMaping]
        [Required]
        public Guid ActID { get; set; }

        [DBMaping]
        [Required]
        public Guid DocumentID { get; set; }

        [DBMaping]
        [Required]
        public Guid DocumentValueID { get; set; }

        [DBMaping]
        [StringLength(256)]
        public string Comment { get; set; }
        
        [DBFieldInfo(IsName = true)]
        public string DocumentName { get; set; }
        public string GroupName { get; set; }
        public Guid DocumentGroupID { get; set; }
        public string DocValue { get; set; }
        public int DocumentOrdNum { get; set; }
        public int GroupOrdNum { get; set; }
        public Guid ValueSetID { get; set; }
        public int? DocColor { get; set; }

        public bool ShowComments { get; set; }
    }
}