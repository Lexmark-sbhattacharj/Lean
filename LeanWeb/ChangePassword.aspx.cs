using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using Lean.Utilities;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace LeanWeb
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePass_Click(object sender, EventArgs e)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            //string strConnString = ConnectionString();
            string password = txtpassword.Text;
            int LdapLogin = 0;
            UserLoginInfo objUserLoginInfo = new UserLoginInfo();
            objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
            string UserName = objUserLoginInfo.UserID.ToString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "UPDATE [aspnet_Users] SET [LdapLogin]=@LdapLogin,[password]=@password WHERE [UserName]=@UserName";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@LdapLogin", SqlDbType.NVarChar).Value = LdapLogin;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = ToSHA256(password);
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;

            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                // return true;
            }
            catch (Exception ex)
            {
                //syelamanchal--Logging--start
                    // Get stack trace for the exception with source file information
                    var st = new StackTrace(ex, true);
                    // Get the top stack frame
                    var frame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    var line = frame.GetFileLineNumber();
                    LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                    objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                    objTestBusiness.Log("Error", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), line, objUserLoginInfo.UserID.ToString(), ex.Message);
                //syelamanchal--Logging--end
                throw;
                //  return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
                lblsuccess.Text = "Password Updated Succesfully..";

                //syelamanchal--Logging--start
                int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                objUserLoginInfo = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo.UserID.ToString(), "Password Changed.");
                //syelamanchal--Logging--end
            }
        }
        //syelamanchali--2 step login--start
        public string ToSHA256(string value)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder returnValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            return returnValue.ToString();
        }
        //syelamanchali--2 step login--end
    }
}