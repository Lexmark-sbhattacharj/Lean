using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Text;
using Microsoft.CSharp;
using System.Xml;
using System.Xml.Serialization;
using System.DirectoryServices;


namespace LeanWeb.App_Code
{
    public class LdapAuthentication
    {
        string _path;
        string _filterAttribute;
        public LdapAuthentication(string path)
        {
            _path = path;
        }

        public string IsAuthenticated(string domain, string username, string pwd)
        {

            string domainAndUsername = domain + "\\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            try
            {
                //Bind to the native AdsObject to force authentication.			
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("displayname");
                SearchResult result = search.FindOne();
                string Display_Name = string.Empty;
                if ((result == null))
                {
                    return Display_Name;
                }
                else
                {
                    //Update the new path to the user in the directory.
                    _path = result.Path;
                    _filterAttribute = Convert.ToString(result.Properties["cn"][0]);
                    Display_Name = search.FindOne().Properties["displayname"][0].ToString();
                    return Display_Name;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error authenticating user. " + ex.Message);
            }

            //return true;
        }

        public string GetGroups()
        {
            DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();

            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count;

                string dn = null;
                int equalsIndex = 0;
                int commaIndex = 0;

                int propertyCounter = 0;

                for (propertyCounter = 0; propertyCounter <= propertyCount - 1; propertyCounter++)
                {
                    dn = Convert.ToString(result.Properties["memberOf"][propertyCounter]);

                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if ((equalsIndex == -1))
                    {
                        return null;
                    }

                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }

            return groupNames.ToString();
        }
    }
}