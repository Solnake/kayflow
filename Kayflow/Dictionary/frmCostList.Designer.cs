namespace Kayflow.Dictionary
{
    partial class frmCostList
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
            this.viewCost = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCostName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCost)).BeginInit();
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
            this.pageListName.Text = "Види витрат";
            // 
            // gridList
            // 
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 145);
            this.gridList.MainView = this.viewCost;
            this.gridList.MenuManager = this.ribbon;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(442, 269);
            this.gridList.TabIndex = 2;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewCost});
            // 
            // viewCost
            // 
            this.viewCost.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnShow,
            this.columnCostName});
            this.viewCost.GridControl = this.gridList;
            this.viewCost.Name = "viewCost";
            this.viewCost.OptionsView.ShowGroupPanel = false;
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
            this.columnShow.VisibleIndex = 0;
            this.columnShow.Width = 100;
            // 
            // columnCostName
            // 
            this.columnCostName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnCostName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnCostName.Caption = "Вид витрати";
            this.columnCostName.FieldName = "CostName";
            this.columnCostName.Name = "columnCostName";
            this.columnCostName.OptionsColumn.AllowEdit = false;
            this.columnCostName.Visible = true;
            this.columnCostName.VisibleIndex = 1;
            this.columnCostName.Width = 324;
            // 
            // frmCostList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridList);
            this.Name = "frmCostList";
            this.Text = "Види витрат";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.gridList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView viewCost;
        private DevExpress.XtraGrid.Columns.GridColumn columnShow;
        private DevExpress.XtraGrid.Columns.GridColumn columnCostName;
    }
}
