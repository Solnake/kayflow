namespace Kayflow.Settings
{
    partial class frmActActionList
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
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.viewActAction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnOrdNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnActionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnAlertDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnRelativeAlertDays = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActAction)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(442, 145);
            // 
            // pageListName
            // 
            this.pageListName.Text = "Етапи";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewActAction;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewActAction});
            // 
            // viewActAction
            // 
            this.viewActAction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnOrdNum,
            this.columnShow,
            this.columnActionName,
            this.columnAlertDays,
            this.columnRelativeAlertDays});
            this.viewActAction.GridControl = this.gridList;
            this.viewActAction.Name = "viewActAction";
            this.viewActAction.OptionsView.ShowGroupPanel = false;
            this.viewActAction.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnOrdNum, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewActAction.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.viewActAction_RowCellStyle);
            // 
            // columnOrdNum
            // 
            this.columnOrdNum.AppearanceCell.Options.UseTextOptions = true;
            this.columnOrdNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOrdNum.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOrdNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOrdNum.Caption = "№ п/п";
            this.columnOrdNum.FieldName = "OrdNum";
            this.columnOrdNum.MaxWidth = 70;
            this.columnOrdNum.MinWidth = 70;
            this.columnOrdNum.Name = "columnOrdNum";
            this.columnOrdNum.OptionsColumn.AllowEdit = false;
            this.columnOrdNum.Visible = true;
            this.columnOrdNum.VisibleIndex = 0;
            this.columnOrdNum.Width = 70;
            // 
            // columnShow
            // 
            this.columnShow.AppearanceCell.Options.UseTextOptions = true;
            this.columnShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.AppearanceHeader.Options.UseTextOptions = true;
            this.columnShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.Caption = "Відображати";
            this.columnShow.FieldName = "Show";
            this.columnShow.MaxWidth = 100;
            this.columnShow.MinWidth = 100;
            this.columnShow.Name = "columnShow";
            this.columnShow.OptionsColumn.AllowEdit = false;
            this.columnShow.Visible = true;
            this.columnShow.VisibleIndex = 1;
            this.columnShow.Width = 100;
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
            this.columnActionName.VisibleIndex = 2;
            // 
            // columnAlertDays
            // 
            this.columnAlertDays.AppearanceCell.Options.UseTextOptions = true;
            this.columnAlertDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAlertDays.AppearanceHeader.Options.UseTextOptions = true;
            this.columnAlertDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnAlertDays.Caption = "Абсолютний термін";
            this.columnAlertDays.FieldName = "AlertDays";
            this.columnAlertDays.Name = "columnAlertDays";
            this.columnAlertDays.OptionsColumn.AllowEdit = false;
            this.columnAlertDays.Visible = true;
            this.columnAlertDays.VisibleIndex = 3;
            // 
            // columnRelativeAlertDays
            // 
            this.columnRelativeAlertDays.AppearanceCell.Options.UseTextOptions = true;
            this.columnRelativeAlertDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnRelativeAlertDays.AppearanceHeader.Options.UseTextOptions = true;
            this.columnRelativeAlertDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnRelativeAlertDays.Caption = "Відносний термін";
            this.columnRelativeAlertDays.FieldName = "RelativeAlertDays";
            this.columnRelativeAlertDays.Name = "columnRelativeAlertDays";
            this.columnRelativeAlertDays.OptionsColumn.AllowEdit = false;
            this.columnRelativeAlertDays.Visible = true;
            this.columnRelativeAlertDays.VisibleIndex = 4;
            // 
            // frmActActionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmActActionList";
            this.Text = "Етапи проходження справи";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewActAction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewActAction;
        private DevExpress.XtraGrid.Columns.GridColumn columnOrdNum;
        private DevExpress.XtraGrid.Columns.GridColumn columnShow;
        private DevExpress.XtraGrid.Columns.GridColumn columnActionName;
        private DevExpress.XtraGrid.Columns.GridColumn columnAlertDays;
        private DevExpress.XtraGrid.Columns.GridColumn columnRelativeAlertDays;
    }
}
