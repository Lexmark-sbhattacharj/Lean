<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="Lines.aspx.cs" Inherits="LeanWeb.role_DefineParameters.Lines" %>

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
        <h3>Lines Administration</h3>
        <asp:ScriptManager ID="ScriptManager1" ScriptMode="release" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="border padding-left padding-top">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelStatus" runat="server" Width="365px" Text="Status..." ForeColor="Maroon" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />

                <div id="dvData" runat="server">
                    <asp:GridView ID="gvLines" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True"
                        PageSize="30"
                        DataKeyNames="idLine"
                        EnableModelValidation="True"
                        CssClass="bordered min-width tablesorter"
                        OnRowEditing="gvLines_RowEditing"
                        OnRowCancelingEdit="gvLines_RowCancelingEdit"
                        OnRowUpdating="gvLines_RowUpdating"
                        OnRowCommand="gvLines_RowCommand"
                        OnRowDeleting="gvLines_RowDeleting"
                        OnPageIndexChanging="gvLines_PageIndexChanging"
                        ShowFooter="false"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="idLine" ShowHeader="false" Visible="false" ReadOnly="true" />
                            <asp:TemplateField HeaderText="idLine" SortExpression="idLine" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="lblidLineEdit" runat="server" Text='<%# Bind("idLine") %>' Visible="false"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblidLineView" runat="server" Text='<%# Bind("idLine") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Line" SortExpression="Line">                                
                                <ItemTemplate>
                                    <asp:Label ID="lblLine" runat="server" Text='<%# Bind("Line") %>'></asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Capacity (Units Per Day)" SortExpression="Capability">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCapacityEdit" runat="server" MaxLength="20" Text='<%# Bind("Capability") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtMaterialEdit" runat="server"
                                        ErrorMessage="Capacity is mandatory"
                                        ControlToValidate="txtCapacityEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtCapacityEdit" runat="server"
                                        ErrorMessage="Capacity should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtCapacityEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCapacity" runat="server" Text='<%# Bind("Capability") %>'></asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Planner (Shortname)" SortExpression="Planner">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPlannerEdit" runat="server" MaxLength="20" Text='<%# Bind("Planner") %>' CssClass="input-width-60"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqValtxtPlannerEdit" runat="server"
                                        ErrorMessage="Planner is mandatory"
                                        ControlToValidate="txtPlannerEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regValtxtPlannerEdit" runat="server"
                                        ErrorMessage="Planner should be Alpha-Numeric"
                                        ValidationExpression="^[a-zA-Z0-9]+$"
                                        ControlToValidate="txtPlannerEdit"
                                        Display="None"
                                        ValidationGroup="Edit">
                                    </asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPlanner" runat="server" Text='<%# Bind("Planner") %>'></asp:Label>
                                </ItemTemplate>                               
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/table_save.ico"
                                        CommandName="Update" ToolTip="Update" AlternateText="Update" ValidationGroup="Edit"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/common/images/srd2013/undo.png" 
                                        CommandName="Cancel" ToolTip="Cancel" AlternateText="Cancel"></asp:ImageButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" AlternateText="Edit" ImageUrl="~/App_Themes/common/images/srd2013/table_edit.ico"
                                        ToolTip="Edit" />
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/cancel.png"
                                        CommandName="Delete" ToolTip="Delete" AlternateText="Delete" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' OnClientClick="javascript: return confirm('Are you sure, you want to delete this?')"></asp:ImageButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                                                       
                        </Columns>
                    </asp:GridView>
                </div>               
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
