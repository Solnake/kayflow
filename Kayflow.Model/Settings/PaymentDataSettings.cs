using System;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class PaymentDataSettings : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid PaymentDataSettingsID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [DBFieldInfo(IsName = true)]
        public ePaymentDataField PaymentFieldID { get; set; }

        [DBMaping]
        [Required]
        public bool Show { get; set; }

        public override string Name
        {
            get
            {
                return PaymentFieldID.GetName();
            }
        }
    }
}