using System;
using System.Text;
using Kayflow.Manager;

public partial class Controls_Content_TickerControl : BaseControl
{
    public string GetMessagesArray()
    {
        if (CurrentOfficeSettings == null)
            return String.Empty;

        return CurrentOfficeSettings.MessagesForTicker;
    }
}