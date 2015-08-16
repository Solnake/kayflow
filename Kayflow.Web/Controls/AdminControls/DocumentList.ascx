<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocumentList.ascx.cs" Inherits="Controls_AdminControls_DocumentList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataCheckColumn FieldName="Show" Caption=" " Width="40px"/>
        <dx:GridViewDataTextColumn FieldName="OrdNum" Caption="№ п/п" Width="80px" SortIndex="0" SortOrder="Ascending" />
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Вид витрат" />
        <dx:GridViewDataTextColumn FieldName="SetName" Caption="Тип даних" Width="100px" />
        <dx:GridViewDataCheckColumn FieldName="ShowComments" Caption="Коментар" Width="100px"/>
        <dx:GridViewDataTextColumn FieldName="GroupName" Caption="Група" GroupIndex="0" />
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