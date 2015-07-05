<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActList.ascx.cs" Inherits="Controls_Acts_ActList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<div class="list_button">
    
</div>
<div class="list_button list_right_button">
    <dx:ASPxButton runat="server" ID="btnChangeSteps" AutoPostBack="False" SkinID="Customize">
        <ClientSideEvents Click="function(s, e){ ShowCustomize(); }"></ClientSideEvents>
    </dx:ASPxButton>
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID"
    OnHtmlRowPrepared="gridList_OnHtmlRowPrepared">
    <Columns>
        <dx:GridViewDataDateColumn FieldName="MeteringDate" Caption="Дата" SortIndex="0" SortOrder="Descending" Width="100px" />
        <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="Землевпорядник" />
        <dx:GridViewDataTextColumn FieldName="UnitName" Caption="Нас. пункт" />
        <dx:GridViewDataTextColumn FieldName="Address" Caption="Адреса" />
        <dx:GridViewDataTextColumn FieldName="CustomerName" Caption="Замовник" />
        <dx:GridViewDataTextColumn FieldName="CustomerPhone" Caption="Телефон" />
        <dx:GridViewDataTextColumn FieldName="AreaAmount" Caption="К-сть ділянок" />
        <dx:GridViewDataTextColumn FieldName="ActAmount" Caption="К-сть актів" />
        <dx:GridViewDataTextColumn FieldName="CategoryName" Caption="Категорія" />
        <dx:GridViewDataTextColumn FieldName="ActNum" Caption="№ договору" />
        <dx:GridViewDataDateColumn FieldName="ActDate" Caption="Дата договору" />
        <dx:GridViewDataColumn Width="64px">
            <DataItemTemplate>
                <table>
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnEdit" runat="server" SkinID="Edit" />
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnDelete" runat="server" SkinID="Delete" />
                        </td>
                    </tr>
                </table>
            </DataItemTemplate>
        </dx:GridViewDataColumn>
    </Columns>
    <Templates>
        <DataItem>
            <a href='<%# string.Format("{0}?view=ActView&ID={1}", Request.Path, Eval("ID")) %>'><%# Container.Text %></a>
        </DataItem>
    </Templates>
    <Settings ShowFilterRow="True"></Settings>
    <SettingsBehavior AllowDragDrop="True"></SettingsBehavior>
    <SettingsCookies Enabled="True" CookiesID="ActList" StoreColumnsVisiblePosition="False" StoreFiltering="True" />
</dx:ASPxGridView>
<script type="text/javascript">
    window.ShowCustomize = function () {
        DialogForm_ShowFrame('Редагувати відображення колонок', 'ActListSettingEdit', '', 'OnCustomizeEditComplete');
    }

    window.OnCustomizeEditComplete = function () {
        location.reload();
    }
</script>
