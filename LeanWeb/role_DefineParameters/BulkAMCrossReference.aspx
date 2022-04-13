<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="BulkAMCrossReference.aspx.cs" Inherits="LeanWeb.role_DefineParameters.BulkAMCrossReference" %>

<%@ Import Namespace="Lean.Utilities" %>
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
        <h3>Bulk AM Cross-Reference Administration</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="border padding-left padding-top padding-bottom">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <asp:Label ID="LabelStatus" runat="server" Width="365px" Text="Status..." ForeColor="Maroon" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div id="dvData" runat="server">
                    <asp:GridView ID="gvBulkAMCatalag" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="20"
                        DataKeyNames="Bulk"
                        EnableModelValidation="True"
                        CssClass="bordered min-width tablesorter"
                        OnRowEditing="gvBulkAMCatalag_RowEditing"
                        OnRowCancelingEdit="gvBulkAMCatalag_RowCancelingEdit"
                        OnRowUpdating="gvBulkAMCatalag_RowUpdating"
                        OnRowCommand="gvBulkAMCatalag_RowCommand"
                        OnRowDeleting="gvBulkAMCatalag_RowDeleting"
                        OnPageIndexChanging="gvBulkAMCatalag_PageIndexChanging"
                        ShowFooter="true"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Bulk" ShowHeader="false" Visible="false" ReadOnly="true" />
                            <asp:TemplateField HeaderText="AMHidden" SortExpression="AM" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblAMHiddenEdit" runat="server" Text='<%# Bind("AM") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAMHiddenView" runat="server" Text='<%# Bind("AM") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblAMHiddenInsert" runat="server" Text="" Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LocalizationHidden" SortExpression="idLocalization" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblLocalizationHiddenEdit" runat="server" Text='<%# Bind("idLocalization") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblLocalizationHiddenView" runat="server" Text='<%# Bind("idLocalization") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblLocalizationHiddenInsert" runat="server" Text="" Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bulk" SortExpression="Bulk" Visible="true">
                                <EditItemTemplate>
                                    <asp:Label ID="lblBulkEdit" runat="server" Text='<%# Bind("Bulk") %>' Visible="true"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBulkView" runat="server" Text='<%# Bind("Bulk") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtBulkInsert" runat="server" MaxLength="20" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtBulkInsert" runat="server"
                                        ErrorMessage="Bulk is mandatory"
                                        ControlToValidate="txtBulkInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtBulkInsert" runat="server"
                                        ErrorMessage="Bulk should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtBulkInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AM" SortExpression="AM">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAMEdit" runat="server" MaxLength="20" Text='<%# Bind("AM") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValAMEdit" runat="server"
                                        ErrorMessage="AM is mandatory"
                                        ControlToValidate="txtAMEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtAMEdit" runat="server"
                                        ErrorMessage="AM should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtAMEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAM" runat="server" Text='<%# Bind("AM") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtAMInsert" runat="server" MaxLength="20" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtAMInsert" runat="server"
                                        ErrorMessage="AM is mandatory"
                                        ControlToValidate="txtAMInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtAMInsert" runat="server"
                                        ErrorMessage="AM should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtAMInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID Localization" SortExpression="idLocalization">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtidLocalizationEdit" runat="server" MaxLength="20" Text='<%# Bind("idLocalization") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtidLocalizationEdit" runat="server"
                                        ErrorMessage="ID Localization is mandatory"
                                        ControlToValidate="txtidLocalizationEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtidLocalizationEdit" runat="server"
                                        ErrorMessage="ID Localization should be Numeric"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtidLocalizationEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidLocalization" runat="server" Text='<%# Bind("idLocalization") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtidLocalizationInsert" runat="server" MaxLength="20" Text="" CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtidLocalizationInsert" runat="server"
                                        ErrorMessage="ID Localization is mandatory"
                                        ControlToValidate="txtidLocalizationInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtidLocalizationInsert" runat="server"
                                        ErrorMessage="ID Localization should be Alpha-Numeric"
                                        ValidationExpression="^\d+$"
                                        ControlToValidate="txtidLocalizationInsert"
                                        Display="None"
                                        ValidationGroup="Add">
                                    </asp:RegularExpressionValidator>
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
                                        CommandName="Delete" ToolTip="Delete" AlternateText="Delete" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClientClick="javascript: return confirm('Are you sure, you want to delete this?')"></asp:ImageButton>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>