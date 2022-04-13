<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="Families.aspx.cs" Inherits="LeanWeb.role_DefineParameters.Families" %>
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
    <h1>Families Administration</h1>
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
                        <td align="center">
                        <asp:HiddenField ID="LEAN_APP" runat ="server" />
                          <asp:GridView ID="gvFamily" runat="server" AutoGenerateColumns="False" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="#284775" ><tr><td><font color="white"><b>Families Information</b></font></td></tr></table>' 
                            Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333"  GridLines="None"
                            DataKeyNames="Family" DataSourceID="dsFamilies">
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
                                        <asp:Label ID="txtPlatform" runat="server" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Platform") %>' Width="150px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlatform" runat="server" Text='<%# Bind("Platform") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775"  Width="150px" />
                                    <ItemStyle Font-Size="X-Small" Height="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Family" SortExpression="Family">
                                    <HeaderStyle Font-Bold="true" Font-Size="X-Small" />
                                    <EditItemTemplate>
                                        <asp:Label ID="txtFamily" runat="server" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Family") %>' Width="150px"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFamily" runat="server" Text='<%# Bind("Family") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775"  Width="150px" />
                                    <ItemStyle Font-Size="X-Small" Height="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Average Standard Cost $" SortExpression="AverageCost">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAverageCost" runat="server" Font-Names="Verdana"
                                            Font-Size="X-Small" MaxLength="5" Text='<%# Bind("AverageCost") %>' Width="100px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAverageCost" runat="server" Text='<%# Bind("AverageCost") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775" Font-Size="X-Small"  Width="150px" />
                                    <ItemStyle Font-Size="X-Small" Height="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Initial Inventory" SortExpression="InitialInventory">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtInitialInventory" runat="server" Font-Names="Verdana"
                                            Font-Size="X-Small" MaxLength="9" Text='<%# Bind("InitialInventory") %>' Width="100px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblInitialInventory" runat="server" Text='<%# Bind("InitialInventory") %>'></asp:Label>
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
                        <asp:SqlDataSource ID="dsFamilies" runat="server" 
                            ConflictDetection="CompareAllValues" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            DeleteCommand="DELETE FROM [Family] WHERE [Family] = @original_Family and lean_application=@Lean_App" 
                            InsertCommand="INSERT INTO [Family] ([Family],[Platform],[AverageCost],InitialInventory,Lean_Application) VALUES (@Family,@Platform, @AverageCost,@InitialInventory,@Lean_Application)" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectCommand="SELECT [Family],[Platform],[AverageCost],[InitialInventory] FROM [Family] where Lean_Application=@Lean_App ORDER BY [Platform],[Family]" 
                            UpdateCommand="UPDATE [Family] SET [AverageCost] = @AverageCost, [InitialInventory]=@InitialInventory WHERE [Family] = @original_Family AND [Platform] = @original_Platform AND Lean_Application=@Lean_App " 
                            >
                            <SelectParameters>
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </SelectParameters>
                            <DeleteParameters>
                                <asp:Parameter Name="original_Family" Type="Int32" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Family" Type="String" />
                                <asp:Parameter Name="AverageCost" Type="Decimal" />
                                <asp:Parameter Name="InitialInventory" Type="Decimal" />
                                <asp:Parameter Name="original_Family" Type="String" />
                                <asp:Parameter Name="original_Platform" Type="String" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_App" 
                                    PropertyName="Value" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Family" Type="String" />
                                <asp:Parameter Name="Platform" Type="String" />
                                <asp:Parameter Name="AverageCost" Type="Decimal" />
                                <asp:Parameter Name="InitialInventory" Type="Decimal" />
                                <asp:ControlParameter ControlID="LEAN_APP" Name="Lean_Application" 
                                    PropertyName="Value" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <br />
                        <asp:DetailsView ID="dvFamily" runat="server" AutoGenerateRows="False" 
                            DataSourceID="dsFamilies" Height="50px" 
                            Width="350px" 
                            BorderStyle="None" Visible="False" OnModeChanged="dvFamily_ModeChanged"  OnItemInserted="dvFamily_ItemInserted"  >
                            <FieldHeaderStyle Width="150px" />
                            <Fields>
                                <asp:TemplateField HeaderText="Family" SortExpression="Family">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Family") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Family") %>' MaxLength="30" 
                                            Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFamily" runat="server" 
                                            ControlToValidate="TextBox1" ErrorMessage="Family" 
                                            style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Family") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775" Font-Size="X-Small" Width="150px" ForeColor="White"
                                        Font-Bold="True" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Main Family" SortExpression="Platform">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPlatform" runat="server" Text='<%# Bind("Platform") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="txtPlatform" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("Platform") %>' MaxLength="30" 
                                            Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlatfrom" runat="server" 
                                            ControlToValidate="txtPlatform" ErrorMessage="Platform" 
                                            style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Platform") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#284775" Font-Size="X-Small" Width="150px" ForeColor="White"
                                        Font-Bold="True" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Avarage Std Cost" SortExpression="AverageCost">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AverageCost") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("AverageCost") %>' MaxLength="4" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAverageCost" runat="server" 
                                            ControlToValidate="TextBox2" ErrorMessage="Capacity" style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AverageCost") %>'></asp:Label>
                                    </ItemTemplate>
                                         <HeaderStyle BackColor="#284775" Font-Size="X-Small" Width="150px" ForeColor="White"
                                        Font-Bold="True" />
                                    <ItemStyle Font-Size="X-Small" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Initial Inventory" SortExpression="InitialInventory">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("InitialInventory") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBoxInitialInventory" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                            Font-Size="X-Small" Text='<%# Bind("InitialInventory") %>' MaxLength="4" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAInitialInventory" runat="server" 
                                            ControlToValidate="TextBoxInitialInventory" ErrorMessage="InitialInventory" style="font-size: X-Small">*</asp:RequiredFieldValidator>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("InitialInventory") %>'></asp:Label>
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
                         <asp:Button ID="btnNew" runat="server" Text="New Family" CssClass="buttonBox" Width="100px" Visible="false" onclick="btnNew_Click" />          
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
