<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Format.aspx.cs" Inherits="LeanWeb.Format" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/footer.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/style.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/globalReset.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/lex-1280-grid-fixed.css" />
    <link rel="stylesheet" type="text/css" href="App_Themes/common/css/srd2013/twelveCol-layout.css" />
    <link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/family-select.css" />
    <link rel="stylesheet" type="text/css" media="all" href="App_Themes/common/css/srd2013/lexmark-wip.css" />
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

    <link rel="shortcut icon" href="App_Themes/common/images/srd2013/lexmark-symbol-desktop-32x32.png" />

    <title>Lean Application</title>
</head>
<script type="text/javascript">
    (function ($) {
        $.fn.dropdown = function (options) {
            var settings = $.extend({}, options);
            $.extend(this, settings);

            function getPosition(element) {
                var position = element.offset();
                return position;
            }

            function vertPositioning(element) {
                var position = getPosition(element);
                if ((position.top) < (element.find(".dropdown__menu").height() + element.height())) {
                    return "bottom";
                } else if (($(document).height() - position.top) < (element.find(".dropdown__menu").height() + element.height() + 50)) {
                    return "top";
                } else {
                    return "default";
                }
            }

            function horzPositioning(element) {
                var position = getPosition(element);
                if ((position.left) < (element.find(".dropdown__menu").width())) {
                    return "left";
                } else if (($(document).width() - position.left) < (element.find(".dropdown__menu").width())) {
                    return "right";
                } else {
                    return "default";
                }
            }

            function positionMenu(element) {
                switch (vertPositioning(element)) {
                    case "bottom":
                        if (element.hasClass("dropdown--align-top")) {
                            element.removeClass("dropdown--align-top");
                        }
                        break;
                    case "top":
                        element.addClass("dropdown--align-top");
                        break;
                    default:
                }
                switch (horzPositioning(element)) {
                    case "left":
                        if (element.hasClass("dropdown--align-right")) {
                            element.removeClass("dropdown--align-right");
                        }
                        element.addClass("dropdown--align-left");
                        break;
                    case "right":
                        if (element.hasClass("dropdown--align-left")) {
                            element.removeClass("dropdown--align-left");
                        }
                        element.addClass("dropdown--align-right");
                        break;
                    default:
                        if (!element.hasClass("dropdown--align-left") && !element.hasClass("dropdown--align-right")) {
                            if (element.closest("[dir=rtl]").size()) {
                                element.addClass("dropdown--align-right");
                            } else {
                                element.addClass("dropdown--align-left");
                            }
                        }
                }
                return element;
            }

            function openMenu(element) {
                if (!element.closest(".navigation").length) {
                    $("body").addClass("dropdown--is-open");
                }
                element.addClass("dropdown--is-open");

                //IE7 needs to clone the dropdown as the last element in the DOM to fix it's z-indexing bug
                if (Modernizr.generatedcontent === false && /MSIE (\d+\.\d+);/.test(navigator.userAgent) && new Number(RegExp.$1) < 8) {
                    var menuCopy = $(element).find(".dropdown__menu").clone(),
                        menuPosition = getPosition($(element).find(".dropdown__menu"));

                    if (element.hasClass("dropdown--align-top")) {
                        menuCopy.addClass("dropdown--align-top");
                    }
                    $("body").append(menuCopy);
                    menuCopy.css("top", menuPosition.top).css("left", menuPosition.left).addClass("dropdown--is-open");
                }
            }

            function closeMenu(element) {
                //IE7 needs to remove the cloned dropdown
                if (Modernizr.generatedcontent === false && /MSIE (\d+\.\d+);/.test(navigator.userAgent) && new Number(RegExp.$1) < 8) {
                    $("body > .dropdown__menu").remove();
                }
                $(".dropdown--is-open").removeClass("dropdown--is-open");
            }

            function isMenuOpen(element) {
                if (element.hasClass("dropdown--is-open")) {
                    return true;
                } else {
                    return false;
                }
            }

            function triggerDropdown(element) {
                element.find(".dropdown__trigger").click(function (e) {
                    e.stopPropagation();
                    if (isMenuOpen(element)) {
                        closeMenu(element);
                    } else {
                        closeMenu(element);
                        openMenu(element);
                    }
                });
                $(document).click(function () {
                    closeMenu(element);
                });
                return element;
            }

            function positionArrow(element) {
                var caret = element.find(".dropdown__caret"),
                    caretWidth = parseFloat(caret.css("border-left-width")),
                    arrow = element.find(".dropdown__arrow"),
                    arrowWidth = parseFloat(arrow.css("border-left-width"));
                if (caret.size()) {
                    var caretPosition = caret.position();
                    if (element.hasClass("dropdown--align-right")) {
                        arrow.css("right", (element.width() - (caretPosition.left + arrowWidth + (.5) * caretWidth)));
                        arrow.css("left", "auto");
                    } else {
                        arrow.css("left", ((caretPosition.left) + arrowWidth - (.5) * caretWidth));
                        arrow.css("right", "auto");
                    }
                }
            }

            function addArrow(element) {
                if (!element.find(".dropdown__arrow").length) {
                    element.find(".dropdown__menu").prepend('<span class="dropdown__arrow"><span class="dropdown__arrow-inner"></span></span>');
                }
            }

            function addClose(element) {
                if (!element.find(".dropdown__close").length) {
                    element.find(".dropdown__menu").prepend('<span class="dropdown__close">&times;</span>').click(function () {
                        closeMenu(element);
                    });
                }
            }

            function repositionDropdown(element) {
                $(window).resize($.debounce(250, function () {
                    positionMenu(element);
                    positionArrow(element);
                }));
            }

            return this.each(function (options) {
                var element = $(this);
                addArrow(element);
                addClose(element);
                positionMenu(element);
                positionArrow(element);
                triggerDropdown(element);
                repositionDropdown(element);
            });
        };
        $(document).ready(function () {
            $('[data-js=dropdown]').dropdown();
        });
    })(jQuery);
