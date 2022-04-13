<%@ Page Language="C#" MasterPageFile="~/Lean.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LeanWeb.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
        
   
        <div id="content-container-two-column" style="right: 0px; top: 0px; height: auto;">
        <h3>Change Password</h3>
          <asp:TextBox ID="txtpassword" TextMode="Password" placeholder="Enter Password" runat="server" />
        <asp:RequiredFieldValidator ID="req6" runat="server" ControlToValidate="txtPassword" Text="*" />
        <asp:RegularExpressionValidator ID="RegExp1" runat="server"    
            ErrorMessage="Password must contain  numbers, uppercase and lowercase letters, and at least 4 or more characters"
            ControlToValidate="txtPassword"    
            ValidationExpression="^[a-zA-Z0-9\s]{4,}$" />
        <br/>
       
        <asp:TextBox ID="txtConformpass" TextMode="Password" placeholder="Confirm Password" runat="server" />
        <asp:CompareValidator runat="server" ID="Comp1" ControlToValidate="txtPassword" ControlToCompare="txtConformpass" Text="Password does not match" />
        <br/>
        <asp:Button ID="BtnChangePass" type="Submit" runat="server" Text="Change Password" OnClick="ChangePass_Click" />
            <br/>
            <asp:Label ID="lblsuccess" runat="server" Text=""></asp:Label>
   
    </div>
</asp:Content>