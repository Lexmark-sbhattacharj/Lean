using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using LeanWeb.App_Code;
using Lean.Utilities;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Security;

namespace LeanWeb
{
    public partial class LeanLogin : System.Web.UI.Page
    {
        // syelamanchal--remove ldap and externallogin--start
        //    //syelamanchal--2 step login--start
        //    static string Userpass = "";
        //    //syelamanchal--2 step login--end
        //    UserLoginInfo objUserLoginInfo;
        //    public void Login_Click(object sender, EventArgs e)
        //    {
        //        string adPath = "";

        //        string domain = ddlDomain.SelectedItem.Text.ToString();
        //        if (ddlDomain.SelectedIndex > -1 & !string.IsNullOrEmpty(ddlDomain.SelectedItem.Text))
        //        {
        //            adPath = getDomainPath(domain);

        //            LdapAuthentication adAuth = new LdapAuthentication(adPath);
        //            TestBusiness objTestBusiness = new TestBusiness();
        //            try
        //            {
        //                clsGlobal clsGlobal = default(clsGlobal);
        //                clsGlobal = new clsGlobal();
        //                myApp myApp = default(myApp);
        //                myApp = new myApp();
        //                //syelamanchali--2 step login--start
        //                //string UserAuthenticated = adAuth.IsAuthenticated(ddlDomain.SelectedItem.Text, txtUsername.Text, txtPassword.Text.Trim());
        //                if (objTestBusiness.getAuthType(txtUsername.Text) == true)
        //                {
        //                    string UserAuthenticated = adAuth.IsAuthenticated(ddlDomain.SelectedItem.Text, txtUsername.Text, Userpass);
        //                    if ((string.Empty != UserAuthenticated) & clsGlobal.userSites(txtUsername.Text, ddlSite.Text))
        //                    {
        //                        //save current site
        //                        string val = null;
        //                        val = ddlSite.Text.ToString();
        //                        myApp.Lean_App = myApp.set_acronym(val);
        //                        myApp.Description = myApp.set_desc(val);
        //                        string Acronym = null;
        //                        Acronym = objTestBusiness.getAcronym(val);
        //                        string testverb = User.Identity.Name;


        //                        getUserLoginInfo(Acronym, txtUsername.Text.ToString(), ddlDomain.SelectedItem.Text.ToString(), UserAuthenticated);
        //                        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        //                        objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
        //                        string test = objUserLoginInfo1.Domain + objUserLoginInfo1.Lean_App + objUserLoginInfo1.UserID + "   " + objUserLoginInfo1.Display_Name;

        //                        #region Create the ticket, and add the groups.
        //                        //Create the ticket, and add the groups.
        //                        //bool isCookiePersistent = false;
        //                        //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, "");

        //                        ////Encrypt the ticket.
        //                        //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

        //                        ////Create a cookie, and then add the encrypted ticket to the cookie as data.
        //                        //HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        //                        //if ((isCookiePersistent == true))
        //                        //{
        //                        //    authCookie.Expires = authTicket.Expiration;
        //                        //}

        //                        ////Add the cookie to the outgoing cookies collection.
        //                        //Response.Cookies.Add(authCookie);
        //                        //clsGlobal = null;
        //                        #endregion

        //                        //You can redirect now.
        //                        Response.Redirect("~/LeanHome.aspx", false);
        //                    }
        //                    else
        //                    {
        //                        errorLabel.Text = "Authentication did not succeed. Check user name , password and site.";
        //                    }
        //                }
        //                else if ((clsGlobal.userSites(txtUsername.Text, ddlSite.Text)) && (ToSHA256(Userpass) == objTestBusiness.getUserPassword(txtUsername.Text)))

        //                {
        //                    //save current site
        //                    string val = null;
        //                    val = ddlSite.Text.ToString();
        //                    myApp.Lean_App = myApp.set_acronym(val);
        //                    myApp.Description = myApp.set_desc(val);
        //                    string Acronym = null;
        //                    Acronym = objTestBusiness.getAcronym(val);
        //                    string testverb = User.Identity.Name;


