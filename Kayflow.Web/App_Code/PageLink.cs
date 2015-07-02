using System.Linq;
using System.Collections.Generic;

public class PageLink
{
    public string ItemName { get; set; }
    public string PagePath { get; set; }
    public string View { get; set; }

    public string Url
    {
        get
        {
            return string.IsNullOrEmpty(View)
                ? PagePath
                : string.Format("{0}?view={1}", PagePath, View);
        }
    }

    public PageLink(string itemName, string pagePath, string view = null)
    {
        ItemName = itemName;
        PagePath = pagePath;
        View = view;
    }
}