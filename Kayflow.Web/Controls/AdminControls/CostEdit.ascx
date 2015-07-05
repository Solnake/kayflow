<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CostEdit.ascx.cs" Inherits="Controls_AdminControls_CostEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Вид витрат" FieldName="Name">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtName" runat="server" SkinID="Required" MaxLength="256">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть назву виду витрат" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
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