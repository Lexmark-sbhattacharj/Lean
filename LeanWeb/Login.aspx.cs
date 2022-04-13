using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using LeanWeb.App_Code;

namespace LeanWeb
{
    public partial class Login : System.Web.UI.Page
    {
        public void Login_Click(object sender, EventArgs e)
        {
            string adPath = "";
            string domain = ddlDomain.SelectedItem.Text.ToString();
            if (ddlDomain.SelectedIndex > -1 & !string.IsNullOrEmpty(ddlDomain.SelectedItem.Text))
            {
                adPath = getDomainPath(domain);

                LdapAuthentication adAuth = new LdapAuthentication(adPath);
                try
                {
                    clsGlobal clsGlobal = default(clsGlobal);
                    clsGlobal = new clsGlobal();
                    myApp myApp = default(myApp);
                    myApp = new myApp();
                    if ((true == adAuth.IsAuthenticated(ddlDomain.SelectedItem.Text, txtUsername.Text, txtPassword.Text)))
                    //& clsGlobal.userSites(txtUsername.Text, ddlSite.Text)))
                    {
                        //save current site
                        string val = null;
                        val = ddlSite.Text.ToString();
                        myApp.Lean_App = myApp.set_acronym(val);
                        myApp.Description = myApp.set_desc(val);

                        #region Create the ticket, and add the groups.
                        //Create the ticket, and add the groups.
                        //bool isCookiePersistent = false;
                        //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, "");

                        ////Encrypt the ticket.
                        //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        ////Create a cookie, and then add the encrypted ticket to the cookie as data.
                        //HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        //if ((isCookiePersistent == true))
                        //{
                        //    authCookie.Expires = authTicket.Expiration;
                        //}

                        ////Add the cookie to the outgoing cookies collection.
                        //Response.Cookies.Add(authCookie);
                        //clsGlobal = null;
                        #endregion

                        //You can redirect now.
                        Response.Redirect("~/default.aspx", false);
                    }
                    else
                    {
                        errorLabel.Text = "Authentication did not succeed. Check user name , password and site.";
                    }
                }
                catch (Exception ex)
                {
                    errorLabel.Text = "Error authenticating. " + ex.Message;
                }
            }
            else
            {
                errorLabel.Text = "Authentication did not succeed. Select a valid domain.";
            }
        }

        private string getDomainPath(string domain)
        {
            switch (domain)
            {
                case "NA":
                    return "LDAP://NA.ds.lexmark.com/DC=NA,DC=ds,DC=lexmark,DC=com";
                case "AP":
                    return "LDAP://AP.ds.lexmark.com/DC=AP,DC=ds,DC=lexmark,DC=com";
                case "LA":
                    return "LDAP://LA.ds.lexmark.com/DC=LA,DC=ds,DC=lexmark,DC=com";
                case "EMEAD":
                    return "LDAP://EMEAD.ds.lexmark.com/DC=EMEAD,DC=ds,DC=lexmark,DC=com";
                default:
                    return String.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TestBusiness objTestBusiness = new TestBusiness();

                //Fill data from database to ddlDomain
                ddlDomain.DataTextField = "Domain";
                ddlDomain.DataValueField = "ID";
                ddlDomain.DataMember = "Domain";
                ddlDomain.DataSource = objTestBusiness.getDomainList();
                ddlDomain.DataBind();

                //Fill data from database to ddlSite
                ddlSite.DataTextField = "Lean_Application";
                ddlSite.DataValueField = "id_site";
                ddlSite.DataMember = "Lean_Application";
                ddlSite.DataSource = objTestBusiness.getSiteList();
                ddlSite.DataBind();
            }
            //Roles.DeleteCookie();
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //ViewState.Clear();
            //System.Web.Security.FormsAuthentication.SignOut();
            //Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
        }
    }
}