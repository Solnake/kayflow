using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Framework.SqlDataAccess.Model;

namespace Kayflow.Model
{
    public class ActAction : BaseModel
    {
        [DBMaping(PrimaryKey = true, Identity = false, Output = true)]
        [Required]
        public Guid ActActionID { get; set; }

        [DBMaping]
        [Required]
        public Guid OfficeID { get; set; }

        [DBMaping]
        [Required]
        [StringLength(128)]
        [DBFieldInfo(IsName = true)]
        public string ActionName { get; set; }

        [DBMaping]
        [Required]
        public int OrdNum { get; set; }

        [DBMaping]
        [Required]
        public bool Hidden { get; set; }

        [DBMaping]
        public int? AlertDays { get; set; }

        [DBMaping]
        public int? RelativeAlertDays { get; set; }

        [DBMaping]
        public int? AlertColor { get; set; }

        public string OfficeName { get; set; }

        public string SysColor
        {
            get
            {
                if (AlertColor.HasValue)
                {
                    var color = Color.FromArgb(AlertColor.Value);
                    return string.Format("#{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"),
                        color.B.ToString("X2"));
                }
                return null;
            }
        }

        public bool Show
        {
            get
            {
                return !Hidden;
            }
            set
            {
                Hidden = !value;
            }
        }

    }
}