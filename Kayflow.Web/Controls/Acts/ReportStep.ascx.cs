using Kayflow.Manager;
using Kayflow.Reports;

public partial class Controls_Acts_ReportStep : BaseControl
{
    protected override void DoInitialize_1_BeforeLoadData()
    {
        base.DoInitialize_1_BeforeLoadData();
        var collection = new ActCollection();
        collection.BindWithSteps(CreateManager<ActManager>().Controller.GetByOfficeEx(CurrentOffice.ID));
        dvReport.Report = new StepReport { DataSource = collection };
    }
}