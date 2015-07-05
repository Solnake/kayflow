<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExpenseEdit.ascx.cs" Inherits="Controls_Expense_ExpenseEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%" OnInit="frmEditForm_OnInit">
    <Items>
        <dx:LayoutItem Caption="Земплевпорядник" FieldName="EmployeeID">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxComboBox ID="ddlEmployees" runat="server" SkinID="Required" ValueType="System.Guid">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Оберіть землевпорядника" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Дата" FieldName="OnDate">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxDateEdit ID="txtOnDate" runat="server" SkinID="Required">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть дату" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Дистанція" FieldName="Distance">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxSpinEdit ID="txtDistance" runat="server" NumberType="Integer" MinValue="0" MaxValue="10000"/>
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