using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class TerritorialUnit : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid TerritorialUnitID { get; set; }

        [DBMaping]
        public Guid? ParentID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        [DBFieldInfo(IsName = true)]
        public string UnitName { get; set; }

        [DBMaping]
        [Required]
        public eUnitType UnitType { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        public eUnitType? ParentUnitType { get; set; }
        public string ParentUnitName { get; set; }

    }
}