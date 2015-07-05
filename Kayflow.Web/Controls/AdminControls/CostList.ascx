<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CostList.ascx.cs" Inherits="Controls_AdminControls_CostList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataCheckColumn FieldName="Show" Caption=" " Width="40px"/>
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Вид витрат" />
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