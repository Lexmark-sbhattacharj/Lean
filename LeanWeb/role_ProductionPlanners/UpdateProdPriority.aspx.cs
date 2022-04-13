using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lean.Utilities;
using LeanBusiness;
using System.Data;

namespace LeanWeb.role_ProductionPlanners
{
    public partial class UpdateProdPriority : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ProdPrioritySession objProdPrioritySession = new ProdPrioritySession();
        TestBusiness objTestBusiness;

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
            objTestBusiness = new TestBusiness();
            try
            {
                if (!IsPostBack)
                {
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    objProdPrioritySession = (ProdPrioritySession)Session["ProdPrioritySession"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        BindDetailsView();
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
                int idLine_ddlLine = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLine;
                int idLine_gv_ddlLine = Convert.ToInt32(((DropDownList)((DetailsView)sender).FindControl("ddlPrioritize_LineEdit")).SelectedItem.Value);
                DateTime FilterDate = ((ProdPrioritySession)Session["ProdPrioritySession"]).FilterDate;
                string idLocalizationMaterial = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLocalizationMaterial;
                string Lean_Application = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
                int Production_Order = Convert.ToInt32(((DropDownList)((DetailsView)sender).FindControl("ddlProduction_OrderEdit")).SelectedItem.Value);
                string SAP_Order = (((TextBox)((DetailsView)sender).FindControl("txtSAP_OrderEdit"))).Text;
                int Minutes_Lost = Convert.ToInt32(((TextBox)((DetailsView)sender).FindControl("txtMinutes_LostEdit")).Text);
                int Pieces_Lost = Convert.ToInt32(((TextBox)((DetailsView)sender).FindControl("txtPieces_LostEdit")).Text);
                string Comments = ((TextBox)((DetailsView)sender).FindControl("txtCommentsEdit")).Text;
                string Upload_User = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                bool result = objTestBusiness.UpdateProduction_Prioritize(idLine_ddlLine, idLine_gv_ddlLine, FilterDate, idLocalizationMaterial, Lean_Application, Production_Order, SAP_Order, Minutes_Lost, Pieces_Lost, Comments, Upload_User);
                if (result == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateSuccess", "javascript:alert('Data Updated Successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgboxUpdateFailed", "javascript:alert('Data Updation Failed.');", true);
                }
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
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

        public void BindDetailsView()
        {
            try
            {
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

                drPriority["idLocalizationMaterial"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLocalizationMaterial;
                drPriority["idLine"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLine;
                drPriority["Production_Order"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Order;
                drPriority["Family"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Family;
                drPriority["idMaterial"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Model;
                drPriority["Pieces"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Quantity;
                drPriority["Pallets"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Pallets;
                drPriority["SAP_Order"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).SapOrder;
                drPriority["Minutes_Lost"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).MinuteLoss;
                drPriority["Pieces_Lost"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).PiecesLoss;
                if (((ProdPrioritySession)Session["ProdPrioritySession"]).Geo.ToUpper() == "SH" & ((ProdPrioritySession)Session["ProdPrioritySession"]).Model == "00")
                {
                    drPriority["Localization_Name"] = "DELL";
                }
                else
                {
                    drPriority["Localization_Name"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Geo;
                }
                drPriority["Comments"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Comments;
                drPriority["idToner"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Toner;
                drPriority["Type"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Type;
                drPriority["PPVT"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).PPVT;
                drPriority["Yield"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Yeild;
                drPriority["Pages"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Pages;
                drPriority["PrimaryPriority"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).VKBPriority;
                //drPriority["Family"] = ((ProdPrioritySession)Session["ProdPrioritySession"]).Family;
                dtPriority.Rows.Add(drPriority);

                ProdPriorityEdit.DataSource = dtPriority;
                ProdPriorityEdit.DataBind();
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
                DateTime Date = ((ProdPrioritySession)Session["ProdPrioritySession"]).FilterDate;
                int idLine = ((ProdPrioritySession)Session["ProdPrioritySession"]).idLine;

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
                            ddlProduction_Order.SelectedItem.Text = ((ProdPrioritySession)Session["ProdPrioritySession"]).Order.ToString();
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

        protected void ProdPriorityEdit_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("CANCEL"))
            {
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = window.close();");
            }
        }
    }
}