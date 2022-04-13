using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using Lean.Utilities;
using System.Data;
using LeanWeb.App_Code;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace LeanWeb.role_ModifyVKB
{
    public partial class PrioritizeProduction : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ProdPrioritySession objProdPrioritySession = new ProdPrioritySession();
        TestBusiness objTestBusiness;
        int Order = 0;

        //syelamanchal--preventing cross-site request forgery (csrf) attacks --start
        protected override void OnInit(EventArgs e)
        {
            ViewStateUserKey = Session.SessionID;
            base.OnInit(e);
        }
        //syelamanchal--preventing cross-site request forgery (csrf) attacks --end

        protected void Page_Load(object sender, EventArgs e)
        {
            objTestBusiness = new TestBusiness();
            //syelamanchal--csrf atack--start
            if ((Request.UrlReferrer == null || Request.Url.Host != Request.UrlReferrer.Host))
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            
            string urlReferrer;
            urlReferrer = Request.UrlReferrer.ToString();
            if (urlReferrer.Contains(Session["CurrentSite"].ToString()))
            {

            }
            else
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            
            if ((UserLoginInfo)Session["UserLoginInfo"] == null)
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
            //syelamanchal--csrf atack--end
            try
            {
                if (!IsPostBack)
                {
                    txtFechaCaptura.Text = DateTime.UtcNow.Date.ToString("d");
                    GetLine(Convert.ToDateTime(txtFechaCaptura.Text));
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    objProdPrioritySession = (ProdPrioritySession)Session["ProdPrioritySession"];
                    //syalamanchal--Yesterday's Last Material dropdown list --start
                    if (txtYesterdayMaterial.Text == string.Empty)
                    {
                        ddlYesterdayMaterial.DataTextField = "idMaterial";
                        ddlYesterdayMaterial.DataValueField = "idMaterial";
                        ddlYesterdayMaterial.DataMember = "idMaterial";
                        ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details("", ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                        ddlYesterdayMaterial.DataBind();
                    }
                    else
                    {
                        string Material = txtYesterdayMaterial.Text;
                        ddlYesterdayMaterial.DataTextField = "idMaterial";
                        ddlYesterdayMaterial.DataValueField = "idMaterial";
                        ddlYesterdayMaterial.DataMember = "idMaterial";
                        ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details(Material, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                        ddlYesterdayMaterial.DataBind();
                    }
                    //syalamanchal--Yesterday's Last Material dropdown list --end	
                    if (Session["UserLoginInfo"] != null)
                    {
                        //BindGridData();
                        lblLastMaterial.Visible = false;
                        txtYesterdayMaterial.Visible = false;
                        ddlYesterdayMaterial.Visible = false;
                        btnAutomaticPriority.Visible = false;
                        btnGetYestardayMaterial.Visible = false;
                        btnSplitPallets.Visible = false;
                        btnRestoreHeijunkaBoard.Visible = false;
                        //OpenPopUp(btnRestoreHeijunkaBoard, "~/Home.aspx", "", 300, 300);
                        if (Session["ProdPrioritySession"] != null)
                        {
                            txtFechaCaptura.Text = ((ProdPrioritySession)Session["ProdPrioritySession"]).FilterDate.ToShortDateString();
                            GetLine(((ProdPrioritySession)Session["ProdPrioritySession"]).FilterDate);
                            ddlLine.SelectedValue = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLine.ToString();
                            BindGridData();
                            lblLastMaterial.Visible = true;
                            txtYesterdayMaterial.Visible = true;
                            ddlYesterdayMaterial.Visible = true;
                            btnAutomaticPriority.Visible = true;
                            btnGetYestardayMaterial.Visible = true;
                            btnSplitPallets.Visible = true;
                            btnRestoreHeijunkaBoard.Visible = true;
                            Session["ProdPrioritySession"] = null;
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

        public void BindGridData()
        {
            try
            {
                bool bolForceReorder = false;
                DataSet ds = default(DataSet);
                DataSet dsMaterial = default(DataSet);
                DataRow drPriority = default(DataRow);
                string stridMaterial = null;
                string stridToner = null;
                string strFamily = null;
                string strType = null;
                int intPages = 0;
                //Page.Header.Title = "Plan " + ddlLine.SelectedItem.Text;
                DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                try
                {
                    DataTable dtPriority = new DataTable();
                    DataRow[] dRowsToOrder = null;
                    DataRow[] dFoundRows = null;
                    int intTotalOrder = 0;
                    int intOrder = 1;
                    dtPriority.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Date", Type.GetType("System.String"));
                    dtPriority.Columns.Add("idLine", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("Line", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Production_Order", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("Family", Type.GetType("System.String"));
                    dtPriority.Columns.Add("idMaterial", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Pieces", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("Pallets", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("SAP_Order", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Minutes_Lost", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("Pieces_Lost", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("Localization_Name", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Comments", Type.GetType("System.String"));
                    dtPriority.Columns.Add("idToner", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Type", Type.GetType("System.String"));
                    dtPriority.Columns.Add("PPVT", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Yield", Type.GetType("System.String"));
                    dtPriority.Columns.Add("Pages", Type.GetType("System.Decimal"));
                    dtPriority.Columns.Add("PrimaryPriority", Type.GetType("System.Decimal"));

                    //Get [Production_Prioritize]

                    ds = objTestBusiness.getProd_priority(Date, idLine, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                    //Fill DATA TABLE

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Get Saved Priority
                        //Process Priority
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            drPriority = dtPriority.NewRow();
                            drPriority["idLocalizationMaterial"] = dr["idLocalizationMaterial"].ToString().ToUpper();
                            drPriority["idLine"] = dr["idLine"].ToString();
                            drPriority["Line"] = dr["Line"].ToString();
                            drPriority["Production_Order"] = dr["Production_Order"].ToString();
                            drPriority["Family"] = dr["Family"].ToString().ToUpper();
                            drPriority["idMaterial"] = dr["idMaterial"].ToString().ToUpper();
                            drPriority["Pieces"] = (dr["Pieces"].ToString());
                            drPriority["Pallets"] = (dr["Pallets"].ToString());
                            drPriority["SAP_Order"] = (dr["SAP_Order"].ToString().ToUpper());
                            drPriority["Minutes_Lost"] = (dr["Minutes_Lost"].ToString());
                            drPriority["Pieces_Lost"] = (dr["Pieces_Lost"].ToString());
                            if (dr["Localization_Name"].ToString().ToUpper() == "SH" & dr["idMaterial"].ToString().ToUpper() == "00")
                            {
                                drPriority["Localization_Name"] = "DELL";
                            }
                            else
                            {
                                drPriority["Localization_Name"] = (dr["Localization_Name"].ToString().ToUpper());
                            }
                            drPriority["Comments"] = (dr["Comments"].ToString().ToUpper());
                            drPriority["idToner"] = (dr["idToner"].ToString().ToUpper());
                            drPriority["Type"] = (dr["Type"].ToString().ToUpper());
                            drPriority["PPVT"] = (dr["PPVT"].ToString());
                            drPriority["Yield"] = (dr["Yield"].ToString());
                            drPriority["Type"] = (dr["Type"].ToString().ToUpper());
                            drPriority["Pages"] = (dr["Pages"].ToString());
                            drPriority["PrimaryPriority"] = dr["PrimaryPriority"].ToString();
                            intTotalOrder = intTotalOrder + Convert.ToInt32(drPriority["Production_Order"]);
                            dtPriority.Rows.Add(drPriority);
                        }

                        //CREATE ORDER
                        if (intTotalOrder == 0 | bolForceReorder)
                        {
                            if (bolForceReorder)
                            {
                                //Base on selected material
                                //dsMaterial = getLastMaterial(ddlYesterdayMaterial.SelectedItem.Value, mySQLDbSqlConn);
                                foreach (DataRow dr in dtPriority.Rows)
                                {
                                    dr["Production_Order"] = 0;
                                }
                            }
                            else
                            {
                                //Get last material run on line
                                //dsMaterial = getLastMaterial("", mySQLDbSqlConn);
                            }

                            stridMaterial = "";
                            stridToner = "";
                            strFamily = "";
                            strType = "";
                            intPages = -1;

                            if ((dsMaterial != null))
                            {
                                if (dsMaterial.Tables[0].Rows.Count > 0)
                                {
                                    ddlYesterdayMaterial.SelectedValue = dsMaterial.Tables[0].Rows[0]["idMaterial"].ToString();
                                    stridMaterial = dsMaterial.Tables[0].Rows[0]["idMaterial"].ToString();
                                    stridToner = dsMaterial.Tables[0].Rows[0]["idToner"].ToString();
                                    strFamily = dsMaterial.Tables[0].Rows[0]["Family"].ToString();
                                    strType = dsMaterial.Tables[0].Rows[0]["Type"].ToString();
                                    intPages = Convert.ToInt32(dsMaterial.Tables[0].Rows[0]["Pages"]);
                                }
                            }
                            //syalamanchili
                           // dRowsToOrder = dtPriority.Select("", "Production_Order=0");
                            dRowsToOrder = dtPriority.Select("Production_Order=0");
                            while (dRowsToOrder.Length > 0)
                            {
                                //1 - 1) Same Part Number
                                dFoundRows = dtPriority.Select("Production_Order=0 AND idMaterial='" + stridMaterial + "'", "PrimaryPriority desc");
                                if (dFoundRows.Length > 0)
                                {
                                    dFoundRows[0]["Production_Order"] = intOrder;
                                    intOrder = intOrder + 1;
                                }
                                else
                                {
                                    //2 - 2) Same Tonner '3) Same Family '4) Same Type
                                    dFoundRows = dtPriority.Select("Production_Order=0 AND idToner='" + stridToner + "' AND Family='" + strFamily + "' AND Type='" + strType + "'", "PrimaryPriority desc");
                                    if (dFoundRows.Length > 0)
                                    {
                                        dFoundRows[0]["Production_Order"] = intOrder;
                                        intOrder = intOrder + 1;
                                    }
                                    else
                                    {
                                        //3 - 2) Same Tonner '3) Same Family 
                                        dFoundRows = dtPriority.Select("Production_Order=0 AND idToner='" + stridToner + "' AND Family='" + strFamily + "'", "PrimaryPriority desc");
                                        if (dFoundRows.Length > 0)
                                        {
                                            dFoundRows[0]["Production_Order"] = intOrder;
                                            intOrder = intOrder + 1;
                                        }
                                        else
                                        {
                                            //4 - 2) Same Tonner
                                            dFoundRows = dtPriority.Select("Production_Order=0 AND idToner='" + stridToner + "'", "PrimaryPriority desc");
                                            if (dFoundRows.Length > 0)
                                            {
                                                dFoundRows[0]["Production_Order"] = intOrder;
                                                intOrder = intOrder + 1;
                                            }
                                            else
                                            {
                                                //5 - '3) Same Family '4) Same Type
                                                dFoundRows = dtPriority.Select("Production_Order=0 AND Family='" + strFamily + "' AND Type='" + strType + "'", "PrimaryPriority desc");
                                                if (dFoundRows.Length > 0)
                                                {
                                                    dFoundRows[0]["Production_Order"] = intOrder;
                                                    intOrder = intOrder + 1;
                                                }
                                                else
                                                {
                                                    //6 - '3) Same Family
                                                    dFoundRows = dtPriority.Select("Production_Order=0 AND Family='" + strFamily + "'", "PrimaryPriority desc");
                                                    if (dFoundRows.Length > 0)
                                                    {
                                                        dFoundRows[0]["Production_Order"] = intOrder;
                                                        intOrder = intOrder + 1;
                                                    }
                                                    else
                                                    {
                                                        //7 - 4) Same Type
                                                        dFoundRows = dtPriority.Select("Production_Order=0 AND Type='" + strType + "'", "PrimaryPriority desc");
                                                        if (dFoundRows.Length > 0)
                                                        {
                                                            dFoundRows[0]["Production_Order"] = intOrder;
                                                            intOrder = intOrder + 1;
                                                        }
                                                        else
                                                        {
                                                            //8 -5) Same Pages
                                                            dFoundRows = dtPriority.Select("Production_Order=0 AND Pages=" + intPages, "PrimaryPriority desc");
                                                            if (dFoundRows.Length > 0)
                                                            {
                                                                dFoundRows[0]["Production_Order"] = intOrder;
                                                                intOrder = intOrder + 1;
                                                            }
                                                            else
                                                            {
                                                                //9 -6) Primary Priority
                                                                dFoundRows = dtPriority.Select("Production_Order=0", "PrimaryPriority desc");
                                                                if (dFoundRows.Length > 0)
                                                                {
                                                                    dFoundRows[0]["Production_Order"] = intOrder;
                                                                    intOrder = intOrder + 1;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                dFoundRows = dtPriority.Select("", "Production_Order desc");
                                if (dFoundRows.Length > 0)
                                {
                                    stridMaterial = dFoundRows[0]["idMaterial"].ToString();
                                    stridToner = dFoundRows[0]["idToner"].ToString();
                                    strFamily = dFoundRows[0]["Family"].ToString();
                                    strType = dFoundRows[0]["Type"].ToString();
                                    intPages = Convert.ToInt32(dFoundRows[0]["Pages"]);
                                }

                                dRowsToOrder = dtPriority.Select("Production_Order=0");
                            }
                        }

                        //BASED ON ORDER
                        dtPriority.DefaultView.Sort = "Production_Order";
                        dtPriority = dtPriority.DefaultView.ToTable();
                    }

                    //Link with GRID VIEW
                    gvPrioritize.DataSource = dtPriority;
                    gvPrioritize.DataBind();


                    //Make Visible DIV
                    //workOnGrid(true);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error showing priotritization grid. " + ex.Message;
                    lblStatus.ForeColor = Color.Red;
                    //divPrioritize.Visible = false;
                    //clsGlobal = null;
                    dsMaterial = null;
                    ds = null;

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

        protected void btnPrioritize_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                BindGridData();
                lblLastMaterial.Visible = true;
                txtYesterdayMaterial.Visible = true;
                ddlYesterdayMaterial.Visible = true;
                btnAutomaticPriority.Visible = true;
                btnGetYestardayMaterial.Visible = true;
                btnSplitPallets.Visible = true;
                btnRestoreHeijunkaBoard.Visible = true;

                ddlSplitMaterial.DataTextField = "idMaterial";
                ddlSplitMaterial.DataValueField = "idLocalizationMaterial";
                ddlSplitMaterial.DataMember = "idMaterial";
                ddlSplitMaterial.DataSource = objTestBusiness.get_Split_Material(Date, idLine, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlSplitMaterial.DataBind();
                //syalamanchili--extra data--start
                //ddlSplitLine.DataTextField = "Line";
                //ddlSplitLine.DataValueField = "idLine";
                //ddlSplitLine.DataMember = "Line";
                //ddlSplitLine.DataSource = objTestBusiness.get_Split_Line(Date, idLine, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                //ddlSplitLine.DataBind();
                //syalamanchili--extra data--end
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

        public void GetLine(DateTime Date)
        {
            try
            {
                //DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                ddlLine.DataTextField = "Line";
                ddlLine.DataValueField = "idLine";
                ddlLine.DataMember = "Line";
                ddlLine.DataSource = objTestBusiness.getVKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Details(Date, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
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

        protected void btnLine_Click(object sender, EventArgs e)
        {
            GetLine(Convert.ToDateTime(txtFechaCaptura.Text));
        }

        protected void gvPrioritize_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DropDownList ddlPrioritize_Line = (DropDownList)e.Row.FindControl("ddlPrioritize_Line");
                        ddlPrioritize_Line.DataSource = objTestBusiness.getVKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Details(Date, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                        ddlPrioritize_Line.DataTextField = "Line";
                        ddlPrioritize_Line.DataValueField = "idLine";
                        ddlPrioritize_Line.DataMember = "Line";
                        ddlPrioritize_Line.DataBind();
                        ddlPrioritize_Line.SelectedValue = idLine.ToString();

                        DropDownList ddlProduction_Order = (DropDownList)e.Row.FindControl("ddlProduction_Order");
                        for (int i = 0; i <= 50; i++)
                        {
                            ddlProduction_Order.Items.Add(i.ToString());
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

        protected void btnSplitPallets_Click(object sender, EventArgs e)
        {
            gvPrioritize.EditIndex = -1;
            divSplit.Visible = true;
            gvPrioritize.Enabled = false;
            btnSplitPallets.Enabled = false;
            btnRestoreHeijunkaBoard.Enabled = false;
            //fillSplitData();
            //syalamanchili-- Added to Get Line--start
            DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
            ddlSplitLine.DataTextField = "Line";
            ddlSplitLine.DataValueField = "idLine";
            ddlSplitLine.DataMember = "Line";
            ddlSplitLine.DataSource = objTestBusiness.getVKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Details(Date, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
            ddlSplitLine.DataBind();
            //syalamanchili-- Added to Get Line--End
        }

        protected void btnCancelSplit_Click(object sender, EventArgs e)
        {
            divSplit.Visible = false;
            gvPrioritize.Enabled = true;
            btnSplitPallets.Enabled = true;
            btnRestoreHeijunkaBoard.Enabled = true;
        }

        protected void btnGetYestardayMaterial_Click(object sender, EventArgs e)
        {
            if (txtYesterdayMaterial.Text == string.Empty)
            {
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details("", ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
            else
            {
                string Material = txtYesterdayMaterial.Text;
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details(Material, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
        }

        /* protected void btnRestoreHeijunkaBoard_Click(object sender, EventArgs e)
         {
             //Response.Write("<script>window.open('WebForm1.aspx', 'hello', 'width=700,height=400,scrollbars=yes,toolbar=no,menubar=no,location=no');</script>");

         }*/

        protected void btnRestoreHeijunkaBoard_Click(object sender, System.EventArgs e)
        {
           // DataRow dr;
            string strConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            SqlConnection  mySQLDbSqlConn = new System.Data.SqlClient.SqlConnection(strConnectionString);
            mySQLDbSqlConn.Open();
            clsGlobal objclsglobal = new clsGlobal();
            try
            {
                string strSQLMaterial;
                DataSet dsMaterial;
                strSQLMaterial = "SELECT [idLocalizationMaterial],[HeijunkaBoard_Pallets],[PrimaryPriority] " + " FROM [VKB_Global_Line] " + " INNER JOIN [VKB_Detail_PartNumber] " + " ON [VKB_Global_Line].[idVKB]=[VKB_Detail_PartNumber].[idVKB] " + " WHERE [HeijunkaBoard_Pallets] > 0 " + " AND [idLine]=" + this.ddlLine.SelectedItem.Value + " AND [Date]='" + Convert.ToDateTime(txtFechaCaptura.Text).ToString("yyyy-MM-dd") + "' and VKB_Global_Line.Lean_Application='" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'";
                dsMaterial = objclsglobal.getTableSQL(strSQLMaterial, mySQLDbSqlConn);
               // strSQLMaterial = "";
                if (!(dsMaterial == null))
                {
                    if (dsMaterial.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsMaterial.Tables[0].Rows)
                            strSQLMaterial = strSQLMaterial + " SELECT " + " '" + dr["idLocalizationMaterial"].ToString().ToUpper() + "' " + " ," + ddlLine.SelectedItem.Value + " " + " ,'" + Convert.ToDateTime(txtFechaCaptura.Text).ToString("yyyy-MM-dd") + "' " + " ,0 " + " ," + dr["HeijunkaBoard_Pallets"].ToString() + " " + " ," + dr["PrimaryPriority"].ToString() + " " + " ,'" + User.Identity.Name + "'" + " ,getdate() " + " ," + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + " UNION ALL ";


                        // Delete Current Priority
                        objclsglobal.updateTable("DELETE FROM [Production_Prioritize] WHERE [idLine]=" + this.ddlLine.SelectedItem.Value + " AND [Date]='" + Convert.ToDateTime(txtFechaCaptura.Text).ToString("yyyy-MM-dd") + "' AND Lean_Application = '" + ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App + "'", mySQLDbSqlConn);

                        // Insert New Production Priority
                        strSQLMaterial = strSQLMaterial.Substring(strSQLMaterial.Length - 10);

                        strSQLMaterial = " INSERT INTO [Production_Prioritize] " + " ([idLocalizationMaterial] " + " ,[idLine] " + " ,[Date] " + " ,[Production_Order] " + " ,[Pallets] " + " ,[PrimaryPriority] " + " ,[Upload_User] " + " ,[Upload_Date]" + " ,[Lean_Application])" + strSQLMaterial;
                        if (strSQLMaterial.Length > 0)
                        {
                            if (!objclsglobal.updateTable(strSQLMaterial, mySQLDbSqlConn))
                            {
                                lblStatus.Text = "Error restoring heijunka board values.";
                                lblStatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblStatus.Text = "Heijunka Board Restored!!, please review other lines to remove production related production this line";
                                lblStatus.ForeColor = Color.Green;
                                BindGridData();
                            }
                        }
                    }
                    else
                    {
                        LabelStatusSplit.Text = "Error getting material information to restore.";
                        LabelStatusSplit.ForeColor = Color.Red;
                    }
                }
                else
                {
                    LabelStatusSplit.Text = "Error getting material information to restore.";
                    LabelStatusSplit.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LabelStatusSplit.Text = "Error getting material information to restore."+ex;
                LabelStatusSplit.ForeColor = Color.Red;
           
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
                objclsglobal = null;
                if (mySQLDbSqlConn.State != ConnectionState.Open)
                    mySQLDbSqlConn.Close();
            }
        }


        public void fillSplitData()
        {
            DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
            int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
            string idMaterial;
            //syalamanchal--exception due to empty string--start
            try
            {
                 idMaterial = ddlSplitMaterial.SelectedItem.Value;
            }
            catch (Exception ex)
            {
                idMaterial = "";
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
            //syalamanchal--exception due to empty string--end
            if (ddlSplitMaterial.SelectedIndex > -1)
            {
                try
                {
                    DataSet dsMaterial = default(DataSet);
                    dsMaterial = objTestBusiness.get_Split(Date, idLine, idMaterial, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                    if ((dsMaterial != null))
                    {
                        if (dsMaterial.Tables[0].Rows.Count > 0)
                        {
                            txtGEO.Text = dsMaterial.Tables[0].Rows[0]["Localization_Name"].ToString();
                            txtPallets.Text = dsMaterial.Tables[0].Rows[0]["Pallets"].ToString();
                            if (Convert.ToDecimal(txtPallets.Text) > 1)
                            {
                                LabelStatusSplit.Text = "";
                                ddlSplitLine.Enabled = true;
                                txtSplitPallets.Enabled = true;
                                btnAcceptSplit.Enabled = true;
                            }
                            else
                            {
                                LabelStatusSplit.Text = "Not enough material to create a pallet split.";
                                LabelStatusSplit.ForeColor = Color.Red;
                                ddlSplitLine.Enabled = false;
                                txtSplitPallets.Enabled = false;
                                btnAcceptSplit.Enabled = false;
                            }
                        }
                        else
                        {
                            txtGEO.Text = "";
                            txtPallets.Text = "";
                            ddlSplitLine.Enabled = false;
                            txtSplitPallets.Enabled = false;
                            btnAcceptSplit.Enabled = false;
                        }
                    }
                    else
                    {
                        txtGEO.Text = "";
                        txtPallets.Text = "";
                        ddlSplitLine.Enabled = false;
                        txtSplitPallets.Enabled = false;
                        btnAcceptSplit.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    LabelStatusSplit.Text = "Error getting material information.";
                    LabelStatusSplit.ForeColor = Color.Red;
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

        protected void ddlSplitLine_DataBound(object sender, EventArgs e)
        {
            fillSplitData();
        }

        protected void ddlSplitLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSplitData();
        }

        protected void btnAcceptSplit_Click(object sender, EventArgs e)
        {
            btnAcceptSplit.Enabled = false;
            btnCancelSplit.Enabled = false;
            string idMaterial = ddlSplitMaterial.SelectedItem.Value;
            DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
            int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
            int idLine_Destiny = Convert.ToInt32(ddlSplitLine.SelectedItem.Value);
            int Pallets = Convert.ToInt32(txtPallets.Text);
            int split_Pallets = Convert.ToInt32(txtSplitPallets.Text);
            try
            {
                if (Convert.ToInt32(txtSplitPallets.Text) > 0 & ddlSplitLine.SelectedIndex > -1)
                {
                    if (Convert.ToDecimal(txtSplitPallets.Text) < Convert.ToDecimal(txtPallets.Text))
                    {
                        int count = objTestBusiness.get_Split_Count(Date, idLine, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, idMaterial);
                        if (count > 0)
                        {
                            bool result = objTestBusiness.Update_Split_Prod_Priority(idLine, idLine_Destiny, Date, idMaterial, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App, Pallets, split_Pallets, ((UserLoginInfo)Session["UserLoginInfo"]).UserID);
                            if (result == true)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Pallet Splitted!!');", true);
                                fillSplitData();
                                btnAcceptSplit.Enabled = true;
                                btnCancelSplit.Enabled = true;
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Error inserting SEND TO pallets.');", true);
                            }
                        }
                        else
                        {
                            lblgvStatus.Text = "Error inserting SEND TO pallets.";
                            lblgvStatus.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        LabelStatusSplit.Text = "Pallets to split could not be greater or equal to original pallets.";
                        LabelStatusSplit.ForeColor = Color.Red;
                    }
                }
                else
                {
                    LabelStatusSplit.Text = "Select a line and define number of pallets to send.";
                    LabelStatusSplit.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LabelStatusSplit.Text = "Error getting material information.";
                LabelStatusSplit.ForeColor = Color.Red;
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

        public static void OpenPopUp(System.Web.UI.WebControls.WebControl opener, string PagePath, string windowName, int width, int height)
        {
            string clientScript = null;
            string windowAttribs = null;

            windowAttribs = "width=" + width + "px," + "height=" + height + "px," + "left='+((screen.width -" + width + ") / 2)+'," + "top='+ (screen.height - " + height + ") / 2+'";

            clientScript = "window.showModalDialog('" + PagePath + "','" + windowName + "','" + windowAttribs + "');return true;";
            opener.Attributes.Add("onClick", clientScript);

        }

        protected void OpenWindow(object sender, EventArgs e)
        {
            string url = "~/Home.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void gvPrioritize_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITROW"))
                {
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                        ImageButton imgbtnEdit = (ImageButton)row.FindControl("imgbtnEdit");
                        Label lbl = (Label)row.FindControl("lblLineView");
                        string a = lbl.Text;
                        Order = Convert.ToInt32(((Label)row.FindControl("lblProduction_OrderView")).Text);
                        //syalamanchali--uncommenting existing code--start
                        objProdPrioritySession.idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                        objProdPrioritySession.FilterDate = Convert.ToDateTime(txtFechaCaptura.Text);
                        objProdPrioritySession.idLocalizationMaterial = ((Label)row.FindControl("lblidLocalizationMaterialView")).Text;
                        objProdPrioritySession.SapOrder = ((Label)row.FindControl("lblSAP_OrderView")).Text;
                        objProdPrioritySession.MinuteLoss = Convert.ToInt32(((Label)row.FindControl("lblMinutes_LostView")).Text);
                        objProdPrioritySession.PiecesLoss = Convert.ToInt32(((Label)row.FindControl("lblPieces_LostView")).Text);
                        objProdPrioritySession.Comments = ((Label)row.FindControl("lblCommentsView")).Text;
                        objProdPrioritySession.Family = ((Label)row.FindControl("lblFamilyView")).Text;
                        objProdPrioritySession.Model = ((Label)row.FindControl("lblModelView")).Text;
                        objProdPrioritySession.Quantity = Convert.ToInt32(((Label)row.FindControl("lblQuantityView")).Text);
                        objProdPrioritySession.Pallets = Convert.ToInt32(((Label)row.FindControl("lblPalletsView")).Text);
                        objProdPrioritySession.Geo = ((Label)row.FindControl("lblGeoView")).Text;
                        objProdPrioritySession.Toner = ((Label)row.FindControl("lblTonerView")).Text;
                        objProdPrioritySession.PPVT = ((Label)row.FindControl("lblPPVTView")).Text;
                        objProdPrioritySession.Yeild = ((Label)row.FindControl("lblYieldView")).Text;
                        objProdPrioritySession.Type = ((Label)row.FindControl("lblTypeView")).Text;
                        objProdPrioritySession.Pages = ((Label)row.FindControl("lblPagesView")).Text;
                        objProdPrioritySession.VKBPriority = ((Label)row.FindControl("lblVKB_PriorityView")).Text;
                        objProdPrioritySession.Order = Convert.ToInt32(((Label)row.FindControl("lblProduction_OrderView")).Text);
                        Session["ProdPrioritySession"] = objProdPrioritySession;
                        //syalamanchali--uncommenting existing code--end

                        DataTable dtPriority = new DataTable();
                        DataRow drPriority = default(DataRow);
                        dtPriority.Columns.Add("idLocalizationMaterial", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Date", Type.GetType("System.String"));
                        dtPriority.Columns.Add("idLine", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("Production_Order", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("Family", Type.GetType("System.String"));
                        dtPriority.Columns.Add("idMaterial", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Pieces", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("Pallets", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("SAP_Order", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Minutes_Lost", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("Pieces_Lost", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("Localization_Name", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Comments", Type.GetType("System.String"));
                        dtPriority.Columns.Add("idToner", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Type", Type.GetType("System.String"));
                        dtPriority.Columns.Add("PPVT", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Yield", Type.GetType("System.String"));
                        dtPriority.Columns.Add("Pages", Type.GetType("System.Decimal"));
                        dtPriority.Columns.Add("PrimaryPriority", Type.GetType("System.Decimal"));

                        drPriority = dtPriority.NewRow();

                        drPriority["idLocalizationMaterial"] = ((Label)row.FindControl("lblidLocalizationMaterialView")).Text;
                        drPriority["idLine"] = Convert.ToInt32(ddlLine.SelectedItem.Value);
                        drPriority["Production_Order"] = Convert.ToInt32(((Label)row.FindControl("lblProduction_OrderView")).Text);
                        drPriority["Family"] = ((Label)row.FindControl("lblFamilyView")).Text;
                        drPriority["idMaterial"] = ((Label)row.FindControl("lblModelView")).Text;
                        drPriority["Pieces"] = Convert.ToInt32(((Label)row.FindControl("lblQuantityView")).Text);
                        drPriority["Pallets"] = Convert.ToInt32(((Label)row.FindControl("lblPalletsView")).Text);
                        drPriority["SAP_Order"] = ((Label)row.FindControl("lblSAP_OrderView")).Text;
                        drPriority["Minutes_Lost"] = Convert.ToInt32(((Label)row.FindControl("lblMinutes_LostView")).Text);
                        drPriority["Pieces_Lost"] = Convert.ToInt32(((Label)row.FindControl("lblPieces_LostView")).Text);
                        if (((Label)row.FindControl("lblGeoView")).Text.ToUpper() == "SH" & ((Label)row.FindControl("lblModelView")).Text == "00")
                        {
                            drPriority["Localization_Name"] = "DELL";
                        }
                        else
                        {
                            drPriority["Localization_Name"] = ((Label)row.FindControl("lblGeoView")).Text;
                        }
                        drPriority["Comments"] = ((Label)row.FindControl("lblCommentsView")).Text;
                        drPriority["idToner"] = ((Label)row.FindControl("lblTonerView")).Text;
                        drPriority["Type"] = ((Label)row.FindControl("lblTypeView")).Text;
                        drPriority["PPVT"] = ((Label)row.FindControl("lblPPVTView")).Text;
                        drPriority["Yield"] = ((Label)row.FindControl("lblYieldView")).Text;
                        drPriority["Pages"] = ((Label)row.FindControl("lblPagesView")).Text;
                        drPriority["PrimaryPriority"] = ((Label)row.FindControl("lblVKB_PriorityView")).Text;
                        //drPriority["Family"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Family;
                        dtPriority.Rows.Add(drPriority);

                        ProdPriorityEdit.DataSource = dtPriority;
                        ProdPriorityEdit.DataBind();
						//syalamanchali--edit grid fixing and UI changes--start
						ProdPriorityEdit.Visible = true;
	                    gvPrioritize.Visible = false;
						//syalamanchali--edit grid fixing and UI changes--End


                        //ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:window.open('UpdateProdPriority.aspx', 'hello', 'width=700px,height=400px,left=((screen.width -700) / 2),top=((screen.height - 400) / 2),scrollbars=yes,toolbar=no,menubar=no,location=no');", true);
                        //OpenPopUp(imgbtnEdit, "~/Home.aspx", "", 300, 300);$("#dialog-message").dialog("open");
                        //syalamanchili--closing popup is refreshing page--start
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "msgboxUpdateSuccess", "$(function () {$('#dialog-message').dialog({autoOpen: false,modal: true,width: 'auto',height: '700',buttons: {Ok: function () {},Cancel: function () {location.reload();}}}); $('#dialog-message').dialog('open'); return false;});", true);
                        //syalamanchili--remove ok close buttons--start    
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "msgboxUpdateSuccess", "$(function () {$('#dialog-message').dialog({autoOpen: false,modal: true,width: 'auto',height: '700',buttons: {Ok: function () {$('#dialog-message').dialog('close');},Cancel: function () {$('#dialog-message').dialog('close');}}}); $('#dialog-message').dialog('open'); return false;});", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msgboxUpdateSuccess", "$(function () {$('#dialog-message').dialog({autoOpen: false,modal: true,width: 'auto',height: '700'}); $('#dialog-message').dialog('open'); return false;});", true);
                        //syalamanchili--remove ok close buttons--end    
                        //syalamanchili--closing popup is refreshing page--end
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

        protected void ProdPriorityEdit_DataBound(object sender, EventArgs e)
        {
            try
            {
                DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);

                if (((DetailsView)sender).CurrentMode == DetailsViewMode.Edit)
                {
                    DataRowView row = (DataRowView)((DetailsView)sender).DataItem;
                    DropDownList ddlPrioritize_Line = (DropDownList)((DetailsView)sender).FindControl("ddlPrioritize_LineEdit");
                    if (ddlPrioritize_Line != null)
                    {
                        ddlPrioritize_Line.DataTextField = "Line";
                        ddlPrioritize_Line.DataValueField = "idLine";
                        ddlPrioritize_Line.DataMember = "Line";
                        ddlPrioritize_Line.DataSource = objTestBusiness.getVKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Details(Date, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                        ddlPrioritize_Line.DataBind();
                        ddlPrioritize_Line.SelectedValue = idLine.ToString();
                    }

                    DropDownList ddlProduction_Order = (DropDownList)((DetailsView)sender).FindControl("ddlProduction_OrderEdit");
                    if (ddlProduction_Order != null)
                    {
                        for (int i = 0; i <= 50; i++)
                        {
                            ddlProduction_Order.Items.Add(i.ToString());
                            ddlProduction_Order.SelectedItem.Text = Order.ToString();
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

        protected void ProdPriorityEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            try
            {
                int idLine_ddlLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                int idLine_gv_ddlLine = Convert.ToInt32(((DropDownList)((DetailsView)sender).FindControl("ddlPrioritize_LineEdit")).SelectedItem.Value);
                DateTime FilterDate = ((ProdPrioritySession)Session["ProdPrioritySession"]).FilterDate;
                //DateTime FilterDate = DateTime.Parse(txtFechaCaptura.Text);
                string idLocalizationMaterial = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLocalizationMaterial;
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                int Production_Order = Convert.ToInt32(((DropDownList)((DetailsView)sender).FindControl("ddlProduction_OrderEdit")).SelectedItem.Value);
                string SAP_Order = (((TextBox)((DetailsView)sender).FindControl("txtSAP_OrderEdit"))).Text;
                //syalamanchal--exception due to empty string--start
                int Minutes_Lost =0, Pieces_Lost=0;
                if (((TextBox)((DetailsView)sender).FindControl("txtMinutes_LostEdit")).Text != "")
                {
                    Minutes_Lost = Convert.ToInt32(((TextBox)((DetailsView)sender).FindControl("txtMinutes_LostEdit")).Text);
                }
                if (((TextBox)((DetailsView)sender).FindControl("txtPieces_LostEdit")).Text != "")
                {
                    Pieces_Lost = Convert.ToInt32(((TextBox)((DetailsView)sender).FindControl("txtPieces_LostEdit")).Text);
                }
                //syalamanchal--exception due to empty string--end
                string Comments = ((TextBox)((DetailsView)sender).FindControl("txtCommentsEdit")).Text;
                string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                bool result = objTestBusiness.UpdateProduction_Prioritize(idLine_ddlLine, idLine_gv_ddlLine, FilterDate, idLocalizationMaterial, Lean_Application, Production_Order, SAP_Order, Minutes_Lost, Pieces_Lost, Comments, Upload_User);
                //syalamanchali--edit grid fixing and UI changes--start
				ProdPriorityEdit.Visible = false;
	            gvPrioritize.Visible = true;
				//syalamanchali--edit grid fixing and UI changes--End

				if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
                //syalamanchal--refresh grid--start
                DateTime Date = Convert.ToDateTime(txtFechaCaptura.Text);
                int idLine = Convert.ToInt32(ddlLine.SelectedItem.Value);
                BindGridData();
                //syalamanchal--refresh grid--end
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
        //syalamanchili--Fixing date and line dropdowns to fetch data--start
        protected void txtFechaCaptura_TextChanged(object sender, EventArgs e)
        {
            GetLine(Convert.ToDateTime(txtFechaCaptura.Text));
            if (txtYesterdayMaterial.Text == string.Empty)
            {
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details("", ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
            else
            {
                string Material = txtYesterdayMaterial.Text;
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details(Material, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
        }

        protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    GetLine(Convert.ToDateTime(txtFechaCaptura.Text));
            if (txtYesterdayMaterial.Text == string.Empty)
            {
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details("", ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
            else
            {
                string Material = txtYesterdayMaterial.Text;
                ddlYesterdayMaterial.DataTextField = "idMaterial";
                ddlYesterdayMaterial.DataValueField = "idMaterial";
                ddlYesterdayMaterial.DataMember = "idMaterial";
                ddlYesterdayMaterial.DataSource = objTestBusiness.getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details(Material, ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App);
                ddlYesterdayMaterial.DataBind();
            }
        }
        //syalamanchili--Fixing date and line dropdowns to fetch data--end
        //syalamanchili--close button in popup--start
        public void ProdPriorityEdit_Close(object sender, EventArgs e)
        {
            //if (e.CommandName.ToUpper().Equals("EDITROW"))
           // {            
						//syalamanchali--edit grid fixing and UI changes--start
						//ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "j$(function () {$('#dialog-message').dialog('close');}", true);
						ProdPriorityEdit.Visible = false;
	                    gvPrioritize.Visible = true;
						//syalamanchali--edit grid fixing and UI changes--End

           // }
        }

        //syalamanchili--close button in popup--start
    }
}