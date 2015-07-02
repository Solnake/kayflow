using System;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

/// <summary>
/// Summary description for BaseListControl
/// </summary>
public abstract class BaseListControl<TM, C, M> : BaseControl
    where M : BaseModel, new()
    where C : KayflowController<M>, new()
    where TM : KayflowManager<C, M>, new()
{
    [Flags]
    protected enum  eGridButtons
    {
        Edit = 1,
        Delete = 2,
        All = 3
    }

    #region -= Properties =-

    protected virtual bool UseViewForm { get { return false; } }

    protected virtual bool UsePopupEdit { get { return true; } }

    protected virtual string ModelName { get { return typeof(M).Name; } }

    public abstract ASPxGridView GridView { get; }

    public abstract ASPxButton AddButton { get; }

    public virtual Literal ScriptLiteral { get { return null; } }

    protected virtual bool IsDictionnary { get { return true; } }

    protected virtual string AdditionalEditParams { get { return string.Empty; }}

    protected virtual eGridButtons GridButtons
    {
        get { return eGridButtons.All;}
    }

    #endregion

    #region -= Initialize =-

    protected override void DoInitialize_1_BeforeLoadData()
    {
        base.DoInitialize_1_BeforeLoadData();
        if (GridView == null) return;
        GridView.BeforePerformDataSelect += gvItems_BeforePerformDataSelect;
        GridView.CustomCallback += gvItems_CustomCallback;
        GridView.RowDeleting += gvItems_RowDeleting;
        GridView.HtmlRowCreated += gvItems_HtmlRowCreated;
        GridView.SettingsBehavior.ConfirmDelete = false;
    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        if (AddButton != null)
        {
            if (AddButton.Enabled)
            {
                if (UsePopupEdit)
                    AddButton.ClientSideEvents.Click = jsFunctionOverlay(GetEditScript(Guid.Empty));
                else
                {
                    string link = string.Format("{0}?view={1}Edit", Request.Path, ModelName);
                    AddButton.ClientSideEvents.Click = jsFunctionOverlayFormat("window.location = '{0}'",
                                                                                link);
                }
            }
        }
    }

    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        if (GridView != null)
            GridView.DataBind();
    }

    protected override void DoInitialize_4_LoadDataFinal()
    {
        base.DoInitialize_4_LoadDataFinal();
        if (GridView == null) return;
        string afterEditScript = GetAfterEditScript();
        if (UsePopupEdit)
        {
            if (ScriptLiteral != null)
            {
                ScriptLiteral.Text = GetEditBodyScript()
                    .Replace("%AfterEditScript%", afterEditScript)
                    .Replace("%Title%", GetEditPopupTitle())
                    .Replace("%ModelName%", ModelName)
                    .Replace("%Mode%", "Edit")
                    .Replace("%GUID%", Storage.StorageID)
                    .Replace("%GridView%", GridView.ClientID);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString("N"), GetEditBodyScript()
                    .Replace("%AfterEditScript%", afterEditScript)
                    .Replace("%Title%", GetEditPopupTitle(true))
                    .Replace("%ModelName%", ModelName)
                    .Replace("%Mode%", "Edit")
                    .Replace("%GUID%", Storage.StorageID)
                    .Replace("%GridView%", GridView.ClientID)
                    .Replace("%AddEditParams%", AdditionalEditParams));
            }
        }
    }
    #endregion

    #region -= Virtual Methods =-

    public virtual string GetEditPopupTitle(bool isEdit = false)
    {
        return string.Empty;
    }

    protected virtual string FormatViewEditLink(object id, string text, string mode)
    {
        if (UsePopupEdit)
            return string.Format("<a href=\"javascript:void(0);\" onclick=\"{0} return false;\">{1}</a>",
                GetEditScript(id), text);
        return string.Format("<a href='{0}'>{1}</a>",

                             string.Format("{0}?view={1}{2}&id={3}", Request.Path, ModelName, mode, id),
                             text);
    }

    protected virtual string GetEditScript(object id)
    {
        if (UsePopupEdit)
            return string.Format("Edit{0}('{1}');", Storage.StorageID, id);
        return string.Format("location = '{0}?view={1}Edit&id={2}';", Request.Path, ModelName, id);
    }

    protected virtual string GetAfterEditScript()
    {
        return string.Empty;
    }

    protected virtual string GetViewScript(object id, string parameters)
    {
        return string.Format("View{0}({1}, '{2}');", Storage.StorageID, id, parameters);
    }

    protected virtual string GetDeleteScript(object visibleIndex, ASPxGridView grid = null)
    {
        grid = grid ?? GridView;
        string text = string.IsNullOrEmpty(grid.SettingsText.ConfirmDelete) ?
            "Ви дійсно бажаєте видалити запис?" : grid.SettingsText.ConfirmDelete;
        return " if (confirm('" + text + "')) gfGetElement('" + grid.ClientID + "').DeleteGridRow(" + visibleIndex + ");";
    }

    protected virtual string GetEditBodyScript()
    {
        return @"
<script type='text/javascript' id='dxss_%ModelName%_%GUID%_Scripts'>
    window.IsNew%GUID% = false;
    window.Edit%GUID% = function(value) {
        if ((value != null) && (value != 0)) {
            DialogForm_ShowFrame('Редагувати %Title%', '%ModelName%%Mode%', 'id=' + value + '%AddEditParams%', 'On%GUID%EditComplete');
        }
        else {
            IsNew%GUID% = true;
            DialogForm_ShowFrame('Додати %Title%', '%ModelName%%Mode%', 'id=0' + '%AddEditParams%', 'On%GUID%EditComplete');
        }
    }
    window.On%GUID%EditComplete = function(result) {
        if (result) {
            gfGetElement('%GridView%').PerformCallback('focusedid=' + result);
             %AfterEditScript%
        }
    }
    
    
</script>";
    }
    #endregion

    #region -= Grid Methods =-

    protected virtual void gvItems_BeforePerformDataSelect(object sender, EventArgs e)
    {
        var manager = CreateManager<TM>();
        GridView.DataSource = IsDictionnary
            ? manager.GetForDictionary(CurrentOffice.ID)
            : manager.GetByOffice(CurrentOffice.OfficeID);
    }

    protected virtual void gvItems_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        try
        {
            var id = (Guid)e.Values[GridView.KeyFieldName];
            DoDelete(id);
            GridView.DataBind();
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected virtual void gvItems_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        GridView.JSProperties["cpResult"] = null;
        var focusedid = Guid.Empty;
        try
        {
            if (!string.IsNullOrEmpty(e.Parameters))
            {
                foreach (var param in e.Parameters.Split('|').Select(pairs => pairs.Split('=')).Where(param => param.Length > 0))
                {
                    switch (param[0])
                    {
                        case "focusedid":
                            if (param.Length > 1)
                                Guid.TryParse(param[1], out focusedid);
                            break;
                    }
                }
            }
        }
        finally
        {
            GridView.DataBind();
        }
        if (focusedid != Guid.Empty)
            GridView.FocusedRowIndex = GridView.FindVisibleIndexByKeyValue(focusedid);

    }

    protected virtual void gvItems_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data)
        {
            int visibleIndex = e.VisibleIndex;
            if (GridButtons.HasFlag(eGridButtons.Edit))
                GridButton_SetEventClick(visibleIndex, "btnEdit", GetEditScript(e.KeyValue));
            if (GridButtons.HasFlag(eGridButtons.Delete))
                GridButton_SetEventClick(visibleIndex, "btnDelete", GetDeleteScript(visibleIndex));
        }
    }

    protected void GridButton_SetEventClick(int visibleIndex, string btnName, string script, ASPxGridView grid = null)
    {
        grid = grid ?? GridView;
        var button = GetGridButton(visibleIndex, btnName, grid);
        button.ClientSideEvents.Click = jsFunctionOverlay(script);
    }

    protected ASPxButton GetGridButton(int visibleIndex, string btnName, ASPxGridView grid)
    {
        var button = grid.FindRowCellTemplateControl(visibleIndex, null, btnName) as ASPxButton;
        if (button == null)
            throw new NullReferenceException("Buttond with this name doesn't exist");
        return button;
    }

    #endregion

    protected virtual void DoDelete(Guid pID)
    {
        CreateManager<TM>().Delete(pID);
    }
}