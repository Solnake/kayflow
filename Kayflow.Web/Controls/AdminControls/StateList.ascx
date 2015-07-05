<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StateList.ascx.cs" Inherits="Controls_AdminControls_StateList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Статус" />
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