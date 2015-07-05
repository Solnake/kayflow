<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeEdit.ascx.cs" Inherits="Controls_AdminControls_EmployeeEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:TabbedLayoutGroup>
            <Paddings Padding="0px" />
            <Styles>
                <ContentStyle>
                    <Paddings Padding="0px" />
                </ContentStyle>
            </Styles>
            <Items>
                <dx:LayoutGroup Caption="Працівник" Height="320px">
                    <CellStyle>
                        <Paddings Padding="0px" />
                    </CellStyle>
                    <Items>
                        <dx:LayoutItem Caption="Ім'я" FieldName="FirstName">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtFirstName" runat="server" MaxLength="256" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Вкажіть імя" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="По-батькові" FieldName="MiddleName">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtMiddleName" runat="server" MaxLength="256" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Вкажіть по-батькові" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Прізвище" FieldName="LastName">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtLastName" runat="server" MaxLength="256" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Вкажіть прізвище" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Логін" FieldName="Login">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtLogin" runat="server" MaxLength="256" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Оберіть логін" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Пароль" Name="itemPassword">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtPassword" runat="server" MaxLength="256" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Вкажіть пароль" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    <dx:ASPxButton ID="btnChangePassword" runat="server" Text="Змінити пароль" SkinID="EditButton" Visible="False">
                                        <ClientSideEvents Click="function(s, e){ ShowSetPassword(); }"></ClientSideEvents>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup Caption="Права доступу" ColCount="2" GroupBoxDecoration="HeadingLine">
                            <Items>
                                <dx:LayoutItem FieldName="IsAdmin">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chAdmin" runat="server" CheckState="Unchecked" Text="Адміністратор офісу" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="SuperAdmin">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chSuperAdmin" runat="server" CheckState="Unchecked" Text="Адміністратор системи" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <SettingsItems ShowCaption="False" />
                        </dx:LayoutGroup>
                        <dx:LayoutItem FieldName="IsBlocked" ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxCheckBox ID="chIsBlocked" runat="server" CheckState="Unchecked" Text="Заблокований" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Офіси" Height="320px" Name="groupOffices">
                    <Items>
                        <dx:LayoutItem ShowCaption="False">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="gridList" runat="server" Width="100%"
                                        AutoGenerateColumns="False" KeyFieldName="ID"
                                        OnBeforePerformDataSelect="gridList_OnBeforePerformDataSelect"
                                        OnCommandButtonInitialize="gridList_OnCommandButtonInitialize">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="60px">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Офіс" />
                                        </Columns>
                                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="290" />
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                    <CellStyle>
                        <Paddings Padding="0px" />
                    </CellStyle>
                </dx:LayoutGroup>
            </Items>
        </dx:TabbedLayoutGroup>
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
<script type="text/javascript">
    window.ShowSetPassword = function () {
        DialogForm_ShowFrame('Задати новий пароль', 'SetPassword', 'ID=<%=DocID%>&StorageID=<%=Storage.StorageID %>');
    }
</script>