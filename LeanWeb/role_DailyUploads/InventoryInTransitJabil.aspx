<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="InventoryInTransitJabil.aspx.cs" Inherits="LeanWeb.role_DailyUploads.InventoryInTransitJabil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Upload Current Inventory Jabil In Transits</h3>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" href="\role_DailyUploads\Templates\Inventory_InTransit_Jabil.xlsx">Click Here To Download The Latest Template</asp:LinkButton>
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
        <asp:GridView ID="gvInventoryInTransitJabil" runat="server"
            AllowPaging="true" CssClass="bordered min-width tablesorter" AutoGenerateColumns="True"
            AllowSorting="True" PageSize="20" OnPageIndexChanging="gvInventoryInTransitJabil_PageIndexChanging"
            Width="100%">
        </asp:GridView>
        <br />
        <asp:Button ID="btnProcess" runat="server" Text="Process Data" OnClick="btnProcess_Click" Visible=" false" />
    </div>
</asp:Content>
