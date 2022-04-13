using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Lean.Utilities;
using LeanBusiness;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;

//sql
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace LeanWeb.roles_UserControl
{
    public partial class User_Role_Assignment : System.Web.UI.Page
    {
        UserLoginInfo objUserLoginInfo1 = new UserLoginInfo();
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
            //syalamanchili--External user login--start
            txtuserpassword.Visible = false;
            Label2.Visible = false;
            passid.Visible = false;
            //syalamanchili--External user login--end
            objTestBusiness = new TestBusiness();
            try
            {
                //syelamanchal--Adding roles functionality to user--start
                string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                if (objTestBusiness.Validate_UserInRole(UserName, "UsersControl") != 1)
                {
                    Response.Redirect("~/LeanHome.aspx");
                }
                //syelamanchal--Adding roles functionality to user--end
                if (!IsPostBack)
                {

                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    if (Session["UserLoginInfo"] != null)
                    {
                        BindRolesToList();
                        DisplayUsersBelongingToRole();
                        //BindGridData();
                        //syelamanchali--removing domain from application--start
                        //Fill data from database to ddlDomain
                        //ddlDomain.DataTextField = "Domain";
                        //ddlDomain.DataValueField = "ID";
                        //ddlDomain.DataMember = "Domain";
                        //ddlDomain.DataSource = objTestBusiness.getDomainList();
                        //ddlDomain.DataBind();
                        //syelamanchali--removing domain from application--end
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

        private void BindRolesToList()
        {
            try
            {
                // Get all of the roles 
                string[] roleArr = null;
                roleArr = Roles.GetAllRoles();
                ddlRoleList.DataSource = roleArr;
                ddlRoleList.DataBind();
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

        protected void ddlRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayUsersBelongingToRole();
                LabelStatus.Text = "";
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

        protected void dgRolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)dgRolesUserList.Rows[e.RowIndex];
                //Get the selected role 

                string selectedRoleName = ddlRoleList.SelectedValue;

                //Reference the UserNameLabel 
                Label UserNameLabel = ((Label)row.FindControl("UserNameLabel"));

                //Remove the user from the role 
                Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

                //Refresh the GridView 
                DisplayUsersBelongingToRole();

                //Display a status message 
                LabelStatus.Text = string.Format("User {0} deleted form role {1}.", UserNameLabel.Text, selectedRoleName);
                LabelStatus.ForeColor = Color.Green;
                //syelamanchal--Logging--start
                int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "User ddeleted from Role");
                //syelamanchal--Logging--end
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

        protected void dgRolesUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgRolesUserList.PageIndex = e.NewPageIndex;
                DisplayUsersBelongingToRole();
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

        private void DisplayUsersBelongingToRole()
        {
            try
            {
                // Get the selected role 
                string selectedRoleName = ddlRoleList.SelectedValue;

                // Get the list of usernames that belong to the role 
                string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

                // Bind the list of users to the GridView 
                dgRolesUserList.DataSource = usersBelongingToRole;
                dgRolesUserList.DataBind();
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

        protected void btnAddUserToRoleButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedRoleName = ddlRoleList.SelectedValue;
                string userNameToAddToRole = this.txtUserNameToAddToRole.Text;

                //Change to selected Provider

                // syelamanchili--Removing Ad autentication--start
                //MembershipProvider mbr = default(MembershipProvider);
                //if (ddlDomain.SelectedItem.Text == "NA")
                //{
                //    mbr = Membership.Providers["MyProvider"];
                //}
                //else if (ddlDomain.SelectedItem.Text == "AP")
                //{
                //    mbr = Membership.Providers["MyProviderAP"];
                //}
                //else if (ddlDomain.SelectedItem.Text == "LA")
                //{
                //    mbr = Membership.Providers["MyProviderLA"];
                //}
                //else if (ddlDomain.SelectedItem.Text == "EMEAD")
                //{
                //    mbr = Membership.Providers["MyProviderEMEAD"];
                //}
                //else
                //{
                //    mbr = Membership.Providers["MyProvider"];
                //}
                // syelamanchili--Removing Ad autentication--end
                //Make sure that a value was entered 
                if ((userNameToAddToRole.Trim().Length == 0))
                {
                    LabelStatus.Text = "Please enter the new user.";
                    LabelStatus.ForeColor = Color.Red;
                    return;
                }

                //Make sure that the user exists in the system 
                //Dim userInfo As MembershipUser = Membership.GetUser(userNameToAddToRole)

                // syelamanchili--Removing Ad autentication--start
                //membershipuser userinfo = mbr.getuser(usernametoaddtorole, false);
                //if ((userinfo == null) && (chklocal.checked == false))
                //{
                //    labelstatus.text = string.format("user {0} does not exist.", usernametoaddtorole);
                //    labelstatus.forecolor = color.red;
                //    return;

                //    //syelamanchal do here update password

                //}
                // syelamanchili--Removing Ad autentication--end

                // Make sure that the user doesn't already belong to this role 
                if ((Roles.IsUserInRole(userNameToAddToRole, selectedRoleName)) && chklocal.Checked == false)
                {
                    LabelStatus.Text = string.Format("User {0} already in role {1}.", userNameToAddToRole, selectedRoleName);
                    LabelStatus.ForeColor = Color.Red;
                    return;
                }

                //syalamanchal--External user login--start
                if (chklocal.Checked == false)
                {
                    Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);
                    //Refresh the GridView 
                    DisplayUsersBelongingToRole();

                    //Display a status message 
                    LabelStatus.Text = string.Format("User {0} added on role {1}.", userNameToAddToRole, selectedRoleName);
                    LabelStatus.ForeColor = Color.Green;
                    //syelamanchal--Logging--start
                    int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                    LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                    objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                    objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "User added to role.");
                    //syelamanchal--Logging--end
                }
                if ((chklocal.Checked == true) && (txtuserpassword.Text != ""))
                {
                    var regexItem = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                    if (regexItem.IsMatch(txtUserNameToAddToRole.Text.ToString()))
                    {

                        string strConnString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
                        //string strConnString = ConnectionString();
                        string password = txtuserpassword.Text = txtuserpassword.Text.Trim() + txtUserNameToAddToRole.Text.Substring(0, (int)(txtUserNameToAddToRole.Text.Length / 2));
                        int LdapLogin = 0;
                        string UserName = txtUserNameToAddToRole.Text.Trim();
                        SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                        string strSQL = "UPDATE [aspnet_Users] SET [LdapLogin]=@LdapLogin,[password]=@password WHERE [UserName]=@UserName";
                        SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
                        cmd.Parameters.Add("@LdapLogin", SqlDbType.NVarChar).Value = LdapLogin;
                        //string UserName = ((UserLoginInfo)Session["UserLoginInfo"]).UserID;
                        //password = password + UserName.Substring(0, (int)(UserName.Length / 2));
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = ToSHA256(password);
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;


                        try
                        {
                            SQLConn.Open();
                            cmd.ExecuteNonQuery();
                            // return true;

                            // If we reach here, we need to add the user to the role 
                            Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);
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
                            SQLConn.Dispose();
                            //syelamanchal--Logging--start
                            int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                            LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                            objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                            objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "Password updated for user.");
                            //syelamanchal--Logging--end
                        }
                    }
                    else
                    {
                        LabelStatus.Text = string.Format("User is not valid as it must not contain special characters.");
                        LabelStatus.ForeColor = Color.Red;
                        //syelamanchal--Logging--start
                        int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                        LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                        objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                        objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "UserName tried to update.Invalid User name");
                        //syelamanchal--Logging--end
                        return;
                    }
                    //syelamanchal--External user login--end


                    // Clear out the TextBox 
                    this.txtUserNameToAddToRole.Text = "";
                    //syelamanchal--External user login--start
                    if ((chklocal.Checked == true) && (txtuserpassword.Text == ""))
                    {
                        //Display a status message 
                        LabelStatus.Text = string.Format("Password is not valid.User {0} cant be added on role {1}.", userNameToAddToRole, selectedRoleName);
                        LabelStatus.ForeColor = Color.Red;
                        //syelamanchal--Logging--start
                        int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                        LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                        objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                        objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "Password tried to update.Invalid Password");
                        //syelamanchal--Logging--end
                    }
                    else
                    {
                        //Refresh the GridView 
                        DisplayUsersBelongingToRole();

                        //Display a status message 
                        LabelStatus.Text = string.Format("User {0} added on role {1}.", userNameToAddToRole, selectedRoleName);
                        LabelStatus.ForeColor = Color.Green;
                        //syelamanchal--Logging--start
                        int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();
                        LeanBusiness.TestBusiness objTestBusiness = new LeanBusiness.TestBusiness();
                        objUserLoginInfo1 = (UserLoginInfo)Session["UserLoginInfo"];
                        objTestBusiness.Log("Warning", System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToString(), lineNumber, objUserLoginInfo1.UserID.ToString(), "User added to role.");
                        //syelamanchal--Logging--end
                    }
                    //syelamanchal--External user login--end
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
            finally
            {
                txtUserNameToAddToRole.Text = "";
            }
        }

        //syalamanchili--External user login--start
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                txtuserpassword.Visible = true;
                Label2.Visible = true;
                passid.Visible = true;
            }
            else
            {
                txtuserpassword.Visible = false;
                Label2.Visible = false;
                passid.Visible = false;
            }

        }


        //syalamanchili--External user login--end
    }
}