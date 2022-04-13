<%@ Page  Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeFile="PlannedHeijunkaMassUpload.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.PlannedHeijunkaMassUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <h3>Mass Update Heijunka Line</h3>

    <div class="border padding-left padding-top padding-bottom">
        <table>
            <tbody>
                <tr>
                    <td class="padding-top-small">
                        <h4 class="padding-top-small">
                            Select File To Uplolad (.xlsx)<br />
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
                        <asp:LinkButton ID="LinkButton1" runat="server" href="\LeanApplication\LeanWeb\role_ModifyVKB\Templates\Planned_Heijunka_Mass_Upload.xls">Click Here To Download The Latest Template</asp:LinkButton> 
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div id="idData">
        <asp:GridView ID="gvData" runat="server"
            AutoGenerateColumns="true"
            AllowPaging="True"
            CssClass="bordered min-width tablesorter"
            OnPageIndexChanging="gvData_PageIndexChanging"
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
                <tr>
                    <td class="padding-top-small">
                        <asp:LinkButton ID="lbtnBack" runat="server" Visible="false" OnClick="lbtnBack_Click">Back to Previous Page</asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

