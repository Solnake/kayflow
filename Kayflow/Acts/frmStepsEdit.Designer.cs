namespace Kayflow.Acts
{
    partial class frmStepsEdit
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
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtStateDescription = new DevExpress.XtraEditors.MemoEdit();
            this.ddlState = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutStateDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
            this.layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStateDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutStateDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.Controls.Add(this.txtDescription);
            this.layoutMain.Controls.Add(this.txtStateDescription);
            this.layoutMain.Controls.Add(this.ddlState);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(29, 147, 250, 350);
            this.layoutMain.Root = this.layoutControlGroup1;
            this.layoutMain.Size = new System.Drawing.Size(384, 230);
            this.layoutMain.TabIndex = 1;
            this.layoutMain.Text = "layoutControl2";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 153);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(364, 67);
            this.txtDescription.StyleController = this.layoutMain;
            this.txtDescription.TabIndex = 6;
            // 
            // txtStateDescription
            // 
            this.txtStateDescription.Location = new System.Drawing.Point(4, 43);
            this.txtStateDescription.Name = "txtStateDescription";
            this.txtStateDescription.Size = new System.Drawing.Size(376, 81);
            this.txtStateDescription.StyleController = this.layoutMain;
            this.txtStateDescription.TabIndex = 5;
            // 
            // ddlState
            // 
            this.ddlState.Location = new System.Drawing.Point(69, 4);
            this.ddlState.Name = "ddlState";
            this.ddlState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.ddlState.Properties.DisplayMember = "Name";
            this.ddlState.Properties.NullText = "Оберіть статус";
            this.ddlState.Properties.ShowFooter = false;
            this.ddlState.Properties.ShowHeader = false;
            this.ddlState.Properties.ValueMember = "ID";
            this.ddlState.Size = new System.Drawing.Size(311, 20);
            this.ddlState.StyleController = this.layoutMain;
            this.ddlState.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Оберіть поточний статус справи";
            this.validationProvider.SetValidationRule(this.ddlState, conditionValidationRule1);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutStateDescription,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 2;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 230);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ddlState;
            this.layoutControlItem1.CustomizationFormText = "Статус";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(380, 24);
            this.layoutControlItem1.Text = "Статус";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutStateDescription
            // 
            this.layoutStateDescription.Control = this.txtStateDescription;
            this.layoutStateDescription.CustomizationFormText = "Стан справи";
            this.layoutStateDescription.Location = new System.Drawing.Point(0, 24);
            this.layoutStateDescription.Name = "layoutStateDescription";
            this.layoutStateDescription.Size = new System.Drawing.Size(380, 100);
            this.layoutStateDescription.Text = "Стан справи";
            this.layoutStateDescription.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutStateDescription.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Причина затримки";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 124);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(380, 102);
            this.layoutControlGroup2.Text = "Причина затримки";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDescription;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(368, 71);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmStepsEdit
            // 
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.layoutMain);
            this.Name = "frmStepsEdit";
            this.Text = "Проходження справи";
            this.Controls.SetChildIndex(this.layoutMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.validationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
            this.layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStateDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutStateDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit txtStateDescription;
        private DevExpress.XtraEditors.LookUpEdit ddlState;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutStateDescription;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
