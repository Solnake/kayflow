using System;
using System.Reflection;

namespace Kayflow.Manager
{
    public static class NullableHelper
    {
        public static void NullableToNull(this object item)
        {
            var booltype = typeof(bool);
            var stringtype = typeof(string);
            var datetimetype = typeof(DateTime);
            foreach (var member in item.GetType().GetMembers())
            {
                Type utype;
                object value;
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        var mpi = member as PropertyInfo;
                        if (mpi==null)
                            continue;
                        if (mpi.PropertyType == stringtype && mpi.CanWrite)
                        {
                            value = mpi.GetValue(item, new Object[0]);
                            if (value != null && value.Equals(string.Empty))
                                mpi.SetValue(item, null, new Object[0]);
                        }
                        else
                        {
                            utype = Nullable.GetUnderlyingType(mpi.PropertyType);
                            if (utype != null && utype.IsValueType && !utype.IsEnum && utype.IsPrimitive && utype != booltype && mpi.CanWrite)
                            {
                                value = mpi.GetValue(item, new Object[0]);
                                if (value != null && value.Equals(Convert.ChangeType(0, utype)))
                                    mpi.SetValue(item, null, new Object[0]);
                            }
                            else
                                if (utype == datetimetype && mpi.CanWrite)
                                {
                                    value = mpi.GetValue(item, new Object[0]);
                                    if (value != null && value.Equals(DateTime.MinValue))
                                        mpi.SetValue(item, null, new Object[0]);
                                }

                        }
                        break;
                    case MemberTypes.Field:
                        var mfi = member as FieldInfo;
                        if (mfi==null)
                            continue;
                        if (mfi.FieldType == stringtype)
                        {
                            value = mfi.GetValue(item);
                            if (value != null && value.Equals(string.Empty))
                                mfi.SetValue(item, null);
                        }
                        else
                        {
                            utype = Nullable.GetUnderlyingType(mfi.FieldType);
                            if (utype != null && utype.IsValueType && !utype.IsEnum && utype.IsPrimitive && utype != booltype)
                            {
                                value = mfi.GetValue(item);
                                if (value != null && value.Equals(Convert.ChangeType(0, utype)))
                                    mfi.SetValue(item, null);
                            }
                            else
                                if (utype == datetimetype)
                                {
                                    value = mfi.GetValue(item);
                                    if (value != null && value.Equals(DateTime.MinValue))
                                        mfi.SetValue(item, null);
                                }
                        }
                        break;
                }
            }
        }
    }

}
