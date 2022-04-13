<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="InventoryDockArea.aspx.cs" Inherits="LeanWeb.role_DailyUploads.InventoryDockArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Upload Current Inventory At Shipping Area</h3>
    <div class="border padding-left padding-top padding-bottom">
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small">
                        <h4 class="padding-top-small">
                            Select File To Upload (.xls/.xlsx)<br />
                        </h4>
                    </td>
                    <td class="padding-top-small">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td class="padding-top-small">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="padding-top-small" colspan="3">
                        <asp:LinkButton ID="LinkButton1" runat="server" href="\role_DailyUploads\Templates\Inventory_Dock_Area_Shipping.xlsx">Click Here To Download The Latest Template</asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div id="div2">
        <asp:GridView ID="gvInventoryDockArea" runat="server"
            AllowPaging="true" CssClass="bordered min-width tablesorter" AutoGenerateColumns="false"
            OnPageIndexChanging="gvInventoryDockArea_PageIndexChanging"
            AllowSorting="True" PageSize="20"
            Width="100%">
            <Columns>
                <asp:BoundField DataField="idLocalizationMaterial" HeaderText="Loc_PartNo"></asp:BoundField>
                <asp:BoundField DataField="idLocalization" HeaderText="Loc"></asp:BoundField>
                <asp:BoundField DataField="Localization_Name" HeaderText="Loc Name"></asp:BoundField>
                <asp:BoundField DataField="idMaterial" HeaderText="Material"></asp:BoundField>
                <asp:BoundField DataField="Pallet_ID" HeaderText="Pallet Id"></asp:BoundField>
                <asp:BoundField DataField="Pallet_No" HeaderText="No"></asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblExecutionResult" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnProcess" runat="server" Text="Process Data" OnClick="btnProcess_Click" Visible=" false" />
    </div>
</asp:Content>
