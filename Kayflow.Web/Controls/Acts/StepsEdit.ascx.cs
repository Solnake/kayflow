using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_StepsEdit : BaseEditControl<StepManager, StepController, Step>
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

    protected override void LoadModelDataFromControls(Step model)
    {

    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo<StateManager>(ddlStatus, e0Type.PlsSelect);
    }

    protected override void DoInitialize_3_LoadDataMain()
    {
        var status = CreateManager<StateHistoryManager>().GetCurrent(DocID);
        if (status != null)
            ddlStatus.Value = status.StateID;
        gridSteps.DataBind();
    }

    protected void gridSteps_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridSteps.DataSource = CreateManager<StepManager>().GetForAct(DocID);
    }

    protected override object DoSave(object data)
    {
        ExceptionCheck(delegate
        {
            var list = CreateManager<StepManager>().GetForAct(DocID);
            for (var i = 0; i < gridSteps.VisibleRowCount; i++)
            {
                var id = (Guid)gridSteps.GetRowValues(i, "ID");
                var txtDelivered = gridSteps.FindRowCellTemplateControl(i, null, "txtDelivered") as ASPxDateEdit;
                var txtReceived = gridSteps.FindRowCellTemplateControl(i, null, "txtReceived") as ASPxDateEdit;
                var step = list.Find(s => s.ID == id);
                if (txtDelivered != null && txtReceived != null && step != null)
                {
                    step.Delivered = GetValue<DateTime?>(txtDelivered);
                    step.Received = GetValue<DateTime?>(txtReceived);
                }
            }

            CreateManager<StepManager>().SaveAll(list,
                new StateHistory
                {
                    ActID = DocID,
                    EmployeeID = CurrentEmployee.ID,
                    StateID = GetValue<Guid>(ddlStatus),
                    StateName = ddlStatus.Text,
                    Description = txtStateDescription.Text,
                    OnDate = DateTime.Now
                },
                new Note
                {
                    ActID = DocID,
                    EmployeeID = CurrentEmployee.ID,
                    Description = txtDescription.Text,
                    OnDate = DateTime.Now
                });
        });
        return DocID;
    }
}