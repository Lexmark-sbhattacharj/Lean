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
    public partial class DistributionExcep : System.Web.UI.Page
    {
        int row_count = 0;
        TestBusiness objTestBusiness;
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
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
                DataTable dt = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                LabelStatus.Visible = true;
                LabelStatus.Text = "Started Inserting Data into the Database";
                LabelStatus.ForeColor = Color.Green;

                if (dt.Rows.Count > 0)
                {
                    string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                    objTestBusiness.DeleteDistributionException(Lean_App);
                    bool result = objTestBusiness.insert_bulkInsertto_DistributionException(dt);
                    if (result == true)
                    {
                        LabelStatus.Text = row_count.ToString() + " Records Entered into The Database Successfully!";
                        LabelStatus.Visible = true;
                        LabelStatus.ForeColor = Color.Green;
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
                LabelStatus.Text = ex.Message.ToString();
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
                btnProcess.Visible = false;
                Session["ExcelData"] = null;
            }
        }

        protected void gvDistributionException_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDistributionException.PageIndex = e.NewPageIndex;
                gvDistributionException.DataSource = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                gvDistributionException.DataBind();
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
                gvDistributionException.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                LabelStatus.Text = ex.Message + "Some Error Occured. Please Try Again!";
                LabelStatus.Visible = true;
                gvDistributionException.Visible = false;
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
                            LabelStatus.Text = "Please Enter .xls or .xlsx files only";
                            LabelStatus.Visible = true;
                            LabelStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            string savepath = "C:\\Files\\DistributionExcep_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\DistributionExcep_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.Extension = Extension;
                            Session["ExcelData"] = objExcelData;
                            FileUpload1.PostedFile.SaveAs(savepath);
                            DataTable dt = FillDataTable(savepath, Extension);
                            if (dt.Rows.Count > 0)
                            {
                                gvDistributionException.Visible = true;
                                gvDistributionException.DataSource = dt;
                                gvDistributionException.DataBind();
                                gvDistributionException.Visible = true;
                                btnProcess.Visible = true;
                                LabelStatus.Visible = true;
                                //syelamanchal-Show upload rows count-Start
                                LabelStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                                LabelStatus.ForeColor = Color.Green;
                                //syelamanchal-Show upload rows count-End
                                // LabelStatus.Text = "Showing Upload File Preview ...";
                                LabelStatus.Visible = true;
                                LabelStatus.ForeColor = Color.Maroon;
                                btnProcess.Visible = true;
                            }
                            else
                            {
                                LabelStatus.Text = "Error in reading file";
                                LabelStatus.Visible = true;
                                LabelStatus.ForeColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        string savepath = "C:\\Files\\DistributionExcep_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\DistributionExcep_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.Extension = Extension;
                        Session["ExcelData"] = objExcelData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = FillDataTable(savepath, Extension);
                        if (dt.Rows.Count > 0)
                        {
                            gvDistributionException.Visible = true;
                            gvDistributionException.DataSource = dt;
                            gvDistributionException.DataBind();
                            gvDistributionException.Visible = true;
                            btnProcess.Visible = true;
                            LabelStatus.Visible = true;
                            //syelamanchal-Show upload rows count-Start
                            LabelStatus.Text = dt.Rows.Count.ToString() + " Records were ready to be inserted !!";
                            LabelStatus.ForeColor = Color.Green;
                            //syelamanchal-Show upload rows count-End
                            // LabelStatus.Text = "Showing Upload File Preview ...";
                            LabelStatus.Visible = true;
                            LabelStatus.ForeColor = Color.Maroon;
                            btnProcess.Visible = true;
                        }
                        else
                        {
                            LabelStatus.Text = "Error in reading file";
                            LabelStatus.Visible = true;
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
                LabelStatus.Text = "Error in reading file" + ex.Message;
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
                DataRow drInventory = default(DataRow);

                dt.Columns.Add("idLocalizationMaterial");
                dt.Columns.Add("idLocalizationMaterial_Excep");
                dt.Columns.Add("Upload_User");
                dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp
                foreach (DataRow row in dt.Rows)
                {
                    //syelamanchal
                    if ((row["Key 0"].ToString().ToUpper() == row["Key1"].ToString().ToUpper()) || (row["Key 0"].ToString().ToUpper() == row["Key 0"].ToString().ToUpper() + "E") || (row["Key 0"].ToString().ToUpper() == ""))
                    {
                        row.Delete();
                    }
                    // if (row["Key 0"].ToString().ToUpper() != "")
                    else
                    {
                        //   if (row["Key 0"].ToString().ToUpper() != row["Key1"].ToString().ToUpper())
                        {
                            //     if (row["Key 0"].ToString().ToUpper() != row["Key 0"].ToString().ToUpper() + "E")
                            {

                                //drInventory = dt.NewRow();
                                row["idLocalizationMaterial"] = row["Key1"].ToString().ToUpper();
                                row["idLocalizationMaterial_Excep"] = row["Key 0"].ToString().ToUpper();
                                row["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                                row["Upload_Date"] = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                                row["Lean_Application"] = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                                row_count = row_count + 1;
                                //dt.Rows.Add(drInventory);
                            }

                        }
                    }
                    //syelamanchal
                }
                dt.AcceptChanges();
                //syelamanchal--remove null rows from dt came from excel--start
                //return dt;
                return RemoveAllNullRowsFromDataTable(dt);
                //syelamanchal--remove null rows from dt came from excel--end
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                LabelStatus.Text = "Parsing Failed";
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

                return null;
            }
        }

        //syelamanchal--remove null rows from dt came from excel--start
        public static DataTable RemoveAllNullRowsFromDataTable(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][1] == DBNull.Value)
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            return dt;
        }
        //syelamanchal--remove null rows from dt came from excel--end
    }
}