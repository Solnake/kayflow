namespace Kayflow.Acts
{
    partial class frmActList
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
            this.viewSteps = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnStepID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnStepOrdNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDelivered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.viewActDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnDocumentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDocValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.viewNotes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnNoteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnOnDateNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.viewStatusHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnHistoryID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnOnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnStateDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.viewHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridHistoryOnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridHistoryTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnHistoryEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnHistoryDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.viewActs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnActID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnMeteringDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCustomerPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnAreaAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnStateNameAct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPaidOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnLeftOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnApproval1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnKailasPaid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnKailasDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPaidDue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnApproval2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnKailasPaid2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnSalaryCalculated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnSalaryPaidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCalculatedMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPaidMainDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddNote = new DevExpress.XtraBars.BarButtonItem();
            this.groupActs = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnEditSteps = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddStatus = new DevExpress.XtraBars.BarButtonItem();
            this.menuItemAddNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSteps = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDeleteNote = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDeleteHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAddStatus = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStatusHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActs)).BeginInit();
            this.menuNotes.SuspendLayout();
            this.menuHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddNote,
            this.btnEditSteps,
            this.btnAddStatus});
            this.ribbon.MaxItemId = 8;
            this.ribbon.Size = new System.Drawing.Size(1077, 144);
            // 
            // pageListName
            // 
            this.pageListName.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupActs});
            this.pageListName.Text = "Акти";
            // 
            // viewSteps
            // 
            this.viewSteps.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnStepID,
            this.columnStepOrdNum,
            this.columnActionName,
            this.columnDelivered,
            this.columnReceived});
            this.viewSteps.GridControl = this.gridList;
            this.viewSteps.Name = "viewSteps";
            this.viewSteps.OptionsCustomization.AllowColumnMoving = false;
            this.viewSteps.OptionsCustomization.AllowColumnResizing = false;
            this.viewSteps.OptionsCustomization.AllowFilter = false;
            this.viewSteps.OptionsCustomization.AllowGroup = false;
            this.viewSteps.OptionsCustomization.AllowQuickHideColumns = false;
            this.viewSteps.OptionsCustomization.AllowSort = false;
            this.viewSteps.OptionsView.ShowGroupPanel = false;
            this.viewSteps.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.viewSteps_RowCellStyle);
            // 
            // columnStepID
            // 
            this.columnStepID.Caption = "ID";
            this.columnStepID.FieldName = "ID";
            this.columnStepID.Name = "columnStepID";
            // 
            // columnStepOrdNum
            // 
            this.columnStepOrdNum.AppearanceCell.Options.UseTextOptions = true;
            this.columnStepOrdNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnStepOrdNum.AppearanceHeader.Options.UseTextOptions = true;
            this.columnStepOrdNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnStepOrdNum.Caption = "№ п/п";
            this.columnStepOrdNum.FieldName = "OrdNum";
            this.columnStepOrdNum.MaxWidth = 50;
            this.columnStepOrdNum.MinWidth = 50;
            this.columnStepOrdNum.Name = "columnStepOrdNum";
            this.columnStepOrdNum.OptionsColumn.AllowEdit = false;
            this.columnStepOrdNum.OptionsColumn.AllowIncrementalSearch = false;
            this.columnStepOrdNum.OptionsColumn.AllowSize = false;
            this.columnStepOrdNum.OptionsColumn.ShowInCustomizationForm = false;
            this.columnStepOrdNum.OptionsColumn.ShowInExpressionEditor = false;
            this.columnStepOrdNum.Visible = true;
            this.columnStepOrdNum.VisibleIndex = 0;
            this.columnStepOrdNum.Width = 50;
            // 
            // columnActionName
            // 
            this.columnActionName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActionName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActionName.Caption = "Назва етапу";
            this.columnActionName.FieldName = "ActionName";
            this.columnActionName.Name = "columnActionName";
            this.columnActionName.OptionsColumn.AllowEdit = false;
            this.columnActionName.Visible = true;
            this.columnActionName.VisibleIndex = 1;
            // 
            // columnDelivered
            // 
            this.columnDelivered.AppearanceCell.Options.UseTextOptions = true;
            this.columnDelivered.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDelivered.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDelivered.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDelivered.Caption = "Передали";
            this.columnDelivered.DisplayFormat.FormatString = "d";
            this.columnDelivered.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnDelivered.FieldName = "Delivered";
            this.columnDelivered.MaxWidth = 75;
            this.columnDelivered.MinWidth = 75;
            this.columnDelivered.Name = "columnDelivered";
            this.columnDelivered.OptionsColumn.AllowEdit = false;
            this.columnDelivered.Visible = true;
            this.columnDelivered.VisibleIndex = 2;
            // 
            // columnReceived
            // 
            this.columnReceived.AppearanceCell.Options.UseTextOptions = true;
            this.columnReceived.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnReceived.AppearanceHeader.Options.UseTextOptions = true;
            this.columnReceived.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnReceived.Caption = "Отримали";
            this.columnReceived.DisplayFormat.FormatString = "d";
            this.columnReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnReceived.FieldName = "Received";
            this.columnReceived.MaxWidth = 75;
            this.columnReceived.MinWidth = 75;
            this.columnReceived.Name = "columnReceived";
            this.columnReceived.OptionsColumn.AllowEdit = false;
            this.columnReceived.Visible = true;
            this.columnReceived.VisibleIndex = 3;
            // 
            // gridList
            // 
            this.gridList.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.viewSteps;
            gridLevelNode1.RelationName = "Steps";
            gridLevelNode2.LevelTemplate = this.viewActDocuments;
            gridLevelNode2.RelationName = "Documents";
            gridLevelNode3.LevelTemplate = this.viewNotes;
            gridLevelNode3.RelationName = "Notes";
            gridLevelNode4.LevelTemplate = this.viewStatusHistory;
            gridLevelNode4.RelationName = "Status";
            gridLevelNode5.LevelTemplate = this.viewHistory;
            gridLevelNode5.RelationName = "History";
            this.gridList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4,
            gridLevelNode5});
            this.gridList.Location = new System.Drawing.Point(0, 169);
            this.gridList.MainView = this.viewActs;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(1077, 451);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewActDocuments,
            this.viewNotes,
            this.viewStatusHistory,
            this.viewHistory,
            this.viewActs,
            this.viewSteps});
            // 
            // viewActDocuments
            // 
            this.viewActDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnDocumentID,
            this.columnDocumentName,
            this.columnGroupName,
            this.columnDocValue});
            this.viewActDocuments.GridControl = this.gridList;
            this.viewActDocuments.GroupCount = 1;
            this.viewActDocuments.Name = "viewActDocuments";
            this.viewActDocuments.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewActDocuments.OptionsView.ShowGroupPanel = false;
            this.viewActDocuments.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnGroupName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewActDocuments.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.viewActDocuments_RowCellStyle);
            // 
            // columnDocumentID
            // 
            this.columnDocumentID.Caption = "ID";
            this.columnDocumentID.FieldName = "ID";
            this.columnDocumentID.Name = "columnDocumentID";
            // 
            // columnDocumentName
            // 
            this.columnDocumentName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDocumentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDocumentName.Caption = "Документ";
            this.columnDocumentName.FieldName = "DocumentName";
            this.columnDocumentName.Name = "columnDocumentName";
            this.columnDocumentName.OptionsColumn.AllowEdit = false;
            this.columnDocumentName.Visible = true;
            this.columnDocumentName.VisibleIndex = 0;
            // 
            // columnGroupName
            // 
            this.columnGroupName.Caption = "Група ";
            this.columnGroupName.FieldName = "GroupName";
            this.columnGroupName.Name = "columnGroupName";
            this.columnGroupName.OptionsColumn.AllowEdit = false;
            this.columnGroupName.Visible = true;
            this.columnGroupName.VisibleIndex = 0;
            // 
            // columnDocValue
            // 
            this.columnDocValue.AppearanceCell.Options.UseTextOptions = true;
            this.columnDocValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDocValue.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDocValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDocValue.Caption = "Статус";
            this.columnDocValue.FieldName = "DocValue";
            this.columnDocValue.MaxWidth = 50;
            this.columnDocValue.MinWidth = 50;
            this.columnDocValue.Name = "columnDocValue";
            this.columnDocValue.OptionsColumn.AllowEdit = false;
            this.columnDocValue.Visible = true;
            this.columnDocValue.VisibleIndex = 1;
            this.columnDocValue.Width = 50;
            // 
            // viewNotes
            // 
            this.viewNotes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnNoteID,
            this.columnOnDateNote,
            this.columnEmployeeName,
            this.columnDescription});
            this.viewNotes.GridControl = this.gridList;
            this.viewNotes.Name = "viewNotes";
            this.viewNotes.OptionsView.ShowGroupPanel = false;
            this.viewNotes.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.viewNotes_PopupMenuShowing);
            this.viewNotes.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewNotes_FocusedRowChanged);
            // 
            // columnNoteID
            // 
            this.columnNoteID.Caption = "ID";
            this.columnNoteID.FieldName = "ID";
            this.columnNoteID.Name = "columnNoteID";
            // 
            // columnOnDateNote
            // 
            this.columnOnDateNote.AppearanceCell.Options.UseTextOptions = true;
            this.columnOnDateNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOnDateNote.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOnDateNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOnDateNote.Caption = "Дата";
            this.columnOnDateNote.DisplayFormat.FormatString = "d";
            this.columnOnDateNote.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnOnDateNote.FieldName = "OnDate";
            this.columnOnDateNote.MaxWidth = 100;
            this.columnOnDateNote.MinWidth = 100;
            this.columnOnDateNote.Name = "columnOnDateNote";
            this.columnOnDateNote.OptionsColumn.AllowEdit = false;
            this.columnOnDateNote.Visible = true;
            this.columnOnDateNote.VisibleIndex = 0;
            this.columnOnDateNote.Width = 100;
            // 
            // columnEmployeeName
            // 
            this.columnEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnEmployeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnEmployeeName.Caption = "Працівник";
            this.columnEmployeeName.FieldName = "EmployeeName";
            this.columnEmployeeName.MaxWidth = 250;
            this.columnEmployeeName.MinWidth = 250;
            this.columnEmployeeName.Name = "columnEmployeeName";
            this.columnEmployeeName.OptionsColumn.AllowEdit = false;
            this.columnEmployeeName.Visible = true;
            this.columnEmployeeName.VisibleIndex = 1;
            this.columnEmployeeName.Width = 250;
            // 
            // columnDescription
            // 
            this.columnDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDescription.Caption = "Причина затримки";
            this.columnDescription.FieldName = "Description";
            this.columnDescription.Name = "columnDescription";
            this.columnDescription.OptionsColumn.AllowEdit = false;
            this.columnDescription.Visible = true;
            this.columnDescription.VisibleIndex = 2;
            // 
            // viewStatusHistory
            // 
            this.viewStatusHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnHistoryID,
            this.columnOnDate,
            this.columEmployeeName,
            this.columnStateDescription});
            this.viewStatusHistory.GridControl = this.gridList;
            this.viewStatusHistory.Name = "viewStatusHistory";
            this.viewStatusHistory.OptionsView.ShowGroupPanel = false;
            this.viewStatusHistory.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.viewStatusHistory_PopupMenuShowing);
            this.viewStatusHistory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewStatusHistory_FocusedRowChanged);
            // 
            // columnHistoryID
            // 
            this.columnHistoryID.Caption = "ID";
            this.columnHistoryID.FieldName = "ID";
            this.columnHistoryID.Name = "columnHistoryID";
            // 
            // columnOnDate
            // 
            this.columnOnDate.AppearanceCell.Options.UseTextOptions = true;
            this.columnOnDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOnDate.Caption = "Дата";
            this.columnOnDate.DisplayFormat.FormatString = "d";
            this.columnOnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnOnDate.FieldName = "OnDate";
            this.columnOnDate.MaxWidth = 100;
            this.columnOnDate.MinWidth = 100;
            this.columnOnDate.Name = "columnOnDate";
            this.columnOnDate.OptionsColumn.AllowEdit = false;
            this.columnOnDate.Visible = true;
            this.columnOnDate.VisibleIndex = 0;
            this.columnOnDate.Width = 100;
            // 
            // columEmployeeName
            // 
            this.columEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columEmployeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columEmployeeName.Caption = "Працівник";
            this.columEmployeeName.FieldName = "EmployeeName";
            this.columEmployeeName.MaxWidth = 250;
            this.columEmployeeName.MinWidth = 250;
            this.columEmployeeName.Name = "columEmployeeName";
            this.columEmployeeName.OptionsColumn.AllowEdit = false;
            this.columEmployeeName.Visible = true;
            this.columEmployeeName.VisibleIndex = 1;
            this.columEmployeeName.Width = 250;
            // 
            // columnStateDescription
            // 
            this.columnStateDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.columnStateDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnStateDescription.Caption = "Стан справи";
            this.columnStateDescription.FieldName = "Description";
            this.columnStateDescription.Name = "columnStateDescription";
            this.columnStateDescription.OptionsColumn.AllowEdit = false;
            this.columnStateDescription.Visible = true;
            this.columnStateDescription.VisibleIndex = 2;
            // 
            // viewHistory
            // 
            this.viewHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridHistoryOnDate,
            this.gridHistoryTime,
            this.columnHistoryEmployee,
            this.columnHistoryDescription});
            this.viewHistory.GridControl = this.gridList;
            this.viewHistory.Name = "viewHistory";
            this.viewHistory.OptionsView.ShowGroupPanel = false;
            this.viewHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridHistoryOnDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridHistoryOnDate
            // 
            this.gridHistoryOnDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridHistoryOnDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridHistoryOnDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridHistoryOnDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridHistoryOnDate.Caption = "Дата";
            this.gridHistoryOnDate.DisplayFormat.FormatString = "d";
            this.gridHistoryOnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridHistoryOnDate.FieldName = "OnDate";
            this.gridHistoryOnDate.MaxWidth = 70;
            this.gridHistoryOnDate.MinWidth = 70;
            this.gridHistoryOnDate.Name = "gridHistoryOnDate";
            this.gridHistoryOnDate.OptionsColumn.AllowEdit = false;
            this.gridHistoryOnDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridHistoryOnDate.Visible = true;
            this.gridHistoryOnDate.VisibleIndex = 0;
            this.gridHistoryOnDate.Width = 70;
            // 
            // gridHistoryTime
            // 
            this.gridHistoryTime.AppearanceCell.Options.UseTextOptions = true;
            this.gridHistoryTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridHistoryTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridHistoryTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridHistoryTime.Caption = "Час";
            this.gridHistoryTime.DisplayFormat.FormatString = "t";
            this.gridHistoryTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridHistoryTime.FieldName = "OnDate";
            this.gridHistoryTime.MaxWidth = 50;
            this.gridHistoryTime.MinWidth = 50;
            this.gridHistoryTime.Name = "gridHistoryTime";
            this.gridHistoryTime.OptionsColumn.AllowEdit = false;
            this.gridHistoryTime.Visible = true;
            this.gridHistoryTime.VisibleIndex = 1;
            this.gridHistoryTime.Width = 50;
            // 
            // columnHistoryEmployee
            // 
            this.columnHistoryEmployee.AppearanceHeader.Options.UseTextOptions = true;
            this.columnHistoryEmployee.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnHistoryEmployee.Caption = "Працівник";
            this.columnHistoryEmployee.FieldName = "EmployeeName";
            this.columnHistoryEmployee.MaxWidth = 250;
            this.columnHistoryEmployee.MinWidth = 250;
            this.columnHistoryEmployee.Name = "columnHistoryEmployee";
            this.columnHistoryEmployee.OptionsColumn.AllowEdit = false;
            this.columnHistoryEmployee.Visible = true;
            this.columnHistoryEmployee.VisibleIndex = 2;
            this.columnHistoryEmployee.Width = 250;
            // 
            // columnHistoryDescription
            // 
            this.columnHistoryDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.columnHistoryDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnHistoryDescription.Caption = "Опис дії";
            this.columnHistoryDescription.FieldName = "Description";
            this.columnHistoryDescription.Name = "columnHistoryDescription";
            this.columnHistoryDescription.OptionsColumn.AllowEdit = false;
            this.columnHistoryDescription.Visible = true;
            this.columnHistoryDescription.VisibleIndex = 3;
            this.columnHistoryDescription.Width = 20;
            // 
            // viewActs
            // 
            this.viewActs.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.viewActs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnActID,
            this.columnMeteringDate,
            this.columnActEmployeeName,
            this.columnUnitName,
            this.columnAddress,
            this.columnCustomerName,
            this.columnCustomerPhone,
            this.columnAreaAmount,
            this.columnActAmount,
            this.columnCategoryName,
            this.columnStateNameAct,
            this.columnActDate,
            this.columnActNum,
            this.columnTotalCost,
            this.columnPaidOn,
            this.columnLeftOn,
            this.columnApproval1,
            this.columnKailasPaid1,
            this.columnKailasDue,
            this.columnPaidDue,
            this.columnApproval2,
            this.columnKailasPaid2,
            this.columnSalaryCalculated,
            this.columnSalaryPaidDate,
            this.columnCalculatedMain,
            this.columnPaidMainDate,
            this.columnActDescription});
            this.viewActs.GridControl = this.gridList;
            this.viewActs.GroupCount = 2;
            this.viewActs.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AreaAmount", this.columnAreaAmount, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ActAmount", this.columnActAmount, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", this.columnTotalCost, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidOn", this.columnPaidOn, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LeftOn", this.columnLeftOn, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Approval1", this.columnApproval1, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KailasPaid1", this.columnKailasPaid1, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KailasDue", this.columnKailasDue, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidDue", this.columnPaidDue, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Approval2", this.columnApproval2, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KailasPaid2", this.columnKailasPaid2, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SalaryCalculated", this.columnSalaryCalculated, "{0:n}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CalculatedMain", this.columnCalculatedMain, "{0:n}")});
            this.viewActs.Name = "viewActs";
            this.viewActs.OptionsDetail.AllowExpandEmptyDetails = true;
            this.viewActs.OptionsView.ShowGroupPanel = false;
            this.viewActs.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnMeteringDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnActEmployeeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewActs.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.viewActs_RowCellStyle);
            this.viewActs.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.viewActs_MasterRowGetChildList);
            this.viewActs.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.viewActs_MasterRowGetRelationName);
            this.viewActs.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.viewActs_MasterRowGetRelationDisplayCaption);
            this.viewActs.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.viewActs_MasterRowGetRelationCount);
            // 
            // columnActID
            // 
            this.columnActID.Caption = "ID";
            this.columnActID.FieldName = "ID";
            this.columnActID.Name = "columnActID";
            // 
            // columnMeteringDate
            // 
            this.columnMeteringDate.AppearanceCell.Options.UseTextOptions = true;
            this.columnMeteringDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnMeteringDate.AppearanceHeader.Options.UseTextOptions = true;
            this.columnMeteringDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnMeteringDate.Caption = "Дата виїзду";
            this.columnMeteringDate.DisplayFormat.FormatString = "d";
            this.columnMeteringDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnMeteringDate.FieldName = "MeteringDate";
            this.columnMeteringDate.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Date;
            this.columnMeteringDate.MaxWidth = 75;
            this.columnMeteringDate.MinWidth = 75;
            this.columnMeteringDate.Name = "columnMeteringDate";
            this.columnMeteringDate.OptionsColumn.AllowEdit = false;
            this.columnMeteringDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.columnMeteringDate.Visible = true;
            this.columnMeteringDate.VisibleIndex = 0;
            // 
            // columnActEmployeeName
            // 
            this.columnActEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActEmployeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActEmployeeName.Caption = "Землевпорядник";
            this.columnActEmployeeName.FieldName = "EmployeeName";
            this.columnActEmployeeName.Name = "columnActEmployeeName";
            this.columnActEmployeeName.OptionsColumn.AllowEdit = false;
            this.columnActEmployeeName.Visible = true;
            this.columnActEmployeeName.VisibleIndex = 0;
            // 
            // columnUnitName
            // 
            this.columnUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnUnitName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnUnitName.Caption = "Населений пункт";
            this.columnUnitName.FieldName = "UnitName";
            this.columnUnitName.Name = "columnUnitName";
            this.columnUnitName.OptionsColumn.AllowEdit = false;
            this.columnUnitName.Visible = true;
            this.columnUnitName.VisibleIndex = 0;
            this.columnUnitName.Width = 176;
            // 
            // columnAddress
            // 
            this.columnAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.columnAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAddress.Caption = "Адреса";
            this.columnAddress.FieldName = "Address";
            this.columnAddress.Name = "columnAddress";
            this.columnAddress.OptionsColumn.AllowEdit = false;
            this.columnAddress.Visible = true;
            this.columnAddress.VisibleIndex = 1;
            this.columnAddress.Width = 176;
            // 
            // columnCustomerName
            // 
            this.columnCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCustomerName.Caption = "Замовник";
            this.columnCustomerName.FieldName = "CustomerName";
            this.columnCustomerName.Name = "columnCustomerName";
            this.columnCustomerName.OptionsColumn.AllowEdit = false;
            this.columnCustomerName.Visible = true;
            this.columnCustomerName.VisibleIndex = 2;
            this.columnCustomerName.Width = 176;
            // 
            // columnCustomerPhone
            // 
            this.columnCustomerPhone.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCustomerPhone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCustomerPhone.Caption = "Телефон";
            this.columnCustomerPhone.FieldName = "CustomerPhone";
            this.columnCustomerPhone.MaxWidth = 75;
            this.columnCustomerPhone.MinWidth = 75;
            this.columnCustomerPhone.Name = "columnCustomerPhone";
            this.columnCustomerPhone.OptionsColumn.AllowEdit = false;
            this.columnCustomerPhone.Visible = true;
            this.columnCustomerPhone.VisibleIndex = 3;
            // 
            // columnAreaAmount
            // 
            this.columnAreaAmount.AppearanceCell.Options.UseTextOptions = true;
            this.columnAreaAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAreaAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.columnAreaAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAreaAmount.Caption = "Ділянок";
            this.columnAreaAmount.FieldName = "AreaAmount";
            this.columnAreaAmount.MaxWidth = 50;
            this.columnAreaAmount.MinWidth = 50;
            this.columnAreaAmount.Name = "columnAreaAmount";
            this.columnAreaAmount.OptionsColumn.AllowEdit = false;
            this.columnAreaAmount.Visible = true;
            this.columnAreaAmount.VisibleIndex = 4;
            this.columnAreaAmount.Width = 50;
            // 
            // columnActAmount
            // 
            this.columnActAmount.AppearanceCell.Options.UseTextOptions = true;
            this.columnActAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActAmount.Caption = "Актів";
            this.columnActAmount.FieldName = "ActAmount";
            this.columnActAmount.Name = "columnActAmount";
            this.columnActAmount.OptionsColumn.AllowEdit = false;
            this.columnActAmount.Visible = true;
            this.columnActAmount.VisibleIndex = 5;
            // 
            // columnCategoryName
            // 
            this.columnCategoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCategoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCategoryName.Caption = "Категорія";
            this.columnCategoryName.FieldName = "CategoryName";
            this.columnCategoryName.Name = "columnCategoryName";
            this.columnCategoryName.OptionsColumn.AllowEdit = false;
            this.columnCategoryName.Visible = true;
            this.columnCategoryName.VisibleIndex = 6;
            // 
            // columnStateNameAct
            // 
            this.columnStateNameAct.AppearanceHeader.Options.UseTextOptions = true;
            this.columnStateNameAct.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnStateNameAct.Caption = "Статус";
            this.columnStateNameAct.FieldName = "StateName";
            this.columnStateNameAct.Name = "columnStateNameAct";
            this.columnStateNameAct.OptionsColumn.AllowEdit = false;
            this.columnStateNameAct.Visible = true;
            this.columnStateNameAct.VisibleIndex = 7;
            // 
            // columnActDate
            // 
            this.columnActDate.AppearanceCell.Options.UseTextOptions = true;
            this.columnActDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActDate.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActDate.Caption = "Дата акту";
            this.columnActDate.DisplayFormat.FormatString = "d";
            this.columnActDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnActDate.FieldName = "ActDate";
            this.columnActDate.Name = "columnActDate";
            this.columnActDate.OptionsColumn.AllowEdit = false;
            this.columnActDate.Visible = true;
            this.columnActDate.VisibleIndex = 8;
            // 
            // columnActNum
            // 
            this.columnActNum.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActNum.Caption = "№ акту";
            this.columnActNum.FieldName = "ActNum";
            this.columnActNum.Name = "columnActNum";
            this.columnActNum.OptionsColumn.AllowEdit = false;
            this.columnActNum.Visible = true;
            this.columnActNum.VisibleIndex = 9;
            // 
            // columnTotalCost
            // 
            this.columnTotalCost.AppearanceCell.Options.UseTextOptions = true;
            this.columnTotalCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnTotalCost.AppearanceHeader.Options.UseTextOptions = true;
            this.columnTotalCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnTotalCost.Caption = "Загальна вартість робіт";
            this.columnTotalCost.DisplayFormat.FormatString = "n";
            this.columnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnTotalCost.FieldName = "TotalCost";
            this.columnTotalCost.Name = "columnTotalCost";
            this.columnTotalCost.OptionsColumn.AllowEdit = false;
            this.columnTotalCost.Visible = true;
            this.columnTotalCost.VisibleIndex = 10;
            // 
            // columnPaidOn
            // 
            this.columnPaidOn.AppearanceCell.Options.UseTextOptions = true;
            this.columnPaidOn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnPaidOn.AppearanceHeader.Options.UseTextOptions = true;
            this.columnPaidOn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnPaidOn.Caption = "Оплачено на вимірах";
            this.columnPaidOn.DisplayFormat.FormatString = "n";
            this.columnPaidOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnPaidOn.FieldName = "PaidOn";
            this.columnPaidOn.Name = "columnPaidOn";
            this.columnPaidOn.OptionsColumn.AllowEdit = false;
            this.columnPaidOn.Visible = true;
            this.columnPaidOn.VisibleIndex = 11;
            // 
            // columnLeftOn
            // 
            this.columnLeftOn.AppearanceCell.Options.UseTextOptions = true;
            this.columnLeftOn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnLeftOn.AppearanceHeader.Options.UseTextOptions = true;
            this.columnLeftOn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnLeftOn.Caption = "Залишено на місці";
            this.columnLeftOn.DisplayFormat.FormatString = "n";
            this.columnLeftOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnLeftOn.FieldName = "LeftOn";
            this.columnLeftOn.Name = "columnLeftOn";
            this.columnLeftOn.OptionsColumn.AllowEdit = false;
            this.columnLeftOn.Visible = true;
            this.columnLeftOn.VisibleIndex = 12;
            // 
            // columnApproval1
            // 
            this.columnApproval1.AppearanceCell.Options.UseTextOptions = true;
            this.columnApproval1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnApproval1.AppearanceHeader.Options.UseTextOptions = true;
            this.columnApproval1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnApproval1.Caption = "Погодження 1";
            this.columnApproval1.DisplayFormat.FormatString = "n";
            this.columnApproval1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnApproval1.FieldName = "Approval1";
            this.columnApproval1.Name = "columnApproval1";
            this.columnApproval1.OptionsColumn.AllowEdit = false;
            this.columnApproval1.Visible = true;
            this.columnApproval1.VisibleIndex = 13;
            // 
            // columnKailasPaid1
            // 
            this.columnKailasPaid1.AppearanceCell.Options.UseTextOptions = true;
            this.columnKailasPaid1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnKailasPaid1.AppearanceHeader.Options.UseTextOptions = true;
            this.columnKailasPaid1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnKailasPaid1.Caption = "Оплачено на ПП Кайлас-К";
            this.columnKailasPaid1.DisplayFormat.FormatString = "n";
            this.columnKailasPaid1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnKailasPaid1.FieldName = "KailasPaid1";
            this.columnKailasPaid1.Name = "columnKailasPaid1";
            this.columnKailasPaid1.OptionsColumn.AllowEdit = false;
            this.columnKailasPaid1.Visible = true;
            this.columnKailasPaid1.VisibleIndex = 14;
            // 
            // columnKailasDue
            // 
            this.columnKailasDue.AppearanceCell.Options.UseTextOptions = true;
            this.columnKailasDue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnKailasDue.AppearanceHeader.Options.UseTextOptions = true;
            this.columnKailasDue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnKailasDue.Caption = "Заборгованість по ПП Кайлас-К";
            this.columnKailasDue.DisplayFormat.FormatString = "n";
            this.columnKailasDue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnKailasDue.FieldName = "KailasDue";
            this.columnKailasDue.Name = "columnKailasDue";
            this.columnKailasDue.OptionsColumn.AllowEdit = false;
            this.columnKailasDue.Visible = true;
            this.columnKailasDue.VisibleIndex = 15;
            // 
            // columnPaidDue
            // 
            this.columnPaidDue.AppearanceCell.Options.UseTextOptions = true;
            this.columnPaidDue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnPaidDue.AppearanceHeader.Options.UseTextOptions = true;
            this.columnPaidDue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnPaidDue.Caption = "Оплачена заборгованість (після виїзду)";
            this.columnPaidDue.DisplayFormat.FormatString = "n";
            this.columnPaidDue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnPaidDue.FieldName = "PaidDue";
            this.columnPaidDue.Name = "columnPaidDue";
            this.columnPaidDue.OptionsColumn.AllowEdit = false;
            this.columnPaidDue.Visible = true;
            this.columnPaidDue.VisibleIndex = 16;
            // 
            // columnApproval2
            // 
            this.columnApproval2.AppearanceCell.Options.UseTextOptions = true;
            this.columnApproval2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnApproval2.AppearanceHeader.Options.UseTextOptions = true;
            this.columnApproval2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnApproval2.Caption = "Погодження 2";
            this.columnApproval2.DisplayFormat.FormatString = "n";
            this.columnApproval2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnApproval2.FieldName = "Approval2";
            this.columnApproval2.Name = "columnApproval2";
            this.columnApproval2.OptionsColumn.AllowEdit = false;
            this.columnApproval2.Visible = true;
            this.columnApproval2.VisibleIndex = 17;
            // 
            // columnKailasPaid2
            // 
            this.columnKailasPaid2.AppearanceCell.Options.UseTextOptions = true;
            this.columnKailasPaid2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnKailasPaid2.AppearanceHeader.Options.UseTextOptions = true;
            this.columnKailasPaid2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnKailasPaid2.Caption = "Оплачено на ПП Кайлас-К 2";
            this.columnKailasPaid2.DisplayFormat.FormatString = "n";
            this.columnKailasPaid2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnKailasPaid2.FieldName = "KailasPaid2";
            this.columnKailasPaid2.Name = "columnKailasPaid2";
            this.columnKailasPaid2.OptionsColumn.AllowEdit = false;
            this.columnKailasPaid2.Visible = true;
            this.columnKailasPaid2.VisibleIndex = 18;
            // 
            // columnSalaryCalculated
            // 
            this.columnSalaryCalculated.AppearanceCell.Options.UseTextOptions = true;
            this.columnSalaryCalculated.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnSalaryCalculated.AppearanceHeader.Options.UseTextOptions = true;
            this.columnSalaryCalculated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSalaryCalculated.Caption = "Нараховано";
            this.columnSalaryCalculated.DisplayFormat.FormatString = "n";
            this.columnSalaryCalculated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnSalaryCalculated.FieldName = "SalaryCalculated";
            this.columnSalaryCalculated.Name = "columnSalaryCalculated";
            this.columnSalaryCalculated.OptionsColumn.AllowEdit = false;
            this.columnSalaryCalculated.Visible = true;
            this.columnSalaryCalculated.VisibleIndex = 19;
            // 
            // columnSalaryPaidDate
            // 
            this.columnSalaryPaidDate.AppearanceCell.Options.UseTextOptions = true;
            this.columnSalaryPaidDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSalaryPaidDate.AppearanceHeader.Options.UseTextOptions = true;
            this.columnSalaryPaidDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSalaryPaidDate.Caption = "Оплочено";
            this.columnSalaryPaidDate.DisplayFormat.FormatString = "d";
            this.columnSalaryPaidDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnSalaryPaidDate.FieldName = "SalaryPaidDate";
            this.columnSalaryPaidDate.Name = "columnSalaryPaidDate";
            this.columnSalaryPaidDate.OptionsColumn.AllowEdit = false;
            this.columnSalaryPaidDate.Visible = true;
            this.columnSalaryPaidDate.VisibleIndex = 20;
            // 
            // columnCalculatedMain
            // 
            this.columnCalculatedMain.AppearanceCell.Options.UseTextOptions = true;
            this.columnCalculatedMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.columnCalculatedMain.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCalculatedMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCalculatedMain.Caption = "Нараховано ХМЛ";
            this.columnCalculatedMain.DisplayFormat.FormatString = "n";
            this.columnCalculatedMain.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnCalculatedMain.FieldName = "CalculatedMain";
            this.columnCalculatedMain.Name = "columnCalculatedMain";
            this.columnCalculatedMain.OptionsColumn.AllowEdit = false;
            this.columnCalculatedMain.Visible = true;
            this.columnCalculatedMain.VisibleIndex = 21;
            // 
            // columnPaidMainDate
            // 
            this.columnPaidMainDate.AppearanceCell.Options.UseTextOptions = true;
            this.columnPaidMainDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnPaidMainDate.AppearanceHeader.Options.UseTextOptions = true;
            this.columnPaidMainDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnPaidMainDate.Caption = "Оплочено ХМЛ";
            this.columnPaidMainDate.DisplayFormat.FormatString = "d";
            this.columnPaidMainDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnPaidMainDate.FieldName = "PaidMainDate";
            this.columnPaidMainDate.Name = "columnPaidMainDate";
            this.columnPaidMainDate.OptionsColumn.AllowEdit = false;
            this.columnPaidMainDate.Visible = true;
            this.columnPaidMainDate.VisibleIndex = 22;
            // 
            // columnActDescription
            // 
            this.columnActDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.columnActDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnActDescription.Caption = "Примітка";
            this.columnActDescription.FieldName = "Description";
            this.columnActDescription.Name = "columnActDescription";
            this.columnActDescription.OptionsColumn.AllowEdit = false;
            this.columnActDescription.Visible = true;
            this.columnActDescription.VisibleIndex = 23;
            // 
            // btnAddNote
            // 
            this.btnAddNote.Caption = "Додати причину затримки";
            this.btnAddNote.Enabled = false;
            this.btnAddNote.Glyph = global::Kayflow.Properties.Resources.NoteAdd;
            this.btnAddNote.Id = 5;
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNote_ItemClick);
            // 
            // groupActs
            // 
            this.groupActs.ItemLinks.Add(this.btnAddNote);
            this.groupActs.ItemLinks.Add(this.btnEditSteps);
            this.groupActs.ItemLinks.Add(this.btnAddStatus);
            this.groupActs.Name = "groupActs";
            this.groupActs.Text = "Акт";
            this.groupActs.Visible = false;
            // 
            // btnEditSteps
            // 
            this.btnEditSteps.Caption = "Проходження справи";
            this.btnEditSteps.Glyph = global::Kayflow.Properties.Resources.StepEdit;
            this.btnEditSteps.Id = 6;
            this.btnEditSteps.Name = "btnEditSteps";
            this.btnEditSteps.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnEditSteps.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditSteps_ItemClick);
            // 
            // btnAddStatus
            // 
            this.btnAddStatus.Caption = "Змінити стан справи";
            this.btnAddStatus.Glyph = global::Kayflow.Properties.Resources.StatusAdd;
            this.btnAddStatus.Id = 7;
            this.btnAddStatus.Name = "btnAddStatus";
            this.btnAddStatus.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAddStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddStatus_ItemClick);
            // 
            // menuItemAddNote
            // 
            this.menuItemAddNote.Name = "menuItemAddNote";
            this.menuItemAddNote.Size = new System.Drawing.Size(219, 22);
            this.menuItemAddNote.Text = "Додати причину затримки";
            // 
            // menuItemSteps
            // 
            this.menuItemSteps.Name = "menuItemSteps";
            this.menuItemSteps.Size = new System.Drawing.Size(192, 22);
            this.menuItemSteps.Text = "Проходження справи";
            // 
            // menuNotes
            // 
            this.menuNotes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDeleteNote});
            this.menuNotes.Name = "menuNotes";
            this.menuNotes.Size = new System.Drawing.Size(178, 26);
            this.menuNotes.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuNotes_ItemClicked);
            // 
            // menuItemDeleteNote
            // 
            this.menuItemDeleteNote.Image = global::Kayflow.Properties.Resources.Delete;
            this.menuItemDeleteNote.Name = "menuItemDeleteNote";
            this.menuItemDeleteNote.Size = new System.Drawing.Size(177, 22);
            this.menuItemDeleteNote.Text = "Видалити причину";
            // 
            // menuHistory
            // 
            this.menuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDeleteHistory});
            this.menuHistory.Name = "menuNotes";
            this.menuHistory.Size = new System.Drawing.Size(130, 26);
            // 
            // menuItemDeleteHistory
            // 
            this.menuItemDeleteHistory.Image = global::Kayflow.Properties.Resources.Delete;
            this.menuItemDeleteHistory.Name = "menuItemDeleteHistory";
            this.menuItemDeleteHistory.Size = new System.Drawing.Size(129, 22);
            this.menuItemDeleteHistory.Text = "Видалити ";
            this.menuItemDeleteHistory.Click += new System.EventHandler(this.menuItemDeleteHistory_Click);
            // 
            // itemAddStatus
            // 
            this.itemAddStatus.Image = global::Kayflow.Properties.Resources.StatusAdd;
            this.itemAddStatus.Name = "itemAddStatus";
            this.itemAddStatus.Size = new System.Drawing.Size(188, 22);
            this.itemAddStatus.Text = "Змінити стан справи";
            // 
            // frmActList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1077, 674);
            this.Controls.Add(this.gridList);
            this.Name = "frmActList";
            this.Text = "Список відкритих справ";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStatusHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActs)).EndInit();
            this.menuNotes.ResumeLayout(false);
            this.menuHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView viewActs;
        private DevExpress.XtraGrid.Columns.GridColumn columnCustomerName;
        private DevExpress.XtraGrid.Views.Grid.GridView viewActDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn columnDocumentName;
        private DevExpress.XtraGrid.Views.Grid.GridView viewSteps;
        private DevExpress.XtraGrid.Columns.GridColumn columnGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn columnDocValue;
        private DevExpress.XtraGrid.Columns.GridColumn columnActionName;
        private DevExpress.XtraGrid.Columns.GridColumn columnDelivered;
        private DevExpress.XtraGrid.Columns.GridColumn columnReceived;
        private DevExpress.XtraGrid.Views.Grid.GridView viewStatusHistory;
        private DevExpress.XtraGrid.Columns.GridColumn columnOnDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnStateDescription;
        private DevExpress.XtraGrid.Columns.GridColumn columEmployeeName;
        private DevExpress.XtraBars.BarButtonItem btnAddNote;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupActs;
        private DevExpress.XtraGrid.Views.Grid.GridView viewNotes;
        private DevExpress.XtraGrid.Columns.GridColumn columnOnDateNote;
        private DevExpress.XtraGrid.Columns.GridColumn columnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn columnEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn columnMeteringDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn columnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn columnCustomerPhone;
        private DevExpress.XtraGrid.Columns.GridColumn columnAreaAmount;
        private DevExpress.XtraGrid.Columns.GridColumn columnActAmount;
        private DevExpress.XtraGrid.Columns.GridColumn columnCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn columnTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn columnActEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn columnStateNameAct;
        private DevExpress.XtraGrid.Columns.GridColumn columnActDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnActNum;
        private DevExpress.XtraGrid.Columns.GridColumn columnPaidOn;
        private DevExpress.XtraGrid.Columns.GridColumn columnLeftOn;
        private DevExpress.XtraGrid.Columns.GridColumn columnApproval1;
        private DevExpress.XtraGrid.Columns.GridColumn columnKailasPaid1;
        private DevExpress.XtraGrid.Columns.GridColumn columnKailasDue;
        private DevExpress.XtraGrid.Columns.GridColumn columnPaidDue;
        private DevExpress.XtraGrid.Columns.GridColumn columnApproval2;
        private DevExpress.XtraGrid.Columns.GridColumn columnKailasPaid2;
        private DevExpress.XtraGrid.Columns.GridColumn columnSalaryCalculated;
        private DevExpress.XtraGrid.Columns.GridColumn columnSalaryPaidDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnCalculatedMain;
        private DevExpress.XtraGrid.Columns.GridColumn columnPaidMainDate;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddNote;
        private DevExpress.XtraGrid.Columns.GridColumn columnStepOrdNum;
        private DevExpress.XtraGrid.Columns.GridColumn columnStepID;
        private DevExpress.XtraGrid.Columns.GridColumn columnDocumentID;
        private DevExpress.XtraGrid.Columns.GridColumn columnHistoryID;
        private DevExpress.XtraGrid.Columns.GridColumn columnNoteID;
        private DevExpress.XtraGrid.Columns.GridColumn columnActID;
        private DevExpress.XtraBars.BarButtonItem btnEditSteps;
        private System.Windows.Forms.ToolStripMenuItem menuItemSteps;
        private System.Windows.Forms.ContextMenuStrip menuNotes;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteNote;
        private System.Windows.Forms.ContextMenuStrip menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView viewHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridHistoryOnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridHistoryTime;
        private DevExpress.XtraGrid.Columns.GridColumn columnHistoryEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn columnHistoryDescription;
        private DevExpress.XtraGrid.Columns.GridColumn columnActDescription;
        private DevExpress.XtraBars.BarButtonItem btnAddStatus;
        private System.Windows.Forms.ToolStripMenuItem itemAddStatus;
        protected DevExpress.XtraGrid.GridControl gridList;
    }
}
