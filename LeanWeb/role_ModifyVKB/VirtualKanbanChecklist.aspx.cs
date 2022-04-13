using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using Lean.Utilities;

namespace LeanWeb.role_ModifyVKB
{
    public partial class VirtualKanbanChecklist : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        TestBusiness objTestBusiness;

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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objTestBusiness = new TestBusiness();
            //syelamanchal--Adding roles functionality to user--start
            string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            if (objTestBusiness.Validate_UserInRole(UserName, "ModifyVKB") != 1)
            {
                Response.Redirect("~/LeanHome.aspx");
            }
            //syelamanchal--Adding roles functionality to user--end
            try
            {
                if (!IsPostBack)
                {
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        //BindGridData();
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

        private void BindGridData()
        {
            try
            {
                DateTime txtDate = Convert.ToDateTime(txtFilter.Text);
                if (txtDate != null)
                {
                    gvVKBChecklist.DataSource = objTestBusiness.getVKB_Checklist_Details(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, txtDate);
                    gvVKBChecklist.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text.ToString() != string.Empty)
            {
                gvVKBChecklist.Visible = true;
                BindGridData();
            }
        }
    }
}