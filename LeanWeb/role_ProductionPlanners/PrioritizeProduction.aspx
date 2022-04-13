<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="PrioritizeProduction.aspx.cs" Inherits="LeanWeb.role_ModifyVKB.PrioritizeProduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <style>
       .displayhead {
            border: 1px solid #aaaaaa;
            background: #cccccc url(../../images/srd2013/ui-bg_highlight-soft_75_cccccc_1x100.png) 50% 50% repeat-x;
        }
    </style>
  <%--  <script>
        //$(function () {
        //    $("#dialog-message").dialog({
        //        autoOpen: false,
        //        modal: true,
        //        width: "auto",
        //        height: "700",
        //        buttons: {
        //            Ok: function () {
        //            },
        //            Cancel: function () {
        //                location.reload();
        //            }
        //        }
        //    });
        //$("#dialog-message").parent().appendTo($("div:first"));

        //$("[id$=btnCapablity]").click("click", function () {
        //    $("#dialog-message").dialog("open");
        //});
        //});
    </script>--%>
    <%-- syelamanchal commented for csrf --%>
   <%-- <script type="text/javascript">
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

    <br />
    <div>
        <h3>Production Plan</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%----syalamanchili Edit grid fixing and UI changes--start --%>
                  <div class="border padding-left padding-top padding-bottom">
                    <table align="center">
                        <tbody>
                            <tr>
                                <td colspan="6" class="padding-top-small">
                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                             <!--   <td class="padding-top-small">
                                    <asp:Button ID="btnLine" runat="server" Text="Get Line" OnClick="btnLine_Click" />
                                </td> --> <!--syalamanchili-->
                                <td class="padding-top-small">
                                    <asp:Label ID="lblLine" runat="server" Text="Line:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlLine" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" />
                                </td>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtFechaCaptura" runat="server" AutoPostBack="true"   OnTextChanged="txtFechaCaptura_TextChanged"  />
                                </td>

                                <td class="padding-top-small">
                                    <asp:Button ID="btnPrioritize" runat="server" Text="Search" OnClick="btnPrioritize_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="padding-top-small">
                                    <asp:Label ID="lblgvStatus" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblLastMaterial" runat="server" Text="Yesterday's Last Material:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtYesterdayMaterial" runat="server" AutoPostBack="true" />
                                </td>
                           <!--     <td class="padding-top-small">
                                    <asp:Button ID="btnGetYestardayMaterial" runat="server" Text="Get Material" OnClick="btnGetYestardayMaterial_Click" />
                                </td>-->
                                <td colspan="2" class="padding-top-small" align="center">
                                    <asp:DropDownList ID="ddlYesterdayMaterial" runat="server" AutoPostBack="false" />
                                </td>
                                <td class="padding-top-small">
                                    <asp:Button ID="btnAutomaticPriority" runat="server" Text="Redefine Order" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <%--<div id="dialog-message" style="display:none" title="Capabilities">--%>
                <div >
                <%----syalamanchili Edit grid fixing and UI changes--End --%>
                <asp:DetailsView ID="ProdPriorityEdit" runat="server"
                    HeaderText="Capabilities"
                    OnItemUpdating="ProdPriorityEdit_ItemUpdating"
                    DataKeyNames="Date,idLocalizationMaterial"
                    OnDataBound="ProdPriorityEdit_DataBound"
                    OnModeChanging="ProdPriorityEdit_Close"
                    CssClass="bordered min-width tablesorter"
                    AutoGenerateRows="false"
                    DefaultMode="Edit"
                    Width="90%"
                    
                    >
                    <headerstyle forecolor="white"
            backcolor="black" 
            font-names="Arial"
            font-size="13"
            font-bold="true"/>
                    <Fields>
                       <%-- <headertemplate class="displayhead" title="Capabilities">
                        <h4 >capabilities</h4>
                        </headertemplate>--%>
                        <asp:TemplateField HeaderText="Date" SortExpression="Date" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDateView" runat="server" Text='<%# Bind("Date") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblDateEdit" runat="server" Text='<%# Bind("Date") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="idLocalizationMaterial" SortExpression="idLocalizationMaterial" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblidLocalizationMaterialView" runat="server" Text='<%# Bind("idLocalizationMaterial") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblidLocalizationMaterialEdit" runat="server" Text='<%# Bind("idLocalizationMaterial") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Line" SortExpression="Prioritize_Line">
                            <ItemTemplate>
                                <asp:Label ID="lblLineView" runat="server" Text='<%# Bind("Line") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPrioritize_LineEdit" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order" SortExpression="Production_Order">
                            <ItemTemplate>
                                <asp:Label ID="lblProduction_OrderView" runat="server" Text='<%# Bind("Production_Order") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlProduction_OrderEdit" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Family" SortExpression="Family">
                            <ItemTemplate>
                                <asp:Label ID="lblFamilyView" runat="server" Text='<%# Bind("Family") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblFamilyEdit" runat="server" Text='<%# Bind("Family") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model" SortExpression="idMaterial">
                            <ItemTemplate>
                                <asp:Label ID="lblModelView" runat="server" Text='<%# Bind("idMaterial") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblModelEdit" runat="server" Text='<%# Bind("idMaterial") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" SortExpression="Pieces">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantityView" runat="server" Text='<%# Bind("Pieces") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblQuantityEdit" runat="server" Text='<%# Bind("Pieces") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pallets" SortExpression="Pallets">
                            <ItemTemplate>
                                <asp:Label ID="lblPalletsView" runat="server" Text='<%# Bind("Pallets") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblPalletsEdit" runat="server" Text='<%# Bind("Pallets") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SAP Order" SortExpression="SAP_Order">
                            <ItemTemplate>
                                <asp:Label ID="lblSAP_OrderView" runat="server" Text='<%# Bind("SAP_Order") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSAP_OrderEdit" runat="server" Text='<%# Bind("SAP_Order") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Minutes Loss" SortExpression="Minutes_Lost">
                            <ItemTemplate>
                                <asp:Label ID="lblMinutes_LostView" runat="server" Text='<%# Bind("Minutes_Lost") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMinutes_LostEdit" runat="server" Text='<%# Bind("Minutes_Lost") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pieces Loss" SortExpression="Pieces_Lost">
                            <ItemTemplate>
                                <asp:Label ID="lblPrices_LostView" runat="server" Text='<%# Bind("Pieces_Lost") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPieces_LostEdit" runat="server" Text='<%# Bind("Pieces_Lost") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Geo" SortExpression="Localization_Name">
                            <ItemTemplate>
                                <asp:Label ID="lblGeoView" runat="server" Text='<%# Bind("Localization_Name") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblGeoEdit" runat="server" Text='<%# Bind("Localization_Name") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                            <ItemTemplate>
                                <asp:Label ID="lblCommentsView" runat="server" Text='<%# Bind("Comments") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCommentsEdit" runat="server" Text='<%# Bind("Comments") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Toner" SortExpression="idToner">
                            <ItemTemplate>
                                <asp:Label ID="lblTonerView" runat="server" Text='<%# Bind("idToner") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblTonerEdit" runat="server" Text='<%# Bind("idToner") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PPVT" SortExpression="PPVT">
                            <ItemTemplate>
                                <asp:Label ID="lblPPVTView" runat="server" Text='<%# Bind("PPVT") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblPPVTEdit" runat="server" Text='<%# Bind("PPVT") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Yield" SortExpression="Yield">
                            <ItemTemplate>
                                <asp:Label ID="lblYieldView" runat="server" Text='<%# Bind("Yield") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblYieldEdit" runat="server" Text='<%# Bind("Yield") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" SortExpression="Type">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeView" runat="server" Text='<%# Bind("Type") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblTypeEdit" runat="server" Text='<%# Bind("Type") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pages" SortExpression="Pages">
                            <ItemTemplate>
                                <asp:Label ID="lblPagesView" runat="server" Text='<%# Bind("Pages") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblPagesEdit" runat="server" Text='<%# Bind("Pages") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VKB_Priority" SortExpression="PrimaryPriority">
                            <ItemTemplate>
                                <asp:Label ID="lblVKB_PriorityView" runat="server" Text='<%# Bind("PrimaryPriority") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblVKB_PriorityEdit" runat="server" Text='<%# Bind("PrimaryPriority") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="false" HeaderText="">
                            <EditItemTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--                                   <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit" align="center" ></asp:ImageButton>--%>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                    ToolTip="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:CommandField ShowEditButton="True" causesvalidation="false" ButtonType="Button"   headertext="Edit" />--%>
                 <%-- <asp:CommandField ShowEditButton="True" ButtonType="Image" causesvalidation="false" headertext="Edit" CancelText="cancel" UpdateText="Update"   UpdateImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"  CancelImageUrl="~/App_Themes/common/images/srd2013/cancel.png"   ItemStyle-Width="40px"     ></asp:CommandField> --%>
                        <asp:CommandField ShowEditButton="True" ButtonType="Button" causesvalidation="false" headertext="Edit" CancelText="cancel" UpdateText="Update" ItemStyle-Width="40px"     ></asp:CommandField> 
                    </Fields>
                </asp:DetailsView>
                </div>
                 <%----syalamanchili Edit grid fixing and UI changes--start --%>
               <%-- <div class="border padding-left padding-top padding-bottom">
                    <table align="center">
                        <tbody>
                            <tr>
                                <td colspan="6" class="padding-top-small">
                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                             <!--   <td class="padding-top-small">
                                    <asp:Button ID="btnLine" runat="server" Text="Get Line" OnClick="btnLine_Click" />
                                </td> --> <!--syalamanchili-->
                                <td class="padding-top-small">
                                    <asp:Label ID="lblLine" runat="server" Text="Line:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlLine" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" />
                                </td>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtFechaCaptura" runat="server" AutoPostBack="true"   OnTextChanged="txtFechaCaptura_TextChanged"  />
                                </td>

                                <td class="padding-top-small">
                                    <asp:Button ID="btnPrioritize" runat="server" Text="Search" OnClick="btnPrioritize_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="padding-top-small">
                                    <asp:Label ID="lblgvStatus" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Label ID="lblLastMaterial" runat="server" Text="Yesterday's Last Material:"></asp:Label>
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtYesterdayMaterial" runat="server" AutoPostBack="true" />
                                </td>
                           <!--     <td class="padding-top-small">
                                    <asp:Button ID="btnGetYestardayMaterial" runat="server" Text="Get Material" OnClick="btnGetYestardayMaterial_Click" />
                                </td>-->
                                <td colspan="2" class="padding-top-small" align="center">
                                    <asp:DropDownList ID="ddlYesterdayMaterial" runat="server" AutoPostBack="false" />
                                </td>
                                <td class="padding-top-small">
                                    <asp:Button ID="btnAutomaticPriority" runat="server" Text="Redefine Order" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>--%>
                 <%----syalamanchili Edit grid fixing and UI changes--End --%>
                <br />
                <div id="Data" runat="server">
                    <asp:GridView ID="gvPrioritize" runat="server" AutoGenerateColumns="False"
                        AllowPaging="False"
                        PageSize="20"
                        DataKeyNames="Date,idLocalizationMaterial"
                        OnRowDataBound="gvPrioritize_RowDataBound"
                        OnRowCommand="gvPrioritize_RowCommand"
                        CssClass="bordered min-width tablesorter"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" SortExpression="Date" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateView" runat="server" Text='<%# Bind("Date") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblDateEdit" runat="server" Text='<%# Bind("Date") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="idLocalizationMaterial" SortExpression="idLocalizationMaterial" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblidLocalizationMaterialView" runat="server" Text='<%# Bind("idLocalizationMaterial") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblidLocalizationMaterialEdit" runat="server" Text='<%# Bind("idLocalizationMaterial") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Line" SortExpression="Prioritize_Line">
                                <ItemTemplate>
                                    <asp:Label ID="lblLineView" runat="server" Text='<%# Bind("Line") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlPrioritize_LineEdit" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Order" SortExpression="Production_Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblProduction_OrderView" runat="server" Text='<%# Bind("Production_Order") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlProduction_OrderEdit" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Family" SortExpression="Family">
                                <ItemTemplate>
                                    <asp:Label ID="lblFamilyView" runat="server" Text='<%# Bind("Family") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblFamilyEdit" runat="server" Text='<%# Bind("Family") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model" SortExpression="idMaterial">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelView" runat="server" Text='<%# Bind("idMaterial") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblModelEdit" runat="server" Text='<%# Bind("idMaterial") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" SortExpression="Pieces">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantityView" runat="server" Text='<%# Bind("Pieces") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblQuantityEdit" runat="server" Text='<%# Bind("Pieces") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pallets" SortExpression="Pallets">
                                <ItemTemplate>
                                    <asp:Label ID="lblPalletsView" runat="server" Text='<%# Bind("Pallets") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblPalletsEdit" runat="server" Text='<%# Bind("Pallets") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SAP Order" SortExpression="SAP_Order">
                                <ItemTemplate>
                                    <asp:Label ID="lblSAP_OrderView" runat="server" Text='<%# Bind("SAP_Order") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSAP_OrderEdit" runat="server" Text='<%# Bind("SAP_Order") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minutes Loss" SortExpression="Minutes_Lost">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinutes_LostView" runat="server" Text='<%# Bind("Minutes_Lost") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMinutes_LostEdit" runat="server" Text='<%# Bind("Minutes_Lost") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pieces Loss" SortExpression="Pieces_Lost">
                                <ItemTemplate>
                                    <asp:Label ID="lblPieces_LostView" runat="server" Text='<%# Bind("Pieces_Lost") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPieces_LostEdit" runat="server" Text='<%# Bind("Pieces_Lost") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Geo" SortExpression="Localization_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGeoView" runat="server" Text='<%# Bind("Localization_Name") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblGeoEdit" runat="server" Text='<%# Bind("Localization_Name") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lblCommentsView" runat="server" Text='<%# Bind("Comments") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCommentsEdit" runat="server" Text='<%# Bind("Comments") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Toner" SortExpression="idToner">
                                <ItemTemplate>
                                    <asp:Label ID="lblTonerView" runat="server" Text='<%# Bind("idToner") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblTonerEdit" runat="server" Text='<%# Bind("idToner") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PPVT" SortExpression="PPVT">
                                <ItemTemplate>
                                    <asp:Label ID="lblPPVTView" runat="server" Text='<%# Bind("PPVT") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblPPVTEdit" runat="server" Text='<%# Bind("PPVT") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Yield" SortExpression="Yield">
                                <ItemTemplate>
                                    <asp:Label ID="lblYieldView" runat="server" Text='<%# Bind("Yield") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblYieldEdit" runat="server" Text='<%# Bind("Yield") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeView" runat="server" Text='<%# Bind("Type") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblTypeEdit" runat="server" Text='<%# Bind("Type") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pages" SortExpression="Pages">
                                <ItemTemplate>
                                    <asp:Label ID="lblPagesView" runat="server" Text='<%# Bind("Pages") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblPagesEdit" runat="server" Text='<%# Bind("Pages") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VKB_Priority" SortExpression="PrimaryPriority">
                                <ItemTemplate>
                                    <asp:Label ID="lblVKB_PriorityView" runat="server" Text='<%# Bind("PrimaryPriority") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblVKB_PriorityEdit" runat="server" Text='<%# Bind("PrimaryPriority") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <br />
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/common/images/srd2013/undo.png"
                                        CommandName="Cancel" ToolTip="Cancel" AlternateText="Cancel"></asp:ImageButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="EditRow" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                        ToolTip="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div align="right">
                    <asp:Button ID="btnSplitPallets" runat="server" Text="Split Pallets" Visible="true" OnClick="btnSplitPallets_Click" />
                    <asp:Button ID="btnRestoreHeijunkaBoard" runat="server" Text="Restore Heijunka" Visible="true" OnClick="btnRestoreHeijunkaBoard_Click" />
                    <br />
                </div>
                <div>
                    <asp:Label ID="LabelStatusSplit" runat="server" Text="" />
                </div>
                <br />
                <div id="divSplit" runat="server" visible="false" class="border padding-left padding-top padding-bottom">
                    <table style="width: 90%">
                        <tr>
                            <td class="padding-top-small"></td>
                            <td colspan="2" align="center" class="padding-top-small">
                                <asp:Label ID="lblSplitPallet" runat="server" Text="Split Pallet"></asp:Label>
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td align="right" class="padding-top-small">
                                <asp:Label ID="lblModelSplit" runat="server" Text="Model:"></asp:Label>
                            </td>
                            <td class="padding-top-small">
                                <asp:DropDownList ID="ddlSplitMaterial" runat="server" AutoPostBack="true" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td align="right" class="padding-top-small">
                                <asp:Label ID="lblGeoSplit" runat="server" Text="GEO:"></asp:Label>
                            </td>
                            <td class="padding-top-small">
                                <asp:TextBox ID="txtGEO" runat="server" Enabled="false" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td align="right" class="padding-top-small">
                                <asp:Label ID="lblPalletsSplit" runat="server" Text="Pallets:"></asp:Label>
                            </td>
                            <td align="left" class="padding-top-small">
                                <asp:TextBox ID="txtPallets" runat="server" Enabled="false" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td align="right" class="padding-top-small">
                                <asp:Label ID="lblSendToLineSplit" runat="server" Text="SEND TO Line:"></asp:Label>
                            </td>
                            <td align="left" class="padding-top-small">
                                <asp:DropDownList ID="ddlSplitLine" runat="server" AutoPostBack="false" OnDataBound="ddlSplitLine_DataBound" OnSelectedIndexChanged="ddlSplitLine_SelectedIndexChanged" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td align="right" class="padding-top-small">
                                <asp:Label ID="lblSendToPalletsSplit" runat="server" Text="SEND TO # of Pallets:"></asp:Label>
                            </td>
                            <td align="left" class="padding-top-small">
                                <asp:TextBox ID="txtSplitPallets" runat="server" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                        <tr>
                            <td class="padding-top-small"></td>
                            <td colspan="2" align="center" class="padding-top-small">
                                <asp:Button ID="btnAcceptSplit" runat="server" Text="Accept Split" Visible="True" OnClick="btnAcceptSplit_Click" />
                                <asp:Button ID="btnCancelSplit" runat="server" Text="Cancel" Visible="True" OnClick="btnCancelSplit_Click" />
                            </td>
                            <td class="padding-top-small"></td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
