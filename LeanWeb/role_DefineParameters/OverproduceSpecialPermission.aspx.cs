using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using LeanBusiness;
using LeanWeb.App_Code;
using Lean.Utilities;

namespace LeanWeb.role_DefineParameters
{
    public partial class OverproduceSpecialPermission : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
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

        private void BindGridData()
        {
            try
            {
                string filter = txtFilter.Text.ToString();
                if (filter == string.Empty)
                {
                    gvSpecialPermission.DataSource = objTestBusiness.getSpecialPermissionDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, "");
                    gvSpecialPermission.DataBind();
                }
                else
                {
                    gvSpecialPermission.DataSource = objTestBusiness.getSpecialPermissionDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, filter);
                    gvSpecialPermission.DataBind();
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

        protected void gvSpecialPermission_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSpecialPermission.EditIndex = e.NewEditIndex;
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

        protected void gvSpecialPermission_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
                gvSpecialPermission.EditIndex = -1;
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

        protected void gvSpecialPermission_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                bool Active;
                
                GridViewRow row = (GridViewRow)gvSpecialPermission.Rows[e.RowIndex];
                CheckBox chkActive = ((CheckBox)row.FindControl("chkActiveEdit"));
                if (chkActive != null && chkActive.Checked == true)
                {
                    Active = true;
                }
                else
                {
                    Active = false;
                }
                int idOverproduce = Convert.ToInt32(((Label)row.FindControl("lblidOverproduceEdit")).Text);
                string uploadUser = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
                bool result = objTestBusiness.UpdateSpecialPermission(Active, uploadUser, Lean_Application, idOverproduce);
                if(result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);
                }
                gvSpecialPermission.EditIndex = -1;
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

        protected void gvSpecialPermission_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("ADD"))
                {
                    string LocalizationName = ((DropDownList)gvSpecialPermission.FooterRow.FindControl("ddlDCInsert")).SelectedItem.ToString();
                    string idMaterial = ((DropDownList)gvSpecialPermission.FooterRow.FindControl("ddlPartNoInsert")).SelectedItem.ToString();
                    string uploadUser = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
                    bool Active = true;
                    bool result = objTestBusiness.CreateSpecialPermission(idMaterial, LocalizationName, Lean_Application, Active, uploadUser);
                    if (result == true)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxSuccess", "javascript:alert('Data Inserted successfully.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxFailed", "javascript:alert('Data Insersion Failed.');", true);
                    }
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

        protected void gvSpecialPermission_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlMaterial = (DropDownList)e.Row.FindControl("ddlPartNoInsert");
                    ddlMaterial.DataSource = objTestBusiness.getIDMATERIALVKBINPUTDetails(Lean_Application);
                    ddlMaterial.DataTextField = "idMaterial";
                    ddlMaterial.DataValueField = "idMaterial";
                    ddlMaterial.DataMember = "idMaterial";
                    ddlMaterial.DataBind();

                    DropDownList ddlDCInsert = (DropDownList)e.Row.FindControl("ddlDCInsert");
                    ddlDCInsert.DataSource = objTestBusiness.getLOCALIZATIONVKBINPUTDetails(Lean_Application);
                    ddlDCInsert.DataTextField = "Localization_Name";
                    ddlDCInsert.DataValueField = "Localization_Name";
                    ddlDCInsert.DataMember = "Localization_Name";
                    ddlDCInsert.DataBind();
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

        protected void gvSpecialPermission_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvSpecialPermission.Rows[e.RowIndex];
                int idOverproduce = Convert.ToInt32(((Label)row.FindControl("lblidOverproduceView")).Text);
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                bool result = objTestBusiness.DeleteSpecialPermission(Lean_Application, idOverproduce);
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

        protected void gvSpecialPermission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvSpecialPermission.PageIndex = e.NewPageIndex;
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