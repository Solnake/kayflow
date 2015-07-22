using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private BasePage CurrentPage
    {
        get
        {
            var page = Page as BasePage;
            if (page==null)
                throw new NullReferenceException("Page is not BasePage");
            return page;
        }
    }

    protected string ImagesPath
    {
        get
        {
            return CurrentPage.ImagesPath;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
