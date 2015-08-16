<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActEdit.ascx.cs" Inherits="Controls_Acts_ActEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%"
    OnInit="frmEditForm_OnInit">
    <Items>
        <dx:TabbedLayoutGroup Name="tabMain">
            <Paddings Padding="0px" />
            <Styles>
                <ContentStyle>
                    <Paddings Padding="0px" />
                </ContentStyle>
            </Styles>
            <Items>
                <dx:LayoutGroup Caption="Дані справи" ColCount="2" Height="420px">
                    <CellStyle>
                        <Paddings Padding="0px" />
                    </CellStyle>
                    <Items>
                        <dx:LayoutItem Caption="Працівник" FieldName="EmployeeID">
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
                        <dx:LayoutGroup Caption="Інформація про замовника" GroupBoxDecoration="HeadingLine" RowSpan="3">
                            <Items>
                                <dx:LayoutItem FieldName="CustomerName" Caption="Замовник">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtCustomerName" runat="server" SkinID="Required" MaxLength="512">
                                                <ValidationSettings ValidationGroup="vgSave">
                                                    <RequiredField ErrorText="Вкажіть замовника" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="CustomerPhone" Caption="Телефон">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtCustomerPhone" runat="server" SkinID="Required" MaxLength="72">
                                                <ValidationSettings ValidationGroup="vgSave">
                                                    <RequiredField ErrorText="Вкажіть телефон замовника" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                        </dx:LayoutGroup>
                        <dx:LayoutItem Caption="Населений пункт" FieldName="TerritorialUnitID">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxComboBox ID="ddlTerritorialUnits" runat="server" SkinID="Required" ValueType="System.Guid">
                                        <Buttons>
                                            <dx:EditButton ToolTip="Пошук">
                                            </dx:EditButton>
                                        </Buttons>
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Оберіть населений пункт" />
                                        </ValidationSettings>
                                        <ClientSideEvents ButtonClick="function(s, e){ ddlTerritorialUnits_ButttonsClick(s, e); }"></ClientSideEvents>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Дата виїзду" FieldName="MeteringDate">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxDateEdit ID="txtMeteringDate" runat="server" SkinID="Required">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Вкажіть дату виїзду" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Адреса" FieldName="Address">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtAddress" runat="server" MaxLength="512" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup Caption="Дані договору" GroupBoxDecoration="HeadingLine" RowSpan="3">
                            <Items>
                                <dx:LayoutItem FieldName="ActNum" Caption="№ договору">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtActNum" runat="server" MaxLength="12" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="ActDate" Caption="Дата договору">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="txtActDate" runat="server" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                        </dx:LayoutGroup>
                        <dx:LayoutItem Caption="Категорія" FieldName="CategoryID">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxComboBox ID="ddlCategories" runat="server" SkinID="Required" ValueType="System.Guid">
                                        <ValidationSettings ValidationGroup="vgSave">
                                            <RequiredField ErrorText="Оберіть категорію" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Примітка" FieldName="Description">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxTextBox ID="txtDescription" runat="server" MaxLength="256" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" Name="Attributes">
                            <Items>
                                <dx:LayoutItem FieldName="IsClosed">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chIsClosed" runat="server" CheckState="Unchecked" Text="Закрита справа" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="IgnoreTherms">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxCheckBox ID="chIgnoreTerms" runat="server" CheckState="Unchecked" Text="Ігнорувати терміни" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                            <SettingsItems ShowCaption="False" />
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="К-сть ділянок" FieldName="AreaAmount">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtAreaAmount" runat="server" Number="1" SkinID="Required" Width="60px"
                                                NumberType="Integer" MinValue="1" MaxValue="100">
                                                <ValidationSettings ValidationGroup="vgSave">
                                                    <RequiredField ErrorText="Вкажіть кількість ділянок" />
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="К-сть актів" FieldName="ActAmount">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtActAmount" runat="server" Number="1" SkinID="Required" Width="60px"
                                                NumberType="Integer" MinValue="1" MaxValue="100">
                                                <ValidationSettings ValidationGroup="vgSave">
                                                    <RequiredField ErrorText="Вкажіть кількість актів" />
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                        </dx:LayoutGroup>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Оплата" ColCount="2" Height="420px" VerticalAlign="Top" Name="SalaryTab">
                    <Items>
                        <dx:LayoutGroup Caption="Зарплата" GroupBoxDecoration="HeadingLine" RowSpan="5" Name="SalaryGroup">
                            <Items>
                                <dx:LayoutItem FieldName="SalaryCalculated" Caption="Нараховано">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtSalaryCalculated" runat="server" NumberType="Float" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="SalaryPaidDate" Caption="Оплочено">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="txtSalaryPaidDate" runat="server" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="CalculatedMain" Caption="Нараховано ХМЛ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtCalculatedMain" runat="server" NumberType="Float" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem FieldName="PaidMainDate" Caption="Оплочено">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="txtPaidMainDate" runat="server" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                            <CellStyle>
                                <Paddings Padding="0px" />
                            </CellStyle>
                        </dx:LayoutGroup>
                        <dx:LayoutItem FieldName="TotalCost" Caption="Вартість робіт">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtTotalCost" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="PaidOn" Caption="Аванс">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtPaidOn" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="LeftOn" Caption="Залишено на місці">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtLeftOn" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Approval1" Caption="Погодження 1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtApproval1" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="KailasPaid1" Caption="Опл. на ПП Кайлас-К">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtKailasPaid1" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="KailasDue" Caption="Заборг. по ПП Кайлас-К">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtKailasDue" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="Approval2" Caption="Погодження 2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtApproval2" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="PaidDue" Caption="Оплачена заборг.">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtPaidDue" runat="server" NumberType="Float" />
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem FieldName="KailasPaid2" Caption="Опл. на ПП Кайлас-К 2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtKailasPaid2" runat="server" NumberType="Float" />
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
    function ddlTerritorialUnits_ButttonsClick(s, e) {
        switch (e.buttonIndex) {
            case 0:
                DialogForm_ShowFrame('Пошук тер. одиниці', 'TerritorialUnitSearch', '', 'OnSearchUnitComplete');
                break;
            default:
        }
    }

    window.OnSearchUnitComplete = function (returnValue) {
        var ddl = gfGetElement('<%= ddlTerritorialUnits.ClientID %>');
        var item = ddl.FindItemByValue(returnValue);
        if (item)
            ddl.SetSelectedItem(item);
        else {
            alert("Поточний офіс не працює з даним нас. пунктом. Виправити цю ситуацію Ви можете в налаштуваннях системи.");
        }
    }
</script>
