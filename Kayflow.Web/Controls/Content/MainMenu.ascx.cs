
using System.Linq;

public partial class Controls_Content_MainMenu : BaseControl
{
    protected override void DoInitialize(object data, bool loadData)
    {
        rpMenu.DataSource = CurrentPage.MenuItems;
        rpMenu.DataBind();

        if (loadData && CurrentPage.MenuItems!= null && CurrentPage.MenuItems.Any())
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "menuScript",
                "<script type=text/javascript> initMenu(); </script>");
        }
    }

    protected string GetActiveClass(string view)
    {
        var cssClass = string.Empty;
        if (string.IsNullOrEmpty(view))
            return cssClass;
        if (CurrentView == view)
        {
            cssClass = "current";
        }
        else
        {
            if (IsMenuView(view))
                cssClass = "current";
        }
        return cssClass;
    }

    private bool IsMenuView(string view)
    {
        var element = CurrentPage.Breadcrumbs.Find(b => b.ParentView == view);
        if (element != null)
        {
            return CurrentView == element.View || IsMenuView(element.View);
        }
        return false;
    }
}