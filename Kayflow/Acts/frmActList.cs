using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow.Acts
{
    public partial class frmActList : BaseListForm
    {

        #region -= Properties =-
        protected override GridControl Grid
        {
            get
            {
                return gridList;
            }
        }

        protected override GridView View
        {
            get
            {
                return viewActs;
            }
        }

        #endregion

        public frmActList()
        {
            InitializeComponent();
            ViewLayoutType = eLayoutType.Act;
        }

        protected override void BaseListForm_Load(object sender, EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            foreach (var item in Factory.Manager<PaymentDataSettingsManager>().GetByOffice(CurrentInfo.OfficeID))
            {
                var column = viewActs.Columns[item.PaymentFieldID.ToString()];
                if (!item.Show)
                {
                    column.VisibleIndex = -1;
                }
                else
                {
                    if (column.VisibleIndex == -1)
                    {
                        column.VisibleIndex =
                            viewActs.Columns.Cast<GridColumn>().Count(c => c.VisibleIndex != -1);
                    }
                }
            }
            menuGrid.Items.Add(menuItemAddNote);
            menuGrid.Items.Add(menuItemSteps);
            //menuGrid.Items.Add(itemAddStatus);
            itemAddStatus.Click += itemAddStatus_Click;
            RefreshHelper = new GridCointrolState(new[]
                {
                    new GridCointrolState.ViewDescriptor("", "ID"),
                    new GridCointrolState.ViewDescriptor("Steps", "ID"),
                    new GridCointrolState.ViewDescriptor("Documents", "ID"),
                    new GridCointrolState.ViewDescriptor("StatusHistory", "ID"),
                    new GridCointrolState.ViewDescriptor("Notes", "ID")
                });
            viewActs.OptionsMenu.EnableColumnMenu = CurrentInfo.Permission == ePermissions.Admin;
            viewActs.OptionsMenu.EnableFooterMenu = CurrentInfo.Permission == ePermissions.Admin;
            viewActs.OptionsMenu.EnableGroupPanelMenu = CurrentInfo.Permission == ePermissions.Admin;
            viewActs.OptionsCustomization.AllowColumnMoving = CurrentInfo.Permission == ePermissions.Admin;
            viewActs.OptionsCustomization.AllowGroup = CurrentInfo.Permission == ePermissions.Admin;
        }

        protected override void BaseListForm_Shown(object sender, EventArgs e)
        {
            base.BaseListForm_Shown(sender, e);
            viewActs.ExpandAllGroups();
        }

        protected override void BindData()
        {
            var manager = Factory.Manager<ActManager>();
            manager.Filter.AddCondition("IsClosed", eOperationType.Equal, false);
            gridList.DataSource =
                manager.GetByOffice(CurrentInfo.OfficeID);
        }

        #region -= Buttons =-
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmActEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmActEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(Resources.confirmDelete,
                            Application.ProductName,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes) return;

            var handle = View.FocusedRowHandle;
               try
                {
                    Factory.Manager<ActManager>().Delete(GetFocusedValue());
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                    MessageBox.Show(Resources.relaterDeleteError,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            RefreshGrid();
            if (handle > 0)
                handle--;
            View.FocusedRowHandle = handle;
        }

        private void btnAddNote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmNoteEdit
            {
                ActID = GetFocusedValue(),
                CurrentInfo = CurrentInfo
            };
            form.SaveComplited += SaveNoteComplited;
            form.ShowDialog(this);
        }

        private void btnEditSteps_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmStepsEdit
            {
                DocID = GetFocusedValue(),
                CurrentInfo = CurrentInfo
            };
            form.SaveComplited += SaveStepComplited;
            form.ShowDialog(this);
        }

        private void btnAddStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new frmStateHistoryEdit
            {
                ActID = GetFocusedValue(),
                CurrentInfo = CurrentInfo
            };
            form.SaveComplited += SaveStateHistoryComplited;
            form.ShowDialog(this);
        }

        #endregion

        #region -= Master-Detail =-
        private void viewActs_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = gridList.LevelTree.Nodes.Count;
        }

        private void viewActs_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            var actID = GetGridValue(viewActs, e.RowHandle);
            switch (gridList.LevelTree.Nodes[e.RelationIndex].RelationName)
            {
                case "Steps":
                    e.ChildList = Factory.Manager<StepManager>().GetForAct(actID);
                    break;
                case "Documents":
                    e.ChildList = Factory.Manager<ActDocumentManager>().GetForActAll(actID, CurrentInfo.OfficeID);
                    break;
                case "Status":
                    e.ChildList =
                        Factory.Manager<StateHistoryManager>().GetForAct(actID).FindAll(
                            s => !string.IsNullOrEmpty(s.Description));
                    break;
                case "Notes":
                    e.ChildList = Factory.Manager<NoteManager>().GetForAct(actID);
                    break;
                case "History":
                    e.ChildList = Factory.Manager<ActHistoryManager>().GetForAct(actID);
                    break;
            }
        }

        private void viewActs_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = gridList.LevelTree.Nodes[e.RelationIndex].RelationName;
        }

        private void viewActs_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            switch (gridList.LevelTree.Nodes[e.RelationIndex].RelationName)
            {
                case "Steps":
                    e.RelationName = "Проходження справи";
                    break;
                case "Documents":
                    e.RelationName = "Документи";
                    break;
                case "Status":
                    e.RelationName = "Стан справи";
                    break;
                case "Notes":
                    e.RelationName = "Причини затримки";
                    break;
                case "History":
                    e.RelationName = "Історія акту";
                    break;
            }
        }

        #endregion

        #region -= Views =-

        protected override void ViewOnDoubleClick(object sender, EventArgs eventArgs)
        {
            if (btnEditSteps.Enabled)
                btnEditSteps_ItemClick(sender, null);
        }

        protected override void view_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.view_FocusedRowChanged(sender, e);
            btnAddNote.Enabled = btnEdit.Enabled;
            menuItemAddNote.Enabled = btnAddNote.Enabled;
            btnEditSteps.Enabled = btnEdit.Enabled;
            menuItemSteps.Enabled = btnEditSteps.Enabled;
            btnAddStatus.Enabled = btnEditSteps.Enabled;
            itemAddStatus.Enabled = btnAddStatus.Enabled;
        }

        private void viewActs_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var model = (view.GetRow(e.RowHandle) as Act);
                if (model != null && model.AlertColor.HasValue)
                {
                    e.Appearance.BackColor = Color.FromArgb(model.AlertColor.Value);
                }
            }
        }

        private void viewActDocuments_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var model = (view.GetRow(e.RowHandle) as ActDocument);
                if (model != null && model.DocColor.HasValue)
                {
                    e.Appearance.BackColor = Color.FromArgb(model.DocColor.Value);
                }
            }
        }

        private void viewSteps_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var model = (view.GetRow(e.RowHandle) as Step);
                if (model != null && model.AlertColor.HasValue && model.AlertDays.HasValue && model.AlertDays.Value > 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(model.AlertColor.Value);
                }
            }
        }

        private void viewNotes_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    menuNotes.Show(view.GridControl, e.Point);
                }
            }
        }

        private void viewNotes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            menuItemDeleteNote.Enabled = CurrentInfo.Permission == ePermissions.Admin;
        }

        private void viewStatusHistory_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    menuHistory.Show(view.GridControl, e.Point);
                }
            }
        }

        private void viewStatusHistory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            menuItemDeleteHistory.Enabled = CurrentInfo.Permission == ePermissions.Admin;
        }

        #endregion

        private void SaveNoteComplited(object sender, EventArgs e)
        {
            var dialog = sender as frmNoteEdit;
            if (dialog != null)
            {
                RefreshGrid();
                viewActs.ExpandMasterRow(viewActs.FocusedRowHandle, "Notes");
            }
        }

        private void SaveStateHistoryComplited(object sender, EventArgs e)
        {
            var dialog = sender as frmStateHistoryEdit;
            if (dialog != null)
            {
                RefreshGrid();
                viewActs.ExpandMasterRow(viewActs.FocusedRowHandle, "History");
            }
        }

        private void SaveStepComplited(object sender, EventArgs e)
        {
            var dialog = sender as frmStepsEdit;
            if (dialog != null)
            {
                RefreshGrid();
                viewActs.ExpandMasterRow(viewActs.FocusedRowHandle, "Steps");
            }
        }

        #region -= Menus =-

        protected override void menuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            base.menuGrid_ItemClicked(sender, e);
            switch (e.ClickedItem.Name)
            {
                case "menuItemAddNote":
                    btnAddNote_ItemClick(sender, null);
                    break;
                case "menuItemSteps":
                    btnEditSteps_ItemClick(sender, null);
                    break;
            }
        }

        private void menuNotes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "menuItemDeleteNote":
                    if (MessageBox.Show(Resources.confirmDelete,
                            Application.ProductName,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes) return;

                    var view = gridList.FocusedView as GridView;
                    if (view != null)
                    {
                        try
                        {
                            Factory.Manager<NoteManager>().Delete(GetGridValue(view, view.FocusedRowHandle));
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.IndexOf("FK") != -1)
                            {
                                MessageBox.Show(Resources.relaterDeleteError,
                                                Application.ProductName,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                return;
                            }
                            throw;
                        }

                        RefreshGrid();
                    }
                    break;
            }
        }

        private void menuItemDeleteHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.confirmDelete,
                            Application.ProductName,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes) return;

            var view = gridList.FocusedView as GridView;
            if (view != null)
            {
                try
                {
                    Factory.Manager<StateHistoryManager>().Delete(GetGridValue(view, view.FocusedRowHandle));
                }
                catch (Exception ex)
                {
                    if (ex.Message.IndexOf("FK") != -1)
                    {
                        MessageBox.Show(Resources.relaterDeleteError,
                                        Application.ProductName,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    throw;
                }

                RefreshGrid();
            }
        }

        private void itemAddStatus_Click(object sender, EventArgs e)
        {
            btnAddStatus_ItemClick(sender, null);
        }

        #endregion

        
    }
}
