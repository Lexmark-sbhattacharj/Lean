<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWebConnection.aspx.cs" MasterPageFile="~/Lean.Master" Inherits="LeanWeb.TestWebConnection" %>

<asp:Content ID="testabcd" ContentPlaceHolderID="ContentMain" runat="server" Visible="true">
    <h2>Welcome to Lean</h2>

    <asp:GridView ID="grvTest" runat="server" AutoGenerateColumns="True" OnDataBinding="Button1_Click">
</asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
<br />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LeanConnectionString %>" SelectCommand="SELECT idLine, Line, Capability, Planner, Lean_Application FROM LA.Line"></asp:SqlDataSource>
</asp:Content>