        //                    getUserLoginInfo(Acronym, txtUsername.Text.ToString(), ddlDomain.SelectedItem.Text.ToString(), txtUsername.Text);
        //                    UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        //                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
        //                    string test = objUserLoginInfo1.Domain + objUserLoginInfo1.Lean_App + objUserLoginInfo1.UserID + "   " + objUserLoginInfo1.Display_Name;

        //                    #region Create the ticket, and add the groups.
        //                    //Create the ticket, and add the groups.
        //                    //bool isCookiePersistent = false;
        //                    //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, "");

        //                    ////Encrypt the ticket.
        //                    //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

        //                    ////Create a cookie, and then add the encrypted ticket to the cookie as data.
        //                    //HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        //                    //if ((isCookiePersistent == true))
        //                    //{
        //                    //    authCookie.Expires = authTicket.Expiration;
        //                    //}

        //                    ////Add the cookie to the outgoing cookies collection.
        //                    //Response.Cookies.Add(authCookie);
        //                    //clsGlobal = null;
        //                    #endregion

        //                    //You can redirect now.
        //                    Response.Redirect("~/LeanHome.aspx", false);
        //                }
        //                else
        //                {
        //                    errorLabel.Text = "Authentication did not succeed. Check user name , password and site.";
        //                }
        //                //syelamanchal--2 step login--end

        //                //syelamanchal


        //            }
        //            catch (Exception ex)
        //            {
        //                errorLabel.Text = ex.Message;
        //            }
        //        }
        //        else
        //        {
        //            errorLabel.Text = "Authentication did not succeed. Select a valid domain.";
        //        }
        //    }

        //    private void getUserLoginInfo(string Acronym, string UserID, string Domain, string Display_Name)
        //    {
        //        objUserLoginInfo = new UserLoginInfo();
        //        objUserLoginInfo.Lean_App = Acronym;
        //        objUserLoginInfo.UserID = UserID;
        //        objUserLoginInfo.Domain = Domain;
        //        objUserLoginInfo.Display_Name = Display_Name;
        //        Session["UserLoginInfo"] = objUserLoginInfo;

        //    }

        //    private string getDomainPath(string domain)
        //    {
        //        //syelamanchal--Get activedirectory info dinamically from web.config--start 
        //        //switch (domain)
        //        //{               
        //        //    case "NA":
        //        //        return "LDAP://NA.ds.lexmark.com:636/DC=NA,DC=ds,DC=lexmark,DC=com";
        //        //    case "AP":
        //        //        return "LDAP://AP.ds.lexmark.com:636/DC=AP,DC=ds,DC=lexmark,DC=com";
        //        //    case "LA":
        //        //        return "LDAP://LA.ds.lexmark.com:636/DC=LA,DC=ds,DC=lexmark,DC=com";
        //        //    case "EMEAD":
        //        //        return "LDAP://EMEAD.ds.lexmark.com:636/DC=EMEAD,DC=ds,DC=lexmark,DC=com";
        //        //    default:
        //        //        return String.Empty;
        //        //}
        //        switch (domain)
        //        {
        //            case "NA":
        //                return System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionString"].ConnectionString;
        //            case "AP":
        //                return System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionStringAP"].ConnectionString;
        //            case "LA":
        //                return System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionStringLA"].ConnectionString;
        //            case "EMEAD":
        //                return System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionStringEMEAD"].ConnectionString;
        //            default:
        //                return string.Empty;
        //        }
        //        //syelamanchal--Get activedirectory info dinamically from web.config--End
        //    }

        //    protected void Page_Load(object sender, EventArgs e)
        //    {
        //        if (!IsPostBack)
        //        {
        //            TestBusiness objTestBusiness = new TestBusiness();

