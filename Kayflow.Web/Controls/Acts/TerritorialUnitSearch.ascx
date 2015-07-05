<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TerritorialUnitSearch.ascx.cs" Inherits="Controls_Acts_TerritorialUnitSearch" %>
<%@ Import Namespace="Kayflow.Model" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:LayoutGroup Caption="Фільтр" ColCount="1" GroupBoxDecoration="HeadingLine">
            <Items>
                <dx:LayoutItem Caption="Область">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="ddlUnits" runat="server" ValueType="System.Guid" Width="100%">
                                <ClientSideEvents ValueChanged="function(s, e){ regionValueChanged(s.GetValue()); }" />
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem ShowCaption="False" Visible="False">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSearch" runat="server" Width="300px">
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:LayoutGroup>
        <dx:LayoutItem ShowCaption="False">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTreeList ID="treeUnits" runat="server" Width="520px" AutoGenerateColumns="False"
                        ClientInstanceName="treeUnits" KeyFieldName="ID" ParentFieldName="ParentID"
                        OnCustomCallback="treeUnits_OnCustomCallback">
                        <Columns>
                            <dx:TreeListTextColumn Caption="Територіальна одиниця" FieldName="Name" Name="columnName" VisibleIndex="0">
                            </dx:TreeListTextColumn>
                        </Columns>
                        <Templates>
                            <DataCell>
                                <%# GetItemHTML((eUnitType)Eval("UnitType"), (Guid)Eval("ID"), Container.Text) %>
                            </DataCell>
                        </Templates>
                        <Settings VerticalScrollBarMode="Visible" ScrollableHeight="300"/>
                        <SettingsBehavior AutoExpandAllNodes="True"/>
                        <ClientSideEvents EndCallback="function(s, e){ treeUnits_EndCallback(s); }"></ClientSideEvents>
                    </dx:ASPxTreeList>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="110px">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxButton ID="btnCancel" runat="server" Text="Закрити">
                    </dx:ASPxButton>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
    </Items>
</dx:ASPxFormLayout>
<script type="text/javascript">
    function itemSelection(id) {
        DialogForm_CloseFrame(id);
    }

    var isFilter = false;
    function regionValueChanged(value) {
        var employeeID = <%= UserID %>;
        ASPxClientUtils.SetCookie('RegionValue_' + employeeID, value);
        isFilter = true;
        treeUnits.PerformCallback();
    }

    function treeUnits_EndCallback(s) {
        if (isFilter) {
            s.ExpandAll();
            isFilter = false;
        }
    }
</script>
