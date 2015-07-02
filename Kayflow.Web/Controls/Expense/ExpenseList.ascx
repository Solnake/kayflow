<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExpenseList.ascx.cs" Inherits="Controls_Expense_ExpenseList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataDateColumn FieldName="OnDate" Caption="Дата" SortIndex="0" SortOrder="Descending" Width="100px"/>
        <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="Землевпорядник" />
        <dx:GridViewDataTextColumn FieldName="Distance" Caption="Дистанція, км." Width="100px"/>
        <dx:GridViewDataTextColumn FieldName="Summ" Caption="Сума витрат" Width="100px">
            <PropertiesTextEdit DisplayFormatString="n"></PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataColumn Width="64px">
            <DataItemTemplate>
                <table>
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnEdit" runat="server" SkinID="Edit" />
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnDelete" runat="server" SkinID="Delete"/>
                        </td>
                    </tr>
                </table>
            </DataItemTemplate>
        </dx:GridViewDataColumn>
    </Columns>
</dx:ASPxGridView>