namespace Kayflow.Settings
{
    partial class frmActActionEdit
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutMain = new DevExpress.XtraLayout.LayoutControl();
            this.ddlAlertColor = new DevExpress.XtraEditors.ColorEdit();
            this.txtRelativeAlertDays = new DevExpress.XtraEditors.SpinEdit();
            this.txtAlertDays = new DevExpress.XtraEditors.SpinEdit();
            this.chShow = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrdNum = new DevExpress.XtraEditors.SpinEdit();
            this.txtActionName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAlertColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelativeAlertDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlertDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.ddlAlertColor);
            this.layoutMain.Controls.Add(this.txtRelativeAlertDays);
            this.layoutMain.Controls.Add(this.txtAlertDays);
            this.layoutMain.Controls.Add(this.chShow);
            this.layoutMain.Controls.Add(this.txtOrdNum);
            this.layoutMain.Controls.Add(this.txtActionName);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 117);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // ddlAlertColor
            // 
            this.ddlAlertColor.EditValue = System.Drawing.Color.Empty;
            this.ddlAlertColor.Location = new System.Drawing.Point(93, 84);
            this.ddlAlertColor.Name = "ddlAlertColor";
            this.ddlAlertColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlAlertColor.Properties.CustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Transparent,
        System.Drawing.Color.DarkSlateBlue,
        System.Drawing.Color.MediumSlateBlue,
        System.Drawing.Color.MediumPurple,
        System.Drawing.Color.BlueViolet,
        System.Drawing.Color.Indigo,
        System.Drawing.Color.DarkOrchid,
        System.Drawing.Color.DarkViolet,
        System.Drawing.Color.MediumVioletRed,
        System.Drawing.Color.DeepPink,
        System.Drawing.Color.HotPink,
        System.Drawing.Color.PaleVioletRed,
        System.Drawing.Color.Crimson,
        System.Drawing.Color.Pink,
        System.Drawing.Color.LightPink,
        System.Drawing.Color.Magenta};
            this.ddlAlertColor.Properties.ShowSystemColors = false;
            this.ddlAlertColor.Properties.ShowWebColors = false;
            this.ddlAlertColor.Properties.StoreColorAsInteger = true;
            this.ddlAlertColor.Size = new System.Drawing.Size(279, 20);
            this.ddlAlertColor.StyleController = this.layoutMain;
            this.ddlAlertColor.TabIndex = 9;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Оберіть колір";
            this.validationProvider.SetValidationRule(this.ddlAlertColor, conditionValidationRule1);
            // 
            // txtRelativeAlertDays
            // 
            this.txtRelativeAlertDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRelativeAlertDays.Location = new System.Drawing.Point(275, 60);
            this.txtRelativeAlertDays.Name = "txtRelativeAlertDays";
            this.txtRelativeAlertDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRelativeAlertDays.Properties.IsFloatValue = false;
            this.txtRelativeAlertDays.Properties.Mask.EditMask = "N00";
            this.txtRelativeAlertDays.Properties.MaxLength = 99;
            this.txtRelativeAlertDays.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtRelativeAlertDays.Size = new System.Drawing.Size(97, 20);
            this.txtRelativeAlertDays.StyleController = this.layoutMain;
            this.txtRelativeAlertDays.TabIndex = 8;
            // 
            // txtAlertDays
            // 
            this.txtAlertDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAlertDays.Location = new System.Drawing.Point(93, 60);
            this.txtAlertDays.Name = "txtAlertDays";
            this.txtAlertDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAlertDays.Properties.IsFloatValue = false;
            this.txtAlertDays.Properties.Mask.EditMask = "N00";
            this.txtAlertDays.Properties.MaxLength = 99;
            this.txtAlertDays.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtAlertDays.Size = new System.Drawing.Size(97, 20);
            this.txtAlertDays.StyleController = this.layoutMain;
            this.txtAlertDays.TabIndex = 7;
            // 
            // chShow
            // 
            this.chShow.Location = new System.Drawing.Point(194, 36);
            this.chShow.Name = "chShow";
            this.chShow.Properties.Caption = "Відображати";
            this.chShow.Size = new System.Drawing.Size(178, 19);
            this.chShow.StyleController = this.layoutMain;
            this.chShow.TabIndex = 6;
            // 
            // txtOrdNum
            // 
            this.txtOrdNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdNum.Location = new System.Drawing.Point(93, 36);
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
            this.txtOrdNum.Size = new System.Drawing.Size(97, 20);
            this.txtOrdNum.StyleController = this.layoutMain;
            this.txtOrdNum.TabIndex = 5;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.validationProvider.SetValidationRule(this.txtOrdNum, conditionValidationRule2);
            // 
            // txtActionName
            // 
            this.txtActionName.Location = new System.Drawing.Point(93, 12);
            this.txtActionName.Name = "txtActionName";
            this.txtActionName.Size = new System.Drawing.Size(279, 20);
            this.txtActionName.StyleController = this.layoutMain;
            this.txtActionName.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Введіть назву етапу";
            this.validationProvider.SetValidationRule(this.txtActionName, conditionValidationRule3);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 10;
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 117);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtActionName;
            this.layoutControlItem1.CustomizationFormText = "Назва етапу";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Назва етапу";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOrdNum;
            this.layoutControlItem2.CustomizationFormText = "№ п/п";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem2.Text = "№ п/п";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chShow;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(182, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtAlertDays;
            this.layoutControlItem4.CustomizationFormText = "Абс. термін";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem4.Text = "Абс. термін";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtRelativeAlertDays;
            this.layoutControlItem5.CustomizationFormText = "Віднос. термін";
            this.layoutControlItem5.Location = new System.Drawing.Point(182, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem5.Text = "Віднос. термін";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ddlAlertColor;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(364, 25);
            this.layoutControlItem6.Text = "Колір";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(71, 13);
            // 
            // frmActActionEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 153);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmActActionEdit";
            this.Text = "Редагування етапу";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlAlertColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelativeAlertDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlertDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ColorEdit ddlAlertColor;
        private DevExpress.XtraEditors.SpinEdit txtRelativeAlertDays;
        private DevExpress.XtraEditors.SpinEdit txtAlertDays;
        private DevExpress.XtraEditors.CheckEdit chShow;
        private DevExpress.XtraEditors.SpinEdit txtOrdNum;
        private DevExpress.XtraEditors.TextEdit txtActionName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
