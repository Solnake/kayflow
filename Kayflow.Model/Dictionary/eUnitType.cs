using System.ComponentModel;

namespace Kayflow.Model
{
    public enum eUnitType
    {
        [Description("Область")]
        Region = 1,
        [Description("Район")]
        District = 2,
        [Description("Сільська рада")]
        Council = 3,
        [Description("Населений пункт")]
        Locality = 4
    }
}
