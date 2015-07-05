namespace Kayflow.Settings
{
    partial class frmDocumentList
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
            this.viewDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridOrdNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnSetName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocuments)).BeginInit();
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
            this.pageListName.Text = "Додаткові колонки";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewDocuments;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(554, 261);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDocuments});
            // 
            // viewDocuments
            // 
            this.viewDocuments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnGroupName,
            this.gridOrdNum,
            this.columnShow,
            this.columnDocumentName,
            this.columnSetName});
            this.viewDocuments.GridControl = this.gridList;
            this.viewDocuments.GroupCount = 1;
            this.viewDocuments.Name = "viewDocuments";
            this.viewDocuments.OptionsView.ShowGroupPanel = false;
            this.viewDocuments.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnGroupName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridOrdNum, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // columnGroupName
            // 
            this.columnGroupName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnGroupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnGroupName.Caption = "Група ";
            this.columnGroupName.FieldName = "GroupName";
            this.columnGroupName.Name = "columnGroupName";
            this.columnGroupName.OptionsColumn.AllowEdit = false;
            this.columnGroupName.Visible = true;
            this.columnGroupName.VisibleIndex = 0;
            // 
            // gridOrdNum
            // 
            this.gridOrdNum.AppearanceCell.Options.UseTextOptions = true;
            this.gridOrdNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridOrdNum.AppearanceHeader.Options.UseTextOptions = true;
            this.gridOrdNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridOrdNum.Caption = "№ п/п";
            this.gridOrdNum.FieldName = "OrdNum";
            this.gridOrdNum.MaxWidth = 50;
            this.gridOrdNum.MinWidth = 50;
            this.gridOrdNum.Name = "gridOrdNum";
            this.gridOrdNum.OptionsColumn.AllowEdit = false;
            this.gridOrdNum.Visible = true;
            this.gridOrdNum.VisibleIndex = 0;
            this.gridOrdNum.Width = 71;
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
            // columnDocumentName
            // 
            this.columnDocumentName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDocumentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDocumentName.Caption = "Назва колонки";
            this.columnDocumentName.FieldName = "DocumentName";
            this.columnDocumentName.Name = "columnDocumentName";
            this.columnDocumentName.OptionsColumn.AllowEdit = false;
            this.columnDocumentName.Visible = true;
            this.columnDocumentName.VisibleIndex = 2;
            // 
            // columnSetName
            // 
            this.columnSetName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnSetName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSetName.Caption = "Тип даних";
            this.columnSetName.FieldName = "SetName";
            this.columnSetName.Name = "columnSetName";
            this.columnSetName.OptionsColumn.AllowEdit = false;
            this.columnSetName.Visible = true;
            this.columnSetName.VisibleIndex = 3;
            // 
            // frmDocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(554, 441);
            this.Controls.Add(this.gridList);
            this.Name = "frmDocumentList";
            this.Text = "Налаштування додаткових колонок";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDocuments;
        private DevExpress.XtraGrid.Columns.GridColumn columnGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn gridOrdNum;
        private DevExpress.XtraGrid.Columns.GridColumn columnShow;
        private DevExpress.XtraGrid.Columns.GridColumn columnDocumentName;
        private DevExpress.XtraGrid.Columns.GridColumn columnSetName;
    }
}
