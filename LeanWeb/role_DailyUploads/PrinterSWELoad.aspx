<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="PrinterSWELoad.aspx.cs" Inherits="LeanWeb.role_DailyUploads.PrinterSWELoad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Printer Mfg SWE Demand</h3>
    <div class="border padding-left padding-top padding-bottom">
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small" colspan="2">
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
                        <asp:LinkButton ID="LinkButton1" runat="server" href="\LeanApplication\LeanWeb\role_DailyUploads\Templates\Printer_SWE_Load.xlsx">Click Here To Download The Latest Template</asp:LinkButton>
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
    <div id="idData">
        <asp:GridView ID="gvData" runat="server"
            AutoGenerateColumns="true"
            AllowPaging="True"
            CssClass="bordered min-width tablesorter"
            Width="100%">
        </asp:GridView>
    </div>
    <br />
    <div>
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small">
                        <asp:Button ID="btnProcess" runat="server" Text="Process Data" Visible="False" OnClick="btnProcess_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
