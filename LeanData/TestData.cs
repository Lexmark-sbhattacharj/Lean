using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.OleDb;

namespace LeanData
{
    public class TestData
    {
        //Query to fetch all values from database
        public string ConnectionString()
        {
            //string strConnectionString = ConfigurationManager.ConnectionStrings["LeanConnectionString"].ConnectionString;
            string strConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            return strConnectionString;
        }

        public string ConnectionReadString()
        {
            //string strConnectionString = ConfigurationManager.ConnectionStrings["LeanConnectionString"].ConnectionString;
            string strConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlReadServer"].ConnectionString;
            return strConnectionString;
        }

        public DataTable databaseValue()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlReadServer"].ConnectionString; //Call direct WebConfig Key
            string query = "select * from dbo.Line";
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //SqlDataReader reader = null;
            DataTable dt = new DataTable();

            try
            {
                sqlconn.Open();
                //cmd.BeginExecuteNonQuery();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlconn.Close();
            }
        }

        //Set Acronym
        public string Acronym(string id)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "select acronym from LeanApp where id_site='" + id + "' ";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            string acrnym;
            try
            {
                SQLConn.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    acrnym = dt.Rows[0].Field<string>(0);
                    return acrnym;
                }
                else
                    return "";
            }
            catch
            {
                return "";
            }
            finally
            {
                if (SQLConn != null)
                {
                    SQLConn.Close();
                }
            }
        }

        //Check Valid UserSites
        public bool validateUserSites(string User, string Site)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "select count(id_user) from usersites us inner join vw_aspnet_Users u on us.id_user=u.userid where u.username='" + User + "' and id_site='" + Site + "'";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                SQLConn.Open();
                Int16 result = default(Int16);
                cmd.CommandTimeout = 600;
                da.Fill(dt);
                
                //if (dt.Rows.Count > 0)
                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                {
                    result = Convert.ToInt16(true);
                }
                else
                {
                    result = Convert.ToInt16(false);
                }
                return Convert.ToBoolean(result);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (SQLConn != null)
                {
                    SQLConn.Close();
                }
            }
        }

        //VKB File Path
        public string VKBFilePath(string Lean_Application)
        {
            try
            {
                string Path = "C:\\Files\\";
                return Path;
            }
            catch
            {
                return string.Empty;
            }
        }

        //Get Physical Folder Path
        public string FolderPath()
        {
            try
            {
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                return FolderPath;
            }
            catch
            {
                return string.Empty;
            }
        }

        //Fill DataTable From Excel
        public DataTable FillDataTableFromExcel(string FilePath, string Extension, string User, string Session)
        {
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls":
                        //Excel 97-03 
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break; // TODO: might not be correct. Was : Exit Select
                    case ".xlsx":
                        //Excel 07 
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break; // TODO: might not be correct. Was : Exit Select
                    default:
                        conStr = string.Empty;
                        break;
                }
                conStr = string.Format(conStr, FilePath, "Yes");

                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet 
                connExcel.Open();
                DataTable dtExcelSchema = default(DataTable);
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet 
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                dt.Columns.Add("idLocalizationMaterial");
                dt.Columns.Add("Upload_User");
                dt.Columns.Add("Upload_Date");
                dt.Columns.Add("Lean_Application");

                //Add Calculated Coulumn, user & date stamp

                foreach (DataRow row in dt.Rows)
                {
                    row["idLocalizationMaterial"] = row["Plant"].ToString() + row["Material"].ToString();
                    row["Upload_User"] = User;
                    row["Upload_Date"] = DateTime.Now.ToShortDateString();
                    row["Lean_Application"] = Session;
                }
                dt.AcceptChanges();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        //Commit DataTable to Database Demand_Customer_Backorder Table
        public bool bulkInserttoDemand_Customer_BackOrder(DataTable dt)
        {
            try
            {
                string consString = ConnectionString();
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Demand_Customer_BackOrder";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Sales_Doc", "sales_Doc");
                        sqlBulkCopy.ColumnMappings.Add("Item", "item");
                        sqlBulkCopy.ColumnMappings.Add("SL_No", "SLNo");
                        sqlBulkCopy.ColumnMappings.Add("Material", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Material_Date", "Mat_Date");
                        sqlBulkCopy.ColumnMappings.Add("Doc_Cat", "Doc_Ca");
                        sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                        sqlBulkCopy.ColumnMappings.Add("Plant", "idLocalization");
                        sqlBulkCopy.ColumnMappings.Add("idLocalizationMaterial", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Commit DataTable to Database Demand_Special_Bid Table
        public bool bulkInserttoDemand_Special_Bid(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Demand_Special_Bid";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Plant No#", "idLocalization");
                        sqlBulkCopy.ColumnMappings.Add("Part No#", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                        sqlBulkCopy.ColumnMappings.Add("Active", "Active");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Comments", "Comments");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
		
		//Mass Upload for Heijunka Planned Line for VKB
        public bool UpdateForMassUpload(string idMaterial, string Localization_Name, string Line, string HeijunkaBoard_Pallets, string Lean_Application)
        {
            string strConnString = ConnectionString();
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            // string strSQL = "UPDATE [VKB_Detail_PartNumber] SET HeijunkaBoard_Pallets = @HeijunkaBoard_Pallets WHERE [idMaterial] = @idMaterial AND [AMLocalization_Name] = @AMLocalization_Name AND [Lean_Application] = @Lean_Application";
            //string strSQL = "UPDATE [VKB_Detail_PartNumber] SET HeijunkaBoard_Pallets ='"+ HeijunkaBoard_Pallets +"' WHERE [idMaterial] = '" + idMaterial +"' AND [Localization_Name] = '" + Localization_Name +"' AND [Lean_Application] = '" + Lean_Application +"'";

            string strSQL = "UPDATE vkb SET [HeijunkaBoard_Pallets] = '" + HeijunkaBoard_Pallets + "' FROM [VKB_Detail_PartNumber] vkb"
                + " inner JOIN[VKB_Global_Line]  Gline ON Gline.[Lean_Application] = vkb.[Lean_Application] and vkb.[idvkb] = Gline.[idvkb]  "
                + " inner JOIN[line] line ON Gline.idLine = line.idLine and Gline.[Lean_Application]=line.[Lean_Application]"
                + " where    vkb.[Lean_Application] ='" + Lean_Application
                + "' AND vkb.[idMaterial] = '" + idMaterial + "' AND vkb.[Localization_Name] = '" + Localization_Name + "'" 
                + " AND Gline.Date = '" + Date + "'"
                + " AND Line.Line ='"+ Line +"'";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@idMaterial", SqlDbType.NVarChar).Value = idMaterial;
            cmd.Parameters.Add("@Localization_Name", SqlDbType.NVarChar).Value = Localization_Name;
            cmd.Parameters.Add("@Lean_Application", SqlDbType.NVarChar).Value = Lean_Application;
            cmd.Parameters.Add("@HeijunkaBoard_Pallets", SqlDbType.Float).Value = HeijunkaBoard_Pallets;
            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@Line", SqlDbType.NVarChar).Value = Line;
            //cmd.Parameters.Add("@original_AM", SqlDbType.NVarChar).Value = original_AM;
            //cmd.Parameters.Add("@original_idLocalization", SqlDbType.NVarChar).Value = original_idLocalization;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                SQLConn.Close();
                SQLConn.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        // Delete from Demand_Special_Bid Table based on Lean Application
        public bool DeleteFromDemand_Special_Bid(string Lean_App)
        {
            try
            {
                string consString = ConnectionString();
                using (SqlConnection con = new SqlConnection(consString))
                {
                    con.Open();
                    using (SqlCommand strcmd = new SqlCommand("DELETE FROM [Demand_Special_Bid] WHERE Lean_Application = @lean_Application", con))
                    {
                        strcmd.Parameters.Add("@lean_Application", SqlDbType.NVarChar).Value = Lean_App;
                        strcmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Select from Bulk_Catalog
        public DataTable SelectFromBulkCatalog(string Lean_App)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "SELECT * FROM [BulkAM_Catalog] where Lean_Application= '" + Lean_App + "' ORDER BY [Bulk]";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                SQLConn.Open();
                cmd.CommandTimeout = 600;
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Update BulkAM_Catalog
        public bool UpdateBulkAMCatalog(string Bulk, string AM, string idLocalization, string original_Bulk, string original_AM, string original_idLocalization)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "UPDATE [BulkAM_Catalog] SET [Bulk] = @Bulk, [AM] = @AM, [idLocalization] = @idLocalization WHERE [Bulk] = @original_Bulk AND [AM] = @original_AM AND [idLocalization] = @original_idLocalization";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Bulk", SqlDbType.NVarChar).Value = Bulk;
            cmd.Parameters.Add("@AM", SqlDbType.NVarChar).Value = AM;
            cmd.Parameters.Add("@idLocalization", SqlDbType.NVarChar).Value = idLocalization;
            cmd.Parameters.Add("@original_Bulk", SqlDbType.NVarChar).Value = original_Bulk;
            cmd.Parameters.Add("@original_AM", SqlDbType.NVarChar).Value = original_AM;
            cmd.Parameters.Add("@original_idLocalization", SqlDbType.NVarChar).Value = original_idLocalization;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                SQLConn.Close();
                SQLConn.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Insert into BulkAM_Catalog
        public bool InsertIntoBulkAMCatalog(string Bulk, string AM, string idLocalization, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "INSERT INTO [BulkAM_Catalog] ([Bulk], [AM],[idLocalization],Lean_Application) VALUES (@Bulk, @AM, @idLocalization, @Lean_Application";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Bulk", SqlDbType.NVarChar).Value = Bulk;
            cmd.Parameters.Add("@AM", SqlDbType.NVarChar).Value = AM;
            cmd.Parameters.Add("@idLocalization", SqlDbType.NVarChar).Value = idLocalization;
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;

            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
            }
        }

        //Delete from BulkAM_Catalog
        public bool DeleteFromBulkAMCatalog(string original_Bulk, string Lean_App)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "DELETE FROM [BulkAM_Catalog] WHERE [Bulk] = @original_Bulk and Lean_Application = @Lean_App";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@original_Bulk", SqlDbType.NVarChar).Value = original_Bulk;
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_App;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Dispose();
                SQLConn.Close();
            }
        }

        //Select from Line
        public DataTable SelectFromLine(string Lean_App)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "SELECT * FROM [Line] WHERE [idLine] <> 0 and Lean_Application = @Lean_App ORDER BY [Line]";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_App;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                SQLConn.Open();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Insert into Line
        public bool InsertIntoLine(string Line, string Capability, string Planner, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "INSERT INTO [Line] ([Line], [Capability],[Planner],[Lean_Application]) VALUES (@Line, @Capability, @Planner,@Lean_App)";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Line", SqlDbType.NVarChar).Value = Line;
            cmd.Parameters.Add("@Capability", SqlDbType.NVarChar).Value = Capability;
            cmd.Parameters.Add("@Planner", SqlDbType.NVarChar).Value = Planner;
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;

            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
            }
        }

        //Delete From Line
        public bool DeleteFromLine(string original_idLine, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "DELETE FROM [Line] WHERE [idLine] = @original_idLine and Lean_Application=@Lean_App ";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@original_idLine", SqlDbType.NVarChar).Value = original_idLine;
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
            }
        }

        //Update to Line
        public bool UpdatetoLine(string original_idLine, string Capability, string Planner, string original_Line)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "UPDATE [Line] SET [Capability] = @Capability, [Planner]= @Planner WHERE [idLine] = @original_idLine AND [Line] = @original_Line";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Capability", SqlDbType.NVarChar).Value = Capability;
            cmd.Parameters.Add("@Planner", SqlDbType.NVarChar).Value = Planner;
            cmd.Parameters.Add("@original_idLine", SqlDbType.NVarChar).Value = original_idLine;
            cmd.Parameters.Add("@original_Line", SqlDbType.NVarChar).Value = original_Line;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
            }
        }

        //Select From VKB_Global_Line
        public DataTable SelectFromVKB_Global_Line(string Date, string Lean_App)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "SELECT [VKB_Global_Line].[idLine],[Line],[Final_Version] FROM [VKB_Global_Line] INNER JOIN [Line] ON [VKB_Global_Line].[idLine] = [Line].[idLine] WHERE [VKB_Global_Line].[Date]=@Date AND [Line].[idLine] <> 0 and [Line].Lean_Application=@Lean_App ORDER BY [Line]";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
            cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_App;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                SQLConn.Open();
                Int16 result = default(Int16);
                cmd.CommandTimeout = 600;
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Update Line
        public bool UpdatetoVKB_Global_Line(string Final_Version, string uploadUser, string original_idLine, string Date)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "UPDATE [VKB_Global_Line] SET [Final_Version]=@Final_Version,[Upload_User]= @uploadUser ,[Upload_Date]=GETDATE()  WHERE [idLine]=@original_idLine AND [Date]=@Date";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            cmd.Parameters.Add("@Final_Version", SqlDbType.NVarChar).Value = Final_Version;
            cmd.Parameters.Add("@uploadUser", SqlDbType.NVarChar).Value = uploadUser;
            cmd.Parameters.Add("@original_idLine", SqlDbType.NVarChar).Value = original_idLine;
            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
            try
            {
                SQLConn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
                SQLConn.Dispose();
            }
        }

        //Get Production Prioritize
        public DataSet SelectFromProd_Priority(DateTime Date, int idLine, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_PRODUCTION_PRIORITIZE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                cmd.Parameters.Add("@idLine", SqlDbType.Int).Value = idLine;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                    throw;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //Get Split
        public DataSet Get_Split_Data(DateTime Date, int idLine, string idMaterial, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_SPLITS", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                cmd.Parameters.Add("@idLine", SqlDbType.Int).Value = idLine;
                cmd.Parameters.Add("@idMaterial", SqlDbType.NVarChar).Value = idMaterial;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                    throw;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //Check Upload Data for selected date.
        public DataSet Get_Upload_Data(DateTime Date, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_CHECK_UPLOAD_DATA", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                    throw;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //Check Checked or Unchecked
        public DataSet Select_Is_Checked(string User_Name, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_ISCHECKED", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = User_Name;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                    throw;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //Select Trigger LHW
        public DataSet SelectTrigger_LHW(string Lean_Application)
        {

            try
            {
                string strConnString = ConnectionString();
                System.Data.SqlClient.SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                using (SqlCommand cmd = new SqlCommand("dbo.GET_ALL_MISMATCH_LHW_TABLES_FROM_HW", SQLConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                string strConnString = ConnectionString();
                SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                SQLConn.Close();
            }
        }

        //Commit DataTable to Database Inventory_JabilInTransit
        public bool bulkInsertto_Inventory_JabilInTransit(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Inventory_JabilInTransit";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Plant", "idLocalization");
                        sqlBulkCopy.ColumnMappings.Add("PN", "Bulk");
                        sqlBulkCopy.ColumnMappings.Add("Qty", "Quantity");
                        sqlBulkCopy.ColumnMappings.Add("Key", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("AMMaterial", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetUserPassword(string username)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "select [password] from [aspnet_Users] where [UserName]='" + username + "' ";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            string password;
            try
            {
                SQLConn.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    password = dt.Rows[0].Field<string>(0);
                    return password;
                }
                else
                    return "";
            }
            catch
            {
               throw;
            }
            finally
            {
                if (SQLConn != null)
                {
                    SQLConn.Close();
                }
            }
        }
        //syelamanchal--get autentication weather user is login via ldap or normal--start
        public bool GetAuthType(string username)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "select [LdapLogin] from [aspnet_Users] where [UserName]='" + username + "' ";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            bool password;
            try
            {
                SQLConn.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    password = dt.Rows[0].Field<bool>(0);
                    return password;
                }
                else
                    return true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (SQLConn != null)
                {
                    SQLConn.Close();
                }
            }
        }
        //syelamanchal--get autentication weather user is login via ldap or normal--end
        //syalamanchili-Get list sites which user can access--start
        public DataTable GetSiteListbyname(string user)
        {
            string strConnString = ConnectionReadString();
            SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
            string strSQL = "SELECT Lean_Application,id_site  FROM[CommonPullSystem].[dbo].[LeanApp] where id_site in (select id_site from usersites us inner join aspnet_Users u on us.id_user = u.userid where u.username = '" + user + "')";
            SqlCommand cmd = new SqlCommand(strSQL, SQLConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                SQLConn.Open();
                cmd.CommandTimeout = 600;
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }
        //syalamanchili-Get list sites which user can access--end

        #region Inventory_DockArea

        //Commit DataTable to Database Inventory_DockArea
        public bool bulkInsertto_Inventory_DockArea(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Inventory_DockArea";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("idLocalization", "idLocalization");
                        sqlBulkCopy.ColumnMappings.Add("idLocalizationMaterial", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Localization_Name", "Localization_Name");
                        sqlBulkCopy.ColumnMappings.Add("idMaterial", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Pallet_ID", "Pallet_ID");
                        sqlBulkCopy.ColumnMappings.Add("Pallet_No", "Pallet_No");
                        sqlBulkCopy.ColumnMappings.Add("Status", "Status");
                        sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Inventory_Rebalancing

        //Commit DataTable to Database Inventory_Rebalancing
        public bool bulkInsertto_Inventory_Rebalancing(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Inventory_Rebalancing";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Key", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Dest", "idLocalization");
                        sqlBulkCopy.ColumnMappings.Add("Material", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Source", "idSource");
                        sqlBulkCopy.ColumnMappings.Add("Qty", "Quantity");
                        sqlBulkCopy.ColumnMappings.Add("Type", "Type");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
                return false;
            }
        }

        #endregion

        #region VKBInput

        //Commit DataTable to Database VKB Input
        public bool bulkInsertto_VKBInput(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.VKB_Input";

                        sqlBulkCopy.ColumnMappings.Add("idLocalizationMaterial", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("idMaterial", "idMaterial");
                        sqlBulkCopy.ColumnMappings.Add("AverageDemand", "AverageDemand");
                        sqlBulkCopy.ColumnMappings.Add("SD", "SD");
                        sqlBulkCopy.ColumnMappings.Add("CV", "CV");
                        sqlBulkCopy.ColumnMappings.Add("Min_Pallet", "Min_Pallet");
                        sqlBulkCopy.ColumnMappings.Add("Target_Pallet", "Target_Pallet");
                        sqlBulkCopy.ColumnMappings.Add("Max_Pallet", "Max_Pallet");
                        sqlBulkCopy.ColumnMappings.Add("Pallet_Qty", "Pallet_Qty");
                        sqlBulkCopy.ColumnMappings.Add("UDC", "UDC");
                        sqlBulkCopy.ColumnMappings.Add("Localization_Name", "Localization_Name");
                        sqlBulkCopy.ColumnMappings.Add("Platform", "Platform");
                        sqlBulkCopy.ColumnMappings.Add("Family", "Family");
                        sqlBulkCopy.ColumnMappings.Add("Type_SWE_AM", "Type_SWE_AM");
                        sqlBulkCopy.ColumnMappings.Add("idLine", "idLine");
                        sqlBulkCopy.ColumnMappings.Add("PPVT", "PPVT");
                        sqlBulkCopy.ColumnMappings.Add("Brand", "Brand");
                        sqlBulkCopy.ColumnMappings.Add("Yield", "Yield");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string get_ID_Line(string Lean_Application, string Line)
        {
            try
            {
                string strConnString = ConnectionString();
                DataSet dsNetwork = new DataSet();
                string id;
                System.Data.SqlClient.SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_IDLINE", SQLConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                    cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                    SqlDataAdapter da = new SqlDataAdapter();
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsNetwork);
                    SQLConn.Close();
                }
                if (dsNetwork.Tables[0].Rows.Count > 0)
                {
                    id = dsNetwork.Tables[0].Rows[0][0].ToString();
                    return id;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion

        #region Distribution Network

        //Commit DataTable to Database Distribution Network
        public bool bulkInsertto_Distribution_Network(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Distribution_Network";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("GEO", "GEO");
                        sqlBulkCopy.ColumnMappings.Add("Source", "idLocalization_Source");
                        sqlBulkCopy.ColumnMappings.Add("Dest", "idLocalization_Dest");
                        sqlBulkCopy.ColumnMappings.Add("LT", "LeadTime");
                        sqlBulkCopy.ColumnMappings.Add("DescDest", "LocalizationDesc");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Distibution_Excep

        //Commit DataTable to Database Distibution_Excep
        public bool bulkInsertto_Distibution_Excep(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.Distibution_Excep";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table

                        sqlBulkCopy.ColumnMappings.Add("Key1", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Key 0", "idLocalizationMaterial_Excep");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');</script>";
                return false;
            }
        }

        #endregion

        #region PartNo Weeks Demand

        //Commit DataTable to Database PartNo Weeks Demand
        public bool bulkInsertto_PartNoWeekDemand(DataTable dt)
        {
            try
            {
                //string consString = ConfigurationManager.ConnectionStrings["PullSystemConnectionString"].ConnectionString;
                string consString = ConnectionString();

                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.PartNumber_WeekDemand";

                        sqlBulkCopy.ColumnMappings.Add("Loc_PartNo", "idLocalizationMaterial");
                        sqlBulkCopy.ColumnMappings.Add("Week", "weekNumber");
                        sqlBulkCopy.ColumnMappings.Add("Year", "Year");
                        sqlBulkCopy.ColumnMappings.Add("Quantity", "DemandQty");
                        sqlBulkCopy.ColumnMappings.Add("Upload_User", "Upload_User");
                        sqlBulkCopy.ColumnMappings.Add("Upload_Date", "Upload_Date");
                        sqlBulkCopy.ColumnMappings.Add("Lean_Application", "Lean_Application");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                        con.Dispose();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Get PartsNo.WeeksDemand_DisNetwork
        public DataSet SelectPNWD_DisNetwork(string Lean_Application)
        {

            try
            {
                string strConnString = ConnectionString();
                System.Data.SqlClient.SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                using (SqlCommand cmd = new SqlCommand("dbo.GET_PARTNO_WEEKSDEMAND_DISTRIBUTIONNETWORK", SQLConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                    DataSet dsNetwork = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsNetwork);
                    return dsNetwork;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                string strConnString = ConnectionString();
                SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                SQLConn.Close();
            }
        }

        public DataSet SelectPNWD_DisExcep(string Lean_Application)
        {

            try
            {
                string strConnString = ConnectionString();
                System.Data.SqlClient.SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                using (SqlCommand cmd = new SqlCommand("dbo.GET_PARTNO_WEEKSDEMAND_DISTRIBUTIONEXCEP", SQLConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                    DataSet dsExceptions = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsExceptions);
                    return dsExceptions;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                string strConnString = ConnectionString();
                SqlConnection SQLConn = new System.Data.SqlClient.SqlConnection(strConnString);
                SQLConn.Close();
            }
        }

        #endregion

        #region Virtual Kanban

        public DataSet Select_VIRTUALKANBAN_ChkUpldData(string Lean_Application, DateTime Date)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_CHECK_UPLOAD_DATA", SQLConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //GET_VIRTUALKANBAN_VKBGLOBAL
        public DataSet Select_VIRTUALKANBAN_VKBGLOBAL(DateTime Date, string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_VKBGLOBAL", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@ddlLineText", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet dsVKB = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsVKB);
                    return dsVKB;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }
        }

        //GET_VIRTUALKANBAN_VKB_DETAIL_PARTNO
        public DataSet Select_VIRTUALKANBAN_VKB_DETAIL_PARTNO(int idVKB, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_VKB_DETAIL_PARTNO", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idVKB", SqlDbType.NVarChar).Value = idVKB;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet dsVKBDetail = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsVKBDetail);
                    return dsVKBDetail;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE
        public DataSet Select_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE(DateTime Date, string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet dsVKBLastHeikunkaBoard = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsVKBLastHeikunkaBoard);
                    return dsVKBLastHeikunkaBoard;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE
        public DataSet Select_VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE(DateTime Date, string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);
            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@ddlLineText", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet dsVKBLastHeikunkaBoard = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {

                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dsVKBLastHeikunkaBoard);
                    return dsVKBLastHeikunkaBoard;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_IFNOT_FINALVERSION
        public DataSet Select_VIRTUALKANBAN_VKB_IFNOT_FINALVERSION(string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_IFNOT_FINALVERSION", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_DIST_NETWORK
        public DataSet Select_VIRTUALKANBAN_DIST_NETWORK(string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_DIST_NETWORK", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_DIST_EXCEP
        public DataSet Select_VIRTUALKANBAN_DIST_EXCEP(string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_DIST_EXCEP", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_FILLDATASET
        public DataSet Select_VIRTUALKANBAN_FILLDATASET(string Line, string txtFilter, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_FILLDATASET", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@txtFilter", SqlDbType.NVarChar).Value = txtFilter;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_LINE
        public DataSet Select_VIRTUALKANBAN_LINE(string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_LINE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }



        }

        //GET_VIRTUALKANBAN_CAPABILITYFROMLINE
        public DataSet Select_VIRTUALKANBAN_CAPABILITYFROMLINE(string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_CAPABILITYFROMLINE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;

                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_ISCHECKED
        public DataSet Select_VIRTUALKANBAN_ISCHECKED(string UserName, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_ISCHECKED", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = UserName;

                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //4thApril
        //GET_VIRTUALKANBAN_VKBGLOBALLINE
        public DataSet Select_VIRTUALKANBAN_VKBGLOBALLINE(DateTime Date, string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_VKBGLOBALLINE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@txtFechaCaptura", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_IDLINE
        public DataSet Select_VIRTUALKANBAN_IDLINE(string Line, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_IDLINE", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_PROD_PRIORITIES
        public DataSet Select_VIRTUALKANBAN_PROD_PRIORITIES(DateTime Date, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_PROD_PRIORITIES", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@txtFechaCaptura", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_SPECIALPERMISSION
        public DataSet Select_VIRTUALKANBAN_SPECIALPERMISSION(string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_SPECIALPERMISSION", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar, 10).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        //GET_VIRTUALKANBAN_PALLETSIZES
        public DataSet Select_VIRTUALKANBAN_PALLETSIZES(string Line, DateTime TextFechaCaptura, string Lean_Application)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.GET_VIRTUALKANBAN_PALLETSIZES", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ddlLinetxt", SqlDbType.NVarChar).Value = Line;
                cmd.Parameters.Add("@txtFechaCaptura", SqlDbType.NVarChar).Value = TextFechaCaptura;
                cmd.Parameters.Add("@Lean_App", SqlDbType.NVarChar).Value = Lean_Application;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }

        #endregion

        #region "Function Not Used"

        //Function Not Used
        public DataSet getTableSQL(string strSQL)
        {
            SqlConnection SQLConn = new SqlConnection(ConnectionString());
            DataSet dss = new DataSet();
            try
            {
                SQLConn.Open();
                SqlCommand myCmd = new System.Data.SqlClient.SqlCommand(strSQL, SQLConn);
                myCmd.CommandTimeout = 600;
                SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(myCmd);
                da.Fill(dss);
                //check status
                return dss;
            }
            catch
            {
                return null;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        //Function Not Used
        public bool updateTable(string strSQL)
        {
            SqlConnection SQLConn = new SqlConnection(ConnectionString());
            DataSet dss = new DataSet();
            try
            {
                SQLConn.Open();
                SqlCommand mycmd = new System.Data.SqlClient.SqlCommand(strSQL, SQLConn);
                mycmd.CommandTimeout = 600;
                mycmd.ExecuteNonQuery();
                //check status
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        #endregion

        #region Trigger LHW Updates

        //Add to LHW Updates
        public bool InsertLHWUpdates(string Lean_Application)
        {

            string consString = ConnectionString();
            SqlParameter sqlParamLeanApp = default(SqlParameter);
            SqlConnection sql = new SqlConnection(consString);
            try
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("dbo.ADD_LHW_TABLES_FROM_HW", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlParamLeanApp = cmd.Parameters.Add("@LEAN_APP", SqlDbType.Char, 20);
                sqlParamLeanApp.Direction = ParameterDirection.Input;
                sqlParamLeanApp.Value = Lean_Application;
                cmd.ExecuteScalar();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sql.Close();
                sql.Dispose();
            }
        }

        //syelamanchili--dividing orange BTO units in other caluclations--staart
        public int[] GetColorBTOunits(string idLocalizationMaterial, string Lean_App, string InputDate)
        {
            string strConnString = ConnectionString();
            int[] Colorout = new int[4];

            try
            {
                
                using (SqlConnection conn = new System.Data.SqlClient.SqlConnection(strConnString))
                using (SqlCommand cmd = new SqlCommand("dbo.GetBTOFromDateRange", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    // set up the input parameters
                    cmd.Parameters.Add("@idLocalizationMaterial", SqlDbType.NVarChar).Value = idLocalizationMaterial;
                    cmd.Parameters.Add("@LeanApp", SqlDbType.NVarChar).Value = Lean_App;
                    cmd.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = InputDate;
                    cmd.Parameters.Add("@OrangeBTO", SqlDbType.Float).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@RedBTO", SqlDbType.Float).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@YellowBTO", SqlDbType.Float).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@GreenBTO", SqlDbType.Float).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                   if((cmd.Parameters["@OrangeBTO"].Value).ToString()!="")
                   {
                        Colorout[0]= Convert.ToInt32(cmd.Parameters["@OrangeBTO"].Value);
                   }
                   else
                   {
                        Colorout[0] = 0;
                   }
                    if ((cmd.Parameters["@RedBTO"].Value).ToString() != "")
                    {
                        Colorout[1] = Convert.ToInt32(cmd.Parameters["@RedBTO"].Value);
                    }
                    else
                    {
                        Colorout[1] = 0;
                    }
                    if ((cmd.Parameters["@YellowBTO"].Value).ToString() != "")
                    {
                        Colorout[2] = Convert.ToInt32(cmd.Parameters["@YellowBTO"].Value);
                    }
                    else
                    {
                        Colorout[2] = 0;
                    }
                    if ((cmd.Parameters["@GreenBTO"].Value).ToString() != "")
                    {
                        Colorout[3] = Convert.ToInt32(cmd.Parameters["@GreenBTO"].Value);
                    }
                    else
                    {
                        Colorout[3] = 0;
                    }
                    //String OrangeBTO = (cmd.Parameters["@OrangeBTO"].Value).ToString();
                    //String RedBTO = (cmd.Parameters["@RedBTO"].Value).ToString();
                    //String YellowBTO = (cmd.Parameters["@YellowBTO"].Value).ToString();
                    //String GreenBTO =(cmd.Parameters["@GreenBTO"].Value).ToString();

                    conn.Close();
                  conn.Dispose();
                    
                }
                return Colorout;
            }
            catch 
            {
                throw;
            }
           
        }
        //syelamanchili--dividing orange BTO units in other caluclations--end
        //syelamanchal--Adding roles functionality to user--start
        public int Validate_UserInRole(string ApplicationName, string UserName,string RoleName)
        {
            string strConnString = ConnectionString();
            SqlConnection SQLConn = new SqlConnection(strConnString);

            using (SqlCommand cmd = new SqlCommand("dbo.aspnet_ValidateUsers_IsUserInRole", SQLConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ApplicationName", SqlDbType.NVarChar).Value = ApplicationName;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = RoleName;
                cmd.Parameters.Add("@isInsert", SqlDbType.Float).Direction = ParameterDirection.Output;
                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter();
                try
                {
                    SQLConn.Open();
                    cmd.ExecuteNonQuery();
                    int result = Convert.ToInt32(cmd.Parameters["@isInsert"].Value);
                    //da.SelectCommand = cmd;
                    //da.Fill(ds);
                    //return ds;
                   // var result = cmd.ExecuteScalar();
                    return (int)(result);
                }
                catch (Exception ex)
                {
                   string tes=ex.Message;
                    return 0;
                    throw;
                }
                finally
                {
                    SQLConn.Close();
                }
            }


        }
        //syelamanchal--Adding roles functionality to user--end
        #endregion
    }
}
