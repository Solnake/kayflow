<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TerritorialUnitList.ascx.cs" Inherits="Controls_AdminControls_TerritorialUnitList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add">
        <ClientSideEvents Click="function(s, e){ Edit(); }"></ClientSideEvents>
    </dx:ASPxButton>
</div>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnRelation" Text="Налаштування" SkinID="Customize" OnClick="btnRelation_OnClick"/>
</div>
<dx:ASPxTreeList ID="treeUnits" runat="server" Width="100%" AutoGenerateColumns="False"
    ClientInstanceName="treeUnits" KeyFieldName="ID" ParentFieldName="ParentID"
    OnCustomCallback="treeUnits_OnCustomCallback"
    OnNodeDeleting="treeUnits_OnNodeDeleting">
    <Columns>
        <dx:TreeListTextColumn FieldName="ID" Name="columnID" Visible="False">
        </dx:TreeListTextColumn>
        <dx:TreeListTextColumn Caption="Територіальна одиниця" FieldName="Name" Name="columnName" VisibleIndex="0">
        </dx:TreeListTextColumn>
        <dx:TreeListTextColumn VisibleIndex="1" Width="64px" Name="columnButtons" Caption=" ">
            <DataCellTemplate>
                <table>
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnEdit" runat="server" SkinID="Edit" EditValue='<%# Eval("ID") %>'>
                                <ClientSideEvents Click="function(s,e) { 
                                        var value = s.mainElement.getAttribute('EditValue');
                                        Edit(value); }" />
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnDelete" runat="server" SkinID="Delete"
                                EditValue='<%# Container.NodeKey %>'>
                                <ClientSideEvents Click="function(s,e) { 
                                        var value = s.mainElement.getAttribute('EditValue');
                                        Delete(value); }" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </DataCellTemplate>
        </dx:TreeListTextColumn>
    </Columns>
    <SettingsBehavior DisablePartialUpdate="True"></SettingsBehavior>
</dx:ASPxTreeList>
<script type="text/javascript">
    window.IsNew = false;
    window.Edit = function (value) {
        if ((value != null) && (value != 0)) {
            DialogForm_ShowFrame('Редагувати територіальну одиницю', 'TerritorialUnitEdit', 'id=' + value, 'OnEditComplete');
        }
        else {
            window.IsNew = true;
            DialogForm_ShowFrame('Додати територіальну одиницю', 'TerritorialUnitEdit', 'id=0', 'OnEditComplete');
        }
    }

    window.OnEditComplete = function (result) {
        if (result) {
            gfGetElement('<%=treeUnits.ClientID%>').PerformCallback('focusedid=' + result);
        }
    }

    window.Delete = function(value) {
        if ((value != null) && (value != 0)) {
            if (confirm('Ви дійсно бажаєте видалити запис?')) {
                gfGetElement('<%=treeUnits.ClientID%>').DeleteNode(value);
            }
        }
    }
</script>
