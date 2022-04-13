<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="DailyUploadsChecklist.aspx.cs" Inherits="LeanWeb.role_DailyUploads.DailyUploadsChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link rel="stylesheet" href="http://localhost:50643/code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
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
    <div>

        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
        </script>
        <asp:ScriptManager ID="ScriptManager1" ScriptMode="release" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <h3>Daily Uploads Checklist</h3>
        <div class="border padding-left padding-top padding-bottom" id="Header" runat="server">
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFilter" runat="server" ReadOnly="true" />
                            &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnShow" runat="server" Text="Search" OnClick="btnShow_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCleanup" runat="server" Text="Files Cleanup" OnClick="btnCleanup_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div>
            <asp:Label ID="LabelStatus" runat="server"></asp:Label>
        </div>
        <br />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="div2" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvDailyUploadsChecklist" runat="server"
                        Visible="false"
                        AutoGenerateColumns="False"
                        Caption='<b>Uploaded Information</b>'
                        CssClass="bordered min-width tablesorter"
                        DataKeyNames="Type"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="idLine" HeaderText="idLine" InsertVisible="False"
                                ReadOnly="True" SortExpression="idLine" Visible="False" />
                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uploaded" SortExpression="Uploaded">
                                <ItemTemplate>
                                    <asp:Label ID="LabelUploaded" runat="server" Text='<%# Bind("Uploaded") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" SortExpression="Upload_Date">
                                <ItemTemplate>
                                    <asp:Label ID="LabelUpload_Date" runat="server" Text='<%# Bind("Upload_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
