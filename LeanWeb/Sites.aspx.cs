using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using Lean.Utilities;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using LeanBusiness;


using LeanWeb.App_Code;
using System.Web.Security;

namespace LeanWeb
{
    public partial class Sites : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            //First, check for the existence of the Anti-XSS cookie
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;

            //If the CSRF cookie is found, parse the token from the cookie.
            //Then, set the global page variable and view state user
            //key. The global variable will be used to validate that it matches 
            //in the view state form field in the Page.PreLoad method.
            if (requestCookie != null
                && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                //Set the global token variable so the cookie value can be
                //validated against the value in the view state form field in
                //the Page.PreLoad method.
                _antiXsrfTokenValue = requestCookie.Value;

                //Set the view state user key, which will be validated by the
                //framework during each request
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            //If the CSRF cookie is not found, then this is a new session.
            else
            {
                //Generate a new Anti-XSRF token
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");

                //Set the view state user key, which will be validated by the
                //framework during each request
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                //Create the non-persistent CSRF cookie
                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    //Set the HttpOnly property to prevent the cookie from
                    //being accessed by client side script
                    HttpOnly = true,

                    //Add the Anti-XSRF token to the cookie value
                    Value = _antiXsrfTokenValue
                };

                //If we are using SSL, the cookie should be set to secure to
                //prevent it from being sent over HTTP connections
                if (FormsAuthentication.RequireSSL &&
                    Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }

                //Add the CSRF cookie to the response
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            //During the initial page load, add the Anti-XSRF token and user
            //name to the ViewState
            if (!IsPostBack)
            {
                //Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

                //If a user name is assigned, set the user name
                ViewState[AntiXsrfUserNameKey] =
                       Context.User.Identity.Name ?? String.Empty;
            }
            //During all subsequent post backs to the page, the token value from
            //the cookie should be validated against the token in the view state
            //form field. Additionally user name should be compared to the
            //authenticated users name
            else
            {
                //Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] !=
                         (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of " +
                                        "Anti-XSRF token failed.");
                }
            }
        }

        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end

        protected void Page_Load(object sender, EventArgs e)
        {    

            if (!IsPostBack)
            {
                TestBusiness objTestBusiness = new TestBusiness();
                UserLoginInfo objUserLoginInfo = new UserLoginInfo();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                //  DropDownList ddlSite = (DropDownList)Page.FindControl("ddlSite");
                ddlSite.DataTextField = "Lean_Application";
                ddlSite.DataValueField = "id_site";
                ddlSite.DataMember = "Lean_Application";
                ddlSite.DataSource = objTestBusiness.getSiteListbyname(objUserLoginInfo.UserID.ToString());
                ddlSite.DataBind();
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            myApp myApp = default(myApp);
            myApp = new myApp();
            // DropDownList ddlSite = (DropDownList)Page.FindControl("ddlSite");
            UserLoginInfo objUserLoginInfo = new UserLoginInfo();
            objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
            TestBusiness objTestBusiness = new TestBusiness();
            string val = null;
            val = ddlSite.Text.ToString();
            myApp.Lean_App = myApp.set_acronym(val);
            myApp.Description = myApp.set_desc(val);
            string Acronym = null;
            Acronym = objTestBusiness.getAcronym(val);
            //String Acronym = objTestBusiness.getAcronym(ddlSite.SelectedItem.Text.ToString());
            objUserLoginInfo.Lean_App = Acronym;
            Session["UserLoginInfo"] = objUserLoginInfo;

            

            //syelamanchal--Logging--start
            int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
            objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
            objTestBusiness.Log("INFO", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo.UserID.ToString(), "Log In");
            //syelamanchal--Logging--end

            Response.Redirect("~/LeanHome.aspx");
        }

        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   DropDownList ddlSite = (DropDownList)Page.FindControl("ddlSite");
            UserLoginInfo objUserLoginInfo = new UserLoginInfo();
            objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
            TestBusiness objTestBusiness = new TestBusiness();
            String Acronym = objTestBusiness.getAcronym(ddlSite.Text.ToString());
            objUserLoginInfo.Lean_App = Acronym;
            Session["UserLoginInfo"] = objUserLoginInfo;
        }
    }
}