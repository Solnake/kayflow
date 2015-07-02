using System;
using System.Collections.Generic;

public partial class Administration : BasePage
{
    public override string PageName
    {
        get { return "Адміністрування"; }
    }

    public override List<PageLink> MenuItems
    {
        get
        {
            var items = new List<PageLink>
            {
                new PageLink("Головна", "Default.aspx"),
                new PageLink("Тер. одиниці", "Administration.aspx", "TerritorialUnitList"),
                new PageLink("Категорії", "Administration.aspx", "CategoryList"),
                new PageLink("Види витрат", "Administration.aspx", "CostList")
            };
            if (CurrentEmployee.IsAdmin)
            {
                items.AddRange(new List<PageLink>
                {
                    new PageLink("Статуси актів", "Administration.aspx", "StateList"),
                    new PageLink("Групи колонок", "Administration.aspx", "DocumentGroupList"),
                    new PageLink("Дод. колонки", "Administration.aspx", "DocumentList"),
                    new PageLink("Відомості про оплату", "Administration.aspx", "PaymentDataSettingsList"),
                    new PageLink("Колонки журналу", "Administration.aspx", "ActListSettingList"),
                    new PageLink("Етапи проходження", "Administration.aspx", "ActActionList")
                });
            }

            if (CurrentEmployee.IsAdmin || CurrentEmployee.SuperAdmin)
            {
                items.Add(new PageLink("Працівники", "Administration.aspx", "EmployeeList"));
            }

            if (CurrentEmployee.SuperAdmin)
            {
                items.Add(new PageLink("Офіси", "Administration.aspx", "OfficeList"));
            }
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
                    View = "OfficeList",
                    Title = "Список офісів"
                },
                new Crumb
                {
                    View = "EmployeeList",
                    Title = "Список працівників"
                },
                new Crumb
                {
                    View = "TerritorialUnitList",
                    Title = "Територіальні одиниці"
                },
                new Crumb
                {
                    View = "OfficeTerritorialUnitList",
                    Title = "Налаштування",
                    ParentView = "TerritorialUnitList"
                },
                new Crumb
                {
                    View = "CategoryList",
                    Title = "Категорії"
                },
                new Crumb
                {
                    View = "CostList",
                    Title = "Види витрат"
                },
                new Crumb
                {
                    View = "StateList",
                    Title = "Статуси актів"
                },
                new Crumb
                {
                    View = "DocumentGroupList",
                    Title = "Групи колонок"
                },
                new Crumb
                {
                    View = "DocumentList",
                    Title = "Додаткові колонки"
                },
                new Crumb
                {
                    View = "ActListSettingList",
                    Title = "Колонки журналу по-замовченню для працівників офісу"
                },
                new Crumb
                {
                    View = "PaymentDataSettingsList",
                    Title = "Відомості про оплату"
                },
                new Crumb
                {
                    View = "ActActionList",
                    Title = "Етапи проходження"
                }
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
        DefaultControl = "TerritorialUnitList";
        base.Page_Load(sender, e);
    }

    protected override void OnShowTitle(string message)
    {
        base.OnShowTitle(message);
        controlTitle.SetTitle(message);
    }
}