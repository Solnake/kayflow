using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kayflow
{
    public class FormFactory
    {
        static readonly Dictionary<Type, BaseListForm> _FormLookup = new Dictionary<Type, BaseListForm>();

        static public T GetForm<T>(BaseMainForm pOwner)
            where T : BaseListForm
        {
            if (!_FormLookup.ContainsKey(typeof(T)))
            {
                var form = (BaseListForm)Activator.CreateInstance(typeof(T));
                _FormLookup.Add(typeof(T), form);
                form.Owner = pOwner;
                form.FormClosed += Remove;
                form.MdiParent = pOwner;
                form.CurrentInfo = pOwner;
            }
            return (T)_FormLookup[typeof(T)];
        }

        static void Remove(object sender, FormClosedEventArgs e)
        {
            var form = sender as BaseListForm;
            if (form == null) return;

            form.FormClosed -= Remove;
            _FormLookup.Remove(form.GetType());
        }  
    }
}
