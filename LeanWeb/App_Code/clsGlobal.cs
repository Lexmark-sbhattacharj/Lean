using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using LeanBusiness;
using System.Reflection;

namespace LeanWeb.App_Code
{
    public class myApp
    {
        public static string Lean_App;
        public static string Description;
        public static string Acronym;

        public static string set_desc(string id)
        {
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                Description = objTestBusiness.getDescription(id);
                return Description;
            }
            catch 
            {
                return "";
            }
        }

        public static string set_acronym(string id)
        {
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                Acronym= objTestBusiness.getAcronym(id);
                return Acronym;
            }
            catch
            {
                return "";
            }
        }

        
    }

    public class clsGlobal
    {
        public string strVKBFilesPath(string Lean_Application)
        {
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                return objTestBusiness.getVKBFilePath(Lean_Application);
            }
            catch
            {
                return "";
            }
        }

        #region "Function Not Used"
        //Function Not Used
        public DataSet getTableSQL(string strSQL, SqlConnection SQLConn)
        {
            DataSet dss = new DataSet();
            try
            {
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
        }

        //Function Not Used
        public bool updateTable(string strSQL, SqlConnection SQLConn)
        {
            DataSet dss = new DataSet();
            try
            {
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
        }
        #endregion

        public bool userSites(string User, string Site)
        {
            try
            {
                TestBusiness objTestBusiness = new TestBusiness();
                return objTestBusiness.getUserSites(User, Site);
            }
            catch
            {
                return false;
            }
        }

        
        
        #region "Standard Deviation"
        private decimal SafeDivide(decimal dbl1, decimal dbl2)
        {
            try
            {
                if ((dbl1 == 0) | (dbl2 == 0))
                    return 0;
                else
                    return dbl1 / dbl2;
            }
            catch
            {
                return  0;
            }
        }
        private decimal Average(decimal[] dblData)
        {
            try
            {
                decimal DataTotal = 0;
                for (int i = 0; i <= dblData.Length - 1; i++)
                {
                    DataTotal += dblData[i];
                }
                return SafeDivide(DataTotal, dblData.Length);
            }
            catch
            {
                return 0;
            }
        }
        public decimal CalculateStandardDeviation(decimal[] dblData)
        {
            try
            {
                decimal dblDataAverage = 0;
                decimal TotalVariance = 0;
                if (dblData.Length == 0)
                    return 0;
                dblDataAverage = Average(dblData);
                for (int i = 0; i <= dblData.Length - 1; i++)
                {
                    double a = Convert.ToDouble(dblData[i] - dblDataAverage);
                    TotalVariance += Convert.ToDecimal(Math.Pow(a, 2));
                }
                return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(SafeDivide(TotalVariance, dblData.Length))));
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region "RoundUp"
        public int roundup(decimal x)
        {
            try
            {
                int functionReturnValue = 0;
                if (x < 0)
                {
                    x = x * -1;
                    if (x > Convert.ToInt32(x))
                    {
                        functionReturnValue = Convert.ToInt32(x) + 1;
                    }
                    else
                    {
                        functionReturnValue = Convert.ToInt32(x);
                    }
                    functionReturnValue = functionReturnValue * -1;
                }
                else
                {
                    if (x > Convert.ToInt32(x))
                    {
                        functionReturnValue = Convert.ToInt32(x) + 1;
                    }
                    else
                    {
                        functionReturnValue = Convert.ToInt32(x);
                    }
                }
                return functionReturnValue;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }

    public static class test
    {
        //public static DataSet ToDataSet<T>(this IList<T> list)
        //{
        //    Type elementType = typeof(T);
        //    DataSet ds = new DataSet();
        //    DataTable t = new DataTable();
        //    ds.Tables.Add(t);

        //    //add a column to table for each public property on T
        //    foreach (var propInfo in elementType.GetProperties())
        //    {
        //        Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

        //        t.Columns.Add(propInfo.Name, ColType);
        //    }

        //    //go through each property on T and add each value to the table
        //    foreach (T item in list)
        //    {
        //        DataRow row = t.NewRow();

        //        foreach (var propInfo in elementType.GetProperties())
        //        {
        //            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
        //        }

        //        t.Rows.Add(row);
        //    }

        //    return ds;
        //}

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}