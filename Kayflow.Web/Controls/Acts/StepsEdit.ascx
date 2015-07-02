<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StepsEdit.ascx.cs" Inherits="Controls_Acts_StepsEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%" ColCount="2">
    <Items>
        <dx:LayoutItem ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxGridView ID="gridSteps" runat="server" ClientInstanceName="gridSteps"
                        AutoGenerateColumns="False" KeyFieldName="ID" Width="600px"
                        OnBeforePerformDataSelect="gridSteps_OnBeforePerformDataSelect">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="OrdNum" Caption="№" Width="30px" />
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Назва етапу" Width="300px" />
                            <dx:GridViewDataDateColumn FieldName="Delivered" Caption="Передали" Width="120px">
                                <DataItemTemplate>
                                    <dx:ASPxDateEdit ID="txtDelivered" runat="server" Width="110px" Value='<%# Eval("Delivered") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="Received" Caption="Отримали" Width="120px">
                                <DataItemTemplate>
                                    <dx:ASPxDateEdit ID="txtReceived" runat="server" Width="110px" Value='<%# Eval("Received") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataDateColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="False" AllowSort="False" />
                        <SettingsPager Mode="ShowAllRecords" />
                    </dx:ASPxGridView>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutGroup GroupBoxDecoration="None" ShowCaption="False">
            <CellStyle>
                <Paddings Padding="0px" />
            </CellStyle>
            <Items>
                <dx:LayoutItem Caption="Статус">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="ddlStatus" runat="server" SkinID="Required" ValueType="System.Guid">
                                <ValidationSettings ValidationGroup="vgSave">
                                    <RequiredField ErrorText="Оберіть статус" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings Location="Top" />
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Стан справи">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxMemo ID="txtStateDescription" runat="server" Height="71px">
                            </dx:ASPxMemo>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings Location="Top" />
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Причина затримки">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxMemo ID="txtDescription" runat="server" Height="71px">
                            </dx:ASPxMemo>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings Location="Top" />
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutItem ColSpan="2" HorizontalAlign="Center" ShowCaption="False" Width="236px">
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
    <SettingsItems VerticalAlign="Top"></SettingsItems>
</dx:ASPxFormLayout>
<dx:ASPxCallback ID="clbkSave" runat="server" />
