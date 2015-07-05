namespace Kayflow.Settings
{
    partial class frmDocumentGroupList
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
            this.viewDocumentGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnOrdNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocumentGroup)).BeginInit();
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
            this.pageListName.Text = "Групи колонок";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewDocumentGroup;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDocumentGroup});
            // 
            // viewDocumentGroup
            // 
            this.viewDocumentGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnOrdNum,
            this.columnShow,
            this.columnName});
            this.viewDocumentGroup.GridControl = this.gridList;
            this.viewDocumentGroup.Name = "viewDocumentGroup";
            this.viewDocumentGroup.OptionsView.ShowGroupPanel = false;
            this.viewDocumentGroup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnOrdNum, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // columnOrdNum
            // 
            this.columnOrdNum.AppearanceCell.Options.UseTextOptions = true;
            this.columnOrdNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOrdNum.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOrdNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOrdNum.Caption = "№ п/п";
            this.columnOrdNum.FieldName = "OrdNum";
            this.columnOrdNum.MaxWidth = 100;
            this.columnOrdNum.MinWidth = 100;
            this.columnOrdNum.Name = "columnOrdNum";
            this.columnOrdNum.OptionsColumn.AllowEdit = false;
            this.columnOrdNum.Visible = true;
            this.columnOrdNum.VisibleIndex = 0;
            this.columnOrdNum.Width = 100;
            // 
            // columnShow
            // 
            this.columnShow.AppearanceCell.Options.UseTextOptions = true;
            this.columnShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.AppearanceHeader.Options.UseTextOptions = true;
            this.columnShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.Caption = "Відображати";
            this.columnShow.FieldName = "Show";
            this.columnShow.MaxWidth = 90;
            this.columnShow.MinWidth = 90;
            this.columnShow.Name = "columnShow";
            this.columnShow.OptionsColumn.AllowEdit = false;
            this.columnShow.Visible = true;
            this.columnShow.VisibleIndex = 1;
            this.columnShow.Width = 90;
            // 
            // columnName
            // 
            this.columnName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnName.Caption = "Назва групи колонок";
            this.columnName.FieldName = "Name";
            this.columnName.Name = "columnName";
            this.columnName.OptionsColumn.AllowEdit = false;
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 2;
            this.columnName.Width = 234;
            // 
            // frmDocumentGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmDocumentGroupList";
            this.Text = "Групи колонок";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocumentGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDocumentGroup;
        private DevExpress.XtraGrid.Columns.GridColumn columnOrdNum;
        private DevExpress.XtraGrid.Columns.GridColumn columnShow;
        private DevExpress.XtraGrid.Columns.GridColumn columnName;
    }
}
