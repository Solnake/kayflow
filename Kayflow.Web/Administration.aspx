<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administration.aspx.cs" Inherits="Administration" %>

<%@ Register Src="Controls/Content/Title.ascx" TagName="Title" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="content_max">
        <uc1:Title ID="controlTitle" runat="server" />
        <div class="padding_content_box">
            <asp:PlaceHolder ID="phContent" runat="server" />
        </div>
    </div>
</asp:Content>

