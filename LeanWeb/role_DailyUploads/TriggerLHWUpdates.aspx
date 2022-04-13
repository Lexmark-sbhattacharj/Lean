<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="TriggerLHWUpdates.aspx.cs" Inherits="LeanWeb.role_DailyUploads.TriggerLHWUpdates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
        <h3>Process LHW Updates</h3>
        <br />
        <%-- syelamanchal commented for csrf un commented below line by Prabhu to test--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                    
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="500">
                    </asp:Timer>
                    <h2>InventoryDistributer</h2>
                    <asp:GridView ID="grvInventoryDistributer" runat="server" 
                        CssClass="bordered min-width tablesorter"
                        AllowPaging="true"
                        PageSize="10"
                        OnPageIndexChanging="grvInventoryDistributer_PageIndexChanging"
                        Width="100%">
                        <EmptyDataTemplate>
                            No Data Found!
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Image ID="imgLoader1" runat="server" ImageUrl="~/App_Themes/images/loading.gif" />
                    <br />
                    <h2>InventoryInTransit</h2>
                    <asp:GridView ID="grvInventoryInTransit" runat="server" 
                        CssClass="bordered min-width tablesorter"
                        AllowPaging="true"
                        PageSize="10"
                        OnPageIndexChanging="grvInventoryInTransit_PageIndexChanging"
                        Width="100%">
                        <EmptyDataTemplate>
                            No Data Found!
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Image ID="imgLoader2" runat="server" ImageUrl="~/App_Themes/images/loading.gif" />
                    <br />
                    <h2>DemandBackOrder</h2>
                    <asp:GridView ID="grvDemandBackOrder" runat="server" 
                        CssClass="bordered min-width tablesorter"
                        AllowPaging="true"
                        PageSize="10"
                        OnPageIndexChanging="grvDemandBackOrder_PageIndexChanging"
                        Width="100%">
                        <EmptyDataTemplate>
                            No Data Found!
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Image ID="imgLoader3" runat="server" ImageUrl="~/App_Themes/images/loading.gif" />
                    <br />
                    <h2>DemandCustomerBackOrder</h2>
                    <asp:GridView ID="grvDemandCustomerBackOrder" runat="server" 
                        CssClass="bordered min-width tablesorter"
                        AllowPaging="true"
                        PageSize="10"
                        OnPageIndexChanging="grvDemandCustomerBackOrder_PageIndexChanging"
                        Width="100%">
                        <EmptyDataTemplate>
                            No Data Found!
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Image ID="imgLoader4" runat="server" ImageUrl="~/App_Themes/images/loading.gif" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <br />
        <asp:Label runat="server" ID="lblResult" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnExtractData" runat="server" Text="Check for Updates" Visible="false"/>
        <asp:Button ID="btnProcess" runat="server" Text="Process Data" onclick="btnProcess_Click" />
        <asp:Button ID="btnRevertChanges" runat="server" Text="Revert Changes (Testing Purpose)" width="210px" Visible="false" onclick="btnRevertChanges_Click" />
    </div>
</asp:Content>
