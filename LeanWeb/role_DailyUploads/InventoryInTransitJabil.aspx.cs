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

namespace LeanWeb.role_DailyUploads
{
    public partial class InventoryInTransitJabil : System.Web.UI.Page
    {
        int row_count = 0;
        TestBusiness objTestBusiness;
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ExcelData objExcelData = new ExcelData();
        string savepath, Extension;

        //This function triggers at page initiation
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

        //This function triggers on page load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //syelamanchal--Adding roles functionality to user--start
                objTestBusiness = new TestBusiness();
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                if (objTestBusiness.Validate_UserInRole(UserName, "DailyUploads") != 1)
                {
                    Response.Redirect("~/LeanHome.aspx");
                }
                //syelamanchal--Adding roles functionality to user--end
                if (IsPostBack)
                {                 
                    if (Session["UserLoginInfo"] != null)
                    {
                        if (FileUpload1.HasFile)
                        {
                            btnUpload.Visible = true;
                        }
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

        //Sends the whole data to the business layer for database insersion
        protected void Bulk_Insert()
        {
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            btnProcess.Enabled = false;
            try
            {
                DataTable dt = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                lblStatus.Text = "Started Inserting Data into the Database";
                lblStatus.Visible = true;

                if (dt.Rows.Count > 0)
                {
                    string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    objTestBusiness.DeleteInventoryInTransitJabil(Lean_App);
                    bool result = objTestBusiness.insert_bulkInsertto_Inventory_JabilInTransit(dt);
                    if (result == true)
                    {
                        lblStatus.Text = row_count.ToString() + " Records Entered into The Database Successfully!";
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Visible = true;
                    }
                    else
                    {
                        lblStatus.Text = "Entering Data to Database Failed Failed. Please Try Again!";
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Visible = true;
                    }
                }                
                row_count = 0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message.ToString();
                lblStatus.ForeColor = Color.Red;
                lblStatus.Visible = true;
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

        //Grid View Page indexing
        protected void gvInventoryInTransitJabil_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvInventoryInTransitJabil.PageIndex = e.NewPageIndex;
                gvInventoryInTransitJabil.DataSource = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                gvInventoryInTransitJabil.DataBind();
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

        //This function triggers when Process button is pressed
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Bulk_Insert();
                gvInventoryInTransitJabil.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = ex.Message.ToString() + "Some Error Occured. Please Try Again!";
                lblStatus.ForeColor = Color.Red;
                gvInventoryInTransitJabil.Visible = false;
                lblStatus.Visible = true;
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

        //This function triggers when Upload button is pressed
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Session["ExcelData"] = null;
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            lblStatus.Text = "";
            lblStatus.Visible = false;
            try
            {
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
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Visible = true;
                        }
                        else
                        {
                            savepath = "C:\\Files\\Jabil_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\Jabil_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.Extension = Extension;
                            Session["ExcelData"] = objExcelData;
                            FileUpload1.PostedFile.SaveAs(savepath);
                            DataTable dt = FillDataTable(savepath, Extension);
                            if (dt.Rows.Count > 0)
                            {
                                //syelamanchal-Show upload rows count-Start
                                lblStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                                lblStatus.ForeColor = Color.Green;
                                lblStatus.Visible = true;
                                //syelamanchal-Show upload rows count-End

                                gvInventoryInTransitJabil.DataSource = dt;
                                gvInventoryInTransitJabil.DataBind();
                                gvInventoryInTransitJabil.Visible = true;
                                btnProcess.Visible = true;
                            }
                            else
                            {
                                lblStatus.Text = "Error in reading file";
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        savepath = "C:\\Files\\Jabil_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\Jabil_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.Extension = Extension;
                        Session["ExcelData"] = objExcelData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = FillDataTable(savepath, Extension);
                        if (dt.Rows.Count > 0)
                        {
                            //syelamanchal-Show upload rows count-Start
                            lblStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                            lblStatus.ForeColor = Color.Green;
                            lblStatus.Visible = true;
                            //syelamanchal-Show upload rows count-End

                            gvInventoryInTransitJabil.DataSource = dt;
                            gvInventoryInTransitJabil.DataBind();
                            gvInventoryInTransitJabil.Visible = true;
                            btnProcess.Visible = true;
                        }
                        else
                        {
                            lblStatus.Text = "Error in reading file";
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Visible = true;
                        }
                    }
                }
                else
                {
                    lblStatus.Text = "Please Select a File to Upload";
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error in reading file" + ex.Message;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Visible = true;
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

        //Binds the grid with data fetched from the business layer
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

                dt.Columns.Add("Upload_User");
                dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp
                foreach (DataRow row in dt.Rows)
                {
                    row["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    row["Upload_Date"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    row["Lean_Application"] = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    row_count = row_count + 1;
                }
                dt.AcceptChanges();
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblStatus.Text = "Parsing Failed";
                lblStatus.ForeColor = Color.Red;
                lblStatus.Visible = true;
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
    }
}