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
    public partial class InventoryDistrCenters : System.Web.UI.Page
    {
        UserLoginInfo objuserLoginInfo = new UserLoginInfo();
        TestBusiness objTestBusiness;
        TextFileData objTextFileData = new TextFileData();

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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objTestBusiness = new TestBusiness();
            //syelamanchal--Adding roles functionality to user--start
            string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            if (objTestBusiness.Validate_UserInRole(UserName, "DailyUploads") != 1)
            {
                Response.Redirect("~/LeanHome.aspx");
            }
            //syelamanchal--Adding roles functionality to user--end
            try
            {
                if (!IsPostBack)
                {
                    objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
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
                objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void btnUpload_Click(object sender, System.EventArgs e)
        {
            Session["TextFileData"] = null;
            LabelStatus.Text = "";

            if (FileUpload1.HasFile)
            {
                string Extension = Path.GetExtension(FileUpload1.FileName).ToLower();

                if (Extension != ".txt")
                {
                    LabelStatus.Text = "Cannot accept files of this type, please select a valid TXT file.";
                    LabelStatus.ForeColor = Color.Red;
                }
                else
                {
                    try
                    {
                        string savepath = "C:\\Files\\InventoryDistributionCenter_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objTextFileData.SavePath = "C:\\Files\\InventoryDistributionCenter_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        Session["TextFileData"] = objTextFileData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = new DataTable();
                        dt = bindUploadPreviewTable();
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                   //     LabelStatus.Text = "Showing Upload File Preview ...";
                   //     LabelStatus.ForeColor = Color.Maroon;
                        
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
                     
                    this.GridView1.Visible = false;
                            this.btnProcess.Visible = false;
                            LabelStatus.Text = "Error Uploading File. " + ex.Message;
                            LabelStatus.ForeColor = Color.Red;
                        
                    }
                }
            }
            else
            {
                LabelStatus.ForeColor = Color.Red;
                LabelStatus.Text = "Please select a TXT file to upload";
            }
        }

        private DataTable bindUploadPreviewTable()
        {
            StreamReader sReader = new StreamReader(((TextFileData)Session["TextFileData"]).SavePath);
            string stringRead = "";
            DataTable dtableInventoryDistributionCenters = new DataTable();

            try
            {
                dtableInventoryDistributionCenters.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                dtableInventoryDistributionCenters.Columns.Add("idLocalization", Type.GetType("System.String"));
                dtableInventoryDistributionCenters.Columns.Add("idMaterial", Type.GetType("System.String"));
                dtableInventoryDistributionCenters.Columns.Add("Quantity", Type.GetType("System.Decimal"));
                DataRow drInventory = default(DataRow);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if ((UserLoginInfo)Session["UserLoginInfo"] != null && stringRead.StartsWith("|") & !stringRead.StartsWith("| Materia") & !stringRead.StartsWith("|*") & !stringRead.StartsWith("|    "))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        if (Convert.ToDecimal((parts[6].Replace(",", ""))) > 0)
                        {
                            drInventory = dtableInventoryDistributionCenters.NewRow();
                            //syalamanchili--location and Material contains space between while appending  --Start
                            //drInventory["idLocalizationMaterial"] = (parts[2]).ToUpper() + (parts[1]).ToUpper();
                            drInventory["idLocalizationMaterial"] = (parts[2]).ToUpper().Trim() + (parts[1]).ToUpper().Trim();
                            //syalamanchili--location and Material contains space between while appending  --end
                            drInventory["idLocalization"] = (parts[2]).ToUpper();
                            drInventory["idMaterial"] = (parts[1]).ToUpper();
                            drInventory["Quantity"] = (parts[6].Replace(",", ""));
                            if (!drInventory["Quantity"].ToString().StartsWith("-"))
                            {
                                dtableInventoryDistributionCenters.Rows.Add(drInventory);
                            }
                        }
                    }
                }
                if (dtableInventoryDistributionCenters.Rows.Count > 0)
                {
                   //syelamanchal-Show upload rows count-Start
                    LabelStatus.Text = dtableInventoryDistributionCenters.Rows.Count.ToString() + " Records were ready to be inserted !!";
                    LabelStatus.ForeColor = Color.Green;
                    //syelamanchal-Show upload rows count-End

                    GridView1.Visible = true;
                    btnProcess.Visible = true;
                    drInventory = dtableInventoryDistributionCenters.NewRow();
                    drInventory["idLocalizationMaterial"] = "TOTAL";
                    drInventory["idLocalization"] = dtableInventoryDistributionCenters.Compute("count(Quantity)", "") + " Rows";
                    drInventory["Quantity"] = dtableInventoryDistributionCenters.Compute("sum(Quantity)", "");
                    dtableInventoryDistributionCenters.Rows.Add(drInventory);
                    return dtableInventoryDistributionCenters;
                }
                else
                {
                    GridView1.Visible = false;
                    btnProcess.Visible = false;

                    LabelStatus.Text = "Empty TXT file.";
                    LabelStatus.ForeColor = Color.Red;
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
             
            GridView1.Visible = false;
                btnProcess.Visible = false;
                LabelStatus.Text = "Error Showing Preview Data. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return null;
            }
            finally
            {
                if (dtableInventoryDistributionCenters != null)
                {
                    dtableInventoryDistributionCenters.Dispose();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindUploadPreviewTable();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    btnProcess.Visible = true;
                    GridView1.PageIndex = e.NewPageIndex;
                    GridView1.DataSource = bindUploadPreviewTable();
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                    btnProcess.Visible = false;
                    LabelStatus.Text = "Error Showing Upload Preview.";
                    LabelStatus.ForeColor = Color.Red;
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
              
            LabelStatus.Text = "ERROR: Page Change On GirdView. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
            }
        }

        protected void btnProcess_Click(object sender, System.EventArgs e)
        {
            StreamReader sReader = new StreamReader(((TextFileData)Session["TextFileData"]).SavePath);
            string stringRead = null;
            int counter = 0;

            try
            {
                objTestBusiness.DeleteInventory_DistributionCenters(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if ((UserLoginInfo)Session["UserLoginInfo"] != null && stringRead.StartsWith("|") & !stringRead.StartsWith("| Materia") & !stringRead.StartsWith("|*") & !stringRead.StartsWith("|    "))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        if (Convert.ToDecimal((parts[6].Replace(",", ""))) > 0)
                        {
                            //syalamanchili--location and Material contains space between while appending  --Start
                            //string idLocalizationMaterial = (parts[2]).ToUpper() + (parts[1]).ToUpper();
                            string idLocalizationMaterial = (parts[2]).ToUpper().Trim() + (parts[1]).ToUpper().Trim();
                            //syalamanchili--location and Material contains space between while appending  --End
                            string idLocalization = (parts[2]).ToUpper();
                            string idMaterial = (parts[1]).ToUpper();
                            int Quantity = Convert.ToInt32((parts[6]).Replace(",", ""));
                            string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                            string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                            bool result = objTestBusiness.CreateInventory_DistributionCenters(idLocalizationMaterial, idLocalization, idMaterial, Quantity, Upload_User, Lean_Application);
                            if (result == true)
                            {
                                counter++;
                                LabelStatus.Text = counter +  " Records was inserted succesfully!!";
                                LabelStatus.ForeColor = Color.Green;
                            }
                            else
                            {
                                LabelStatus.Text = counter +  " Error uploading the file";
                                LabelStatus.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                sReader.Close();
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
               
            LabelStatus.Text = "ERROR: Inserting in SQL. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return;
            }
            finally
            {
                GridView1.Visible = false;
                btnProcess.Visible = false;
            }
        }
    }
}