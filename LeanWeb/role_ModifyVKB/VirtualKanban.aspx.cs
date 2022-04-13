using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using LeanBusiness;
using Lean.Utilities;
using System.Data;
using System.Text;
using LeanWeb.App_Code;

namespace LeanWeb.role_ModifyVKB
{
    public partial class VirtualKanban : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ProdPrioritySession objProdPrioritySession = new ProdPrioritySession();
        TestBusiness objTestBusiness;

        #region Variable Declaration

        string idLocalizationMaterial_dtVKB;
        string UDC_dtVKB;
        float CV_dtVKB;
        float PrimaryPriority_dtVKB;
        string idMaterial_dtVKB;
        string Localization_Name_dtVKB;
        float PrecentRed_dtVKB;
        float Customer_Backorder_Units_dtVKB;
        float BTO_Units_dtVKB;
        float Special_Bids_Units_dtVKB;
        float Projected_Backorder_Units_dtVKB;
        float InvOnDisCenter_Units_dtVKB;
        float InvInTransit_Units_dtVKB;
        float SAPKanbanTotal_Pallets_dtVKB;
        float HeijunkaKanban_Pallets_dtVKB;
        float TotalKanban_Pallets_dtVKB;
        float TotalInvpercent_dtVKB;
        float RedPorc_dtVKB;
        float YellowPorc_dtVKB;
        float GreenPorc_dtVKB;
        float KanbanNeededForCustomerBO_Pallets_dtVKB;
        float KanbanNeededForBTO_Pallets_dtVKB;
        float KanbanNeededForSpecialBid_Pallets_dtVKB;
        float KanbanNeededForProjectedBO_Pallets_dtVKB;
        float KanbanNeededForOrange_Pallets_dtVKB;
        float KanbanNeededForRed_Pallets_dtVKB;
        float KanbanNeededForYellow_Pallets_dtVKB;
        float KanbanNeededForGreen_Pallets_dtVKB;
        float MinKanban_Pallets_dtVKB;
        float TargetKanban_Pallets_dtVKB;
        float MaxKanban_Pallets_dtVKB;
        float ExcessKanban_Pallets_dtVKB;
        float HeijunkaBoard_Pallets_dtVKB;
        string Platform_dtVKB;
        string Family_dtVKB;
        float AverageDemand_dtVKB;
        int Pallet_Qty_dtVKB;
        string Type_dtVKB;
        float High_Priority_Units_dtVKB;
        int Remd_Pallet_dtVKB;
        string PPVT_dtVKB;
        string Yield_dtVKB;

        #endregion

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
            string test_1 = HiddenField1.Value;
            objTestBusiness = new TestBusiness();
            string LeanApp = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
            DateTime Date = DateTime.Now;
            string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            Capabilities objCapabilities = new Capabilities();
            try
            {
                if (!IsPostBack)
                {
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    objProdPrioritySession = (ProdPrioritySession)Session["ProdPrioritySession"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        //HiddenField1.Value = DateTime.Now.ToShortDateString();
                        Session["Capabilities"] = null;
                        objCapabilities.Line = Request.QueryString["line"];
                        objCapabilities.Quantity = Convert.ToInt32(Request.QueryString["qty"]);
                        Session["Capabilities"] = objCapabilities;
                        BindLine();
                        checkUploadforSelecteddate();
                        BindDropDown();
                        BindGrid();
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

        public void BindDropDown()
        {
            try
            {
                ddlLineCapabilities.DataTextField = "Line";
                ddlLineCapabilities.DataValueField = "Line";
                ddlLineCapabilities.DataMember = "Line";
                ddlLineCapabilities.DataSource = objTestBusiness.getLinesDetail(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlLineCapabilities.DataBind();
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

        public void BindGrid()
        {
            try
            {
                GVLine.DataSource = objTestBusiness.get_Capabilities(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                GVLine.DataBind();
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

        public bool checkUploadforSelecteddate()
        {
            try
            {
                //Validate Uploaded Information
                DataSet ds = default(DataSet);
                ds = objTestBusiness.get_Upload_Data_For_Selected_Date(Convert.ToDateTime(DateTime.Now.ToShortDateString()), ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LabelStatus.Text = " Information Not Uploaded For " + DateTime.Now.ToShortDateString() + ":";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var _with1 = dr;
                        LabelStatus.Text = LabelStatus.Text + " " + _with1["Type"] + ",";
                    }
                    LabelStatus.Text = LabelStatus.Text + ". Contact the responsible to upload these files.";
                    LabelStatus.ForeColor = Color.Red;
                    ddlLine.Enabled = false;
                    chkAutoSave.Visible = false;
                    return false;
                }
                else
                {
                    ddlLine.Enabled = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                ddlLine.Enabled = false;
                HiddenField1.Value = "";
                LabelStatus.Text = "Error Validating Uploaded Information. " + ex.Message;
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
              
            return false;
            }
        }

        protected void txtFechaCaptura_TextChanged(object sender, System.EventArgs e)
        {
            txtFilter.Text = "";
            if (ddlLine.SelectedIndex != -1 & !string.IsNullOrEmpty(ddlLine.Text))
            {
                if (string.IsNullOrEmpty(this.HiddenField1.Value))
                {
                    this.btnSave.Visible = false;
                    this.chkAutoSave.Visible = false;
                    this.chkcopypaste.Checked = false;
                    this.chkcopypaste.Visible = false;
                    this.chkRestoreHeijunka.Visible = false;
                    this.chkRestoreHeijunka.Checked = false;
                    this.chkFinalVersion.Visible = false;
                    this.hlReporte.Visible = false;
                }
                else
                {
                    this.chkcopypaste.Visible = false;
                    this.btnSave.Visible = true;
                    this.chkAutoSave.Visible = true;
                    this.chkRestoreHeijunka.Visible = true;
                    this.chkFinalVersion.Visible = true;
                    this.hlReporte.Visible = true;
                }
            }
        }

        public void BindLine()
        {
            try
            {
                ddlLine.DataMember = "Line";
                ddlLine.DataTextField = "Line";
                ddlLine.DataValueField = "Line";
                ddlLine.DataSource = objTestBusiness.Get_Virtual_Kanban_Line(((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlLine.DataBind();
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

        protected void ddlLine_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtFilter.Text = "";
            this.chkcopypaste.Checked = false;
            this.chkAutoSave.Checked = true;
            this.chkRestoreHeijunka.Checked = false;
            if (ddlLine.SelectedIndex != -1 & !string.IsNullOrEmpty(ddlLine.Text))
            {
                if (string.IsNullOrEmpty(this.HiddenField1.Value))
                {
                    this.btnSave.Visible = false;
                    this.chkAutoSave.Visible = false;
                    this.chkRestoreHeijunka.Visible = false;
                    this.chkcopypaste.Checked = false;
                    this.chkcopypaste.Visible = false;
                    this.chkRestoreHeijunka.Checked = false;
                    this.chkFinalVersion.Visible = false;
                    this.hlReporte.Visible = false;
                }
                else
                {
                    this.btnSave.Visible = true;
                    this.chkAutoSave.Visible = true;
                    this.chkRestoreHeijunka.Visible = true;
                    this.chkFinalVersion.Visible = true;
                    this.chkcopypaste.Visible = true;
                    this.hlReporte.Visible = true;
                }
            }
        }

        protected void btnShow_Click(object sender, System.EventArgs e)
        {
            try
            {
                int Is_Checked = 0;
                //Arnesh Checkbox Checked/Unchecked
                DataSet Is_Checkedds = new DataSet();
                Is_Checkedds = objTestBusiness.get_Is_Checked(((UserLoginInfo)Session["UserLoginInfo"]).UserID, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                if ((Is_Checkedds != null))
                {
                    if (Is_Checkedds.Tables[0] == null || Is_Checkedds.Tables[0].Rows.Count == 0)
                    {
                        //is really empty
                        Is_Checked = 2;
                    }
                    else
                    {
                        //Have a dataTable with data.
                        Is_Checked = Convert.ToInt32(Is_Checkedds.Tables[0].Rows[0][0]);
                    }
                }
                if (Is_Checked == 0)
                {
                    chkAutoCal.Checked = false;
                }
                else
                {
                    if (Is_Checked == 1)
                    {
                        chkAutoCal.Checked = true;
                    }
                    else
                    {
                        objTestBusiness.Create_Is_Checked(((UserLoginInfo)Session["UserLoginInfo"]).UserID, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                    }
                }

                if (ddlLine.SelectedIndex != -1 & !string.IsNullOrEmpty(ddlLine.Text))
                {
                    if ((HiddenField1.Value != string.Empty))
                    {
                        this.chkcopypaste.Visible = false;
                        this.btnSave.Visible = true;
                        this.chkAutoSave.Visible = true;
                        this.chkAutoCal.Visible = true;
                        this.chkAutoSave.Visible = true;
                        this.chkRestoreHeijunka.Visible = true;
                        this.chkFinalVersion.Visible = true;
                        //If CheckUploadDataForSelectedDate() Then
                        //HyperLink1.NavigateUrl = HyperLink1.NavigateUrl.Remove(HyperLink1.NavigateUrl.IndexOf("Date=") + 5) + HiddenField1.Value;
                        if ((Convert.ToDateTime(DateTime.Now.ToShortDateString()) - Convert.ToDateTime(HiddenField1.Value)).TotalDays > 0 | checkUploadforSelecteddate())
                        {
                            bindUploadTable();
                            if (!(chkFinalVersion.Checked == true))
                            {
                                this.chkcopypaste.Checked = false;
                                this.chkcopypaste.Visible = true;
                            }
                        }
                        else
                        {
                            //this.divVKB.Visible = false;
                            this.gvVKB.Visible = false;
                            this.btnSave.Visible = false;
                            this.chkAutoSave.Visible = false;
                            this.chkcopypaste.Checked = false;
                            this.chkcopypaste.Visible = false;
                            this.chkRestoreHeijunka.Visible = false;
                            this.chkRestoreHeijunka.Checked = false;
                            this.chkFinalVersion.Visible = false;
                            this.hlReporte.Visible = false;
                        }
                    }
                    else
                    {
                        //this.divVKB.Visible = false;
                        this.gvVKB.Visible = false;
                        this.btnSave.Visible = false;
                        this.chkAutoSave.Visible = false;
                        this.chkcopypaste.Checked = false;
                        this.chkcopypaste.Visible = false;
                        this.chkRestoreHeijunka.Visible = false;
                        this.chkRestoreHeijunka.Checked = false;
                        this.chkFinalVersion.Visible = false;
                        this.hlReporte.Visible = false;
                        //Me.divReport.Visible = False
                        LabelStatus.Text = "Please select a valid VKB Date.";
                        LabelStatus.ForeColor = Color.Red;
                        this.txtFechaCaptura.Focus();
                    }
                }
                else
                {
                    //this.divVKB.Visible = false;
                    this.gvVKB.Visible = false;
                    this.btnSave.Visible = false;
                    this.chkAutoSave.Visible = false;
                    this.chkcopypaste.Checked = false;
                    this.chkcopypaste.Visible = false;
                    this.chkRestoreHeijunka.Visible = false;
                    this.chkRestoreHeijunka.Checked = false;
                    this.chkFinalVersion.Visible = false;
                    this.hlReporte.Visible = false;
                    //Me.divReport.Visible = False
                    LabelStatus.Text = "Please select a VKB Line.";
                    LabelStatus.ForeColor = Color.Red;
                    this.ddlLine.Focus();
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

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            lblNotSaved.Visible = false;
            if (gvVKB.Rows.Count > 0)
            {
                try
                {
                    int i = 0;
                    int count = 0;
                    TextBox txtMaterial_0 = default(TextBox);
                    string abc;
                    int totalColumns = 800;
                    string[] PN = new string[totalColumns];
                    string[] LOC = new string[totalColumns];
                    string[] Heijunka_Kanban_Pallets = new string[totalColumns];
                    string[] Heijunka_Board = new string[totalColumns + 1];
                    string[] Needed_ORANGE = new string[totalColumns];
                    string[] Needed_RED = new string[totalColumns];
                    string[] Needed_YELLOW = new string[totalColumns];
                    string[] Needed_GREEN = new string[totalColumns + 1];
                    string strField = null;
                    DataTable dtableCaptured = new DataTable();
                    DataRow dr = default(DataRow);
                    dtableCaptured.Columns.Add("idMaterial", Type.GetType("System.String"));
                    dtableCaptured.Columns.Add("Localization_Name", Type.GetType("System.String"));
                    dtableCaptured.Columns.Add("HeijunkaKanban_Pallets", Type.GetType("System.Decimal"));
                    dtableCaptured.Columns.Add("HeijunkaBoard_Pallets", Type.GetType("System.Decimal"));

                    //Get Captured Data On VKB
                    for (i = 0; i <= gvVKB.Rows.Count - 1; i++)
                    {
                        strField = gvVKB.Rows[i].Cells[0].Text;
                        if (strField == "PN")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    PN[count] = txtMaterial_0.Text;
                                }
                            }
                        }
                        else if (strField == "LOC")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    LOC[count] = txtMaterial_0.Text;
                                }
                            }
                        }
                        else if (strField == "Heijunka Kanban (Pallets)")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Heijunka_Kanban_Pallets[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Heijunka_Kanban_Pallets[count] = "-1";
                                }
                            }
                        }
                        else if (strField == "Planned Heijunka Board")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Heijunka_Board[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Heijunka_Board[count] = "-1";
                                }
                            }
                        }
                        else if (strField == "Kanban Needed for ORANGE")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Needed_ORANGE[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Needed_ORANGE[count] = "0";
                                }
                            }
                        }
                        else if (strField == "Kanban Needed for RED")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Needed_RED[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Needed_RED[count] = "0";
                                }
                            }
                        }
                        else if (strField == "Kanban Needed for YELLOW")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Needed_YELLOW[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Needed_YELLOW[count] = "0";
                                }
                            }
                        }
                        else if (strField == "Kanban Needed for GREEN")
                        {
                            for (count = 1; count <= totalColumns; count++)
                            {
                                txtMaterial_0 = (TextBox)gvVKB.Rows[i].Controls[2].FindControl("txtMaterial_" + count);
                                if (!string.IsNullOrEmpty(txtMaterial_0.Text))
                                {
                                    Needed_GREEN[count] = txtMaterial_0.Text;
                                }
                                else
                                {
                                    Needed_GREEN[count] = "0";
                                }
                            }
                        }
                    }

                    DataSet dsSpecialPermission = getSpecialPermissions();

                    for (count = 1; count <= totalColumns; count++)
                    {
                        if (Heijunka_Board[count] != "-1" | Heijunka_Kanban_Pallets[count] != "-1")
                        {
                            //Add to Data Table
                            dr = dtableCaptured.NewRow();
                            dr["idMaterial"] = PN[count];
                            dr["Localization_Name"] = LOC[count];
                            if (Convert.ToInt32(Heijunka_Board[count]) == -1)
                            {
                                Heijunka_Board[count] = "0";
                            }
                            if (Convert.ToInt32(Heijunka_Kanban_Pallets[count]) == -1)
                            {
                                Heijunka_Kanban_Pallets[count] = "0";
                            }

                            dr["HeijunkaKanban_Pallets"] = Convert.ToDecimal(Heijunka_Kanban_Pallets[count]);
                            if (Convert.ToDecimal(Heijunka_Board[count]) <= (Convert.ToDecimal(Needed_GREEN[count]) + Convert.ToDecimal(Needed_YELLOW[count]) + Convert.ToDecimal(Needed_RED[count]) + Convert.ToDecimal(Needed_ORANGE[count])))
                            {
                                dr["HeijunkaBoard_Pallets"] = Convert.ToDecimal(Heijunka_Board[count]);
                                dtableCaptured.Rows.Add(dr);
                            }
                            else
                            {
                                //'Validate if Exist an Special Permisssion
                                if (existSpecialPermission(dsSpecialPermission, PN[count], LOC[count]))
                                {
                                    dr["HeijunkaBoard_Pallets"] = Convert.ToDecimal(Heijunka_Board[count]);
                                    dtableCaptured.Rows.Add(dr);
                                }
                                else
                                {
                                    LabelStatus.Text = "The Heijunka Board entered for PN: " + PN[count] + " - " + LOC[count] + " is greater than the kanban signal, contact supply chain for special permission.";
                                    LabelStatus.ForeColor = Color.Red;
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + LabelStatus.Text + "');", true);
                                    dr["HeijunkaBoard_Pallets"] = 0;
                                    dtableCaptured.Rows.Add(dr);
                                    chkFinalVersion.Checked = false;
                                }
                            }
                        }
                    }
                    if (dtableCaptured.Rows.Count > 0)
                    {
                        bindUploadTable(dtableCaptured, (chkFinalVersion.Checked ? true : false));
                    }
                    else
                    {
                        bindUploadTable(null, (chkFinalVersion.Checked ? true : false));
                    }
                }
                catch (Exception ex)
                {
                    this.gvVKB.Visible = false;
                    this.btnSave.Visible = false;
                    this.chkAutoSave.Visible = false;
                    this.chkRestoreHeijunka.Visible = false;
                    this.chkRestoreHeijunka.Checked = false;
                    this.chkFinalVersion.Visible = false;
                    //Me.divReport.Visible = False
                    LabelStatus.Text = "Error Updating Virtual Kanban Board." + ex.Message;
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
        }

        protected void chkFinalVersion_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                chkFinalVersion.Checked = false;
                LabelStatus.Text = "Clear the Filter to save a Final VKB Version.";
                LabelStatus.ForeColor = Color.Red;
            }
        }

        protected void chkcopypaste_CheckedChanged(object sender, System.EventArgs e)
        {
            btnSave_Click(this, null);
        }

