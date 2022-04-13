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

namespace LeanWeb.role_PeriodicUploads
{
    public partial class VKBInput : System.Web.UI.Page
    {
        int row_count = 0;
        TestBusiness objTestBusiness;
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        DataSet dsBulkAM = new DataSet();
        DataTable dtableBulkAM = new System.Data.DataTable();
        DataTable dtableVKBInput = new DataTable();
        ExcelData objExcelData = new ExcelData();
        string savepath, Extension;

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
            try
            {
                //syelamanchal--Adding roles functionality to user--start
                objTestBusiness = new TestBusiness();
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                if (objTestBusiness.Validate_UserInRole(UserName, "PeriodicUploads") != 1)
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

        protected void Bulk_Insert()
        {
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            btnProcess.Enabled = false;
            try
            {
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DataTable dt = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                LabelStatus.Text = "Started Inserting Data into the Database";
                LabelStatus.ForeColor = Color.Green;
                LabelStatus.Visible = true;

                if (dt.Rows.Count > 0)
                {
                    objTestBusiness.DeleteVKBInput(Lean_App);
                    bool result = objTestBusiness.insert_bulkInsertto_VKBInput(dt);
                    if (result == true)
                    {
                        LabelStatus.Text = " Records Entered into The Database Successfully!";
                        LabelStatus.ForeColor = Color.Green;
                        LabelStatus.Visible = true;
                    }
                    else
                    {
                        LabelStatus.Text = "Entering Data to Database Failed Failed. Please Try Again!";
                        LabelStatus.Visible = true;
                        LabelStatus.ForeColor = Color.Red;
                    }
                }
                row_count = 0;
            }
            catch (Exception ex)
            {
                LabelStatus.Text = ex.Message.ToString() + "Entering Data to Database Failed Failed. Please Try Again!";
                LabelStatus.Visible = true;
                LabelStatus.ForeColor = Color.Red;

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
                Session["ExcelData"] = null;
                btnProcess.Visible = false;
            }
        }

        protected void gvVKBInput_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVKBInput.PageIndex = e.NewPageIndex;
                gvVKBInput.DataSource = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                gvVKBInput.DataBind();
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Bulk_Insert();
                gvVKBInput.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                LabelStatus.Text = ex.Message + "Some Error Occured. Please Try Again!";
                gvVKBInput.Visible = false;
                LabelStatus.Visible = true;
                LabelStatus.ForeColor = Color.Red;

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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            LabelStatus.Visible = false;
            Session["ExcelData"] = null;
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
                            LabelStatus.Visible = true;
                            LabelStatus.Text = "Please Enter .xls or .xlsx files only";
                            LabelStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            savepath = "C:\\Files\\VKBInput_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\VKBInput_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.Extension = Extension;
                            Session["ExcelData"] = objExcelData;
                            FileUpload1.PostedFile.SaveAs(savepath);
                            DataTable dt = FillDataTable(savepath, Extension);
                            if (dt.Rows.Count > 0)
                            {
                                gvVKBInput.DataSource = dt;
                                gvVKBInput.DataBind();
                                gvVKBInput.Visible = true;
                                btnProcess.Visible = true;
                            }
                            else
                            {
                                LabelStatus.Visible = true;
                                LabelStatus.Text = "Error in reading file";
                                LabelStatus.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        savepath = "C:\\Files\\VKBInput_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\VKBInput_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.Extension = Extension;
                        Session["ExcelData"] = objExcelData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = FillDataTable(savepath, Extension);
                        if (dt.Rows.Count > 0)
                        {
                            gvVKBInput.DataSource = dt;
                            gvVKBInput.DataBind();
                            gvVKBInput.Visible = true;
                            btnProcess.Visible = true;
                        }
                        else
                        {
                            LabelStatus.Visible = true;
                            LabelStatus.Text = "Error in reading file";
                            LabelStatus.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    LabelStatus.Text = "Please Select a File to Upload";
                    LabelStatus.Visible = true;
                    LabelStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LabelStatus.Visible = true;
                LabelStatus.Text = "Error in reading file" + ex.Message;
                LabelStatus.ForeColor = Color.Red;

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
                DataSet ds = new DataSet();
                DataRow drInventory = default(DataRow);

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet 
                connExcel.Open();
                DataTable dtExcelSchema = new DataTable();
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet 
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(ds);
                connExcel.Close();

                dt.Columns.Add("idLocalizationMaterial");
                dt.Columns.Add("idMaterial");
                dt.Columns.Add("idLine");
                dt.Columns.Add("AverageDemand");
                dt.Columns.Add("SD");
                dt.Columns.Add("CV");
                dt.Columns.Add("Min_Pallet");
                dt.Columns.Add("Target_Pallet");
                dt.Columns.Add("Max_Pallet");
                dt.Columns.Add("Pallet_Qty");
                dt.Columns.Add("UDC");
                dt.Columns.Add("Localization_Name");
                dt.Columns.Add("Platform");
                dt.Columns.Add("Family");
                dt.Columns.Add("Type_SWE_AM");
                dt.Columns.Add("PPVT");
                dt.Columns.Add("Brand");
                dt.Columns.Add("Yield");
                dt.Columns.Add("Upload_User");
                dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drInventory = dt.NewRow();
                        drInventory["idLocalizationMaterial"] = dr["Key"].ToString();
                        drInventory["idMaterial"] = dr["PN"].ToString();
                        string idLine = objTestBusiness.get_id_line(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, dr["VKB"].ToString());
                        if (idLine == "" || idLine == null || idLine == string.Empty)
                        {
                            drInventory["idLine"] = 0;
                        }
                        else
                        {
                            drInventory["idLine"] = Convert.ToInt32(idLine);
                        }
                        if (dr["Average Demand (units/wk)"].ToString() == "" || dr["Average Demand (units/wk)"].ToString() == null || dr["Average Demand (units/wk)"].ToString() == string.Empty)
                        {
                            drInventory["AverageDemand"] = 0.0;
                        }
                        else
                        {
                            drInventory["AverageDemand"] = Convert.ToDouble(dr["Average Demand (units/wk)"].ToString());
                        }
                        if (dr["SD"].ToString() == "" || dr["SD"].ToString() == null || dr["SD"].ToString() == string.Empty)
                        {
                            drInventory["SD"] = 0.0;
                        }
                        else
                        {
                            drInventory["SD"] = Convert.ToDouble(dr["SD"].ToString());
                        }
                        if (dr["CV"].ToString() == "" || dr["CV"].ToString() == null || dr["CV"].ToString() == string.Empty)
                        {
                            drInventory["CV"] = 0.0;
                        }
                        else
                        {
                            drInventory["CV"] = Convert.ToDouble(dr["CV"].ToString());
                        }
                        if (dr["MIN"].ToString() == "" || dr["MIN"].ToString() == null || dr["MIN"].ToString() == string.Empty)
                        {
                            drInventory["Min_Pallet"] = 0;
                        }
                        else
                        {
                            drInventory["Min_Pallet"] = Convert.ToInt32(dr["MIN"].ToString());
                        }
                        if (dr["TARGET"].ToString() == "" || dr["TARGET"].ToString() == null || dr["TARGET"].ToString() == string.Empty)
                        {
                            drInventory["Target_Pallet"] = 0;
                        }
                        else
                        {
                            drInventory["Target_Pallet"] = Convert.ToInt32(dr["TARGET"].ToString());
                        }
                        if (dr["MAX"].ToString() == "" || dr["MAX"].ToString() == null || dr["MAX"].ToString() == string.Empty)
                        {
                            drInventory["Max_Pallet"] = 0;
                        }
                        else
                        {
                            drInventory["Max_Pallet"] = Convert.ToInt32(dr["MAX"].ToString());
                        }
                        if (dr["Pallet"].ToString() == "" || dr["Pallet"].ToString() == null || dr["Pallet"].ToString() == string.Empty)
                        {
                            drInventory["Pallet_Qty"] = 0;
                        }
                        else
                        {
                            drInventory["Pallet_Qty"] = Convert.ToInt32(dr["Pallet"].ToString());
                        }
                        drInventory["UDC"] = dr["UDC"].ToString();
                        drInventory["Localization_Name"] = dr["LOC"].ToString();
                        drInventory["Platform"] = dr["Line"].ToString();
                        drInventory["Family"] = dr["Family"].ToString();
                        drInventory["Type_SWE_AM"] = dr["Type"].ToString();
                        drInventory["PPVT"] = dr["PPVT"].ToString();
                        drInventory["Brand"] = dr["Brand"].ToString();
                        drInventory["Yield"] = dr["YIELD"].ToString();
                        drInventory["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                        drInventory["Upload_Date"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        drInventory["Lean_Application"] = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                        dt.Rows.Add(drInventory);
                    }
                }
                else
                {
                    LabelStatus.Text = "Entered File is Blank";
                    LabelStatus.ForeColor = Color.Red;
                    LabelStatus.Visible = true;
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                LabelStatus.Visible = true;
                LabelStatus.Text = "Parsing Failed";
                LabelStatus.ForeColor = Color.Red;
                

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