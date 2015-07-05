using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_DocumentList : BaseListControl<DocumentManager, DocumentController, Document>
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
        return "додаткову колонку";
    }
}