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
    public partial class InventoryDockArea : System.Web.UI.Page
    {
        TestBusiness objTestBusiness;
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ExcelData objExcelData = new ExcelData();
        string savepath, Extension;
        int row_count = 0;
        DataTable dtableInventoryDockArea = new DataTable();

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

        //This function triggers when Upload button is pressed
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            Session["ExcelData"] = null;
            DataRow drInventory = default(DataRow);
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
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
                            savepath = "C:\\Files\\InventoryDockArea_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\InventoryDockArea_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.Extension = Extension;
                            Session["ExcelData"] = objExcelData;
                            FileUpload1.PostedFile.SaveAs(savepath);
                            DataTable dt = FillDataTable(savepath, Extension);
                            if (dt.Rows.Count > 0)
                            {
                                //syelamanchal-Show upload rows count-Start
                                lblStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                                lblStatus.ForeColor = Color.Green;
                                //syelamanchal-Show upload rows count-End
                                gvInventoryDockArea.Visible = true;
                                drInventory = dt.NewRow();
                                drInventory["idLocalizationMaterial"] = "TOTAL";
                                drInventory["Localization_Name"] = dt.Compute("count(Quantity)", "") + " Rows";
                                drInventory["Quantity"] = dt.Compute("sum(Quantity)", "");
                                dt.Rows.Add(drInventory);
                                dt.AcceptChanges();
                                gvInventoryDockArea.DataSource = dt;
                                gvInventoryDockArea.DataBind();
                                lblStatus.Visible = true;
                               // lblStatus.Text = "Showing Upload File Preview ...";
                                lblStatus.Visible = true;
                                lblStatus.ForeColor = Color.Maroon;
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
                        savepath = "C:\\Files\\InventoryDockArea_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\InventoryDockArea_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.Extension = Extension;
                        Session["ExcelData"] = objExcelData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = FillDataTable(savepath, Extension);
                        if (dt.Rows.Count > 0)
                        {
                            //syelamanchal-Show upload rows count-Start
                            lblStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                            lblStatus.ForeColor = Color.Green;
                            //syelamanchal-Show upload rows count-End
                            gvInventoryDockArea.Visible = true;
                            drInventory = dt.NewRow();
                            drInventory["idLocalizationMaterial"] = "TOTAL";
                            drInventory["Localization_Name"] = dt.Compute("count(Quantity)", "") + " Rows";
                            drInventory["Quantity"] = dt.Compute("sum(Quantity)", "");
                            dt.Rows.Add(drInventory);
                            dt.AcceptChanges();
                            gvInventoryDockArea.Visible = true;
                            gvInventoryDockArea.DataSource = dt;
                            gvInventoryDockArea.DataBind();
                            lblStatus.Visible = true;
                          //  lblStatus.Text = "Showing Upload File Preview ...";
                            lblStatus.Visible = true;
                            lblStatus.ForeColor = Color.Maroon;
                            btnProcess.Visible = true;
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

                lblStatus.Text = "Error in reading file" + ex.Message;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnUpload.Enabled = true;
                FileUpload1.Enabled = true;
            }
        }

        //This function triggers when Process button is pressed
        protected void btnProcess_Click(object sender, System.EventArgs e)
        {
            try
            {
                Bulk_Insert();
                gvInventoryDockArea.Visible = false;
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

                ex.Message.ToString();
                lblStatus.Text = ex.Message + "Some Error Occured. Please Try Again!";
                gvInventoryDockArea.Visible = false;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
            }
        }

        //Grid View Page indexing
        protected void gvInventoryDockArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvInventoryDockArea.PageIndex = e.NewPageIndex;
                gvInventoryDockArea.DataSource = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                gvInventoryDockArea.DataBind();
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

        //Binds the grid with data fetched from the business layer
        protected DataTable FillDataTable(string FilePath, string Extension)
        {
            DataRow drInventory = default(DataRow);
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
                DataSet ds = new DataSet();

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
                oda.Fill(ds);
                connExcel.Close();

                int count = 0;

                dtableInventoryDockArea.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("idLocalization", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Localization_Name", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("idMaterial", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Pallet_ID", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Pallet_No", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Status", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Quantity", Type.GetType("System.Decimal"));
                dtableInventoryDockArea.Columns.Add("Upload_User", Type.GetType("System.String"));
                dtableInventoryDockArea.Columns.Add("Upload_Date", Type.GetType("System.DateTime"));
                dtableInventoryDockArea.Columns.Add("Lean_Application", Type.GetType("System.String"));

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    drInventory = dtableInventoryDockArea.NewRow();
                    drInventory["idLocalization"] = dr["Plant"].ToString();
                    drInventory["idLocalizationMaterial"] = drInventory["idLocalization"] + dr["Modelo"].ToString().ToUpper();
                    drInventory["Localization_Name"] = dr["Destino"].ToString().ToUpper();
                    drInventory["idMaterial"] = dr["Modelo"].ToString().ToUpper();
                    drInventory["Pallet_ID"] = dr["Pallet ID"].ToString().ToUpper();
                    drInventory["Pallet_No"] = dr["Pallet No"].ToString().ToUpper();
                    drInventory["Status"] = dr["Status"].ToString().ToUpper();
                    drInventory["Quantity"] = dr["Piezas"].ToString();
                    drInventory["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    drInventory["Upload_Date"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    drInventory["Lean_Application"] = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    if (!drInventory["Quantity"].ToString().StartsWith("-"))
                    {
                        dtableInventoryDockArea.Rows.Add(drInventory);
                    }

                    count = count + 1;
                }
                return dtableInventoryDockArea;
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

                lblStatus.Text = ex.Message + "Error occured while parsing the excel file.. Please try again!!";
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
                return null;
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
                lblStatus.ForeColor = Color.Green;

                if (dt.Rows.Count > 0)
                {
                    objTestBusiness.Delete_InventoryDockArea(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                    bool result = objTestBusiness.Insert_bulkInsertto_Inventory_DockArea(dt);
                    if (result == true)
                    {
                        lblStatus.Text = " Records Entered into The Database Successfully!";
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Entering Data to Database Failed. Please Try Again!";
                        lblStatus.Visible = true;
                        lblStatus.ForeColor = Color.Red;
                    }
                }
                row_count = 0;
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

                lblStatus.Text = ex.Message.ToString() + "Entering Data to Database Failed Failed. Please Try Again!"; ;
                lblStatus.Visible = true;
                lblStatus.ForeColor = Color.Red;
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
    }
}
