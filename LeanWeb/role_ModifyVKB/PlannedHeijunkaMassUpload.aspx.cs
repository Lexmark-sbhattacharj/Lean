using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Office;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using LeanBusiness;
using Lean.Utilities;
using LeanData;


namespace LeanWeb.role_ModifyVKB
{
    public partial class PlannedHeijunkaMassUpload : System.Web.UI.Page
    {
        int row_count = 0;
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ExcelData objExcelData = new ExcelData();
        string savepath, Extension;

        //public void Page_Init(object o, EventArgs e)
        //{
            
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((UserLoginInfo)Session["UserLoginInfo"] == null)
                {
                    Response.Redirect("~/LeanLogout.aspx", false);
                }
                //syelamanchal--Adding roles functionality to user--start
                string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                TestBusiness objTestBusiness;
                objTestBusiness = new TestBusiness();
                if (objTestBusiness.Validate_UserInRole(UserName, "ModifyVKB") != 1)
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
                LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo1.UserID.ToString(), ex.Message);
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
                            savepath = "C:\\Files\\PlannedHeijunka_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                            objExcelData.SavePath = "C:\\Files\\PlannedHeijunka_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
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
                        savepath = "C:\\Files\\PlannedHeijunka_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objExcelData.SavePath = "C:\\Files\\PlannedHeijunka_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
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

