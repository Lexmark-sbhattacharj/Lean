using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LeanBusiness;
using System.DirectoryServices;
namespace LeanWeb
{
    public partial class TestWebConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TestBusiness objTestBusiness = new TestBusiness();

                    grvTest.DataSource = objTestBusiness.getDatabaseValueFromSP(2);
                    grvTest.DataBind();
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message.ToString();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }        
    }
}