        //            //Fill data from database to ddlDomain
        //            ddlDomain.DataTextField = "Domain";
        //            ddlDomain.DataValueField = "ID";
        //            ddlDomain.DataMember = "Domain";
        //            ddlDomain.DataSource = objTestBusiness.getDomainList();
        //            ddlDomain.DataBind();

        //            //syelamanchali--2 step login--start
        //            //Fill data from database to ddlSite
        //            //ddlSite.DataTextField = "Lean_Application";
        //            //ddlSite.DataValueField = "id_site";
        //            //ddlSite.DataMember = "Lean_Application";
        //            //ddlSite.DataSource = objTestBusiness.getSiteList();
        //            //ddlSite.DataBind();
        //            //syelamanchili--2 step login--end


        //            //syelamanchili--2 step login--start
        //            btnLogin.Visible = false;
        //            ddlSite.Visible = false;
        //            btnLogin.Visible = false;
        //            lblsites.Text = "";

        //            txtUsername.Visible = true;
        //            txtPassword.Visible = true;
        //            ddlDomain.Visible = true;

        //            lblusername.Text = "Short Name";
        //            lblpassword.Text = "Password";
        //            lbldomain.Text = "Domain";
        //            //syelamanchili--2 step login--end
        //        }

        //        #region Roles
        //        //Roles.DeleteCookie();
        //        //HttpContext.Current.Session.Clear();
        //        //HttpContext.Current.Session.Abandon();
        //        //ViewState.Clear();
        //        //System.Web.Security.FormsAuthentication.SignOut();
        //        //Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
        //        #endregion

        //    }

        //    //syelamanchali--2 step login--start
        //    protected void btnGenSites_Click(object sender, EventArgs e)
        //    {
        //        string adPath = "";

        //        string domain = ddlDomain.SelectedItem.Text.ToString();
        //        if (ddlDomain.SelectedIndex > -1 & !string.IsNullOrEmpty(ddlDomain.SelectedItem.Text))
        //        {
        //            adPath = getDomainPath(domain);

        //            LdapAuthentication adAuth = new LdapAuthentication(adPath);
        //            TestBusiness objTestBusiness = new TestBusiness();
        //            try
        //            {
        //                clsGlobal clsGlobal = default(clsGlobal);
        //                clsGlobal = new clsGlobal();
        //                if (objTestBusiness.getAuthType(txtUsername.Text) == true)
        //                {
        //                    string UserAuthenticated = adAuth.IsAuthenticated(ddlDomain.SelectedItem.Text, txtUsername.Text, txtPassword.Text.Trim());

        //                    if ((string.Empty != UserAuthenticated))
        //                    {
        //                        Userpass = txtPassword.Text.Trim();
        //                        ddlSite.DataTextField = "Lean_Application";
        //                        ddlSite.DataValueField = "id_site";
        //                        ddlSite.DataMember = "Lean_Application";
        //                        //ddlSite.DataSource = objTestBusiness.getSiteList();
        //                        ddlSite.DataSource = objTestBusiness.getSiteListbyname(txtUsername.Text.ToString());
        //                        ddlSite.DataBind();
        //                        //syelamanchili
        //                        btnLogin.Visible = true;
        //                        ddlSite.Visible = true;
        //                        btnLogin.Visible = true;
        //                        lblsites.Text = "Site";
        //                        lblusername.Text = "";
        //                        lblpassword.Text = "";
        //                        lbldomain.Text = "";

        //                        txtUsername.Visible = false;
        //                        txtPassword.Visible = false;
        //                        ddlDomain.Visible = false;
        //                        btnGenSites.Visible = false;

        //                        idtest.Visible = false;

        //                        string Password = txtPassword.Text.Trim();
        //                        txtPassword.Attributes.Add("value", Password);

