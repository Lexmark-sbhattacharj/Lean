<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="VirtualKanbanChecklist.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.VirtualKanbanChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <%--<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />--%>
    <script>
        $(function () {
            //$("[id$=txtFilter]").datepicker();
            $("#ContentMain_txtFilter").datepicker();
        });
    </script>
    <div>
        <h3>Processed VKB Checklist</h3>
        <div class="border padding-left padding-top padding-bottom">
            <table>
                <tbody>
                    <tr>
                        <td class="padding-top-small"><span class="bold">Date: </span></td>
                        <td class="padding-top-small">
                            <asp:TextBox ID="txtFilter" runat="server" />
                        </td>
                        <td class="padding-top-small">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Visible="True" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="dvData" runat="server">
                    <asp:GridView ID="gvVKBChecklist" runat="server" AutoGenerateColumns="False"
                        AllowPaging="False"
                        PageSize="20"
                        DataKeyNames="Line"
                        CssClass="bordered min-width tablesorter"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Line" HeaderText="Line" InsertVisible="False"
                                ReadOnly="True" SortExpression="idLine" Visible="False" />
                            <asp:TemplateField HeaderText="Line" SortExpression="Line">
                                <ItemTemplate>
                                    <asp:Label ID="lblLine" runat="server" Text='<%# Bind("Line") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Processed" SortExpression="Processed">
                                <ItemTemplate>
                                    <asp:Label ID="LabelProcessed" runat="server" Text='<%# Bind("Processed") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Final Version" SortExpression="FinalVersion">
                                <ItemTemplate>
                                    <asp:Label ID="LabelFinalVersion" runat="server" Text='<%# Bind("FinalVersion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <th scope="col">Line
                                    </th>
                                    <th scope="col">Processed
                                    </th>
                                    <th scope="col">Final Version
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">No records found.
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
