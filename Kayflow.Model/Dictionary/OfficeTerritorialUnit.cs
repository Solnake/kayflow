using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class OfficeTerritorialUnit : ModelBaseMultiPK
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid TerritorialUnitID { get; set; }
    }
}