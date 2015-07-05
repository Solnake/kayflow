using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Layout : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid LayoutID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        public byte[] LayoutData { get; set; }

        [DBMaping]
        [Required]
        public eLayoutType LayoutType { get; set; }
    }
}