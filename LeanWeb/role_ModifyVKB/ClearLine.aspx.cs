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

using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

using System.Configuration;

using System.Data.OleDb;

namespace LeanWeb.role_ModifyVKB
{
    public partial class ClearLine : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
        ProdPrioritySession objProdPrioritySession = new ProdPrioritySession();
        TestBusiness objTestBusiness;
    //    clsGlobal objclsGlobal = new clsGlobal();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string test_1 = HiddenField1.Value;
            objTestBusiness = new TestBusiness();
            string LeanApp = ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
            DateTime Date = DateTime.Now;
            //syelamanchal--Adding roles functionality to user--start
            string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            if (objTestBusiness.Validate_UserInRole(UserName, "ModifyVKB") != 1)
            {
                Response.Redirect("~/LeanHome.aspx");
            }
            //syelamanchal--Adding roles functionality to user--end

            //string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
            Capabilities objCapabilities = new Capabilities();
            this.LabelStatus.Visible = false;
            try
            {
                if (!IsPostBack)
                {
                    HiddenField1.Value = Date.ToString();
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    objProdPrioritySession = (ProdPrioritySession)Session["ProdPrioritySession"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        txtFechaCaptura.Text = DateTime.Now.ToShortDateString();
                        Session["Capabilities"] = null;
                        objCapabilities.Line = Request.QueryString["line"];
                        objCapabilities.Quantity = Convert.ToInt32(Request.QueryString["qty"]);
                        Session["Capabilities"] = objCapabilities;
                        BindLine();
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

        //Query to fetch all values from database
        public string ConnectionString()
        {
            //string strConnectionString = ConfigurationManager.ConnectionStrings["LeanConnectionString"].ConnectionString;
            string strConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            return strConnectionString;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string Lean_Application= ((UserLoginInfo)Session["UserLoginInfo"]).Lean_App;
            DateTime DateTime = Convert.ToDateTime(HiddenField1.Value);
            string Date = DateTime.ToString("yyy/MM/dd");
            string Line = ddlLine.Text;
            int finalversion = chkFinalVersion(Date, Line, Lean_Application);
            if (finalversion == 0)
            {
                string strConnString = ConnectionString();
                SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                string strSQL = "UPDATE vkb SET [HeijunkaBoard_Pallets] = 0 FROM [VKB_Detail_PartNumber] vkb"
                    + " inner JOIN[VKB_Global_Line]  Gline ON Gline.[Lean_Application] = vkb.[Lean_Application] and vkb.[idvkb] = Gline.[idvkb]  "
                    + " inner JOIN[line] line ON Gline.idLine = line.idLine and Gline.[Lean_Application]=line.[Lean_Application]"
                    + " where    vkb.[Lean_Application] ='" + Lean_Application
                    + "' AND Date = '" + Date
                    + "' AND Line.Line ='" + Line + "'";
                SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
                cmd.Parameters.Add("@Lean_Application", SqlDbType.NVarChar).Value = Lean_Application;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@Line", SqlDbType.NVarChar).Value = Line;

                try
                {
                    SQLConn.Open();
                    cmd.ExecuteNonQuery();
                    SQLConn.Close();
                    SQLConn.Dispose();
                    LabelStatus.Visible = true;
                    LabelStatus.Text = "Heijunka Kanban Pallets with Line: " + Line + " and Date: " + DateTime.ToString("dd/MM/yyy") + " deleted successfully";
                    LabelStatus.ForeColor = Color.Green;
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
                finally
                {
                    SQLConn.Close();
                }
            }
            else
            {
                LabelStatus.Visible = true;
                LabelStatus.Text = "Heijunka Kanban Pallets with Line: " + Line + " and Date: " + DateTime.ToString("dd/MM/yyy") + " Can't be deleted as VKB is final version or does not exist.";
                LabelStatus.ForeColor = Color.Red;

            }
        }
        protected int chkFinalVersion(string Date, string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            
            //SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            using (var connection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                
                var sql = "Select Gline.[Final_Version] FROM [VKB_Detail_PartNumber] vkb"
                + " inner JOIN[VKB_Global_Line]  Gline ON Gline.[Lean_Application] = vkb.[Lean_Application] and vkb.[idvkb] = Gline.[idvkb]  "
                + " inner JOIN[line] line ON Gline.idLine = line.idLine and Gline.[Lean_Application]=line.[Lean_Application]"
                + " where    vkb.[Lean_Application] ='" + Lean_Application
                + "' AND Date = '" + Date
                + "' AND Line.Line ='" + Line + "'";
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {

                    cmd.Parameters.Add("@Lean_Application", SqlDbType.NVarChar).Value = Lean_Application;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                    cmd.Parameters.Add("@Line", SqlDbType.NVarChar).Value = Line;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            return Convert.ToInt32(reader[0]);
                        }
                       
                    }
                }
                connection.Close();
                connection.Dispose();

            }
            
                return 1;
           
        }
    }

   
}