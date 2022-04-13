<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="SpecialBid.aspx.cs" Inherits="LeanWeb.role_DefineParameters.SpecialBid" %>
<%@ Import Namespace="Lean.Utilities" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
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
        <h3>Special Bids Administration</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="border padding-left padding-top padding-bottom">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <span class="bold">Filter</span></td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtFilter" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" Visible="True" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div id="dvData" runat="server">

                    <asp:GridView ID="gvSpecialBids" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="20"
                        DataKeyNames="idSpecialBid"
                        EnableModelValidation="True"
                        CssClass="bordered min-width tablesorter"
                        OnRowEditing="gvSpecialBids_RowEditing"
                        OnRowCancelingEdit="gvSpecialBids_RowCancelingEdit"
                        OnRowUpdating="gvSpecialBids_RowUpdating"
                        OnRowCommand="gvSpecialBids_RowCommand"
                        OnPageIndexChanging="gvSpecialBids_PageIndexChanging"
                        OnRowDeleting="gvSpecialBids_RowDelete"
                        ShowFooter="true"
                        Width="100%">
                        
                        <Columns>
                            <asp:BoundField DataField="idSpecialBid" ShowHeader="false" Visible="false" ReadOnly="true" />
                            <asp:TemplateField HeaderText="ID" SortExpression="Line" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidSpecialBidEdit" runat="server" Text='<%# Bind("idSpecialBid") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidSpecialBidView" runat="server" Text='<%# Bind("idSpecialBid") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblidSpecialBidInsert" runat="server" Text="" Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Active?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("Active") %>' HeaderText="Active" Enabled="false" />
                                    <%--EVAL can also be used--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkActiveEdit" runat="server" Checked='<%# Bind("Active") %>' HeaderText="Active" Enabled="true" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="chkActiveInsert" runat="server" Checked="true" Enabled="false" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part No" SortExpression="idMaterial">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaterialEdit" runat="server" MaxLength="20" Text='<%# Bind("idMaterial") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtMaterialEdit" runat="server"
                                        ErrorMessage="Part Number is mandatory"
                                        ControlToValidate="txtMaterialEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtMaterialEdit" runat="server"
                                        ErrorMessage="Part Number should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtMaterialEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMaterial" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMaterialInsert" runat="server" MaxLength="20" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtMaterialInsert" runat="server"
                                        ErrorMessage="Part Number is mandatory"
                                        ControlToValidate="txtMaterialInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtMaterialInsert" runat="server"
                                        ErrorMessage="Part Number should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtMaterialInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Plant No" SortExpression="idLocalization">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLocalizationEdit" runat="server" MaxLength="4" Text='<%# Bind("idLocalization") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtLocalizationEdit" runat="server"
                                        ErrorMessage="ID Localization is mandatory"
                                        Display="None"
                                        ControlToValidate="txtLocalizationEdit"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <%-- syalamanchili--Allow only numbers in Plant No. column--start --%>
                                   <%-- <asp:RegularExpressionValidator ID="regValtxtLocalizationEdit" runat="server"
                                        ErrorMessage="Plant No. should be Alpha-Numeric"
                                        Display="None"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtLocalizationEdit"
                                        ValidationGroup="Edit">--%>
                                    <asp:RegularExpressionValidator ID="regValtxtLocalizationEdit" runat="server"
                                        ErrorMessage="Plant No. should be Alpha-Numeric"
                                        Display="None"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtLocalizationEdit"
                                        ValidationGroup="Edit">
                                    <%-- syalamanchili--Allow only numbers in Plant No. column--End --%>  
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLocalization" runat="server" Text='<%# Bind("idLocalization") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtLocalizationInsert" runat="server" MaxLength="4" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtLocalizationInsert" runat="server"
                                        ErrorMessage="Plant No. is mandatory"
                                        Display="None"
                                        ControlToValidate="txtLocalizationInsert"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                     <%-- syalamanchili--Allow only numbers in Plant No. column--start --%>
                                    <%--<asp:RegularExpressionValidator ID="regValtxtLocalizationInsert" runat="server"
                                        ErrorMessage="ID Localization should be Alpha-Numeric"
                                        Display="None"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtLocalizationInsert"
                                        ValidationGroup="Add">--%>
                                    <asp:RegularExpressionValidator ID="regValtxtLocalizationInsert" runat="server"
                                        ErrorMessage="Plant No. should be Numeric"
                                        Display="None"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtLocalizationInsert"
                                        ValidationGroup="Add">
                                         <%-- syalamanchili--Allow only numbers in Plant No. column--End --%>
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuantityEdit" runat="server" MaxLength="5" Text='<%# Bind("Quantity") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtQuantityEdit" runat="server"
                                        ErrorMessage="Quantity is mandatory"
                                        Display="None"
                                        ControlToValidate="txtQuantityEdit"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtQuantityEdit" runat="server"
                                        ErrorMessage="Quantity should be Numeric"
                                        Display="None"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtQuantityEdit"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtQuantityInsert" runat="server" MaxLength="5" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtQuantityInsert" runat="server"
                                        ErrorMessage="Quantity is mandatory"
                                        Display="None"
                                        ControlToValidate="txtQuantityInsert"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtQuantityInsert" runat="server"
                                        ErrorMessage="Quantity should be Numeric"
                                        Display="None"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtQuantityInsert"
                                        ValidationGroup="Add">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Line" SortExpression="Line">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelLineEdit" runat="server" Text='<%# Bind("Lean_Application") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelLineView" runat="server" Text='<%# Bind("Lean_Application") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelLineInsert" runat="server" Text='<%# ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App %>'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User" SortExpression="User"
                                HeaderStyle-CssClass="halign-left" ItemStyle-CssClass="halign-left" FooterStyle-CssClass="halign-left">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelUserEdit" runat="server" Text='<%# Bind("Upload_User") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelUserView" runat="server" Text='<%# Bind("Upload_User") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelUserInsert" runat="server" Text='<%# ((UserLoginInfo)Session["UserLoginInfo"]).UserID.ToUpper() %>'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelDateEdit" runat="server" Text='<%# Bind("Upload_Date", "{0:M-dd-yyyy}")%>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDateView" runat="server" Text='<%# Bind("Upload_Date", "{0:M-dd-yyyy}")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelDateInsert" runat="server" Text='<%# DateTime.Now.ToShortDateString()%>'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comments" SortExpression="Comments"
                                HeaderStyle-CssClass="halign-left" ItemStyle-CssClass="halign-left" FooterStyle-CssClass="halign-left">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCommentsEdit" runat="server" MaxLength="90" Text='<%# Bind("Comments")%>' CssClass="input-width-180"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqtxtCommentsEdit" runat="server"
                                        ErrorMessage="Comments section is mandatory"
                                        Display="None"
                                        ControlToValidate="txtCommentsEdit"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("Comments")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCommentsInsert" runat="server" MaxLength="90" Text="" CssClass="input-width-180"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqtxtCommentsInsert" runat="server"
                                        ErrorMessage="Comments section is mandatory"
                                        Display="None"
                                        ControlToValidate="txtCommentsInsert"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Actions">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/common/images/srd2013/undo.png"
                                        CommandName="Cancel" ToolTip="Cancel" AlternateText="Cancel"></asp:ImageButton>
                                    <%--write a confirmbox in onclientClick and then delete--%>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                        ToolTip="Edit" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/cancel.png"
                                        CommandName="Delete" ToolTip="Delete" AlternateText="Delete" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClientClick="javascript: return confirm('Are you sure, you want to delete this?')" ></asp:ImageButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" CommandName="Add" AlternateText="Add" ImageUrl="~/App_Themes/common/images/srd2013/add.png"
                                        ValidationGroup="Add" ToolTip="Add" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
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

                    <asp:Button ID="btnNew" runat="server" Text="Bulk Upload" Visible="True" OnClick="btnNew_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