              //  dt.Columns.Add("Active");
               // dt.Columns.Add("Upload_User");
               // dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp
                foreach (DataRow row in dt.Rows)
                {
                //    row["Active"] = true;
                //    row["Upload_User"] = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
               //     row["Upload_Date"] = DateTime.Now.ToShortDateString();
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

        //Query to fetch all values from database
        public string ConnectionString()
        {
            //string strConnectionString = ConfigurationManager.ConnectionStrings["LeanConnectionString"].ConnectionString;
            string strConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            return strConnectionString;
        }

        protected void Bulk_Insert()
        {
            btnUpload.Enabled = false;
            FileUpload1.Enabled = false;
            btnProcess.Enabled = false;
            try
            {
                TestData objTest = new TestData();
                string Lean_App = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DataTable dt = new DataTable();
                dt = FillDataTable(((ExcelData)Session["ExcelData"]).SavePath, ((ExcelData)Session["ExcelData"]).Extension);
                row_count = dt.Rows.Count;
                int row_count2 = dt.Rows.Count;
                DateTime Date = DateTime.Now;
                if (row_count >= 0)
                {
                    int rowcount = (dt.Rows.Count);
                    while (row_count > 0)
                    {
                        row_count--;
                        //syalamanchal
                        string strConnString = ConnectionString();
                        //SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                        using (var connection = new System.Data.SqlClient.SqlConnection(strConnString))
                        {

                            var sql = "SELECT KanbanNeededForOrange_Pallets,KanbanNeededForRed_Pallets,KanbanNeededForYellow_Pallets,KanbanNeededForGreen_Pallets  FROM [VKB_Detail_PartNumber] vkb"
                            + " inner JOIN[VKB_Global_Line]  Gline ON Gline.[Lean_Application] = vkb.[Lean_Application] and vkb.[idvkb] = Gline.[idvkb]  "
                            + " inner JOIN[line] line ON Gline.idLine = line.idLine and Gline.[Lean_Application]=line.[Lean_Application]"
                            + " where    vkb.[Lean_Application] ='" + Lean_App
                            + "' AND vkb.[idMaterial] = '" + dt.Rows[row_count][0].ToString() + "' AND vkb.[Localization_Name] = '" + dt.Rows[row_count][1].ToString() + "'"
                            + " AND Gline.Date = '" + DateTime.Now.ToString("MM/dd/yyyy") + "'"
                            + " AND Line.Line ='" + dt.Rows[row_count][2].ToString() + "'";
                            connection.Open();
                            using (var cmd = new SqlCommand(sql, connection))
                            {

                                cmd.Parameters.Add("@Lean_Application", SqlDbType.NVarChar).Value = Lean_App;
                                cmd.Parameters.Add("@idMaterial", SqlDbType.NVarChar).Value = dt.Rows[row_count][0].ToString();
                                cmd.Parameters.Add("@Localization_Name", SqlDbType.NVarChar).Value = dt.Rows[row_count][1].ToString();
                                cmd.Parameters.Add("@Line", SqlDbType.NVarChar).Value = dt.Rows[row_count][2].ToString();

                                using (var reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {

                                        if (Convert.ToDouble(dt.Rows[row_count][3].ToString()) <= Convert.ToDouble(Convert.ToDouble(reader[0].ToString()) + Convert.ToDouble(reader[1].ToString()) + Convert.ToDouble(reader[2].ToString()) + Convert.ToDouble(reader[3].ToString())))
                                        {
                                            bool result = objTest.UpdateForMassUpload(dt.Rows[row_count][0].ToString(), dt.Rows[row_count][1].ToString(), dt.Rows[row_count][2].ToString(), dt.Rows[row_count][3].ToString(), Lean_App);
                                            if (result == true)
                                            {
                                                // lblStatus.Text = (dt.Rows.Count).ToString() + " Records Entered into The Database Successfully!";
                                                lblStatus.Text = rowcount.ToString() + " Records updated into the Database Successfully!";
                                                lblStatus.Visible = true;
                                                lblStatus.ForeColor = Color.Green;
                                                //  lbtnBack.Visible = true;
                                            }
                                            else
                                            {
                                                rowcount--;
                                                lblStatus.Text = "Entering Data to Database Failed for Part Number = " + Lean_App + " idMaterial = " + dt.Rows[row_count][0].ToString() + " Location=" + dt.Rows[row_count][1].ToString() + " Line=" + dt.Rows[row_count][2].ToString() + " . Please Try Again!";
                                                lblStatus.Visible = true;
                                                lblStatus.ForeColor = Color.Red;
                                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + lblStatus.Text + "');", true);
                                                // lbtnBack.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            double RecommendedValue = Convert.ToDouble(Convert.ToDouble(reader[0].ToString()) + Convert.ToDouble(reader[1].ToString()) + Convert.ToDouble(reader[2].ToString()) + Convert.ToDouble(reader[3].ToString()));
                                            bool result1 = objTest.UpdateForMassUpload(dt.Rows[row_count][0].ToString(), dt.Rows[row_count][1].ToString(), dt.Rows[row_count][2].ToString(), RecommendedValue.ToString(), Lean_App);
                                            if (result1 == true) 
                                            {                                              
                                                lblStatus.Text = "One or more Planned heijunka values are more than the recommended values so they have been limited to recommended values.";
                                                lblStatus.Visible = true;
                                                lblStatus.ForeColor = Color.Red;
                                                // lbtnBack.Visible = true;
                                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + lblStatus.Text + "');", true);
                                            }
                                            else
                                            {
                                                rowcount--;
                                                lblStatus.Text = "Entering Data to Database Failed for Part Number = " + Lean_App + " idMaterial = " + dt.Rows[row_count][0].ToString() + " Location=" + dt.Rows[row_count][1].ToString() + " Line=" + dt.Rows[row_count][2].ToString() + " . Please Try Again!";
                                                lblStatus.Visible = true;
                                                lblStatus.ForeColor = Color.Red;
                                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + lblStatus.Text + "');", true);
                                                // lbtnBack.Visible = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        rowcount--;
                                        row_count2--;
                                        //  lblStatus.Text += "There is no data exists  for Part Number = " + Lean_App + " idMaterial = " + dt.Rows[row_count][0].ToString() + " Location=" + dt.Rows[row_count][1].ToString() + " Line=" + dt.Rows[row_count][2].ToString() + " . Please Try Again!. \r\n";
                                       // lblStatus.Text = "There is no data exists for one or more rows from excel file . Please Try Again!";
                                      //  lblStatus.Visible = true;
                                      //  lblStatus.ForeColor = Color.Red;
                                        // lbtnBack.Visible = true;
                                     //   ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + lblStatus.Text + "');", true);
                                        if (row_count2 == 0)
                                        {
                                            lblStatus.Text += "There is no data exists in database for given excel file.";
                                            lblStatus.Visible = true;
                                            lblStatus.ForeColor = Color.Red;
                               //             ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + lblStatus.Text + "');", true);
                                        }
                                    }
                                }
                            }
                            connection.Close();
                            connection.Dispose();

                        }
                    }
                }
                else
                {
                    lblStatus.Text = "Excel entered has no data.Please try again!";
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = Color.Red;
                    // lbtnBack.Visible = true;
                }

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
                Response.Redirect("~/role_ModifyVKB/HeijunkaPlannedLine.aspx");
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

        //protected void Delete(string Lean_App)
        //{
        //    try
        //    {
        //        TestData objTest = new TestData();
        //        bool result = objTest.DeleteFromVKB_Detail_PartNumber(Lean_App);
        //        if (result == false)
        //        {
        //            lblStatus.Text = "Error Occured while Deleting";
        //            lblStatus.Visible = true;
        //            lblStatus.ForeColor = Color.Red;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblStatus.Text = ex.Message.ToString() + "Error Occured while Deleting";
        //        lblStatus.Visible = true;
        //        lblStatus.ForeColor = Color.Red;
        //    }
        //}

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