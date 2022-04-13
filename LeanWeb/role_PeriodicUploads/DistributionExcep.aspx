<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="DistributionExcep.aspx.cs" Inherits="LeanWeb.role_PeriodicUploads.DistributionExcep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Distribution Exceptions</h3>
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
                    <td class="padding-top-small">
                        <asp:LinkButton ID="LinkButton1" runat="server" href="\role_PeriodicUploads\Templates\Distribution_Exception.xlsx">Click Here To Download The Latest Template</asp:LinkButton>
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
        <asp:GridView ID="gvDistributionException" runat="server"
            AllowPaging="true" CssClass="bordered min-width tablesorter" AutoGenerateColumns="True"
            AllowSorting="True" PageSize="20" OnPageIndexChanging="gvDistributionException_PageIndexChanging"
            Width="100%">
        </asp:GridView>
        <br />
        <asp:Button ID="btnProcess" runat="server" Text="Process XLS File" OnClick="btnProcess_Click" Visible=" false" />
    </div>
</asp:Content>
