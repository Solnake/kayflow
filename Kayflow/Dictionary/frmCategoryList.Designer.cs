namespace Kayflow.Dictionary
{
    partial class frmCategoryList
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
            this.viewCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCategory)).BeginInit();
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
            this.pageListName.Text = "Категорії";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewCategory;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewCategory});
            // 
            // viewCategory
            // 
            this.viewCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnCategoryName});
            this.viewCategory.GridControl = this.gridList;
            this.viewCategory.Name = "viewCategory";
            this.viewCategory.OptionsView.ShowGroupPanel = false;
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
            this.columnCategoryName.VisibleIndex = 0;
            // 
            // frmCategoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmCategoryList";
            this.Text = "Категорії";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewCategory;
        private DevExpress.XtraGrid.Columns.GridColumn columnCategoryName;
    }
}
