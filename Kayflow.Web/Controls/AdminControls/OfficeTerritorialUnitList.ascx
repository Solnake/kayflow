<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfficeTerritorialUnitList.ascx.cs" Inherits="Controls_AdminControls_OfficeTerritorialUnitList" %>
<dx:ASPxTreeList ID="treeUnits" runat="server" Width="100%" AutoGenerateColumns="False"
    KeyFieldName="ID" ParentFieldName="ParentID"
    OnCustomCallback="treeUnits_OnCustomCallback">
    <Columns>
        <dx:TreeListTextColumn Caption="Територіальна одиниця" FieldName="Name" Name="columnName" VisibleIndex="0">
        </dx:TreeListTextColumn>
    </Columns>
    <SettingsSelection Enabled="True" Recursive="False" AllowSelectAll="True"/>
    <ClientSideEvents SelectionChanged="function(s, e){ s.PerformCallback(); }"></ClientSideEvents>
</dx:ASPxTreeList>