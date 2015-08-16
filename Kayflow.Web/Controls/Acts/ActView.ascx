<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActView.ascx.cs" Inherits="Controls_Acts_ActView" %>
<%@ Register Src="NotesList.ascx" TagName="NotesList" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Acts/StatusHistoryList.ascx" TagPrefix="uc1" TagName="StatusHistoryList" %>

<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnEdit" AutoPostBack="False" Text="Редагувати" SkinID="EditButton">
        <ClientSideEvents Click="function(s, e){ ActEdit(); }"></ClientSideEvents>
    </dx:ASPxButton>
</div>

<dx:ASPxPageControl ID="pageActView" runat="server" ActiveTabIndex="0" TabPosition="Left" Width="100%">
    <TabPages>
        <dx:TabPage Text="Справа">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <div class="wrapper_horizontal_half">
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Землевпорядник:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblEmployeeName" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Населений пункт:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblUnitName" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Дата виїзду:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblMeteringDate" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Адреса:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblAddress" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Категорія:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblCategoryName" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Примітка:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblDescription" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <dx:ASPxCheckBox ID="chIsClosed" runat="server" CheckState="Unchecked" Text="Закрита справа" ReadOnly="True" />
                            <dx:ASPxCheckBox ID="chIgnoreTerms" runat="server" CheckState="Unchecked" Text="Ігнорувати терміни" ReadOnly="True" />
                        </div>
                    </div>
                    <div class="wrapper_horizontal_half">
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Замовник:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblCustomerName" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Телефон:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblCustomerPhone" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="№ договору:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblActNum" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Дата договору:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblActDate" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="К-сть ділянок:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblAreaAmount" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="К-сть актів:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblActAmount" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Стан справи:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblActStatus" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Причина затр.:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblDelayReason" CssClass="text_box" />
                            </div>
                        </div>
                    </div>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Проходження справи">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <div class="list_button list_right_button">
                        <dx:ASPxButton runat="server" ID="btnChangeSteps" AutoPostBack="False" Text="Змінити проходження справи" SkinID="EditButton">
                            <ClientSideEvents Click="function(s, e){ StepsEdit(); }"></ClientSideEvents>
                        </dx:ASPxButton>
                    </div>
                    <dx:ASPxGridView ID="gridSteps" runat="server" Width="100%" ClientInstanceName="gridSteps"
                        AutoGenerateColumns="False" KeyFieldName="ID"
                        OnBeforePerformDataSelect="gridSteps_OnBeforePerformDataSelect"
                        OnHtmlRowPrepared="gridSteps_OnHtmlRowPrepared">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="OrdNum" Caption="№" SortOrder="Ascending" SortIndex="0" Width="50px" />
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Назва етапу" />
                            <dx:GridViewDataDateColumn FieldName="Delivered" Caption="Передали" Width="90px" />
                            <dx:GridViewDataDateColumn FieldName="Received" Caption="Отримали" Width="90px" />
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="False"></SettingsBehavior>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Оплата" Name="tabPayments" Visible="False">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <div class="wrapper_horizontal_half">
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Нараховано:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblSalaryCalculated" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Оплочено:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblSalaryPaidDate" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Нараховано ХМЛ:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblCalculatedMain" CssClass="text_box" />
                            </div>
                        </div>
                        <div class="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title" Text="Оплочено:" />
                            <div class="textbox">
                                <asp:Label runat="server" ID="lblPaidMainDate" CssClass="text_box" />
                            </div>
                        </div>
                        <asp:Panel runat="server" ID="panTotalCost" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Вартість робіт:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblTotalCost" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panPaidOn" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Опл. на вимірах:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblPaidOn" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panLeftOn" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Залишено на місці:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblLeftOn" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panApproval1" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Погодження 1:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblApproval1" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="wrapper_horizontal_half">
                        <asp:Panel runat="server" ID="panKailasPaid1" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Опл. на ПП Кайлас-К:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblKailasPaid1" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panKailasDue" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Заборг. по ПП Кайлас-К:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblKailasDue" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panApproval2" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Погодження 2:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblApproval2" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panPaidDue" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Оплачена заборг.:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblPaidDue" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="panKailasPaid2" CssClass="wrapper_horizontal">
                            <asp:Label runat="server" CssClass="title_wide" Text="Опл. на ПП Кайлас-К 2:" />
                            <div class="textbox_short">
                                <asp:Label runat="server" ID="lblKailasPaid2" CssClass="text_box" />
                            </div>
                        </asp:Panel>
                    </div>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Документи">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="gridActDocument" runat="server" Width="100%"
                        AutoGenerateColumns="False" KeyFieldName="ID"
                        OnBeforePerformDataSelect="gridActDocument_OnBeforePerformDataSelect"
                        OnHtmlRowPrepared="gridActDocument_OnHtmlRowPrepared">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="GroupName" Caption="Група" GroupIndex="0" />
                            <dx:GridViewDataDateColumn FieldName="DocumentName" Caption="Документ" />
                            <dx:GridViewDataDateColumn FieldName="DocValue" Caption="Статус" Width="90px" />
                            <dx:GridViewDataTextColumn FieldName="Comment" Caption="Коментар"/>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="False" AllowSort="False" />
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Причини затримки">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <uc1:NotesList ID="ucActNotes" runat="server" />
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Стан справи">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <uc1:StatusHistoryList runat="server" ID="ucStatusHistory" />
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Text="Історія">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="gridHistory" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="ID"
                        OnBeforePerformDataSelect="gridHistory_OnBeforePerformDataSelect">
                        <Columns>
                            <dx:GridViewDataDateColumn FieldName="OnDate" Caption="Дата" SortIndex="0" SortOrder="Descending" Width="100px" />
                            <dx:GridViewDataDateColumn FieldName="OnDate" Caption="Час" SortIndex="1" SortOrder="Descending" Width="100px">
                                <PropertiesDateEdit DisplayFormatString="t"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="Працівник" Width="200" />
                            <dx:GridViewDataTextColumn FieldName="Description" Caption="Опис дії" />
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
    </TabPages>
</dx:ASPxPageControl>
<script type="text/javascript">
    window.ActEdit = function () {
        DialogForm_ShowFrame('Редагувати справу', 'ActEdit', 'id=' + '<%: DocID %>', 'OnActEditComplete');
    }

    window.OnActEditComplete = function () {
        location.reload();
    }

    window.StepsEdit = function () {
        DialogForm_ShowFrame('Проходження справи', 'StepsEdit', 'id=' + '<%: DocID %>', 'OnActEditComplete');
    }
</script>
