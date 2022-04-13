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
    public partial class InventoryInTransit : System.Web.UI.Page
    {
        UserLoginInfo objuserLoginInfo1 = new UserLoginInfo();
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
                objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
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
                    objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
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
                objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
            }
        }

        protected void GridView_InventoryInTransit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindUploadPreviewTable();
                if (GridView_InventoryInTransit.Rows.Count > 0)
                {
                    GridView_InventoryInTransit.Visible = true;
                    btnProcess.Visible = true;
                    GridView_InventoryInTransit.PageIndex = e.NewPageIndex;
                    GridView_InventoryInTransit.DataSource = bindUploadPreviewTable();
                    GridView_InventoryInTransit.DataBind();
                }
                else
                {
                    GridView_InventoryInTransit.Visible = false;
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
                objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
             
            LabelStatus.Text = "ERROR: Page Change On GirdView. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
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
                        string savepath = "C:\\Files\\InventoryInTransit_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objTextFileData.SavePath = "C:\\Files\\InventoryInTransit_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        Session["TextFileData"] = objTextFileData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = new DataTable();
                        dt = bindUploadPreviewTable();
                        GridView_InventoryInTransit.DataSource = dt;
                        GridView_InventoryInTransit.DataBind();
                        //syelamanchal-Show upload rows count-Start
                        LabelStatus.Text = (dt.Rows.Count-1).ToString() + " Records were ready to be inserted !!";
                        LabelStatus.ForeColor = Color.Green;
                        //syelamanchal-Show upload rows count-End
                        // LabelStatus.Text = "Showing Upload File Preview ...";
                        LabelStatus.ForeColor = Color.Maroon;

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
                        objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                        objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
                        //syelamanchal--Logging--end
                      
                    this.GridView_InventoryInTransit.Visible = false;
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            StreamReader sReader = new StreamReader(((TextFileData)Session["TextFileData"]).SavePath);
            string stringRead = null;
            int counter = 0;
            try
            {
                objTestBusiness.DeleteInventoryInTransit(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if (stringRead.StartsWith("|") & !stringRead.StartsWith("|Material"))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        if (!(parts[9].Contains("-")))
                        {
                            //syalamanchili--location is not appended while saving into database--Start
                            //string idLocalizationMaterial = parts[5].ToUpper() + (parts[1]).ToUpper();
                            string idLocalizationMaterial = parts[3].ToUpper() + (parts[1]).ToUpper();
                            //syalamanchili--location is not appended while saving into database--End
                            string idLocalization = (parts[3]).ToUpper();
                            string Localization_Name = (parts[4]).ToUpper();
                            string idMaterial = (parts[1]);
                            string Material_Name = (parts[2]).ToUpper();
                            int Quantity = Convert.ToInt32((parts[9]).Replace(",", ""));
                            string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                            DateTime Upload_Date = DateTime.Now;
                            string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                            bool result = objTestBusiness.CreateInventoryInTransit(idLocalizationMaterial, idLocalization, Localization_Name, idMaterial, Material_Name, Quantity, Upload_User, Upload_Date, Lean_Application);
                            if (result == true)
                            {
                                counter++;
                                LabelStatus.Text = counter + " Records was inserted succesfully!!";
                                LabelStatus.ForeColor = Color.Green;
                            }
                            else
                            {
                                LabelStatus.Text = counter + " Error uploading the file";
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
                objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
              
            LabelStatus.Text = "ERROR: Inserting in SQL. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return;
            }
            finally
            {
                GridView_InventoryInTransit.Visible = false;
                btnProcess.Visible = false;
            }
        }

        private DataTable bindUploadPreviewTable()
        {
            StreamReader sReader = new StreamReader(((TextFileData)Session["TextFileData"]).SavePath);
            string stringRead = "";
            DataTable dtableInventoryInTransit = new DataTable();
            try
            {
                dtableInventoryInTransit.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                dtableInventoryInTransit.Columns.Add("idLocalization", Type.GetType("System.String"));
                dtableInventoryInTransit.Columns.Add("Localization_Name", Type.GetType("System.String"));
                dtableInventoryInTransit.Columns.Add("idMaterial", Type.GetType("System.String"));
                dtableInventoryInTransit.Columns.Add("Material_Name", Type.GetType("System.String"));
                dtableInventoryInTransit.Columns.Add("Quantity", Type.GetType("System.Decimal"));

                DataRow drInventory = default(DataRow);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if (stringRead.StartsWith("|") & !stringRead.StartsWith("|Material"))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        if (!(parts[9].Contains("-")))
                        {
                            drInventory = dtableInventoryInTransit.NewRow();
                            drInventory["idLocalizationMaterial"] = (parts[3]) + (parts[1]).ToUpper();
                            drInventory["idLocalization"] = (parts[3]).ToUpper();
                            drInventory["Localization_Name"] = (parts[4]).ToUpper();
                            drInventory["idMaterial"] = (parts[1]).ToUpper();
                            drInventory["Material_Name"] = (parts[2]).ToUpper();
                            drInventory["Quantity"] = Convert.ToInt32((parts[9].Replace(",", "")));
                            if (!drInventory["Quantity"].ToString().StartsWith("-"))
                            {
                                dtableInventoryInTransit.Rows.Add(drInventory);
                            }
                        }
                    }
                }
                if (dtableInventoryInTransit.Rows.Count > 0)
                {
                    GridView_InventoryInTransit.Visible = true;
                    btnProcess.Visible = true;
                    drInventory = dtableInventoryInTransit.NewRow();
                    drInventory["idLocalizationMaterial"] = "TOTAL";
                    drInventory["Localization_Name"] = dtableInventoryInTransit.Compute("count(Quantity)", "") + " Rows";
                    drInventory["Quantity"] = dtableInventoryInTransit.Compute("sum(Quantity)", "");
                    dtableInventoryInTransit.Rows.Add(drInventory);
                    return dtableInventoryInTransit;
                }
                else
                {
                    GridView_InventoryInTransit.Visible = false;
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
                objuserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo1.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
             
            GridView_InventoryInTransit.Visible = false;
                btnProcess.Visible = false;
                LabelStatus.Text = "Error Showing Preview Data. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return null;
            }
            finally
            {
                if (dtableInventoryInTransit != null)
                {
                    dtableInventoryInTransit.Dispose();
                }
            }
        }
    }
}