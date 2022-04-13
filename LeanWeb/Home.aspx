<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LeanWeb.Home" MasterPageFile="~/Lean.Master" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Main" ContentPlaceHolderID="ContentMain" runat="server" Visible="true">
    <div class="headerTitle1">
        <div class="headerTitle2">
            <div class="hText">Welcome to Lean</div>
        </div>
    </div>
    <br />
    <asp:GridView ID="grvTest" runat="server" AutoGenerateColumns="True" CssClass="bordered min-width tablesorter">
    </asp:GridView>
    <br />
    <asp:Button ID="btnRedirect" runat="server" Text="Redirect" OnClick="btnRedirect_Click" />
    <br />
    <br />
</asp:Content>
