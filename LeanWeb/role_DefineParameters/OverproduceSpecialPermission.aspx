<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="OverproduceSpecialPermission.aspx.cs" Inherits="LeanWeb.role_DefineParameters.OverproduceSpecialPermission" %>

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
    <div>
        <h3>Special Permission to Produce Administration</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
        </script>
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
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelStatus" runat="server" Text="Status..."></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div id="dvData" runat="server">
                    <asp:GridView ID="gvSpecialPermission" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="20"
                        DataKeyNames="idOverproduce"
                        EnableModelValidation="True"
                        CssClass="bordered min-width tablesorter"
                        OnRowEditing="gvSpecialPermission_RowEditing"
                        OnRowCancelingEdit="gvSpecialPermission_RowCancelingEdit"
                        OnRowUpdating="gvSpecialPermission_RowUpdating"
                        OnRowCommand="gvSpecialPermission_RowCommand"
                        OnRowDataBound="gvSpecialPermission_RowDataBound"
                        OnRowDeleting="gvSpecialPermission_RowDeleting"
                        OnPageIndexChanging="gvSpecialPermission_PageIndexChanging"
                        ShowFooter="true"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="idOverproduce" ShowHeader="false" Visible="false" ReadOnly="true" />
                            <asp:TemplateField HeaderText="ID" SortExpression="idOverproduce" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidOverproduceEdit" runat="server" Text='<%# Bind("idOverproduce") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidOverproduceView" runat="server" Text='<%# Bind("idOverproduce") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblidOverproduceInsert" runat="server" Text="" Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkActiveEdit" runat="server" Checked='<%# Bind("Active") %>' HeaderText="Active" Enabled="true" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("Active") %>' HeaderText="Active" Enabled="false" />
                                    <%--EVAL can also be used--%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="chkActiveInsert" runat="server" Checked="true" Enabled="false" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" SortExpression="Date">
                                <EditItemTemplate>
                                    <asp:Label ID="lblDateEdit" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDateView" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblDateInsert" runat="server" Text='<%# DateTime.Now.ToShortDateString()%>'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part No" SortExpression="idMaterial">
                                <EditItemTemplate>
                                    <asp:Label ID="lblPartNoEdit" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNoView" runat="server" Text='<%# Bind("idMaterial") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlPartNoInsert" runat="server"></asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DC" SortExpression="Line">
                                <EditItemTemplate>
                                    <asp:Label ID="lblDCEdit" runat="server" Text='<%# Bind("Localization_Name") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDCView" runat="server" Text='<%# Bind("Localization_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlDCInsert" runat="server"></asp:DropDownList>
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
                            <asp:TemplateField HeaderText="Upload_Date" SortExpression="Date">
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>