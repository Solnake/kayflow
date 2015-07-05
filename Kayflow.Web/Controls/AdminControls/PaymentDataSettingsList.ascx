<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentDataSettingsList.ascx.cs" Inherits="Controls_AdminControls_PaymentDataSettingsList" %>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%"
    AutoGenerateColumns="False" KeyFieldName="PaymentFieldID"
    OnBeforePerformDataSelect="gridList_OnBeforePerformDataSelect"
    OnHtmlRowCreated="gridList_OnHtmlRowCreated"
    OnCustomCallback="gridList_OnCustomCallback">
    <Columns>
        <dx:GridViewDataCheckColumn FieldName="Show" Caption="Відображати" Width="100px">
            <DataItemTemplate>
                <dx:ASPxCheckBox ID="chShow" runat="server" />
            </DataItemTemplate>
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Назва колонки" />
    </Columns>
</dx:ASPxGridView>
<script type="text/javascript">
    window.ShowPaymentData_Change = function (value, id) {
        gfGetElement('<%=gridList.ClientID%>').PerformCallback(value + '|' + id);
    };
</script>