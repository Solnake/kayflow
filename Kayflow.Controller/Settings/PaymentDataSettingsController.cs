using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class PaymentDataSettingsController: KayflowController<PaymentDataSettings>
    {
        #region -= Constructors =-

        public PaymentDataSettingsController() : this(null, null, false) { }
        public PaymentDataSettingsController(PaymentDataSettings model) : this(model, null, false) { }
        public PaymentDataSettingsController(PaymentDataSettings model, DALCBase parent) : this(model, parent, true) { }
        public PaymentDataSettingsController(PaymentDataSettings model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}