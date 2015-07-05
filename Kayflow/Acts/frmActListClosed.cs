using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Acts
{
    public partial class frmActListClosed : frmActList
    {
        public frmActListClosed()
        {
            InitializeComponent();
            ViewLayoutType = eLayoutType.Act;
            
        }

        protected override void BaseListForm_Load(object sender, System.EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            Text = "Список закритих справ";
        }

        protected override void BindData()
        {
            var manager = Factory.Manager<ActManager>();
            manager.Filter.AddCondition("IsClosed", eOperationType.Equal, true);
            gridList.DataSource =
                manager.GetByOffice(CurrentInfo.OfficeID);
        }
    }
}
