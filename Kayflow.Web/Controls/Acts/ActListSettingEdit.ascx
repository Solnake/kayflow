<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActListSettingEdit.ascx.cs" Inherits="Controls_Acts_ActListSettingEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="450px">
    <Items>
        <dx:LayoutItem ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                    <dx:ASPxGridView ID="gridList" runat="server" Width="100%"
                        AutoGenerateColumns="False" KeyFieldName="FieldName"
                        OnBeforePerformDataSelect="gridList_OnBeforePerformDataSelect">
                        <Columns>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" SelectAllCheckboxMode="Page" Width="40px" />
                            <dx:GridViewDataTextColumn FieldName="DisplayName" Caption="Назва колонки" />
                        </Columns>
                        <SettingsPager Mode="ShowAllRecords" />
                    </dx:ASPxGridView>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="236px">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
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
