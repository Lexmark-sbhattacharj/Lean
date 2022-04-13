using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lean.Utilities;
using System.Web.Security;

namespace LeanWeb
{
    public partial class LeanLogout : System.Web.UI.Page
    {

        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        protected override void OnInit(EventArgs e)
        {
            ViewStateUserKey = Session.SessionID;
            base.OnInit(e);
        }
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end

        protected void Page_Load(object sender, EventArgs e)
        {
            
            UserLoginInfo objUserLoginInfo = new UserLoginInfo();
            if ((UserLoginInfo)Session["UserLoginInfo"] == null)
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            else
            {
                //syelamanchal--Logging--start
                int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo.UserID.ToString(), "Logged Out");
                //syelamanchal--Logging--end
                objUserLoginInfo.Lean_App = string.Empty;
                objUserLoginInfo.UserID = string.Empty;
                // objUserLoginInfo.Domain = string.Empty;   //syelamanchali--commented for oAuth Autentication
                objUserLoginInfo.Display_Name = string.Empty;
                objUserLoginInfo.LoginType = string.Empty;
                Session["UserLoginInfo"] = objUserLoginInfo;
                Session["UserLoginInfo"] = null;
                this.Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-4));
                this.Response.Cache.SetValidUntilExpires(false);
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                this.Response.Cache.SetNoStore();
                this.Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
                this.Response.Expires = 0;
                this.Response.CacheControl = "no-cache";
                this.Response.AppendHeader("Pragma", "no-cache");
                this.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate, post-check=0, pre-check=0");
                Session.Abandon();
                

                //syelamanchal--Session Identifier Not Updated--start
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }

                if (Request.Cookies["AuthToken"] != null)
                {
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }

                if (Request.Cookies["CurrentSite"] != null)
                {
                    Response.Cookies["CurrentSite"].Value = string.Empty;
                    Response.Cookies["CurrentSite"].Expires = DateTime.Now.AddMonths(-20);
                }



                FormsAuthentication.SignOut();
                if (Session["UserLoginInfo"] == null)
                {
                    Response.Redirect("~/LeanLogin.aspx");
                }
                //syelamanchal--Session Identifier Not Updated--end
            }
        }
    }
}