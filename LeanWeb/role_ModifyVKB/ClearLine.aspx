<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeFile="ClearLine.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.ClearLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script>
        $(function () {
            $("#dialog-message").dialog({
                autoOpen: false,
                modal: true,
                width: "auto",
                height: "700",
                buttons: {
                    Update: function () {
                        $("[id*=btnSaveCapabilities]").click();
                    },
                }
            });
            $("[id$=btnCapablity]").click(function () {
                $("#dialog-message").dialog("open");
                return false;
            });
        });

        $(function () {
            $("[id$=txtFechaCaptura]").datepicker({
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true,
                altField: "[id$=HiddenField1]",
                // The format you want
                altFormat: "mm/dd/yy",
            //}).datepicker("setDate", new Date());
        }).datepicker();
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
    <script>
        function ValidateData() {
            var Quantity, Line;
            Quantity = $("[id$=txtQty]").val();
            Line = $("[id$=ddlLineCapabilities]").val();
            if (Quantity == '') {
                alert("Please Enter Quantity");
                return false;
            }
            else {
                if (isNaN(Quantity)) {
                    alert("Enter a valid Quantity");
                    return false;
                }
                else {
                    var url = window.location.href;
                    var index = 0;
                    var newURL = url;
                    index = url.indexOf('?');
                    if (index == -1) {
                        index = url.indexOf('#');
                    }
                    if (index != -1) {
                        url = url.substring(0, index);
                    }
                    newURL = url + '?qty=' + Quantity + '&line=' + Line;
                    window.open(newURL, "_blank");
                    location.reload(false);
                    return false;
                }
            }
        }
    </script>
        <h3>Clear Planned Heijunka Line</h3>
     <div id="Header" runat="server" class="border padding-left padding-top padding-bottom">
         <asp:HiddenField ID="HiddenField1" runat="server" />
            <table>
                <tr>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label1" runat="server" Text="Line:" />
                    </td>
                    <td align="left" class="padding-top-small">
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                ConnectionString="<%$ ConnectionStrings:PullSystemConnectionString %>"
                                SelectCommand="SELECT DISTINCT Planner, Line FROM Line INNER JOIN [VKB_Input] ON [Line].[idLine]=[VKB_Input].[idLine] WHERE [Line].idLine&lt;&gt;0 and Line.Lean_Application=@Lean_App  ORDER BY [Planner],[Line]; ">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App"
                                        PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>--%>
                        <asp:DropDownList ID="ddlLine" runat="server" AutoPostBack="true"  />
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                    </td>
                    <td align="left" class="padding-top-small">
                        
                        <asp:TextBox ID="txtFechaCaptura" runat="server"  AutoPostBack="true"  />
                        <%--<asp:Image ID="imgCalendar" runat="server" ImageUrl="~/images/Calendar.ico" />--%>
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" PopupPosition="Right" runat="server" TargetControlID="txtFechaCaptura" PopupButtonID="imgCalendar" Format="dddd MMMM dd , yyyy" CssClass="myCalendar" />--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="padding-top-small">
                        </td>
                    <td align="left" class="padding-top-small">
                        &nbsp;</td>
                    <td align="left" class="padding-top-small" colspan="2">
                        <asp:Button ID="btnShow" runat="server" Text="Clear" OnClick="btnShow_Click"   />
                        &nbsp;&nbsp;
                        
                    </td>
                </tr>
                <tr>
                    <td align="left" class="padding-top-small">
                        </td>
                    <td align="center" class="padding-top-small" colspan="3">
            <asp:Label ID="LabelStatus" runat="server" Text="" />
                    </td>
                </tr>
            </table>
          
        </div>
</asp:Content>
