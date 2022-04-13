<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="MyVKB.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.MyVKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script>
        $(function () {
            //$("#dialog-message").dialog({
            //    autoOpen: false,
            //    modal: true,
            //    width: "auto",
            //    height: "700",
            //    buttons: {
            //        Update: function () {
            //            $("[id*=btnSaveCapabilities]").click();
            //        },
            //    }
            //});
            //$("[id$=btnCapablity]").click(function () {
            //    $("#dialog-message").dialog("open");
            //    return false;
            //});
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
        //function ValidateData() {
        //    var Quantity, Line;
        //    Quantity = $("[id$=txtQty]").val();
        //    Line = $("[id$=ddlLineCapabilities]").val();
        //    if (Quantity == '') {
        //        alert("Please Enter Quantity");
        //        return false;
        //    }
        //    else {
        //        if (isNaN(Quantity)) {
        //            alert("Enter a valid Quantity");
        //            return false;
        //        }
        //        else {
        //            var url = window.location.href;
        //            var index = 0;
        //            var newURL = url;
        //            index = url.indexOf('?');
        //            if (index == -1) {
        //                index = url.indexOf('#');
        //            }
        //            if (index != -1) {
        //                url = url.substring(0, index);
        //            }
        //            newURL = url + '?qty=' + Quantity + '&line=' + Line;
        //            window.open(newURL, "_blank");
        //            location.reload(false);
        //            return false;
        //        }
        //    }
        //}
    </script>
 <%--    <div id="dialog-message" title="Capabilities">--%>
       <div id="PopUpcontainer" runat="server" title="Capabilities">
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <div id="main">
            <br />
            <asp:GridView ID="GVLine" Visible="true" runat="server" AutoGenerateColumns="true"
                CssClass="bordered min-width tablesorter"
                Width="40%">
            </asp:GridView>
        </div>
        <br />
        <div class="border padding-left padding-top padding-bottom" align="center">
            <table>
                <tbody>
                    <tr>
                        <td class="padding-top-small">
                            <asp:Label ID="lblLine" runat="server" Text="Line:" />
                        </td>
                        <td class="padding-top-small">
                            <asp:DropDownList ID="ddlLineCapabilities" runat="server" />
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
                    </tr>
                    <tr>
                        <td class="padding-top-small" colspan="2">
                            <asp:Label ID="lblError" runat="server"
                                Text="" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td class="padding-top-small">
                            <%--<asp:Button ID="btnSaveCapabilities" runat="server" Text="Save" OnClick="btnSaveCapabilities_Click" OnClientClick="ValidateData()" UseSubmitBehavior="false" Style="display: none" />--%>
                             <asp:Button ID="btnSaveCapabilities" runat="server" Text="Save" OnClick="btnSaveCapabilities_Click" />
                            &nbsp;&nbsp;
                        </td>
                        <td class="padding-top-small" align="center">
                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click"/>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div id="content-container-two-column" style="right: 0px; top: 0px; height: auto;">
        <h3>Heijunka VKB</h3>
        <p></p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>

        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
        </script>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <asp:HiddenField ID="LEAN_APP" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div id="Header" runat="server" class="border padding-left padding-top padding-bottom">
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
                        <asp:DropDownList ID="ddlLine" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" />
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:TextBox ID="txtFechaCaptura" runat="server" OnTextChanged="txtFechaCaptura_TextChanged" AutoPostBack="true" />
                        <%--<asp:Image ID="imgCalendar" runat="server" ImageUrl="~/images/Calendar.ico" />--%>
                        <%--<cc1:CalendarExtender ID="CalendarExtender1" PopupPosition="Right" runat="server" TargetControlID="txtFechaCaptura" PopupButtonID="imgCalendar" Format="dddd MMMM dd , yyyy" CssClass="myCalendar" />--%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label2" runat="server" Text="Filter:" />
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:TextBox ID="txtFilter" runat="server" />
                    </td>
                    <td align="left" class="padding-top-small" colspan="2">
                        <asp:Button ID="btnShow" runat="server" Text="Search" OnClick="btnShow_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnCapablity" runat="server" Text="Capacity" OnClick="btnCapablity_Click" />
                        <asp:HiddenField ID="HFCapability" Value="0" runat="server" />
                       
                    </td>
                </tr>
                <tr>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="lblNotSaved" runat="server" Text="Modifications will not be autosaved" ForeColor="Red" Visible="false" />
                    </td>
                    <td align="center" class="padding-top-small" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkAutoCal" runat="server" AutoPostBack="true" Checked="false" OnCheckedChanged="chkAutoCal_CheckedChanged" Text="Include Sales Orders in Yellow and Green Recommendation" Visible="false" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:CheckBox ID="chkAutoSave" runat="server" Text="Auto Recalculate and Save Modification" Checked="true" Visible="true" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div id="Status">
            <asp:Label ID="LabelStatus" runat="server" Text="" />
        </div>
        <br />
                <div id="divVKB" visible="false" style="position: relative; width: 1155px; height: auto; overflow: scroll; margin-bottom: 0px;" runat="server">
                    <table width="55000px">
                        <tr>
                            <td align="left">
                                <asp:GridView ID="gvVKB" Visible="false" runat="server" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="#284775" margin-bottom="0px"><tr><td><font color="white"><b>Virtual Kanban Board</b></font></td></tr></table>'
                                    AutoGenerateColumns="False" CellPadding="0" AllowPaging="False" Font-Names="sans-serif" Font-Size="XX-Small" ShowHeader="false" ShowFooter="false" OnDataBound="gvVKB_DataBound"
                                    ForeColor="#333333" GridLines="Vertical" AllowSorting="False">
                                    <RowStyle BackColor="White" ForeColor="#333333" Height="2px"/>
                                    <Columns>
                                        <asp:BoundField DataField="Field" HeaderText="Field">
                                            <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                            <ItemStyle Font-Names="sans-serif" Font-Size="XX-Small" HorizontalAlign="Left" Font-Bold="true" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nothing_1" HeaderText="Nothing_1">
                                            <ItemStyle HorizontalAlign="Center" Width="3px" BackColor="DarkGray" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Material_1" SortExpression="Material_1" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_1" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_1") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_2" SortExpression="Material_2" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_2" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_2") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_3" SortExpression="Material_3" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_3" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_3") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_4" SortExpression="Material_4" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_4" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_4") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_5" SortExpression="Material_5" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_5" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_5") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_6" SortExpression="Material_6" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_6" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_6") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_7" SortExpression="Material_7" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_7" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_7") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_8" SortExpression="Material_8" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_8" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_8") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_9" SortExpression="Material_9" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_9" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_9") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_10" SortExpression="Material_10" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_10" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_10") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_11" SortExpression="Material_11" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_11" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_11") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_12" SortExpression="Material_12" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_12" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_12") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_13" SortExpression="Material_13" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_13" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_13") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_14" SortExpression="Material_14" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_14" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_14") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_15" SortExpression="Material_15" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_15" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_15") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_16" SortExpression="Material_16" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_16" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_16") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_17" SortExpression="Material_17" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_17" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_17") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_18" SortExpression="Material_18" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_18" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_18") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_19" SortExpression="Material_19" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_19" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_19") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_20" SortExpression="Material_20" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_20" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_20") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_21" SortExpression="Material_21" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_21" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_21") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_22" SortExpression="Material_22" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_22" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_22") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_23" SortExpression="Material_23" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_23" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_23") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_24" SortExpression="Material_24" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_24" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_24") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_25" SortExpression="Material_25" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_25" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_25") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_26" SortExpression="Material_26" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_26" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_26") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_27" SortExpression="Material_27" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_27" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_27") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_28" SortExpression="Material_28" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_28" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_28") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_29" SortExpression="Material_29" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_29" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_29") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_30" SortExpression="Material_30" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_30" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_30") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_31" SortExpression="Material_31" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_31" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_31") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_32" SortExpression="Material_32" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_32" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_32") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_33" SortExpression="Material_33" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_33" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_33") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_34" SortExpression="Material_34" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_34" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_34") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_35" SortExpression="Material_35" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_35" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_35") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_36" SortExpression="Material_36" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_36" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_36") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_37" SortExpression="Material_37" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_37" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_37") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_38" SortExpression="Material_38" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_38" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_38") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_39" SortExpression="Material_39" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_39" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_39") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_40" SortExpression="Material_40" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_40" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_40") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_41" SortExpression="Material_41" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_41" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_41") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_42" SortExpression="Material_42" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_42" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_42") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_43" SortExpression="Material_43" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_43" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_43") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_44" SortExpression="Material_44" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_44" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_44") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_45" SortExpression="Material_45" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_45" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_45") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_46" SortExpression="Material_46" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_46" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_46") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_47" SortExpression="Material_47" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_47" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_47") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_48" SortExpression="Material_48" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_48" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_48") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_49" SortExpression="Material_49" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_49" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_49") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_50" SortExpression="Material_50" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_50" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_50") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_51" SortExpression="Material_51" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_51" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_51") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_52" SortExpression="Material_52" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_52" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_52") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_53" SortExpression="Material_53" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_53" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_53") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_54" SortExpression="Material_54" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_54" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_54") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_55" SortExpression="Material_55" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_55" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_55") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_56" SortExpression="Material_56" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_56" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_56") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_57" SortExpression="Material_57" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_57" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_57") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_58" SortExpression="Material_58" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_58" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_58") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_59" SortExpression="Material_59" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_59" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_59") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_60" SortExpression="Material_60" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_60" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_60") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_61" SortExpression="Material_61" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_61" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_61") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_62" SortExpression="Material_62" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_62" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_62") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_63" SortExpression="Material_63" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_63" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_63") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_64" SortExpression="Material_64" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_64" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_64") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_65" SortExpression="Material_65" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_65" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_65") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_66" SortExpression="Material_66" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_66" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_66") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_67" SortExpression="Material_67" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_67" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_67") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_68" SortExpression="Material_68" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_68" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_68") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_69" SortExpression="Material_69" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_69" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_69") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_70" SortExpression="Material_70" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_70" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_70") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_71" SortExpression="Material_71" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_71" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_71") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_72" SortExpression="Material_72" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_72" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_72") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_73" SortExpression="Material_73" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_73" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_73") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_74" SortExpression="Material_74" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_74" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_74") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_75" SortExpression="Material_75" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_75" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_75") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_76" SortExpression="Material_76" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_76" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_76") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_77" SortExpression="Material_77" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_77" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_77") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_78" SortExpression="Material_78" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_78" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_78") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_79" SortExpression="Material_79" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_79" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_79") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_80" SortExpression="Material_80" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_80" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_80") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_81" SortExpression="Material_81" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_81" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_81") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_82" SortExpression="Material_82" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_82" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_82") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_83" SortExpression="Material_83" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_83" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_83") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_84" SortExpression="Material_84" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_84" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_84") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_85" SortExpression="Material_85" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_85" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_85") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_86" SortExpression="Material_86" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_86" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_86") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_87" SortExpression="Material_87" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_87" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_87") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_88" SortExpression="Material_88" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_88" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_88") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_89" SortExpression="Material_89" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_89" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_89") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_90" SortExpression="Material_90" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_90" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_90") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_91" SortExpression="Material_91" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_91" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_91") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_92" SortExpression="Material_92" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_92" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_92") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_93" SortExpression="Material_93" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_93" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_93") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_94" SortExpression="Material_94" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_94" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_94") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_95" SortExpression="Material_95" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_95" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_95") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_96" SortExpression="Material_96" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_96" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_96") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_97" SortExpression="Material_97" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_97" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_97") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_98" SortExpression="Material_98" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_98" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_98") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_99" SortExpression="Material_99" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_99" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_99") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_100" SortExpression="Material_100" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_100" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_100") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_101" SortExpression="Material_101" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_101" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_101") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_102" SortExpression="Material_102" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_102" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_102") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_103" SortExpression="Material_103" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_103" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_103") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_104" SortExpression="Material_104" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_104" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_104") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_105" SortExpression="Material_105" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_105" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_105") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_106" SortExpression="Material_106" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_106" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_106") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_107" SortExpression="Material_107" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_107" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_107") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_108" SortExpression="Material_108" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_108" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_108") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_109" SortExpression="Material_109" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_109" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_109") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_110" SortExpression="Material_110" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_110" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_110") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_111" SortExpression="Material_111" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_111" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_111") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_112" SortExpression="Material_112" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_112" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_112") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_113" SortExpression="Material_113" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_113" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_113") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_114" SortExpression="Material_114" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_114" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_114") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_115" SortExpression="Material_115" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_115" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_115") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_116" SortExpression="Material_116" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_116" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_116") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_117" SortExpression="Material_117" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_117" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_117") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_118" SortExpression="Material_118" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_118" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_118") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_119" SortExpression="Material_119" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_119" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_119") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_120" SortExpression="Material_120" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_120" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_120") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_121" SortExpression="Material_121" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_121" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_121") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_122" SortExpression="Material_122" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_122" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_122") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_123" SortExpression="Material_123" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_123" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_123") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_124" SortExpression="Material_124" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_124" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_124") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_125" SortExpression="Material_125" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_125" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_125") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_126" SortExpression="Material_126" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_126" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_126") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_127" SortExpression="Material_127" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_127" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_127") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_128" SortExpression="Material_128" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_128" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_128") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_129" SortExpression="Material_129" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_129" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_129") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_130" SortExpression="Material_130" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_130" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_130") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_131" SortExpression="Material_131" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_131" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_131") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_132" SortExpression="Material_132" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_132" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_132") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_133" SortExpression="Material_133" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_133" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_133") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_134" SortExpression="Material_134" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_134" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_134") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_135" SortExpression="Material_135" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_135" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_135") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_136" SortExpression="Material_136" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_136" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_136") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_137" SortExpression="Material_137" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_137" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_137") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_138" SortExpression="Material_138" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_138" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_138") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_139" SortExpression="Material_139" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_139" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_139") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_140" SortExpression="Material_140" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_140" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_140") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_141" SortExpression="Material_141" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_141" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_141") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_142" SortExpression="Material_142" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_142" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_142") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_143" SortExpression="Material_143" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_143" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_143") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_144" SortExpression="Material_144" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_144" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_144") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_145" SortExpression="Material_145" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_145" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_145") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_146" SortExpression="Material_146" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_146" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_146") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_147" SortExpression="Material_147" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_147" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_147") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_148" SortExpression="Material_148" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_148" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_148") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_149" SortExpression="Material_149" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_149" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_149") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_150" SortExpression="Material_150" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_150" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_150") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_151" SortExpression="Material_151" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_151" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_151") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_152" SortExpression="Material_152" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_152" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_152") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_153" SortExpression="Material_153" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_153" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_153") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_154" SortExpression="Material_154" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_154" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_154") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_155" SortExpression="Material_155" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_155" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_155") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_156" SortExpression="Material_156" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_156" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_156") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_157" SortExpression="Material_157" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_157" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_157") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_158" SortExpression="Material_158" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_158" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_158") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_159" SortExpression="Material_159" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_159" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_159") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_160" SortExpression="Material_160" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_160" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_160") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_161" SortExpression="Material_161" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_161" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_161") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_162" SortExpression="Material_162" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_162" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_162") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_163" SortExpression="Material_163" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_163" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_163") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_164" SortExpression="Material_164" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_164" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_164") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_165" SortExpression="Material_165" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_165" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_165") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_166" SortExpression="Material_166" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_166" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_166") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_167" SortExpression="Material_167" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_167" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_167") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_168" SortExpression="Material_168" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_168" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_168") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_169" SortExpression="Material_169" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_169" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_169") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_170" SortExpression="Material_170" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_170" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_170") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_171" SortExpression="Material_171" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_171" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_171") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_172" SortExpression="Material_172" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_172" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_172") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_173" SortExpression="Material_173" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_173" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_173") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_174" SortExpression="Material_174" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_174" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_174") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_175" SortExpression="Material_175" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_175" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_175") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_176" SortExpression="Material_176" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_176" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_176") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_177" SortExpression="Material_177" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_177" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_177") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_178" SortExpression="Material_178" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_178" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_178") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_179" SortExpression="Material_179" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_179" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_179") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_180" SortExpression="Material_180" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_180" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_180") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_181" SortExpression="Material_181" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_181" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_181") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_182" SortExpression="Material_182" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_182" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_182") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_183" SortExpression="Material_183" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_183" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_183") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_184" SortExpression="Material_184" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_184" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_184") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_185" SortExpression="Material_185" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_185" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_185") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_186" SortExpression="Material_186" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_186" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_186") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_187" SortExpression="Material_187" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_187" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_187") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_188" SortExpression="Material_188" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_188" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_188") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_189" SortExpression="Material_189" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_189" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_189") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_190" SortExpression="Material_190" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_190" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_190") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_191" SortExpression="Material_191" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_191" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_191") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_192" SortExpression="Material_192" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_192" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_192") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_193" SortExpression="Material_193" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_193" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_193") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_194" SortExpression="Material_194" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_194" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_194") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_195" SortExpression="Material_195" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_195" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_195") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_196" SortExpression="Material_196" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_196" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_196") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_197" SortExpression="Material_197" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_197" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_197") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_198" SortExpression="Material_198" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_198" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_198") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_199" SortExpression="Material_199" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_199" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_199") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_200" SortExpression="Material_200" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_200" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_200") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_201" SortExpression="Material_201" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_201" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_201") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_202" SortExpression="Material_202" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_202" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_202") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_203" SortExpression="Material_203" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_203" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_203") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_204" SortExpression="Material_204" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_204" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_204") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_205" SortExpression="Material_205" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_205" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_205") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_206" SortExpression="Material_206" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_206" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_206") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_207" SortExpression="Material_207" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_207" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_207") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_208" SortExpression="Material_208" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_208" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_208") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_209" SortExpression="Material_209" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_209" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_209") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_210" SortExpression="Material_210" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_210" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_210") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_211" SortExpression="Material_211" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_211" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_211") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_212" SortExpression="Material_212" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_212" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_212") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_213" SortExpression="Material_213" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_213" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_213") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_214" SortExpression="Material_214" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_214" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_214") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_215" SortExpression="Material_215" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_215" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_215") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_216" SortExpression="Material_216" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_216" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_216") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_217" SortExpression="Material_217" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_217" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_217") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_218" SortExpression="Material_218" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_218" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_218") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_219" SortExpression="Material_219" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_219" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_219") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_220" SortExpression="Material_220" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_220" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_220") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_221" SortExpression="Material_221" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_221" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_221") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_222" SortExpression="Material_222" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_222" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_222") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_223" SortExpression="Material_223" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_223" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_223") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_224" SortExpression="Material_224" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_224" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_224") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_225" SortExpression="Material_225" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_225" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_225") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_226" SortExpression="Material_226" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_226" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_226") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_227" SortExpression="Material_227" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_227" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_227") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_228" SortExpression="Material_228" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_228" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_228") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_229" SortExpression="Material_229" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_229" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_229") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_230" SortExpression="Material_230" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_230" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_230") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_231" SortExpression="Material_231" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_231" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_231") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_232" SortExpression="Material_232" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_232" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_232") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_233" SortExpression="Material_233" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_233" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_233") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_234" SortExpression="Material_234" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_234" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_234") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_235" SortExpression="Material_235" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_235" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_235") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_236" SortExpression="Material_236" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_236" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_236") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_237" SortExpression="Material_237" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_237" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_237") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_238" SortExpression="Material_238" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_238" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_238") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_239" SortExpression="Material_239" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_239" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_239") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_240" SortExpression="Material_240" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_240" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_240") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_241" SortExpression="Material_241" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_241" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_241") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_242" SortExpression="Material_242" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_242" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_242") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_243" SortExpression="Material_243" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_243" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_243") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_244" SortExpression="Material_244" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_244" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_244") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_245" SortExpression="Material_245" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_245" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_245") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_246" SortExpression="Material_246" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_246" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_246") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_247" SortExpression="Material_247" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_247" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_247") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_248" SortExpression="Material_248" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_248" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_248") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_249" SortExpression="Material_249" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_249" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_249") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_250" SortExpression="Material_250" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_250" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_250") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_251" SortExpression="Material_251" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_251" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_251") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_252" SortExpression="Material_252" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_252" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_252") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_253" SortExpression="Material_253" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_253" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_253") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_254" SortExpression="Material_254" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_254" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_254") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_255" SortExpression="Material_255" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_255" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_255") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_256" SortExpression="Material_256" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_256" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_256") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_257" SortExpression="Material_257" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_257" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_257") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_258" SortExpression="Material_258" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_258" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_258") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_259" SortExpression="Material_259" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_259" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_259") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_260" SortExpression="Material_260" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_260" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_260") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_261" SortExpression="Material_261" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_261" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_261") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_262" SortExpression="Material_262" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_262" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_262") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_263" SortExpression="Material_263" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_263" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_263") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_264" SortExpression="Material_264" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_264" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_264") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_265" SortExpression="Material_265" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_265" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_265") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_266" SortExpression="Material_266" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_266" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_266") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_267" SortExpression="Material_267" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_267" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_267") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_268" SortExpression="Material_268" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_268" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_268") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_269" SortExpression="Material_269" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_269" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_269") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_270" SortExpression="Material_270" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_270" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_270") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_271" SortExpression="Material_271" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_271" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_271") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_272" SortExpression="Material_272" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_272" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_272") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_273" SortExpression="Material_273" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_273" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_273") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_274" SortExpression="Material_274" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_274" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_274") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_275" SortExpression="Material_275" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_275" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_275") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_276" SortExpression="Material_276" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_276" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_276") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_277" SortExpression="Material_277" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_277" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_277") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_278" SortExpression="Material_278" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_278" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_278") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_279" SortExpression="Material_279" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_279" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_279") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_280" SortExpression="Material_280" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_280" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_280") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_281" SortExpression="Material_281" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_281" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_281") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_282" SortExpression="Material_282" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_282" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_282") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_283" SortExpression="Material_283" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_283" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_283") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_284" SortExpression="Material_284" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_284" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_284") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_285" SortExpression="Material_285" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_285" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_285") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_286" SortExpression="Material_286" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_286" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_286") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_287" SortExpression="Material_287" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_287" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_287") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_288" SortExpression="Material_288" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_288" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_288") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_289" SortExpression="Material_289" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_289" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_289") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_290" SortExpression="Material_290" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_290" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_290") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_291" SortExpression="Material_291" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_291" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_291") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_292" SortExpression="Material_292" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_292" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_292") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_293" SortExpression="Material_293" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_293" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_293") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_294" SortExpression="Material_294" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_294" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_294") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_295" SortExpression="Material_295" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_295" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_295") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_296" SortExpression="Material_296" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_296" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_296") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_297" SortExpression="Material_297" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_297" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_297") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_298" SortExpression="Material_298" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_298" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_298") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_299" SortExpression="Material_299" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_299" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_299") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_300" SortExpression="Material_300" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_300" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_300") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_301" SortExpression="Material_301" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_301" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_301") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_302" SortExpression="Material_302" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_302" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_302") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_303" SortExpression="Material_303" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_303" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_303") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_304" SortExpression="Material_304" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_304" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_304") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_305" SortExpression="Material_305" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_305" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_305") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_306" SortExpression="Material_306" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_306" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_306") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_307" SortExpression="Material_307" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_307" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_307") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_308" SortExpression="Material_308" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_308" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_308") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_309" SortExpression="Material_309" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_309" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_309") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_310" SortExpression="Material_310" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_310" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_310") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_311" SortExpression="Material_311" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_311" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_311") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_312" SortExpression="Material_312" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_312" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_312") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_313" SortExpression="Material_313" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_313" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_313") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_314" SortExpression="Material_314" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_314" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_314") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_315" SortExpression="Material_315" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_315" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_315") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_316" SortExpression="Material_316" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_316" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_316") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_317" SortExpression="Material_317" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_317" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_317") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_318" SortExpression="Material_318" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_318" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_318") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_319" SortExpression="Material_319" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_319" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_319") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_320" SortExpression="Material_320" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_320" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_320") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_321" SortExpression="Material_321" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_321" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_321") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_322" SortExpression="Material_322" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_322" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_322") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_323" SortExpression="Material_323" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_323" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_323") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_324" SortExpression="Material_324" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_324" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_324") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_325" SortExpression="Material_325" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_325" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_325") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_326" SortExpression="Material_326" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_326" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_326") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_327" SortExpression="Material_327" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_327" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_327") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_328" SortExpression="Material_328" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_328" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_328") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_329" SortExpression="Material_329" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_329" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_329") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_330" SortExpression="Material_330" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_330" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_330") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_331" SortExpression="Material_331" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_331" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_331") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_332" SortExpression="Material_332" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_332" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_332") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_333" SortExpression="Material_333" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_333" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_333") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_334" SortExpression="Material_334" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_334" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_334") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_335" SortExpression="Material_335" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_335" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_335") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_336" SortExpression="Material_336" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_336" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_336") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_337" SortExpression="Material_337" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_337" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_337") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_338" SortExpression="Material_338" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_338" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_338") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_339" SortExpression="Material_339" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_339" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_339") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_340" SortExpression="Material_340" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_340" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_340") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_341" SortExpression="Material_341" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_341" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_341") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_342" SortExpression="Material_342" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_342" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_342") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_343" SortExpression="Material_343" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_343" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_343") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_344" SortExpression="Material_344" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_344" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_344") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_345" SortExpression="Material_345" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_345" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_345") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_346" SortExpression="Material_346" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_346" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_346") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_347" SortExpression="Material_347" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_347" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_347") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_348" SortExpression="Material_348" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_348" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_348") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_349" SortExpression="Material_349" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_349" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_349") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_350" SortExpression="Material_350" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_350" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_350") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_351" SortExpression="Material_351" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_351" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_351") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_352" SortExpression="Material_352" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_352" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_352") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_353" SortExpression="Material_353" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_353" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_353") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_354" SortExpression="Material_354" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_354" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_354") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_355" SortExpression="Material_355" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_355" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_355") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_356" SortExpression="Material_356" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_356" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_356") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_357" SortExpression="Material_357" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_357" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_357") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_358" SortExpression="Material_358" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_358" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_358") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_359" SortExpression="Material_359" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_359" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_359") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_360" SortExpression="Material_360" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_360" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_360") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_361" SortExpression="Material_361" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_361" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_361") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_362" SortExpression="Material_362" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_362" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_362") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_363" SortExpression="Material_363" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_363" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_363") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_364" SortExpression="Material_364" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_364" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_364") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_365" SortExpression="Material_365" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_365" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_365") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_366" SortExpression="Material_366" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_366" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_366") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_367" SortExpression="Material_367" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_367" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_367") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_368" SortExpression="Material_368" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_368" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_368") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_369" SortExpression="Material_369" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_369" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_369") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_370" SortExpression="Material_370" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_370" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_370") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_371" SortExpression="Material_371" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_371" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_371") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_372" SortExpression="Material_372" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_372" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_372") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_373" SortExpression="Material_373" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_373" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_373") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_374" SortExpression="Material_374" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_374" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_374") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_375" SortExpression="Material_375" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_375" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_375") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_376" SortExpression="Material_376" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_376" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_376") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_377" SortExpression="Material_377" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_377" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_377") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_378" SortExpression="Material_378" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_378" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_378") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_379" SortExpression="Material_379" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_379" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_379") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_380" SortExpression="Material_380" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_380" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_380") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_381" SortExpression="Material_381" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_381" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_381") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_382" SortExpression="Material_382" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_382" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_382") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_383" SortExpression="Material_383" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_383" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_383") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_384" SortExpression="Material_384" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_384" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_384") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_385" SortExpression="Material_385" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_385" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_385") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_386" SortExpression="Material_386" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_386" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_386") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_387" SortExpression="Material_387" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_387" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_387") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_388" SortExpression="Material_388" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_388" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_388") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_389" SortExpression="Material_389" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_389" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_389") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_390" SortExpression="Material_390" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_390" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_390") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_391" SortExpression="Material_391" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_391" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_391") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_392" SortExpression="Material_392" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_392" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_392") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_393" SortExpression="Material_393" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_393" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_393") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_394" SortExpression="Material_394" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_394" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_394") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_395" SortExpression="Material_395" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_395" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_395") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_396" SortExpression="Material_396" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_396" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_396") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_397" SortExpression="Material_397" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_397" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_397") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_398" SortExpression="Material_398" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_398" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_398") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_399" SortExpression="Material_399" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_399" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_399") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_400" SortExpression="Material_400" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_400" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_400") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_401" SortExpression="Material_401" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_401" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_401") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_402" SortExpression="Material_402" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_402" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_402") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_403" SortExpression="Material_403" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_403" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_403") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_404" SortExpression="Material_404" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_404" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_404") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_405" SortExpression="Material_405" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_405" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_405") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_406" SortExpression="Material_406" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_406" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_406") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_407" SortExpression="Material_407" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_407" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_407") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_408" SortExpression="Material_408" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_408" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_408") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_409" SortExpression="Material_409" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_409" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_409") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_410" SortExpression="Material_410" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_410" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_410") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_411" SortExpression="Material_411" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_411" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_411") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_412" SortExpression="Material_412" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_412" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_412") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_413" SortExpression="Material_413" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_413" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_413") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_414" SortExpression="Material_414" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_414" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_414") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_415" SortExpression="Material_415" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_415" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_415") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_416" SortExpression="Material_416" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_416" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_416") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_417" SortExpression="Material_417" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_417" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_417") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_418" SortExpression="Material_418" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_418" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_418") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_419" SortExpression="Material_419" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_419" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_419") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_420" SortExpression="Material_420" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_420" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_420") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_421" SortExpression="Material_421" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_421" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_421") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_422" SortExpression="Material_422" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_422" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_422") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_423" SortExpression="Material_423" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_423" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_423") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_424" SortExpression="Material_424" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_424" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_424") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_425" SortExpression="Material_425" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_425" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_425") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_426" SortExpression="Material_426" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_426" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_426") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_427" SortExpression="Material_427" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_427" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_427") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_428" SortExpression="Material_428" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_428" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_428") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_429" SortExpression="Material_429" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_429" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_429") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_430" SortExpression="Material_430" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_430" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_430") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_431" SortExpression="Material_431" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_431" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_431") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_432" SortExpression="Material_432" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_432" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_432") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_433" SortExpression="Material_433" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_433" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_433") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_434" SortExpression="Material_434" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_434" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_434") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_435" SortExpression="Material_435" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_435" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_435") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_436" SortExpression="Material_436" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_436" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_436") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_437" SortExpression="Material_437" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_437" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_437") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_438" SortExpression="Material_438" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_438" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_438") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_439" SortExpression="Material_439" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_439" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_439") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_440" SortExpression="Material_440" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_440" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_440") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_441" SortExpression="Material_441" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_441" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_441") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_442" SortExpression="Material_442" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_442" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_442") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_443" SortExpression="Material_443" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_443" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_443") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_444" SortExpression="Material_444" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_444" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_444") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_445" SortExpression="Material_445" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_445" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_445") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_446" SortExpression="Material_446" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_446" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_446") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_447" SortExpression="Material_447" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_447" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_447") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_448" SortExpression="Material_448" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_448" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_448") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_449" SortExpression="Material_449" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_449" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_449") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_450" SortExpression="Material_450" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_450" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_450") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_451" SortExpression="Material_451" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_451" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_451") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_452" SortExpression="Material_452" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_452" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_452") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_453" SortExpression="Material_453" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_453" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_453") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_454" SortExpression="Material_454" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_454" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_454") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_455" SortExpression="Material_455" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_455" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_455") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_456" SortExpression="Material_456" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_456" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_456") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_457" SortExpression="Material_457" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_457" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_457") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_458" SortExpression="Material_458" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_458" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_458") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_459" SortExpression="Material_459" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_459" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_459") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_460" SortExpression="Material_460" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_460" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_460") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_461" SortExpression="Material_461" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_461" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_461") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_462" SortExpression="Material_462" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_462" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_462") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_463" SortExpression="Material_463" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_463" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_463") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_464" SortExpression="Material_464" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_464" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_464") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_465" SortExpression="Material_465" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_465" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_465") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_466" SortExpression="Material_466" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_466" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_466") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_467" SortExpression="Material_467" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_467" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_467") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_468" SortExpression="Material_468" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_468" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_468") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_469" SortExpression="Material_469" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_469" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_469") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_470" SortExpression="Material_470" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_470" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_470") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_471" SortExpression="Material_471" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_471" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_471") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_472" SortExpression="Material_472" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_472" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_472") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_473" SortExpression="Material_473" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_473" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_473") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_474" SortExpression="Material_474" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_474" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_474") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_475" SortExpression="Material_475" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_475" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_475") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_476" SortExpression="Material_476" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_476" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_476") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_477" SortExpression="Material_477" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_477" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_477") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_478" SortExpression="Material_478" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_478" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_478") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_479" SortExpression="Material_479" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_479" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_479") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_480" SortExpression="Material_480" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_480" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_480") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_481" SortExpression="Material_481" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_481" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_481") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_482" SortExpression="Material_482" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_482" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_482") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_483" SortExpression="Material_483" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_483" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_483") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_484" SortExpression="Material_484" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_484" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_484") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_485" SortExpression="Material_485" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_485" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_485") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_486" SortExpression="Material_486" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_486" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_486") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_487" SortExpression="Material_487" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_487" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_487") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_488" SortExpression="Material_488" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_488" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_488") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_489" SortExpression="Material_489" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_489" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_489") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_490" SortExpression="Material_490" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_490" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_490") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_491" SortExpression="Material_491" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_491" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_491") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_492" SortExpression="Material_492" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_492" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_492") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_493" SortExpression="Material_493" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_493" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_493") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_494" SortExpression="Material_494" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_494" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_494") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_495" SortExpression="Material_495" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_495" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_495") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_496" SortExpression="Material_496" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_496" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_496") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_497" SortExpression="Material_497" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_497" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_497") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_498" SortExpression="Material_498" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_498" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_498") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_499" SortExpression="Material_499" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_499" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_499") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_500" SortExpression="Material_500" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_500" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_500") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_501" SortExpression="Material_501" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_501" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_501") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_502" SortExpression="Material_502" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_502" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_502") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_503" SortExpression="Material_503" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_503" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_503") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_504" SortExpression="Material_504" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_504" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_504") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_505" SortExpression="Material_505" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_505" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_505") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_506" SortExpression="Material_506" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_506" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_506") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_507" SortExpression="Material_507" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_507" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_507") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_508" SortExpression="Material_508" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_508" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_508") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_509" SortExpression="Material_509" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_509" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_509") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_510" SortExpression="Material_510" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_510" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_510") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_511" SortExpression="Material_511" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_511" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_511") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_512" SortExpression="Material_512" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_512" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_512") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_513" SortExpression="Material_513" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_513" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_513") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_514" SortExpression="Material_514" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_514" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_514") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_515" SortExpression="Material_515" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_515" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_515") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_516" SortExpression="Material_516" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_516" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_516") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_517" SortExpression="Material_517" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_517" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_517") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_518" SortExpression="Material_518" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_518" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_518") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_519" SortExpression="Material_519" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_519" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_519") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_520" SortExpression="Material_520" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_520" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_520") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_521" SortExpression="Material_521" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_521" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_521") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_522" SortExpression="Material_522" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_522" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_522") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_523" SortExpression="Material_523" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_523" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_523") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_524" SortExpression="Material_524" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_524" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_524") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_525" SortExpression="Material_525" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_525" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_525") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_526" SortExpression="Material_526" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_526" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_526") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_527" SortExpression="Material_527" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_527" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_527") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_528" SortExpression="Material_528" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_528" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_528") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_529" SortExpression="Material_529" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_529" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_529") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_530" SortExpression="Material_530" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_530" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_530") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_531" SortExpression="Material_531" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_531" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_531") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_532" SortExpression="Material_532" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_532" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_532") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_533" SortExpression="Material_533" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_533" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_533") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_534" SortExpression="Material_534" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_534" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_534") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_535" SortExpression="Material_535" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_535" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_535") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_536" SortExpression="Material_536" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_536" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_536") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_537" SortExpression="Material_537" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_537" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_537") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_538" SortExpression="Material_538" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_538" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_538") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_539" SortExpression="Material_539" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_539" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_539") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_540" SortExpression="Material_540" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_540" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_540") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_541" SortExpression="Material_541" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_541" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_541") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_542" SortExpression="Material_542" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_542" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_542") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_543" SortExpression="Material_543" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_543" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_543") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_544" SortExpression="Material_544" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_544" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_544") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_545" SortExpression="Material_545" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_545" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_545") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_546" SortExpression="Material_546" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_546" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_546") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_547" SortExpression="Material_547" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_547" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_547") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_548" SortExpression="Material_548" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_548" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_548") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_549" SortExpression="Material_549" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_549" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_549") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_550" SortExpression="Material_550" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_550" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_550") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_551" SortExpression="Material_551" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_551" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_551") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_552" SortExpression="Material_552" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_552" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_552") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_553" SortExpression="Material_553" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_553" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_553") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_554" SortExpression="Material_554" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_554" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_554") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_555" SortExpression="Material_555" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_555" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_555") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_556" SortExpression="Material_556" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_556" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_556") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_557" SortExpression="Material_557" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_557" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_557") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_558" SortExpression="Material_558" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_558" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_558") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_559" SortExpression="Material_559" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_559" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_559") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_560" SortExpression="Material_560" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_560" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_560") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_561" SortExpression="Material_561" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_561" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_561") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_562" SortExpression="Material_562" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_562" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_562") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_563" SortExpression="Material_563" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_563" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_563") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_564" SortExpression="Material_564" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_564" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_564") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_565" SortExpression="Material_565" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_565" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_565") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_566" SortExpression="Material_566" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_566" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_566") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_567" SortExpression="Material_567" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_567" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_567") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_568" SortExpression="Material_568" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_568" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_568") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_569" SortExpression="Material_569" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_569" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_569") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_570" SortExpression="Material_570" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_570" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_570") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_571" SortExpression="Material_571" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_571" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_571") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_572" SortExpression="Material_572" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_572" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_572") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_573" SortExpression="Material_573" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_573" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_573") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_574" SortExpression="Material_574" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_574" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_574") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_575" SortExpression="Material_575" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_575" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_575") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_576" SortExpression="Material_576" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_576" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_576") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_577" SortExpression="Material_577" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_577" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_577") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_578" SortExpression="Material_578" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_578" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_578") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_579" SortExpression="Material_579" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_579" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_579") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_580" SortExpression="Material_580" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_580" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_580") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_581" SortExpression="Material_581" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_581" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_581") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_582" SortExpression="Material_582" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_582" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_582") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_583" SortExpression="Material_583" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_583" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_583") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_584" SortExpression="Material_584" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_584" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_584") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_585" SortExpression="Material_585" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_585" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_585") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_586" SortExpression="Material_586" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_586" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_586") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_587" SortExpression="Material_587" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_587" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_587") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_588" SortExpression="Material_588" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_588" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_588") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_589" SortExpression="Material_589" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_589" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_589") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_590" SortExpression="Material_590" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_590" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_590") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_591" SortExpression="Material_591" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_591" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_591") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_592" SortExpression="Material_592" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_592" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_592") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_593" SortExpression="Material_593" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_593" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_593") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_594" SortExpression="Material_594" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_594" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_594") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_595" SortExpression="Material_595" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_595" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_595") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_596" SortExpression="Material_596" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_596" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_596") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_597" SortExpression="Material_597" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_597" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_597") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_598" SortExpression="Material_598" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_598" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_598") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_599" SortExpression="Material_599" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_599" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_599") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_600" SortExpression="Material_600" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_600" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_600") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_601" SortExpression="Material_601" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_601" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_601") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_602" SortExpression="Material_602" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_602" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_602") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_603" SortExpression="Material_603" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_603" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_603") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_604" SortExpression="Material_604" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_604" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_604") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_605" SortExpression="Material_605" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_605" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_605") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_606" SortExpression="Material_606" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_606" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_606") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_607" SortExpression="Material_607" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_607" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_607") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_608" SortExpression="Material_608" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_608" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_608") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_609" SortExpression="Material_609" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_609" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_609") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_610" SortExpression="Material_610" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_610" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_610") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_611" SortExpression="Material_611" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_611" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_611") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_612" SortExpression="Material_612" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_612" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_612") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_613" SortExpression="Material_613" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_613" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_613") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_614" SortExpression="Material_614" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_614" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_614") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_615" SortExpression="Material_615" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_615" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_615") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_616" SortExpression="Material_616" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_616" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_616") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_617" SortExpression="Material_617" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_617" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_617") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_618" SortExpression="Material_618" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_618" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_618") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_619" SortExpression="Material_619" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_619" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_619") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_620" SortExpression="Material_620" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_620" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_620") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_621" SortExpression="Material_621" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_621" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_621") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_622" SortExpression="Material_622" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_622" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_622") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_623" SortExpression="Material_623" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_623" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_623") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_624" SortExpression="Material_624" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_624" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_624") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_625" SortExpression="Material_625" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_625" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_625") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_626" SortExpression="Material_626" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_626" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_626") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_627" SortExpression="Material_627" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_627" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_627") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_628" SortExpression="Material_628" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_628" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_628") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_629" SortExpression="Material_629" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_629" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_629") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_630" SortExpression="Material_630" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_630" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_630") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_631" SortExpression="Material_631" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_631" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_631") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_632" SortExpression="Material_632" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_632" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_632") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_633" SortExpression="Material_633" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_633" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_633") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_634" SortExpression="Material_634" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_634" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_634") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_635" SortExpression="Material_635" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_635" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_635") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_636" SortExpression="Material_636" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_636" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_636") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_637" SortExpression="Material_637" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_637" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_637") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_638" SortExpression="Material_638" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_638" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_638") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_639" SortExpression="Material_639" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_639" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_639") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_640" SortExpression="Material_640" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_640" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_640") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_641" SortExpression="Material_641" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_641" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_641") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_642" SortExpression="Material_642" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_642" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_642") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_643" SortExpression="Material_643" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_643" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_643") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_644" SortExpression="Material_644" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_644" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_644") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_645" SortExpression="Material_645" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_645" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_645") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_646" SortExpression="Material_646" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_646" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_646") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_647" SortExpression="Material_647" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_647" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_647") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_648" SortExpression="Material_648" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_648" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_648") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_649" SortExpression="Material_649" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_649" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_649") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_650" SortExpression="Material_650" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_650" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_650") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_651" SortExpression="Material_651" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_651" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_651") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_652" SortExpression="Material_652" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_652" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_652") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_653" SortExpression="Material_653" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_653" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_653") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_654" SortExpression="Material_654" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_654" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_654") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_655" SortExpression="Material_655" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_655" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_655") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_656" SortExpression="Material_656" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_656" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_656") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_657" SortExpression="Material_657" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_657" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_657") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_658" SortExpression="Material_658" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_658" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_658") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_659" SortExpression="Material_659" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_659" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_659") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_660" SortExpression="Material_660" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_660" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_660") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_661" SortExpression="Material_661" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_661" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_661") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_662" SortExpression="Material_662" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_662" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_662") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_663" SortExpression="Material_663" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_663" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_663") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_664" SortExpression="Material_664" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_664" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_664") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_665" SortExpression="Material_665" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_665" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_665") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_666" SortExpression="Material_666" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_666" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_666") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_667" SortExpression="Material_667" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_667" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_667") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_668" SortExpression="Material_668" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_668" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_668") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_669" SortExpression="Material_669" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_669" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_669") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_670" SortExpression="Material_670" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_670" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_670") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_671" SortExpression="Material_671" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_671" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_671") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_672" SortExpression="Material_672" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_672" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_672") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_673" SortExpression="Material_673" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_673" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_673") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_674" SortExpression="Material_674" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_674" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_674") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_675" SortExpression="Material_675" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_675" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_675") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_676" SortExpression="Material_676" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_676" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_676") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_677" SortExpression="Material_677" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_677" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_677") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_678" SortExpression="Material_678" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_678" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_678") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_679" SortExpression="Material_679" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_679" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_679") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_680" SortExpression="Material_680" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_680" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_680") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_681" SortExpression="Material_681" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_681" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_681") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_682" SortExpression="Material_682" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_682" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_682") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_683" SortExpression="Material_683" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_683" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_683") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_684" SortExpression="Material_684" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_684" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_684") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_685" SortExpression="Material_685" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_685" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_685") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_686" SortExpression="Material_686" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_686" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_686") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_687" SortExpression="Material_687" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_687" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_687") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_688" SortExpression="Material_688" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_688" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_688") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_689" SortExpression="Material_689" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_689" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_689") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_690" SortExpression="Material_690" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_690" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_690") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_691" SortExpression="Material_691" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_691" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_691") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_692" SortExpression="Material_692" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_692" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_692") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_693" SortExpression="Material_693" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_693" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_693") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_694" SortExpression="Material_694" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_694" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_694") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_695" SortExpression="Material_695" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_695" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_695") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_696" SortExpression="Material_696" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_696" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_696") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_697" SortExpression="Material_697" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_697" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_697") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_698" SortExpression="Material_698" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_698" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_698") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_699" SortExpression="Material_699" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_699" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_699") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_700" SortExpression="Material_700" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_700" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_700") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_701" SortExpression="Material_701" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_701" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_701") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_702" SortExpression="Material_702" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_702" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_702") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_703" SortExpression="Material_703" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_703" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_703") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_704" SortExpression="Material_704" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_704" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_704") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_705" SortExpression="Material_705" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_705" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_705") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_706" SortExpression="Material_706" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_706" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_706") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_707" SortExpression="Material_707" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_707" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_707") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_708" SortExpression="Material_708" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_708" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_708") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_709" SortExpression="Material_709" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_709" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_709") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_710" SortExpression="Material_710" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_710" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_710") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_711" SortExpression="Material_711" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_711" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_711") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_712" SortExpression="Material_712" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_712" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_712") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_713" SortExpression="Material_713" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_713" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_713") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_714" SortExpression="Material_714" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_714" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_714") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_715" SortExpression="Material_715" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_715" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_715") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_716" SortExpression="Material_716" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_716" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_716") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_717" SortExpression="Material_717" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_717" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_717") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_718" SortExpression="Material_718" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_718" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_718") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_719" SortExpression="Material_719" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_719" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_719") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_720" SortExpression="Material_720" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_720" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_720") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_721" SortExpression="Material_721" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_721" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_721") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_722" SortExpression="Material_722" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_722" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_722") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_723" SortExpression="Material_723" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_723" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_723") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_724" SortExpression="Material_724" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_724" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_724") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_725" SortExpression="Material_725" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_725" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_725") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_726" SortExpression="Material_726" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_726" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_726") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_727" SortExpression="Material_727" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_727" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_727") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_728" SortExpression="Material_728" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_728" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_728") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_729" SortExpression="Material_729" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_729" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_729") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_730" SortExpression="Material_730" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_730" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_730") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_731" SortExpression="Material_731" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_731" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_731") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_732" SortExpression="Material_732" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_732" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_732") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_733" SortExpression="Material_733" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_733" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_733") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_734" SortExpression="Material_734" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_734" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_734") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_735" SortExpression="Material_735" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_735" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_735") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_736" SortExpression="Material_736" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_736" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_736") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_737" SortExpression="Material_737" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_737" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_737") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_738" SortExpression="Material_738" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_738" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_738") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_739" SortExpression="Material_739" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_739" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_739") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_740" SortExpression="Material_740" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_740" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_740") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_741" SortExpression="Material_741" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_741" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_741") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_742" SortExpression="Material_742" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_742" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_742") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_743" SortExpression="Material_743" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_743" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_743") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_744" SortExpression="Material_744" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_744" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_744") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_745" SortExpression="Material_745" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_745" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_745") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_746" SortExpression="Material_746" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_746" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_746") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_747" SortExpression="Material_747" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_747" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_747") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_748" SortExpression="Material_748" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_748" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_748") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_749" SortExpression="Material_749" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_749" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_749") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_750" SortExpression="Material_750" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_750" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_750") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_751" SortExpression="Material_751" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_751" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_751") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_752" SortExpression="Material_752" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_752" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_752") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_753" SortExpression="Material_753" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_753" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_753") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_754" SortExpression="Material_754" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_754" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_754") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_755" SortExpression="Material_755" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_755" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_755") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_756" SortExpression="Material_756" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_756" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_756") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_757" SortExpression="Material_757" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_757" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_757") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_758" SortExpression="Material_758" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_758" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_758") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_759" SortExpression="Material_759" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_759" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_759") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_760" SortExpression="Material_760" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_760" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_760") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_761" SortExpression="Material_761" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_761" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_761") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_762" SortExpression="Material_762" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_762" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_762") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_763" SortExpression="Material_763" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_763" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_763") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_764" SortExpression="Material_764" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_764" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_764") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_765" SortExpression="Material_765" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_765" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_765") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_766" SortExpression="Material_766" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_766" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_766") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_767" SortExpression="Material_767" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_767" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_767") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_768" SortExpression="Material_768" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_768" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_768") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_769" SortExpression="Material_769" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_769" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_769") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_770" SortExpression="Material_770" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_770" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_770") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_771" SortExpression="Material_771" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_771" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_771") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_772" SortExpression="Material_772" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_772" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_772") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_773" SortExpression="Material_773" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_773" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_773") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_774" SortExpression="Material_774" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_774" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_774") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_775" SortExpression="Material_775" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_775" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_775") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_776" SortExpression="Material_776" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_776" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_776") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_777" SortExpression="Material_777" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_777" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_777") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_778" SortExpression="Material_778" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_778" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_778") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_779" SortExpression="Material_779" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_779" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_779") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_780" SortExpression="Material_780" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_780" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_780") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_781" SortExpression="Material_781" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_781" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_781") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_782" SortExpression="Material_782" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_782" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_782") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_783" SortExpression="Material_783" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_783" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_783") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_784" SortExpression="Material_784" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_784" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_784") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_785" SortExpression="Material_785" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_785" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_785") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_786" SortExpression="Material_786" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_786" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_786") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_787" SortExpression="Material_787" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_787" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_787") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_788" SortExpression="Material_788" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_788" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_788") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_789" SortExpression="Material_789" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_789" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_789") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_790" SortExpression="Material_790" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_790" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_790") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_791" SortExpression="Material_791" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_791" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_791") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_792" SortExpression="Material_792" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_792" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_792") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_793" SortExpression="Material_793" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_793" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_793") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_794" SortExpression="Material_794" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_794" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_794") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_795" SortExpression="Material_795" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_795" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_795") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_796" SortExpression="Material_796" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_796" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_796") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_797" SortExpression="Material_797" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_797" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_797") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_798" SortExpression="Material_798" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_798" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_798") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_799" SortExpression="Material_799" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_799" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_799") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Material_800" SortExpression="Material_800" Visible="false">
                                            <HeaderStyle Font-Size="XX-Small" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterial_800" runat="server" Style="text-align: center; font-family: sans-serif; font-size: xx-small;" Enabled="false" BorderStyle="None" OnTextChanged="txtMaterialGridValues_TextChanged" AutoPostBack="true" AutoCompleteType="Disabled"
                                                    Text='<%# Bind("Material_800") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Nothing_2" HeaderText="Nothing_2">
                                            <ItemStyle HorizontalAlign="Center" Width="3px" BackColor="DarkGray" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL">
                                            <ItemStyle HorizontalAlign="Center" Width="55px" Font-Bold="true" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div id="footer">
                    <%--<table style="width: 95%">
                    <tr>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" CssClass="buttonBox" Text="Save VKB Information" OnClick="btnSave_Click" Visible="false" />
                            &nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:CheckBox ID="chkFinalVersion" runat="server" Text="Update As Final Version" Checked="false" Visible="false" OnCheckedChanged="chkFinalVersion_CheckedChanged" AutoPostBack="true" />
                            &nbsp; &nbsp;
                        <asp:HiddenField ID="hfidVKB" runat="server" Value="0" Visible="False" />
                            <asp:HiddenField ID="hfidLine" runat="server" Value="0" Visible="False" />
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="chkRestoreHeijunka" runat="server" Text="Restore Heijunka Kanban Values" Checked="false" Visible="false" />
                            &nbsp; &nbsp;
                                                <asp:CheckBox ID="chkcopypaste" runat="server" Text="Copy/Paste Recommended"
                                                    Checked="false" Visible="false" AutoPostBack="true"
                                                    OnCheckedChanged="chkcopypaste_CheckedChanged1" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink ID="hlReporte" Text="View Report" NavigateUrl="" Target="_blank" runat="server">View Report</asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="" Text="Recommended Heijunka Board.csv" Target="_blank" runat="server"></asp:HyperLink>
                        </td>
                        <td align="right"></td>
                    </tr>
                </table>--%>
                    <table style="width: 95%">
                        <tr>
                            <td align="left" class="padding-top-small">
                                <asp:Button ID="btnSave" runat="server" Text="Save VKB Information" OnClick="btnSave_Click" Visible="false" />
                            </td>
                            <td class="padding-top-small">
                                <asp:CheckBox ID="chkFinalVersion" runat="server" Text="Update As Final Version" Checked="false" Visible="false" OnCheckedChanged="chkFinalVersion_CheckedChanged" AutoPostBack="true" />
                                <asp:HiddenField ID="hfidVKB" runat="server" Value="0" Visible="False" />
                                <asp:HiddenField ID="hfidLine" runat="server" Value="0" Visible="False" />
                            </td>
                            <td align="right" class="padding-top-small">
                                <asp:CheckBox ID="chkRestoreHeijunka" runat="server" Text="Restore Heijunka Kanban Values" Checked="false" Visible="false" />
                            </td>
                            <td align="right" class="padding-top-small">
                                <asp:CheckBox ID="chkcopypaste" runat="server" Text="Copy/Paste Recommended"
                                    Checked="false" Visible="false" AutoPostBack="true"
                                    OnCheckedChanged="chkcopypaste_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="padding-top-small">
                                <asp:HyperLink ID="hlReporte" Text="View Report" NavigateUrl="#" Target="_blank" runat="server">View Report</asp:HyperLink>
                                <br />
                                <asp:HyperLink ID="HyperLink1" NavigateUrl="#" Text="Recommended Heijunka Board.csv" Target="_blank" runat="server"></asp:HyperLink>
                            </td>
                            <td align="right" class="padding-top-small"></td>
                        </tr>
                    </table>
                </div>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