</script>
<body>
    <form id="Form1" runat="server">
        <header id="siteHeader">
            <div class="row header">
                <div class="row container">
                    <div class="row firstrow">
                        <div id="logo" class="f-col-1-8"><a href="../welcome/index.cfm"><i class="icon icon--ui icon--lxk-logo"></i></a></div>
                        <div class="f-col-7-8">
                        </div>
                    </div>
                    <div class="row l-hidden--lt-laptop">
                        <div class="col-1">
                            <nav id="mainNav">
                                <ul class="horizontal-nav">

                                    <li class="dropdown dropdown--align-left" data-js="dropdown">
                                        <a href="#" class="dropdown__trigger">Menu Header 1</a>
                                        <div class="dropdown__menu menu--1,-col">
                                            <span class="dropdown__close">×</span><span class="dropdown__arrow"><span class="dropdown__arrow-inner"></span></span>
                                            <div class="dropdown__menu-inner">
                                                <div class="row">
                                                    <div class="col-1-1 l-pad-horizontal">
                                                        <h2>Sub Header 1</h2>
                                                        <ul>
                                                            <li><a href="#">Menu 1</a></li>
                                                        </ul>
                                                        <h2>Sub Header 2</h2>
                                                        <ul>

                                                            <li><a title="My Request" href="#">Menu 2</a></li>

                                                            <li><a title="Search Request" href="#">Menu 3</a></li>

                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>

                                    <li class="dropdown dropdown--align-left" data-js="dropdown">
                                        <a href="#" class="dropdown__trigger">Menu Header 1</a>
                                        <div class="dropdown__menu menu--1,-col">
                                            <span class="dropdown__close">×</span><span class="dropdown__arrow"><span class="dropdown__arrow-inner"></span></span>
                                            <div class="dropdown__menu-inner">
                                                <div class="row">
                                                    <div class="col-1-1 l-pad-horizontal">
                                                        <h2>Sub Header 1</h2>
                                                        <ul>
                                                            <li><a href="#">Menu 1</a></li>
                                                        </ul>
                                                        <h2>Sub Header 2</h2>
                                                        <ul>

                                                            <li><a title="My Request" href="#">Menu 2</a></li>

                                                            <li><a title="Search Request" href="#">Menu 3</a></li>

                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </nav>
                            <nav id="secondaryUtilityNav">
                                <ul class="horizontal-nav">
                                    <span style="font-size: 12.2px; font-weight: normal; font-style: normal;">Welcome,</span>
                                    <li class="lxk-hdr-sign-in dropdown dropdown--align-left" data-js="dropdown"><a class="dropdown__trigger" data-name="atg-sign-in">
                                        <div class="menu-item">
                                            <asp:Label ID="lblUserName" runat="server" Text="Sudipta Kundu"></asp:Label>
                                        </div>
                                    </a>
                                        <div class="dropdown__menu">
                                            <span class="dropdown__close">×</span><span class="dropdown__arrow"><span class="dropdown__arrow-inner"></span></span>
                                            <div class="dropdown__menu-inner">
                                                <ul>
                                                    <li><a title="Document" href="#" target="new">Download User Guide</a></li>
                                                    <li><a class="_self " href="#" target="_self" title="SIGN OUT">Sign out</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </nav>
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
                    Main content goes here......
                    <br />
                    Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />Main content goes here......
                    <br />
                    <!-- Main Content End-->
                </div>
            </div>
        </div>
        <footer id="siteFooter" class="row">
            <section id="subFooter" class="row l-pad-thick">
                <div class="row container">
                    <div class="row row--alley-thick">
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol1">
                            <li><a href="#">Link 1</a></li>

                        </ul>
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol2">
                            <li><a href="#">Link 3</a></li>

                        </ul>
                        <ul class="col-1-3 col-sm-1 col-md-1-3" id="subFooterCol3">
                            <li><a href="#">Link 4</a></li>
                        </ul>
                    </div>
                </div>
            </section>
            <section id="footer" class="row l-pad-thick">
                <div class="row container" style="padding-left:24px">
                    <div class="col-1-2 col-md-1-2 col-sm-1">
                        <ul id="footerLogo" class="horizontal-nav">
                            <li><i class="icon icon--logo icon--lxk-symbol"></i></li>
                            <li>
                                <div id="copyright" class="l-pad-vertical">
                                    <p class="company-name">Lexmark International, Inc.</p>
                                    <p>©2017 All rights reserved.</p>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="col-1-2 col-md-1-2 col-sm-1" style="padding-right: 10px;">
                        <ul id="footerNav" class="horizontal-nav">
                            <li><a href="#">Privacy Policy</a></li>
                            <li><a href="#">Terms & Conditions</a></li>
                            <li><a href="#">Terms of Use</a></li>
                        </ul>
                    </div>
                </div>
            </section>
        </footer>
    </form>
</body>
</html>
