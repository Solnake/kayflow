using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_EmployeeList : BaseListControl<EmployeeManager, EmployeeController, Employee>
{
    public override ASPxGridView GridView
    {
        get { return gridList; }
    }

    public override ASPxButton AddButton
    {
        get { return btnAdd; }
    }

    public override string GetEditPopupTitle(bool isEdit = false)
    {
        return "працівника";
    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        gridList.Columns["SuperAdmin"].Visible = CurrentEmployee.SuperAdmin;
    }

    protected override void gvItems_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
    {
        base.gvItems_HtmlRowCreated(sender, e);
        if (e.RowType == GridViewRowType.Data)
        {
            var btnEdit = GetGridButton(e.VisibleIndex, "btnEdit", gridList);
            var btnDelete = GetGridButton(e.VisibleIndex, "btnDelete", gridList);
            var id = (Guid) e.KeyValue;
            var superAdmin = (bool) e.GetValue("SuperAdmin");
            btnDelete.Enabled = CurrentEmployee.ID != id & (!superAdmin || CurrentEmployee.SuperAdmin);
            btnEdit.Enabled = !superAdmin || CurrentEmployee.SuperAdmin;
        }
    }
}