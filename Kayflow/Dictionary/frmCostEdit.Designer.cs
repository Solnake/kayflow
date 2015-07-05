namespace Kayflow.Dictionary
{
    partial class frmCostEdit
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutMain = new DevExpress.XtraLayout.LayoutControl();
            this.chShow = new DevExpress.XtraEditors.CheckEdit();
            this.txtCostName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.chShow);
            this.layoutMain.Controls.Add(this.txtCostName);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 70);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // chShow
            // 
            this.chShow.Location = new System.Drawing.Point(12, 36);
            this.chShow.Name = "chShow";
            this.chShow.Properties.Caption = "Відображати";
            this.chShow.Size = new System.Drawing.Size(360, 19);
            this.chShow.StyleController = this.layoutMain;
            this.chShow.TabIndex = 5;
            // 
            // txtCostName
            // 
            this.txtCostName.Location = new System.Drawing.Point(80, 12);
            this.txtCostName.Name = "txtCostName";
            this.txtCostName.Size = new System.Drawing.Size(292, 20);
            this.txtCostName.StyleController = this.layoutMain;
            this.txtCostName.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Вкажіть вид витрат";
            this.validationProvider.SetValidationRule(this.txtCostName, conditionValidationRule1);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 10;
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 70);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCostName;
            this.layoutControlItem1.CustomizationFormText = "Вид витрат";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Вид витрат";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chShow;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmCostEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 106);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmCostEdit";
            this.Text = "Редагування виду витрат";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCostName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckEdit chShow;
        private DevExpress.XtraEditors.TextEdit txtCostName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