        //                        //syelamanchili
        //                    }
        //                    else
        //                    {
        //                        errorLabel.Text = "Authentication did not succeed. Check user name , password and site.";
        //                    }
        //                }
        //                else
        //                {
        //                    if (ToSHA256(txtPassword.Text.Trim()) == objTestBusiness.getUserPassword(txtUsername.Text))
        //                    {
        //                        Userpass = txtPassword.Text.Trim();
        //                        ddlSite.DataTextField = "Lean_Application";
        //                        ddlSite.DataValueField = "id_site";
        //                        ddlSite.DataMember = "Lean_Application";
        //                        // ddlSite.DataSource = objTestBusiness.getSiteList();
        //                        ddlSite.DataSource = objTestBusiness.getSiteListbyname(txtUsername.Text.ToString());
        //                        ddlSite.DataBind();
        //                        //syelamanchili
        //                        btnLogin.Visible = true;
        //                        ddlSite.Visible = true;
        //                        btnLogin.Visible = true;
        //                        lblsites.Text = "Site";
        //                        lblusername.Text = "";
        //                        lblpassword.Text = "";
        //                        lbldomain.Text = "";

        //                        txtUsername.Visible = false;
        //                        txtPassword.Visible = false;
        //                        ddlDomain.Visible = false;
        //                        btnGenSites.Visible = false;

        //                        idtest.Visible = false;

        //                        string Password = txtPassword.Text.Trim();
        //                        txtPassword.Attributes.Add("value", Password);
        //                    }
        //                    else
        //                    {
        //                        errorLabel.Text = "Authentication did not succeed. Check user name , password and site.";
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                errorLabel.Text = ex.Message;
        //            }
        //        }
        //        else
        //        {
        //            errorLabel.Text = "Authentication did not succeed. Select a valid domain.";
        //        }
        //    }
        //    //syelamanchali--2 step login--end

        //    //protected void btnTestLogin_Click(object sender, EventArgs e)
        //    //{
        //    //getUserLoginInfo("SIRLS", "anbiswas", "NA", "Anurag Biswas");
        //    //UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        //    //objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
        //    //Response.Redirect("~/LeanHome.aspx", false);
        //    //}
        //    //syelamanchali--2 step login--start
        //    public string ToSHA256(string value)
        //    {
        //        SHA256 sha256 = SHA256.Create();

        //        byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
        //        StringBuilder returnValue = new StringBuilder();

        //        for (int i = 0; i < hashData.Length; i++)
        //        {
        //            returnValue.Append(hashData[i].ToString());
        //        }

        //        return returnValue.ToString();
        //    }
        //    //syelamanchali--2 step login--end
        // syelamanchal--remove ldap and externallogin--end
        // syelamanchal--OAuth Single Login using outlook account--start

           

        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        protected override void OnInit(EventArgs e)
        {
            ViewStateUserKey = Session.SessionID;
            base.OnInit(e);
        }
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end
        

        static string Userpass = "";
        UserLoginInfo objUserLoginInfo;
        protected void Page_Load(object sender, EventArgs e)
        {

            //syelamanchal--Session Hizacking atack fix --start
            string _browserInfo = Request.Browser.Browser
                        + Request.Browser.Version
                        + Request.UserAgent + "~"
                        + Request.ServerVariables["REMOTE_ADDR"];

            string _sessionValue = Convert.ToString(Session["UserID"]) + "^"
                                    + DateTime.Now.Ticks + "^"
                                    + _browserInfo + "^"
                                    + System.Guid.NewGuid();

            byte[] _encodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_sessionValue);
            string _encryptedString = System.Convert.ToBase64String(_encodeAsBytes);
            Session["encryptedSession"] = _encryptedString;
            //syelamanchal--Session Hizacking atack fix --end

            if (!IsPostBack)
            {                
                lblpassword.Text = "";
                txtPassword.Visible = false;
                btnLogin.Visible = false;
            }

