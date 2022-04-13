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
    public partial class SpecialBid : System.Web.UI.Page
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
                string filter = txtFilter.Text.ToString();
                if (filter == string.Empty)
                {
                    gvSpecialBids.DataSource = objTestBusiness.getSpecialBidDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, "");
                    gvSpecialBids.DataBind();
                }
                else
                {
                    gvSpecialBids.DataSource = objTestBusiness.getSpecialBidDetails(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, filter);
                    gvSpecialBids.DataBind();
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

        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("~/role_DefineParameters/SpecialBidMassUpload.aspx", false);
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

        protected void gvSpecialBids_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvSpecialBids.EditIndex = e.NewEditIndex;
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

        protected void gvSpecialBids_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                e.Cancel = true;
                gvSpecialBids.EditIndex = -1;
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

        protected void gvSpecialBids_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int Active;
                GridViewRow row = (GridViewRow)gvSpecialBids.Rows[e.RowIndex];
                string idLocalization = ((TextBox)row.FindControl("txtLocalizationEdit")).Text;
                string idMaterial = ((TextBox)row.FindControl("txtMaterialEdit")).Text;
                int Quantity = Convert.ToInt32(((TextBox)row.FindControl("txtQuantityEdit")).Text);
                string uploadUser = ((Label)row.FindControl("LabelUserEdit")).Text;
                string Comments = ((TextBox)row.FindControl("txtCommentsEdit")).Text;
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
                string original_idSpecialBid = ((Label)row.FindControl("lblidSpecialBidEdit")).Text;
                CheckBox chkActive = ((CheckBox)row.FindControl("chkActiveEdit"));
                if (chkActive != null && chkActive.Checked == true)
                {
                    Active = 1;
                }
                else
                {
                    Active = 0;
                }
                bool result = objTestBusiness.UpdateSpecialBid(idLocalization,idMaterial,Active,Quantity,uploadUser,Comments,Lean_App,original_idSpecialBid);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);
                }
                gvSpecialBids.EditIndex = -1;
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

        protected void gvSpecialBids_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("ADD"))
                {
                    
                    string idLocalization = ((TextBox)gvSpecialBids.FooterRow.FindControl("txtLocalizationInsert")).Text.ToString();
                    string idMaterial = ((TextBox)gvSpecialBids.FooterRow.FindControl("txtMaterialInsert")).Text.ToString();
                    string uploadUser = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    string Comments = ((TextBox)gvSpecialBids.FooterRow.FindControl("txtCommentsInsert")).Text.ToString();
                    string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App.ToUpper();
                    int Quantity = Convert.ToInt32(((TextBox)gvSpecialBids.FooterRow.FindControl("txtQuantityInsert")).Text.ToString());
                    
                    int returnFlg = 0;
                    returnFlg = objTestBusiness.CreateSpecialBid(idLocalization, idMaterial, Quantity, uploadUser, Comments, Lean_App);

                    if (returnFlg == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxSuccess", "javascript:alert('Data Inserted successfully.');", true); //Write this in 
                    }
                    else if (returnFlg == 2)
                    {
                        ScriptManager.RegisterStartupScript(this,GetType(), "msgboxCheckConst", "javascript:alert('Part number does not exists. Data could not be inserted.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxError", "javascript:alert('Problem in inserting data from database.');", true); //Write this in 
                    }
                    BindGridData();
                }
                //syalamanchili--After deletion page is continuesly loading with out showing succes message--start
                //else if (e.CommandName.ToUpper().Equals("DELETE"))
                //{
                //    int original_idSpecialBid = Convert.ToInt32(((Label)(gvSpecialBids.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].FindControl("lblidSpecialBidView"))).Text);
                //    if (objTestBusiness.DeleteSpecialBid(original_idSpecialBid))
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDeletedSuccess", "javascript:alert('Selected data is deleted successfully.');", true);
                        
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDeleteError", "javascript:alert('Problem in inserting data from database.');", true); //Write this in 
                //    }
                //    //Show which Record is deleted from database in an alert
                //    BindGridData();
                //}
                //syalamanchili--After deletion page is continuesly loading with out showing succes message--End
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

        protected void gvSpecialBids_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSpecialBids.PageIndex = e.NewPageIndex;
            BindGridData();
        }

        //syalamanchili--After deletion page is continuesly loading with out showing succes message--start
        protected void gvSpecialBids_RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            int original_idSpecialBid = Convert.ToInt32(((Label)(gvSpecialBids.Rows[Convert.ToInt32(e.RowIndex)].Cells[10].FindControl("lblidSpecialBidView"))).Text);
            if (objTestBusiness.DeleteSpecialBid(original_idSpecialBid))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDeletedSuccess", "javascript:alert('Selected data is deleted successfully.');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxDeleteError", "javascript:alert('Problem in inserting data from database.');", true); //Write this in 
            }
            //Show which Record is deleted from database in an alert
            BindGridData();
        }
        //syalamanchili--After deletion page is continuesly loading with out showing succes message--End
    }
}