<%@ Page Title="" Language="C#" MasterPageFile="~/VKB.Master" AutoEventWireup="true" CodeBehind="VirtualKanban.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.VirtualKanban" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
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
    <div id="dialog-message" title="Capabilities">
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
                            <asp:Button ID="btnSaveCapabilities" runat="server" Text="Save" OnClick="btnSaveCapabilities_Click" OnClientClick="ValidateData()" UseSubmitBehavior="false" Style="display: none" />
                            &nbsp;&nbsp;
                        </td>
                        <td class="padding-top-small" align="center">
                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" Visible="false" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div>
        <h3>Heijunka VKB</h3>
        <p>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
        </asp:ScriptManager>

        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
        </script>
        <div id="Header" runat="server" class="border padding-left padding-top padding-bottom" >
            <%--<asp:HiddenField ID="LEAN_APP" runat="server" />--%>
            <table>
                <tr>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label1" runat="server" Text="Line:" />
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:DropDownList ID="ddlLine" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" />
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label3" runat="server" Text="Date:"></asp:Label>
                    </td>
                    <td align="left" class="padding-top-small">
                        <asp:TextBox ID="txtFechaCaptura" runat="server" OnTextChanged="txtFechaCaptura_TextChanged" ReadOnly="true" />
                </tr>
                <tr>
                    <td align="left" class="padding-top-small">
                        <asp:Label ID="Label2" runat="server" Text="Filter:" />
                    </td>
                    <td align="left" style="width: 250px;" class="padding-top-small">
                        <asp:TextBox ID="txtFilter" runat="server" />
                    </td>
                    <td align="center" style="width: 300px;" colspan="3" class="padding-top-small">
                        <asp:Button ID="btnShow" runat="server" Text="Search" OnClick="btnShow_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCapablity" runat="server" Text="Capacity" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" class="padding-top-small">
                        <asp:Label ID="lblNotSaved" runat="server" Text="Modifications will not be autosaved" Visible="false" />
                    </td>
                    <td align="center" colspan="3" class="padding-top-small">
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
        <div id="Status">
            <asp:Label ID="LabelStatus" runat="server" Text="" />
        </div>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="divVKB" runat="server" style="overflow: auto; height: 100%;">
                    <asp:GridView ID="gvVKB" Visible="false" runat="server" PageSize="10"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        ShowFooter="false"
                        AllowSorting="False"
                        CssClass="bordered min-width tablesorter"
                        OnRowDataBound="gvVKB_RowDataBound"
                        OnPageIndexChanging="gvVKB_PageIndexChanging"
                        DefaultMode="Edit"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="idVKB" SortExpression="idMaterial" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidVKBEdit" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidVKBView" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idLocalizationMaterial" SortExpression="idLocalizationMaterial" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidLocalizationMaterialEdit" runat="server" Text='<%# Bind("idLocalizationMaterial") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidLocalizationMaterialView" runat="server" Text='<%# Bind("idLocalizationMaterial") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="% of RED" SortExpression="Precent_Red">
                                <EditItemTemplate>
                                    <asp:Label ID="lblRedEdit" runat="server" Text='<%# Bind("Precent_Red") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRedView" runat="server" Text='<%# Bind("Precent_Red") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PN" SortExpression="idMaterial">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidMaterialEdit" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidMaterialView" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PPVT" SortExpression="PPVT">
                                <EditItemTemplate>
                                    <asp:Label ID="lblPPVTEdit" runat="server" Text='<%# Bind("PPVT") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPPVTView" runat="server" Text='<%# Bind("PPVT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Yield" SortExpression="Yield">
                                <EditItemTemplate>
                                    <asp:Label ID="lblYieldEdit" runat="server" Text='<%# Bind("Yield") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblYieldView" runat="server" Text='<%# Bind("Yield") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LOC" SortExpression="Localization_Name">
                                <EditItemTemplate>
                                    <asp:Label ID="lblLocalization_NameEdit" runat="server" Text='<%# Bind("Localization_Name") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLocalization_NameView" runat="server" Text='<%# Bind("Localization_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Kanban_Qty" SortExpression="Pallet_Qty">
                                <EditItemTemplate>
                                    <asp:Label ID="lblPallet_QtyEdit" runat="server" Text='<%# Bind("Pallet_Qty") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPallet_QtyView" runat="server" Text='<%# Bind("Pallet_Qty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer Orders (w/in LT window)" SortExpression="Customer_Order_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="lblProjected_BO_UnitsEdit" runat="server" Text='<%# Bind("Customer_Order_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblProjected_BO_UnitsView" runat="server" Text='<%# Bind("Customer_Order_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Current BackOrder (Units)" SortExpression="Current_Backorder_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="Customer_BO_Units" runat="server" Text='<%# Bind("Current_Backorder_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomer_BO_UnitsView" runat="server" Text='<%# Bind("Current_Backorder_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BTO (Units)" SortExpression="BTO_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="lblCustomer_BO_UnitsEdit" runat="server" Text='<%# Bind("BTO_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBTO_UnitsView" runat="server" Text='<%# Bind("BTO_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Special Bids (Units)" SortExpression="Special_Bids_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="lblSpecial_Bids_UnitsEdit" runat="server" Text='<%# Bind("Special_Bids_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSpecial_Bids_UnitsView" runat="server" Text='<%# Bind("Special_Bids_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SAP INV (Units)" SortExpression="InvOnDisCenter_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="lblInvOnDisCenter_UnitsEdit" runat="server" Text='<%# Bind("InvOnDisCenter_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblInvOnDisCenter_UnitsView" runat="server" Text='<%# Bind("InvOnDisCenter_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SAP INV-IN-Transit (Units)" SortExpression="InvInTransit_Units">
                                <EditItemTemplate>
                                    <asp:Label ID="lblInvInTransit_UnitsEdit" runat="server" Text='<%# Bind("InvInTransit_Units") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblInvInTransit_UnitsView" runat="server" Text='<%# Bind("InvInTransit_Units") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank1Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank1View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SAP KANBAN total (Pallets)" SortExpression="SAPKanbanTotal_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblSAPKanbanTotal_PalletsEdit" runat="server" Text='<%# Bind("SAPKanbanTotal_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSAPKanbanTotal_PalletsView" runat="server" Text='<%# Bind("SAPKanbanTotal_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HEIJUNKA KANBAN (Pallets)" SortExpression="HeijunkaKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="HeijunkaKanban_PalletsEdit" runat="server" Text='<%# Bind("HeijunkaKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblHeijunkaKanban_PalletsView" runat="server" Text='<%# Bind("HeijunkaKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total KANBAN (Pallets)" SortExpression="TotalKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblTotalKanban_PalletsEdit" runat="server" Text='<%# Bind("TotalKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalKanban_PalletsView" runat="server" Text='<%# Bind("TotalKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank2Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank2View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KANBAN NEEDED FOR ORANGE" SortExpression="KanbanNeededForOrange_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForOrange_PalletsEdit" runat="server" Text='<%# Bind("KanbanNeededForOrange_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForOrange_PalletsView" runat="server" Text='<%# Bind("KanbanNeededForOrange_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KANBAN NEEDED FOR RED" SortExpression="KanbanNeededForRed_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForRed_PalletsEdit" runat="server" Text='<%# Bind("KanbanNeededForRed_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForRed_PalletsView" runat="server" Text='<%# Bind("KanbanNeededForRed_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KANBAN NEEDED FOR YELLOW" SortExpression="KanbanNeededForYellow_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForYellow_PalletsEdit" runat="server" Text='<%# Bind("KanbanNeededForYellow_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForYellow_PalletsView" runat="server" Text='<%# Bind("KanbanNeededForYellow_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KANBAN NEEDED FOR GREEN" SortExpression="KanbanNeededForGreen_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForGreen_PalletsEdit" runat="server" Text='<%# Bind("KanbanNeededForGreen_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblKanbanNeededForGreen_PalletsView" runat="server" Text='<%# Bind("KanbanNeededForGreen_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank3Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank3View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Red Kanban (Pallets)" SortExpression="MinKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblMinKanban_PalletsEdit" runat="server" Text='<%# Bind("MinKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMinKanban_PalletsView" runat="server" Text='<%# Bind("MinKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Yellow Kanban (Pallets)" SortExpression="TargetKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblTargetKanban_PalletsEdit" runat="server" Text='<%# Bind("TargetKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTargetKanban_PalletsView" runat="server" Text='<%# Bind("TargetKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Green Kanban (Pallets)" SortExpression="MaxKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblMaxKanban_PalletsEdit" runat="server" Text='<%# Bind("MaxKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxKanban_PalletsView" runat="server" Text='<%# Bind("MaxKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank4Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank4View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excess Inventory (Units)" SortExpression="ExcessKanban_Pallets">
                                <EditItemTemplate>
                                    <asp:Label ID="lblExcessKanban_PalletsView" runat="server" Text='<%# Bind("ExcessKanban_Pallets") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblExcessKanban_PalletsView" runat="server" Text='<%# Bind("ExcessKanban_Pallets") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" " ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank5Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank5View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recommended Production" SortExpression="Recommended">
                                <EditItemTemplate>
                                    <asp:Label ID="lblRemd_PalletEdit" runat="server" Text='<%# Bind("Recommended") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRemd_PalletView" runat="server" Text='<%# Bind("Recommended") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBlank6Edit" runat="server" Text=""></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBlank6View" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Planned HEIJUNKA Board" SortExpression="HeijunkaBoard_Pallets" ItemStyle-Width="3px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtHeijunkaBoard_PalletsEdit" runat="server" Text='<%# Bind("HeijunkaBoard_Pallets") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHeijunkaBoard_PalletsView" runat="server" Text='<%# Bind("HeijunkaBoard_Pallets") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/common/images/srd2013/undo.png"
                                        CommandName="Cancel" ToolTip="Cancel" AlternateText="Cancel"></asp:ImageButton>
                                    <%--write a confirmbox in onclientClick and then delete--%>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit"></asp:ImageButton>
                                    <%--<asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                        ToolTip="Edit" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div id="footer" runat="server">
                    <table style="width: 95%">
                        <tr>
                            <td align="left" class="padding-top-small">
                                <asp:Button ID="btnSave" runat="server" Text="Save VKB Information" OnClick="btnSave_Click" Visible="false" />
                            </td>
                            <td class="padding-top-small">
                                <asp:CheckBox ID="chkFinalVersion" runat="server" Text="Update As Final Version" Checked="false" Visible="false" OnCheckedChanged="chkFinalVersion_CheckedChanged" AutoPostBack="true" />
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
