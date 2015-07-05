using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace Kayflow
{
    public class MyRibbonControl : RibbonControl
    {
        protected override RibbonViewInfo CreateViewInfo()
        {
            return new MyRibbonViewInfo(this);
        }
    }

    public class MyRibbonViewInfo : RibbonViewInfo
    {
        public MyRibbonViewInfo(MyRibbonControl ribbon) : base(ribbon) { }

        protected override RibbonCaptionViewInfo CreateCaptionInfo()
        {
            return new MyRibbonCaptionInfo(this);
        }
    }

    public class MyRibbonCaptionInfo : RibbonCaptionViewInfo
    {
        public MyRibbonCaptionInfo(MyRibbonViewInfo info) : base(info) { }

        protected override string GetTextPart1()
        {
            return Ribbon.Parent.Text;
        }

        protected override string GetTextPart2()
        {
            return "";
        }
    }
}
