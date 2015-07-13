<%@ Control Language="C#" AutoEventWireup="true" CodeFile="schEventEdit.ascx.cs" Inherits="Controls_Schedule_schEventEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True">
    <Items>
        <dx:LayoutItem Caption="Дата" FieldName="StartDate">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxDateEdit ID="txtOnDate" runat="server" SkinID="Required">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Оберіть дату" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Землевпорядник" FieldName="EmployeeID">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxComboBox ID="ddlEmployees" runat="server" SkinID="Required" ValueType="System.Guid">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Оберіть землевпорядника" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Опис" FieldName="Subject">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxMemo ID="txtSubject" runat="server" Height="71px" SkinID="Required" MaxLength="128">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть опис планування" />
                        </ValidationSettings>
                    </dx:ASPxMemo>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="236px" Name="itemButtons">
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