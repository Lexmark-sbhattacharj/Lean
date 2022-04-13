using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Drawing;
using LeanBusiness;
using LeanWeb.App_Code;
using Lean.Utilities;

namespace LeanWeb.role_DefineParameters
{
    public partial class unblockFinalVKB : System.Web.UI.Page
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
            string test_1 = HiddenField1.Value;
            objTestBusiness = new TestBusiness();
            try
            { //syelamanchal--Adding roles functionality to user--start
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
                DateTime txtDate = Convert.ToDateTime(HiddenField1.Value);
                if (txtDate != null)
                {
                    gvUnblockFinalVKB.DataSource = objTestBusiness.getVKB_Global_LineDetail(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, txtDate);
                    gvUnblockFinalVKB.DataBind();
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

        protected void gvUnblockFinalVKB_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvUnblockFinalVKB.EditIndex = e.NewEditIndex;
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

        protected void gvUnblockFinalVKB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
                gvUnblockFinalVKB.EditIndex = -1;
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

        protected void gvUnblockFinalVKB_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvUnblockFinalVKB.Rows[e.RowIndex];
                bool Final_Version;
                CheckBox chkFinalEdit = ((CheckBox)row.FindControl("chkFinalEdit"));
                if (chkFinalEdit != null && chkFinalEdit.Checked == true)
                {
                    Final_Version = true;
                }
                else
                {
                    Final_Version = false;
                }
                string uploadUser = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                int original_idLine = Convert.ToInt32(((Label)row.FindControl("lblidLine")).Text);
                DateTime Date = Convert.ToDateTime(((Label)row.FindControl("lblDateEdit")).Text);
                bool result = objTestBusiness.UpdateVKB_Global_Line(Final_Version, uploadUser, original_idLine, Date);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);
                }
                gvUnblockFinalVKB.EditIndex = -1;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (HiddenField1.Value.ToString() != string.Empty)
                {
                    gvUnblockFinalVKB.Visible = true;
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
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void gvUnblockFinalVKB_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUnblockFinalVKB.PageIndex = e.NewPageIndex;
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