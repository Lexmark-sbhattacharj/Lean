using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanWeb.App_Code;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Text;
using Lean.Utilities;
using LeanBusiness;

namespace LeanWeb.role_DailyUploads
{
    public partial class DailyUploadsChecklist : System.Web.UI.Page
    {
        TestBusiness objTestBusiness;
        UserLoginInfo objuserLoginInfo = new UserLoginInfo();

        public void Page_Init(object o, EventArgs e)
        {
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string test_1 = HiddenField1.Value;
            objTestBusiness = new TestBusiness();
            //syelamanchal--Adding roles functionality to user--start
            string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            if (objTestBusiness.Validate_UserInRole(UserName, "DailyUploads") != 1)
            {
                Response.Redirect("~/LeanHome.aspx");
            }
            //syelamanchal--Adding roles functionality to user--end
            try
            {
                if (!IsPostBack)
                {
                    objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void btnCleanup_Click(object sender, EventArgs e)
        {
            try
            {
                string Lean_app = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                bool result = objTestBusiness.Delete_DailyUploadsChecklist(Lean_app);
                if (result == true)
                {
                    LabelStatus.Text = "Files Cleaned up succesfully!!";
                    LabelStatus.ForeColor = Color.Green;

                }
                else
                {
                    LabelStatus.Text = "Error on Files Cleanup";
                    LabelStatus.ForeColor = Color.Red;
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end

                LabelStatus.Text = "ERROR: Deleting from SQL. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (HiddenField1.Value.ToString() != string.Empty)
                {
                    gvDailyUploadsChecklist.Visible = true;
                    BindGridData();
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        private void BindGridData()
        {
            try
            {
                string Lean_app = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DateTime Date = Convert.ToDateTime(HiddenField1.Value);
                if (Date != null)
                {
                    gvDailyUploadsChecklist.DataSource = objTestBusiness.GetDailyUploadsChecklist(Lean_app, Date);
                    gvDailyUploadsChecklist.DataBind();
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }
    }
}