<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActListSettingList.ascx.cs" Inherits="Controls_AdminControls_ActListSettingList" %>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%"
    AutoGenerateColumns="False" KeyFieldName="FieldName"
    OnBeforePerformDataSelect="gridList_OnBeforePerformDataSelect"
    OnCustomCallback="gridList_OnCustomCallback">
    <Columns>
        <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" SelectAllCheckboxMode="Page" Width="40px"/>
        <dx:GridViewDataTextColumn FieldName="DisplayName" Caption="Назва колонки" />
    </Columns>
    <SettingsPager Mode="ShowAllRecords"/>
    <ClientSideEvents SelectionChanged="function(s, e){ s.PerformCallback(); }"/>
</dx:ASPxGridView>
<script type="text/javascript">
    window.ColumnVisible_Change = function () {
        gfGetElement('<%=gridList.ClientID%>').PerformCallback();
    };
</script>