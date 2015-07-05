using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class Employee : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid EmployeeID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string MiddleName { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string Login { get; set; }

        [DBMaping]
        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        [DBMaping]
        [Required]
        public ePermissions Permission { get; set; }

        public string OfficeName { get; set; }

        [DBFieldInfo(IsName = true)]
        public string DisplayName { get; set; }

        public bool IsAdmin
        {
            get { return Permission.HasFlag(ePermissions.Admin); }
            set
            {
                if (value)
                {
                    if (!Permission.HasFlag(ePermissions.Admin))
                        Permission = Permission | ePermissions.Admin;
                }
                else
                    Permission &= ~ePermissions.Admin;
            }
        }

        public bool SuperAdmin
        {
            get { return Permission.HasFlag(ePermissions.SuperAdmin); }
            set
            {
                if (value)
                {
                    if (!Permission.HasFlag(ePermissions.SuperAdmin))
                        Permission = Permission | ePermissions.SuperAdmin;
                }
                else
                    Permission &= ~ePermissions.SuperAdmin;
            }
        }

        public bool IsBlocked
        {
            get { return Permission.HasFlag(ePermissions.Blocked); }
            set
            {
                if (value)
                {
                    if (!Permission.HasFlag(ePermissions.Blocked))
                        Permission = Permission | ePermissions.Blocked;
                }
                else
                    Permission &= ~ePermissions.Blocked;
            }
        }

        /// <summary>
        /// For Export/Import only
        /// </summary>
        public List<Expense> Expenses { get; set; }

        public Employee()
        {
            Permission = ePermissions.Employee;
        }
    }
}