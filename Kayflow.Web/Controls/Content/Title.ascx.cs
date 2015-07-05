
using System.IO;

public partial class Controls_Content_Title : BaseControl
{
    private string _pageName
    {
        get { return Path.GetFileName(Request.Path); }
    }
    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        if (!string.IsNullOrEmpty(CurrentPage.PageName))
        {
            lblTitle.Text = _GetElement(_pageName, CurrentPage.PageName);
            lblTitle.Text += " / " + _GetCrumbs(CurrentView);
        }
        else
        {
            lblTitle.Text = _GetCrumbs(CurrentView);
        }
    }

    private string _GetCrumbs(string view)
    {
        var result = string.Empty;
        var element = CurrentPage.Breadcrumbs.Find(b => b.View == view);
        if (element != null)
        {
            if (element.Type != eCrumbType.Hidden)
                result = _GetElement(_pageName, element.Title, element.View, element.Type);
            if (!string.IsNullOrEmpty(element.ParentView))
                result = string.Format("{0} / {1}", _GetCrumbs(element.ParentView), result);
        }
        return result;
    }

    private string _GetElement(string page, string title, string view = null, eCrumbType type = eCrumbType.Link)
    {
        var href = SitePath + page;
        if (!string.IsNullOrEmpty(view))
            href += "?view=" + view;
        if (CurrentView == view)
            type = eCrumbType.Text;
        return _GetElementTitle(type, href, title, view);
    }

    private string _GetElementTitle(eCrumbType pType, string pHref, string pTitle, string pView)
    {
        var result = string.Empty;
        switch (pType)
        {
            case eCrumbType.Link:
                result = string.Format("<a href=\'{0}\'>{1}</a>",
                    pHref,
                    pTitle);
                break;
            case eCrumbType.Text:
                result =  string.Format("<span {0}>{1}</a>",
                    CurrentView == pView ? "class='active'" : string.Empty,
                    pTitle);
                break;
        }

        return result;
    }

    public void SetTitle(string message)
    {
        lblTitle.Text += string.Format(" <span class='active'>{0}</span>", message);
    }
}