        protected void chkAutoCal_CheckedChanged(object sender, EventArgs e)
        {
            decimal Is_Checked = 0;
            try
            {
                if (chkAutoCal.Checked == false)
                {
                    Is_Checked = 0;
                }
                else
                {
                    Is_Checked = 1;
                }
                objTestBusiness.Update_Is_Checked(((UserLoginInfo)Session["UserLoginInfo"]).UserID, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, Is_Checked);
                btnShow_Click(this, null);
                btnSave_Click(this, null);
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

        protected void txtMaterialGridValues_TextChanged(object sender, System.EventArgs e)
        {
            btnSave_Click(this, null);
        }

        protected void imgCalender_Click(object sender, ImageClickEventArgs e)
        {
            //Calendar1.Visible = true;
            //imgCalender.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //HiddenField1.Value = Calendar1.SelectedDate.ToShortDateString();
            //Calendar1.Visible = false;
            //imgCalender.Visible = true;
        }

        public void bindUploadTable(DataTable dtableCaptureData = null, bool bolFinal = false)
        {
            LabelStatus.Text = "";
            dynamic ds = default(DataSet);
            dynamic dsVKBDetail = default(DataSet);
            DataSet dsVKBLastHeikunkaBoard = new DataSet();
            DataTable dtablePartNo = new DataTable();
            DataTable dtableUploads = new DataTable();
            DataTable dtableVKB = new DataTable();
            DataTable dtableNetwork = new DataTable();
            DataTable dtableKeyNet = new DataTable();
            DataRow drInventory = default(DataRow);
            int auxInt = 0;
            int count = 0;
            string strInsert = "";
            DataRow[] foundRows = null;
            DataRow[] fRowsNetwork = null;
            DataRow[] fRowsException = null;
            DataRow[] capturedRows = null;
            DataRow[] foundRowsLastHeikunkaBoard = null;
            int lc_Orangeitemscount = 0;
            int lc_Reditemscount = 0;
            int lc_Yellowitemscount = 0;
            int lc_Greenitemscount = 0;
            string HFCapability = null;

            dtablePartNo.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("idMaterial", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("PPVT", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("Yield", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("Localization_Name", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("Precent_Red", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Current_Backorder_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("BTO_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Special_Bids_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Customer_Order_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("High_Priority_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("InvOnDisCenter_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("InvInTransit_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("SAPKanbanTotal_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("HeijunkaKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TotalKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForCurrentBO_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForBTO_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForSpecialBid_Pallets", Type.GetType("System.Decimal"));

            dtablePartNo.Columns.Add("KanbanNeededForHighPriority_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForOrange_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForRed_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForYellow_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("KanbanNeededForGreen_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("MinKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TargetKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("MaxKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("ExcessKanban_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("HeijunkaBoard_Pallets", Type.GetType("System.Decimal"));

            //#Region Aditional Values Used on Formulas
            dtablePartNo.Columns.Add("PrimaryPriority", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TotalInTransit+Heijunka_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TotalInTransit+Heijunka_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TotalFG+Heijunka_Units", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("ActiveKanban", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Current_Backorder_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("BTO_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Special_Bids_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("High_Priority_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Temp_Kanban_Projected_Backorder_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Total_Backorder_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Total_Aditional_Pallets", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("RedKanban%", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("YellowKanban%", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("GreenKanban%", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("TotalInv%", Type.GetType("System.Decimal"));
            //#END Region Values Used on Formulas
            //#Region Aditional Values for Save Process
            //UDC,CV,Pallet_Qty
            dtablePartNo.Columns.Add("UDC", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("CV", Type.GetType("System.Decimal"));
            //Platform,Family,AverageDemnd,Pallet_Qty
            dtablePartNo.Columns.Add("Platform", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("Family", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("AverageDemand", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Pallet_Qty", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Recommended", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("RecommendedOrange", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("RecommendedRed", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("RecommendedYellow", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("RecommendedGreen", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("%MinOrangeP", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("%MinRedP", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("%MinYellowP", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("%MinGreenP", Type.GetType("System.Decimal"));
            dtablePartNo.Columns.Add("Type", Type.GetType("System.String"));
            dtablePartNo.Columns.Add("Recommendedis", Type.GetType("System.Decimal"));
            try
            {
                string Line = ddlLine.Text;
                string LeanApp = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DateTime Date = DateTime.Now;
                ds = objTestBusiness.get_VIRTUALKANBAN_VKBGLOBAL(Convert.ToDateTime(HiddenField1.Value), Line, LeanApp);
                int idVKB = 0;
                int idLine = 0;
                bool bolFinal_Version = bolFinal;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idVKB = ds.Tables[0].Rows[0]["idVKB"];
                    idLine = ds.Tables[0].Rows[0]["idLine"];
                    HFCapability = ds.Tables[0].Rows[0]["Capability"].ToString();
                    bolFinal_Version = ds.Tables[0].Rows[0]["Final_Version"];
                }

                //If already exist saved data
                if (idVKB != 0)
                {
                    dsVKBDetail = objTestBusiness.get_VIRTUALKANBAN_VKB_DETAIL_PARTNO(idVKB, LeanApp);
                    if (chkRestoreHeijunka.Checked == true)
                    {
                        //Get Last Heijunka Board Captured - To Use It as Heijunka Kanban
                        dsVKBLastHeikunkaBoard = objTestBusiness.get_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE(Date, Line, LeanApp);
                    }
                }
                else
                {
                    //Get Last Heijunka Board Captured - To Use It as Heijunka Kanban
                    dsVKBLastHeikunkaBoard = objTestBusiness.get_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE(Date, Line, LeanApp);
                }
                //Hidden Field Values
                int testVariable2 = idVKB;
                int testVariable3 = idLine;

                //#END Region Aditional Values for Save Process

                //If is FINAL VERSION cant be modified
                if (bolFinal_Version)
                {
                    DataRow[] foundFinalVersion = null;
                    count = 0;
                    foundFinalVersion = dsVKBDetail.Tables[0].Select(" (idLocalizationMaterial like '%" + txtFilter.Text + "%' OR idMaterial like '%" + txtFilter.Text + "%' OR Localization_Name like '%" + txtFilter.Text + "%')");
                    foreach (DataRow dr in foundFinalVersion)
                    {
                        drInventory = dtablePartNo.NewRow();
                        drInventory["idLocalizationMaterial"] = dr["idLocalizationMaterial"].ToString().ToUpper();
                        drInventory["idMaterial"] = dr["idMaterial"].ToString().ToUpper();
                        drInventory["PPVT"] = dr["PPVT"].ToString().ToUpper();
                        drInventory["Yield"] = dr["Yield"].ToString().ToUpper(); ;
                        drInventory["Localization_Name"] = dr["Localization_Name"].ToString().ToUpper(); ;
                        drInventory["UDC"] = dr["UDC"].ToString().ToUpper(); ;
                        drInventory["CV"] = dr["CV"].ToString().ToUpper(); ;
                        drInventory["Platform"] = dr["Platform"].ToString().ToUpper(); ;
                        drInventory["Family"] = dr["Family"].ToString().ToUpper(); ;
                        drInventory["AverageDemand"] = dr["AverageDemand"].ToString();
                        drInventory["Pallet_Qty"] = dr["Pallet_Qty"].ToString();
                        drInventory["Type"] = dr["Type"].ToString().ToUpper(); ;
                        drInventory["Current_Backorder_Units"] = dr["Customer_Backorder_Units"].ToString();
                        drInventory["BTO_Units"] = dr["BTO_Units"].ToString();
                        drInventory["Special_Bids_Units"] = dr["Special_Bids_Units"].ToString();
                        drInventory["Customer_Order_Units"] = dr["Projected_Backorder_Units"].ToString();
                        drInventory["High_Priority_Units"] = dr["High_Priority_Units"].ToString();
                        drInventory["InvOnDisCenter_Units"] = dr["InvOnDisCenter_Units"].ToString();
                        drInventory["InvInTransit_Units"] = dr["InvInTransit_Units"].ToString();
                        drInventory["SAPKanbanTotal_Pallets"] = dr["SAPKanbanTotal_Pallets"].ToString();
                        drInventory["HeijunkaKanban_Pallets"] = dr["HeijunkaKanban_Pallets"].ToString();
                        drInventory["TotalKanban_Pallets"] = dr["TotalKanban_Pallets"].ToString();
                        drInventory["KanbanNeededForCurrentBO_Pallets"] = dr["KanbanNeededForCustomerBO_Pallets"].ToString();
                        drInventory["KanbanNeededForBTO_Pallets"] = dr["KanbanNeededForBTO_Pallets"].ToString();
                        drInventory["KanbanNeededForSpecialBid_Pallets"] = dr["KanbanNeededForSpecialBid_Pallets"].ToString();
                        drInventory["KanbanNeededForHighPriority_Pallets"] = dr["KanbanNeededForProjectedBO_Pallets"].ToString();
                        drInventory["KanbanNeededForOrange_Pallets"] = dr["KanbanNeededForOrange_Pallets"].ToString();
                        drInventory["KanbanNeededForRed_Pallets"] = dr["KanbanNeededForRed_Pallets"].ToString();
                        drInventory["KanbanNeededForYellow_Pallets"] = dr["KanbanNeededForYellow_Pallets"].ToString();
                        drInventory["KanbanNeededForGreen_Pallets"] = dr["KanbanNeededForGreen_Pallets"].ToString();
                        drInventory["MinKanban_Pallets"] = dr["MinKanban_Pallets"].ToString();
                        drInventory["TargetKanban_Pallets"] = dr["TargetKanban_Pallets"].ToString();
                        drInventory["MaxKanban_Pallets"] = dr["MaxKanban_Pallets"].ToString();
                        drInventory["ExcessKanban_Pallets"] = dr["ExcessKanban_Pallets"].ToString();
                        drInventory["HeijunkaBoard_Pallets"] = dr["HeijunkaBoard_Pallets"].ToString();
                        drInventory["TotalInv%"] = dr["TotalInv%"].ToString();
                        drInventory["Precent_Red"] = dr["Percent_Red"].ToString();
                        drInventory["PrimaryPriority"] = dr["PrimaryPriority"].ToString();

                        //Added by Shovanjit for new Recomended production
                        drInventory["Recommendedis"] = dr["Remd_Pallet"].ToString();

                        drInventory["Recommended"] = 0;
                        drInventory["RecommendedOrange"] = 0;
                        drInventory["RecommendedGreen"] = 0;
                        drInventory["RecommendedYellow"] = 0;
                        drInventory["RecommendedRed"] = 0;

                        drInventory["%MinOrangeP"] = Convert.ToDecimal(drInventory["KanbanNeededForOrange_Pallets"]);
                        drInventory["%MinRedP"] = drInventory["KanbanNeededForRed_Pallets"];
                        drInventory["%MinYellowP"] = drInventory["KanbanNeededForYellow_Pallets"];
                        drInventory["%MinGreenP"] = drInventory["KanbanNeededForGreen_Pallets"];

                        lc_Orangeitemscount = lc_Orangeitemscount + Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]);
                        lc_Reditemscount = lc_Reditemscount + Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]);
                        lc_Yellowitemscount = lc_Yellowitemscount + Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]);
                        lc_Greenitemscount = lc_Greenitemscount + Convert.ToInt32(drInventory["KanbanNeededForGreen_Pallets"]);
                        dtablePartNo.Rows.Add(drInventory);
                        count = count + 1;
                    }

                }
                else
                {
                    //NOT A FINAL VERSION
                    //CALCULATE DATA
                    //Get Complete DTABLE
                    count = 0;
                    ds.Clear();
                    ds = objTestBusiness.get_VIRTUALKANBAN_IFNOT_FINALVERSION(LeanApp);
                    dtableUploads.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                    dtableUploads.Columns.Add("Inventory_DistributionCenters", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Inventory_InTransitTotal", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Demand_Customer_BackOrder", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Real_For_Demand_Customer_BackOrder", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Demand_BackOrder", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Real_For_Demand_BackOrder", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Demand_Special_Bid", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Real_For_Demand_Special_Bid", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Demand_BTO", Type.GetType("System.Decimal"));
                    dtableUploads.Columns.Add("Real_For_Demand_BTO", Type.GetType("System.Decimal"));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drInventory = dtableUploads.NewRow();
                        drInventory["idLocalizationMaterial"] = dr["idLocalizationMaterial"].ToString().ToUpper();
                        drInventory["Inventory_DistributionCenters"] = dr["Inventory_DistributionCenters"].ToString();
                        drInventory["Inventory_InTransitTotal"] = dr["Inventory_InTransitTotal"].ToString();
                        drInventory["Demand_Customer_BackOrder"] = dr["Demand_Customer_BackOrder"].ToString();
                        drInventory["Real_For_Demand_Customer_BackOrder"] = dr["Real_For_Demand_Customer_BackOrder"].ToString();
                        drInventory["Demand_BackOrder"] = dr["Demand_BackOrder"].ToString();
                        drInventory["Real_For_Demand_BackOrder"] = dr["Real_For_Demand_BackOrder"].ToString();
                        drInventory["Demand_Special_Bid"] = dr["Demand_Special_Bid"].ToString();
                        drInventory["Real_For_Demand_Special_Bid"] = dr["Real_For_Demand_Special_Bid"].ToString();
                        drInventory["Demand_BTO"] = dr["Demand_BTO"].ToString();
                        drInventory["Real_For_Demand_BTO"] = dr["Real_For_Demand_BTO"].ToString();
                        dtableUploads.Rows.Add(drInventory);
                        count = count + 1;
                    }


                    //DISTRIBUTION
                    //Get Network DTABLE
                    count = 0;
                    ds.Clear();
                    ds = objTestBusiness.get_VIRTUALKANBAN_DIST_NETWORK(LeanApp);
                    dtableNetwork.Columns.Add("idLocalization_Source", Type.GetType("System.String"));
                    dtableNetwork.Columns.Add("idLocalization_Dest", Type.GetType("System.String"));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drInventory = dtableNetwork.NewRow();
                        drInventory["idLocalization_Source"] = dr["idLocalization_Source"].ToString().ToUpper(); ;
                        drInventory["idLocalization_Dest"] = dr["idLocalization_Dest"].ToString().ToUpper(); ;
                        dtableNetwork.Rows.Add(drInventory);
                        count = count + 1;
                    }

                    //Get Exceptions DTABLE
                    count = 0;
                    ds.Clear();
                    ds = objTestBusiness.get_VIRTUALKANBAN_DIST_EXCEP(LeanApp);
                    dtableKeyNet.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                    dtableKeyNet.Columns.Add("idLocalizationMaterial_Excep", Type.GetType("System.String"));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drInventory = dtableKeyNet.NewRow();
                        drInventory["idLocalizationMaterial"] = dr["idLocalizationMaterial"].ToString().ToUpper();
                        drInventory["idLocalizationMaterial_Excep"] = dr["idLocalizationMaterial_Excep"].ToString().ToUpper();
                        dtableKeyNet.Rows.Add(drInventory);
                        count = count + 1;
                    }


                    //Fill the Data Set
                    count = 0;

                    //Fill the Grid View
                    string idtxtFilter = txtFilter.Text;
                    ds.Clear();
                    ds = objTestBusiness.get_VIRTUALKANBAN_FILLDATASET(Line, idtxtFilter, LeanApp); //call business class function
                    decimal decInvOnDisCenter_Units = default(decimal);
                    decimal decInvInTransit_Units = default(decimal);
                    decimal decCustomerBOUnits = default(decimal);
                    decimal decBTOUnits = default(decimal);
                    decimal decProjectedUnits = default(decimal);
                    decimal decInvJrzBalance = default(decimal);
                    decimal decInvJrzCustBOBalance = default(decimal);

                    bool bolUsesJuarezNode = false;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        drInventory = dtablePartNo.NewRow();
                        drInventory["idLocalizationMaterial"] = dr["idLocalizationMaterial"].ToString().ToUpper(); ;
                        drInventory["PPVT"] = dr["PPVT"].ToString().ToUpper();
                        drInventory["Yield"] = dr["Yield"].ToString().ToUpper();
                        drInventory["UDC"] = dr["UDC"].ToString().ToUpper();
                        drInventory["CV"] = Convert.ToDecimal(dr["CV"].ToString().ToUpper());
                        drInventory["Platform"] = dr["Platform"].ToString().ToUpper();
                        drInventory["Family"] = dr["Family"].ToString().ToUpper();
                        drInventory["AverageDemand"] = Convert.ToDecimal(dr["AverageDemand"].ToString().ToUpper());
                        drInventory["Pallet_Qty"] = Convert.ToDecimal(dr["Pallet_Qty"].ToString().ToUpper());
                        drInventory["Type"] = dr["Type"].ToString().ToUpper();
                        try
                        {
                            string testVariable4 = dr["Capability"].ToString().ToUpper();
                        }
                        catch (Exception ex)
                        {
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
                        }

                        //Get Saved Data 
                        try
                        {
                            if (idVKB != 0)
                            {
                                foundRows = (DataRow[])dsVKBDetail.Tables[0].Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                if (chkRestoreHeijunka.Checked == true)
                                {
                                    foundRowsLastHeikunkaBoard = dsVKBLastHeikunkaBoard.Tables[0].Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                }
                                else
                                {
                                    foundRowsLastHeikunkaBoard = null;
                                }
                            }
                            else
                            {
                                foundRows = null;
                                foundRowsLastHeikunkaBoard = dsVKBLastHeikunkaBoard.Tables[0].Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                            }
                        }
                        catch (Exception ex)
                        {
                            foundRows = null;
                            foundRowsLastHeikunkaBoard = null;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
                        
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

                        drInventory["idMaterial"] = dr["idMaterial"].ToString().ToUpper();

                        if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() == "DELL")
                        {
                            drInventory["Localization_Name"] = "DELL";
                        }
                        else
                        {
                            drInventory["Localization_Name"] = dr["Localization_Name"].ToString().ToUpper();
                        }

                        //Get Captured Data 
                        try
                        {
                            if (dtableCaptureData != null)
                            {
                                capturedRows = dtableCaptureData.Select("idMaterial='" + drInventory["idMaterial"] + "' AND Localization_Name='" + drInventory["Localization_Name"] + "'");
                            }
                            else
                            {
                                capturedRows = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            capturedRows = null;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
                        
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

                        //Validate if it uses JUAREZ NODE
                        bolUsesJuarezNode = false;
                        if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                        {
                            bolUsesJuarezNode = true;
                        }
                        else
                        {
                            fRowsException = dtableKeyNet.Select("(idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "' OR idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "') AND (idLocalizationMaterial like '5477%' OR idLocalizationMaterial_Excep like '5477%')");
                            if (fRowsException != null)
                            {
                                if (fRowsException.Length > 0)
                                {
                                    bolUsesJuarezNode = true;
                                }
                            }
                        }

                        //Obtain Balance FOR 544
                        if (bolUsesJuarezNode)
                        {
                            //Inv DC + Inv Transit - Dmd
                            //Validate if is an EMEA key or  AP key ---changes for EMEA -14-04-2014 
                            if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" |
                                dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") &
                                dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" &
                                drInventory["idLocalizationMaterial"].ToString().Length > 11 |
                                drInventory["idLocalizationMaterial"].ToString().Substring(0, 1) == "7" &
                                drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                            {
                                if (dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + (drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'")) == DBNull.Value)
                                {
                                    decInvJrzBalance = 0;
                                }
                                else
                                {
                                    decInvJrzBalance = Convert.ToDecimal(dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + (drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'")));
                                }
                                //decInvJrzBalance = (Convert.ToBoolean(dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + (drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + (drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"))));
                            }
                            else
                            {
                                if ((dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + drInventory["idMaterial"].ToString() + "'")) == DBNull.Value)
                                {
                                    decInvJrzBalance = 0;
                                }
                                else
                                {
                                    decInvJrzBalance = Convert.ToDecimal((dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + drInventory["idMaterial"].ToString() + "'")));
                                }
                                //decInvJrzBalance = (Convert.ToBoolean((dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + drInventory["idMaterial"].ToString() + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters) + SUM(Inventory_InTransitTotal) - SUM(Demand_BackOrder)", "idLocalizationMaterial='5477" + drInventory["idMaterial"].ToString() + "'")));
                            }

                            if (decInvJrzBalance < 0)
                            {
                                decInvJrzBalance = 0;
                            }
                        }

                        //SAP INVENTORY && SAP INVENTORY INTRANSIT Units
                        decInvOnDisCenter_Units = 0;
                        decInvInTransit_Units = 0;
                        //Inventory Network
                        if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")  //.Substring(0, 4)
                        {
                            //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                        }
                        else
                        {
                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                        }

                        if (fRowsNetwork != null)
                        {
                            foreach (DataRow dRowNetwork in fRowsNetwork)
                            {
                                if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                {
                                    if ((dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'")) == DBNull.Value)
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                    }
                                    else
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                    }

                                    if ((dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'")) == DBNull.Value)
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                    }
                                    else
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                    }
                                }
                                else
                                {
                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                    }
                                    else
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                    }

                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                    }
                                    else
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                    }

                                    //Validate if is an EMEA key --(modified)
                                    if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" || dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") && dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" && drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                    {
                                        if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                        {
                                            //Evaluate the same key with E sufix
                                            if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                            }
                                            else
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                            }

                                            if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + 0;
                                            }
                                            else
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                            }
                                        }
                                        else
                                        {
                                            //Evaluate the same key withOUT E sufix
                                            if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                            }
                                            else
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                            }

                                            if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + 0;
                                            }
                                            else
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                            }
                                        }
                                    }
                                    //Validate if is an AP key 
                                    if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                    {
                                        if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                        {
                                            //Evaluate the same key with P sufix
                                            if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                            }
                                            else
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                            }

                                            if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + 0;
                                            }
                                            else
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                            }
                                        }
                                        else
                                        {
                                            //Evaluate the same key withOUT P sufix
                                            if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                            }
                                            else
                                            {
                                                decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                            }

                                            if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + 0;
                                            }
                                            else
                                            {
                                                decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Inventory Exceptions
                        if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                        {
                            //5477 LOC is the Exception
                            fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                            if (fRowsException != null)
                            {
                                foreach (DataRow dRowException in fRowsException)
                                {
                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                    }
                                    else
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                    }

                                    if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                    }
                                    else
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                    }
                                    //#####
                                    //Network Of The Exception
                                    //Inventory Network
                                    if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL") //.Substring(0, 4)
                                    {
                                        //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                    }
                                    else
                                    {
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                    }
                                    if (fRowsNetwork != null)
                                    {
                                        foreach (DataRow dRowNetwork in fRowsNetwork)
                                        {
                                            if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                            {
                                                if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                {
                                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                    {
                                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                    }
                                                    else
                                                    {
                                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                    }

                                                    if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                    {
                                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                                    }
                                                    else
                                                    {
                                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                    }
                                                }
                                                else
                                                {
                                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                    {
                                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                    }
                                                    else
                                                    {
                                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                    }

                                                    if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                    {
                                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                                    }
                                                    else
                                                    {
                                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                    }
                                                    //Validate if is an EMEA key ---(modified)
                                                    if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                    {
                                                        if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                        {
                                                            //Validate if is a different key
                                                            if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                            {
                                                                //Evaluate the same key with E sufix
                                                                if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                }

                                                                if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Validate if is a different key
                                                            if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                            {
                                                                //Evaluate the same key withOUT E sufix
                                                                if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                }

                                                                if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                }

                                                            }
                                                        }
                                                    }
                                                    //Validate if is an AP key 
                                                    if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                    {
                                                        if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                        {
                                                            //Validate if is a different key
                                                            if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                            {
                                                                //Evaluate the same key with P sufix
                                                                if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                }

                                                                if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Validate if is a different key
                                                            if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                            {
                                                                //Evaluate the same key withOUT P sufix
                                                                if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                }

                                                                if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + 0;
                                                                }
                                                                else
                                                                {
                                                                    decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                            if (fRowsException != null)
                            {
                                foreach (DataRow dRowException in fRowsException)
                                {
                                    if (dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + 0;
                                    }
                                    else
                                    {
                                        decInvOnDisCenter_Units = decInvOnDisCenter_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_DistributionCenters)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                    }

                                    if (dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + 0;
                                    }
                                    else
                                    {
                                        decInvInTransit_Units = decInvInTransit_Units + Convert.ToInt32(dtableUploads.Compute("SUM(Inventory_InTransitTotal)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                    }
                                }
                            }
                        }

                        drInventory["InvOnDisCenter_Units"] = decInvOnDisCenter_Units;
                        drInventory["InvInTransit_Units"] = decInvInTransit_Units;

                        decCustomerBOUnits = 0;
                        //CUSTOMER BACKORDER UNITS and PALLETS
                        if (!bolUsesJuarezNode)
                        {
                            try
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"]) == 0)
                                {
                                    drInventory["Current_Backorder_Units"] = 0;
                                    drInventory["Current_Backorder_Pallets"] = 0;
                                }
                                else
                                {
                                    decCustomerBOUnits = 0;
                                    //Demand Network
                                    if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                                    {
                                        //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                    }
                                    else
                                    {
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                    }


                                    if (fRowsNetwork != null)
                                    {
                                        foreach (DataRow dRowNetwork in fRowsNetwork)
                                        {
                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                                }
                                            }
                                            else
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                }
                                                //Validate if is an EMEA key ---(modified)
                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                        {
                                                            //Evaluate the same key with E sufix
                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT E sufix
                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                                //Validate if is an AP key 
                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                        {
                                                            //Evaluate the same key with P sufix
                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT P sufix
                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    //Demand Exceptions
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                }
                                                //Network Of The Exception
                                                //Inventory Network
                                                if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                                {
                                                    //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                                }
                                                else
                                                {
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                                }
                                                if (fRowsNetwork != null)
                                                {
                                                    foreach (DataRow dRowNetwork in fRowsNetwork)
                                                    {
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                        {
                                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                            {
                                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                                }
                                                                //Validate if is an EMEA key ---(modified)
                                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                                        {
                                                                            //Evaluate the same key with E sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT E sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                //Validate if is an AP key 
                                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                        {
                                                                            //Evaluate the same key with P sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT P sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                                }
                                            }
                                        }
                                    }

                                    drInventory["Current_Backorder_Units"] = decCustomerBOUnits;
                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["Current_Backorder_Units"] = 0;
                            
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

                            //Substract On Hand Inventory - Distribution Centers
                            try
                            {
                                if (Convert.ToInt32(drInventory["Current_Backorder_Units"]) > 0)
                                {
                                    if ((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"])) < 0)
                                    {
                                        drInventory["Current_Backorder_Units"] = System.Math.Abs(Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"]));
                                    }
                                    else
                                    {
                                        drInventory["Current_Backorder_Units"] = 0;

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["Current_Backorder_Units"] = 0;
                                LabelStatus.Text = LabelStatus.Text + ex.Message;
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
                        else
                        {
                            //JUAREZ NODES - CUSTOMER BACKORDER UNITS and PALLETS
                            try
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"].ToString()) == 0)
                                {
                                    drInventory["Current_Backorder_Units"] = 0;
                                    drInventory["Current_Backorder_Pallets"] = 0;
                                }
                                else
                                {
                                    decCustomerBOUnits = 0;
                                    //Demand Network
                                    if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                                    {
                                        //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                    }
                                    else
                                    {
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                    }

                                    if (fRowsNetwork != null)
                                    {
                                        foreach (DataRow dRowNetwork in fRowsNetwork)
                                        {
                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                                }
                                            }
                                            else
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                }
                                                //Validate if is an EMEA key ---(modified)
                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "E" & (drInventory["idLocalizationMaterial"].ToString().Length > 11))
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                        {
                                                            //Evaluate the same key with E sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT E sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                                //Validate if is an AP key 
                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                        {
                                                            //Evaluate the same key with P sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT P sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Demand Exceptions
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                }
                                                //Network Of The Exception
                                                //Inventory Network
                                                if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                                {
                                                    //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                                }
                                                else
                                                {
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                                }
                                                if (fRowsNetwork != null)
                                                {
                                                    foreach (DataRow dRowNetwork in fRowsNetwork)
                                                    {
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                        {
                                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                            {
                                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                                }
                                                                //Validate if is an EMEA key ---(modified)
                                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(0, 1) != "E")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                                        {
                                                                            //Evaluate the same key with E sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT E sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                //Validate if is an AP key 
                                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                        {
                                                                            //Evaluate the same key with P sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToDecimal(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT P sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decCustomerBOUnits = decCustomerBOUnits + Convert.ToDecimal(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1)) + "'");
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + 0;
                                                }
                                                else
                                                {
                                                    decCustomerBOUnits = decCustomerBOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_Customer_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                                }
                                            }
                                        }
                                    }


                                    //Substract 5477 Inventory Balance
                                    if (decInvJrzBalance > 0 & decCustomerBOUnits > 0)
                                    {
                                        //Obtain the New Balance
                                        decInvJrzCustBOBalance = decInvJrzBalance - decCustomerBOUnits;
                                        if (decInvJrzCustBOBalance < 0)
                                        {
                                            decInvJrzCustBOBalance = 0;
                                        }
                                        //Substract the Inventory on JRZ DC
                                        decCustomerBOUnits = decCustomerBOUnits - decInvJrzBalance;
                                        if (decCustomerBOUnits > 0)
                                        {
                                            drInventory["Current_Backorder_Units"] = decCustomerBOUnits;
                                        }
                                        else
                                        {
                                            drInventory["Current_Backorder_Units"] = 0;
                                        }
                                    }
                                    else
                                    {
                                        drInventory["Current_Backorder_Units"] = decCustomerBOUnits;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["Current_Backorder_Units"] = 0;
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

                            //Inventory already substracted
                        }

                        //Pallets
                        //Feb 22 value set to ZERO
                        drInventory["Current_Backorder_Pallets"] = 0;

                        //BTO UNITS and PALLETS
                        if (!bolUsesJuarezNode)
                        {
                            decBTOUnits = 0;
                            try
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"].ToString()) > 0)
                                {
                                    drInventory["BTO_Units"] = 0;
                                }
                                else
                                {
                                    //Demand Network
                                    decBTOUnits = 0;
                                    if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                                    {
                                        //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                    }
                                    else
                                    {
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                    }
                                    if (fRowsNetwork != null)
                                    {
                                        foreach (DataRow dRowNetwork in fRowsNetwork)
                                        {
                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                                }
                                            }
                                            else
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                }
                                                //Validate if is an EMEA key ---(modified)
                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                        {
                                                            //Evaluate the same key with E sufix
                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT E sufix
                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                                //Validate if is an AP key 
                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                        {
                                                            //Evaluate the same key with P sufix
                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT P sufix
                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Demand Exceptions
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                }
                                                //Network Of The Exception
                                                //Inventory Network
                                                if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                                {
                                                    //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                                }
                                                else
                                                {
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                                }
                                                if (fRowsNetwork != null)
                                                {
                                                    foreach (DataRow dRowNetwork in fRowsNetwork)
                                                    {
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                        {
                                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                            {
                                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decBTOUnits = decBTOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decBTOUnits = decBTOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                                }
                                                                //Validate if is an EMEA key ---(modified)
                                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                                        {
                                                                            //Evaluate the same key with E sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT E sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                //Validate if is an AP key 
                                                                if (dr["idLocalizationMaterial"].ToString().Substring(0, 1) == "7")
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                        {
                                                                            //Evaluate the same key with P sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT P sufix
                                                                            if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                                }
                                            }
                                        }
                                    }

                                    drInventory["BTO_Units"] = decBTOUnits;
                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["BTO_Units"] = 0;
                                LabelStatus.Text = LabelStatus.Text + ex.Message;
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

                            //Substract On Hand Inventory - Distribution Centers
                            try
                            {
                                if (Convert.ToInt32(drInventory["BTO_Units"]) > 0)
                                {
                                    if (Convert.ToInt32(drInventory["InvOnDisCenter_Units"].ToString()) - Convert.ToInt32(drInventory["BTO_Units"].ToString()) < 0)
                                    {
                                        drInventory["BTO_Units"] = System.Math.Abs(Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) - Convert.ToInt32(drInventory["BTO_Units"]));
                                    }
                                    else
                                    {
                                        drInventory["BTO_Units"] = 0;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["BTO_Units"] = 0;
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
                        else
                        {
                            //JUAREZ NODE - BTO UNITS and PALLETS
                            decBTOUnits = 0;
                            try
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"].ToString()) > 0)
                                {
                                    drInventory["BTO_Units"] = 0;
                                }
                                else
                                {
                                    //Demand Network
                                    decBTOUnits = 0;
                                    if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                                    {
                                        //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                    }
                                    else
                                    {
                                        fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                    }


                                    if (fRowsNetwork != null)
                                    {
                                        foreach (DataRow dRowNetwork in fRowsNetwork)
                                        {
                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                                }
                                            }
                                            else
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                }
                                                //Validate if is an EMEA key ---(modified)
                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & (drInventory["idLocalizationMaterial"].ToString().Length) > 11)
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                        {
                                                            //Evaluate the same key with E sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT E sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                                //Validate if is an AP key 
                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                {
                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                        {
                                                            //Evaluate the same key with P sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Validate if is a different key
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                        {
                                                            //Evaluate the same key withOUT P sufix
                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                            {
                                                                decBTOUnits = decBTOUnits + 0;
                                                            }
                                                            else
                                                            {
                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Demand Exceptions
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                }
                                                //Network Of The Exception
                                                //Inventory Network
                                                if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                                {
                                                    //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                                }
                                                else
                                                {
                                                    fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                                }
                                                if (fRowsNetwork != null)
                                                {
                                                    foreach (DataRow dRowNetwork in fRowsNetwork)
                                                    {
                                                        if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                        {
                                                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                            {
                                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decBTOUnits = decBTOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                                {
                                                                    decBTOUnits = decBTOUnits + 0;
                                                                }
                                                                else
                                                                {
                                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                                }
                                                                //Validate if is an EMEA key ---(modified)
                                                                if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & (drInventory["idLocalizationMaterial"].ToString().Length) > 11)
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                                        {
                                                                            //Evaluate the same key with E sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT E sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                //Validate if is an AP key 
                                                                if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                                {
                                                                    if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"] != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                        {
                                                                            //Evaluate the same key with P sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                            }
                                                                            //decBTOUnits = decBTOUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'")));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //Validate if is a different key
                                                                        if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                        {
                                                                            //Evaluate the same key withOUT P sufix
                                                                            if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                            {
                                                                                decBTOUnits = decBTOUnits + 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                            }
                                                                            //decBTOUnits = decBTOUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'")));
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                        if (fRowsException != null)
                                        {
                                            foreach (DataRow dRowException in fRowsException)
                                            {
                                                if (dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                                {
                                                    decBTOUnits = decBTOUnits + 0;
                                                }
                                                else
                                                {
                                                    decBTOUnits = decBTOUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                                }
                                                //decBTOUnits = decBTOUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Real_For_Demand_BTO)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'")));
                                            }
                                        }
                                    }

                                    //Substract 5477 Inventory Balance
                                    if (decInvJrzBalance > 0 & decBTOUnits > 0)
                                    {
                                        //Substract the Inventory on JRZ DC
                                        decBTOUnits = decBTOUnits - decInvJrzBalance;
                                        if (decBTOUnits > 0)
                                        {
                                            drInventory["BTO_Units"] = decBTOUnits;
                                        }
                                        else
                                        {
                                            drInventory["BTO_Units"] = 0;
                                        }
                                    }
                                    else
                                    {
                                        drInventory["BTO_Units"] = decBTOUnits;
                                    }



                                }
                            }
                            catch (Exception ex)
                            {
                                drInventory["BTO_Units"] = 0;
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

                            //Inventory already substracted
                        }

                        clsGlobal objclsglobal = new clsGlobal();
                        //Pallets
                        try
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"].ToString()) > 0)
                            {
                                drInventory["BTO_Pallets"] = 0;
                            }
                            else
                            {
                                drInventory["BTO_Pallets"] = objclsglobal.roundup(Convert.ToDecimal(Convert.ToDecimal(drInventory["BTO_Units"]) / Convert.ToDecimal(dr["Pallet_Qty"])));
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["BTO_Pallets"] = 0;
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


                        //SPECIAL BIDS UNITS and PALLETS  ---(modified for EMEA)

                        if (dtableUploads.Compute("SUM(Demand_Special_Bid)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                        {
                            if (((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11 | drInventory["idMaterial"].ToString().Substring(0, 1) == "P"))
                            {
                                if (dtableUploads.Compute("SUM(Demand_Special_Bid)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, drInventory["idLocalizationMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                {
                                    drInventory["Special_Bids_Units"] = 0;
                                }
                                else
                                {
                                    drInventory["Special_Bids_Units"] = dtableUploads.Compute("SUM(Demand_Special_Bid)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, drInventory["idLocalizationMaterial"].ToString().Length - 1) + "'");
                                }
                            }
                            else
                            {
                                drInventory["Special_Bids_Units"] = 0;
                            }
                        }
                        else
                        {
                            drInventory["Special_Bids_Units"] = dtableUploads.Compute("SUM(Demand_Special_Bid)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                        }
                        // DO NOT Substract On Hand Inventory - Distribution Centers

                        //Pallets
                        try
                        {
                            drInventory["Special_Bids_Pallets"] = objclsglobal.roundup(Convert.ToDecimal(drInventory["Special_Bids_Units"].ToString() + drInventory["BTO_Units"].ToString()) / Convert.ToDecimal(dr["Pallet_Qty"].ToString())) - Convert.ToDecimal(drInventory["BTO_Pallets"]);
                        }
                        catch (Exception ex)
                        {
                            drInventory["Special_Bids_Pallets"] = 0;
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


                        //PROJECTED BACKORDER UNITS and PALLETS
                        if (!bolUsesJuarezNode)
                        {
                            //Demand Network
                            decProjectedUnits = 0;
                            if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                            {
                                //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                            }
                            else
                            {
                                fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                            }

                            if (fRowsNetwork != null)
                            {
                                foreach (DataRow dRowNetwork in fRowsNetwork)
                                {
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                        }
                                        //decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'")));
                                    }
                                    else
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                        }
                                        //decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'")));
                                        //Validate if is an EMEA key ---(modified)
                                        if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                        {
                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                {
                                                    //Evaluate the same key with E sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                    }
                                                    //decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'")));
                                                }
                                            }
                                            else
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                {
                                                    //Evaluate the same key withOUT E sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                    }
                                                    // decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'")));
                                                }
                                            }
                                        }
                                        //Validate if is an AP key 
                                        if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                        {
                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                {
                                                    //Evaluate the same key with P sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                    }
                                                    // decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'")));
                                                }
                                            }
                                            else
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                {
                                                    //Evaluate the same key withOUT P sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                    }
                                                    // decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'")));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //Demand Exceptions
                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                            {
                                fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                if (fRowsException != null)
                                {
                                    foreach (DataRow dRowException in fRowsException)
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                        }
                                        //decProjectedUnits = decProjectedUnits + (Convert.ToBoolean((dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"))) ? 0 : Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'")));
                                        //Network Of The Exception
                                        //Inventory Network
                                        if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                        {
                                            //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                        }
                                        else
                                        {
                                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                        }
                                        if (fRowsNetwork != null)
                                        {
                                            foreach (DataRow dRowNetwork in fRowsNetwork)
                                            {
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                {
                                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                    {
                                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                        {
                                                            decProjectedUnits = decProjectedUnits + 0;
                                                        }
                                                        else
                                                        {
                                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                        {
                                                            decProjectedUnits = decProjectedUnits + 0;
                                                        }
                                                        else
                                                        {
                                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                        }
                                                        //Validate if is an EMEA key ---(modified)
                                                        if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                        {
                                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"] + "E")
                                                                {
                                                                    //Evaluate the same key with E sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                {
                                                                    //Evaluate the same key withOUT E sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        //Validate if is an AP key 
                                                        if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                        {
                                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                {
                                                                    //Evaluate the same key with P sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P'"));
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                {
                                                                    //Evaluate the same key withOUT P sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                if (fRowsException != null)
                                {
                                    foreach (DataRow dRowException in fRowsException)
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                        }
                                    }
                                }
                            }
                            drInventory["Customer_Order_Units"] = decProjectedUnits;

                        }
                        else
                        {
                            //JUAREZ NODE - PROJECTED BACKORDER UNITS and PALLETS
                            //15 Feb 2012 - Oscar Request to Remove the Inventory Substract

                            //Demand Network
                            decProjectedUnits = 0;
                            if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["Brand"].ToString().ToUpper() != "DELL")
                            {
                                //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                            }
                            else
                            {
                                fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                            }
                            if (fRowsNetwork != null)
                            {
                                foreach (DataRow dRowNetwork in fRowsNetwork)
                                {
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'"));
                                        }
                                    }
                                    else
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                        }
                                        //Validate if is an EMEA key ---(modified)
                                        if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                        {
                                            if (drInventory["idMaterial"].ToString().Substring(0, 1) != "E")
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                {
                                                    //Evaluate the same key with E sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                {
                                                    //Evaluate the same key withOUT E sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                    }
                                                }
                                            }
                                        }
                                        //Validate if is an AP key 
                                        if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                        {
                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "P")
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                {
                                                    //Evaluate the same key with P sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Validate if is a different key
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                {
                                                    //Evaluate the same key withOUT P sufix
                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                    {
                                                        decProjectedUnits = decProjectedUnits + 0;
                                                    }
                                                    else
                                                    {
                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //Demand Exceptions
                            if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                            {
                                fRowsException = dtableKeyNet.Select("idLocalizationMaterial_Excep='" + drInventory["idLocalizationMaterial"] + "'");
                                if (fRowsException != null)
                                {
                                    foreach (DataRow dRowException in fRowsException)
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                        }
                                        //Network Of The Exception
                                        //Inventory Network
                                        if (dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) == "5001" & dr["Brand"].ToString().ToUpper() != "DELL")
                                        {
                                            //FOR Southeaven just take the inventory in Southeaven Except DELL Part No
                                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "' AND (idLocalization_Dest='5001' OR idLocalization_Dest='5002')");
                                        }
                                        else
                                        {
                                            fRowsNetwork = dtableNetwork.Select("idLocalization_Source='" + dRowException["idLocalizationMaterial"].ToString().Substring(0, 4) + "'");
                                        }
                                        if (fRowsNetwork != null)
                                        {
                                            foreach (DataRow dRowNetwork in fRowsNetwork)
                                            {
                                                if (dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() != dRowException["idLocalizationMaterial"].ToString())
                                                {
                                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "3005")
                                                    {
                                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'") == DBNull.Value)
                                                        {
                                                            decProjectedUnits = decProjectedUnits + 0;
                                                        }
                                                        else
                                                        {
                                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial"] + "'"));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'") == DBNull.Value)
                                                        {
                                                            decProjectedUnits = decProjectedUnits + 0;
                                                        }
                                                        else
                                                        {
                                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "'"));
                                                        }
                                                        //Validate if is an EMEA key ---(modified)
                                                        if ((dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "1" | dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 4) == "5477") & dr["idLocalizationMaterial"].ToString().ToUpper().Substring(dr["idLocalizationMaterial"].ToString().Length - 1, 1) == "E" & drInventory["idLocalizationMaterial"].ToString().Length > 11)
                                                        {
                                                            if (drInventory["idMaterial"].ToString().Substring(drInventory["idMaterial"].ToString().Length - 1, 1) != "E")
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "E")
                                                                {
                                                                    //Evaluate the same key with E sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "E'"));
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                {
                                                                    //Evaluate the same key withOUT E sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        //Validate if is an AP key 
                                                        if (dr["idLocalizationMaterial"].ToString().ToUpper().Substring(0, 1) == "7")
                                                        {
                                                            if (drInventory["idMaterial"].ToString().Substring(0, 1) != "P")
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"].ToString() + drInventory["idMaterial"].ToString() + "P")
                                                                {
                                                                    //Evaluate the same key with P sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"] + "P'"));
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Validate if is a different key
                                                                if (dRowException["idLocalizationMaterial"].ToString() != dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1))
                                                                {
                                                                    //Evaluate the same key withOUT P sufix
                                                                    if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'") == DBNull.Value)
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + 0;
                                                                    }
                                                                    else
                                                                    {
                                                                        decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowNetwork["idLocalization_Dest"] + drInventory["idMaterial"].ToString().Substring(0, drInventory["idMaterial"].ToString().Length - 1) + "'"));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                fRowsException = dtableKeyNet.Select("idLocalizationMaterial='" + drInventory["idLocalizationMaterial"] + "'");
                                if (fRowsException != null)
                                {
                                    foreach (DataRow dRowException in fRowsException)
                                    {
                                        if (dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'") == DBNull.Value)
                                        {
                                            decProjectedUnits = decProjectedUnits + 0;
                                        }
                                        else
                                        {
                                            decProjectedUnits = decProjectedUnits + Convert.ToInt32(dtableUploads.Compute("SUM(Demand_BackOrder)", "idLocalizationMaterial='" + dRowException["idLocalizationMaterial_Excep"] + "'"));
                                        }
                                    }
                                }
                            }

                            //Substract 5477 Inventory Balance
                            //15 Feb 2012 - Oscar Request to Remove the Inventory Substract
                            drInventory["Customer_Order_Units"] = decProjectedUnits;
                        }

                        try
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"].ToString()) == 0)
                            {
                                drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = objclsglobal.roundup(Convert.ToDecimal(Convert.ToDecimal(drInventory["Customer_Order_Units"]) - Convert.ToDecimal(drInventory["BTO_Units"])) / Convert.ToDecimal(dr["Pallet_Qty"].ToString()));
                            }
                            else
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"].ToString()) == 1)
                                {
                                    if (Convert.ToInt32(drInventory["Customer_Order_Units"]) > Convert.ToInt32(dr["Pallet_Qty"].ToString()))
                                    {
                                        drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = objclsglobal.roundup((Convert.ToDecimal(drInventory["Customer_Order_Units"]) / Convert.ToDecimal(dr["Pallet_Qty"])) - Convert.ToDecimal(dr["Max_Pallet"]));
                                        if (Convert.ToInt32(drInventory["Temp_Kanban_Projected_Backorder_Pallets"]) < 0)
                                        {
                                            drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = 0;
                                        }
                                    }
                                    else
                                    {
                                        drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = 0;
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(drInventory["Customer_Order_Units"]) >= Convert.ToInt32(drInventory["Special_Bids_Units"]))
                                    {
                                        auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                    }
                                    else
                                    {
                                        auxInt = 0;
                                    }
                                    if ((Convert.ToInt32(drInventory["Customer_Order_Units"]) + auxInt) < (Convert.ToInt32(dr["Max_Pallet"]) * Convert.ToInt32(dr["Pallet_Qty"])))
                                    {
                                        drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(drInventory["Customer_Order_Units"]) >= Convert.ToInt32(drInventory["Special_Bids_Units"]))
                                        {
                                            auxInt = Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["Special_Bids_Units"]) - Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Current_Backorder_Pallets"]);
                                        }
                                        else
                                        {
                                            auxInt = Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Current_Backorder_Pallets"]);
                                        }
                                        drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = objclsglobal.roundup(auxInt / Convert.ToInt32(dr["Pallet_Qty"]));
                                        if (Convert.ToInt32(drInventory["Temp_Kanban_Projected_Backorder_Pallets"]) < 0)
                                        {
                                            drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = 0;
                                        }
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            drInventory["Temp_Kanban_Projected_Backorder_Pallets"] = 0;
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

                        //#### REGION 2 - KANBAN PALLETS ####
                        //SAP KANBAN TOTAL (Pallets)

                        try
                        {
                            // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalFG+Heijunka_Units is Juarez Balance :::  [ drInventory("InvOnDisCenter_Units") + drInventory("InvInTransit_Units")  -> decInvJrzBalance
                            // 01/Junio - FEDEX no estaba pidiendo la cantidad correcta para pallets SAP Kanban Pallet y le removi la opcion de juarez node!!
                            //If Not bolUsesJuarezNode Then
                            drInventory["SAPKanbanTotal_Pallets"] = (((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"])) / Convert.ToInt32(dr["Pallet_Qty"]))) < 0.5 ? 0 : objclsglobal.roundup(((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"])) / Convert.ToInt32(dr["Pallet_Qty"])));

                        }
                        catch (Exception ex)
                        {
                            drInventory["SAPKanbanTotal_Pallets"] = 0;
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

                        //Captured HEIJUNKA KANBAN (Pallets)
                        if (capturedRows != null & chkRestoreHeijunka.Checked == false)
                        {
                            if (capturedRows.Length > 0)
                            {
                                drInventory["HeijunkaKanban_Pallets"] = capturedRows[0]["HeijunkaKanban_Pallets"];
                            }
                            else
                            {
                                drInventory["HeijunkaKanban_Pallets"] = 0;
                            }
                        }
                        else if (foundRows != null & chkRestoreHeijunka.Checked == false)
                        {
                            if (foundRows.Length > 0)
                            {
                                drInventory["HeijunkaKanban_Pallets"] = Convert.ToInt32(foundRows[0]["HeijunkaKanban_Pallets"]);
                            }
                            else
                            {
                                drInventory["HeijunkaKanban_Pallets"] = 0;
                            }
                        }
                        else if (foundRows != null & chkRestoreHeijunka.Checked == true)
                        {
                            if (foundRowsLastHeikunkaBoard.Length > 0)
                            {
                                drInventory["HeijunkaKanban_Pallets"] = foundRowsLastHeikunkaBoard[0]["HeijunkaBoard_Pallets"];
                            }
                            else
                            {
                                drInventory["HeijunkaKanban_Pallets"] = 0;
                            }
                        }
                        else if (foundRowsLastHeikunkaBoard != null)
                        {
                            if (foundRowsLastHeikunkaBoard.Length > 0)
                            {
                                drInventory["HeijunkaKanban_Pallets"] = foundRowsLastHeikunkaBoard[0]["HeijunkaBoard_Pallets"];
                            }
                            else
                            {
                                drInventory["HeijunkaKanban_Pallets"] = 0;
                            }
                        }
                        else
                        {
                            drInventory["HeijunkaKanban_Pallets"] = 0;
                        }

                        //TOTAL KANBAN (Pallets)
                        drInventory["TotalKanban_Pallets"] = Convert.ToInt32(drInventory["SAPKanbanTotal_Pallets"]) + Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]);


                        //VALUES FOR FORMULAS
                        try
                        {
                            // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalInTransit+Heijunka_Units is Juarez Balance
                            if (!bolUsesJuarezNode)
                            {
                                drInventory["TotalInTransit+Heijunka_Units"] = Convert.ToInt32(drInventory["InvInTransit_Units"]) + (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]));
                            }
                            else
                            {
                                drInventory["TotalInTransit+Heijunka_Units"] = decInvJrzBalance + (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]));
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["TotalInTransit+Heijunka_Units"] = 0;
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
                        try
                        {
                            // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalInTransit+Heijunka_Units is Juarez Balance
                            if (!bolUsesJuarezNode)
                            {
                                drInventory["TotalInTransit+Heijunka_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["InvInTransit_Units"]) / Convert.ToInt32(dr["Pallet_Qty"]))) + Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]);
                            }
                            else
                            {
                                drInventory["TotalInTransit+Heijunka_Pallets"] = objclsglobal.roundup((decInvJrzBalance / Convert.ToInt32(dr["Pallet_Qty"]))) + Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]);
                            }

                        }
                        catch (Exception ex)
                        {
                            drInventory["TotalInTransit+Heijunka_Pallets"] = 0;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
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
                        try
                        {
                            // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalFG+Heijunka_Units is Juarez Balance
                            // 14.06.2012 Se modifico High Priority Values

                            if (bolUsesJuarezNode & drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                            {
                                drInventory["TotalFG+Heijunka_Units"] = decInvJrzBalance + (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]));
                            }
                            else
                            {
                                drInventory["TotalFG+Heijunka_Units"] = Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) + (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]));
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["TotalFG+Heijunka_Units"] = 0;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
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

                        //ACTIVE KANBAN
                        drInventory["ActiveKanban"] = Convert.ToInt32(dr["Max_Pallet"]) - Convert.ToInt32(drInventory["TotalKanban_Pallets"]);



                        //A3 - HIGH PRIORITY UNITS

                        if (Convert.ToInt32(drInventory["Customer_Order_Units"]) >= Convert.ToInt32(drInventory["Special_Bids_Units"]))
                        {
                            if ((Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Special_Bids_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"])) < 0)
                            {
                                drInventory["High_Priority_Units"] = 0;
                            }
                            else
                            {
                                drInventory["High_Priority_Units"] = (Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Special_Bids_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"]));

                                if (Convert.ToInt32(drInventory["High_Priority_Units"]) > (decInvOnDisCenter_Units + decInvInTransit_Units))
                                {
                                }
                            }
                        }
                        else
                        {
                            if ((Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"])) < 0)
                            {
                                drInventory["High_Priority_Units"] = 0;
                            }
                            else
                            {
                                drInventory["High_Priority_Units"] = Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Current_Backorder_Units"]);
                            }
                        }

                        //Pallets
                        try
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) == 0)
                            {
                                drInventory["High_Priority_Pallets"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"]) == 1)
                                {
                                    if (Convert.ToInt32(drInventory["Current_Backorder_Units"]) < Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]))
                                    {
                                        drInventory["High_Priority_Pallets"] = objclsglobal.roundup(((Convert.ToInt32(drInventory["High_Priority_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"]) + 0) / Convert.ToInt32(dr["Pallet_Qty"]))) - Convert.ToInt32(drInventory["Current_Backorder_Pallets"]) - Convert.ToInt32(drInventory["Special_Bids_Pallets"]);
                                    }
                                    else
                                    {
                                        drInventory["High_Priority_Pallets"] = objclsglobal.roundup(((Convert.ToInt32(drInventory["High_Priority_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"]) + (Convert.ToInt32(drInventory["Current_Backorder_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]))) / Convert.ToInt32(dr["Pallet_Qty"]))) - Convert.ToInt32(drInventory["Current_Backorder_Pallets"]) - Convert.ToInt32(drInventory["Special_Bids_Pallets"]);
                                    }
                                }
                                else
                                {
                                    drInventory["High_Priority_Pallets"] = objclsglobal.roundup(((Convert.ToInt32(drInventory["High_Priority_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Current_Backorder_Units"])) / Convert.ToInt32(dr["Pallet_Qty"]))) - Convert.ToInt32(drInventory["Current_Backorder_Pallets"]) - Convert.ToInt32(drInventory["Special_Bids_Pallets"]);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["High_Priority_Pallets"] = 0;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
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

                        //TOTAL BACKORDER PALLETS
                        drInventory["Total_Backorder_Pallets"] = Convert.ToInt32(drInventory["Temp_Kanban_Projected_Backorder_Pallets"]) + Convert.ToInt32(drInventory["Current_Backorder_Pallets"]);

                        //TOTAL ADITIONAL PALLETS
                        drInventory["Total_Aditional_Pallets"] = Convert.ToInt32(drInventory["Current_Backorder_Pallets"]) + Convert.ToInt32(drInventory["BTO_Pallets"]) + Convert.ToInt32(drInventory["Special_Bids_Pallets"]) + Convert.ToInt32(drInventory["Temp_Kanban_Projected_Backorder_Pallets"]);

                        //% RED, YELLOW & GREEN KANBAN   
                        try
                        {
                            drInventory["RedKanban%"] = Convert.ToInt32(dr["Min_Pallet"]) / Convert.ToInt32(dr["Max_Pallet"]);
                        }
                        catch (Exception ex)
                        {
                            drInventory["RedKanban%"] = 0;
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

                        if (Convert.ToInt32(dr["Target_Pallet"]) == Convert.ToInt32(dr["Max_Pallet"]))
                        {
                            drInventory["YellowKanban%"] = 1 - Convert.ToInt32(drInventory["RedKanban%"]);
                        }
                        else
                        {
                            try
                            {
                                drInventory["YellowKanban%"] = (Convert.ToInt32(dr["Target_Pallet"]) - Convert.ToInt32(dr["Min_Pallet"])) / Convert.ToInt32(dr["Max_Pallet"]);
                            }
                            catch (Exception ex)
                            {
                                drInventory["YellowKanban%"] = 0;
                                LabelStatus.Text = LabelStatus.Text + ex.Message;
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

                        drInventory["GreenKanban%"] = 1 - Convert.ToInt32(drInventory["RedKanban%"]) - Convert.ToInt32(drInventory["YellowKanban%"]);

                        //#### REGION 3 - KANBAN NEEDED ####
                        //ORANGE
                        // FOR CUSTOMER BACKORDER
                        //Feb 22 value set to ZERO
                        drInventory["KanbanNeededForCurrentBO_Pallets"] = 0;

                        //ORANGE
                        // FOR BTO
                        // FOR BTO  - 7 DIC
                        if (Convert.ToInt32(drInventory["BTO_Pallets"]) == 0)
                        {
                            drInventory["KanbanNeededForBTO_Pallets"] = 0;
                        }
                        else
                        {
                            if (bolUsesJuarezNode)
                            {
                                try
                                {
                                    //Change Requsted By Federico Perez and confirmed by Oscar Maldonado
                                    //04/12/12
                                    drInventory["KanbanNeededForBTO_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["BTO_Units"]) - (Convert.ToInt32(drInventory["TotalInTransit+Heijunka_Units"]))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                    if (Convert.ToInt32(drInventory["KanbanNeededForBTO_Pallets"]) < 0)
                                    {
                                        drInventory["KanbanNeededForBTO_Pallets"] = 0;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    drInventory["KanbanNeededForBTO_Pallets"] = 0;
                                    LabelStatus.Text = LabelStatus.Text + ex.Message;
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
                            else
                            {
                                //Must be TotalInTransit+Heijunka_Pallets
                                //DC alreay substracted
                                if ((Convert.ToInt32(drInventory["TotalInTransit+Heijunka_Units"])) > Convert.ToInt32(drInventory["BTO_Units"]))
                                {
                                    drInventory["KanbanNeededForBTO_Pallets"] = 0;
                                }
                                else
                                {
                                    try
                                    {
                                        //Correccion de Resta Units vs Pallets
                                        drInventory["KanbanNeededForBTO_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["BTO_Units"]) - (Convert.ToInt32(drInventory["TotalInTransit+Heijunka_Units"]))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                    }
                                    catch (Exception ex)
                                    {
                                        drInventory["KanbanNeededForBTO_Pallets"] = 0;
                                        LabelStatus.Text = LabelStatus.Text + ex.Message;
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
                            }
                        }


                        //ORANGE
                        // A3 - FOR SPECIAL BIDS
                        try
                        {
                            if (Convert.ToInt32(drInventory["Special_Bids_Units"]) <= 0)
                            {
                                drInventory["KanbanNeededForSpecialBid_Pallets"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                {
                                    auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                }
                                else
                                {
                                    auxInt = 0;
                                }
                                if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) >= Convert.ToInt32(drInventory["Customer_Order_Units"]) + auxInt)
                                {
                                    drInventory["KanbanNeededForSpecialBid_Pallets"] = 0;
                                }
                                else
                                {
                                    if ((Convert.ToInt32(drInventory["Current_Backorder_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"])) <= Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]))
                                    {
                                        drInventory["KanbanNeededForSpecialBid_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        if (((Convert.ToInt32(drInventory["Current_Backorder_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"])) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"])) >= Convert.ToInt32(drInventory["Special_Bids_Units"]))
                                        {
                                            drInventory["KanbanNeededForSpecialBid_Pallets"] = drInventory["Special_Bids_Pallets"];
                                        }
                                        else
                                        {
                                            drInventory["KanbanNeededForSpecialBid_Pallets"] = objclsglobal.roundup(((Convert.ToInt32(drInventory["Current_Backorder_Units"]) + Convert.ToInt32(drInventory["Special_Bids_Units"])) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"])) / Convert.ToInt32(dr["Pallet_Qty"])) - Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["KanbanNeededForSpecialBid_Pallets"] = 0;
                            LabelStatus.Text = LabelStatus.Text + ex.Message;
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

                        //ORANGE
                        //A3 - FOR HIGH PRIORITY
                        try
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) == 0)
                            {
                                drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(dr["Max_Pallet"]) == 1)
                                {
                                    if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                    {
                                        auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                    }
                                    else
                                    {
                                        auxInt = 0;
                                    }
                                    if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) >= Convert.ToInt32(drInventory["Customer_Order_Units"]) + auxInt)
                                    {
                                        drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                        {
                                            if ((Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))))
                                            {
                                                auxInt = 0;
                                            }
                                            else
                                            {
                                                auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])));
                                            }
                                            drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup(auxInt / Convert.ToInt32(dr["Pallet_Qty"]));
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > 0)
                                            {
                                                if ((Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))))
                                                {
                                                    auxInt = 0;
                                                }
                                                else
                                                {
                                                    auxInt = Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])));
                                                }
                                                drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup(auxInt / Convert.ToInt32(dr["Pallet_Qty"]));
                                            }
                                            else
                                            {
                                                if ((Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"])))))
                                                {
                                                    auxInt = 0;
                                                }
                                                else
                                                {
                                                    auxInt = Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"])));
                                                }
                                                drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup(auxInt / Convert.ToInt32(dr["Pallet_Qty"]));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                    {
                                        auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                    }
                                    else
                                    {
                                        auxInt = 0;
                                    }
                                    //CAMBIO'
                                    if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) > (Convert.ToInt32(drInventory["Customer_Order_Units"]) + auxInt))
                                    {
                                        drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                        {
                                            if ((Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))))
                                            {
                                                drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                                            }
                                            else
                                            {
                                                // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalFG+Heijunka_Units is Juarez Balance :::  [ drInventory("InvOnDisCenter_Units") + drInventory("InvInTransit_Units")  -> decInvJrzBalance

                                                if (!bolUsesJuarezNode)
                                                {
                                                    drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Customer_Order_Units"]) - (Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"])) - Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"]);
                                                }
                                                else
                                                {
                                                    drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Special_Bids_Units"]) + Convert.ToInt32(drInventory["Customer_Order_Units"]) - (decInvJrzBalance - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"])));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > 0)
                                            {
                                                if ((Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))))
                                                {
                                                    drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                                                }
                                                else
                                                {
                                                    if (!bolUsesJuarezNode)
                                                    {
                                                        drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Customer_Order_Units"]) - (Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"])) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                                    }
                                                    else
                                                    {
                                                        drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Customer_Order_Units"]) - (decInvJrzBalance) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if ((Convert.ToInt32(drInventory["Customer_Order_Units"])) < (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) + (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"])))))
                                                {
                                                    drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
                                                }
                                                else
                                                {
                                                    // 09 May - Oscar/Federico/Emmanuel Meeting - Ensure TotalFG+Heijunka_Units is Juarez Balance
                                                    // Lolo Updated
                                                    if (!bolUsesJuarezNode)
                                                    {
                                                        drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Customer_Order_Units"]) - (Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"])) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                                    }
                                                    else
                                                    {
                                                        drInventory["KanbanNeededForHighPriority_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Customer_Order_Units"]) - (decInvJrzBalance) - (Convert.ToInt32(dr["Pallet_Qty"]) * (Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"])))) / Convert.ToInt32(dr["Pallet_Qty"]));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["KanbanNeededForHighPriority_Pallets"] = 0;
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

                        //ORANGE
                        //A3 - FOR PROJECTED BACKORER
                        //!!! DELETE !!!

                        // NEEDED FOR ORANGE
                        drInventory["KanbanNeededForOrange_Pallets"] = Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForBTO_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]);

                        //A3 - NEEDED FOR RED
                        if (Convert.ToInt32(dr["Max_Pallet"]) == 0)
                        {
                            drInventory["KanbanNeededForRed_Pallets"] = 0;
                        }
                        else
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) == 1)
                            {
                                if (Convert.ToInt32(drInventory["Customer_Order_Units"]) <= Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]))
                                {
                                    if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                    {
                                        auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                    }
                                    else
                                    {
                                        auxInt = 0;
                                    }
                                    if ((Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]) - auxInt + (Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]))) >= (Convert.ToInt32(dr["Pallet_Qty"]) / 2))
                                    {
                                        drInventory["KanbanNeededForRed_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        drInventory["KanbanNeededForRed_Pallets"] = 1;
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                    {
                                        auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                    }
                                    else
                                    {
                                        auxInt = 0;
                                    }
                                    if (Convert.ToInt32(drInventory["Customer_Order_Units"]) <= Convert.ToInt32(dr["Pallet_Qty"]))
                                    {
                                        if ((Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]) - auxInt + (Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]))) >= (Convert.ToInt32(dr["Pallet_Qty"]) / 2))
                                        {
                                            drInventory["KanbanNeededForRed_Pallets"] = 0;
                                        }
                                        else
                                        {
                                            drInventory["KanbanNeededForRed_Pallets"] = 1;
                                        }
                                    }
                                    else
                                    {
                                        if ((Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]) - auxInt + (Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"]))) > (Convert.ToInt32(dr["Pallet_Qty"]) / 2))
                                        {
                                            drInventory["KanbanNeededForRed_Pallets"] = 0;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(drInventory["Special_Bids_Units"]) > Convert.ToInt32(drInventory["Customer_Order_Units"]))
                                            {
                                                auxInt = Convert.ToInt32(drInventory["Special_Bids_Units"]);
                                            }
                                            else
                                            {
                                                auxInt = 0;
                                            }
                                            drInventory["KanbanNeededForRed_Pallets"] = objclsglobal.roundup((Convert.ToInt32(drInventory["Customer_Order_Units"]) + auxInt - Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - (Convert.ToInt32(dr["Pallet_Qty"]) * Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]))) / Convert.ToInt32(dr["Pallet_Qty"])) + 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]) > Convert.ToInt32(dr["Min_Pallet"]))
                                {
                                    drInventory["KanbanNeededForRed_Pallets"] = 0;
                                }
                                else
                                {
                                    if ((Convert.ToInt32(dr["Min_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"])) < Convert.ToInt32(drInventory["TotalKanban_Pallets"]))
                                    {
                                        drInventory["KanbanNeededForRed_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        drInventory["KanbanNeededForRed_Pallets"] = Convert.ToInt32(dr["Min_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(drInventory["TotalKanban_Pallets"]);
                                    }
                                }
                            }
                        }

                        //Red formula
                        if (!(Convert.ToInt32(dr["Max_Pallet"]) == 0 | Convert.ToInt32(dr["Max_Pallet"]) == 1) & (Convert.ToInt32(drInventory["Customer_Order_Units"]) > ((Convert.ToInt32(dr["Max_Pallet"]) - Convert.ToInt32(dr["Min_Pallet"])) * Convert.ToInt32(dr["Pallet_Qty"]))) & ((objclsglobal.roundup(Convert.ToInt32(dr["Min_Pallet"]) * (Convert.ToInt32(dr["Pallet_Qty"])) - (Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]))) / (Convert.ToInt32(dr["Pallet_Qty"]))) - Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"])) > 0)
                        {
                            drInventory["KanbanNeededForRed_Pallets"] = Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) + Math.Abs(objclsglobal.roundup(Convert.ToInt32(dr["Min_Pallet"]) * (Convert.ToInt32(dr["Pallet_Qty"]) - (Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]))) / (Convert.ToInt32(dr["Pallet_Qty"]))) - Convert.ToInt32(drInventory["HeijunkaKanban_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"]));
                        }

                        // A3 - NEEDED FOR YELLOW      LOLO
                        if (chkAutoCal.Checked == false)
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) < 2)
                            {
                                drInventory["KanbanNeededForYellow_Pallets"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]) > Convert.ToInt32(dr["Target_Pallet"]))
                                {
                                    drInventory["KanbanNeededForYellow_Pallets"] = 0;
                                }
                                else
                                {
                                    if ((Convert.ToInt32(dr["Target_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"])) < Convert.ToInt32(drInventory["TotalKanban_Pallets"]))
                                    {
                                        drInventory["KanbanNeededForYellow_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        drInventory["KanbanNeededForYellow_Pallets"] = Convert.ToInt32(dr["Target_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) - Convert.ToInt32(drInventory["TotalKanban_Pallets"]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Include open sales order calculations for recommended yellow
                            if ((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) <= 0)
                            {
                                drInventory["KanbanNeededForYellow_Pallets"] = Convert.ToInt32(dr["Target_Pallet"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]);
                            }
                            else
                            {
                                if ((Convert.ToInt32(dr["Target_Pallet"]) - Math.Abs(objclsglobal.roundup((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) / (Convert.ToInt32(dr["Pallet_Qty"]))))) > 0)
                                {
                                    drInventory["KanbanNeededForYellow_Pallets"] = Convert.ToInt32(dr["Target_Pallet"]) - Math.Abs(objclsglobal.roundup((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) / (Convert.ToInt32(dr["Pallet_Qty"]))));
                                }
                                else
                                {
                                    drInventory["KanbanNeededForYellow_Pallets"] = 0;
                                }
                            }
                        }

                        //A3 - NEEDED FOR GREEN
                        if (chkAutoCal.Checked == false)
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) < 2)
                            {
                                drInventory["KanbanNeededForGreen_Pallets"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]) > Convert.ToInt32(dr["Max_Pallet"]))
                                {
                                    drInventory["KanbanNeededForGreen_Pallets"] = 0;
                                }
                                else
                                {
                                    if ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"])) < Convert.ToInt32(drInventory["TotalKanban_Pallets"]))
                                    {
                                        drInventory["KanbanNeededForGreen_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        drInventory["KanbanNeededForGreen_Pallets"] = Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) - Convert.ToInt32(drInventory["TotalKanban_Pallets"]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) <= 0)
                            {
                                drInventory["KanbanNeededForGreen_Pallets"] = Convert.ToInt32(dr["Max_Pallet"]) - Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) - Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]);
                            }
                            else
                            {
                                if ((Convert.ToInt32(dr["Max_Pallet"]) - Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) - Math.Abs(objclsglobal.roundup((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) / (Convert.ToInt32(dr["Pallet_Qty"]))))) > 0)
                                {
                                    drInventory["KanbanNeededForGreen_Pallets"] = Convert.ToInt32(dr["Max_Pallet"]) - Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) - Math.Abs(objclsglobal.roundup((Convert.ToInt32(drInventory["InvOnDisCenter_Units"]) + Convert.ToInt32(drInventory["InvInTransit_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"])) / (Convert.ToInt32(dr["Pallet_Qty"]))));
                                }
                                else
                                {
                                    drInventory["KanbanNeededForGreen_Pallets"] = 0;
                                }
                            }
                        }

                        //#### REGION 4 - KANBAN LEVELS ####
                        drInventory["MinKanban_Pallets"] = dr["Min_Pallet"];
                        drInventory["TargetKanban_Pallets"] = dr["Target_Pallet"];
                        drInventory["MaxKanban_Pallets"] = dr["Max_Pallet"];

                        //#### REGION 5 - EXCESS OF KANBAN ####
                        //A3 - 02/21/2012 Tony Spoto Correction
                        if ((Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForGreen_Pallets"])) > 0)
                        {
                            drInventory["ExcessKanban_Pallets"] = 0;
                        }
                        else
                        {
                            if (Convert.ToInt32(dr["Max_Pallet"]) == 1)
                            {
                                if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) <= (1.5 * Convert.ToInt32(dr["Pallet_Qty"])))
                                {
                                    drInventory["ExcessKanban_Pallets"] = 0;
                                }
                                else
                                {
                                    //Correction For Negative Excess - Requested By Oscar - 03/14/2012
                                    //Add If validation

                                    if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"])) * Convert.ToInt32(dr["Pallet_Qty"])) < 0)
                                    {
                                        drInventory["ExcessKanban_Pallets"] = 0;
                                    }
                                    else
                                    {
                                        drInventory["ExcessKanban_Pallets"] = Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"])) * Convert.ToInt32(dr["Pallet_Qty"]));
                                    }
                                }
                            }
                            else
                            {
                                // Modificado por requisicion de Federico, se resta el total de inventario menos las ordenes (Customer) esto solo aplicac para el nodo de Juarez!!!
                                // 06/11/2012 Emmanuel
                                if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) <= ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"])) * Convert.ToInt32(dr["Pallet_Qty"])))
                                {
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        if ((Convert.ToInt32(dr["Min_Pallet"]) == 0) & (Convert.ToInt32(dr["Max_Pallet"]) == 0) & (Convert.ToInt32(dr["Target_Pallet"]) == 0))
                                        {
                                            drInventory["ExcessKanban_Pallets"] = (decInvOnDisCenter_Units + decInvInTransit_Units) - Convert.ToInt32(drInventory["Customer_Order_Units"]);
                                        }
                                        else
                                        {
                                            drInventory["ExcessKanban_Pallets"] = 0;
                                        }
                                    }
                                    else
                                    {
                                        drInventory["ExcessKanban_Pallets"] = 0;
                                    }
                                }
                                else
                                {
                                    if (drInventory["idLocalizationMaterial"].ToString().Substring(0, 4) == "5477")
                                    {
                                        if ((Convert.ToInt32(dr["Min_Pallet"]) == 0) & (Convert.ToInt32(dr["Max_Pallet"]) == 0) & (Convert.ToInt32(dr["Target_Pallet"]) == 0))
                                        {
                                            drInventory["ExcessKanban_Pallets"] = (decInvOnDisCenter_Units + decInvInTransit_Units) - Convert.ToInt32(drInventory["Customer_Order_Units"]);
                                        }
                                        else
                                        {
                                            drInventory["ExcessKanban_Pallets"] = Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"])) * Convert.ToInt32(dr["Pallet_Qty"]));
                                        }
                                    }
                                    else
                                    {
                                        drInventory["ExcessKanban_Pallets"] = Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - ((Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"])) * Convert.ToInt32(dr["Pallet_Qty"]));
                                    }

                                    // TERMINA 06/11/2012 Emmanuel

                                }
                            }
                        }

                        if (Convert.ToInt32(drInventory["ExcessKanban_Pallets"]) < 0)
                        {
                            drInventory["ExcessKanban_Pallets"] = 0;
                        }

                        //#### REGION 6 - HEIJUNKA BOARD PALLETS ####
                        //Captured
                        if (capturedRows != null)
                        {
                            if (capturedRows.Length > 0)
                            {
                                drInventory["HeijunkaBoard_Pallets"] = capturedRows[0]["HeijunkaBoard_Pallets"];
                            }
                            else
                            {
                                drInventory["HeijunkaBoard_Pallets"] = 0;
                            }
                        }
                        else if (foundRows != null)
                        {
                            if (foundRows.Length > 0)
                            {
                                drInventory["HeijunkaBoard_Pallets"] = foundRows[0]["HeijunkaBoard_Pallets"];
                            }
                            else
                            {
                                drInventory["HeijunkaBoard_Pallets"] = 0;
                            }
                        }
                        else
                        {
                            drInventory["HeijunkaBoard_Pallets"] = 0;
                        }


                        //### ADITIONAL VALUES ###
                        //A3 -TOTAL INV % 
                        try
                        {
                            if (Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"]) > 0)
                            {
                                drInventory["TotalInv%"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) < (0.5 * Convert.ToInt32(dr["Pallet_Qty"])))
                                {
                                    drInventory["TotalInv%"] = Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) / (Convert.ToInt32(dr["Max_Pallet"]) * Convert.ToInt32(dr["Pallet_Qty"]));
                                }
                                else
                                {
                                    drInventory["TotalInv%"] = 1 - ((Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) + Convert.ToInt32(drInventory["KanbanNeededForGreen_Pallets"])) / (Convert.ToInt32(dr["Max_Pallet"]) + Convert.ToInt32(drInventory["Total_Aditional_Pallets"]) - Convert.ToInt32(drInventory["Special_Bids_Pallets"])));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            drInventory["TotalInv%"] = 0;
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

                        //A3 - % RED (Modified by A3 - Jan 2013)
                        try
                        {
                            if ((Convert.ToInt32(drInventory["KanbanNeededForCurrentBO_Pallets"])) > 0)
                            {
                                drInventory["Precent_Red"] = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["MinKanban_Pallets"]) > 0)
                                {
                                    drInventory["Precent_Red"] = ((Convert.ToInt32(drInventory["TotalFG+Heijunka_Units"]) - Convert.ToInt32(drInventory["Customer_Order_Units"]) - Convert.ToInt32(drInventory["BTO_Units"]) - Convert.ToInt32(drInventory["Special_Bids_Units"])) / (Convert.ToInt32(drInventory["MinKanban_Pallets"]) * Convert.ToInt32(drInventory["Pallet_Qty"]))) * 100;
                                }
                                else
                                {
                                    drInventory["Precent_Red"] = 100;
                                }

                                if (Convert.ToInt32(drInventory["Precent_Red"]) > 100)
                                {
                                    drInventory["Precent_Red"] = 100;
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            drInventory["Precent_Red"] = 100;
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


                        //PRIMARY PRIORITY
                        if (Convert.ToInt32(drInventory["Current_Backorder_Units"]) > 0 & Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]) > 0)
                        {
                            drInventory["PrimaryPriority"] = 900 + Convert.ToInt32(drInventory["Current_Backorder_Units"]) / Convert.ToInt32(drInventory["Pallet_Qty"]);
                        }
                        else
                        {
                            if (Convert.ToInt32(drInventory["KanbanNeededForBTO_Pallets"]) > 0)
                            {
                                drInventory["PrimaryPriority"] = 800 + Convert.ToInt32(drInventory["KanbanNeededForBTO_Pallets"]);
                            }
                            else
                            {
                                if (Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"]) > 0)
                                {
                                    drInventory["PrimaryPriority"] = 700 + Convert.ToInt32(drInventory["KanbanNeededForSpecialBid_Pallets"]);
                                }
                                else
                                {
                                    if (Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]) > 0)
                                    {
                                        drInventory["PrimaryPriority"] = 600 + Convert.ToInt32(drInventory["KanbanNeededForHighPriority_Pallets"]);
                                    }
                                    else
                                    {
                                        if (dr["Brand"].ToString().ToUpper() == "DELL" & Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) > 0)
                                        {
                                            drInventory["PrimaryPriority"] = 500 + (1 - (Convert.ToInt32(drInventory["Precent_Red"]) / 100));
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]) > 0)
                                            {
                                                drInventory["PrimaryPriority"] = 400 + (1 - (Convert.ToInt32(drInventory["Precent_Red"]) / 100));
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]) > 0)
                                                {
                                                    drInventory["PrimaryPriority"] = 300 + Convert.ToDecimal(dr["CV"].ToString().ToUpper());
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(drInventory["KanbanNeededForGreen_Pallets"]) > 0)
                                                    {
                                                        drInventory["PrimaryPriority"] = 200 + Convert.ToDecimal(dr["CV"].ToString().ToUpper());
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToInt32(dr["Max_Pallet"]) == 0)
                                                        {
                                                            drInventory["PrimaryPriority"] = Convert.ToDecimal(dr["CV"].ToString().ToUpper());
                                                        }
                                                        else
                                                        {
                                                            drInventory["PrimaryPriority"] = 100 + Convert.ToDecimal(dr["CV"].ToString().ToUpper());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        drInventory["Recommended"] = 0;
                        drInventory["RecommendedOrange"] = 0;
                        drInventory["RecommendedGreen"] = 0;
                        drInventory["RecommendedYellow"] = 0;
                        drInventory["RecommendedRed"] = 0;

                        drInventory["%MinOrangeP"] = Convert.ToDecimal(drInventory["KanbanNeededForOrange_Pallets"]);
                        drInventory["%MinRedP"] = drInventory["KanbanNeededForRed_Pallets"];
                        drInventory["%MinYellowP"] = drInventory["KanbanNeededForYellow_Pallets"];
                        drInventory["%MinGreenP"] = drInventory["KanbanNeededForGreen_Pallets"];

                        lc_Orangeitemscount = lc_Orangeitemscount + Convert.ToInt32(drInventory["KanbanNeededForOrange_Pallets"]);
                        lc_Reditemscount = lc_Reditemscount + Convert.ToInt32(drInventory["KanbanNeededForRed_Pallets"]);
                        lc_Yellowitemscount = lc_Yellowitemscount + Convert.ToInt32(drInventory["KanbanNeededForYellow_Pallets"]);
                        lc_Greenitemscount = lc_Greenitemscount + Convert.ToInt32(drInventory["KanbanNeededForGreen_Pallets"]);

                        dtablePartNo.Rows.Add(drInventory);
                        count = count + 1;
                    }
                }

                //SET PART NO VISIBLE TO FALSE 

                //REORDER BASED ON PRIMARY PRIORITY
                dtablePartNo.DefaultView.Sort = "PrimaryPriority desc";
                dtablePartNo = dtablePartNo.DefaultView.ToTable();
                decimal Minorangepercentage = 1;
                decimal Minredpercentage = 100;
                decimal Minyellowpercentage = 100;
                decimal Mingreenpercentage = 100;
                decimal NewMinredpercentage = lc_Reditemscount;
                decimal NewMinYellowpercentage = lc_Yellowitemscount;
                decimal NewMinGreenpercentage = lc_Greenitemscount;
                decimal NewMinOrangepercentage = lc_Orangeitemscount;

                foreach (DataRow dr in dtablePartNo.Rows)
                {
                    if (Minorangepercentage < Convert.ToDecimal(dr["KanbanNeededForOrange_Pallets"]))
                    {
                        Minorangepercentage = Convert.ToDecimal(dr["KanbanNeededForOrange_Pallets"]);
                    }
                }

                int ope3 = 0;
                int ope4 = 0;

                //========================= ORANGE PALLET =============================================
                decimal X = Minorangepercentage;

                // if Capability have more than 1 quantity then calculate Orange Kanban
                if (Convert.ToInt32(HFCapability) > 0 && Convert.ToInt32(lc_Orangeitemscount) > 0)
                {
                    X = Minorangepercentage;
                    while (X < 10000)
                    {

                        foreach (DataRow dr in dtablePartNo.Rows)
                        {
                            if ((Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(dr["RecommendedOrange"])) >= Minorangepercentage)
                            {
                                strInsert = strInsert + " SELECT '" + idVKB + "', " + " '" + dr["idLocalizationMaterial"] + "', " + "'" + "1" + "', " + "'" + "Orange" + "', " + "'" + ((UserLoginInfo)Session["UserLoginInfo"]).UserID + "', " + "getdate() " + ",'" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'" + " UNION ALL ";

                                dr["RecommendedOrange"] = Convert.ToInt32(dr["RecommendedOrange"].ToString()) + 1;
                                ope4 = ope4 + 1;
                                HFCapability = (Convert.ToInt32(HFCapability) - 1).ToString();

                                dr["%MinOrangeP"] = Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]) - Convert.ToInt32(dr["RecommendedOrange"]);

                                if (Convert.ToDecimal(dr["%MinOrangeP"]) <= Minorangepercentage)
                                {
                                    Minorangepercentage = Convert.ToDecimal(dr["%MinOrangeP"]);
                                    if (Minorangepercentage == 0)
                                    {
                                        Minorangepercentage = 1;
                                    }
                                    NewMinOrangepercentage = Convert.ToDecimal(dr["%MinOrangeP"]);

                                    X = NewMinOrangepercentage;

                                }

                                ope3 = lc_Orangeitemscount - ope4;
                                if (ope3 == 0)
                                {
                                    X = 10000;
                                    break; // TODO: might not be correct. Was : Exit For
                                }

                            }

                            if (Convert.ToInt32(HFCapability) <= 0 | X == 10000)
                            {
                                X = 10000;
                                break; // TODO: might not be correct. Was : Exit For
                            }

                            if (object.ReferenceEquals(dr["RecommendedOrange"], DBNull.Value))
                            {
                                dr["RecommendedOrange"] = 0;
                            }
                            dr["Recommended"] = dr["RecommendedOrange"];

                        }
                    }

                }

                //========================= RED PALLET =============================================
                decimal currentRedPercentage = default(decimal);
                DataRow updateRow = null;
                // if Capability have more than 1 quantity then calculate Red Kanban
                // Changing from allocation based on Unit Difference to least %Fill
                while (Convert.ToInt32(HFCapability) > 0)
                {
                    Minredpercentage = 100;
                    //Select the least %Filled Red
                    foreach (DataRow dr in dtablePartNo.Select("MinKanban_Pallets > 0 AND KanbanNeededForRed_Pallets > RecommendedRed AND (([TotalFG+Heijunka_Units] + Recommended * Pallet_Qty - Customer_Order_Units - BTO_Units - Special_Bids_Units) / (MinKanban_Pallets * Pallet_Qty)) * 100 < 100"))
                    {
                        currentRedPercentage = ((Convert.ToInt32(dr["TotalFG+Heijunka_Units"]) + Convert.ToInt32(dr["Recommended"]) * Convert.ToInt32(dr["Pallet_Qty"]) - Convert.ToInt32(dr["Customer_Order_Units"]) - Convert.ToInt32(dr["BTO_Units"]) - Convert.ToInt32(dr["Special_Bids_Units"])) / (Convert.ToInt32(dr["MinKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]))) * 100;
                        if (currentRedPercentage < Minredpercentage)
                        {
                            updateRow = dr;
                            Minredpercentage = currentRedPercentage;
                        }
                    }

                    if (Minredpercentage < 100)
                    {
                        strInsert = strInsert + " SELECT '" + idVKB + "', " + " '" + updateRow["idLocalizationMaterial"] + "', " + "'" + "1" + "', " + "'" + "Red" + "', " + "'" + ((UserLoginInfo)Session["UserLoginInfo"]).UserID + "', " + "getdate() " + ",'" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'" + " UNION ALL ";

                        if (object.ReferenceEquals(updateRow["RecommendedRed"], DBNull.Value))
                        {
                            updateRow["RecommendedRed"] = 0;
                        }

                        updateRow["RecommendedRed"] = Convert.ToInt32(updateRow["RecommendedRed"].ToString()) + 1;
                        updateRow["Recommended"] = Convert.ToInt32(updateRow["RecommendedOrange"]) + Convert.ToInt32(updateRow["RecommendedRed"]);
                        //Update Recommended
                        HFCapability = (Convert.ToInt32(HFCapability) - 1).ToString();
                        //Capacity consumed
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                }

                //========================= YELLOW PALLET =============================================
                decimal currentYellowPercentage = default(decimal);
                // if Capability have more than 1 quantity then calculate Yellow Kanban
                while (Convert.ToInt32(HFCapability) > 0)
                {
                    Minyellowpercentage = 100;
                    foreach (DataRow dr in dtablePartNo.Select("TargetKanban_Pallets > 0 AND KanbanNeededForYellow_Pallets > RecommendedYellow AND (([TotalFG+Heijunka_Units] + Recommended * Pallet_Qty - Customer_Order_Units - BTO_Units - Special_Bids_Units) / (TargetKanban_Pallets * Pallet_Qty)) * 100 < 100"))
                    {
                        currentYellowPercentage = ((Convert.ToInt32(dr["TotalFG+Heijunka_Units"]) + Convert.ToInt32(dr["Recommended"]) * Convert.ToInt32(dr["Pallet_Qty"]) - Convert.ToInt32(dr["Customer_Order_Units"]) - Convert.ToInt32(dr["BTO_Units"]) - Convert.ToInt32(dr["Special_Bids_Units"])) / (Convert.ToInt32(dr["TargetKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]))) * 100;
                        if (currentYellowPercentage < Minyellowpercentage)
                        {
                            updateRow = dr;
                            Minyellowpercentage = currentYellowPercentage;
                        }
                    }

                    if (Minyellowpercentage < 100)
                    {
                        strInsert = strInsert + " SELECT '" + idVKB + "', " + " '" + updateRow["idLocalizationMaterial"] + "', " + "'" + "1" + "', " + "'" + "Yellow" + "', " + "'" + ((UserLoginInfo)Session["UserLoginInfo"]).UserID + "', " + "getdate() " + ",'" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'" + " UNION ALL ";

                        if (object.ReferenceEquals(updateRow["RecommendedYellow"], DBNull.Value))
                        {
                            updateRow["RecommendedYellow"] = 0;
                        }

                        updateRow["RecommendedYellow"] = Convert.ToInt32(updateRow["RecommendedYellow"].ToString()) + 1;
                        updateRow["Recommended"] = Convert.ToInt32(updateRow["RecommendedOrange"]) + Convert.ToInt32(updateRow["RecommendedRed"]) + Convert.ToInt32(updateRow["RecommendedYellow"]);
                        HFCapability = (Convert.ToInt32(HFCapability) - 1).ToString();
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                }

                //========================= Green PALLET =============================================
                decimal currentGreenPercentage = default(decimal);
                // if Capability have more than 1 quantity then calculate Green Kanban
                while (Convert.ToInt32(HFCapability) > 0)
                {
                    Mingreenpercentage = 100;
                    foreach (DataRow dr in dtablePartNo.Select("MaxKanban_Pallets > 0 AND KanbanNeededForGreen_Pallets > RecommendedGreen AND (([TotalFG+Heijunka_Units] + Recommended * Pallet_Qty - Customer_Order_Units - BTO_Units - Special_Bids_Units) / (MaxKanban_Pallets * Pallet_Qty)) * 100 < 100"))
                    {
                        currentGreenPercentage = ((Convert.ToInt32(dr["TotalFG+Heijunka_Units"]) + Convert.ToInt32(dr["Recommended"]) * Convert.ToInt32(dr["Pallet_Qty"]) - Convert.ToInt32(dr["Customer_Order_Units"]) - Convert.ToInt32(dr["BTO_Units"]) - Convert.ToInt32(dr["Special_Bids_Units"])) / (Convert.ToInt32(dr["MaxKanban_Pallets"]) * Convert.ToInt32(dr["Pallet_Qty"]))) * 100;
                        if (currentGreenPercentage < Mingreenpercentage)
                        {
                            updateRow = dr;
                            Mingreenpercentage = currentGreenPercentage;
                        }
                    }

                    if (Mingreenpercentage < 100)
                    {
                        strInsert = strInsert + " SELECT '" + idVKB + "', " + " '" + updateRow["idLocalizationMaterial"] + "', " + "'" + "1" + "', " + "'" + "Green" + "', " + "'" + ((UserLoginInfo)Session["UserLoginInfo"]).UserID + "', " + "getdate() " + ",'" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'" + " UNION ALL ";

                        if (object.ReferenceEquals(updateRow["RecommendedGreen"], DBNull.Value))
                        {
                            updateRow["RecommendedGreen"] = 0;
                        }

                        updateRow["RecommendedGreen"] = Convert.ToInt32(updateRow["RecommendedGreen"].ToString()) + 1;
                        updateRow["Recommended"] = Convert.ToInt32(updateRow["RecommendedOrange"]) + Convert.ToInt32(updateRow["RecommendedRed"]) + Convert.ToInt32(updateRow["RecommendedYellow"]) + Convert.ToInt32(updateRow["RecommendedGreen"]);
                        HFCapability = (Convert.ToInt32(HFCapability) - 1).ToString();
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                }

                if (strInsert.Length > 0)
                {
                    objTestBusiness.DELETE_VIRTUALKANBAN_SIGNALDELAY(idVKB);

                    string idLocalizationMaterial = (updateRow["idLocalizationMaterial"]).ToString();
                    string Material_Type_Request = "Green";
                    string User_Upload = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    DateTime Creation_Date = DateTime.Now;

                    Boolean Result_InsertSignalDelay = objTestBusiness.INSERT_VIRTUALKANBAN_SIGNALDELAY(idVKB, idLocalizationMaterial, Material_Type_Request, User_Upload, Creation_Date, LeanApp);
                    strInsert = strInsert.Substring(0, strInsert.Length - 10);
                    
                    if (Result_InsertSignalDelay == true)
                    {
                        LabelStatus.Text = "File was uploaded succesfully!!";
                        LabelStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        LabelStatus.Text = "Signal Error uploading the file";
                        LabelStatus.ForeColor = Color.Red;
                    }
                }

                DataSet dbDataSet = new DataSet();
                dbDataSet = objTestBusiness.get_VIRTUALKANBAN_CAPABILITYFROMLINE(Line, LeanApp); //call from business
                int TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                int OldTotalCapacity = TotalCapacity;
                foreach (DataRow dr in dtablePartNo.Rows)
                {
                    dr["Recommended"] = 0;
                }

                //For Orange Kanban
                for (int iloop = TotalCapacity; iloop >= 0; iloop += -1)
                {
                    foreach (DataRow dr in dtablePartNo.Rows)
                    {
                        TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                        int Recommended = Convert.ToInt32(dr["Recommended"]);
                        if (TotalCapacity == 0)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        int OrangeKanban = Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]);
                        int KanbanQuantity = Convert.ToInt32(dr["Pallet_Qty"]);
                        if (Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]) == 0)
                        {
                            dr["Recommended"] = 0;
                        }
                        else
                        {
                            if (KanbanQuantity <= TotalCapacity)
                            {
                                int CapacityNeeded = KanbanQuantity * 1;
                                if (TotalCapacity >= CapacityNeeded & CapacityNeeded > 0 & Recommended < OrangeKanban)
                                {
                                    dr["Recommended"] = Recommended + 1;
                                    TotalCapacity = TotalCapacity - CapacityNeeded;
                                    dbDataSet.Tables[0].Rows[0][0] = TotalCapacity.ToString();
                                }
                            }
                            else
                            {
                                dr["Recommended"] = Recommended;
                            }
                        }
                        if (chkcopypaste.Checked == true)
                        {
                            dr["HeijunkaBoard_Pallets"] = dr["Recommended"];
                        }
                    }
                    TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                }

                //For Red Kanban
                for (int iloop = TotalCapacity; iloop >= 0; iloop += -1)
                {
                    foreach (DataRow dr in dtablePartNo.Rows)
                    {
                        TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                        int Recommended = Convert.ToInt32(dr["Recommended"]);
                        if (TotalCapacity == 0)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        int RedKanban = Convert.ToInt32(dr["KanbanNeededForRed_Pallets"]);
                        int OrangeKanban = Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]);
                        int KanbanQuantity = Convert.ToInt32(dr["Pallet_Qty"]);
                        if (Convert.ToInt32(dr["KanbanNeededForRed_Pallets"]) == 0)
                        {
                            dr["Recommended"] = Recommended;
                        }
                        else
                        {
                            if (KanbanQuantity <= TotalCapacity)
                            {
                                int CapacityNeeded = KanbanQuantity * 1;
                                if (TotalCapacity >= CapacityNeeded & CapacityNeeded > 0 & (Recommended - OrangeKanban) < RedKanban)
                                {
                                    dr["Recommended"] = Recommended + 1;
                                    TotalCapacity = TotalCapacity - CapacityNeeded;
                                    dbDataSet.Tables[0].Rows[0][0] = TotalCapacity.ToString();
                                }
                            }
                            else
                            {
                                dr["Recommended"] = Recommended;
                            }
                        }
                        if (chkcopypaste.Checked == true)
                        {
                            dr["HeijunkaBoard_Pallets"] = dr["Recommended"];
                        }
                    }
                    TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                }

                //For Yellow Kanban
                for (int iloop = TotalCapacity; iloop >= 0; iloop += -1)
                {
                    foreach (DataRow dr in dtablePartNo.Rows)
                    {
                        TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                        int Recommended = Convert.ToInt32(dr["Recommended"]);
                        if (TotalCapacity == 0)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        int YellowKanban = Convert.ToInt32(dr["KanbanNeededForYellow_Pallets"]);
                        int RedKanban = Convert.ToInt32(dr["KanbanNeededForRed_Pallets"]);
                        int OrangeKanban = Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]);
                        int KanbanQuantity = Convert.ToInt32(dr["Pallet_Qty"]);
                        if (Convert.ToInt32(dr["KanbanNeededForYellow_Pallets"]) == 0)
                        {
                            dr["Recommended"] = Recommended;
                        }
                        else
                        {
                            if (KanbanQuantity <= TotalCapacity)
                            {
                                int CapacityNeeded = KanbanQuantity * 1;
                                if (TotalCapacity >= CapacityNeeded & CapacityNeeded > 0 & (Recommended - (OrangeKanban + RedKanban)) < YellowKanban)
                                {
                                    dr["Recommended"] = Recommended + 1;
                                    TotalCapacity = TotalCapacity - CapacityNeeded;
                                    dbDataSet.Tables[0].Rows[0][0] = TotalCapacity.ToString();
                                }
                            }
                            else
                            {
                                dr["Recommended"] = Recommended;
                            }
                        }
                        if (chkcopypaste.Checked == true)
                        {
                            dr["HeijunkaBoard_Pallets"] = dr["Recommended"];
                        }
                    }
                    TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                }

                //For Green Kanban
                for (int iloop = TotalCapacity; iloop >= 0; iloop += -1)
                {
                    foreach (DataRow dr in dtablePartNo.Rows)
                    {
                        int Recommended = Convert.ToInt32(dr["Recommended"]);
                        TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                        if (TotalCapacity == 0)
                        {
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        int YellowKanban = Convert.ToInt32(dr["KanbanNeededForYellow_Pallets"]);
                        int RedKanban = Convert.ToInt32(dr["KanbanNeededForRed_Pallets"]);
                        int OrangeKanban = Convert.ToInt32(dr["KanbanNeededForOrange_Pallets"]);
                        int GreenKanban = Convert.ToInt32(dr["KanbanNeededForGreen_Pallets"]);
                        int KanbanQuantity = Convert.ToInt32(dr["Pallet_Qty"]);
                        if (Convert.ToInt32(dr["KanbanNeededForGreen_Pallets"]) == 0)
                        {
                            dr["Recommended"] = Recommended;
                        }
                        else
                        {
                            if (KanbanQuantity <= TotalCapacity)
                            {
                                int CapacityNeeded = KanbanQuantity * 1;
                                if (TotalCapacity >= CapacityNeeded & CapacityNeeded > 0 & (Recommended - (OrangeKanban + RedKanban + YellowKanban)) < GreenKanban)
                                {
                                    dr["Recommended"] = Recommended + 1;
                                    TotalCapacity = TotalCapacity - CapacityNeeded;
                                    dbDataSet.Tables[0].Rows[0][0] = TotalCapacity.ToString();
                                }
                            }
                            else
                            {
                                dr["Recommended"] = Recommended;
                            }
                        }
                        if (chkcopypaste.Checked == true)
                        {
                            dr["HeijunkaBoard_Pallets"] = dr["Recommended"];
                        }
                    }
                    TotalCapacity = Convert.ToInt32(dbDataSet.Tables[0].Rows[0][0]);
                }

                //Update orignal Capacity Back to Database
                bool result_UpdateLine = objTestBusiness.Update_VIRTUALKANBAN_LINE(OldTotalCapacity, Line, LeanApp);

                //End of Recommended Calculations
                //ORDER PARTNUMBERS IN COLUMS FOR VIRTUAL KANBAN
                if (dtablePartNo.Rows.Count > 0) //If condition changed to <
                {
                    if (dtablePartNo.Rows.Count > 0)
                    {
                        if (bolFinal_Version)
                        {
                            LabelStatus.Text = "Final Virtual Kanban Board Version !!";
                            LabelStatus.ForeColor = Color.Green;
                            this.btnSave.Visible = false;
                            this.chkAutoSave.Visible = false;
                            this.chkRestoreHeijunka.Visible = false;
                            this.chkRestoreHeijunka.Checked = false;
                            this.chkFinalVersion.Visible = false;
                            this.hlReporte.Visible = true;
                        }
                        else if (bolFinal)
                        {
                            LabelStatus.Text = "Final Virtual Kanban Board Version !!";
                            LabelStatus.ForeColor = Color.Green;
                            this.btnSave.Visible = false;
                            this.chkAutoSave.Visible = false;
                            this.chkRestoreHeijunka.Visible = false;
                            this.chkRestoreHeijunka.Checked = false;
                            this.chkFinalVersion.Visible = false;
                            this.hlReporte.Visible = true;
                            saveVirtualKanban(dtablePartNo);

                        }
                        else
                        {
                            chkFinalVersion.Checked = false;
                            LabelStatus.Text = "Showing Part Number Virtual Kanban Board ...";
                            LabelStatus.ForeColor = Color.Maroon;
                            this.btnSave.Visible = true;
                            this.chkAutoSave.Visible = true;
                            this.chkRestoreHeijunka.Visible = true;
                            this.chkFinalVersion.Visible = true;
                            this.hlReporte.Visible = true;
                            //showReport()
                            saveVirtualKanban(dtablePartNo);

                        }
                        this.gvVKB.Visible = true;
                        gvVKB.Font.Size = FontUnit.XXSmall;
                        gvVKB.DataSource = dtablePartNo;
                        gvVKB.DataBind();
                    }
                    else
                    {
                        this.gvVKB.Visible = false;
                        this.btnSave.Visible = false;
                        this.chkAutoSave.Visible = false;
                        this.chkRestoreHeijunka.Visible = false;
                        this.chkRestoreHeijunka.Checked = false;
                        this.chkFinalVersion.Visible = false;
                        this.hlReporte.Visible = false;
                        LabelStatus.Text = "Empty Virtual Kanban Board.";
                        LabelStatus.ForeColor = Color.Red;
                        throw new Exception("Empty Virtual Kanban Board.");
                    }
                }
                else
                {
                    this.gvVKB.Visible = false;
                    this.btnSave.Visible = false;
                    this.chkAutoSave.Visible = false;
                    this.chkRestoreHeijunka.Visible = false;
                    this.chkRestoreHeijunka.Checked = false;
                    this.chkFinalVersion.Visible = false;
                    this.hlReporte.Visible = false;
                    LabelStatus.Text = "Empty Virtual Kanban Board.";
                    LabelStatus.ForeColor = Color.Red;
                    throw new Exception("Empty Virtual Kanban Board.");
                }

            }
            catch (Exception ex)
            {
                this.gvVKB.Visible = false;
                this.btnSave.Visible = false;
                this.chkAutoSave.Visible = false;
                this.chkRestoreHeijunka.Visible = false;
                this.chkRestoreHeijunka.Checked = false;
                this.chkFinalVersion.Visible = false;
                this.hlReporte.Visible = false;
                LabelStatus.Text = "Error Showing Virtual Kanban Board. " + ex.Message;
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
                if (dtablePartNo != null)
                {
                    dtablePartNo.Dispose();
                }
                if (dtableUploads != null)
                {
                    dtableUploads.Dispose();
                }
                if (dtableNetwork != null)
                {
                    dtableNetwork.Dispose();
                }
                if (dtableKeyNet != null)
                {
                    dtableKeyNet.Dispose();
                }
                if (dtableVKB != null)
                {
                    dtableVKB.Dispose();
                }
            }
        }

        private DataSet getSpecialPermissions()
        {
            DataSet functionReturnValue = default(DataSet);
            try
            {
                DataSet ds = new DataSet();
                string strSQL = null;
                //Open Connection
                //SQLConn = new System.Data.SqlClient.SqlConnection(connStr);
                //SQLConn.Open();
                //clsGlobal = new clsGlobal();

                //Get Special Permission
                //strSQL = "SELECT [idMaterial],[Localization_Name] " + " FROM [Overproduce_Special_Permission] " + " WHERE [Active]=1  " + " AND CAST(CONVERT(VARCHAR(10),[Date],101) AS DATETIME)  >=CONVERT(VARCHAR(10),getdate(),112)  " + " AND [Lean_Application] = '" + Session["Lean_Application"] + "'";
                string LeanApp = ((UserLoginInfo)Session["objUserLoginInfo"]).Lean_App;
                ds = objTestBusiness.get_VIRTUALKANBAN_SPECIALPERMISSION(LeanApp); ; //call from business
                if ((ds != null))
                {
                    functionReturnValue = ds;
                }
                else
                {
                    functionReturnValue = null;
                }
            }
            catch (Exception ex)
            {
                functionReturnValue = null;
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
            return functionReturnValue;
        }

        private bool existSpecialPermission(DataSet dsSpecialPermissions, string stridMaterial, string strLocalization_Name)
        {
            bool functionReturnValue = false;
            try
            {
                DataRow[] foundRows = null;
                functionReturnValue = false;

                if ((dsSpecialPermissions != null))
                {
                    foundRows = dsSpecialPermissions.Tables[0].Select("[idMaterial] = '" + stridMaterial + "'  AND [Localization_Name]='" + strLocalization_Name + "'");
                    if (foundRows.Length > 0)
                    {
                        functionReturnValue = true;
                    }
                }

            }
            catch (Exception ex)
            {
                functionReturnValue = false;
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
            return functionReturnValue;
        }

        private void saveVirtualKanban(DataTable dtVKB)
        {
            DataSet ds = new DataSet();
            DataSet dsCurrentPriority = default(DataSet);
            DataRow[] foundRows = null;
            int idVKB = 0;
            int intTotalCurrentPallets = 0;
            int idLine = 0;
            DataSet dsid = new DataSet();
            int hfidLine = 0;
            dsid = objTestBusiness.get_VIRTUALKANBAN_IDLINE(ddlLine.SelectedItem.Value, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
            foreach (DataRow dr in dsid.Tables[0].Rows)
            {
                hfidLine = Convert.ToInt32(dr["idLine"].ToString());
            }

            int hfidVKB = idVKB;

            try
            {
                //Get VKB Global
                DateTime TextFechaCaptura = Convert.ToDateTime(HiddenField1.Value);
                string LeanApp = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                DateTime Date = DateTime.Now;
                string Line = ddlLine.Text;
                {
                    if (hfidLine == 0 | hfidVKB == 0)
                    {
                        ds = objTestBusiness.get_VIRTUALKANBAN_VKBGLOBALLINE(TextFechaCaptura, Line, LeanApp);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            idVKB = Convert.ToInt32(ds.Tables[0].Rows[0]["idVKB"]);
                            idLine = Convert.ToInt32(ds.Tables[0].Rows[0]["idLine"]);
                        }
                        else
                        {
                            ds = objTestBusiness.get_VIRTUALKANBAN_IDLINE(Line, LeanApp);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                idLine = Convert.ToInt32(ds.Tables[0].Rows[0]["idLine"]);
                            }
                        }
                    }
                    else
                    {
                        idVKB = hfidVKB;
                        idLine = hfidLine;
                    }
                }

                //Set VKB Global

                {
                    string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                    Boolean val_chkFinalVersion;
                    if (chkFinalVersion.Checked == true)
                        val_chkFinalVersion = true;
                    else
                        val_chkFinalVersion = false;
                    if (idVKB == 0)
                    {
                        DateTime Upload_Date = DateTime.Now;

                        bool result_InsertVKBGlobal = objTestBusiness.INSERT_VIRTUALKANBAN_VKBGLOBALLINE(TextFechaCaptura, idLine, val_chkFinalVersion, Upload_User, Upload_Date, LeanApp);
                    }
                    else
                    {
                        bool result_UpdateVKBGlobal = objTestBusiness.UPDATE_VIRTUALKANBAN_VKBGLOBALLINE(val_chkFinalVersion, Upload_User, Date, idVKB);

                        if (result_UpdateVKBGlobal != true)
                        {
                            LabelStatus.Text = "Error Updating Virtual Kanban Board.";
                            LabelStatus.ForeColor = Color.Red;
                        }
                    }
                }

                //VKB Global
                //Get VKB Global
                if (idVKB == 0)
                {
                    //Get idVKB
                    ds = objTestBusiness.get_VIRTUALKANBAN_VKBGLOBALLINE(TextFechaCaptura, Line, LeanApp); //call from business
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        idVKB = Convert.ToInt32(ds.Tables[0].Rows[0]["idVKB"]);
                        idLine = Convert.ToInt32(ds.Tables[0].Rows[0]["idLine"]);
                    }
                }

                //Get Todays Priority
                dsCurrentPriority = objTestBusiness.get_VIRTUALKANBAN_PROD_PRIORITIES(TextFechaCaptura, LeanApp); //call from business
                bool result_VKBDetailPN;

                //Set VKB Detail
                foreach (DataRow dr in dtVKB.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["idLocalizationMaterial"].ToString()))
                    {
                        if (chkcopypaste.Checked == true)
                        {
                            dr["HeijunkaBoard_Pallets"] = dr["Recommended"];
                        }
                        idLocalizationMaterial_dtVKB = dr["idLocalizationMaterial"].ToString().ToUpper();
                        UDC_dtVKB = dr["UDC"].ToString().ToUpper();
                        CV_dtVKB = float.Parse(dr["CV"].ToString());
                        PrimaryPriority_dtVKB = float.Parse(dr["PrimaryPriority"].ToString());
                        idMaterial_dtVKB = dr["idMaterial"].ToString().ToUpper();
                        Localization_Name_dtVKB = dr["Localization_Name"].ToString().ToUpper();
                        PrecentRed_dtVKB = float.Parse(dr["Precent_Red"].ToString());
                        Customer_Backorder_Units_dtVKB = float.Parse(dr["Current_Backorder_Units"].ToString());
                        BTO_Units_dtVKB = float.Parse(dr["BTO_Units"].ToString());
                        Special_Bids_Units_dtVKB = float.Parse(dr["Special_Bids_Units"].ToString());
                        Projected_Backorder_Units_dtVKB = float.Parse(dr["Customer_Order_Units"].ToString());
                        InvOnDisCenter_Units_dtVKB = float.Parse(dr["InvOnDisCenter_Units"].ToString());
                        InvInTransit_Units_dtVKB = float.Parse(dr["InvInTransit_Units"].ToString());
                        SAPKanbanTotal_Pallets_dtVKB = float.Parse(dr["SAPKanbanTotal_Pallets"].ToString());
                        HeijunkaKanban_Pallets_dtVKB = float.Parse(dr["HeijunkaKanban_Pallets"].ToString());
                        TotalKanban_Pallets_dtVKB = float.Parse(dr["TotalKanban_Pallets"].ToString());
                        TotalInvpercent_dtVKB = float.Parse(dr["TotalInv%"].ToString());
                        RedPorc_dtVKB = float.Parse(dr["RedKanban%"].ToString());
                        YellowPorc_dtVKB = float.Parse(dr["YellowKanban%"].ToString());
                        GreenPorc_dtVKB = float.Parse(dr["GreenKanban%"].ToString());
                        KanbanNeededForCustomerBO_Pallets_dtVKB = float.Parse(dr["KanbanNeededForCurrentBO_Pallets"].ToString());
                        KanbanNeededForBTO_Pallets_dtVKB = float.Parse(dr["KanbanNeededForBTO_Pallets"].ToString());
                        KanbanNeededForSpecialBid_Pallets_dtVKB = float.Parse(dr["KanbanNeededForSpecialBid_Pallets"].ToString());
                        KanbanNeededForProjectedBO_Pallets_dtVKB = float.Parse(dr["KanbanNeededForHighPriority_Pallets"].ToString());
                        KanbanNeededForOrange_Pallets_dtVKB = float.Parse(dr["KanbanNeededForOrange_Pallets"].ToString());
                        KanbanNeededForRed_Pallets_dtVKB = float.Parse(dr["KanbanNeededForRed_Pallets"].ToString());
                        KanbanNeededForYellow_Pallets_dtVKB = float.Parse(dr["KanbanNeededForYellow_Pallets"].ToString());
                        KanbanNeededForGreen_Pallets_dtVKB = float.Parse(dr["KanbanNeededForGreen_Pallets"].ToString());
                        MinKanban_Pallets_dtVKB = float.Parse(dr["MinKanban_Pallets"].ToString());
                        TargetKanban_Pallets_dtVKB = float.Parse(dr["TargetKanban_Pallets"].ToString());
                        MaxKanban_Pallets_dtVKB = float.Parse(dr["MaxKanban_Pallets"].ToString());
                        ExcessKanban_Pallets_dtVKB = float.Parse(dr["ExcessKanban_Pallets"].ToString());
                        HeijunkaBoard_Pallets_dtVKB = float.Parse(dr["HeijunkaBoard_Pallets"].ToString());
                        Platform_dtVKB = dr["Platform"].ToString();
                        Family_dtVKB = dr["Family"].ToString();
                        AverageDemand_dtVKB = float.Parse(dr["AverageDemand"].ToString());
                        Pallet_Qty_dtVKB = Convert.ToInt32(dr["Pallet_Qty"].ToString());
                        Type_dtVKB = dr["Type"].ToString();
                        High_Priority_Units_dtVKB = float.Parse(dr["High_Priority_Units"].ToString());
                        Remd_Pallet_dtVKB = Convert.ToInt32(dr["Recommended"].ToString());
                        PPVT_dtVKB = "NA";
                        Yield_dtVKB = "NA";
                        result_VKBDetailPN = objTestBusiness.INSERT_VIRTUALKANBAN_VKBDETAILPARTNO(idVKB, idLocalizationMaterial_dtVKB, UDC_dtVKB, CV_dtVKB, PrimaryPriority_dtVKB, idMaterial_dtVKB, Localization_Name_dtVKB, PrecentRed_dtVKB, Customer_Backorder_Units_dtVKB, BTO_Units_dtVKB, Special_Bids_Units_dtVKB, Projected_Backorder_Units_dtVKB, InvOnDisCenter_Units_dtVKB, InvInTransit_Units_dtVKB, SAPKanbanTotal_Pallets_dtVKB, HeijunkaKanban_Pallets_dtVKB, TotalKanban_Pallets_dtVKB, TotalInvpercent_dtVKB, RedPorc_dtVKB, YellowPorc_dtVKB, GreenPorc_dtVKB, KanbanNeededForCustomerBO_Pallets_dtVKB, KanbanNeededForBTO_Pallets_dtVKB, KanbanNeededForSpecialBid_Pallets_dtVKB, KanbanNeededForProjectedBO_Pallets_dtVKB, KanbanNeededForOrange_Pallets_dtVKB, KanbanNeededForRed_Pallets_dtVKB, KanbanNeededForYellow_Pallets_dtVKB, KanbanNeededForGreen_Pallets_dtVKB, MinKanban_Pallets_dtVKB, TargetKanban_Pallets_dtVKB, MaxKanban_Pallets_dtVKB, ExcessKanban_Pallets_dtVKB, HeijunkaBoard_Pallets_dtVKB, Platform_dtVKB, Family_dtVKB, AverageDemand_dtVKB, Pallet_Qty_dtVKB, Type_dtVKB, High_Priority_Units_dtVKB, Remd_Pallet_dtVKB, LeanApp, PPVT_dtVKB, Yield_dtVKB);

                        //Priority
                        if (Convert.ToDecimal(dr["HeijunkaBoard_Pallets"].ToString()) == 0)
                        {
                            //Delete SKU from Current Date Priority
                            objTestBusiness.DELETE_VIRTUALKANBAN_PROD_PRIORITIZE(dr["idLocalizationMaterial"].ToString().ToUpper(), Convert.ToDateTime(HiddenField1.Value), ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                        }
                        else
                        {
                            foundRows = dsCurrentPriority.Tables[0].Select("idLocalizationMaterial='" + dr["idLocalizationMaterial"].ToString().ToUpper() + "'");
                            //id SKU NOT EXIST
                            if (foundRows.Length <= 0)
                            {
                                //Insert SKU from Current Date Priority
                                int Production_Order = 0;
                                int Pallets = Convert.ToInt32(dr["HeijunkaBoard_Pallets"].ToString());
                                string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID; ;
                                int Minutes_Lost = 0;
                                int Pieces_Lost = 0;
                                bool result_InsertProdPrioritize = objTestBusiness.INSERT_VIRTUALKANBAN_PROD_PRIORITIZE(idLocalizationMaterial_dtVKB, idLine, Date, Production_Order, Pallets, PrimaryPriority_dtVKB, Upload_User, Minutes_Lost, Pieces_Lost, LeanApp);

                            }
                            else
                            {
                                intTotalCurrentPallets = Convert.ToInt32(dsCurrentPriority.Tables[0].Compute("SUM(Pallets)", "idLocalizationMaterial='" + dr["idLocalizationMaterial"].ToString().ToUpper() + "'"));
                                //if Saved Pallets = Processed Heijunka
                                if (intTotalCurrentPallets == Convert.ToDecimal(dr["HeijunkaBoard_Pallets"].ToString()))
                                {
                                    //Nothing Same Qty as Saved
                                }
                                else
                                {
                                    //Delete SKU from Current Date Priority
                                    //Insert SKU from Current Date Priority
                                }

                            }
                        }
                    }
                }

                if (dtVKB.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        objTestBusiness.DELETE_VIRTUALKANBAN_VKBDETAILPARTNO(idVKB);

                    }
                    else
                    {
                        objTestBusiness.DELETE_VIRTUALKANBAN_VKBDETAILPARTNO(idVKB);
                    }

                    //Insert Uploaded Part Numbers
                    result_VKBDetailPN = objTestBusiness.INSERT_VIRTUALKANBAN_VKBDETAILPARTNO(idVKB, idLocalizationMaterial_dtVKB, UDC_dtVKB, CV_dtVKB, PrimaryPriority_dtVKB, idMaterial_dtVKB, Localization_Name_dtVKB, PrecentRed_dtVKB, Customer_Backorder_Units_dtVKB, BTO_Units_dtVKB, Special_Bids_Units_dtVKB, Projected_Backorder_Units_dtVKB, InvOnDisCenter_Units_dtVKB, InvInTransit_Units_dtVKB, SAPKanbanTotal_Pallets_dtVKB, HeijunkaKanban_Pallets_dtVKB, TotalKanban_Pallets_dtVKB, TotalInvpercent_dtVKB, RedPorc_dtVKB, YellowPorc_dtVKB, GreenPorc_dtVKB, KanbanNeededForCustomerBO_Pallets_dtVKB, KanbanNeededForBTO_Pallets_dtVKB, KanbanNeededForSpecialBid_Pallets_dtVKB, KanbanNeededForProjectedBO_Pallets_dtVKB, KanbanNeededForOrange_Pallets_dtVKB, KanbanNeededForRed_Pallets_dtVKB, KanbanNeededForYellow_Pallets_dtVKB, KanbanNeededForGreen_Pallets_dtVKB, MinKanban_Pallets_dtVKB, TargetKanban_Pallets_dtVKB, MaxKanban_Pallets_dtVKB, ExcessKanban_Pallets_dtVKB, HeijunkaBoard_Pallets_dtVKB, Platform_dtVKB, Family_dtVKB, AverageDemand_dtVKB, Pallet_Qty_dtVKB, Type_dtVKB, High_Priority_Units_dtVKB, Remd_Pallet_dtVKB, LeanApp, PPVT_dtVKB, Yield_dtVKB);

                    if (result_VKBDetailPN != true)
                    {
                        LabelStatus.Text = "Error Updating Virtual Kanban Board.";
                        LabelStatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (chkFinalVersion.Checked == true)
                        {
                            LabelStatus.Text = "Final Virtual Kanban Board Version !!.";
                            LabelStatus.ForeColor = Color.Green;
                        }
                        else
                        {
                            LabelStatus.ForeColor = Color.Green;
                            LabelStatus.Text = "VKB Successfully Calculated And Updated!!.";
                        }

                        //Delete Current Priority
                        objTestBusiness.DELETE_VIRTUALKANBAN_PROD_PRIORITIZE(idLocalizationMaterial_dtVKB, TextFechaCaptura, LeanApp);

                        //Insert New Production Priority
                        if (dtVKB.Rows.Count > 0)
                        {
                            foreach (DataRow drProd in dtVKB.Rows)
                            {
                                DateTime txtDate = Convert.ToDateTime(HiddenField1.Value);
                                int Production_Order = 0;
                                int Pallets = Convert.ToInt32(drProd["HeijunkaBoard_Pallets"].ToString());
                                double PrimaryPriority = Convert.ToDouble(drProd["PrimaryPriority"].ToString());
                                string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                                int Minutes_Lost = 0;
                                int Pieces_Lost = 0;
                                bool Result_InsertProdPrioritize = objTestBusiness.INSERT_VIRTUALKANBAN_PROD_PRIORITIZE(idLocalizationMaterial_dtVKB, idLine, txtDate, Production_Order, Pallets, PrimaryPriority, Upload_User, Minutes_Lost, Pieces_Lost, LeanApp);
                                if (Result_InsertProdPrioritize != true)
                                {
                                    LabelStatus.Text = LabelStatus.Text + " Error Saving Prioritization.";
                                    LabelStatus.ForeColor = Color.Red;
                                }
                            }
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

        private DataTable getPalletSizes()
        {
            try
            {
                DataSet ds = new DataSet();
                //DataRow dr = default(DataRow);
                DataRow dRow = default(DataRow);
                DataTable dtable = new DataTable();
                string strSQL = null;
                //Open Connection
                //SQLConn = new System.Data.SqlClient.SqlConnection(connStr);
                //SQLConn.Open();
                //clsGlobal = new clsGlobal();
                //Get VKB Global
                //strSQL = "SELECT [idMaterial],[Pallet_Qty],[KanbanNeededForCustomerBO_Pallets],[Localization_Name] " + " FROM [VKB_Detail_PartNumber] " + " INNER JOIN [VKB_Global_Line] " + " ON [VKB_Detail_PartNumber].[idVKB]=[VKB_Global_Line].[idVKB]  " + " INNER JOIN [Line] " + " ON Line.idLine = [VKB_Global_Line].idLine " + " WHERE  Line.Line = '" + ddlLine.Text + "' AND [VKB_Global_Line].[Date]='" + Convert.ToDateTime(HiddenField1.Value) + "'" + " and Line.Lean_Application='" + Session["Lean_Application"] + "'";

                //strSQL = "Select [idMaterial],[Pallet_Qty] " & _
                //       " FROM [VKB_Input], Line" & _
                //        " WHERE " & _
                //            " Line.idLine = [VKB_Input].idLine AND " & _
                //            " Line.Line = '" & ddlLine.Text & "'"

                string Line = ddlLine.Text;
                DateTime TextFechaCaptura = Convert.ToDateTime(HiddenField1.Value);
                string LeanApp = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                ds = objTestBusiness.get_VIRTUALKANBAN_PALLETSIZES(Line, TextFechaCaptura, LeanApp); //call from business
                dtable.Columns.Add("idMaterial", Type.GetType("System.String"));
                dtable.Columns.Add("Localization_Name", Type.GetType("System.String"));
                dtable.Columns.Add("Pallet_Qty", Type.GetType("System.Decimal"));
                dtable.Columns.Add("KanbanNeededForCurrentBO_Pallets", Type.GetType("System.Decimal"));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dRow = dtable.NewRow();
                    dRow["idMaterial"] = dr["idMaterial"].ToString().ToUpper();
                    dRow["Localization_Name"] = dr["Localization_Name"].ToString().ToUpper();
                    dRow["Pallet_Qty"] = dr["Pallet_Qty"].ToString();
                    dRow["KanbanNeededForCurrentBO_Pallets"] = dr["KanbanNeededForCustomerBO_Pallets"].ToString();
                    dtable.Rows.Add(dRow);
                }
                return dtable;
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
                return null;
            }
            //finally {
            //    //ds.Clear()
            //    if ((SQLConn != null)) {
            //        if (SQLConn.State == ConnectionState.Open) {
            //            SQLConn.Close();
            //        }
            //        SQLConn.Dispose();
            //    }
            //}
        }

        protected void gvVKB_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                bindUploadTable();
                gvVKB.PageIndex = e.NewPageIndex;
                gvVKB.DataBind();
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

        protected void gvVKB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Color For %Red
                    Label lbl_Per_Red = (Label)e.Row.FindControl("lblRedView");
                    if (lbl_Per_Red.Text == "100 %")
                    {
                        lbl_Per_Red.BackColor = Color.White;
                        lbl_Per_Red.ForeColor = Color.White;
                        e.Row.Cells[2].BorderWidth = 3;
                        e.Row.Cells[2].BorderColor = Color.White;
                    }
                    else
                    {
                        lbl_Per_Red.BackColor = Color.White;
                        lbl_Per_Red.ForeColor = Color.Red;
                        e.Row.Cells[2].BorderWidth = 3;
                        e.Row.Cells[2].BorderColor = Color.White;
                    }

                    //Colour for Needed Orange Kanban
                    Label lbl_Kanban_Needed_For_Orange = (Label)e.Row.FindControl("lblKanbanNeededForOrange_PalletsView");
                    if (lbl_Kanban_Needed_For_Orange.Text == "0")
                    {
                        e.Row.Cells[19].BorderWidth = 3;
                        e.Row.Cells[19].BorderColor = Color.Orange;
                        e.Row.Cells[19].BackColor = Color.White;
                        e.Row.Cells[19].ForeColor = Color.Black;
                    }
                    else
                    {
                        e.Row.Cells[19].BackColor = Color.Orange;
                        e.Row.Cells[19].BorderWidth = 3;
                        e.Row.Cells[19].BorderColor = Color.LightGray;
                        e.Row.Cells[19].ForeColor = Color.Black;
                    }

                    //Colour for Needed Red Kanban
                    Label lbl_Kanban_Needed_For_Red = (Label)e.Row.FindControl("lblKanbanNeededForRed_PalletsView");
                    if (lbl_Kanban_Needed_For_Red.Text == "0")
                    {
                        e.Row.Cells[20].BorderWidth = 3;
                        e.Row.Cells[20].BorderColor = Color.Red;
                        e.Row.Cells[20].BackColor = Color.White;
                        e.Row.Cells[20].ForeColor = Color.Black;
                    }
                    else
                    {
                        e.Row.Cells[20].BackColor = Color.Red;
                        e.Row.Cells[20].BorderWidth = 3;
                        e.Row.Cells[20].BorderColor = Color.LightGray;
                        e.Row.Cells[20].ForeColor = Color.Black;
                    }

                    //Colour for Needed Yellow Kanban
                    Label lbl_Kanban_Needed_For_Yellow = (Label)e.Row.FindControl("lblKanbanNeededForYellow_PalletsView");
                    if (lbl_Kanban_Needed_For_Yellow.Text == "0")
                    {
                        e.Row.Cells[21].BorderWidth = 3;
                        e.Row.Cells[21].BorderColor = Color.Yellow;
                        e.Row.Cells[21].BackColor = Color.White;
                        e.Row.Cells[21].ForeColor = Color.Black;
                    }
                    else
                    {
                        e.Row.Cells[21].BackColor = Color.Yellow;
                        e.Row.Cells[21].BorderWidth = 3;
                        e.Row.Cells[21].BorderColor = Color.LightGray;
                        e.Row.Cells[21].ForeColor = Color.Black;
                    }

                    //Colour for Needed Green Kanban
                    Label lbl_Kanban_Needed_For_Green = (Label)e.Row.FindControl("lblKanbanNeededForGreen_PalletsView");
                    if (lbl_Kanban_Needed_For_Green.Text == "0")
                    {
                        e.Row.Cells[22].BorderWidth = 3;
                        e.Row.Cells[22].BorderColor = Color.LimeGreen;
                        e.Row.Cells[22].BackColor = Color.White;
                        e.Row.Cells[22].ForeColor = Color.Black;
                    }
                    else
                    {
                        e.Row.Cells[22].BackColor = Color.LimeGreen;
                        e.Row.Cells[22].BorderWidth = 3;
                        e.Row.Cells[22].BorderColor = Color.LightGray;
                        e.Row.Cells[22].ForeColor = Color.Black;
                    }

                    //Colour for PPVT
                    e.Row.Cells[4].BorderWidth = 3;
                    e.Row.Cells[4].BorderColor = Color.White;
                    e.Row.Cells[4].BackColor = Color.LightGray;
                    e.Row.Cells[4].ForeColor = Color.Black;
                    e.Row.Cells[4].Enabled = false;

                    //Colour for Yield
                    e.Row.Cells[5].BorderWidth = 2;
                    e.Row.Cells[5].BorderColor = Color.White;
                    e.Row.Cells[5].BackColor = Color.LightGray;
                    e.Row.Cells[5].ForeColor = Color.Black;
                    e.Row.Cells[5].Enabled = false;

                    //Colour for LOC
                    e.Row.Cells[6].BorderWidth = 3;
                    e.Row.Cells[6].BorderColor = Color.Black;
                    e.Row.Cells[6].ForeColor = Color.Black;
                    e.Row.Cells[6].Font.Bold = true;

                    //Colour For PN
                    e.Row.Cells[3].BorderWidth = 3;
                    e.Row.Cells[3].BorderColor = Color.White;
                    e.Row.Cells[3].BackColor = Color.White;
                    e.Row.Cells[3].ForeColor = Color.Black;
                    e.Row.Cells[3].Font.Bold = true;

                    //Colour for Kanban Quantity
                    e.Row.Cells[7].BorderWidth = 3;
                    e.Row.Cells[7].BorderColor = Color.White;
                    e.Row.Cells[7].BackColor = Color.LightGray;
                    e.Row.Cells[7].ForeColor = Color.Black;

                    //Colour for Customer Orders
                    e.Row.Cells[8].BorderWidth = 3;
                    e.Row.Cells[8].BorderColor = Color.SkyBlue;
                    e.Row.Cells[8].BackColor = Color.White;
                    e.Row.Cells[8].ForeColor = Color.Black;

                    //Colour for Current BackOrders
                    e.Row.Cells[9].BorderWidth = 3;
                    e.Row.Cells[9].BorderColor = Color.SkyBlue;
                    e.Row.Cells[9].BackColor = Color.White;
                    e.Row.Cells[9].ForeColor = Color.Black;

                    //Colour for BTO
                    e.Row.Cells[10].BorderWidth = 3;
                    e.Row.Cells[10].BorderColor = Color.SkyBlue;
                    e.Row.Cells[10].BackColor = Color.White;
                    e.Row.Cells[10].ForeColor = Color.Black;

                    //Colour for Special Bids
                    e.Row.Cells[11].BorderWidth = 3;
                    e.Row.Cells[11].BorderColor = Color.SkyBlue;
                    e.Row.Cells[11].BackColor = Color.White;
                    e.Row.Cells[11].ForeColor = Color.Black;

                    //Colour for SAP Inventory
                    e.Row.Cells[12].BorderWidth = 3;
                    e.Row.Cells[12].BorderColor = Color.SkyBlue;
                    e.Row.Cells[12].BackColor = Color.White;
                    e.Row.Cells[12].ForeColor = Color.Black;

                    //Colour for SAP Inventory In Transit
                    e.Row.Cells[13].BorderWidth = 3;
                    e.Row.Cells[13].BorderColor = Color.SkyBlue;
                    e.Row.Cells[13].BackColor = Color.White;
                    e.Row.Cells[13].ForeColor = Color.Black;

                    //Color for First Blank Space
                    e.Row.Cells[14].BorderWidth = 1;
                    e.Row.Cells[14].BorderColor = Color.Gray;
                    e.Row.Cells[14].BackColor = Color.Gray;
                    e.Row.Cells[14].Enabled = false;

                    //Color for SAP Kanban Total
                    e.Row.Cells[15].BorderWidth = 3;
                    e.Row.Cells[15].BorderColor = Color.LightGray;
                    e.Row.Cells[15].BackColor = Color.White;
                    e.Row.Cells[15].ForeColor = Color.Black;

                    //Color for Heijunka Kanban
                    e.Row.Cells[16].BorderWidth = 3;
                    e.Row.Cells[16].BorderColor = Color.SkyBlue;
                    e.Row.Cells[16].BackColor = Color.SkyBlue;
                    e.Row.Cells[16].ForeColor = Color.SkyBlue;
                    e.Row.Cells[16].Enabled = false;

                    //Color for Total Kanban
                    e.Row.Cells[17].BorderWidth = 3;
                    e.Row.Cells[17].BorderColor = Color.LightGray;
                    e.Row.Cells[17].BackColor = Color.White;
                    e.Row.Cells[17].ForeColor = Color.Black;

                    //Color for Second Blank Space
                    e.Row.Cells[18].BorderWidth = 1;
                    e.Row.Cells[18].BorderColor = Color.Gray;
                    e.Row.Cells[18].BackColor = Color.Gray;
                    e.Row.Cells[18].Enabled = false;

                    //Color for Third Blank Space
                    e.Row.Cells[23].BorderWidth = 1;
                    e.Row.Cells[23].BorderColor = Color.Gray;
                    e.Row.Cells[23].BackColor = Color.Gray;
                    e.Row.Cells[23].Enabled = false;

                    //Color for Red Pallets
                    e.Row.Cells[24].BorderWidth = 3;
                    e.Row.Cells[24].BorderColor = Color.White;
                    e.Row.Cells[24].BackColor = Color.LightGray;
                    e.Row.Cells[24].ForeColor = Color.Black;
                    e.Row.Cells[24].Enabled = false;

                    //Color for Yellow Pallets
                    e.Row.Cells[25].BorderWidth = 3;
                    e.Row.Cells[25].BorderColor = Color.White;
                    e.Row.Cells[25].ForeColor = Color.Black;
                    e.Row.Cells[25].BackColor = Color.LightGray;
                    e.Row.Cells[25].Enabled = false;

                    //Color for Green Pallets
                    e.Row.Cells[26].BorderWidth = 3;
                    e.Row.Cells[26].BorderColor = Color.White;
                    e.Row.Cells[26].BackColor = Color.LightGray;
                    e.Row.Cells[26].ForeColor = Color.Black;
                    e.Row.Cells[26].Enabled = false;

                    //Color for Forth Blank Space
                    e.Row.Cells[27].BorderWidth = 1;
                    e.Row.Cells[27].BorderColor = Color.Gray;
                    e.Row.Cells[27].BackColor = Color.Gray;
                    e.Row.Cells[27].Enabled = false;

                    //Color for Encess Inventory
                    e.Row.Cells[28].BorderWidth = 3;
                    e.Row.Cells[28].BorderColor = Color.LightGray;
                    e.Row.Cells[28].BackColor = Color.White;
                    e.Row.Cells[28].ForeColor = Color.Black;

                    //Color for Fifth Blank Space
                    e.Row.Cells[29].BorderWidth = 1;
                    e.Row.Cells[29].BorderColor = Color.Gray;
                    e.Row.Cells[29].BackColor = Color.Gray;
                    e.Row.Cells[29].Enabled = false;

                    //Color for Recommended Production
                    e.Row.Cells[30].BorderWidth = 3;
                    e.Row.Cells[30].BorderColor = Color.LightGray;
                    e.Row.Cells[30].BackColor = Color.LightGreen;
                    e.Row.Cells[25].ForeColor = Color.Black;

                    //Color for Sixth Blank Space
                    e.Row.Cells[31].BorderWidth = 1;
                    e.Row.Cells[31].BorderColor = Color.Gray;
                    e.Row.Cells[31].BackColor = Color.Gray;
                    e.Row.Cells[31].Enabled = false;

                    //Color for Recommended Production
                    e.Row.Cells[32].BorderWidth = 3;
                    e.Row.Cells[32].BorderColor = Color.LightGray;
                    e.Row.Cells[32].BackColor = Color.LightGreen;
                    e.Row.Cells[32].ForeColor = Color.LightGreen;
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

        protected void btnCapablity_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:window.open('Capability.aspx', 'hello', 'width=700px,height=400px,left=((screen.width -700) / 2),top=((screen.height - 400) / 2),scrollbars=yes,toolbar=no,menubar=no,location=no,resizable=no');", true);
        }

        protected void btnSaveCapabilities_Click(object sender, EventArgs e)
        {
            try
            {
                string Line = ((Capabilities)Session["Capabilities"]).Line;
                int Quantity = ((Capabilities)Session["Capabilities"]).Quantity;
                bool result = objTestBusiness.Update_Capabilities(Line, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, Quantity);
                if (result == true)
                {
                    lblError.Text = "Line " + ddlLine.SelectedItem.Text + " updated successfully";
                    lblError.ForeColor = Color.Green;
                    lblError.Visible = true;
                    BindGrid();
                }
                else
                {
                    lblError.Text = "Error updated Capability, please try again or call support!";
                    lblError.ForeColor = Color.Red;
                    lblError.Visible = true;
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
                txtQty.Text = "";
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