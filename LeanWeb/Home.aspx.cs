using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using System.DirectoryServices;
using Lean.Utilities;

namespace LeanWeb
{
    public partial class Home : System.Web.UI.Page
    {
        public void Page_Init(object o, EventArgs e)
        {
            if ((UserLoginInfo)Session["UserLoginInfo"] == null)
            {
                Response.Redirect("~/LeanLogout.aspx", false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TestBusiness objTestBusiness = new TestBusiness();

                try
                {
                    if (Session["UserLoginInfo"] != null)
                    {
                        string testverb = Convert.ToString(Session["Lean_Application"]);
                        grvTest.DataSource = objTestBusiness.getDatabaseValueFromSP(2);
                        grvTest.DataBind();
                    }
                }
                catch
                {
                }
            }
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/role_DefineParameters/Lines.aspx");
        }
    }
}