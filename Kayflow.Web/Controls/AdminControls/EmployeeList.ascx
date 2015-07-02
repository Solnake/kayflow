<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeList.ascx.cs" Inherits="Controls_AdminControls_EmployeeList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Працівник" />
        <dx:GridViewDataTextColumn FieldName="Login" Caption="Логін" />
        <dx:GridViewDataCheckColumn FieldName="IsAdmin" Caption="Адміністратор офісу" Width="100px"/>
        <dx:GridViewDataCheckColumn FieldName="SuperAdmin" Caption="Адміністратор системи" Width="100px"/>
        <dx:GridViewDataCheckColumn FieldName="IsBlocked" Caption="Заблокований" Width="100px"/>
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