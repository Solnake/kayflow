<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StatusHistoryList.ascx.cs" Inherits="Controls_Acts_StatusHistoryList" %>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataDateColumn FieldName="OnDate" Caption="Дата" SortIndex="0" SortOrder="Descending" Width="100px" />
        <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="Працівник" Width="200" />
        <dx:GridViewDataTextColumn FieldName="Description" Caption="Стан справи" />
        <dx:GridViewDataColumn Width="32px">
            <DataItemTemplate>
                <dx:ASPxButton ID="btnDelete" runat="server" SkinID="Delete" Enabled='<%# CurrentEmployee.IsAdmin %>' />
            </DataItemTemplate>
        </dx:GridViewDataColumn>
    </Columns>
</dx:ASPxGridView>