using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class CompanyMessage : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid CompanyMessageID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(1024)]
        [DBFieldInfo(IsName = true)]
        public string MessageText { get; set; }
        
        public string OfficeName { get; set; }

        public CompanyMessage()
        {

        }
    }
}