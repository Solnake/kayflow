<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocumentGroupEdit.ascx.cs" Inherits="Controls_AdminControls_DocumentGroupEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Назва групи" FieldName="Name">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtName" runat="server" SkinID="Required" MaxLength="256">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть назву групи" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="№ п/п" FieldName="OrdNum">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxSpinEdit ID="txtOrdNum" runat="server" Number="1" SkinID="Required" MinValue="1" MaxValue="10" NumberType="Integer">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть порядковий номер" />
                        </ValidationSettings>
                    </dx:ASPxSpinEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Відображати" FieldName="Show">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxCheckBox ID="chShow" runat="server"/>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="236px">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnOk" runat="server" ClientInstanceName="btnOk" Text="Зберегти">
                                </dx:ASPxButton>
                            </td>
                            <td style="padding-left: 15px;">
                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Закрити">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
    </Items>
</dx:ASPxFormLayout>
<dx:ASPxCallback ID="clbkSave" runat="server" />