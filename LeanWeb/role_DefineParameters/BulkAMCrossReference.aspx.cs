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
    public partial class BulkAMCrossReference : System.Web.UI.Page
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
                gvBulkAMCatalag.DataSource = objTestBusiness.getBulkAM_CatalogDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, "");
                gvBulkAMCatalag.DataBind();
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

        protected void gvBulkAMCatalag_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvBulkAMCatalag.EditIndex = e.NewEditIndex;
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

        protected void gvBulkAMCatalag_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
                gvBulkAMCatalag.EditIndex = -1;
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

        protected void gvBulkAMCatalag_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvBulkAMCatalag.Rows[e.RowIndex];
                string idLocalization = ((TextBox)row.FindControl("txtidLocalizationEdit")).Text;
                string AM = ((TextBox)row.FindControl("txtAMEdit")).Text;
                string Bulk = ((Label)row.FindControl("lblBulkEdit")).Text;
                string orignal_idLocalization = ((Label)row.FindControl("lblLocalizationHiddenEdit")).Text;
                string orignal_AM = ((Label)row.FindControl("lblAMHiddenEdit")).Text;
                string orignal_Bulk = ((Label)row.FindControl("lblBulkEdit")).Text;
                //Call Business Class Update Function
                bool result = objTestBusiness.UpdateBulkAM_Catalog(Bulk, AM, idLocalization, orignal_Bulk, orignal_AM, orignal_idLocalization);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);

                }
                gvBulkAMCatalag.EditIndex = -1;
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

        protected void gvBulkAMCatalag_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("ADD"))
                {
                    string Bulk = ((TextBox)gvBulkAMCatalag.FooterRow.FindControl("txtBulkInsert")).Text.ToString();
                    string idLocalization = ((TextBox)gvBulkAMCatalag.FooterRow.FindControl("txtidLocalizationInsert")).Text.ToString();
                    string AM = ((TextBox)gvBulkAMCatalag.FooterRow.FindControl("txtAMInsert")).Text.ToString();
                    string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
                    //Call Business Class Insert Function
                    if (objTestBusiness.getBulkAM_CatalogDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, Bulk).Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxExists", "javascript:alert('Data Already Exists.');", true);
                    }
                    else
                    {
                        bool result = objTestBusiness.CreateBulkAM_Catalog(Bulk, AM, idLocalization, Lean_App);
                        if (result == true)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msgboxSuccess", "javascript:alert('Data Inserted successfully.');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "msgboxFailed", "javascript:alert('Data Insersion Failed.');", true);
                        }
                    }
                    BindGridData();
                }
                else if (e.CommandName.ToUpper().Equals("DELETE"))
                {
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

        protected void gvBulkAMCatalag_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvBulkAMCatalag.Rows[e.RowIndex];
            string original_Bulk = ((Label)row.FindControl("lblBulkView")).Text;
            bool result = objTestBusiness.DeleteBulkAM_Catalog(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, original_Bulk);
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

        protected void gvBulkAMCatalag_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBulkAMCatalag.PageIndex = e.NewPageIndex;
            BindGridData();
        }
    }
}