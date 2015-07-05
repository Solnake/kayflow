using System.Linq;
using System.Reflection;

namespace Kayflow.Reports
{
    public static class ObjectExt
    {
        public static T1 CopyFrom<T1, T2>(this T1 obj, T2 otherObject)
            where T1 : class
            where T2 : class
        {
            var srcFields = otherObject.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            var destFields = obj.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var property in srcFields)
            {
                var dest = destFields.FirstOrDefault(x => x.Name == property.Name);
                if (dest != null)
                    if (dest.CanWrite)
                        dest.SetValue(obj, property.GetValue(otherObject, null), null);
            }

            return obj;
        }
    }
}
