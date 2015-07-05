using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class EmployeeOffices : ModelBaseMultiPK
    {
        [DBMaping(PrimaryKey = true, Identity = false)]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping(PrimaryKey = true, Identity = false)]
        [Required]
        public Guid OfficeID { get; set; }

        public string OfficeName { get; set; }
    }
}
