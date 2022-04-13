using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LeanBusiness;
using Lean.Utilities;
using System.Data;

namespace LeanWeb.role_DefineParameters
{
    public partial class Lines : System.Web.UI.Page
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
            try
            {
                //syelamanchal--Adding roles functionality to user--start
                string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                if (objTestBusiness.Validate_UserInRole(UserName, "DefineParameters") != 1)
                {
                    Response.Redirect("~/LeanHome.aspx");
                }
                //syelamanchal--Adding roles functionality to user--end
                if (!IsPostBack)
                {
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
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

        private void BindGridData()
        {
            try
            {                
                gvLines.DataSource = objTestBusiness.getLinesDetail(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                gvLines.DataBind();
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

        protected void gvLines_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvLines.EditIndex = e.NewEditIndex;
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

        protected void gvLines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
                gvLines.EditIndex = -1;
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

        protected void gvLines_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvLines.Rows[e.RowIndex];
                int Capability = Convert.ToInt32(((TextBox)row.FindControl("txtCapacityEdit")).Text);
                string Planner = ((TextBox)row.FindControl("txtPlannerEdit")).Text;
                int original_idLine = Convert.ToInt32(((Label)row.FindControl("lblidLineEdit")).Text);
                string original_Line = ((Label)row.FindControl("lblLine")).Text;

                bool result = objTestBusiness.UpdateLines(Capability, Planner, original_idLine, original_Line);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);

                }
                gvLines.EditIndex = -1;
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

        protected void gvLines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
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

        protected void gvLines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvLines.Rows[e.RowIndex];
            int original_idLine = Convert.ToInt32(((Label)row.FindControl("lblidLineView")).Text);
            string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
            bool result = objTestBusiness.DeleteLines(original_idLine, Lean_App);
            if (result == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDltSuccess", "javascript:alert('Data Deleted successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDltFailed", "javascript:alert('Data Deletion Failed.');", true);
            }
            BindGridData();
        }

        protected void gvLines_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLines.PageIndex = e.NewPageIndex;
            BindGridData();
        }
    }
}