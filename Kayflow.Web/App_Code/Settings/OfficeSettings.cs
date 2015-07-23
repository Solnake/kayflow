using System;
using System.Collections.Generic;
using System.Text;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

/// <summary>
/// Summary description for OfficeSettings
/// </summary>
public class OfficeSettings
{
    public Guid OfficeID { get; private set; }

    public bool NeedShowMessage { get; set; }

    public List<CompanyMessage> Messages { get; private set; }

    public string MessagesForTicker { get; private set; }

    public OfficeSettings(Guid OfficeId)
	{
	    OfficeID = OfficeId;
        Messages = Factory.Manager<CompanyMessageManager>().GetByOffice(OfficeId);
        FillMessagesForTicker();
        NeedShowMessage = true;
	}

    private void FillMessagesForTicker()
    {
        var sb = new StringBuilder();
        if (Messages.Count == 0)
            MessagesForTicker = String.Empty;
        else
        {
            sb.Append("&nbsp&#149;&nbsp;&nbsp;");
            foreach (var item in Messages)
            {
                sb.Append(escapeHTML(item.MessageText) + "&nbsp;&nbsp;&#149;&nbsp;&nbsp;");
            }

            MessagesForTicker = sb.ToString();
        }
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