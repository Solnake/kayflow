using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_StatusHistoryList : BaseListControl<NoteManager, NoteController, Note>
{
    protected override string AdditionalEditParams
    {
        get { return string.Format("&ActID={0}", DocID); }
    }

    public override ASPxGridView GridView
    {
        get { return gridList; }
    }

    public override ASPxButton AddButton
    {
        get { return null; }
    }

    protected override eGridButtons GridButtons
    {
        get { return eGridButtons.Delete; }
    }

    public override string GetEditPopupTitle(bool isEdit = false)
    {
        return "причину затримки";
    }

    protected override void gvItems_BeforePerformDataSelect(object sender, EventArgs e)
    {
        GridView.DataSource =
            CreateManager<StateHistoryManager>().GetForAct(DocID).FindAll(s => !string.IsNullOrEmpty(s.Description));
    }
}