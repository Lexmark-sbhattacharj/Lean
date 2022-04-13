<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProdPriority.aspx.cs" Inherits="LeanWeb.role_ProductionPlanners.UpdateProdPriority" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link rel="stylesheet" type="text/css" href="../App_Themes/common/css/srd2013/jquery-ui.css" />
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

    <script>
        function CloseWindow() {
            window.close();
        }
        window.onunload = refreshParent;
        function refreshParent() {
            window.opener.location.reload();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="padding-left padding-top padding-bottom">
            <asp:DetailsView ID="ProdPriorityEdit" runat="server"
                OnItemUpdating="ProdPriorityEdit_ItemUpdating"
                DataKeyNames="Date,idLocalizationMaterial"
                OnDataBound="ProdPriorityEdit_DataBound"
                OnItemCommand="ProdPriorityEdit_ItemCommand"
                CssClass="bordered min-width tablesorter"
                AutoGenerateRows="false"
                DefaultMode="Edit"
                Width="90%">
                <Fields>
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
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit" align="center"></asp:ImageButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                ToolTip="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
