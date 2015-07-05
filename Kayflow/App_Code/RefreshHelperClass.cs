using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpress.XtraGrid.Helpers
{

    public class GridCointrolState
    {

        public struct RowInfo
        {
            public object Id;
            public int level;
        }

        public struct ViewDescriptor
        {
            public string relationName;
            public string keyFieldName;

            public ViewDescriptor(string relationName, string keyFieldName)
            {
                this.relationName = relationName;
                this.keyFieldName = keyFieldName;
            }
        }

        public class ViewState
        {
            private int focusedRowHandle;
            private GridCointrolState gridState;
            private ViewState parent;
            private ViewDescriptor descriptor;
            private ArrayList saveExpList;
            private ArrayList saveSelList;
            private ArrayList saveMasterRowsList;
            private int visibleRowIndex = -1;
            private Hashtable detailViews;

            protected ViewState(GridCointrolState gridState, ViewDescriptor descriptor)
            {
                this.gridState = gridState;
                this.descriptor = descriptor;
                this.parent = null;
            }

            protected ViewState(ViewState parent, ViewDescriptor descriptor)
            {
                this.parent = parent;
                this.gridState = parent.gridState;
                this.descriptor = descriptor;
            }

            public static ViewState Create(GridCointrolState gridState, GridView view)
            {
                if (!gridState.viewDescriptors.ContainsKey(view.LevelName)) return null;
                ViewState state = new ViewState(gridState, (ViewDescriptor)gridState.viewDescriptors[view.LevelName]);
                return state;
            }

            private static ViewState Create(ViewState parent, GridView view)
            {
                if (!parent.gridState.viewDescriptors.ContainsKey(view.LevelName)) return null;
                ViewState state = new ViewState(parent, (ViewDescriptor)parent.gridState.viewDescriptors[view.LevelName]);
                return state;
            }

            public bool IsLevel(string level)
            {
                return level == this.descriptor.relationName;
            }

            public ArrayList SaveExpList
            {
                get
                {
                    if (saveExpList == null)
                        saveExpList = new ArrayList();
                    return saveExpList;
                }
            }

            public ArrayList SaveSelList
            {
                get
                {
                    if (saveSelList == null)
                        saveSelList = new ArrayList();
                    return saveSelList;
                }
            }

            public ArrayList SaveMasterRowsList
            {
                get
                {
                    if (saveMasterRowsList == null)
                        saveMasterRowsList = new ArrayList();
                    return saveMasterRowsList;
                }
            }

            public Hashtable DetailViews
            {
                get
                {
                    if (detailViews == null)
                        detailViews = new Hashtable();
                    return detailViews;
                }
            }

            protected int FindParentRowHandle(GridView view, RowInfo rowInfo, int rowHandle)
            {
                int result = view.GetParentRowHandle(rowHandle);
                while (view.GetRowLevel(result) != rowInfo.level)
                    result = view.GetParentRowHandle(result);
                return result;
            }

            protected void ExpandRowByRowInfo(GridView view, RowInfo rowInfo)
            {
                int dataRowHandle = view.LocateByValue(0, view.Columns[descriptor.keyFieldName], rowInfo.Id);
                if (dataRowHandle != GridControl.InvalidRowHandle)
                {
                    int parentRowHandle = FindParentRowHandle(view, rowInfo, dataRowHandle);
                    view.SetRowExpanded(parentRowHandle, true, false);
                }
            }

            protected int GetRowHandleToSelect(GridView view, RowInfo rowInfo)
            {
                int dataRowHandle = view.LocateByValue(0, view.Columns[descriptor.keyFieldName], rowInfo.Id);
                if (dataRowHandle != GridControl.InvalidRowHandle)
                    if (view.GetRowLevel(dataRowHandle) != rowInfo.level)
                        return FindParentRowHandle(view, rowInfo, dataRowHandle);
                return dataRowHandle;
            }

            protected void SelectRowByRowInfo(GridView view, RowInfo rowInfo, bool isFocused)
            {
                if (isFocused)
                    view.FocusedRowHandle = GetRowHandleToSelect(view, rowInfo);
                else
                    view.SelectRow(GetRowHandleToSelect(view, rowInfo));
            }

            public void SaveSelectionViewInfo(GridView view)
            {
                SaveSelList.Clear();
                GridColumn column = view.Columns[descriptor.keyFieldName];
                RowInfo rowInfo;
                int[] selectionArray = view.GetSelectedRows();
                if (selectionArray != null)  // otherwise we have a single focused but not selected row
                    for (int i = 0; i < selectionArray.Length; i++)
                    {
                        int dataRowHandle = selectionArray[i];
                        rowInfo.level = view.GetRowLevel(dataRowHandle);
                        if (dataRowHandle < 0) // group row
                            dataRowHandle = view.GetDataRowHandleByGroupRowHandle(dataRowHandle);
                        rowInfo.Id = view.GetRowCellValue(dataRowHandle, column);
                        SaveSelList.Add(rowInfo);
                    }
                rowInfo.Id = view.GetRowCellValue(view.FocusedRowHandle, column);
                rowInfo.level = view.GetRowLevel(view.FocusedRowHandle);
                SaveSelList.Add(rowInfo);
            }

            public void SaveExpansionViewInfo(GridView view)
            {
                if (view.GroupedColumns.Count == 0) return;
                SaveExpList.Clear();
                GridColumn column = view.Columns[descriptor.keyFieldName];
                for (int i = -1; i > int.MinValue; i--)
                {
                    if (!view.IsValidRowHandle(i)) break;
                    if (view.GetRowExpanded(i))
                    {
                        RowInfo rowInfo;
                        int dataRowHandle = view.GetDataRowHandleByGroupRowHandle(i);
                        rowInfo.Id = view.GetRowCellValue(dataRowHandle, column);
                        rowInfo.level = view.GetRowLevel(i);
                        SaveExpList.Add(rowInfo);
                    }
                }
            }

            public void SaveExpandedMasterRows(GridView view)
            {
                if (view.GridControl.Views.Count == 1) return;
                SaveMasterRowsList.Clear();
                GridColumn column = view.Columns[descriptor.keyFieldName];
                for (int i = 0; i < view.DataRowCount; i++)
                    if (view.GetMasterRowExpanded(i))
                    {
                        object key = view.GetRowCellValue(i, column);
                        SaveMasterRowsList.Add(key);
                        GridView detail = view.GetVisibleDetailView(i) as GridView;
                        if (detail != null)
                        {
                            ViewState state = ViewState.Create(this, detail);
                            if (state != null)
                            {
                                DetailViews.Add(key, state);
                                state.SaveState(detail);
                            }
                        }
                    }
            }

            private void SaveFocusedRowHandle(GridView view) {
                focusedRowHandle = view.FocusedRowHandle;
            }
            public void SaveVisibleIndex(GridView view)
            {
                visibleRowIndex = view.GetVisibleIndex(view.FocusedRowHandle) - view.TopRowIndex;
            }

            public void LoadVisibleIndex(GridView view)
            {
                view.MakeRowVisible(view.FocusedRowHandle, true);
                view.TopRowIndex = view.GetVisibleIndex(view.FocusedRowHandle) - visibleRowIndex;
            }

            public void LoadSelectionViewInfo(GridView view)
            {
                view.BeginSelection();
                try
                {
                    view.ClearSelection();
                    for (int i = 0; i < SaveSelList.Count; i++)
                        SelectRowByRowInfo(view, (RowInfo)SaveSelList[i], i == SaveSelList.Count - 1);
                }
                finally
                {
                    view.EndSelection();
                }
            }

            public void LoadExpansionViewInfo(GridView view)
            {
                if (view.GroupedColumns.Count == 0) return;
                view.BeginUpdate();
                try
                {
                    view.CollapseAllGroups();
                    foreach (RowInfo info in SaveExpList)
                        ExpandRowByRowInfo(view, info);
                }
                finally
                {
                    view.EndUpdate();
                }
            }

            public void LoadExpandedMasterRows(GridView view)
            {
                view.BeginUpdate();
                try
                {
                    view.CollapseAllDetails();
                    GridColumn column = view.Columns[descriptor.keyFieldName];
                    for (int i = 0; i < SaveMasterRowsList.Count; i++)
                    {
                        int rowHandle = view.LocateByValue(0, column, SaveMasterRowsList[i]);
                        ViewState state = (ViewState)DetailViews[SaveMasterRowsList[i]];
                        if (state == null)
                        {
                            view.SetMasterRowExpanded(rowHandle, true);
                        }
                        else
                        {
                            view.SetMasterRowExpandedEx(rowHandle, view.GetRelationIndex(rowHandle, state.descriptor.relationName), true);
                            GridView detail = view.GetVisibleDetailView(rowHandle) as GridView;
                            if (detail != null)
                            {
                                state.LoadState(detail);
                            }
                        }
                    }
                }
                finally
                {
                    view.EndUpdate();
                }
            }

            private void LoadFocusedRowHandle(GridView view) {
                view.FocusedRowHandle = focusedRowHandle;
            }
            public void SaveState(GridView view)
            {                
                SaveExpandedMasterRows(view);
                SaveExpansionViewInfo(view);
                SaveFocusedRowHandle(view);
                SaveSelectionViewInfo(view);
                SaveVisibleIndex(view);
            }

            public void LoadState(GridView view)
            {
                LoadExpandedMasterRows(view);
                LoadExpansionViewInfo(view);
                LoadFocusedRowHandle(view);
                LoadSelectionViewInfo(view);
                LoadVisibleIndex(view);
            }
        }

        private Hashtable viewDescriptors;
        private ViewState root;

        public GridCointrolState(ViewDescriptor[] views)
        {
            viewDescriptors = new Hashtable();
            foreach (ViewDescriptor desc in views)
            {
                viewDescriptors.Add(desc.relationName, desc);
            }
        }

        public void SaveViewInfo(GridView view)
        {
            root = ViewState.Create(this, view);
            root.SaveState(view);
        }

        public void LoadViewInfo(GridView view)
        {
            if (root == null || !root.IsLevel(view.LevelName)) return;
            root.LoadState(view);
        }

    }
}
