namespace Kayflow.Staff
{
    partial class frmOfficeEdit
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
            this.chIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.txtOfficeName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.chIsDefault);
            this.layoutMain.Controls.Add(this.txtOfficeName);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 78);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // chIsDefault
            // 
            this.chIsDefault.Location = new System.Drawing.Point(12, 36);
            this.chIsDefault.Name = "chIsDefault";
            this.chIsDefault.Properties.Caption = "Поточний офіс";
            this.chIsDefault.Size = new System.Drawing.Size(360, 19);
            this.chIsDefault.StyleController = this.layoutMain;
            this.chIsDefault.TabIndex = 5;
            // 
            // txtOfficeName
            // 
            this.txtOfficeName.Location = new System.Drawing.Point(45, 12);
            this.txtOfficeName.Name = "txtOfficeName";
            this.txtOfficeName.Size = new System.Drawing.Size(327, 20);
            this.txtOfficeName.StyleController = this.layoutMain;
            this.txtOfficeName.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Вкажіть назву офісу";
            this.validationProvider.SetValidationRule(this.txtOfficeName, conditionValidationRule1);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 78);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtOfficeName;
            this.layoutControlItem1.CustomizationFormText = "Офіс";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Офіс";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(23, 13);
            this.layoutControlItem1.TextToControlDistance = 10;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chIsDefault;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 34);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmOfficeEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 114);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmOfficeEdit";
            this.Text = "Редагування даних офісу";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOfficeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckEdit chIsDefault;
        private DevExpress.XtraEditors.TextEdit txtOfficeName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
