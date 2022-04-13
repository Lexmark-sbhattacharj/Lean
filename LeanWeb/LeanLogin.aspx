<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeanLogin.aspx.cs" Inherits="LeanWeb.LeanLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript">
        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        //syalamanchili----Start
        //window.setInterval(function () {
        //    if (window.location.hash != storedHash) {
        //        window.location.hash = storedHash;
        //    }
        //}, 50);
        window.setInterval(function () {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        });
        //syalamanchili----End
    </script>

    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/footer.css" />
    <%--<link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/style.css" />--%>
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/globalReset.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/lex-1280-grid-fixed.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/twelveCol-layout.css" />
    <link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/family-select.css" />
    <%--<link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/lexmark-wip.css" />--%>
    <link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/be-lexmark-top.css" />
    <link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/be-lexmark-table.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/menu-styles.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/lxk-framework.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/header-footer.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/utilities.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/visibility.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/slide-in-panel.css" />
    <%--<link rel="stylesheet" href="App_Themes/common/css/srd2013/style123.css" />--%>

    <script src="App_Themes/common/js/srd2013/jquery.js"></script>
    <script src="App_Themes/common/js/srd2013/jquery-ui.js"></script>
    <script src="App_Themes/common/js/srd2013/modernizr.js"></script>
    <script type="text/javascript" src="App_Themes/common/js/srd2013/jquery.ba-throttle-debounce.js"></script>
    <script type="text/javascript" src="App_Themes/common/js/srd2013/modernizr-2.6.3.js"></script>
    <script src="App_Themes/common/js/srd2013/be-lexmark.js"></script>
    <script type="text/javascript" src="App_Themes/common/js/srd2013/require.js"></script>
    <script type="text/javascript" src="App_Themes/common/js/srd2013/main.js"></script>
    <%--<script type="text/javascript" src="App_Themes/common/js/srd2013/calendar.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtUsername').focus();
        });
    </script>
    <%--<script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 10);
        window.onunload = function () { null };
    </script>--%>
    <link rel="shortcut icon" href="App_Themes/common/images/srd2013/lexmark-symbol-desktop-32x32.png" />

    <title>Lean Application</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE09" />