            if (Request["code"] != null)
            {
                UserLoginInfo objUserLoginInfo = new UserLoginInfo();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                if (objUserLoginInfo.LoginType.ToString() == "Consortium")
                {
                    string ClientId = System.Configuration.ConfigurationManager.AppSettings["Con_ClientId"];
                    string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["Con_ClientSecret"];
                    string TenantId = System.Configuration.ConfigurationManager.AppSettings["Con_TenantId"];
                    string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["Con_RedirectUri"];
                    CheckAuthorization(ClientId, ClientSecret, TenantId, RedirectUri, objUserLoginInfo.LoginType.ToString());
                }
                else if (objUserLoginInfo.LoginType.ToString() == "Lexmark")
                {
                    string ClientId = System.Configuration.ConfigurationManager.AppSettings["Lex_ClientId"];
                    string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["Lex_ClientSecret"];
                    string TenantId = System.Configuration.ConfigurationManager.AppSettings["Lex_TenantId"];
                    string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["Lex_RedirectUri"];
                    CheckAuthorization(ClientId, ClientSecret, TenantId, RedirectUri, objUserLoginInfo.LoginType.ToString());
                }
                else {

                }
            }
        }

        protected void btnGenEmail_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(txtUserEmail.Text))
            {
                MailAddress address = new MailAddress(txtUserEmail.Text);
                string host = address.Host; // host contains Lexmark.com
                if (host.Trim().ToUpper() == "LEXMARK.COM")
                {
                    string ClientId = System.Configuration.ConfigurationManager.AppSettings["Lex_ClientId"];
                    string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["Lex_ClientSecret"];
                    string TenantId = System.Configuration.ConfigurationManager.AppSettings["Lex_TenantId"];
                    string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["Lex_RedirectUri"];
                    string LoginType = "Lexmark";
                    //syelamanchili
                   // Session["LoggedIn"] = txtUserEmail.Text.Trim();
                    // createa a new GUID and save into the session
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    // now create a new cookie with this guid value
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    //syelamanchili
                    CheckAuthorization(ClientId, ClientSecret, TenantId, RedirectUri, LoginType);
                }
                else if (host.Trim().ToUpper() == "LEXMARK365.ONMICROSOFT.COM")
                {
                    string ClientId = System.Configuration.ConfigurationManager.AppSettings["Con_ClientId"];
                    string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["Con_ClientSecret"];
                    string TenantId = System.Configuration.ConfigurationManager.AppSettings["Con_TenantId"];
                    string RedirectUri = System.Configuration.ConfigurationManager.AppSettings["Con_RedirectUri"];
                    string LoginType = "Consortium";
                    //syelamanchili
                    //Session["LoggedIn"] = txtUserEmail.Text.Trim();
                    // createa a new GUID and save into the session
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    // now create a new cookie with this guid value
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    //syelamanchili
                    CheckAuthorization(ClientId, ClientSecret, TenantId, RedirectUri, LoginType);
                    //Response.Redirect("UserDetail.aspx");
                   // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Consortium  User')", true);
                }
                else
                {
                    //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User is not valid.')", true);
                    lblpassword.Text = "Password";
                    txtPassword.Visible = true;
                    btnLogin.Visible = true;
                    btnGenEmail.Visible = false;
                }
            }
            else
            {
                lblpassword.Text = "Password";
                txtPassword.Visible = true;
                btnLogin.Visible = true;
                btnGenEmail.Visible = false;         
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception ex)
            {
                //syelamanchal--Logging--start
                // Get stack trace for the exception with source file information
                var st = new System.Diagnostics.StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                return false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            TestBusiness objTestBusiness = new TestBusiness();
            txtPassword.Text= txtPassword.Text.Trim()+ txtUserEmail.Text.Substring(0, (int)(txtUserEmail.Text.Length / 2));
            if (ToSHA256(txtPassword.Text.Trim()) == objTestBusiness.getUserPassword(txtUserEmail.Text))
            {
                Userpass = txtPassword.Text.Trim();

                //syelamanchili
              //  Session["LoggedIn"] = txtUserEmail.Text.Trim();
                // createa a new GUID and save into the session
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                // now create a new cookie with this guid value
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
               //syelamanchili

                getUserLoginInfo("", txtUserEmail.Text.ToString(),"LocalUser", txtUserEmail.Text.ToString());

                Response.Redirect("~/Sites.aspx", false);
            }
            else
            {
                errorLabel.Text = "Authentication did not succeed. Check user name and password .";
            }

        }

        public string ToSHA256(string value)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder returnValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            return returnValue.ToString();
        }    

        private void getUserLoginInfo(string Acronym, string UserID, string LoginType, string Display_Name)
        {
            objUserLoginInfo = new UserLoginInfo();
            objUserLoginInfo.Lean_App = Acronym;
            objUserLoginInfo.UserID = UserID;
            objUserLoginInfo.LoginType = LoginType;
            objUserLoginInfo.Display_Name = Display_Name;
            Session["UserLoginInfo"] = objUserLoginInfo;
            Session["CurrentSite"] = HttpContext.Current.Request.Url.Host;//HttpContext.Current.Request.Url.PathAndQuery; 

            //syelamanchal--Session Hizacking atack fix --start
            string _browserInfo = Request.Browser.Browser
                        + Request.Browser.Version
                        + Request.UserAgent + "~"
                        + Request.ServerVariables["REMOTE_ADDR"];

            string _sessionValue = Convert.ToString(Session["UserID"]) + "^"
                                    + DateTime.Now.Ticks + "^"
                                    + _browserInfo + "^"
                                    + System.Guid.NewGuid();

            byte[] _encodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_sessionValue);
            string _encryptedString = System.Convert.ToBase64String(_encodeAsBytes);
            Session["encryptedSession"] = _encryptedString;
            //syelamanchal--Session Hizacking atack fix --end


        }
        // syelamanchal--OAuth Single Login using outlook account--end

        // syelamanchal--Check Authorization,user login update and creating sessions--start
        private void CheckAuthorization(string ClientId, string ClientSecret, string TenantId, string RedirectUri,string LoginType)
        {
            string app_id = ClientId;
            string app_secret = ClientSecret;
            string scope = "openid+Mail.Read";
            string response_type = "code";
            getUserLoginInfo("", "", LoginType, "");

            if (Request["code"] == null)
            {
                Response.Redirect(string.Format(
                    "https://login.microsoftonline.com/"+ TenantId + "/oauth2/authorize?client_id={0}&redirect_uri={1}&scope={2}&response_type={3}",
                    app_id, Server.UrlEncode(RedirectUri.ToString()), scope, response_type));                
            }
            else
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://login.microsoftonline.com/"+TenantId+"/oauth2/token");

                var request = (HttpWebRequest)WebRequest.Create(url);
                var postData = "client_id="+ app_id;
                postData += "&client_secret="+ app_secret;
                postData += "&redirect_uri=" + Server.UrlEncode(RedirectUri);
                postData += "&code=" + Request["code"].ToString();
                postData += "&grant_type=authorization_code";

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                // responseString.Replace(@"\", " ");
                JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                var Access_token = jObject.SelectToken("id_token").ToString().Trim('"');


                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(Access_token) as JwtSecurityToken; ;

                var unique_name = jsonToken.Claims.First(claim => claim.Type == "unique_name").Value;
                var name = jsonToken.Claims.First(claim => claim.Type == "name").Value;
              //  var unique_name = jsonToken.Claims.First(claim => claim.Type == "unique_name").Value;

                getUserLoginInfo("", unique_name, LoginType, name);
                Response.Redirect("~/Sites.aspx", false);

            }
            // syelamanchal--Check Authorization,user login update and creating sessions--end
        }
    }
}