using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace LeanWeb.role_DefineParameters
{
    public partial class Platforms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Lean_Application"] = "JUALS";
            if (!IsPostBack)
            {
                LEAN_APP.Value = Session["Lean_Application"].ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(Session["Lean_Application"].ToString()))
                {
                    Response.Redirect("../Login.aspx");
                }
            }
        }

        protected void btnNew_Click(object sender, System.EventArgs e)
        {
            dvPlatform.ChangeMode(DetailsViewMode.Insert);
            btnNew.Visible = false;
            gvPlatforms.Enabled = false;
            dvPlatform.Visible = true;
        }

        protected void dvPlatform_ModeChanged(object sender, System.EventArgs e)
        {
            if (dvPlatform.CurrentMode != DetailsViewMode.Insert)
            {
                dvPlatform.Visible = false;
                btnNew.Visible = false;
                gvPlatforms.Enabled = true;
                LabelStatus.Text = "";
            }
        }

        protected void dvPlatform_ItemInserted(object sender, System.Web.UI.WebControls.DetailsViewInsertedEventArgs e)
        {
            if (((e.Exception != null)))
            {

                LabelStatus.Text = "An error occured while entering this record: <br> ";
                if (e.Exception.GetType() == typeof(SqlException))
                {
                    SqlException errorSQL = (SqlException)e.Exception;
                    if (errorSQL.Number == 2601)
                    {
                        LabelStatus.Text += "Platform already exists!";
                    }
                    else
                    {
                        LabelStatus.Text += errorSQL.Message;
                    }
                }
                else
                {
                    LabelStatus.Text += e.Exception.Message;
                }
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
            }
            else
            {
                LabelStatus.Text = "";
            }
        }
    }
}