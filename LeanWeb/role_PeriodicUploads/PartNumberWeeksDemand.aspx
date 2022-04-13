<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="PartNumberWeeksDemand.aspx.cs" Inherits="LeanWeb.role_PeriodicUploads.PartNumberWeeksDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Upload Part Number Weekly Historical Demand</h3>
    <div class="border padding-left padding-top padding-bottom">
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small" colspan="2">
                        <h4 class="padding-top-small">Select File To Upload (.xlsx)<br />
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
                        <p>
                            <b>Note: </b>Recommended no more than ten weeks per upload, for a faster response.<br />
                        </p>
                    </td>
                </tr>
                <tr>
                    <td class="padding-top-small" colspan="3">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" href="\LeanApplication\LeanWeb\role_PeriodicUploads\Templates\Weekly_Demand.xlsx">Click Here To Download The Latest Template</asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="LabelStatus" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <br />
    <div id="div2">
        <asp:GridView ID="gvPartNumber" runat="server"
            AllowPaging="true" CssClass="bordered min-width tablesorter" AutoGenerateColumns="True"
            AllowSorting="True" PageSize="20" OnPageIndexChanging="gvPartNumber_PageIndexChanging"
            Width="100%">
        </asp:GridView>
        <br />
        <asp:Button ID="btnProcess" runat="server" Text="Process XLS File" OnClick="btnProcess_Click" Visible="false" />
    </div>
</asp:Content>
