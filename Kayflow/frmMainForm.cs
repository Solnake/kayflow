using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using Framework.SqlDataAccess.Manager;
using Kayflow.Acts;
using Kayflow.Controller;
using Kayflow.Dictionary;
using Kayflow.Expenses;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;
using Kayflow.Reports;
using Kayflow.Settings;
using Kayflow.Staff;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Kayflow
{
    public partial class frmMainForm : BaseMainForm
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool ErrorDB { get; set; }

        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            if (!ErrorDB)
                RefreshOffice();
            RefreshItemsEnabled();
            if (EmployeeID != Guid.Empty)
            {
                var model = Factory.Controller<EmployeeController>().Get(EmployeeID);
                lblUserInfo.Caption = string.Format("Користувач: {0} ({1})", model.Login, model.DisplayName);
                lblOfficeInfo.Caption = string.Format("Офіс: {0}", model.OfficeName);
            }
        }

        private void RefreshItemsEnabled()
        {
            btnEmployeeList.Enabled = OfficeID != Guid.Empty
                                      && (EmployeeID == Guid.Empty
                                          || Permission == ePermissions.Admin);
            btnOffice.Enabled = (EmployeeID == Guid.Empty
                                 || Permission == ePermissions.Admin) && !ErrorDB;
            btnTerritorialUnit.Enabled = OfficeID != Guid.Empty;
            btnCategoryList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnCostList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnStateList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnDocumentGroupList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnDocumentList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnPaymentDataSettingsList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnActActionList.Enabled = OfficeID != Guid.Empty
                                  && Permission == ePermissions.Admin;
            btnAct.Enabled = OfficeID != Guid.Empty;
            btnClosedActs.Enabled = btnAct.Enabled;
            btnMyActs.Enabled = btnAct.Enabled;
            btnExpence.Enabled = OfficeID != Guid.Empty;
            btnExport.Enabled = OfficeID != Guid.Empty && Permission == ePermissions.Admin;
            //btnImport.Enabled = ((EmployeeID != Guid.Empty && Permission == ePermissions.Admin) ||
            //                     EmployeeID == Guid.Empty) && !ErrorDB;
            btnImport.Enabled = true;
            btnActReport.Enabled = OfficeID != Guid.Empty;
            btnReportStep.Enabled = OfficeID != Guid.Empty;
        }

        private void ShowForm<T>()
            where T : BaseListForm, new()
        {
            var frm = FormFactory.GetForm<T>(this);
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void tabbedView_DocumentActivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            var frm = e.Document.Form as IDefaultRibbonPage;
            if (frm != null)
            {
                if (frm.DefaultPage.Groups.Cast<RibbonPageGroup>().All(g => !g.Visible))
                    ribbon.UnMergeRibbon();
                else
                    ribbon.SelectedPage = frm.DefaultPage;
            }
        }

        private void barItemOffice_EditValueChanged(object sender, EventArgs e)
        {
            var officeId = (Guid)barItemOffice.EditValue;
            RefreshOffice(officeId);
        }

        private void RefreshOffice(Guid officeId)
        {
            if (OfficeID == Guid.Empty)
            {
                OfficeID = officeId;
                RefreshItemsEnabled();
            }
            else
                OfficeID = officeId;
            foreach (var document in tabbedView.Documents)
            {
                var frm = document.Form as BaseListForm;
                if (frm != null)
                    frm.ReloadData();
            }
        }

        public override void RefreshOffice()
        {
            ddlOffice.DataSource = Factory.Manager<OfficeManager>().GetAll("OfficeName");
            if (CurrentEmployee != null)
            {
                barItemOffice.EditValue = CurrentEmployee.OfficeID;
            }
        }

        #region -= Forms =-
        private void btnOffice_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmOfficeList>();
        }

        private void btnEmployeeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmEmployeeList>();
        }

        private void btnTerritorialUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmTerritorialUnitList>();
        }

        private void btnCategoryList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmCategoryList>();
        }

        private void btnCostList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmCostList>();
        }

        private void btnStateList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmStateList>();
        }

        private void btnDocumentGroupList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmDocumentGroupList>();
        }

        private void btnDocumentList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmDocumentList>();
        }

        private void btnPaymentDataSettingsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmPaymentDataSettingsList>();
        }

        private void btnActActionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmActActionList>();
        }

        private void btnAct_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmActList>();
        }

        private void btnClosedActs_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmActListClosed>();
        }

        private void btnMyActs_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmActListMy>();
        }

        private void btnExpence_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<frmExpenseList>();
        }

        #endregion

        #region -= Reports =-
        private void btnActReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            var collection = new ActCollection();
            try
            {
                collection.BindWithDocuments(Factory.Manager<ActManager>().GetByOffice(OfficeID));
                var report = new ActMainReport
                {
                    DataSource = collection,
                    OfficeID = OfficeID
                };
                report.ShowPreview();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message, exception);
                MessageBox.Show(Resources.errorReport,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void btnReportStep_ItemClick(object sender, ItemClickEventArgs e)
        {
            var collection = new ActCollection();
            try
            {
                collection.BindWithSteps(Factory.Manager<ActManager>().GetByOffice(OfficeID));
                var report = new StepReport { DataSource = collection };
                report.ShowPreview();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message, exception);
                MessageBox.Show(Resources.errorReport,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        } 
        #endregion 

        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dialogExport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pgLongProcess.EditValue = 0;
                    exportWorker.RunWorkerAsync(OfficeID);
                }
                catch (Exception exception)
                {
                    log.Error(exception.Message, exception);
                    MessageBox.Show(exception.Message,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dialogImport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pgLongProcess.EditValue = 0;
                    importWorker.RunWorkerAsync(dialogImport.OpenFile());
                }
                catch (Exception exception)
                {
                    log.Error(exception.Message, exception);
                    MessageBox.Show(exception.Message,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        #region -= Export Worker =-
        private void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var manager = new ImportExportManager();
            manager.Progress +=
                (o, args) => exportWorker.ReportProgress(args.Progress);
            e.Result = manager.GetExportAllOffice();
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var model = e.Result as List<MasterModel>;
            if (model != null)
            {
                var settings = new XmlWriterSettings
                {
                    ConformanceLevel = ConformanceLevel.Auto,
                    Encoding = Encoding.UTF8,
                    Indent = true
                };
                var savePath = dialogExport.FileName;
                using (var stream = XmlWriter.Create(savePath, settings))
                {
                    var serialiser = new XmlSerializer(model.GetType());
                    serialiser.Serialize(stream, model);
                }
                MessageBox.Show(Resources.frmMainForm_exportWorker_RunWorkerCompleted_Export_Completed,
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                pgLongProcess.EditValue = 0;
            }
        } 
        #endregion

        #region -= Import Worker =-
        private void importWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var stream = (Stream)e.Argument;
            var manager = new ImportExportManager();
            manager.Progress +=
                (o, args) => importWorker.ReportProgress(args.Progress);
            e.Result = manager.ImportOffice(stream);
        }

        private void importWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var list = e.Result as List<Office>;
                if (list != null)
                {
                    pgLongProcess.EditValue = 0;
                    if (EmployeeID != Guid.Empty)
                    {
                        ddlOffice.DataSource = Factory.Manager<OfficeManager>().GetAll("IsDefault desc, OfficeName");
                        MessageBox.Show(
                            list.Count == 1
                                ? string.Format("Імпорт даних офісу {0} завершено", list.First().Name)
                                : "Імпорт офісів завершено",
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            list.Count == 1
                                ? string.Format(
                                    "Імпорт даних офісу {0} завершено. Перезапустіть програму для роботи із завантаженими даними.",
                                    list.First().Name)
                                : "Імпорт офісів завершено. Перезапустіть програму для роботи із завантаженими даними.",
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                pgLongProcess.EditValue = 0;
                log.Error(ex.Message, ex);
                throw;
            }
        }
        #endregion

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgLongProcess.EditValue = e.ProgressPercentage;
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exportWorker.IsBusy)
                exportWorker.CancelAsync();
            if (importWorker.IsBusy)
                importWorker.CancelAsync();
        }

        

        
    }
}