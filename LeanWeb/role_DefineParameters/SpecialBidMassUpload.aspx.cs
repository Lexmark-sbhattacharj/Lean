using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using LeanBusiness;
using Lean.Utilities;

namespace LeanWeb.role_DefineParameters
{
    public partial class SpecialBidMassUpload : System.Web.UI.Page
    {
        int row_count = 0;

       
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ExcelData objExcelData = new ExcelData();
        string savepath, Extension;

        public void Page_Init(object o, EventArgs e)
        {
            if ((UserLoginInfo)Session["UserLoginInfo"] == null)
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TestBusiness objTestBusiness;
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
                LeanBusiness.TestBusiness objTestBusiness1 = new LeanBusiness.TestBusiness();
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness1.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            try
            {
                Session["ExcelData"] = null;
                string ExcelFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FilePath = Server.MapPath(ExcelFileName);
                if (FileUpload1.HasFile)
                {
                    if (Extension != ".xls")
                    {
                        if (Extension != ".xlsx")
                        {
                            lblStatus.Text = "Please Enter .xls or .xlsx files only";
                            lblStatus.Visible = true;
                            lblStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            savepath = "C:\\Files\\SpecialBid_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\SpecialBid_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.Extension = Extension;
                            Session["ExcelData"] = objExcelData;
                            FileUpload1.PostedFile.SaveAs(savepath);
                            DataTable dt = FillDataTable(savepath, Extension);
                            if (dt.Rows.Count > 0)
                            {
                                gvData.DataSource = dt;
                                gvData.DataBind();
                                btnProcess.Visible = true;
                            }
                            else
                            {
                                lblStatus.Text = "Error in reading file";
                                lblStatus.Visible = true;
                                lblStatus.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        savepath = "C:\\Files\\SpecialBid_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\SpecialBid_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.Extension = Extension;
                        Session["ExcelData"] = objExcelData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = FillDataTable(savepath, Extension);
                        if (dt.Rows.Count > 0)
                        {
                            gvData.DataSource = dt;
                            gvData.DataBind();
                            btnProcess.Visible = true;
                        }
                        else
                        {
                            lblStatus.Text = "Error in reading file";
                            lblStatus.Visible = true;
                            lblStatus.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    lblStatus.Text = "Please Select a File to Upload";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error in reading file" + ex.Message;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;

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

            }
            finally
            {
                btnUpload.Enabled = true;
                FileUpload1.Enabled = true;
            }
        }

        protected DataTable FillDataTable(string FilePath, string Extension)
        {
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls":
                        //Excel 97-03 
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break; // TODO: might not be correct. Was : Exit Select

                    case ".xlsx":
                        //Excel 07 
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break; // TODO: might not be correct. Was : Exit Select
                }
                conStr = string.Format(conStr, FilePath, "Yes");

                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet 
                connExcel.Open();
                DataTable dtExcelSchema = default(DataTable);
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet 
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                dt.Columns.Add("Active");
                dt.Columns.Add("Upload_User");
                dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp
                foreach (DataRow row in dt.Rows)
                {
                    row["Active"] = true;
                    row["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    row["Upload_Date"] = DateTime.Now.ToShortDateString();
                    row["Lean_Application"] = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    row_count = row_count + 1;
                }
                dt.AcceptChanges();
                return dt;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString() + "Parsing Failed";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;

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

                return null;
            }
        }

        protected void Bulk_Insert()
        {
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            btnProcess.Enabled = false;
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DataTable dt = new DataTable();
                dt = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                if (dt.Rows.Count > 0)
                {
                    Delete(Lean_App);
                    bool result = objTestBusiness.getbulkInserttoDemand_Special_Bid(dt);
                    if (result == true)
                    {
                        lblStatus.Text = row_count.ToString() + " Records Entered into The Database Successfully!";
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = Color.Green;
                        lbtnBack.Visible = true;
                    }
                    else
                    {
                        lblStatus.Text = "Entering Data to Database Failed Failed. Please Try Again!";
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = Color.Red;
                        lbtnBack.Visible = true;
                    }
                }
                row_count = 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString() + "Entering Data to Database Failed Failed. Please Try Again!";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
                lbtnBack.Visible = true;

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

            }
            finally
            {
                btnUpload.Enabled = true;
                FileUpload1.Enabled = true;
                btnProcess.Enabled = true;
                btnProcess.Visible = false;
                Session["ExcelData"] = null;
            }
        }

        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/role_DefineParameters/SpecialBid.aspx");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = "Some Error Occured. Please Try Again!";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;

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

            }
        }

        protected void Delete(string Lean_App)
        {
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                bool result = objTestBusiness.getDeleteFromDemand_Special_Bid(Lean_App);
                if (result == false)
                {
                    lblStatus.Text = "Error Occured while Deleting";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString() + "Error Occured while Deleting";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;

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

            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Bulk_Insert();
                gvData.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = ex.Message + "Some Error Occured. Please Try Again!";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
                gvData.Visible = false;
                lbtnBack.Visible = true;

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

            }
        }

        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvData.PageIndex = e.NewPageIndex;
                gvData.DataSource = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                gvData.DataBind();
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