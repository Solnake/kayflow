<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControl.ascx.cs" Inherits="Controls_Content_UserControl" %>
<asp:Label runat="server" ID="lblOffice" CssClass="office" data-dropdown="#panOffices"/>
<asp:Panel runat="server" ID="panOffices" ClientIDMode="Static" CssClass="dropdown dropdown-tip">
</asp:Panel>
<dx:ASPxHyperLink ID="hlUserName" runat="server" CssClass="user">
</dx:ASPxHyperLink>
<dx:ASPxCallback ID="callbackOFficeActions" runat="server" OnCallback="callbackOFficeActions_OnCallback">
    <ClientSideEvents CallbackComplete="function(s, e){ location.reload(); }"></ClientSideEvents>
</dx:ASPxCallback>
<script type="text/javascript">
    window.officeChange = function (value) {
        gfGetElement('<%=callbackOFficeActions.ClientID%>').PerformCallback(value);
    };
</script>