</head>
<body onload="changeHashOnLoad();">
    <form id="Form1" runat="server">
        <header id="siteHeader">
            <div class="row header">
                <div class="row container">
                    <div class="row firstrow">
                        <div id="logo" class="f-col-1"><a href="../welcome/index.cfm"><i class="icon icon--ui icon--lxk-logo"></i></a></div>
                        <div class="f-col-7-8">
                        </div>
                    </div>

                </div>
            </div>
        </header>

        <div id="wrapper">

            <div id="content" class="container_12 clearfix">
                <div class="headerTitle1">
                    <div class="headerTitle2">
                        <div class="hText">
                        </div>
                    </div>
                </div>
                <div class="mainPadding clearfix" style="min-height: 350px;">
                    <!-- Main Content -->
                    <div class="col-1">
                        <header>
                            <h1>Sign in to Lexmark Pull Replenishment System</h1>
                        </header>
                        <div class="row container" role="main">
                            <!-- BEGIN main -->
                            <article class="col-1">
                                <!-- BEGIN article col-1 -->
                                <div class="row l-pad-bottom">
                                    <section class="col-1-2 l-alley-after">
                                        <!-- START Returning Customers Section -->
                                        <div class="sign-in l-pad-thick bg--n1">

                                            <div class="info-wrapper">
                                                <div runat="server" id="idtest">
                                                    <%-- <div class="form__field">
                                                    <asp:Label id="lblusername" runat="server" Text="Short Name"/>
                                                    <asp:TextBox ID="txtUsername" runat="server" Style="min-height: 40px;" Text="" />
                                                </div>
                                                <div class="form__field">
                                                    <asp:Label id="lblpassword" runat="server" Text="Password"/>
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="min-height: 40px;" />
                                                </div>
                                                <div class="form__field">
                                                    <asp:Label id="lbldomain" runat="server" Text="Domain"/>
                                                    <asp:DropDownList ID="ddlDomain" runat="server" />
                                                </div>
                                                    </div>
                                                <div class="form__field">
                                                    <asp:Label id="lblsites" runat="server" Text="Site"/>
                                                    <asp:DropDownList ID="ddlSite" runat="server" />
                                                </div>
                                                <asp:Button ID="btnGenSites" runat="server" Text="Get Sites" OnClick="btnGenSites_Click" CssClass="btn btn--primary" />
                                                <asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="Login_Click" CssClass="btn btn--primary" />
                                                <div class="form__field">
                                                    <br />
                                                    <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300" />
                                                </div>--%>
                                                    <div class="form__field">
                                                        <asp:Label ID="lblusername" runat="server" Text="Email" />
                                                        <asp:TextBox ID="txtUserEmail" runat="server" Style="min-height: 40px;" Text="" MaxLength="50" />
                                                          <asp:RequiredFieldValidator id="usernameReq"
                                                           runat="server"
                                                           ControlToValidate="txtUserEmail"
                                                           ErrorMessage="Username is required!"
                                                           SetFocusOnError="True" ForeColor="Red" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                            runat="server" ControlToValidate="txtUserEmail" 
                                                            ErrorMessage="Enter proper email format" 
                                                            ForeColor="Red" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                        </asp:RegularExpressionValidator>  
                                                    </div>
                                                    <div class="form__field">
                                                        <asp:Label ID="lblpassword" runat="server" Text="Password" />
                                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Style="min-height: 40px;" />
                                                         <asp:RequiredFieldValidator id="passwordReq"
                                                       runat="server"
                                                       ControlToValidate="txtPassword"
                                                       ErrorMessage="Password is required!"
                                                       SetFocusOnError="True" Display="Dynamic" ForeColor="Red" />
                                                    </div>
                                                    <asp:Button ID="btnGenEmail" runat="server" Text="Authenticate" OnClick="btnGenEmail_Click" CssClass="btn btn--primary" />
                                                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn--primary" />
                                                    <div class="form__field">
                                                        <br />
                                                        <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300" />
                                                    </div>
                                                </div>
                                            </div>
                                    </section>
                                    <section class="col-1-2 l-alley-before">
                                        <div class="l-pad-top-thick"></div>
                                    </section>
                                </div>
                            </article>
                        </div>
                    </div>
                    <!-- Main Content End-->
                </div>
            </div>
        </div>
        <footer id="siteFooter" class="row">
            <section id="subFooter" class="row l-pad-thick">
                <div class="row container">
                    <div class="row row--alley-thick">
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol1">
                            <li><a href="https://www.lexmark.com">Lexmark Home</a></li>

                        </ul>
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol2">
                            <li><a href="/LeanApplication/LeanWeb/About.aspx">About Us</a></li>

                        </ul>
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol3">
                            <li><a href="/LeanApplication/LeanWeb/Contact.aspx">Contact Us</a></li>
                        </ul>
                    </div>
                </div>
            </section>
            <section id="footer" class="row l-pad-thick">
                <div class="row container" style="padding-left: 24px">
                    <div class="col-1-2 col-md-1-2 col-sm-1">
                        <ul id="footerLogo" class="horizontal-nav">
                            <li><i class="icon icon--logo icon--lxk-symbol"></i></li>
                            <li>
                                <div id="copyright" class="l-pad-vertical">
                                    <p class="company-name">Lexmark International, Inc.</p>
                                    <p>©2019 All rights reserved.</p>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="col-1-2 col-md-1-2 col-sm-1" style="padding-right: 10px;">
                        <ul id="footerNav" class="horizontal-nav">
                            <li><a href="/LeanApplication/LeanWeb/PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="/LeanApplication/LeanWeb/TermsCondition">Terms & Conditions</a></li>
                            <li><a href="/LeanApplication/LeanWeb/TermsofUse">Terms of Use</a></li>
                        </ul>
                    </div>
                </div>
            </section>
        </footer>
    </form>
</body>
</html>
