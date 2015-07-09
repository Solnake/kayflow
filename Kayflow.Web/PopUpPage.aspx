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

        .wrapper_popup {
            width: 100%;
            height: 100%;
        }

        .iframe {
            width: 100%;
            height: 100%;
            position: absolute;
            z-index: -1;
            border: none;
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

        function isBrowserMobileIOS() {
            if (parent.isBrowserMobileIOS)
                return parent.isBrowserMobileIOS();
            return false;
        }
    </script>
</head>
<body style="overflow-x: hidden;">
    <form id="frmMain" runat="server">
        <div id="divIFrame">
            <asp:ScriptManager runat="server">
                <Scripts>
                    <asp:ScriptReference Name="jquery" />
                    <asp:ScriptReference Name="CommonJs" />
                </Scripts>
            </asp:ScriptManager>
            <dx:ASPxGlobalEvents ID="globalEventManager" runat="server">
                <ClientSideEvents ControlsInitialized="function(s, e){ ShowPopup(); }"></ClientSideEvents>
            </dx:ASPxGlobalEvents>
            <dx:ASPxLoadingPanel ID="loadingPanelDialog" runat="server" ClientInstanceName="DialogLoadingPanel" Modal="True" OnCustomJSProperties="loadingPanelDialog_OnCustomJSProperties" />
            <dx:ASPxPopupControl ID="popupControl" runat="server"
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Modal="true" AllowDragging="true"
                CloseAction="CloseButton" ShowPageScrollbarWhenModal="True">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="popupDiv" runat="server" SupportsDisabledAttribute="True">
                        <div id="centralDiv">
                            <div class="wrapper_popup">
                                <iframe class="iframe" name="frame"></iframe>
                                <asp:PlaceHolder runat="server" ID="phCenter" />
                            </div>
                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
                <ClientSideEvents CloseUp="function(s,e){ DialogForm_HideFrame(); }" />
            </dx:ASPxPopupControl>
        </div>
        <script type="text/javascript">
            var pageLoaded = false;

            function ShowPopup() {
                if (pageLoaded)
                    return;
                gfGetElement('<%=popupControl.ClientID %>').Show();
                if (!window.isBrowserMobileIOS())
                    setTimeout(function() {
                        $(':input:enabled:visible:first').focus();
                    }, 50);
                setTimeout(function(){ 
                    var timerResize='first';
                    frame.onresize = function() { 
                        if (timerResize !== 'first') clearTimeout(timerResize);
                        timerResize = setTimeout(function() {
                            //if (!window.isBrowserMobileIOS()) {
                            parent.popFixScroll(gfGetElement('<%= popupControl.ClientID %>').GetHeight(), frameElement.id);
                            var popupControl = gfGetElement('<%= popupControl.ClientID %>');
                            //var viewportHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 20) - 20;
                            //var maxAllowedHeight = Math.min(popupInitialHeight, viewportHeight);
                            //var cdheight = $(frame).height();
                            //if (cdheight > maxAllowedHeight && cdheight < popupControl.GetHeight() - 45)
                            //    popupControl.SetHeight(cdheight);
                            popupControl.UpdatePosition();
                            //}
                        }, 20);
                    };
                },200);

                pageLoaded = true;
            }

            var popupInitialWidth = <%= PopupWidth %>;
            var popupInitialHeight = <%= PopupHeight %>;
            $(window).on('resize', function() {
                popWindowResize("resize");
            });

            function popWindowResize(eventName) {
                var popupControl = gfGetElement('<%= popupControl.ClientID %>');
                var viewportWidth = Math.max(document.documentElement.clientWidth, window.innerWidth || 0) - 20;
                var viewportHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 20) - 20;
                var maxAllowedWidth = Math.min(popupInitialWidth, viewportWidth);
                var maxAllowedHeight = Math.min(popupInitialHeight, viewportHeight);                
                if (viewportWidth < popupInitialWidth) {
                    popupControl.SetWidth(viewportWidth);
                } else {
                    if (popupControl.GetWidth() < maxAllowedWidth) {
                        popupControl.SetWidth(maxAllowedWidth);
                    }
                }
                if (viewportHeight < popupInitialHeight)
                    popupControl.SetHeight(viewportHeight);
                else {
                    if (popupControl.GetHeight() < maxAllowedHeight)
                        popupControl.SetHeight(maxAllowedHeight);
                    else {
                        if ($('#centralDiv').height() < popupControl.GetHeight() - 100)
                            popupControl.SetHeight($('#centralDiv').height() + 100);
                    }
                }
                //if (!window.isBrowserMobileIOS() || eventName == "orientationchange")
                popupControl.UpdatePosition();
                parent.popFixScroll(popupControl.GetHeight(), frameElement.id);
            }

            function pop_HideFrame() {
                gfGetElement('<%= popupControl.ClientID %>').Hide();
            }

        </script>
        <script type="text/javascript">
            if (typeof ASPxClientGridView !== 'undefined') {
                ASPxClientGridView.prototype.DeleteGridRow = function (index) {
                    if (confirm('Ви дійсно бажаєте видалити запис?'))
                        this.DeleteRow(index);
                };
                }            
        </script>

    </form>
</body>
</html>
