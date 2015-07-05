namespace Kayflow.Expenses
{
    partial class frmExpenseList
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.viewCosts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnCostID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.viewExpense = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnOnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDistance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnSumm = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(629, 145);
            // 
            // pageListName
            // 
            this.pageListName.Text = "Витрати";
            // 
            // viewCosts
            // 
            this.viewCosts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnCostID,
            this.columnCostName,
            this.columnAmount});
            this.viewCosts.GridControl = this.gridList;
            this.viewCosts.Name = "viewCosts";
            this.viewCosts.OptionsDetail.AllowZoomDetail = false;
            this.viewCosts.OptionsDetail.EnableMasterViewMode = false;
            this.viewCosts.OptionsView.ShowGroupPanel = false;
            // 
            // columnCostID
            // 
            this.columnCostID.Caption = "CostID";
            this.columnCostID.FieldName = "CostID";
            this.columnCostID.Name = "columnCostID";
            // 
            // columnCostName
            // 
            this.columnCostName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCostName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCostName.Caption = "Вид витрат";
            this.columnCostName.FieldName = "CostName";
            this.columnCostName.Name = "columnCostName";
            this.columnCostName.OptionsColumn.AllowEdit = false;
            this.columnCostName.Visible = true;
            this.columnCostName.VisibleIndex = 0;
            // 
            // columnAmount
            // 
            this.columnAmount.AppearanceHeader.Options.UseTextOptions = true;
            this.columnAmount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAmount.Caption = "Сума";
            this.columnAmount.DisplayFormat.FormatString = "n";
            this.columnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnAmount.FieldName = "Amount";
            this.columnAmount.MaxWidth = 75;
            this.columnAmount.MinWidth = 75;
            this.columnAmount.Name = "columnAmount";
            this.columnAmount.OptionsColumn.AllowEdit = false;
            this.columnAmount.Visible = true;
            this.columnAmount.VisibleIndex = 1;
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.viewCosts;
            gridLevelNode1.RelationName = "Costs";
            this.gridList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewExpense;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(629, 345);
            this.gridList.TabIndex = 3;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewExpense,
            this.viewCosts});
            // 
            // viewExpense
            // 
            this.viewExpense.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnID,
            this.columnOnDate,
            this.columnEmployeeName,
            this.columnDistance,
            this.columnSumm});
            this.viewExpense.GridControl = this.gridList;
            this.viewExpense.GroupCount = 1;
            this.viewExpense.Name = "viewExpense";
            this.viewExpense.OptionsDetail.ShowDetailTabs = false;
            this.viewExpense.OptionsView.ShowGroupPanel = false;
            this.viewExpense.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnOnDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewExpense.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.viewExpense_MasterRowGetChildList);
            this.viewExpense.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.viewExpense_MasterRowGetRelationName);
            this.viewExpense.MasterRowGetRelationDisplayCaption += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.viewExpense_MasterRowGetRelationDisplayCaption);
            this.viewExpense.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.viewExpense_MasterRowGetRelationCount);
            // 
            // columnID
            // 
            this.columnID.Caption = "ID";
            this.columnID.FieldName = "ID";
            this.columnID.Name = "columnID";
            // 
            // columnOnDate
            // 
            this.columnOnDate.Caption = "Дата";
            this.columnOnDate.DisplayFormat.FormatString = "d";
            this.columnOnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.columnOnDate.FieldName = "OnDate";
            this.columnOnDate.Name = "columnOnDate";
            this.columnOnDate.OptionsColumn.AllowEdit = false;
            this.columnOnDate.Visible = true;
            this.columnOnDate.VisibleIndex = 0;
            // 
            // columnEmployeeName
            // 
            this.columnEmployeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnEmployeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnEmployeeName.Caption = "Землеупорядник";
            this.columnEmployeeName.FieldName = "EmployeeName";
            this.columnEmployeeName.Name = "columnEmployeeName";
            this.columnEmployeeName.OptionsColumn.AllowEdit = false;
            this.columnEmployeeName.Visible = true;
            this.columnEmployeeName.VisibleIndex = 0;
            // 
            // columnDistance
            // 
            this.columnDistance.AppearanceCell.Options.UseTextOptions = true;
            this.columnDistance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDistance.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDistance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDistance.Caption = "Дистанція";
            this.columnDistance.FieldName = "Distance";
            this.columnDistance.MaxWidth = 75;
            this.columnDistance.MinWidth = 75;
            this.columnDistance.Name = "columnDistance";
            this.columnDistance.OptionsColumn.AllowEdit = false;
            this.columnDistance.Visible = true;
            this.columnDistance.VisibleIndex = 1;
            // 
            // columnSumm
            // 
            this.columnSumm.AppearanceCell.Options.UseTextOptions = true;
            this.columnSumm.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSumm.AppearanceHeader.Options.UseTextOptions = true;
            this.columnSumm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSumm.Caption = "Сума витрат";
            this.columnSumm.FieldName = "Summ";
            this.columnSumm.GroupFormat.FormatString = "n";
            this.columnSumm.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.columnSumm.MaxWidth = 75;
            this.columnSumm.MinWidth = 75;
            this.columnSumm.Name = "columnSumm";
            this.columnSumm.OptionsColumn.AllowEdit = false;
            this.columnSumm.Visible = true;
            this.columnSumm.VisibleIndex = 2;
            // 
            // frmExpenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(629, 525);
            this.Controls.Add(this.gridList);
            this.Name = "frmExpenseList";
            this.Text = "Витрати";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewExpense;
        private DevExpress.XtraGrid.Columns.GridColumn columnID;
        private DevExpress.XtraGrid.Columns.GridColumn columnOnDate;
        private DevExpress.XtraGrid.Columns.GridColumn columnEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn columnDistance;
        private DevExpress.XtraGrid.Columns.GridColumn columnSumm;
        private DevExpress.XtraGrid.Views.Grid.GridView viewCosts;
        private DevExpress.XtraGrid.Columns.GridColumn columnCostID;
        private DevExpress.XtraGrid.Columns.GridColumn columnCostName;
        private DevExpress.XtraGrid.Columns.GridColumn columnAmount;
    }
}
