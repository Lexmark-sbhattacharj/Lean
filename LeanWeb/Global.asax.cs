using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Lean.Utilities;

namespace LeanWeb
{
    public class Global : System.Web.HttpApplication
    {
        static string callback = System.Configuration.ConfigurationManager.AppSettings["callback"].ToString();
        static string redirectlink= System.Configuration.ConfigurationManager.AppSettings["route"].ToString();
        protected void Application_Start(object sender, EventArgs e)
        {
           
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", callback, redirectlink);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Request.IsSecureConnection == true)
            //    {
            //        Response.Cookies["ASP.NET_SessionId"].Secure = true;
            //    }
            //}
            //catch (Exception)
            //{
            //}
            //Session.Timeout = 60;
            //if ((UserLoginInfo)Session["UserLoginInfo"] == null)
            //{
            //    Response.Redirect("~/LeanLogin.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/LeanHome.aspx");
            //}

            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //var httpCookie = new HttpCookie("mycookie", "leanqa.lexmark.com");
            //httpCookie.Path += ";SameSite=Strict";

            //Response.SetCookie(httpCookie);
            //System.Web.Helpers.AntiForgeryConfig.RequireSsl = HttpContext.Current.Request.IsSecureConnection;
            //syelamanchal
            //if (Request.IsSecureConnection == true)
            //{ 
            //   Response.Cookies["ASP.NET_SessionID"].Secure = true;
            //}
            //if (Request.IsSecureConnection)
            //{
            //    if (Response.Cookies.Count > 0)
            //    {
            //        foreach (string s in Response.Cookies.AllKeys)
            //        {
            //            if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")
            //            {
            //                Response.Cookies[s].Secure = true;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    //if not secure, then don't set session cookie
            //    Response.Cookies["asp.net_sessionid"].Value = string.Empty;
            //    Response.Cookies["asp.net_sessionid"].Expires = new DateTime(2018, 01, 01);
            //}
            //            System.Web.Configuration.SessionStateSection sessionState =
            //(System.Web.Configuration.SessionStateSection)System.Configuration.ConfigurationManager.GetSection("system.web/sessionState");
            //            string sidCookieName = sessionState.CookieName;

            //            if (Request.Cookies[sidCookieName] != null)
            //            {
            //                HttpCookie sidCookie = Response.Cookies[sidCookieName];
            //                sidCookie.Value = Session.SessionID;
            //                sidCookie.HttpOnly = true;
            //                sidCookie.Secure = true;
            //                sidCookie.Path = "/";
            //            }
            //syelamanchal

        }
        //syelamanchal
        protected void Application_PreSendRequestHeaders()
        {
            HttpContext.Current.Response.Headers.Add("X-Frame-Options", "DENY");
            HttpContext.Current.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            HttpContext.Current.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            HttpContext.Current.Response.Headers.Remove("Server");
            Response.Headers.Remove("Server");
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string _sessionIPAddress = string.Empty;
            //string _sessionBrowserInfo = string.Empty;
            if (HttpContext.Current.Session != null)
            {
                string _encryptedString = Convert.ToString(Session["encryptedSession"]);
                byte[] _encodedAsBytes = System.Convert.FromBase64String(_encryptedString);
                string _decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(_encodedAsBytes);

                char[] _separator = new char[] { '^' };
                if (_decryptedString != string.Empty && _decryptedString != "" && _decryptedString != null)
                {
                    string[] _splitStrings = _decryptedString.Split(_separator);
                    if (_splitStrings.Count() > 0)
                    {
                        //string UserId = _splitStrings[0];
                        //string Ticks = _splitStrings[1];
                        //string dummyGuid = _splitStrings[3];

                        if (_splitStrings[2].Count() > 0)
                        {
                            string[] _userBrowserInfo = _splitStrings[2].Split('~');
                            if (_userBrowserInfo.Count() > 0)
                            {
                                //_sessionBrowserInfo = _userBrowserInfo[0];
                                _sessionIPAddress = _userBrowserInfo[1];
                            }
                        }
                    }
                }

                string _currentUseripAddress;
                if (string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                {
                    _currentUseripAddress = Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    _currentUseripAddress =
                    Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                }

                System.Net.IPAddress result;
                if (!System.Net.IPAddress.TryParse(_currentUseripAddress, out result))
                {
                    result = System.Net.IPAddress.None;
                }

                if (_sessionIPAddress != "" && _sessionIPAddress != string.Empty)
                {
                    //Same way we can validate browser info also...
                    //string _currentBrowserInfo = Request.Browser.Browser + Request.Browser.Version + Request.UserAgent;
                    if (_sessionIPAddress != _currentUseripAddress)
                    {
                        Session.RemoveAll();
                        Session.Clear();
                        Session.Abandon();
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddSeconds(-30);
                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                        Response.Redirect("LeanLogout.aspx");
                    }
                    else
                    {
                        //Valid User
                    }
                }
            }
        }


        //syelamanchal

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}