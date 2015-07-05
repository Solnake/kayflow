using System;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmPaymentDataSettingsList : BaseListForm
    {
        public frmPaymentDataSettingsList()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<PaymentDataSettingsManager>().GetForDictionary(CurrentInfo.OfficeID);
        }

        protected override void view_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void viewSettings_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Show")
            {
                var model = (viewSettings.GetRow(e.RowHandle) as PaymentDataSettings);
                if (model!=null)
                {
                    if (model.ID == Guid.Empty)
                    {
                        model.OfficeID = CurrentInfo.OfficeID;
                    }
                    model.Show = (bool) e.Value;
                    var manager = Factory.Manager<PaymentDataSettingsManager>();
                    manager.Model = model;
                    manager.Save();
                }
            }
        }
    }
}
