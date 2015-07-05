<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TerritorialUnitEdit.ascx.cs" Inherits="Controls_AdminControls_TerritorialUnitEdit" %>
<dx:ASPxFormLayout ID="frmEditForm" runat="server" AlignItemCaptionsInAllGroups="True" Width="100%">
    <Items>
        <dx:LayoutItem Caption="Тип одиниці" FieldName="UnitType">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxComboBox ID="ddlUnitType" runat="server" SkinID="Required" ValueType="System.Int32">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Оберіть тип територіальної одиниці" />
                        </ValidationSettings>
                        <ClientSideEvents ValueChanged="function(s, e){ ddlParentUnitType.PerformCallback(); }"></ClientSideEvents>
                    </dx:ASPxComboBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutItem Caption="Назва" FieldName="UnitName">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxTextBox ID="txtUnitName" runat="server" SkinID="Required" MaxLength="256">
                        <ValidationSettings ValidationGroup="vgSave">
                            <RequiredField ErrorText="Вкажіть назву" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </dx:LayoutItemNestedControlContainer>
            </LayoutItemNestedControlCollection>
        </dx:LayoutItem>
        <dx:LayoutGroup Caption="Підпорядкування" GroupBoxDecoration="HeadingLine">
            <Items>
                <dx:LayoutItem Caption="Тип" FieldName="ParentUnitType">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxComboBox ID="ddlParentUnitType" runat="server" SkinID="Required" 
                                ClientInstanceName="ddlParentUnitType" ValueType="System.Int32"
                                OnCallback="ddlParentUnitType_OnCallback"
                                NullText="Оберіть підпорядкування" OnInit="ddlParentUnitType_Init" >
                                <ValidationSettings ValidationGroup="vgSave">
                                    <RequiredField ErrorText="Оберіть тип підпорядкування" />
                                </ValidationSettings>
                                <ClientSideEvents ValueChanged="function(s, e){ ddlParentUnit.PerformCallback(); }"
                                    Validation="function(s, e){ ddlParentUnitType_Validate(s, e); }"></ClientSideEvents>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Тер. одиниця" FieldName="ParentID">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                            <dx:ASPxComboBox ID="ddlParentUnit" runat="server" SkinID="Required" ValueType="System.Guid"
                                ClientInstanceName="ddlParentUnit"
                                OnCallback="ddlParentUnit_OnCallback"
                                OnInit="ddlParentUnit_OnInit"
                                NullText="Оберіть підпорядкування" >
                                <ValidationSettings ValidationGroup="vgSave">
                                    <RequiredField ErrorText="Оберіть територіальну одиницю" />
                                </ValidationSettings>
                                <ClientSideEvents Validation="function(s, e){ ddlParentUnitType_Validate(s, e); }"></ClientSideEvents>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
            <CellStyle>
                <Paddings Padding="0px" />
            </CellStyle>
            <ParentContainerStyle>
                <Paddings Padding="0px" />
            </ParentContainerStyle>
        </dx:LayoutGroup>
        <dx:LayoutItem HorizontalAlign="Center" ShowCaption="False" Width="236px">
            <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnOk" runat="server" Text="Зберегти" ClientInstanceName="btnOk" />
                            </td>
                            <td style="padding-left: 15px;">
                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Закрити" />
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
    function ddlParentUnitType_Validate(s, e) {
        e.isValid = s.GetItemCount() == 0 || s.GetSelectedIndex() >= 0;
    }
</script>
