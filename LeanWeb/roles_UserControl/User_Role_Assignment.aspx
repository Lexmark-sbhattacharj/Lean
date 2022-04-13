<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="User_Role_Assignment.aspx.cs" Inherits="LeanWeb.roles_UserControl.User_Role_Assignment" %>

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
        <h3>User Role Maintenance</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="border padding-left padding-top padding-bottom">
                    <table>
                        <tbody>
                            <tr>
                                <td class="padding-top-small">
                                    <span class="bold">Roles</span></td>
                                <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlRoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleList_SelectedIndexChanged" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div>
                    <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:GridView ID="dgRolesUserList" runat="server" AutoGenerateColumns="False"
                        CssClass="bordered min-width tablesorter"
                        AllowPaging="True"
                        PageSize="20"
                        EmptyDataText="No users belong to this role."
                        OnRowDeleting="dgRolesUserList_RowDeleting"
                        OnPageIndexChanging="dgRolesUserList_PageIndexChanging"
                        Width="100%" >
                        <Columns>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/common/images/srd2013/cancel.png"
                                        CommandName="Delete" ToolTip="Borrar"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User" SortExpression="Users">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="UserNameLabel"
                                        Text='<%# Container.DataItem %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Navigate">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "User_Sites_Assignment.aspx?user=" + (Container.DataItem).ToString() %>' Text='Sites'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="border padding-left padding-top padding-bottom" align="center">
                    <table align="center">
                        <tbody>
                            <tr>
                                <td class="padding-top-small" style="width: 100px">
                                    <asp:Label ID="lblShortName" runat="server" Text="Email ID:"></asp:Label>
                                    &nbsp;
                                </td>

                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtUserNameToAddToRole" AutoPostBack="false" runat="server" />
                                     <asp:RequiredFieldValidator id="usernameReq"
                                                           runat="server"
                                                           ControlToValidate="txtUserNameToAddToRole"
                                                           ErrorMessage="Username is required!"
                                                           SetFocusOnError="True" ForeColor="Red" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                            runat="server" ControlToValidate="txtUserNameToAddToRole" 
                                                            ErrorMessage="Enter proper email format" 
                                                            ForeColor="Red" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                        </asp:RegularExpressionValidator>  
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <%--syelamanchali--removing domain from application--start--%>
                             <%--<td class="padding-top-small" style="width: 100px">
                                    <asp:Label ID="Label1" runat="server" Text="User Domain:" ></asp:Label>
                                    &nbsp;
                                </td>
                                  <td class="padding-top-small">
                                    <asp:DropDownList ID="ddlDomain" runat="server" />
                                    <br />
                                </td>--%>
                                <%--syelamanchali--removing domain from application--end--%>
                           </tr>
                            <tr>
								<%-- syelamanchili--Two step login--start --%>
                                <td style="height: 36px; width: 100px"></td>
                                 <td class="padding-top-small" style="height: 36px">
                                    <asp:CheckBox ID="chklocal" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="true" Text="Local User"  />
                                    <br />
                                </td>
                            </tr>
                            <tr id="passid" runat="server">
                                <td class="padding-top-small" style="width: 100px">
                                    <asp:Label ID="Label2" runat="server" Text="Password:" ></asp:Label>
                                    &nbsp;
                                </td>
                                <td class="padding-top-small">
                                    <asp:TextBox ID="txtuserpassword"  AutoPostBack="false" runat="server" />
                                    <asp:RequiredFieldValidator id="passwordReq"
                                                       runat="server"
                                                       ControlToValidate="txtuserpassword"
                                                       ErrorMessage="Password is required!"
                                                       SetFocusOnError="True" Display="Dynamic" ForeColor="Red" />
                                    <br />
                                </td>
                              </tr>
                                <%-- syelamanchili--Two step login--end --%>
                            
                            <tr>
                                <td colspan="2" align="center" class="padding-top-small">
                                    <br />
                                    &nbsp;
                         <asp:Button ID="btnAddUserToRoleButton" runat="server" Text="Add User in Role"  OnClick="btnAddUserToRoleButton_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
