<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="Controls_Content_MainMenu" %>
<ul class="menu flex-multi">
    <asp:Repeater ID="rpMenu" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%# SitePath+ Eval("Url") %>' class='<%# GetActiveClass((string)Eval("View")) %>'><%# Eval("ItemName") %></a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<script type="text/javascript">
    function initMenu() {
        $('ul.menu.flex-multi').flexMenu({
            linkText: "..."
        });
    }
</script>