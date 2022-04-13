<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="User_Sites_Assignment.aspx.cs" Inherits="LeanWeb.roles_UserControl.User_Sites_Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <script type="text/javascript">
        function ieAjaxBeginRequest(sender, args) {
            window.status = "Please Wait...";
            document.body.style.cursor = "wait";
        }

        function ieAjaxPageLoaded(sender, args) {
            window.status = "Done";
            document.body.style.cursor = "default";
        }
    </script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
    </script>
    <div>
        <h3>User Sites Maintenance</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="border padding-left padding-top padding-bottom">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <span class="bold">Sites</span></td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlSite" runat="server"/>

                                </td>
                                <td class="padding-top-small">
                                    <asp:Button ID="btnAddSite" runat="server" Text="Add Site In User" OnClick="btnAddSite_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div>
                    <asp:GridView Width="100%" ID="gvList" runat="server"
                        AutoGenerateColumns="False"
                        CssClass="bordered min-width tablesorter"
                        GridLines="None" AllowPaging="True" PageSize="20"
                        EmptyDataText="No sites belong to this user."
                        OnRowDeleting="gvList_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/cancel.png"
                                        CommandName="Delete" ToolTip="Borrar"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lean_Application"
                                SortExpression="Lean_Application">
                                <EditItemTemplate>
                                    <asp:Label ID="Lean_Application" runat="server" Text='<%# Eval("Lean_Application") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Lean_Application" runat="server" Text='<%# Bind("Lean_Application") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div>
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
