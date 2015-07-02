using System;
using System.Collections.Generic;

public partial class _Default : BasePage
{
    public override List<PageLink> MenuItems
    {
        get
        {
            var items = new List<PageLink>
            {
                new PageLink("Мої справи", "Default.aspx", "MyActList"),
                new PageLink("Відкриті справи", "Default.aspx", "OpenActList"),
                new PageLink("Закриті справи", "Default.aspx", "ClosedActList"),
                new PageLink("Витрати", "Default.aspx", "ExpenseList"),
                new PageLink("Загальний звіт", "Default.aspx", "ActReport"),
                new PageLink("Проходження справи", "Default.aspx", "ReportStep"),
                new PageLink("Налаштування", "Administration.aspx")
            };
            return items;
        }
    }

    public override List<Crumb> Breadcrumbs
    {
        get
        {
            return new List<Crumb>
            {
                new Crumb
                {
                    View = "MyActList",
                    Title = "Мої справи"
                },
                new Crumb
                {
                    View = "OpenActList",
                    Title = "Відкриті справи"
                },
                new Crumb
                {
                    View = "ClosedActList",
                    Title = "Закриті справи"
                },
                new Crumb
                {
                    View = "ActView",
                    ParentView = "MyActList"
                },
                new Crumb
                {
                    View = "ExpenseList",
                    Title = "Витрати"
                },
                new Crumb
                {
                    View = "ActReport",
                    Title = "Загальний звіт"
                },
                new Crumb
                {
                    View = "ReportStep",
                    Title = "Проходження справи"
                },
            };
        }
    }

    protected override void OnPreLoadFormContent(EventArgs e)
    {
        base.OnPreLoadFormContent(e);
        CenterPlaceHolder = phContent;
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        DefaultControl = "MyActList";
        base.Page_Load(sender, e);
    }

    protected override void OnShowTitle(string message)
    {
        base.OnShowTitle(message);
        controlTitle.SetTitle(message);
    }
}