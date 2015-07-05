namespace Kayflow.Settings
{
    partial class frmDocumentEdit
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
            this.ddlValueSet = new DevExpress.XtraEditors.LookUpEdit();
            this.chShow = new DevExpress.XtraEditors.CheckEdit();
            this.txtOrdNum = new DevExpress.XtraEditors.SpinEdit();
            this.txtDocumentName = new DevExpress.XtraEditors.TextEdit();
            this.ddlGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlValueSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.ddlValueSet);
            this.layoutMain.Controls.Add(this.chShow);
            this.layoutMain.Controls.Add(this.txtOrdNum);
            this.layoutMain.Controls.Add(this.txtDocumentName);
            this.layoutMain.Controls.Add(this.ddlGroup);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 116);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // ddlValueSet
            // 
            this.ddlValueSet.Location = new System.Drawing.Point(97, 84);
            this.ddlValueSet.Name = "ddlValueSet";
            this.ddlValueSet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlValueSet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SetName", "Назва типу")});
            this.ddlValueSet.Properties.DisplayMember = "SetName";
            this.ddlValueSet.Properties.NullText = "Оберіть тип даних";
            this.ddlValueSet.Properties.ShowFooter = false;
            this.ddlValueSet.Properties.ShowHeader = false;
            this.ddlValueSet.Properties.ValueMember = "ID";
            this.ddlValueSet.Size = new System.Drawing.Size(275, 20);
            this.ddlValueSet.StyleController = this.layoutMain;
            this.ddlValueSet.TabIndex = 8;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Оберіть тип даних";
            this.validationProvider.SetValidationRule(this.ddlValueSet, conditionValidationRule1);
            // 
            // chShow
            // 
            this.chShow.Location = new System.Drawing.Point(194, 60);
            this.chShow.Name = "chShow";
            this.chShow.Properties.Caption = "Відображати";
            this.chShow.Size = new System.Drawing.Size(178, 19);
            this.chShow.StyleController = this.layoutMain;
            this.chShow.TabIndex = 7;
            // 
            // txtOrdNum
            // 
            this.txtOrdNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdNum.Location = new System.Drawing.Point(97, 60);
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
            this.txtOrdNum.Size = new System.Drawing.Size(93, 20);
            this.txtOrdNum.StyleController = this.layoutMain;
            this.txtOrdNum.TabIndex = 6;
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Location = new System.Drawing.Point(97, 36);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(275, 20);
            this.txtDocumentName.StyleController = this.layoutMain;
            this.txtDocumentName.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Введіть назву колонки";
            this.validationProvider.SetValidationRule(this.txtDocumentName, conditionValidationRule2);
            // 
            // ddlGroup
            // 
            this.ddlGroup.Location = new System.Drawing.Point(97, 12);
            this.ddlGroup.Name = "ddlGroup";
            this.ddlGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrdNum", "№ п/п", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Група")});
            this.ddlGroup.Properties.DisplayMember = "GroupName";
            this.ddlGroup.Properties.NullText = "Оберіть групу";
            this.ddlGroup.Properties.ShowFooter = false;
            this.ddlGroup.Properties.ValueMember = "ID";
            this.ddlGroup.Size = new System.Drawing.Size(275, 20);
            this.ddlGroup.StyleController = this.layoutMain;
            this.ddlGroup.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Оберіть групу";
            this.validationProvider.SetValidationRule(this.ddlGroup, conditionValidationRule3);
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
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 10;
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 116);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ddlGroup;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Група колонки";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDocumentName;
            this.layoutControlItem2.CustomizationFormText = "Назва колонки";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem2.Text = "Назва колонки";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtOrdNum;
            this.layoutControlItem3.CustomizationFormText = "№ п/п";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem3.Text = "№ п/п";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chShow;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(182, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ddlValueSet;
            this.layoutControlItem5.CustomizationFormText = "Тип даних";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem5.Text = "Тип даних";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(75, 13);
            // 
            // frmDocumentEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 152);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmDocumentEdit";
            this.Text = "Редагувати додаткову колонку";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlValueSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit ddlGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit ddlValueSet;
        private DevExpress.XtraEditors.CheckEdit chShow;
        private DevExpress.XtraEditors.SpinEdit txtOrdNum;
        private DevExpress.XtraEditors.TextEdit txtDocumentName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
