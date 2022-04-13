<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="LeanWeb.roles_ConsultReports.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <%-- syelamanchal commented for csrf --%>
    <%--<script type="text/javascript">
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
    </script>--%>
    <%-- syelamanchal commented for csrf --%>
    <div>
        <h3>Reports Section</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           
            <ContentTemplate>
                <div class="border padding-left padding-top padding-bottom">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <span class="bold">GEO</span></td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlGEO" runat="server" OnSelectedIndexChanged="ddlGEO_SelectedIndexChanged" AutoPostBack="true"/>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div id="dvData" runat="server">
                    <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns="False"
                        AllowPaging="False"
                        PageSize="20"
                        DataKeyNames="ReportName"
                        CssClass="bordered min-width tablesorter"
                        Width="100%">
                        <Columns>
                            <%-- <%= System.Web.Helpers.AntiForgery.GetHtml() %>--%>
                            <asp:HyperLinkField DataNavigateUrlFields="ReportServer,ReportPath" DataNavigateUrlFormatString="{0}{1}" ItemStyle-Font-Underline="true" ItemStyle-ForeColor="Blue"
                                DataTextField="ReportName" HeaderText="Name" SortExpression="ReportName" NavigateUrl="{0}" Target="_blank"></asp:HyperLinkField>
                            <asp:TemplateField HeaderText="Description" SortExpression="ReportDescription">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("ReportDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Version" HeaderText="Version" SortExpression="Version" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="ReportServer" HeaderText="Server" SortExpression="ReportServer"
                                Visible="False" />
                            <asp:BoundField DataField="ReportPath" HeaderText="Path" SortExpression="ReportPath"
                                Visible="False" />
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <th scope="col">Name
                                    </th>
                                    <th scope="col">Description
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">No reports found.
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
