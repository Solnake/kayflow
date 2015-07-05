using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;

namespace Kayflow
{
    public class CustomFocusHelper
    {
        public LayoutControl Layout { get; private set; }

        public CustomFocusHelper(LayoutControl pControl)
        {
            Layout = pControl;
        }

        public void FocusFirstEditableControl()
        {
            var walker = new LayoutControlWalker(Layout.Root);
            var itemsByFocus = walker.ArrangeElements(new OptionsFocus(MoveFocusDirection.AcrossThenDown, true));
            foreach (BaseLayoutItem item in itemsByFocus)
            {
                var controlItem = item as LayoutControlItem;
                if (controlItem==null || IsReadOnly(controlItem.Control))
                    continue;
                Layout.FocusHelper.FocusElement(item, false);
                return;
            }
        }

        private bool IsReadOnly(Control pControl)
        {
            var edit = pControl as BaseEdit;
            return edit == null || edit.Properties.ReadOnly || !edit.Enabled;
        }
    }
}
