<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="unblockFinalVKB.aspx.cs" Inherits="LeanWeb.role_DefineParameters.unblockFinalVKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script>
        $(function () {
            $("[id$=txtFilter]").datepicker({
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true,
                altField: "[id$=HiddenField1]",
                // The format you want
                altFormat: "mm/dd/yy",
            }).datepicker("setDate", new Date());
            return false;
        });
    </script>
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
        <h3>Block/Unblock Final VKB</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="border padding-left padding-top padding-bottom">
            <table>
                <tbody>
                    <tr>
                        <td class="padding-top-small"><span class="bold">Date: </span></td>
                        <td class="padding-top-small">
                            <asp:TextBox ID="txtFilter" runat="server" ReadOnly="true" />
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Visible="True" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="dvData" runat="server">
                    <asp:GridView ID="gvUnblockFinalVKB" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="20"
                        DataKeyNames="idLine"
                        EnableModelValidation="True"
                        CssClass="bordered min-width tablesorter"
                        OnRowEditing="gvUnblockFinalVKB_RowEditing"
                        OnRowCancelingEdit="gvUnblockFinalVKB_RowCancelingEdit"
                        OnRowUpdating="gvUnblockFinalVKB_RowUpdating"
                        OnPageIndexChanging="gvUnblockFinalVKB_PageIndexChanging"
                        ShowFooter="false"
                        Width="100%"
                        Visible="false">
                        <Columns>
                            <asp:BoundField DataField="idLine" ShowHeader="false" Visible="false" ReadOnly="true" />
                            <asp:TemplateField HeaderText="idLine" SortExpression="idLine" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblidLine" runat="server" Text='<%# Bind("idLine") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" SortExpression="Date" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblDateEdit" runat="server" Text='<%# Bind("Date") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Final">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkFinalView" runat="server" Checked='<%# Bind("Final_Version") %>' HeaderText="Final" Enabled="false" />
                                    <%--EVAL can also be used--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkFinalEdit" runat="server" Checked='<%# Bind("Final_Version") %>' HeaderText="Final" Enabled="true" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Line" SortExpression="Line">
                                <ItemTemplate>
                                    <asp:Label ID="lblLine" runat="server" Text='<%# Bind("Line") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/common/images/srd2013/undo.png"
                                        CommandName="Cancel" ToolTip="Cancel" AlternateText="Cancel"></asp:ImageButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                        ToolTip="Edit" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/cancel.png"
                                        CommandName="Delete" ToolTip="Delete" AlternateText="Delete" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClientClick="javascript: return confirm('Are you sure, you want to delete this?')"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <th scope="col">Final
                                    </th>
                                    <th scope="col">Line
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">No records found.
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ValidationSummary ID="EditValidationSummery" runat="server"
                        ShowSummary="false"
                        ShowMessageBox="true"
                        HeaderText="Edit Mode"
                        DisplayMode="List"
                        ValidationGroup="Edit" />

                    <asp:ValidationSummary ID="AddValidationSummery" runat="server"
                        ShowSummary="false"
                        ShowMessageBox="true"
                        HeaderText="Add Mode"
                        DisplayMode="List"
                        ValidationGroup="Add" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>