namespace Kayflow
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lblUserInfo = new DevExpress.XtraBars.BarStaticItem();
            this.lblOfficeInfo = new DevExpress.XtraBars.BarStaticItem();
            this.lblConnectionInfo = new DevExpress.XtraBars.BarStaticItem();
            this.pgLongProcess = new DevExpress.XtraBars.BarEditItem();
            this.repositoryLogTimeProgress = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.ribbon = new Kayflow.MyRibbonControl();
            this.btnOffice = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployeeList = new DevExpress.XtraBars.BarButtonItem();
            this.barItemOffice = new DevExpress.XtraBars.BarEditItem();
            this.ddlOffice = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnTerritorialUnit = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategoryList = new DevExpress.XtraBars.BarButtonItem();
            this.btnCostList = new DevExpress.XtraBars.BarButtonItem();
            this.btnStateList = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentGroupList = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocumentList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPaymentDataSettingsList = new DevExpress.XtraBars.BarButtonItem();
            this.btnActActionList = new DevExpress.XtraBars.BarButtonItem();
            this.btnAct = new DevExpress.XtraBars.BarButtonItem();
            this.btnExpence = new DevExpress.XtraBars.BarButtonItem();
            this.btnActReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportStep = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnClosedActs = new DevExpress.XtraBars.BarButtonItem();
            this.pageWorkflow = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupActWorkflow = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageSettings = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupStaff = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupDictionary = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupSettings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupImportExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dialogExport = new System.Windows.Forms.SaveFileDialog();
            this.dialogImport = new System.Windows.Forms.OpenFileDialog();
            this.exportWorker = new System.ComponentModel.BackgroundWorker();
            this.importWorker = new System.ComponentModel.BackgroundWorker();
            this.btnMyActs = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLogTimeProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblUserInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.lblOfficeInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.lblConnectionInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.pgLongProcess);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 563);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(864, 31);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblUserInfo.Id = 5;
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblOfficeInfo
            // 
            this.lblOfficeInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblOfficeInfo.Id = 6;
            this.lblOfficeInfo.Name = "lblOfficeInfo";
            this.lblOfficeInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblConnectionInfo.Id = 7;
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // pgLongProcess
            // 
            this.pgLongProcess.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.pgLongProcess.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.pgLongProcess.Edit = this.repositoryLogTimeProgress;
            this.pgLongProcess.Id = 24;
            this.pgLongProcess.Name = "pgLongProcess";
            this.pgLongProcess.Width = 150;
            // 
            // repositoryLogTimeProgress
            // 
            this.repositoryLogTimeProgress.Name = "repositoryLogTimeProgress";
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnOffice,
            this.btnEmployeeList,
            this.barItemOffice,
            this.lblUserInfo,
            this.lblOfficeInfo,
            this.lblConnectionInfo,
            this.btnTerritorialUnit,
            this.btnCategoryList,
            this.btnCostList,
            this.btnStateList,
            this.btnDocumentGroupList,
            this.btnDocumentList,
            this.btnPaymentDataSettingsList,
            this.btnActActionList,
            this.btnAct,
            this.btnExpence,
            this.btnActReport,
            this.btnReportStep,
            this.btnExport,
            this.btnImport,
            this.pgLongProcess,
            this.btnClosedActs,
            this.btnMyActs});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 27;
            this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barItemOffice);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageWorkflow,
            this.pageSettings});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlOffice,
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryLogTimeProgress});
            this.ribbon.Size = new System.Drawing.Size(864, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnOffice
            // 
            this.btnOffice.Caption = "Офіси";
            this.btnOffice.Glyph = global::Kayflow.Properties.Resources.Office;
            this.btnOffice.Id = 1;
            this.btnOffice.Name = "btnOffice";
            this.btnOffice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOffice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOffice_ItemClick);
            // 
            // btnEmployeeList
            // 
            this.btnEmployeeList.Caption = "Працівники";
            this.btnEmployeeList.Glyph = global::Kayflow.Properties.Resources.Employee;
            this.btnEmployeeList.Id = 2;
            this.btnEmployeeList.Name = "btnEmployeeList";
            this.btnEmployeeList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnEmployeeList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployeeList_ItemClick);
            // 
            // barItemOffice
            // 
            this.barItemOffice.Caption = "Офіс";
            this.barItemOffice.Edit = this.ddlOffice;
            this.barItemOffice.Id = 4;
            this.barItemOffice.Name = "barItemOffice";
            this.barItemOffice.Width = 150;
            this.barItemOffice.EditValueChanged += new System.EventHandler(this.barItemOffice_EditValueChanged);
            // 
            // ddlOffice
            // 
            this.ddlOffice.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.ddlOffice.AutoHeight = false;
            this.ddlOffice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlOffice.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OfficeName", "Офіс")});
            this.ddlOffice.DisplayMember = "OfficeName";
            this.ddlOffice.Name = "ddlOffice";
            this.ddlOffice.NullText = "Оберіть офіс";
            this.ddlOffice.ShowFooter = false;
            this.ddlOffice.ShowHeader = false;
            this.ddlOffice.ValueMember = "ID";
            // 
            // btnTerritorialUnit
            // 
            this.btnTerritorialUnit.Caption = "Територіальні одиниці";
            this.btnTerritorialUnit.Glyph = global::Kayflow.Properties.Resources.Location;
            this.btnTerritorialUnit.Id = 8;
            this.btnTerritorialUnit.Name = "btnTerritorialUnit";
            this.btnTerritorialUnit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTerritorialUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTerritorialUnit_ItemClick);
            // 
            // btnCategoryList
            // 
            this.btnCategoryList.Caption = "Категорії";
            this.btnCategoryList.Glyph = global::Kayflow.Properties.Resources.CategoryList;
            this.btnCategoryList.Id = 9;
            this.btnCategoryList.Name = "btnCategoryList";
            this.btnCategoryList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCategoryList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategoryList_ItemClick);
            // 
            // btnCostList
            // 
            this.btnCostList.Caption = "Види витрати";
            this.btnCostList.Glyph = global::Kayflow.Properties.Resources.ExprenseList;
            this.btnCostList.Id = 10;
            this.btnCostList.Name = "btnCostList";
            this.btnCostList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCostList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCostList_ItemClick);
            // 
            // btnStateList
            // 
            this.btnStateList.Caption = "Статуси актів";
            this.btnStateList.Glyph = global::Kayflow.Properties.Resources.StatusList;
            this.btnStateList.Id = 11;
            this.btnStateList.Name = "btnStateList";
            this.btnStateList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnStateList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStateList_ItemClick);
            // 
            // btnDocumentGroupList
            // 
            this.btnDocumentGroupList.Caption = "Групи колонок";
            this.btnDocumentGroupList.Glyph = global::Kayflow.Properties.Resources.DocumentGroupList;
            this.btnDocumentGroupList.Id = 13;
            this.btnDocumentGroupList.Name = "btnDocumentGroupList";
            this.btnDocumentGroupList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDocumentGroupList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentGroupList_ItemClick);
            // 
            // btnDocumentList
            // 
            this.btnDocumentList.Caption = "Додаткові колонки";
            this.btnDocumentList.Glyph = global::Kayflow.Properties.Resources.DocumentList;
            this.btnDocumentList.Id = 14;
            this.btnDocumentList.Name = "btnDocumentList";
            this.btnDocumentList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDocumentList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDocumentList_ItemClick);
            // 
            // btnPaymentDataSettingsList
            // 
            this.btnPaymentDataSettingsList.Caption = "Відомості про оплату";
            this.btnPaymentDataSettingsList.Glyph = global::Kayflow.Properties.Resources.ExprenseList;
            this.btnPaymentDataSettingsList.Id = 15;
            this.btnPaymentDataSettingsList.Name = "btnPaymentDataSettingsList";
            this.btnPaymentDataSettingsList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPaymentDataSettingsList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPaymentDataSettingsList_ItemClick);
            // 
            // btnActActionList
            // 
            this.btnActActionList.Caption = "Етапи проходження";
            this.btnActActionList.Glyph = global::Kayflow.Properties.Resources.ActActionList;
            this.btnActActionList.Id = 16;
            this.btnActActionList.Name = "btnActActionList";
            this.btnActActionList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnActActionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActActionList_ItemClick);
            // 
            // btnAct
            // 
            this.btnAct.Caption = "Відкриті справи";
            this.btnAct.Glyph = global::Kayflow.Properties.Resources.ActList;
            this.btnAct.Id = 17;
            this.btnAct.Name = "btnAct";
            this.btnAct.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAct_ItemClick);
            // 
            // btnExpence
            // 
            this.btnExpence.Caption = "Витрати";
            this.btnExpence.Glyph = global::Kayflow.Properties.Resources.Expense;
            this.btnExpence.Id = 18;
            this.btnExpence.Name = "btnExpence";
            this.btnExpence.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnExpence.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExpence_ItemClick);
            // 
            // btnActReport
            // 
            this.btnActReport.Caption = "Загальний";
            this.btnActReport.Glyph = global::Kayflow.Properties.Resources.Report;
            this.btnActReport.Id = 19;
            this.btnActReport.Name = "btnActReport";
            this.btnActReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnActReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActReport_ItemClick);
            // 
            // btnReportStep
            // 
            this.btnReportStep.Caption = "Проходження справи";
            this.btnReportStep.Glyph = global::Kayflow.Properties.Resources.Report;
            this.btnReportStep.Id = 20;
            this.btnReportStep.Name = "btnReportStep";
            this.btnReportStep.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnReportStep.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportStep_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Експорт";
            this.btnExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExport.Glyph = global::Kayflow.Properties.Resources.Export;
            this.btnExport.GlyphDisabled = global::Kayflow.Properties.Resources.Export_dis;
            this.btnExport.Id = 21;
            this.btnExport.Name = "btnExport";
            this.btnExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Імпорт";
            this.btnImport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnImport.Glyph = global::Kayflow.Properties.Resources.Import;
            this.btnImport.GlyphDisabled = global::Kayflow.Properties.Resources.Import_dis;
            this.btnImport.Id = 22;
            this.btnImport.Name = "btnImport";
            this.btnImport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnClosedActs
            // 
            this.btnClosedActs.Caption = "Закриті справи";
            this.btnClosedActs.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnClosedActs.Glyph = global::Kayflow.Properties.Resources.ActList;
            this.btnClosedActs.Id = 25;
            this.btnClosedActs.Name = "btnClosedActs";
            this.btnClosedActs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClosedActs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClosedActs_ItemClick);
            // 
            // pageWorkflow
            // 
            this.pageWorkflow.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupActWorkflow,
            this.groupReports});
            this.pageWorkflow.Name = "pageWorkflow";
            this.pageWorkflow.Text = "Документообіг";
            // 
            // groupActWorkflow
            // 
            this.groupActWorkflow.ItemLinks.Add(this.btnMyActs);
            this.groupActWorkflow.ItemLinks.Add(this.btnAct);
            this.groupActWorkflow.ItemLinks.Add(this.btnClosedActs);
            this.groupActWorkflow.ItemLinks.Add(this.btnExpence);
            this.groupActWorkflow.Name = "groupActWorkflow";
            this.groupActWorkflow.Text = "Робота із актами та документами";
            // 
            // groupReports
            // 
            this.groupReports.ItemLinks.Add(this.btnActReport);
            this.groupReports.ItemLinks.Add(this.btnReportStep);
            this.groupReports.Name = "groupReports";
            this.groupReports.Text = "Звіти";
            // 
            // pageSettings
            // 
            this.pageSettings.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupStaff,
            this.groupDictionary,
            this.groupSettings,
            this.groupImportExport});
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Text = "Налаштування";
            // 
            // groupStaff
            // 
            this.groupStaff.ItemLinks.Add(this.btnEmployeeList);
            this.groupStaff.ItemLinks.Add(this.btnOffice);
            this.groupStaff.Name = "groupStaff";
            this.groupStaff.Text = "Персонал";
            // 
            // groupDictionary
            // 
            this.groupDictionary.ItemLinks.Add(this.btnTerritorialUnit);
            this.groupDictionary.ItemLinks.Add(this.btnCategoryList);
            this.groupDictionary.ItemLinks.Add(this.btnCostList);
            this.groupDictionary.ItemLinks.Add(this.btnStateList);
            this.groupDictionary.Name = "groupDictionary";
            this.groupDictionary.Text = "Довідники";
            // 
            // groupSettings
            // 
            this.groupSettings.ItemLinks.Add(this.btnDocumentGroupList);
            this.groupSettings.ItemLinks.Add(this.btnDocumentList);
            this.groupSettings.ItemLinks.Add(this.btnPaymentDataSettingsList);
            this.groupSettings.ItemLinks.Add(this.btnActActionList);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Text = "Налаштування даних актів";
            // 
            // groupImportExport
            // 
            this.groupImportExport.ItemLinks.Add(this.btnExport);
            this.groupImportExport.ItemLinks.Add(this.btnImport);
            this.groupImportExport.Name = "groupImportExport";
            this.groupImportExport.Text = "Імпорт/Експорт";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // documentManager
            // 
            this.documentManager.MdiParent = this;
            this.documentManager.MenuManager = this.ribbon;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});
            // 
            // tabbedView
            // 
            this.tabbedView.DocumentActivated += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.tabbedView_DocumentActivated);
            // 
            // dialogExport
            // 
            this.dialogExport.DefaultExt = "xml";
            this.dialogExport.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            this.dialogExport.RestoreDirectory = true;
            this.dialogExport.Title = "Збереження файла екпорта";
            // 
            // dialogImport
            // 
            this.dialogImport.DefaultExt = "xml";
            this.dialogImport.Filter = "XML file (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // exportWorker
            // 
            this.exportWorker.WorkerReportsProgress = true;
            this.exportWorker.WorkerSupportsCancellation = true;
            this.exportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportWorker_DoWork);
            this.exportWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.exportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.exportWorker_RunWorkerCompleted);
            // 
            // importWorker
            // 
            this.importWorker.WorkerReportsProgress = true;
            this.importWorker.WorkerSupportsCancellation = true;
            this.importWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.importWorker_DoWork);
            this.importWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.importWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.importWorker_RunWorkerCompleted);
            // 
            // btnMyActs
            // 
            this.btnMyActs.Caption = "Мої справи";
            this.btnMyActs.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMyActs.Glyph = global::Kayflow.Properties.Resources.ActList;
            this.btnMyActs.Id = 26;
            this.btnMyActs.Name = "btnMyActs";
            this.btnMyActs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMyActs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMyActs_ItemClick);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 594);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Кайлас :: Документообіг";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainForm_FormClosed);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryLogTimeProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private MyRibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageWorkflow;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupActWorkflow;
        private DevExpress.XtraBars.BarButtonItem btnOffice;
        private DevExpress.XtraBars.BarButtonItem btnEmployeeList;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupStaff;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupDictionary;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.BarEditItem barItemOffice;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlOffice;
        private DevExpress.XtraBars.BarStaticItem lblUserInfo;
        private DevExpress.XtraBars.BarStaticItem lblOfficeInfo;
        private DevExpress.XtraBars.BarStaticItem lblConnectionInfo;
        private DevExpress.XtraBars.BarButtonItem btnTerritorialUnit;
        private DevExpress.XtraBars.BarButtonItem btnCategoryList;
        private DevExpress.XtraBars.BarButtonItem btnCostList;
        private DevExpress.XtraBars.BarButtonItem btnStateList;
        private DevExpress.XtraBars.BarButtonItem btnDocumentGroupList;
        private DevExpress.XtraBars.BarButtonItem btnDocumentList;
        private DevExpress.XtraBars.BarButtonItem btnPaymentDataSettingsList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupSettings;
        private DevExpress.XtraBars.BarButtonItem btnActActionList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupReports;
        private DevExpress.XtraBars.BarButtonItem btnAct;
        private DevExpress.XtraBars.BarButtonItem btnExpence;
        private DevExpress.XtraBars.BarButtonItem btnActReport;
        private DevExpress.XtraBars.BarButtonItem btnReportStep;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupImportExport;
        private System.Windows.Forms.SaveFileDialog dialogExport;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private System.Windows.Forms.OpenFileDialog dialogImport;
        private DevExpress.XtraBars.BarEditItem pgLongProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryLogTimeProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private System.ComponentModel.BackgroundWorker exportWorker;
        private System.ComponentModel.BackgroundWorker importWorker;
        private DevExpress.XtraBars.BarButtonItem btnClosedActs;
        private DevExpress.XtraBars.BarButtonItem btnMyActs;
    }
}