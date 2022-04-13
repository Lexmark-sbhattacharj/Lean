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
using System.Text;
using Lean.Utilities;
using LeanBusiness;

namespace LeanWeb.role_DailyUploads
{
    public partial class TriggerLHWUpdates : System.Web.UI.Page
    {
        TestBusiness objTestBusiness;
        UserLoginInfo objuserLoginInfo = new UserLoginInfo();


        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        //protected override void OnInit(EventArgs e)
        //{
        //    ViewStateUserKey = Session.SessionID;
        //    base.OnInit(e);
        //}
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            objTestBusiness = new TestBusiness();
            try
            {
                if (!IsPostBack)
                {
                    objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        BindGrids();
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = updateLHWTables();
                if (result == true)
                {
                    lblResult.Visible = true;
                    if (BindGrids() == true)
                    {
                        lblResult.Text = "Data Update Successful";
                        lblResult.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblResult.Text = "Problem encountered while uploading data to LHW!";
                        lblResult.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblResult.Text = "Problem encountered while uploading data to LHW!";
                    lblResult.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message + "Problem encountered while uploading data to LHW!";
                lblResult.ForeColor = Color.Red;

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

            }
        }

        protected void btnRevertChanges_Click(object sender, EventArgs e)
        {
            try
            {
                revertChanges();
                BindGrids();
                lblResult.Visible = false;
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message + "Problem encountered while rolling back to LHW!";
                lblResult.ForeColor = Color.Red;

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

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BindGrids();
                Timer1.Enabled = false;
                imgLoader1.Visible = false;
                imgLoader2.Visible = false;
                imgLoader3.Visible = false;
                imgLoader4.Visible = false;
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

        public bool BindGrids()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = FillDataset();

                grvInventoryDistributer.DataSource = ds.Tables[0];
                grvInventoryDistributer.DataBind();

                grvInventoryInTransit.DataSource = ds.Tables[1];
                grvInventoryInTransit.DataBind();

                grvDemandBackOrder.DataSource = ds.Tables[2];
                grvDemandBackOrder.DataBind();

                grvDemandCustomerBackOrder.DataSource = ds.Tables[3];
                grvDemandCustomerBackOrder.DataBind();

                return true;
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

                return false;
            }
        }

        public DataSet FillDataset()
        {
            try
            {
                DataSet ds = new DataSet();
                string Lean_app = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;

                if (Lean_app != null)
                {
                    string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    ds = objTestBusiness.get_TriggerLHW(Lean_app);
                    return ds;
                }
                else
                {
                    return null;
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

                lblResult.Text = ex.Message + "Problem encountered while binding data to the grid!";
                lblResult.ForeColor = Color.Red;
                return null;
            }
        }

        protected bool revertChanges()
        {
            try
            {
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                bool result = objTestBusiness.Delete_TriggerLHW(Lean_App);
                return true;

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

                lblResult.Text = ex.Message + "Problem encountered while reverting changes!";
                lblResult.ForeColor = Color.Red;
                return false;
            }

        }

        protected bool updateLHWTables()
        {
            try
            {
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                bool result = objTestBusiness.Update_TriggerLHW(Lean_App);
                if (result == true)
                {
                    return true;
                }
                else
                {
                    lblResult.Text = "Problem encountered while updating data to LHW!";
                    return false;
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

                lblResult.Text = ex.Message + "Problem encountered while updating data to LHW!";
                lblResult.ForeColor = Color.Red;
                return false;
            }

        }

        protected bool GetUpdates()
        {
            try
            {
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                bool result_GetUpdates = objTestBusiness.Update_TriggerLHW(Lean_App);
                return true;
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message + "Problem encountered while getting updates!";
                lblResult.ForeColor = Color.Red;

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

                return false;
            }
        }

        protected void grvInventoryDistributer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (grvInventoryDistributer.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds = FillDataset();
                    grvInventoryDistributer.Visible = true;
                    btnProcess.Visible = true;
                    grvInventoryDistributer.PageIndex = e.NewPageIndex;
                    grvInventoryDistributer.DataSource = ds.Tables[0];
                    grvInventoryDistributer.DataBind();
                }
                else
                {
                    grvInventoryDistributer.Visible = false;
                    lblResult.Text = "Error Showing Upload Preview.";
                    lblResult.ForeColor = Color.Red;
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

        protected void grvInventoryInTransit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (grvInventoryInTransit.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds = FillDataset();
                    grvInventoryInTransit.Visible = true;
                    grvInventoryInTransit.PageIndex = e.NewPageIndex;
                    grvInventoryInTransit.DataSource = ds.Tables[1];
                    grvInventoryInTransit.DataBind();
                }
                else
                {
                    grvInventoryInTransit.Visible = false;
                    lblResult.Text = "Error Showing Upload Preview.";
                    lblResult.ForeColor = Color.Red;
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

        protected void grvDemandBackOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (grvDemandBackOrder.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds = FillDataset();
                    grvDemandBackOrder.Visible = true;
                    grvDemandBackOrder.PageIndex = e.NewPageIndex;
                    grvDemandBackOrder.DataSource = ds.Tables[2];
                    grvDemandBackOrder.DataBind();
                }
                else
                {
                    grvDemandBackOrder.Visible = false;
                    lblResult.Text = "Error Showing Upload Preview.";
                    lblResult.ForeColor = Color.Red;
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

        protected void grvDemandCustomerBackOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (grvDemandCustomerBackOrder.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    ds = FillDataset();
                    grvDemandCustomerBackOrder.Visible = true;
                    grvDemandCustomerBackOrder.PageIndex = e.NewPageIndex;
                    grvDemandCustomerBackOrder.DataSource = ds.Tables[3];
                    grvDemandCustomerBackOrder.DataBind();
                }
                else
                {
                    grvDemandCustomerBackOrder.Visible = false;
                    lblResult.Text = "Error Showing Upload Preview.";
                    lblResult.ForeColor = Color.Red;
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