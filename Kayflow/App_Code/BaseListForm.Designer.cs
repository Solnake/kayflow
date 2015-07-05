namespace Kayflow
{
    partial class BaseListForm
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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.pageListName = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupEditAction = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.toolboxManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barList = new DevExpress.XtraBars.Bar();
            this.barAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.menuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolboxManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageListName});
            this.ribbon.Size = new System.Drawing.Size(442, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Додати";
            this.btnAdd.Glyph = global::Kayflow.Properties.Resources.Add;
            this.btnAdd.GlyphDisabled = global::Kayflow.Properties.Resources.Add_dis;
            this.btnAdd.Id = 1;
            this.btnAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Insert);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Редагувати";
            this.btnEdit.Enabled = false;
            this.btnEdit.Glyph = global::Kayflow.Properties.Resources.Edit;
            this.btnEdit.GlyphDisabled = global::Kayflow.Properties.Resources.Edit_dis;
            this.btnEdit.Id = 2;
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Видалити";
            this.btnDelete.Enabled = false;
            this.btnDelete.Glyph = global::Kayflow.Properties.Resources.Delete;
            this.btnDelete.GlyphDisabled = global::Kayflow.Properties.Resources.Delete_dis;
            this.btnDelete.Id = 3;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Обновити";
            this.btnRefresh.Glyph = global::Kayflow.Properties.Resources.Refresh;
            this.btnRefresh.GlyphDisabled = global::Kayflow.Properties.Resources.Refresh_dis;
            this.btnRefresh.Id = 4;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // pageListName
            // 
            this.pageListName.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupEditAction});
            this.pageListName.Name = "pageListName";
            // 
            // groupEditAction
            // 
            this.groupEditAction.ItemLinks.Add(this.btnAdd);
            this.groupEditAction.ItemLinks.Add(this.btnEdit);
            this.groupEditAction.ItemLinks.Add(this.btnDelete);
            this.groupEditAction.ItemLinks.Add(this.btnRefresh);
            this.groupEditAction.Name = "groupEditAction";
            this.groupEditAction.Text = "Редагування";
            this.groupEditAction.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 395);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 31);
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAdd,
            this.menuItemEdit,
            this.menuItemDelete,
            this.toolStripSeparator1,
            this.menuItemRefresh});
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.Size = new System.Drawing.Size(175, 98);
            this.menuGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuGrid_ItemClicked);
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Image = global::Kayflow.Properties.Resources.Add;
            this.menuItemAdd.Name = "menuItemAdd";
            this.menuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.menuItemAdd.Size = new System.Drawing.Size(174, 22);
            this.menuItemAdd.Text = "Додати";
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Enabled = false;
            this.menuItemEdit.Image = global::Kayflow.Properties.Resources.Edit;
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuItemEdit.Size = new System.Drawing.Size(174, 22);
            this.menuItemEdit.Text = "Редагувати";
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Enabled = false;
            this.menuItemDelete.Image = global::Kayflow.Properties.Resources.Delete;
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuItemDelete.Size = new System.Drawing.Size(174, 22);
            this.menuItemDelete.Text = "Видалити";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Image = global::Kayflow.Properties.Resources.Refresh;
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuItemRefresh.Size = new System.Drawing.Size(174, 22);
            this.menuItemRefresh.Text = "Обновити";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 144);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(442, 25);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // toolboxManager
            // 
            this.toolboxManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barList,
            this.bar3});
            this.toolboxManager.DockControls.Add(this.barDockControlTop);
            this.toolboxManager.DockControls.Add(this.barDockControlBottom);
            this.toolboxManager.DockControls.Add(this.barDockControlLeft);
            this.toolboxManager.DockControls.Add(this.barDockControlRight);
            this.toolboxManager.DockControls.Add(this.standaloneBarDockControl1);
            this.toolboxManager.Form = this;
            this.toolboxManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barAdd,
            this.barEdit,
            this.barDelete,
            this.barRefresh});
            this.toolboxManager.MainMenu = this.barList;
            this.toolboxManager.MaxItemId = 4;
            this.toolboxManager.StatusBar = this.bar3;
            // 
            // barList
            // 
            this.barList.BarName = "Main menu";
            this.barList.DockCol = 0;
            this.barList.DockRow = 0;
            this.barList.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barList.FloatLocation = new System.Drawing.Point(88, 273);
            this.barList.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barRefresh)});
            this.barList.OptionsBar.MultiLine = true;
            this.barList.OptionsBar.UseWholeRow = true;
            this.barList.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.barList.Text = "Main menu";
            // 
            // barAdd
            // 
            this.barAdd.Caption = "Додати";
            this.barAdd.Glyph = global::Kayflow.Properties.Resources.Add_16;
            this.barAdd.Hint = "Додати";
            this.barAdd.Id = 0;
            this.barAdd.Name = "barAdd";
            this.barAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // barEdit
            // 
            this.barEdit.Caption = "Редагувати";
            this.barEdit.Glyph = global::Kayflow.Properties.Resources.Edit_16;
            this.barEdit.Hint = "Редагувати";
            this.barEdit.Id = 1;
            this.barEdit.Name = "barEdit";
            this.barEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // barDelete
            // 
            this.barDelete.Caption = "Видалити";
            this.barDelete.Glyph = global::Kayflow.Properties.Resources.Delete_16;
            this.barDelete.Hint = "Видалити";
            this.barDelete.Id = 2;
            this.barDelete.Name = "barDelete";
            this.barDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // barRefresh
            // 
            this.barRefresh.Caption = "Обновити";
            this.barRefresh.Glyph = global::Kayflow.Properties.Resources.Refresh_16;
            this.barRefresh.Hint = "Обновити";
            this.barRefresh.Id = 3;
            this.barRefresh.Name = "barRefresh";
            this.barRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(442, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 426);
            this.barDockControlBottom.Size = new System.Drawing.Size(442, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 426);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(442, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 426);
            // 
            // BaseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "BaseListForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "BaseListForm";
            this.Activated += new System.EventHandler(this.BaseListForm_Activated);
            this.Deactivate += new System.EventHandler(this.BaseListForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseListForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseListForm_Load);
            this.Shown += new System.EventHandler(this.BaseListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.menuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolboxManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.Ribbon.RibbonPage pageListName;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupEditAction;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraBars.BarButtonItem btnAdd;
        protected DevExpress.XtraBars.BarButtonItem btnEdit;
        protected DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected System.Windows.Forms.ContextMenuStrip menuGrid;
        protected System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        protected System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        protected System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        protected System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.Bar barList;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barAdd;
        protected DevExpress.XtraBars.BarManager toolboxManager;
        private DevExpress.XtraBars.BarButtonItem barEdit;
        private DevExpress.XtraBars.BarButtonItem barDelete;
        private DevExpress.XtraBars.BarButtonItem barRefresh;
    }
}