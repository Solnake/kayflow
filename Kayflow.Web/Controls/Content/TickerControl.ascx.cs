using System;
using System.Text;
using Kayflow.Manager;

public partial class Controls_Content_TickerControl : BaseControl
{
    private string Message
    {
        get
        {
            return Session["ListCompanyMessagesForTicker"] != null
                ? Session["ListCompanyMessagesForTicker"].ToString()
                : String.Empty;
        }
        set { Session["ListCompanyMessagesForTicker"] = value; }
    }

    public string GetMessagesArray()
    {
        if (CurrentOffice == null)
            return String.Empty;

        if (Session["ListCompanyMessagesForTicker"] == null)
        {
            StringBuilder sb = new StringBuilder();
            var list = CreateManager<CompanyMessageManager>().GetByOffice(CurrentOffice.ID);
            if (list.Count == 0)
                Message = String.Empty;
            else
            {
                sb.Append("&nbsp&#149;&nbsp;&nbsp;");
                foreach (var item in list)
                {
                    sb.Append(escapeHTML(item.MessageText) + "&nbsp;&nbsp;&#149;&nbsp;&nbsp;");
                }

                Message = sb.ToString();
            }
        }

        return Message;
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