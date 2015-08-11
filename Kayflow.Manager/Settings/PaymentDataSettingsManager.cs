using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class PaymentDataSettingsManager : KayflowManager<PaymentDataSettingsController, PaymentDataSettings>
    {
        public override List<PaymentDataSettings> GetForDictionary(Guid pOfficeID)
        {
            return CheckSettings(base.GetForDictionary(pOfficeID), false);
        }

        public override List<PaymentDataSettings> GetByOffice(Guid pOfficeID)
        {
            return CheckSettings(base.GetByOffice(pOfficeID), true);
        }

        public PaymentDataSettings GetDataSettings(Guid pOfficeID, ePaymentDataField pField)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            Filter.AddCondition("PaymentFieldID", eOperationType.Equal, pField);
            return GetAll().FirstOrDefault() ??
                   new PaymentDataSettings {OfficeID = pOfficeID, PaymentFieldID = pField};
        }

        private List<PaymentDataSettings> CheckSettings(List<PaymentDataSettings> list, bool pIgnoreHidden)
        {
            var fields = Enum.GetValues(typeof (ePaymentDataField)).Cast<ePaymentDataField>().ToList();
            foreach (var field in fields.FindAll(f => list.All(l => l.PaymentFieldID != f)))
            {
                list.Add(new PaymentDataSettings
                    {
                        PaymentFieldID = field,
                        Show = true
                    });
            }
            return list.OrderBy(i => (int) i.PaymentFieldID).ToList();
        }
    }
}