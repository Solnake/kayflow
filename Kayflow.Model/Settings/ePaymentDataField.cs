using System.ComponentModel;

namespace Kayflow.Model
{
    public enum ePaymentDataField
    {
        [Description("Загальна вартість робіт")]
        TotalCost = 1,
        [Description("Оплачено на вимірах")]
        PaidOn,
        [Description("Залишено на місці")]
        LeftOn,
        [Description("Погодження 1")]
        Approval1,
        [Description("Оплачено на ПП Кайлас-К")]
        KailasPaid1,
        [Description("Заборгованість по ПП Кайлас-К")]
        KailasDue,
        [Description("Оплачена заборгованість (після виїзду)")]
        PaidDue,
        [Description("Погодження 2")]
        Approval2,
        [Description("Оплачено на ПП Кайлас-К 2")]
        KailasPaid2
    }
}
