<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NotesList.ascx.cs" Inherits="Controls_Acts_NotesList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataDateColumn FieldName="OnDate" Caption="Дата" SortIndex="0" SortOrder="Descending" Width="100px" />
        <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="Працівник" Width="200" />
        <dx:GridViewDataTextColumn FieldName="Description" Caption="Причина затримки" />
        <dx:GridViewDataColumn Width="32px">
            <DataItemTemplate>
                <dx:ASPxButton ID="btnDelete" runat="server" SkinID="Delete" Enabled='<%# CurrentEmployee.IsAdmin %>' />
            </DataItemTemplate>
        </dx:GridViewDataColumn>
    </Columns>
</dx:ASPxGridView>
