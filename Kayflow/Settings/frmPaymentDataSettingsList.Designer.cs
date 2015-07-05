namespace Kayflow.Settings
{
    partial class frmPaymentDataSettingsList
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
            this.viewSettings = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSettings)).BeginInit();
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
            this.pageListName.Text = "Відомості про оплату";
            // 
            // btnAdd
            // 
            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnEdit
            // 
            this.btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnDelete
            // 
            this.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewSettings;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewSettings});
            // 
            // viewSettings
            // 
            this.viewSettings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnName,
            this.columnShow});
            this.viewSettings.GridControl = this.gridList;
            this.viewSettings.Name = "viewSettings";
            this.viewSettings.OptionsView.ShowGroupPanel = false;
            this.viewSettings.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.viewSettings_CellValueChanged);
            // 
            // columnName
            // 
            this.columnName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnName.Caption = "Назва колонки";
            this.columnName.FieldName = "Name";
            this.columnName.Name = "columnName";
            this.columnName.OptionsColumn.AllowEdit = false;
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 0;
            // 
            // columnShow
            // 
            this.columnShow.AppearanceCell.Options.UseTextOptions = true;
            this.columnShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.AppearanceHeader.Options.UseTextOptions = true;
            this.columnShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnShow.Caption = "Відображати";
            this.columnShow.FieldName = "Show";
            this.columnShow.MaxWidth = 75;
            this.columnShow.MinWidth = 75;
            this.columnShow.Name = "columnShow";
            this.columnShow.Visible = true;
            this.columnShow.VisibleIndex = 1;
            // 
            // frmPaymentDataSettingsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmPaymentDataSettingsList";
            this.Text = "Відомості про оплату";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewSettings;
        private DevExpress.XtraGrid.Columns.GridColumn columnName;
        private DevExpress.XtraGrid.Columns.GridColumn columnShow;
    }
}
