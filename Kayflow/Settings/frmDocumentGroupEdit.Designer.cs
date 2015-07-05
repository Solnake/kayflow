namespace Kayflow.Settings
{
    partial class frmDocumentGroupEdit
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutMain = new DevExpress.XtraLayout.LayoutControl();
            this.chIsShow = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrdNum = new DevExpress.XtraEditors.SpinEdit();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chIsShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.chIsShow);
            this.layoutMain.Controls.Add(this.txtOrdNum);
            this.layoutMain.Controls.Add(this.txtGroupName);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 68);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // chIsShow
            // 
            this.chIsShow.Location = new System.Drawing.Point(194, 36);
            this.chIsShow.Name = "chIsShow";
            this.chIsShow.Properties.Caption = "Відображати";
            this.chIsShow.Size = new System.Drawing.Size(178, 19);
            this.chIsShow.StyleController = this.layoutMain;
            this.chIsShow.TabIndex = 6;
            // 
            // txtOrdNum
            // 
            this.txtOrdNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdNum.Location = new System.Drawing.Point(84, 36);
            this.txtOrdNum.Name = "txtOrdNum";
            this.txtOrdNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtOrdNum.Properties.IsFloatValue = false;
            this.txtOrdNum.Properties.Mask.EditMask = "N00";
            this.txtOrdNum.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtOrdNum.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdNum.Size = new System.Drawing.Size(106, 20);
            this.txtOrdNum.StyleController = this.layoutMain;
            this.txtOrdNum.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Визначіть № п/п";
            this.validationProvider.SetValidationRule(this.txtOrdNum, conditionValidationRule1);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(84, 12);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(288, 20);
            this.txtGroupName.StyleController = this.layoutMain;
            this.txtGroupName.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Введіть назву групи";
            this.validationProvider.SetValidationRule(this.txtGroupName, conditionValidationRule2);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 10;
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 68);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtGroupName;
            this.layoutControlItem1.CustomizationFormText = "Назва групи";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Назва групи";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOrdNum;
            this.layoutControlItem2.CustomizationFormText = "№ п/п";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem2.Text = "№ п/п";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chIsShow;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(182, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmDocumentGroupEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 104);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmDocumentGroupEdit";
            this.Text = "Редагування групи";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chIsShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckEdit chIsShow;
        private DevExpress.XtraEditors.SpinEdit txtOrdNum;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
