using System;
using System.Text;
using Kayflow.Manager;

public partial class Controls_Content_TickerControl : BaseControl
{
    public string GetMessagesArray()
    {
        if (CurrentOffice == null)
            return String.Empty;

        StringBuilder sb = new StringBuilder();
        var list = CreateManager<CompanyMessageManager>().GetByOffice(CurrentOffice.ID);
        if (list.Count==0)
            return String.Empty;

        sb.Append("&nbsp&#149;&nbsp;&nbsp;");
        foreach (var item in list)
        {
            sb.Append(escapeHTML(item.MessageText) + "&nbsp;&nbsp;&#149;&nbsp;&nbsp;");
        }

        return sb.ToString();
    }



    private string escapeHTML(string str)
    {
        return str
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\r", " ")
            .Replace("\n", " ")
            .Replace("\"", "&quot;");
    }
}