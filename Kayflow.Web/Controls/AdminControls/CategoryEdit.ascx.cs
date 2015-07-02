using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_CategoryEdit : BaseEditControl<CategoryManager, CategoryController, Category>
{
    protected override ASPxCallback GetCallbackControl()
    {
        return clbkSave;
    }

    protected override ASPxButton GetCancelButton()
    {
        return btnCancel;
    }

    protected override ASPxButton GetOkButton()
    {
        return btnOk;
    }

    protected override ASPxFormLayout Layout
    {
        get { return frmEditForm; }
    }

    protected override void LoadModelDataFromControls(Category model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.OfficeID;
        model.CategoryName = GetValue<string>(txtName);
    }
}