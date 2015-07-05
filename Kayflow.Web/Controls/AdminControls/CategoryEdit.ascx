<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryEdit.ascx.cs" Inherits="Controls_AdminControls_CategoryEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Категорія" FieldName="Name">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtName" runat="server" SkinID="Required" MaxLength="256">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть назву категорії" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="236px">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnOk" runat="server" Text="Зберегти" ClientInstanceName="btnOk"/>
                            </td>
                            <td style="padding-left: 15px;">
                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Закрити"/>
                            </td>
                        </tr>
                    </table>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
    </Items>
</dx:ASPxFormLayout>
<dx:ASPxCallback ID="clbkSave" runat="server" />