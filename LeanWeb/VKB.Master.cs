using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lean.Utilities;

namespace LeanWeb
{
    public partial class VKB : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserLoginInfo objUserLoginInfo = new UserLoginInfo();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                string DisplayName = objUserLoginInfo.Display_Name.ToString();
                lblUserName.Text = DisplayName;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/LeanLogin.aspx");
            }
        }
    }
}