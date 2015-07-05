namespace Kayflow.Expenses
{
    partial class frmExpenseEdit
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutMain = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ddlEmployee = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtOnDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDistance = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.txtDistance);
            this.layoutMain.Controls.Add(this.txtOnDate);
            this.layoutMain.Controls.Add(this.ddlEmployee);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 93);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 93);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ddlEmployee
            // 
            this.ddlEmployee.Location = new System.Drawing.Point(107, 12);
            this.ddlEmployee.Name = "ddlEmployee";
            this.ddlEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlEmployee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "Name1")});
            this.ddlEmployee.Properties.DisplayMember = "DisplayName";
            this.ddlEmployee.Properties.NullText = "Оберіть землеупорядника";
            this.ddlEmployee.Properties.ShowFooter = false;
            this.ddlEmployee.Properties.ShowHeader = false;
            this.ddlEmployee.Properties.ValueMember = "ID";
            this.ddlEmployee.Size = new System.Drawing.Size(265, 20);
            this.ddlEmployee.StyleController = this.layoutMain;
            this.ddlEmployee.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Оберіть землеупорядника";
            this.validationProvider.SetValidationRule(this.ddlEmployee, conditionValidationRule2);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ddlEmployee;
            this.layoutControlItem1.CustomizationFormText = "Землеупорядник";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem1.Text = "Землеупорядник";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 13);
            // 
            // txtOnDate
            // 
            this.txtOnDate.EditValue = null;
            this.txtOnDate.Location = new System.Drawing.Point(107, 36);
            this.txtOnDate.Name = "txtOnDate";
            this.txtOnDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOnDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtOnDate.Size = new System.Drawing.Size(265, 20);
            this.txtOnDate.StyleController = this.layoutMain;
            this.txtOnDate.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Вкажіть дату";
            this.validationProvider.SetValidationRule(this.txtOnDate, conditionValidationRule1);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOnDate;
            this.layoutControlItem2.CustomizationFormText = "Дата";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 24);
            this.layoutControlItem2.Text = "Дата";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 13);
            // 
            // txtDistance
            // 
            this.txtDistance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDistance.Location = new System.Drawing.Point(107, 60);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDistance.Properties.IsFloatValue = false;
            this.txtDistance.Properties.Mask.EditMask = "d";
            this.txtDistance.Size = new System.Drawing.Size(265, 20);
            this.txtDistance.StyleController = this.layoutMain;
            this.txtDistance.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDistance;
            this.layoutControlItem3.CustomizationFormText = "Дистанція, км";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(364, 25);
            this.layoutControlItem3.Text = "Дистанція, км";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(85, 13);
            // 
            // frmExpenseEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 129);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmExpenseEdit";
            this.Text = "Реєстрація витрат";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit txtDistance;
        private DevExpress.XtraEditors.DateEdit txtOnDate;
        private DevExpress.XtraEditors.LookUpEdit ddlEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
