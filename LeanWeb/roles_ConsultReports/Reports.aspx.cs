using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using Lean.Utilities;
using System.Web.Security;

namespace LeanWeb.roles_ConsultReports
{
    public partial class Reports : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        TestBusiness objTestBusiness;
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        protected override void OnInit(EventArgs e)
        {
            ViewStateUserKey = Session.SessionID;
            base.OnInit(e);
        }
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.UrlReferrer == null || Request.Url.Host != Request.UrlReferrer.Host))
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            //syelamanchal--csrf atack--start
            string urlReferrer;
                urlReferrer = Request.UrlReferrer.ToString();
            if (urlReferrer.Contains(Session["CurrentSite"].ToString()))
            {

            }
            else
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            //syelamanchal--csrf atack--end
            //syelamanchili-Already existing code-start
            try
            {
                if ((UserLoginInfo)Session["UserLoginInfo"] == null)
                {
                    Response.Redirect("~/LeanLogout.aspx", false);
                }
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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
            //syelamanchili-Already existing code-end
            objTestBusiness = new TestBusiness();
            try
            {
                if (!IsPostBack)
                {
                    //syelamanchal
                  //  System.Web.Helpers.AntiForgery.Validate();
                    

                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        //syelamanchal--Adding roles functionality to user--start
                        //if (User.IsInRole("GEO - Global"))
                        //{
                        //    ddlGEO.Items.Add("Global");
                        //}
                        //ddlGEO.Items.Add("Global");
                        //ddlGEO.Items.Add("AP");
                        //ddlGEO.Items.Add("CAN");
                        //ddlGEO.Items.Add("EMEA");
                        //ddlGEO.Items.Add("LAD");
                        //ddlGEO.Items.Add("USA");
                        //syelamanchal--Adding roles functionality to user--end
                        //syelamanchal--Adding roles functionality to user--start
                        string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                        if (objTestBusiness.Validate_UserInRole(UserName, "GEO - Global") == 1)
                        {
                            ddlGEO.Items.Add("Global");
                        }
                         if (objTestBusiness.Validate_UserInRole(UserName, "GEO - LAD") == 1)
                        {
                            ddlGEO.Items.Add("LAD");
                        }
                         if (objTestBusiness.Validate_UserInRole(UserName, "GEO - USA") == 1)
                        {
                            ddlGEO.Items.Add("USA");
                        }
                         if (objTestBusiness.Validate_UserInRole(UserName, "GEO - EMEA") == 1)
                        {
                            ddlGEO.Items.Add("EMEA");
                        }
                         if (objTestBusiness.Validate_UserInRole(UserName, "GEO - CAN") == 1)
                        {
                            ddlGEO.Items.Add("CAN");
                        }
                         if (objTestBusiness.Validate_UserInRole(UserName, "GEO - AP") == 1)
                        {
                            ddlGEO.Items.Add("AP");
                        }
                        if (ddlGEO.Items.Count == 0) { ddlGEO.Items.Add(" "); }
                        //syelamanchal--Adding roles functionality to user--end

                        BindGridData();

                    }
                }
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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void BindGridData()
        {
            try
            {
                string Geo = ddlGEO.SelectedItem.Text;
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                gvReports.DataSource = objTestBusiness.getResult_Catalog_Details(Lean_Application, Geo);
                gvReports.DataBind();
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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void ddlGEO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindGridData();
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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;        
            }
        }
    }
}