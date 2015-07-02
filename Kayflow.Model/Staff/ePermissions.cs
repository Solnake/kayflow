using System;
using System.ComponentModel;

namespace Kayflow.Model
{
    [Flags]
    public enum ePermissions
    {
        [Description("Адміністратор офісу")]
        Admin = 1,
        [Description("Працівник")]
        Employee = 2,
        [Description("Адміністратор системи")]
        SuperAdmin = 4,
        [Description("Заблокований")]
        Blocked = 8
    }
}
