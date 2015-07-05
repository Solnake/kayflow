using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class ActListSetting : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ActListSettingID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        public Guid? EmployeeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(2048)]
        [DBFieldInfo(IsName = true)]
        public string Fields { get; set; }

        public List<ActListSettingItem> DisplayFields
        {
            get
            {
                var list =
                    (from x in
                        typeof (Act).GetMembers(BindingFlags.Instance | BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly)
                        let m = Attribute.GetCustomAttribute(x, typeof (CustomizeInfo)) as CustomizeInfo
                        where m != null
                        select new ActListSettingItem
                        {
                            FieldName = x.Name,
                            DisplayName = m.DisplayName
                        }).ToList();
                if (!string.IsNullOrEmpty(Fields))
                {
                    Fields.Split(',').ToList().ForEach(delegate(string field)
                    {
                        var item = list.Find(s => s.FieldName.Equals(field));
                        item.Show = true;
                    });
                }

                return list;
            }
            set { Fields = string.Join(",", value.FindAll(s => s.Show).Select(s => s.FieldName)); }
        }

        public ActListSetting()
        {

        }
    }

    public class ActListSettingItem
    {
        public string FieldName { get; set; }

        public string DisplayName { get; set; }

        public bool Show { get; set; }
    }
}