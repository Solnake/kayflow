<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActActionList.ascx.cs" Inherits="Controls_AdminControls_ActActionList" %>
<div class="list_button">
    <dx:ASPxButton runat="server" ID="btnAdd" AutoPostBack="False" Text="Додати" SkinID="Add" />
</div>
<dx:ASPxGridView ID="gridList" runat="server" Width="100%" ClientInstanceName="gridList"
    AutoGenerateColumns="False" KeyFieldName="ID"
    OnHtmlDataCellPrepared="gridList_OnHtmlDataCellPrepared">
    <Columns>
        <dx:GridViewDataCheckColumn FieldName="Show" Caption=" " Width="40px"/>
        <dx:GridViewDataTextColumn FieldName="OrdNum" Caption="№ п/п" Width="80px" SortIndex="0" SortOrder="Ascending" />
        <dx:GridViewDataTextColumn FieldName="Name" Caption="Назва етапу" />
        <dx:GridViewDataTextColumn FieldName="AlertDays" Caption="Абсолютний термін" Width="100px"/>
        <dx:GridViewDataTextColumn FieldName="RelativeAlertDays" Caption="Відносний термін" Width="100px"/>
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