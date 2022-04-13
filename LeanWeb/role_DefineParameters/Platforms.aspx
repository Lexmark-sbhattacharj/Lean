<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="Platforms.aspx.cs" Inherits="LeanWeb.role_DefineParameters.Platforms" %>
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
    <div id="content-container-two-column" style="right: 0px; top: 0px; height: auto;" >
    <h1>Platforms Administration</h1>
    <asp:ScriptManager ID="ScriptManager1" ScriptMode="release" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(ieAjaxBeginRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ieAjaxPageLoaded);
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label id="LabelStatus" runat="server" Width="365px" Text="Status..." ForeColor="Maroon" Font-Bold="False"></asp:Label>
                    &nbsp;
            <div id="div2" runat="server">
                <table style="width:90%">
                    <tr>
                    <asp:HiddenField ID="LEAN_APP" runat ="server" />
                        <td align="center">
                          <asp:GridView ID="gvPlatforms" runat="server" AutoGenerateColumns="False" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="#284775" ><tr><td><font color="white"><b>Platforms Information</b></font></td></tr></table>' 
                            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
                            DataKeyNames="Platform" DataSourceID="dsPlatforms">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="imgbtnUpdate" runat="server" CausesValidation="True" ImageUrl="~/App_Themes/images/table_save.ico"
                                            CommandName="Update" Tooltip="Update"></asp:ImageButton>
                                            <asp:ImageButton ID="imgbtnCancel" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/images/table_error.ico"
                                            CommandName="Cancel" Tooltip="Cancel"></asp:ImageButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ImageUrl="~/App_Themes/images/table_edit.ico" ToolTip="Edit" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="60px"/>
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Platform" SortExpression="Platform">
                                    <HeaderStyle Font-Bold="true" Font-Size="X-Small" />
                                    <EditItemTemplate>
                                        <asp:Label ID="TextBox1" runat="server" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Platform") %>' Width="150px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Platform") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775"  Width="150px" />
                                    <ItemStyle Font-Size="X-Small" Height="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Extra Capacity (Pallet Per Day)" SortExpression="ExtraCapacity">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana" 
                                            Font-Size="X-Small" MaxLength="5" Text='<%# Bind("ExtraCapacity") %>' Width="150px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ExtraCapacity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775" Font-Size="X-Small"  Width="150px" />
                                    <ItemStyle Font-Size="X-Small" Height="20px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#284775" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="LightGray"/>
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsPlatforms" runat="server" 
                            ConflictDetection="CompareAllValues" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            DeleteCommand="DELETE FROM [Platform] WHERE [Platform] = @original_Platform and lean_application=@Lean_App " 
                            InsertCommand="INSERT INTO [Platform] ([Platform], [ExtraCapacity],[Lean_Application]) VALUES (@Platform, @ExtraCapacity,@Lean_App)" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectCommand="SELECT [Platform], [ExtraCapacity] FROM [Platform] where Lean_application=@Lean_App ORDER BY [Platform]" 
                            UpdateCommand="UPDATE [Platform] SET [ExtraCapacity] = @ExtraCapacity WHERE [Platform] = @original_Platform AND [ExtraCapacity] = @original_ExtraCapacity AND Lean_Application = @Lean_App" 
                            >
                            <SelectParameters>
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="original_Platform" Type="String" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Platform" Type="String" />
                                <asp:Parameter Name="ExtraCapacity" Type="Int32" />
                                  <asp:Parameter Name="original_Platform" Type="String" />
                                <asp:Parameter Name="original_ExtraCapacity" Type="Int32" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Platform" Type="String" />
                                <asp:Parameter Name="ExtraCapacity" Type="Int32" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <br />
                        <asp:DetailsView ID="dvPlatform" runat="server" AutoGenerateRows="False" 
                            DataSourceID="dsPlatforms" Height="50px" 
                            Width="350px" 
                            BorderStyle="None" Visible="False" OnModeChanged="dvPlatform_ModeChanged"  OnItemInserted="dvPlatform_ItemInserted"  >
                            <FieldHeaderStyle Width="150px" />
                            <Fields>
                                <asp:TemplateField HeaderText="Platform" SortExpression="Platform">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Platform") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Platform") %>' MaxLength="30" 
                                            Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlatform" runat="server" 
                                            ControlToValidate="TextBox1" ErrorMessage="Platform" 
                                            style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Platform") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775" Font-Size="X-Small" Width="150px" ForeColor="White"
                                        Font-Bold="True" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Extra Capacity" SortExpression="ExtraCapacity">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ExtraCapacity") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("ExtraCapacity") %>' MaxLength="4" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorExtraCapacity" runat="server" 
                                            ControlToValidate="TextBox2" ErrorMessage="Capacity" style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ExtraCapacity") %>'></asp:Label>
                                    </ItemTemplate>
                                         <HeaderStyle BackColor="#284775" Font-Size="X-Small" Width="150px" ForeColor="White"
                                        Font-Bold="True" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <InsertItemTemplate>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            HeaderText="You must enter a value in the following fields:" />
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                            CommandName="Insert" Text="Insert" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small"></asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                            CommandName="Cancel" Text="Cancel" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small"></asp:LinkButton>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="New" Text="New"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Height="20px" />
                                </asp:TemplateField>
                            </Fields>
                        </asp:DetailsView>
                        <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                         <asp:Button ID="btnNew" runat="server" Text="New Platform" CssClass="buttonBox" Width="100px" Visible="false" onclick="btnNew_Click" />          
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc1:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server" TargetControlID="UpdatePanel1">
        <Animations>
            <OnUpdating>
               <EnableAction AnimationTarget="UpdatePanel1" Enabled="false" />
                <%--<FadeOut AnimationTarget="UpdatePanel1" minimumOpacity=".3" />--%>
            </OnUpdating>
            <OnUpdated>
                <EnableAction AnimationTarget="UpdatePanel1" Enabled="true" />
                <%--<FadeIn AnimationTarget="UpdatePanel1" minimumOpacity=".3" />--%>
            </OnUpdated>
        </Animations>
    </cc1:UpdatePanelAnimationExtender>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" DynamicLayout="False">
        <ProgressTemplate>
            <table style="width:90%; height:45px;">
              <tr>
                    <td align="center" valign="top">
                       <asp:Panel ID="Panel1" runat="server" Height="20px" HorizontalAlign="Center" Width="120px">
                            <asp:Label ID="lblProcess" runat="server" Text="Please Wait ..." Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333"></asp:Label>
                            <br />
                            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/App_Themes/images/loading.gif" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ProgressTemplate>
    </asp:UpdateProgress>
  </div>
</asp:Content>
