using System;

namespace Kayflow.Model
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomizeInfo : Attribute
    {
        public bool Customizable { get; set; }

        public string DisplayName { get; set; }

        public CustomizeInfo()
        {
            Customizable = false;
        }
    }
}
