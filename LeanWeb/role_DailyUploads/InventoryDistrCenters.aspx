<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="InventoryDistrCenters.aspx.cs" Inherits="LeanWeb.role_DailyUploads.InventoryDistrCenters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Upload Current Inventory At All Distribution Centers</h3>
    <div class="border padding-left padding-top padding-bottom">
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small">
                        <h4 class="padding-top-small">
                            Select File To Upload (.txt)<br />
                        </h4>
                    </td>
                    <td class="padding-top-small">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="padding-top-small">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
    </div>
    <div id="div2" runat="server">
        <table style="width: 100%">
            <tr>
                <td align="center">
                    <asp:GridView ID="GridView1" Visible="false" runat="server"
                        AutoGenerateColumns="False" AllowPaging="true" CssClass="bordered min-width tablesorter"
                        GridLines="None" AllowSorting="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="idLocalizationMaterial" HeaderText="Loc_PartNo"></asp:BoundField>
                            <asp:BoundField DataField="idLocalization" HeaderText="Loc"></asp:BoundField>
                            <asp:BoundField DataField="idMaterial" HeaderText="Material"></asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <br />
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnProcess" runat="server" Text="Process TXT File" OnClick="btnProcess_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
