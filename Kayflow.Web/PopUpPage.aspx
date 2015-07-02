<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpPage.aspx.cs" Inherits="PopUpPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html {
            background: transparent !important;
        }

        body {
            background: transparent !important;
        }
    </style>
    <script type="text/javascript">
        function DialogForm_ShowFrame(headerText, editForm, queryString, event, width, height) {
            parent.DialogForm_ShowFrame(headerText, editForm, queryString, event, width, height, DialogLoadingPanel);
        }

        function DialogForm_CloseFrame(returnValue, msgType) {
            parent.CloseDialogFrame(returnValue, msgType);
        }

        function DialogForm_HideFrame() {
            parent.HideDialogFrame();
        }
    </script>
</head>
<body style="overflow-x: hidden;">
    <form id="frmMain" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="CommonJs"/>
            </Scripts>
        </asp:ScriptManager>
        <dx:ASPxGlobalEvents ID="globalEventManager" runat="server">
            <ClientSideEvents ControlsInitialized="function(s, e){ OnControlsInitialized(); }"></ClientSideEvents>
        </dx:ASPxGlobalEvents>
        <dx:ASPxLoadingPanel ID="loadingPanelDialog" runat="server" ClientInstanceName="DialogLoadingPanel" Modal="True" />
        <dx:ASPxPopupControl ID="popupControl" runat="server"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowCloseButton="false"
            Modal="True" AllowDragging="True" CloseAction="CloseButton" AutoUpdatePosition="True">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div id="centralDiv">
                        <asp:PlaceHolder runat="server" ID="phCenter" />
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <ClientSideEvents CloseUp="function(s,e){ DialogForm_HideFrame(); }" />
        </dx:ASPxPopupControl>
        <script type="text/javascript">
            var pageLoaded = false;
            function OnControlsInitialized() {
                if (pageLoaded)
                    return;
                $('#centralDiv').bind('resize', function () {
                    gfGetElement('<%=popupControl.ClientID %>').UpdatePosition();
                });
                gfGetElement('<%=popupControl.ClientID %>').Show();
                setTimeout(function () {
                    $(':input:enabled:visible:first').focus();
                }, 50);
                pageLoaded = true;
            }
        </script>
    </form>
</body>
</html>
