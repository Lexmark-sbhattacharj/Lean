<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Capability.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.Capability" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/footer.css" />
    <%--<link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/style.css" />--%>
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/globalReset.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/lex-1280-grid-fixed.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/twelveCol-layout.css" />
    <link rel="stylesheet" type="text/css" media="all" href="../App_Themes/common/css/srd2013/family-select.css" />
    <link rel="stylesheet" type="text/css" media="all" href="../App_Themes/common/css/srd2013/lexmark-wip.css" />
    <link rel="stylesheet" type="text/css" media="all" href="../App_Themes/common/css/srd2013/be-lexmark-top.css" />
    <link rel="stylesheet" type="text/css" media="all" href="../App_Themes/common/css/srd2013/be-lexmark-table.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/menu-styles.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/lxk-framework.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/header-footer.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/utilities.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/visibility.css" />
    <link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/slide-in-panel.css" />
    <%--<link rel="stylesheet" href="App_Themes/common/css/srd2013/style123.css" />--%>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script src="../App_Themes/common/js/srd2013/jquery.js"></script>
    <script src="../App_Themes/common/js/srd2013/jquery-ui.js"></script>
    <script src="../App_Themes/common/js/srd2013/modernizr.js"></script>
    <script type="text/javascript" src="../App_Themes/common/js/srd2013/jquery.ba-throttle-debounce.js"></script>
    <script type="text/javascript" src="../App_Themes/common/js/srd2013/modernizr-2.6.3.js"></script>
    <script src="../App_Themes/common/js/srd2013/be-lexmark.js"></script>
    <script type="text/javascript" src="../App_Themes/common/js/srd2013/require.js"></script>
    <script type="text/javascript" src="../App_Themes/common/js/srd2013/main.js"></script>
    <%--<script type="text/javascript" src="App_Themes/common/js/srd2013/calendar.js"></script>--%>

    <link rel="shortcut icon" href="../App_Themes/common/images/srd2013/lexmark-symbol-desktop-32x32.png" />

    <title>Capacity Update</title>

</head>
        <script type="text/javascript">
            function WindowSize() {
                var width = $(window).width() - 25;
                $("#main").width(width);
            }
    </script>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="main" runat="server" style="position:fixed; float:left; height:100%; overflow:auto; width:100%; right:0; bottom:0; left:0;">
                <br />
                <h3>Capacity by Line in Units</h3>
                <div class="border padding-left padding-top padding-bottom" align="center">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblLine" runat="server" Text="Line:" />
                                </td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlLine" runat="server" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblQty" runat="server" Text="Qty:" />
                                    &nbsp;
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtQty" runat="server" />
                                    <br />
                                </td>
                                <br />
                            </tr>
                            <tr>
                                <td class="padding-top-small" colspan="2">
                                    <asp:Label ID="lblNotSaved" runat="server"
                                        Text="" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    &nbsp;&nbsp;
                                </td>
                                <td class="padding-top-small" align="center">
                                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                    <br />
                <div id="div2">
                    <asp:GridView ID="GVLine" Visible="true" runat="server" AutoGenerateColumns="true"
                        CssClass="bordered min-width tablesorter"
                        Width="90%">
                    </asp:GridView>
                </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
