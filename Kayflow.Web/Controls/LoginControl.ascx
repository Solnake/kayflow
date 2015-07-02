<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs" Inherits="Controls_LoginControl" %>
<div class="popup_box">
    <div class="title_popup">
        Авторизація
    </div>
    <div class="popup_content" style="margin-left: 50px; margin-top: 50px;">
        <dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True">
            <Items>
                <dx:LayoutItem Caption="Логін">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtLogin" runat="server" SkinID="Required" MaxLength="256">
                                <ValidationSettings ValidationGroup="vgSave">
                                    <RequiredField ErrorText="Вкажіть логін" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Пароль">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxTextBox ID="txtPassword" runat="server" SkinID="Required" MaxLength="256" Password="True" ClientInstanceName="txtPassword">
                                <ValidationSettings ValidationGroup="vgSave">
                                    <RequiredField ErrorText="Вкажіть пароль" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="210px">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxButton ID="btnOk" runat="server" Text="Авторизуватися" ClientInstanceName="btnOk">
                                <ClientSideEvents Click="function(s, e){ btnOk_Click(); }"/>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:ASPxFormLayout>
    </div>
</div>
<dx:ASPxCallback ID="clbkSave" runat="server" ClientInstanceName="clbkSave" OnCallback="clbkSave_OnCallback">
    <ClientSideEvents CallbackError="function(s, e){ clbkSave_CallbackError(); }"></ClientSideEvents>
</dx:ASPxCallback>
<script type="text/javascript">
    function btnOk_Click() {
        if (ASPxClientEdit.ValidateGroup('vgSave', true)) {
            clbkSave.PerformCallback();
        }
    }

    function clbkSave_CallbackError() {
        txtPassword.SetValue('');
    }
</script>
