namespace Kayflow.Staff
{
    partial class frmOfficeList
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
            this.viewOffice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnOfficeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOffice)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(698, 145);
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewOffice;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(698, 397);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewOffice});
            // 
            // viewOffice
            // 
            this.viewOffice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnIsDefault,
            this.columnOfficeName});
            this.viewOffice.GridControl = this.gridList;
            this.viewOffice.Name = "viewOffice";
            this.viewOffice.OptionsView.ShowGroupPanel = false;
            // 
            // columnIsDefault
            // 
            this.columnIsDefault.AppearanceCell.Options.UseTextOptions = true;
            this.columnIsDefault.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnIsDefault.AppearanceHeader.Options.UseTextOptions = true;
            this.columnIsDefault.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnIsDefault.Caption = "Поточний";
            this.columnIsDefault.FieldName = "IsDefault";
            this.columnIsDefault.Name = "columnIsDefault";
            this.columnIsDefault.OptionsColumn.AllowEdit = false;
            this.columnIsDefault.Visible = true;
            this.columnIsDefault.VisibleIndex = 0;
            // 
            // columnOfficeName
            // 
            this.columnOfficeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOfficeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOfficeName.Caption = "Назва офісу";
            this.columnOfficeName.FieldName = "OfficeName";
            this.columnOfficeName.Name = "columnOfficeName";
            this.columnOfficeName.OptionsColumn.AllowEdit = false;
            this.columnOfficeName.Visible = true;
            this.columnOfficeName.VisibleIndex = 1;
            this.columnOfficeName.Width = 605;
            // 
            // frmOfficeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(698, 577);
            this.Controls.Add(this.gridList);
            this.Name = "frmOfficeList";
            this.Text = "Список офісів";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOffice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewOffice;
        private DevExpress.XtraGrid.Columns.GridColumn columnIsDefault;
        private DevExpress.XtraGrid.Columns.GridColumn columnOfficeName;
    }
}
