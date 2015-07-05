using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow
{
    public partial class BaseListForm : RibbonForm, IDefaultRibbonPage
    {
        protected static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ICurrentInfo CurrentInfo { get; set; }

        private bool _loaded;

        public BaseListForm()
        {
            InitializeComponent();
        }

        public RibbonPage DefaultPage { get { return pageListName; } }

        protected virtual GridControl Grid { get; private set; }
        protected virtual GridView View { get; private set; }
        protected eLayoutType? ViewLayoutType { get; set; }
        protected GridCointrolState RefreshHelper { get; set; }

        #region -= Form Events =-
        protected virtual void BaseListForm_Load(object sender, EventArgs e)
        {
            if (View != null)
            {
                View.FocusedRowChanged += view_FocusedRowChanged;
                View.DoubleClick += ViewOnDoubleClick;
                View.PopupMenuShowing += ViewOnPopupMenuShowing;
                if (ViewLayoutType.HasValue)
                {
                    try
                    {
                        var layout = Factory.Manager<LayoutManager>().Get(CurrentInfo.OfficeID, ViewLayoutType.Value);
                        if (layout != null && layout.LayoutData.Length > 0)
                        {
                            View.RestoreLayoutFromStream(new MemoryStream(layout.LayoutData));
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.Message, exception);
                        MessageBox.Show(Resources.errorLoadLayout,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            BindData();
            _loaded = true;
        }

        protected virtual void BaseListForm_Shown(object sender, EventArgs e)
        {

        }

        private void BaseListForm_Activated(object sender, EventArgs e)
        {
            if (!_loaded && View != null)
                RefreshGrid();
        }

        private void BaseListForm_Deactivate(object sender, EventArgs e)
        {
            _loaded = false;
        }

        private void BaseListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (View != null && ViewLayoutType.HasValue)
            {
                var manager = Factory.Manager<LayoutManager>();
                var model = manager.Get(CurrentInfo.OfficeID, ViewLayoutType.Value) ?? new Layout
                {
                    LayoutType = ViewLayoutType.Value,
                    OfficeID = CurrentInfo.OfficeID
                };
                var stream = new MemoryStream();
                View.SaveLayoutToStream(stream);
                model.LayoutData = stream.GetBuffer();
                manager.Model = model;
                manager.Save();
            }
        }
        #endregion

        #region -= View  Events =-
        private void ViewOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    menuGrid.Show(view.GridControl, e.Point);
                }
            }
        }

        protected virtual void ViewOnDoubleClick(object sender, EventArgs eventArgs)
        {
            if (btnEdit.Enabled)
                btnEdit_ItemClick(sender, null);
        }

        protected virtual void view_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (View != null)
            {
                btnEdit.Enabled = e.FocusedRowHandle != -1;
                btnDelete.Enabled = btnEdit.Enabled;
                menuItemEdit.Enabled = btnEdit.Enabled;
                menuItemDelete.Enabled = btnEdit.Enabled;
                barEdit.Enabled = btnEdit.Enabled;
                barDelete.Enabled = btnEdit.Enabled;
            }
        }
        #endregion

        #region -= Buttons =-
        protected virtual void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        public void ReloadData()
        {
            _loaded = true;
            BindData();
        }

        protected virtual void BindData()
        {

        }

        protected void RefreshGrid()
        {
            ReloadWithLocate(Guid.Empty);
        }

        protected virtual void ReloadWithLocate(Guid pID)
        {
            if (Grid == null || View == null)
                return;
            var handle = View.FocusedRowHandle;
            if (RefreshHelper != null)
                RefreshHelper.SaveViewInfo(View);
            BindData();
            Grid.ForceInitialize();
            if (RefreshHelper != null)
                RefreshHelper.LoadViewInfo(View);
            View.FocusedRowHandle = pID == Guid.Empty ? handle : View.LocateByValue("ID", pID);
        }

        protected virtual Guid GetFocusedValue()
        {
            return GetFocusedGridValue(View);
        }

        private Guid GetFocusedGridValue(GridView pView)
        {
            return GetGridValue(pView, pView.FocusedRowHandle);
        }

        protected Guid GetGridValue(GridView pView, int pRowHandle)
        {
            var model = (pView.GetRow(pRowHandle) as ModelBaseSinglePK<Guid>);
            return model != null ? model.ID : Guid.Empty;
        }

        protected virtual void SaveComplited(object sender, EventArgs e)
        {
            var dialog = sender as BaseEditForm;
            if (dialog != null)
            {
                ReloadWithLocate(dialog.DocID);
            }
        }

        protected void ShowEditForm(BaseEditForm pForm, Guid pID)
        {
            pForm.DocID = pID;
            pForm.SaveComplited += SaveComplited;
            pForm.CurrentInfo = CurrentInfo;
            pForm.ShowDialog(this);
        }

        protected void ShowEditForm(BaseEditForm pForm)
        {
            ShowEditForm(pForm, Guid.Empty);
        }

        protected void DeleteHandler<M, TC, TM>()
            where M : KayflowManager<TC, TM>, new()
            where TC : ReadWriteControllerSinglePK<TM, Guid>, new()
            where TM : BaseModel, new()
        {
            if (MessageBox.Show(Resources.confirmDelete,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var handle = View.FocusedRowHandle;
            try
            {
                Factory.Manager<M>().Delete(GetFocusedValue());
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
            BindData();
            if (handle > 0)
                View.FocusedRowHandle = handle - 1;
        }


        protected virtual void menuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "menuItemAdd":
                    btnAdd_ItemClick(sender, null);
                    break;
                case "menuItemEdit":
                    btnEdit_ItemClick(sender, null);
                    break;
                case "menuItemDelete":
                    btnDelete_ItemClick(sender, null);
                    break;
                case "menuItemRefresh":
                    btnRefresh_ItemClick(sender, null);
                    break;
            }
        }
    }
}