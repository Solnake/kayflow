using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Acts
{
    public partial class frmActListMy : frmActList
    {
        public frmActListMy()
        {
            InitializeComponent();
            ViewLayoutType = eLayoutType.Act;
        }

        protected override void BaseListForm_Load(object sender, System.EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            Text = "Список моїх справ";
        }

        protected override void BindData()
        {
            var manager = Factory.Manager<ActManager>();
            manager.Filter.AddCondition("IsClosed", eOperationType.Equal, false);
            manager.Filter.AddCondition("EmployeeID", eOperationType.Equal, CurrentInfo.EmployeeID);
            manager.Filter.AddCondition("OfficeID", eOperationType.Equal, CurrentInfo.OfficeID);
            gridList.DataSource =
                manager.GetByOffice(CurrentInfo.OfficeID);
        }
    }
}
