<%@ Page Title="" Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="LeanHome.aspx.cs" Inherits="LeanWeb.LeanHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
        <div id="divWelcome" runat="server" visible="true" class="border padding-left padding-top padding-bottom">
        <table style="width:100%">
            <tr>
                <td align="center" class="padding-top-small" colspan="4">
                    <h3>Pull Replenishment System</h3>
                </td>    
            </tr>
            <tr>
                <td align="center" style="width:33%" class="padding-top-small">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/Tn1.jpg"/>
                </td>
                <td align="center" style="width:33%" class="padding-top-small">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/Tn2.jpg" />
                </td>
                <td align="center" style="width:33%" class="padding-top-small">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/common/images/srd2013/Tn3.jpg" />
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>
