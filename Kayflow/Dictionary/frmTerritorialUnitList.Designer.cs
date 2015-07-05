namespace Kayflow.Dictionary
{
    partial class frmTerritorialUnitList
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
            this.treeUnits = new DevExpress.XtraTreeList.TreeList();
            this.columnUnitName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Size = new System.Drawing.Size(528, 145);
            // 
            // treeUnits
            // 
            this.treeUnits.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.columnUnitName});
            this.treeUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUnits.Location = new System.Drawing.Point(0, 145);
            this.treeUnits.Name = "treeUnits";
            this.treeUnits.OptionsBehavior.PopulateServiceColumns = true;
            this.treeUnits.Size = new System.Drawing.Size(528, 281);
            this.treeUnits.TabIndex = 2;
            this.treeUnits.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeUnits_FocusedNodeChanged);
            this.treeUnits.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeUnits_PopupMenuShowing);
            this.treeUnits.DoubleClick += new System.EventHandler(this.treeUnits_DoubleClick);
            // 
            // columnUnitName
            // 
            this.columnUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnUnitName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnUnitName.Caption = "Територіальна одиниця";
            this.columnUnitName.FieldName = "UnitName";
            this.columnUnitName.Name = "columnUnitName";
            this.columnUnitName.OptionsColumn.AllowEdit = false;
            this.columnUnitName.Visible = true;
            this.columnUnitName.VisibleIndex = 0;
            // 
            // frmTerritorialUnitList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(528, 461);
            this.Controls.Add(this.treeUnits);
            this.Name = "frmTerritorialUnitList";
            this.Text = "Територіальні одиниці";
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.treeUnits, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeUnits;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnUnitName;
    }
}
