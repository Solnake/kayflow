namespace Kayflow.Dictionary
{
    partial class frmTerritorialUnitFind
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
            this.columnName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Text = "Вибрати";
            // 
            // treeUnits
            // 
            this.treeUnits.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.columnName});
            this.treeUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUnits.Location = new System.Drawing.Point(0, 0);
            this.treeUnits.Name = "treeUnits";
            this.treeUnits.Size = new System.Drawing.Size(384, 287);
            this.treeUnits.TabIndex = 1;
            this.treeUnits.DoubleClick += new System.EventHandler(this.treeUnits_DoubleClick);
            // 
            // columnName
            // 
            this.columnName.AppearanceHeader.Options.UseTextOptions = true;
            this.columnName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnName.Caption = "Територіальна одиниця";
            this.columnName.FieldName = "Name";
            this.columnName.Name = "columnName";
            this.columnName.OptionsColumn.AllowEdit = false;
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 0;
            // 
            // frmTerritorialUnitFind
            // 
            this.ClientSize = new System.Drawing.Size(384, 323);
            this.Controls.Add(this.treeUnits);
            this.Name = "frmTerritorialUnitFind";
            this.Text = "Пошук населеного пункту";
            this.Controls.SetChildIndex(this.treeUnits, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeUnits;
        private DevExpress.XtraTreeList.Columns.TreeListColumn columnName;

    }
}
