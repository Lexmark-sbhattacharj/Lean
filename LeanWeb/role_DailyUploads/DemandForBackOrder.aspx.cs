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
    public partial class DemandForBackOrder : System.Web.UI.Page
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            LabelStatus.Text = "";
            Session["TextFileData"] = null;

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
                        string savepath = "C:\\Files\\DemandForBackOrder_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        objTextFileData.SavePath = "C:\\Files\\DemandForBackOrder_" + DateTime.Now.ToString("mmddyyhhmmss") + Extension;
                        Session["TextFileData"] = objTextFileData;
                        FileUpload1.PostedFile.SaveAs(savepath);
                        DataTable dt = new DataTable();
                        dt = bindUploadPreviewTable();
                        GridView_DemandForBackOrder.DataSource = dt;
                        GridView_DemandForBackOrder.DataBind();
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
                        objuserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                        objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objuserLoginInfo.UserID.ToString(), ex.Message);
                        //syelamanchal--Logging--end

                        this.GridView_DemandForBackOrder.Visible = false;
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
            DataTable dtableBackOrder = new DataTable();
            dtableBackOrder.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("idLocalization", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("idMaterial", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("Qty", Type.GetType("System.Decimal"));
            dtableBackOrder.Columns.Add("Mat_Date", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("sales_doc", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("Doc_Ca", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("SLNo", Type.GetType("System.String"));
            dtableBackOrder.Columns.Add("item", Type.GetType("System.String"));
            try
            {
                //DataSet dsLeadTime;
                //DateTime orderDate;
                //int intDateDiff, intLeadTime;
                //bool bolSWE = false;
                objTestBusiness.DeleteDemandForBackOrder(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if (stringRead.StartsWith("|") & !stringRead.StartsWith("| Sales Doc") & !stringRead.StartsWith("|*") & !stringRead.StartsWith("|    "))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        string idLocalizationMaterial = (parts[5]).ToUpper() + (parts[4]).ToUpper();
                        string idLocalization = (parts[5]).ToUpper();
                        string idMaterial = (parts[4]).ToUpper();
                        DateTime Mat_Date = Convert.ToDateTime(parts[6]);
                        string sales_Doc = (parts[1]);
                        string item = (parts[2]);
                        string SLNo = (parts[3]);
                        string Doc_Ca = (parts[7]);
                        int Quantity = Convert.ToInt32((parts[8]).Replace(",", ""));
                        string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                        DateTime Upload_Date = DateTime.Now;
                        string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                        bool result = objTestBusiness.CreateDemandForBackOrder(idLocalizationMaterial, idLocalization, idMaterial, sales_Doc, item, SLNo, Mat_Date, Doc_Ca, Quantity, Upload_User, Upload_Date, Lean_Application);
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

        }

        protected void GridView_DemandForBackOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindUploadPreviewTable();
                if (GridView_DemandForBackOrder.Rows.Count > 0)
                {
                    GridView_DemandForBackOrder.Visible = true;
                    btnProcess.Visible = true;
                    GridView_DemandForBackOrder.PageIndex = e.NewPageIndex;
                    GridView_DemandForBackOrder.DataSource = bindUploadPreviewTable();
                    GridView_DemandForBackOrder.DataBind();
                }
                else
                {
                    GridView_DemandForBackOrder.Visible = false;
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

        private DataTable bindUploadPreviewTable()
        {
            StreamReader sReader = new StreamReader(((TextFileData)Session["TextFileData"]).SavePath);
            string stringRead = "";
            DataTable dtableDemand = new DataTable();
            try
            {
                dtableDemand.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                dtableDemand.Columns.Add("idLocalization", Type.GetType("System.String"));
                dtableDemand.Columns.Add("idMaterial", Type.GetType("System.String"));
                dtableDemand.Columns.Add("sales_Doc", Type.GetType("System.String"));
                dtableDemand.Columns.Add("item", Type.GetType("System.String"));
                dtableDemand.Columns.Add("SLNo", Type.GetType("System.String"));
                dtableDemand.Columns.Add("Mat_Date", Type.GetType("System.String"));
                dtableDemand.Columns.Add("Doc_Ca", Type.GetType("System.String"));
                dtableDemand.Columns.Add("Quantity", Type.GetType("System.Decimal"));

                DataRow drInventory = default(DataRow);
                while (!(sReader.EndOfStream))
                {
                    stringRead = sReader.ReadLine();
                    if (stringRead.StartsWith("|") & !stringRead.StartsWith("| Sales Doc") & !stringRead.StartsWith("|*") & !stringRead.StartsWith("|    "))
                    {
                        // Split the string on the | character
                        string[] parts = stringRead.Split(new char[] { '|' });
                        drInventory = dtableDemand.NewRow();
                        drInventory["idLocalizationMaterial"] = (parts[5]).ToUpper() + (parts[4]).ToUpper();
                        drInventory["idLocalization"] = (parts[5]).ToUpper();
                        drInventory["idMaterial"] = (parts[4]).ToUpper();
                        drInventory["sales_Doc"] = (parts[1]);
                        drInventory["item"] = (parts[2]);
                        drInventory["SLNo"] = (parts[3]);
                        drInventory["Mat_Date"] = (parts[6]);
                        drInventory["Doc_Ca"] = (parts[7]).ToUpper();
                        drInventory["Quantity"] = Convert.ToInt32((parts[8].Replace(",", "")));
                        if (!drInventory["Quantity"].ToString().StartsWith("-"))
                        {
                            dtableDemand.Rows.Add(drInventory);
                        }
                    }
                }
                if (dtableDemand.Rows.Count > 0)
                {
                    GridView_DemandForBackOrder.Visible = true;
                    btnProcess.Visible = true;
                    drInventory = dtableDemand.NewRow();
                    drInventory["idLocalizationMaterial"] = "TOTAL";
                    drInventory["idMaterial"] = dtableDemand.Compute("count(Quantity)", "") + " Rows";
                    drInventory["Quantity"] = dtableDemand.Compute("sum(Quantity)", "");
                    dtableDemand.Rows.Add(drInventory);
                    return dtableDemand;
                }
                else
                {
                    GridView_DemandForBackOrder.Visible = false;
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

                GridView_DemandForBackOrder.Visible = false;
                btnProcess.Visible = false;
                LabelStatus.Text = "Error Showing Preview Data. " + ex.Message;
                LabelStatus.ForeColor = Color.Red;
                return null;
            }
            finally
            {
                if (dtableDemand != null)
                {
                    dtableDemand.Dispose();
                }
            }
        }
    }
}