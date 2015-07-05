namespace Kayflow.Staff
{
    partial class frmEmployeeList
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
            this.viewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnOfficeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnIsAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(565, 145);
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewEmployee;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(565, 337);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewEmployee});
            // 
            // viewEmployee
            // 
            this.viewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnOfficeName,
            this.columnDisplayName,
            this.columnLogin,
            this.columnIsAdmin});
            this.viewEmployee.GridControl = this.gridList;
            this.viewEmployee.Name = "viewEmployee";
            this.viewEmployee.OptionsView.ShowGroupPanel = false;
            // 
            // columnOfficeName
            // 
            this.columnOfficeName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnOfficeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnOfficeName.Caption = "Офіс";
            this.columnOfficeName.FieldName = "OfficeName";
            this.columnOfficeName.MaxWidth = 100;
            this.columnOfficeName.MinWidth = 100;
            this.columnOfficeName.Name = "columnOfficeName";
            this.columnOfficeName.OptionsColumn.AllowEdit = false;
            this.columnOfficeName.Width = 100;
            // 
            // columnDisplayName
            // 
            this.columnDisplayName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnDisplayName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnDisplayName.Caption = "Працівник";
            this.columnDisplayName.FieldName = "DisplayName";
            this.columnDisplayName.Name = "columnDisplayName";
            this.columnDisplayName.OptionsColumn.AllowEdit = false;
            this.columnDisplayName.Visible = true;
            this.columnDisplayName.VisibleIndex = 2;
            this.columnDisplayName.Width = 347;
            // 
            // columnLogin
            // 
            this.columnLogin.AppearanceHeader.Options.UseTextOptions = true;
            this.columnLogin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnLogin.Caption = "Логін";
            this.columnLogin.FieldName = "Login";
            this.columnLogin.MaxWidth = 100;
            this.columnLogin.MinWidth = 100;
            this.columnLogin.Name = "columnLogin";
            this.columnLogin.OptionsColumn.AllowEdit = false;
            this.columnLogin.Visible = true;
            this.columnLogin.VisibleIndex = 1;
            this.columnLogin.Width = 100;
            // 
            // columnIsAdmin
            // 
            this.columnIsAdmin.AppearanceCell.Options.UseTextOptions = true;
            this.columnIsAdmin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnIsAdmin.AppearanceHeader.Options.UseTextOptions = true;
            this.columnIsAdmin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnIsAdmin.Caption = "Адміністратор";
            this.columnIsAdmin.FieldName = "IsAdmin";
            this.columnIsAdmin.MaxWidth = 100;
            this.columnIsAdmin.MinWidth = 100;
            this.columnIsAdmin.Name = "columnIsAdmin";
            this.columnIsAdmin.OptionsColumn.AllowEdit = false;
            this.columnIsAdmin.Visible = true;
            this.columnIsAdmin.VisibleIndex = 0;
            this.columnIsAdmin.Width = 100;
            // 
            // frmEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 517);
            this.Controls.Add(this.gridList);
            this.Name = "frmEmployeeList";
            this.Text = "Список працівників";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn columnOfficeName;
        private DevExpress.XtraGrid.Columns.GridColumn columnDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn columnLogin;
        private DevExpress.XtraGrid.Columns.GridColumn columnIsAdmin;
    }
}