using System.Collections;
using System.ComponentModel;
using Kayflow.Model;

namespace Kayflow.Reports
{
    public class DocumentCollection : ArrayList, ITypedList
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(ActDocument));
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Documents";
        }
    }
}
