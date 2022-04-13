<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LeanWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="300px" style="border: thin solid #C0C0C0; background-color: White">
                <tr>
                    <td colspan="2" bgcolor="Gray">
                        <asp:Label ID="lblLogin" runat="server" ForeColor="White" Font-Bold="false" Font-Names="Vedana" Font-Size="X-Small">Login</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%">
                        <asp:Label ID="Label2" runat="server" Text="User Name:" ForeColor="Gray" Font-Bold="False" />
                    </td>
                    <td align="left" style="width: 70%">
                        <asp:TextBox ID="txtUsername" runat="server" Width="80%" Font-Size="X-Small" Font-Bold="True" Font-Names="Vedana" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%">
                        <asp:Label ID="Label1" runat="server" Text="Password:" ForeColor="Gray" Font-Bold="False" />
                    </td>
                    <td align="left" style="width: 70%">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="80%" Font-Size="X-Small" Font-Bold="True" Font-Names="Vedana" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%">
                        <asp:Label ID="Label3" runat="server" Text="Domain:" ForeColor="Gray" Font-Bold="False" />
                    </td>
                    <td align="left" style="width: 70%">
                        <asp:DropDownList ID="ddlDomain" runat="server" Width="83%" Font-Names="Verdana" Font-Size="X-Small" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%">
                        <asp:Label ID="Label4" runat="server" Text="Site:" ForeColor="Gray" Font-Bold="False" />
                    </td>
                    <td align="left" style="width: 70%">
                        <asp:DropDownList ID="ddlSite" runat="server" Width="83%" Font-Names="Verdana" Font-Size="X-Small" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="chkPersist" runat="server" Text="Persist Cookie" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Login_Click" CssClass="buttonBox" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
