namespace Kayflow.Dictionary
{
    partial class frmTerritorialUnitEdit
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
            this.ddlParentUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.ddlParentType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUnitName = new DevExpress.XtraEditors.TextEdit();
            this.ddlUnitType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlParentUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlParentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUnitType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.ddlParentUnit);
            this.layoutMain.Controls.Add(this.ddlParentType);
            this.layoutMain.Controls.Add(this.txtUnitName);
            this.layoutMain.Controls.Add(this.ddlUnitType);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 156);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // ddlParentUnit
            // 
            this.ddlParentUnit.Location = new System.Drawing.Point(98, 116);
            this.ddlParentUnit.Name = "ddlParentUnit";
            this.ddlParentUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlParentUnit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Name5")});
            this.ddlParentUnit.Properties.DisplayMember = "UnitName";
            this.ddlParentUnit.Properties.NullText = "Оберіть підпорядкування";
            this.ddlParentUnit.Properties.ShowFooter = false;
            this.ddlParentUnit.Properties.ShowHeader = false;
            this.ddlParentUnit.Properties.ValueMember = "ID";
            this.ddlParentUnit.Size = new System.Drawing.Size(266, 20);
            this.ddlParentUnit.StyleController = this.layoutMain;
            this.ddlParentUnit.TabIndex = 7;
            // 
            // ddlParentType
            // 
            this.ddlParentType.Location = new System.Drawing.Point(98, 92);
            this.ddlParentType.Name = "ddlParentType";
            this.ddlParentType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ddlParentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlParentType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Name6")});
            this.ddlParentType.Properties.DisplayMember = "Text";
            this.ddlParentType.Properties.NullText = "Оберіть тип підпорядкування";
            this.ddlParentType.Properties.ShowFooter = false;
            this.ddlParentType.Properties.ShowHeader = false;
            this.ddlParentType.Properties.ValueMember = "Value";
            this.ddlParentType.Size = new System.Drawing.Size(266, 20);
            this.ddlParentType.StyleController = this.layoutMain;
            this.ddlParentType.TabIndex = 6;
            this.ddlParentType.EditValueChanged += new System.EventHandler(this.ddlParentType_EditValueChanged);
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(90, 36);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(282, 20);
            this.txtUnitName.StyleController = this.layoutMain;
            this.txtUnitName.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Вкажіть назву територіальної одиниці";
            this.validationProvider.SetValidationRule(this.txtUnitName, conditionValidationRule1);
            // 
            // ddlUnitType
            // 
            this.ddlUnitType.Location = new System.Drawing.Point(90, 12);
            this.ddlUnitType.Name = "ddlUnitType";
            this.ddlUnitType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlUnitType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Населений пункт")});
            this.ddlUnitType.Properties.DisplayMember = "Text";
            this.ddlUnitType.Properties.NullText = "Оберіть тип";
            this.ddlUnitType.Properties.ShowFooter = false;
            this.ddlUnitType.Properties.ShowHeader = false;
            this.ddlUnitType.Properties.ValueMember = "Value";
            this.ddlUnitType.Size = new System.Drawing.Size(282, 20);
            this.ddlUnitType.StyleController = this.layoutMain;
            this.ddlUnitType.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Виберіть тип територіальної одиниці";
            this.validationProvider.SetValidationRule(this.ddlUnitType, conditionValidationRule2);
            this.ddlUnitType.EditValueChanged += new System.EventHandler(this.ddlUnitType_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 10;
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 156);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ddlUnitType;
            this.layoutControlItem1.CustomizationFormText = "Тип одиниці";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Тип одиниці";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUnitName;
            this.layoutControlItem2.CustomizationFormText = "Назва";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem2.Text = "Назва";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Підпорядкування";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 2;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup2.Size = new System.Drawing.Size(364, 88);
            this.layoutControlGroup2.Text = "Підпорядкування";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ddlParentType;
            this.layoutControlItem3.CustomizationFormText = "Тип";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem3.Text = "Тип";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ddlParentUnit;
            this.layoutControlItem4.CustomizationFormText = "Тер. одиниця";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(348, 24);
            this.layoutControlItem4.Text = "Тер. одиниця";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // frmTerritorialUnitEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 192);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmTerritorialUnitEdit";
            this.Text = "Редагування територіальної одиниці";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlParentUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlParentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUnitType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtUnitName;
        private DevExpress.XtraEditors.LookUpEdit ddlUnitType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit ddlParentType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit ddlParentUnit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
