namespace Kayflow.Dictionary
{
    partial class frmStateList
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
            this.viewState = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnStateName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewState)).BeginInit();
            this.SuspendLayout();
            // 
            // pageListName
            // 
            this.pageListName.Text = "Статуси";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewState;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewState});
            // 
            // viewState
            // 
            this.viewState.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnStateName});
            this.viewState.GridControl = this.gridList;
            this.viewState.Name = "viewState";
            this.viewState.OptionsView.ShowGroupPanel = false;
            // 
            // columnStateName
            // 
            this.columnStateName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnStateName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnStateName.Caption = "Статус";
            this.columnStateName.FieldName = "StateName";
            this.columnStateName.Name = "columnStateName";
            this.columnStateName.OptionsColumn.AllowEdit = false;
            this.columnStateName.Visible = true;
            this.columnStateName.VisibleIndex = 0;
            // 
            // frmStateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmStateList";
            this.Text = "Статуси актів";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewState;
        private DevExpress.XtraGrid.Columns.GridColumn columnStateName;
    }
}
