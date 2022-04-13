using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanData;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Configuration;

namespace LeanBusiness
{
    public class TestBusiness
    {
        #region Others

        public List<dynamic> getDatabaseValueFromSP(int LineID)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();

                var LineSPDataSet = objCPSEntities.Database.SqlQuery<TEST_Line_Result>("exec dbo.TEST_Line @LineID",
                    new SqlParameter { ParameterName = "LineID", Value = LineID }).ToList<TEST_Line_Result>();

                //var LineSPDataSet = objCPSEntities.TEST_Line(2).ToList<TEST_Line_Result>();

                return LineSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public DataTable getDBValueUsingGeneralQuery()
        {
            return new TestData().databaseValue();
        }

        public List<dynamic> getDomainList()
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var DomainDataSet = from Domain in objCPSEntities.DomainNames
                                    orderby Domain.ID
                                    select new { Domain.Domain, Domain.ID };
                //TestData objTestData = new TestData();
                return DomainDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public List<dynamic> getSiteList()
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                //TestData objTestData = new TestData();
                var SiteDataSet = from Lean_Application in objCPSEntities.LeanApps
                                  select new { Lean_Application.Lean_Application, Lean_Application.id_site };
                return SiteDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public string getDescription(string id)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var DescpDataSet = (from Description in objCPSEntities.LeanApps
                                    where Description.id_site == int.Parse(id)
                                    select Description.Description).First().ToString();
                //TestData objTestData = new TestData();
                return DescpDataSet.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public string getAcronym(string id)
        {
            try
            {
                int abc = Convert.ToInt32(id);
                CPSEntities objCPSEntities = new CPSEntities();
                var AcrnymDataSet = (from Acronym in objCPSEntities.LeanApps
                                     where Acronym.id_site == abc
                                     select Acronym.Acronym).First().ToString();
                //TestData objTestData = new TestData();
                return AcrnymDataSet.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        //syelamanchal
        public string getLeanApp(string Acronym)
        {
            try
            {
                string abc = Acronym;
                CPSEntities objCPSEntities = new CPSEntities();
                var AcrnymDataSet = (from Lean_Application in objCPSEntities.LeanApps
                                     where Lean_Application.Acronym == abc
                                     select Lean_Application.Lean_Application).First().ToString();
                //TestData objTestData = new TestData();
                return AcrnymDataSet.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public String getUserPassword(string User)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.GetUserPassword(User);
            }
            catch
            {
                throw;
            }
        }

        public bool getAuthType(string User)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.GetAuthType(User);
            }
            catch
            {
                throw;
            }
        }

        public DataTable getSiteListbyname(string user)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.GetSiteListbyname(user);
            }
            catch
            {
                return null;
            }
        }
        //syelamanchal

        public bool getUserSites(string User, string Site)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.validateUserSites(User, Site);
            }
            catch
            {
                return false;
            }
        }

        public string getVKBFilePath(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.VKBFilePath(Lean_Application);
            }
            catch
            {
                return string.Empty;
            }
        }

        public string getFolderPath()
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.FolderPath();
            }
            catch
            {
                return string.Empty;
            }
        }

        public DataTable getFillDataTableFromExcel(string FilePath, string Extension, string User, string Session)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.FillDataTableFromExcel(FilePath, Extension, Extension, Session);
            }
            catch
            {
                return null;
            }
        }

        public bool getbulkInserttoDemand_Customer_BackOrder(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInserttoDemand_Customer_BackOrder(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getbulkInserttoDemand_Special_Bid(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInserttoDemand_Special_Bid(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getDeleteFromDemand_Special_Bid(string Lean_App)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.DeleteFromDemand_Special_Bid(Lean_App);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getSelectFromBulkCatalog(string Lean_App)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.SelectFromBulkCatalog(Lean_App);
            }
            catch
            {
                return null;
            }
        }

        public bool getUpdateBulkAMCatalog(string Bulk, string AM, string idLocalization, string original_Bulk, string original_AM, string original_idLocalization)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.UpdateBulkAMCatalog(Bulk, AM, idLocalization, original_Bulk, original_AM, original_idLocalization);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getInsertIntoBulkAMCatalog(string Bulk, string AM, string idLocalization, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.InsertIntoBulkAMCatalog(Bulk, AM, idLocalization, Lean_Application);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getDeleteFromBulkAMCatalog(string original_Bulk, string Lean_App)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.DeleteFromBulkAMCatalog(original_Bulk, Lean_App);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getSelectFromLine(string Lean_App)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.SelectFromLine(Lean_App);
            }
            catch
            {
                return null;
            }
        }

        public bool getInsertIntoLine(string Line, string Capability, string Planner, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.InsertIntoLine(Line, Capability, Planner, Lean_Application);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getDeleteFromLine(string original_idLine, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.DeleteFromLine(original_idLine, Lean_Application);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool getUpdatetoLine(string original_idLine, string Capability, string Planner, string original_Line)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.UpdatetoLine(original_idLine, Capability, Planner, original_Line);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public DataTable getSelectFromVKB_Global_Line(string Date, string Lean_App)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.SelectFromVKB_Global_Line(Date, Lean_App);
            }
            catch
            {
                return null;
            }
        }

        public bool getUpdatetoVKB_Global_Line(string Final_Version, string uploadUser, string original_idLine, string Date)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.UpdatetoVKB_Global_Line(Final_Version, uploadUser, original_idLine, Date);
                return result;
            }
            catch
            {
                return false;
            }
        }

        //syelamanchili--dividing orange BTO units in other caluclations--start
        public int[] GetColorBTOunits(string idLocalizationMaterial, string Lean_App, string InputDate)
        {
            try
            {
                TestData objTestData = new TestData();
                int[] result = objTestData.GetColorBTOunits(idLocalizationMaterial,Lean_App,InputDate);
                return result;
            }
            catch
            {
               throw;
            }
        }
        //syelamanchili--dividing orange BTO units in other caluclations--end
        #endregion

        #region SPECIAL BID SYSTEM FROM Lean

        public List<dynamic> getSpecialBidDetails(string Lean_Application, string filter)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();

                var LineSPDataSet = objCPSEntities.Database.SqlQuery<GET_SPECIAL_BIDS_Result>("exec dbo.GET_SPECIAL_BIDS @Lean_App, @Filter",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }, new SqlParameter { ParameterName = "Filter", Value = filter }

                    ).ToList<GET_SPECIAL_BIDS_Result>();
                return LineSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateSpecialBid(string idLocalization, string idMaterial, int Active, int Quantity, string uploadUser, string Comments, string Lean_App, string original_idSpecialBid)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_SPECIAL_BIDS(idLocalization, idMaterial, Convert.ToBoolean(Active), Quantity, uploadUser, Comments, Lean_App, original_idSpecialBid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CreateSpecialBid(string idLocalization, string idMaterial, int Quantity, string uploadUser, string Comments, string Lean_App)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                return objCPSEntities.CREATE_SPECIAL_BIDS(idLocalization, idMaterial, Quantity, uploadUser, Comments, Lean_App);
            }
            catch
            {
                return 0;
            }
        }

        public bool DeleteSpecialBid(int original_idSpecialBid)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_SPECIAL_BIDS(original_idSpecialBid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region BULKAM CATALOG FROM LEAN

        public bool CreateBulkAM_Catalog(string Bulk, string AM, string idLocalization, string Lean_App)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.Create_BulkAM_Catalog(Bulk, AM, idLocalization, Lean_App);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<dynamic> getBulkAM_CatalogDetails(string Lean_Application, string filter)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var BulkAM_CatalogSPDataSet = objCPSEntities.Database.SqlQuery<GET_BulkAM_Catalog_Result>("exec dbo.GET_BulkAM_Catalog @Lean_App , @Filter",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }, new SqlParameter { ParameterName = "Filter", Value = filter }

                    ).ToList<GET_BulkAM_Catalog_Result>();
                return BulkAM_CatalogSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateBulkAM_Catalog(string Bulk, string AM, string idLocalization, string orignal_Bulk, string orignal_AM, string orignal_idLocalization)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.Update_BulkAM_Catalog(Bulk, AM, idLocalization, orignal_Bulk, orignal_AM, orignal_idLocalization);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBulkAM_Catalog(string Lean_Application, string orignal_Bulk)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.Delete_BulkAM_Catalog(Lean_Application, orignal_Bulk);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region SPECIAL PERMISSIONS FROM LEAN

        public List<dynamic> getSpecialPermissionDetails(string Lean_Application, string filter)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var SpecialPermissionSPDataSet = objCPSEntities.Database.SqlQuery<GET_Overproduce_Special_Permission_Result>("exec dbo.GET_Overproduce_Special_Permission @Lean_App , @Filter",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }, new SqlParameter { ParameterName = "Filter", Value = filter }

                    ).ToList<GET_Overproduce_Special_Permission_Result>();
                return SpecialPermissionSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool CreateSpecialPermission(string idMaterial, string LocalizationName, string Lean_Application, bool Active, string uploadUser)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.CREATE_Overproduce_Special_Permission(idMaterial, LocalizationName, uploadUser, Active, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSpecialPermission(bool Active, string uploadUser, string Lean_Application, int idOverproduce)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_Overproduce_Special_Permission(Active, uploadUser, idOverproduce, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSpecialPermission(string Lean_Application, int idOverproduce)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_Overproduce_Special_Permission(idOverproduce, Lean_Application); ;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<dynamic> getIDMATERIALVKBINPUTDetails(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var IDMATERIALVKBINPUTSPDataSet = objCPSEntities.Database.SqlQuery<GET_IDMATERIAL_VKBINPUT_Result>("exec dbo.GET_IDMATERIAL_VKBINPUT @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }

                    ).ToList<GET_IDMATERIAL_VKBINPUT_Result>();
                return IDMATERIALVKBINPUTSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public List<dynamic> getLOCALIZATIONVKBINPUTDetails(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var LOCALIZATIONVKBINPUTSPDataSet = objCPSEntities.Database.SqlQuery<GET_LOCALIZATION_VKBINPUT_Result>("exec dbo.GET_LOCALIZATION_VKBINPUT @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }

                    ).ToList<GET_LOCALIZATION_VKBINPUT_Result>();
                return LOCALIZATIONVKBINPUTSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Lines FROM LEAN

        public bool CreateLines(string Line, int Capability, string Planner, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.CREATE_LINE(Line, Capability, Planner, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<dynamic> getLinesDetail(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var LineSPDataSet = objCPSEntities.Database.SqlQuery<GET_LINE_Result>("exec [dbo].[GET_LINE] @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }).ToList<GET_LINE_Result>();
                return LineSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateLines(int Capability, string Planner, int original_idLine, string original_Line)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_LINE(Capability, Planner, original_idLine, original_Line);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLines(int original_idLine, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_LINE(original_idLine, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Unblock Final VKB

        public List<dynamic> getVKB_Global_LineDetail(string Lean_Application, DateTime Date)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var unblockFinalVKB_SPDataSet = objCPSEntities.Database.SqlQuery<GET_VKB_Global_Line_Result>("exec [dbo].[GET_VKB_Global_Line] @Lean_App, @Date",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application },
                    new SqlParameter { ParameterName = "Date", Value = Date }
                    ).ToList<GET_VKB_Global_Line_Result>();
                return unblockFinalVKB_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateVKB_Global_Line(bool Final_Version, string uploadUser, int original_idLine, DateTime Date)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.Update_VKB_Global_Line(Final_Version, uploadUser, original_idLine, Date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Inventory DistributionCenters

        public bool CreateInventory_DistributionCenters(string idLocalizationMaterial, string idLocalization, string idMaterial, int Quantity, string Upload_User, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_INVENTORY_DISTRIBUTION_CENTERS(idLocalizationMaterial, idLocalization, idMaterial, Quantity, Upload_User, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInventory_DistributionCenters(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_INVENTORY_DISTRIBUTION_CENTERS(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Reports Catalog

        public List<dynamic> getResult_Catalog_Details(string Lean_Application, string Geo)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var result_Catalog_SPDataSet = objCPSEntities.Database.SqlQuery<GET_REPORT_DETAILS_Result>("exec [dbo].[GET_REPORT_DETAILS] @Lean_App, @Geo",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application },
                    new SqlParameter { ParameterName = "Geo", Value = Geo }
                    ).ToList<GET_REPORT_DETAILS_Result>();
                return result_Catalog_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region VKB Checklist

        public List<dynamic> getVKB_Checklist_Details(string Lean_Application, DateTime Date)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var result_Catalog_SPDataSet = objCPSEntities.Database.SqlQuery<GET_VKB_CHECKLIST_Result>("exec [dbo].[GET_VKB_CHECKLIST] @Date, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_VKB_CHECKLIST_Result>();
                return result_Catalog_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Demand Customer Backorder

        public bool CreateDemand_Customer_BackOrder(string idLocalizationMaterial, string idLocalization, string idMaterial, string sales_Doc, string item, string SLNo, DateTime Mat_Date, string Doc_Ca, int Quantity, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_DEMAND_CUSTOMER_BACKORDER(idLocalizationMaterial, idLocalization, idMaterial, sales_Doc, item, SLNo, Mat_Date, Doc_Ca, Quantity, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDemand_Customer_BackOrder(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DEMAND_CUSTOMER_BACKORDER(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Demand SWE

        public bool CreateDemand_SWE(string idLocalizationMaterial, string idLocalization, string idMaterial, string sales_Doc, string item, string SLNo, DateTime Mat_Date, string Doc_Ca, int Quantity, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_DEMAND_SWE(idLocalizationMaterial, idLocalization, idMaterial, sales_Doc, item, SLNo, Mat_Date, Doc_Ca, Quantity, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDemand_SWE(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DEMAND_SWE(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Inventory In Transit

        public bool CreateInventoryInTransit(string idLocalizationMaterial, string idLocalization, string Localization_Name, string idMaterial, string Material_Name, int Quantity, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_INVENTORY_INTRANSIT(idLocalizationMaterial, idLocalization, Localization_Name, idMaterial, Material_Name, Quantity, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInventoryInTransit(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_INVENTORY_INTRANSIT(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Production Prioritize

        public List<dynamic> getVKB_Production_Prioritize_Details(DateTime Date, int idLine, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var Production_Prioritize_SPDataSet = objCPSEntities.Database.SqlQuery<GET_PRODUCTION_PRIORITIZE_Result>("exec [dbo].[GET_PRODUCTION_PRIORITIZE] @Date, @idLine, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "idLine", Value = idLine },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_PRODUCTION_PRIORITIZE_Result>();
                return Production_Prioritize_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public List<dynamic> getVKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Details(DateTime Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_SPDataSet = objCPSEntities.Database.SqlQuery<GET_VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Result>("exec [dbo].[GET_VKB_GLOBAL_LINE_FOR_PROD_PRIORITY] @Date, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_Result>();
                return VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public List<dynamic> getMATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Details(string Material, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_SPDataSet = objCPSEntities.Database.SqlQuery<GET_MATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Result>("exec [dbo].[GET_MATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY] @Material, @LeanApp",
                    new SqlParameter { ParameterName = "Material", Value = Material },
                    new SqlParameter { ParameterName = "LeanApp", Value = Lean_Application }
                    ).ToList<GET_MATERIAL_VKB_Detail_PartNumber_PROD_PRIORITY_Result>();
                return VKB_GLOBAL_LINE_FOR_PROD_PRIORITY_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateProduction_Prioritize(int idLine_ddlLine, int idLine_gv_ddlLine, DateTime FilterDate, string idLocalizationMaterial, string Lean_Application, int Production_Order, string SAP_Order, int Minutes_Lost, int Pieces_Lost, string Comments, string Upload_User)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_Production_Prioritize(idLine_ddlLine, idLine_gv_ddlLine, FilterDate, idLocalizationMaterial, Lean_Application, 0, 0, Production_Order, SAP_Order, Minutes_Lost, Pieces_Lost, Comments, Upload_User);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataSet getProd_priority(DateTime Date, int idLine, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.SelectFromProd_Priority(Date, idLine, Lean_Application);
            }
            catch
            {
                throw;
            }

        }

        public List<dynamic> get_Split_Material(DateTime Date, int idLine, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var Split_Material_SPDataSet = objCPSEntities.Database.SqlQuery<GET_SPLIT_MATERIAL_Result>("exec [dbo].[GET_SPLIT_MATERIAL] @idLine, @Date, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "idLine", Value = idLine },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_SPLIT_MATERIAL_Result>();
                return Split_Material_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public List<dynamic> get_Split_Line(DateTime Date, int idLine, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var Split_Line_SPDataSet = objCPSEntities.Database.SqlQuery<GET_SPLIT_LINE_Result>("exec [dbo].[GET_SPLIT_LINE] @idLine, @Date, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "idLine", Value = idLine },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_SPLIT_LINE_Result>();
                return Split_Line_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public DataSet get_Split(DateTime Date, int idLine, string idMaterial, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Get_Split_Data(Date, idLine, idMaterial, Lean_Application);
            }
            catch
            {
                throw;
            }

        }

        public bool Update_Split_Prod_Priority(int idLine_ddlLine, int idLine_Destiny, DateTime Date, string idLocalizationMaterial, string Lean_Application, int Pallets, int Split_Pallets, string Upload_User)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_SPLITS_TO_PROD_PRIORITY(idLine_ddlLine, idLine_Destiny, Date, idLocalizationMaterial, Pallets, Split_Pallets, Lean_Application, Upload_User);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int get_Split_Count(DateTime Date, int idLine, string Lean_Application, string idLocalizationMaterial)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var Split_Count_SPDataSet = objCPSEntities.Database.SqlQuery<GET_COUNT_SPLIT_Result>("exec [dbo].[GET_COUNT_SPLIT] @idLine, @Date, @idLocalizationMaterial, @Lean_App",
                    new SqlParameter { ParameterName = "Date", Value = Date },
                    new SqlParameter { ParameterName = "idLine", Value = idLine },
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application },
                    new SqlParameter { ParameterName = "idLocalizationMaterial", Value = idLocalizationMaterial }
                    ).ToList<GET_COUNT_SPLIT_Result>();
                return Split_Count_SPDataSet.ToList<dynamic>().Count;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region DailyUploads Checklist

        public List<dynamic> GetDailyUploadsChecklist(string Lean_app, DateTime Date)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var DailyUploadsSPDataSet = objCPSEntities.Database.SqlQuery<GET_DAILY_UPLOADS_CHECKLIST_Result>("exec [dbo].[GET_DAILY_UPLOADS_CHECKLIST] @Lean_App, @Date",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_app },
                    new SqlParameter { ParameterName = "Date", Value = Date }).ToList<GET_DAILY_UPLOADS_CHECKLIST_Result>();
                return DailyUploadsSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;

            }
        }

        public bool Delete_DailyUploadsChecklist(string Lean_app)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DAILY_UPLOADS_CHECKLIST(Lean_app);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion

        #region Virtual Kanban

        public List<dynamic> Get_Virtual_Kanban_Line(string Lean_app)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var Line_SPDataSet = objCPSEntities.Database.SqlQuery<GET_VIRTUALKANBAN_LINE_Result>("exec [dbo].[GET_VIRTUALKANBAN_LINE] @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_app })
                    .ToList<GET_VIRTUALKANBAN_LINE_Result>();
                return Line_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;

            }
        }

        public DataSet get_Upload_Data_For_Selected_Date(DateTime Date, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Get_Upload_Data(Date, Lean_Application);
            }
            catch
            {
                throw;
            }

        }

        public DataSet get_Is_Checked(string UserName, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_Is_Checked(UserName, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        public bool Create_Is_Checked(string User_Name, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_IS_CHECKED(User_Name, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update_Is_Checked(string User_Name, string Lean_Application, decimal Is_Checked)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_IS_CHECKED(User_Name, Lean_Application, Is_Checked);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region InventoryDockArea

        public List<dynamic> getInventDockArea_BulkAM(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();

                var InventDockArea_BulkAM_SPDataSet = objCPSEntities.Database.SqlQuery<GET_INVENTDOCKAREA_BULKAMCAT_Result>("exec dbo.GET_INVENTDOCKAREA_BULKAMCAT @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }

                    ).ToList<GET_INVENTDOCKAREA_BULKAMCAT_Result>();
                return InventDockArea_BulkAM_SPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool Delete_InventoryDockArea(string Lean_app)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_INVENTORY_DOCKAREA(Lean_app);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool Insert_InventoryDockArea(string idLocalizationMaterial, string idLocalization, string Localization_Name, string idMaterial, string Pallet_ID, string Pallet_No, int Quantity, string Status, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_Inventory_DockArea(idLocalizationMaterial, idLocalization, Localization_Name, idMaterial, Pallet_ID, Pallet_No, Quantity, Status, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool Insert_bulkInsertto_Inventory_DockArea(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_Inventory_DockArea(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Demand For Backorder

        public bool CreateDemandForBackOrder(string idLocalizationMaterial, string idLocalization, string idMaterial, string sales_Doc, string item, string SLNo, DateTime Mat_Date, string Doc_Ca, int Quantity, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_DEMAND_BACKORDER(idLocalizationMaterial, idLocalization, idMaterial, sales_Doc, item, SLNo, Mat_Date, Doc_Ca, Quantity, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDemandForBackOrder(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DEMAND_BACKORDER(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region TriggerLHWUpdates

        public bool Update_TriggerLHW(string LEAN_APP)
        {
            try
            {
                //CPSEntities objCPSEntities = new CPSEntities();
                //objCPSEntities.ADD_LHW_TABLES_FROM_HW(LEAN_APP);
                TestData objTestData = new TestData();
                bool result = objTestData.InsertLHWUpdates(LEAN_APP);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public DataSet get_TriggerLHW(string LEAN_APP)
        {

            try
            {
                TestData objTestData = new TestData();
                return objTestData.SelectTrigger_LHW(LEAN_APP);
            }
            catch
            {
                return null;
            }
        }

        public bool Delete_TriggerLHW(string LEAN_APP)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.ROLLBACK_ALL_MISMATCH_HW_TABLES_FROM_LHW(LEAN_APP);

                //LeanDataModelContainer obj = new LeanDataModelContainer();
                //obj.ROLLBACK_ALL_MISMATCH_HW_TABLES_FROM_LHW(LEAN_APP);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Inventory In Transit Jabil

        public bool CreateInventoryInTransitJabil(string idLocalizationMaterial, string idLocalization, string idMaterial, string Bulk, int Quantity, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_INVENTORY_INTRANSIT_JABIL(idLocalizationMaterial, idLocalization, idMaterial, Bulk, Quantity, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInventoryInTransitJabil(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_INVENTORY_INTRANSIT_JABIL(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert_bulkInsertto_Inventory_JabilInTransit(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_Inventory_JabilInTransit(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Inventory Rebalancing

        public bool CreateInventoryRebalancing(string idLocalizationMaterial, string idSource, string idLocalization, string idMaterial, int Quantity, string Type, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_INVENTORY_REBALANCING(idLocalizationMaterial, idSource, idLocalization, idMaterial, Quantity, Type, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteInventoryRebalancing(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_INVENTORY_REBALANCING(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert_bulkInsertto_Inventory_Rebalancing(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_Inventory_Rebalancing(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region VKB Input

        public bool CreateVKBInput(string idLocalizationMaterial, string idMaterial, int idLine, float AverageDemand, float SD, float CV, int Max_Pallet, int Target_Pallet, int Min_Pallet, int Pallet_Qty, string PPVT, string Yield, string UDC, string Localization_Name, string Platform, string Family, string Type_SWE_AM, string Upload_User, DateTime Upload_Date, string Brand, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_VKBINPUT(idLocalizationMaterial, idMaterial, idLine, AverageDemand, SD, CV, Max_Pallet, Target_Pallet, Min_Pallet, Pallet_Qty, PPVT, Yield, UDC, Localization_Name, Platform, Family, Type_SWE_AM, Upload_User, Upload_Date, Brand, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteVKBInput(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_VKBINPUT(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert_bulkInsertto_VKBInput(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_VKBInput(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public string get_id_line(string Lean_Application, string Line)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.get_ID_Line(Lean_Application, Line);
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region Distribution Network
        public bool CreateDistributionNetwork(string GEO, string idLocalization_Source, string idLocalization_Dest, int LeadTime, string LocalizationDesc, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_DISTRIBUTION_NETWORK(GEO, idLocalization_Source, idLocalization_Dest, LeadTime, LocalizationDesc, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDistributionNetwork(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DISTRIBUTION_NETWORK(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //-----
        public bool insert_bulkInsertto_DistributionNetwork(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_Distribution_Network(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Distribution Exception
        public bool CreateDistributionException(string idLocalizationMaterial, string idLocalizationMaterial_Excep, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_DISTRIBUTION_EXCEP(idLocalizationMaterial, idLocalizationMaterial_Excep, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDistributionException(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_DISTRIBUTION_EXCEP(Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert_bulkInsertto_DistributionException(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_Distibution_Excep(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region PartNumber_WeeksDemand

        public bool CreatePartNumber_WeeksDemand(string idLocalizationMaterial, int weekNumber, int Year, int DemandQty, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_PARTNUMBER_WEEKDEMAND(idLocalizationMaterial, weekNumber, Year, DemandQty, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePartNumber_WeeksDemand(int Week, int Year, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_PARTNUMBER_WEEKDEMAND(Week, Year, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool insert_bulkInsertto_PartNumber_WeeksDemand(DataTable dt)
        {
            try
            {
                TestData objTestData = new TestData();
                bool result = objTestData.bulkInsertto_PartNoWeekDemand(dt);
                return result;
            }
            catch
            {
                return false;
            }
        }

        public DataSet get_PNWD_DisNetwork(string Lean_App)
        {

            try
            {
                TestData objTestData = new TestData();
                var dsNetwork = objTestData.SelectPNWD_DisNetwork(Lean_App);
                return dsNetwork;
            }
            catch
            {
                return null;
            }
        }

        public DataSet get_PNWD_DisExcep(string Lean_App)
        {

            try
            {
                TestData objTestData = new TestData();
                var dsExceptions = objTestData.SelectPNWD_DisExcep(Lean_App);
                return dsExceptions;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Virtual Kanban(By Surbhi)

        //Select_ChkUpldData
        public DataSet get_VIRTUALKANBAN_ChkUpldData(string Lean_Application, DateTime Date)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_ChkUpldData(Lean_Application, Date);
            }
            catch
            {
                throw;
            }

        }

        //Select_IsChecked
        public DataSet get_VIRTUALKANBAN_IsChecked(string UserName, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_ISCHECKED(UserName, Lean_Application);
            }
            catch
            {
                throw;
            }

        }

        //Select_VKBGLOBAL
        public DataSet get_VIRTUALKANBAN_VKBGLOBAL(DateTime Date, string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKBGLOBAL(Date, Line, Lean_Application);
            }
            catch
            {
                throw;
            }

        }

        //VIRTUALKANBAN_VKB_DETAIL_PARTNO
        public DataSet get_VIRTUALKANBAN_VKB_DETAIL_PARTNO(int idVKB, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKB_DETAIL_PARTNO(idVKB, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE
        public DataSet get_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE(DateTime Date, string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKBDETAIL_PN_CHK_TRUE(Date, Line, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE
        public DataSet get_VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE(DateTime Date, string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKBDETAIL_PN_CHK_FALSE(Date, Line, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //VIRTUALKANBAN_IFNOT_FINALVERSION
        public DataSet get_VIRTUALKANBAN_IFNOT_FINALVERSION(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKB_IFNOT_FINALVERSION(Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //VIRTUALKANBAN_DIST_NETWORK
        public DataSet get_VIRTUALKANBAN_DIST_NETWORK(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_DIST_NETWORK(Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //Get VIRTUALKANBAN_DIST_EXCEP
        public DataSet get_VIRTUALKANBAN_DIST_EXCEP(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_DIST_EXCEP(Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //Get VIRTUALKANBAN_FILLDATASET
        public DataSet get_VIRTUALKANBAN_FILLDATASET(string Line, string txtFilter, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_FILLDATASET(Line, txtFilter, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //Get VIRTUALKANBAN_LINE
        public DataSet get_VIRTUALKANBAN_LINE(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_LINE(Lean_Application);
            }
            catch
            {
                throw;
            }
        }


        //Get VIRTUALKANBAN_CAPABILITYFROMLINE
        public DataSet get_VIRTUALKANBAN_CAPABILITYFROMLINE(string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_CAPABILITYFROMLINE(Line, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //4thApril
        //GET_VIRTUALKANBAN_VKBGLOBALLINE
        public DataSet get_VIRTUALKANBAN_VKBGLOBALLINE(DateTime Date, string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_VKBGLOBALLINE(Date, Line, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //GET_VIRTUALKANBAN_IDLINE
        public DataSet get_VIRTUALKANBAN_IDLINE(string Line, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_IDLINE(Line, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //GET_VIRTUALKANBAN_PROD_PRIORITIES
        public DataSet get_VIRTUALKANBAN_PROD_PRIORITIES(DateTime Date, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_PROD_PRIORITIES(Date, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //GET_VIRTUALKANBAN_SPECIALPERMISSION
        public DataSet get_VIRTUALKANBAN_SPECIALPERMISSION(string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_SPECIALPERMISSION(Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //6thApril
        //Update Virtual Kanban Line
        public bool Update_VIRTUALKANBAN_LINE(int OldTotalCapacity, string Line, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_VIRTUALKANBAN_LINE(OldTotalCapacity, Line, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //GET_VIRTUALKANBAN_PALLETSIZES
        public DataSet get_VIRTUALKANBAN_PALLETSIZES(string Line, DateTime TextFechaCaptura, string Lean_Application)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Select_VIRTUALKANBAN_PALLETSIZES(Line, TextFechaCaptura, Lean_Application);
            }
            catch
            {
                throw;
            }
        }

        //INSERT_VIRTUALKANBAN_VKBGLOBALLINE
        public bool INSERT_VIRTUALKANBAN_VKBGLOBALLINE(DateTime txtFechaCaptura, int idLine, Boolean chkFinalVersion, string Upload_User, DateTime Upload_Date, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_VIRTUALKANBAN_VKBGLOBALLINE(txtFechaCaptura, idLine, chkFinalVersion, Upload_User, Upload_Date, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //UPDATE_VIRTUALKANBAN_VKBGLOBALLINE
        public bool UPDATE_VIRTUALKANBAN_VKBGLOBALLINE(Boolean chkFinalVersion, string Upload_User, DateTime Upload_Date, int idVKB)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_VIRTUALKANBAN_VKBGLOBALLINE(chkFinalVersion, Upload_User, Upload_Date, idVKB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DELETE_VIRTUALKANBAN_PROD_PRIORITIZE
        public bool DELETE_VIRTUALKANBAN_PROD_PRIORITIZE(string idLocalizationMaterial, DateTime txtFechaCaptura, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_VIRTUALKANBAN_PROD_PRIORITIZE(idLocalizationMaterial, txtFechaCaptura, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //INSERT_VIRTUALKANBAN_PROD_PRIORITIZE
        public bool INSERT_VIRTUALKANBAN_PROD_PRIORITIZE(string idLocalizationMaterial, int idLine, DateTime Date, int Production_Order, int Pallets, double PrimaryPriority, string Upload_User, int Minutes_Lost, int Pieces_Lost, string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_VIRTUALKANBAN_PROD_PRIORITIZE(idLocalizationMaterial, idLine, Date, Production_Order, Pallets, PrimaryPriority, Upload_User, Minutes_Lost, Pieces_Lost, Lean_Application);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //INSERT_VIRTUALKANBAN_SIGNALDELAY
        public bool INSERT_VIRTUALKANBAN_SIGNALDELAY(int idVKB, string idLocalizationMaterial, string Material_Type_Request, string User_Upload, DateTime Creation_Date, string LeanApp)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_VIRTUALKANBAN_SIGNALDELAY(idVKB, idLocalizationMaterial, Material_Type_Request, User_Upload, Creation_Date, LeanApp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DELETE_VIRTUALKANBAN_SIGNALDELAY
        public bool DELETE_VIRTUALKANBAN_SIGNALDELAY(int idVKB)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_VIRTUALKANBAN_SIGNALDELAY(idVKB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //INSERT_VIRTUALKANBAN_VKBDETAILPARTNO
        public bool INSERT_VIRTUALKANBAN_VKBDETAILPARTNO(int idVKB, string idLocalizationMaterial, string UDC, float CV, float PrimaryPriority, string idMaterial, string Localization_Name, float PercentRed, float Customer_Backorder_Units, float BTO_Units, float Special_Bids_Units, float Projected_Backorder_Units, float InvOnDisCenter_Units, float InvInTransit_Units, float SAPKanbanTotal_Pallets, float HeijunkaKanban_Pallets, float TotalKanban_Pallets, float TotalInvpercent, float RedPorc, float YellowPorc, float GreenPorc, float KanbanNeededForCustomerBO_Pallets, float KanbanNeededForBTO_Pallets, float KanbanNeededForSpecialBid_Pallets, float KanbanNeededForProjectedBO_Pallets, float KanbanNeededForOrange_Pallets, float KanbanNeededForRed_Pallets, float KanbanNeededForYellow_Pallets, float KanbanNeededForGreen_Pallets, float MinKanban_Pallets, float TargetKanban_Pallets, float MaxKanban_Pallets, float ExcessKanban_Pallets, float HeijunkaBoard_Pallets, string Platform, string Family, float AverageDemand, int Pallet_Qty, string Type, float High_Priority_Units, int Remd_Pallet, string Lean_Application, string PPVT, string Yield)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.INSERT_VIRTUALKANBAN_VKBDETAILPARTNO1(idVKB, idLocalizationMaterial, UDC, CV, PrimaryPriority, idMaterial, Localization_Name, PercentRed, Customer_Backorder_Units, BTO_Units, Special_Bids_Units, Projected_Backorder_Units, InvOnDisCenter_Units, InvInTransit_Units, SAPKanbanTotal_Pallets, HeijunkaKanban_Pallets, TotalKanban_Pallets, TotalInvpercent, RedPorc, YellowPorc, GreenPorc, KanbanNeededForCustomerBO_Pallets, KanbanNeededForBTO_Pallets, KanbanNeededForSpecialBid_Pallets, KanbanNeededForProjectedBO_Pallets, KanbanNeededForOrange_Pallets, KanbanNeededForRed_Pallets, KanbanNeededForYellow_Pallets, KanbanNeededForGreen_Pallets, MinKanban_Pallets, TargetKanban_Pallets, MaxKanban_Pallets, ExcessKanban_Pallets, HeijunkaBoard_Pallets, Platform, Family, AverageDemand, Pallet_Qty, Type, High_Priority_Units, Remd_Pallet, Lean_Application, PPVT, Yield);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DELETE__VIRTUALKANBAN_VKBDETAILPARTNO
        public bool DELETE_VIRTUALKANBAN_VKBDETAILPARTNO(int idVKB)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.DELETE_VIRTUALKANBAN_VKBDETAILPARTNO(idVKB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Get Connection
        public string Get_Connection()
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.ConnectionString();
            }
            catch
            {
                return string.Empty;
            }
        }

        //Get Table
        public DataSet Get_Table(string strSQL)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.getTableSQL(strSQL);
            }
            catch
            {
                return null;
            }
        }

        //Update Table
        public bool Update_Table(string strSQL)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.updateTable(strSQL);
            }
            catch
            {
                return false;
            }
        }

        //syelamanchal--Adding roles functionality to user--start
        public int Validate_UserInRole(string UserName, string RoleName)
        {
            try
            {
                TestData objTestData = new TestData();
                return objTestData.Validate_UserInRole("/",UserName, RoleName);
            }
            catch
            {
                throw;
            }
        }
        //syelamanchal--Adding roles functionality to user--end

        //syelamanchal
        public  void Log(string type, string page,int line, string user,string logMessage)
        {
            // string path = @"c:\files\Log.txt";
            int count=0;
            string path = Path.Combine(@System.Configuration.ConfigurationManager.AppSettings["LogFileLocation"], "Log_"+String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now,  ".txt"));
            iterate:
            long size = path.Length;
            Decimal FileSize = Decimal.Divide(size, 1048576);
            int sizelimit = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["logfilesizelimit"]);
            if(Convert.ToInt32(FileSize)>=sizelimit)
            {
                path = Path.Combine(@System.Configuration.ConfigurationManager.AppSettings["LogFileLocation"], "Log_"+ count + String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, ".txt"));
                goto iterate;
            }
            using (StreamWriter w = File.AppendText(path))
            {

                w.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} => {type} => {page} => LineNumber:{line.ToString()}=> {user} => {logMessage}");

                w.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        //public  void DumpLog(StreamReader r)
        //{
        //    string line;
        //    while ((line = r.ReadLine()) != null)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}
        //syelamanchal

        #endregion

        #region Capabilities

        public List<dynamic> get_Capabilities(string Lean_Application)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();

                var CapabilitiesSPDataSet = objCPSEntities.Database.SqlQuery<GET_CAPABILITIES_Result>("exec [dbo].GET_CAPABILITIES @Lean_App",
                    new SqlParameter { ParameterName = "Lean_App", Value = Lean_Application }
                    ).ToList<GET_CAPABILITIES_Result>();
                return CapabilitiesSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;
            }
        }

        public bool Update_Capabilities(string Line, string Lean_Application, int Qty)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.UPDATE_CAPABILITIES(Lean_Application, Line, Qty);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region User Control

        public List<dynamic> GetLeanApp()
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var LeanAppSPDataSet = objCPSEntities.Database.SqlQuery<GET_LEAN_APP_Result>
                    ("exec [dbo].[GET_LEAN_APP]").ToList<GET_LEAN_APP_Result>();
                return LeanAppSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;

            }
        }

        public List<dynamic> GetUserControlSites(string UserName)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                var UserSitesSPDataSet = objCPSEntities.Database.SqlQuery<GET_USER_SITES1_Result>("exec [dbo].[GET_USER_SITES] @UserName",
                    new SqlParameter { ParameterName = "UserName", Value = UserName })
                    .ToList<GET_USER_SITES1_Result>();
                return UserSitesSPDataSet.ToList<dynamic>();
            }
            catch
            {
                return null;

            }
        }

        public bool GrantUserAccess(int idSite, string UserName)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.GRANT_USER_ACCESS_TO_USERSITE(UserName, idSite);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RevokeAccess(string UserName, string SiteName)
        {
            try
            {
                CPSEntities objCPSEntities = new CPSEntities();
                objCPSEntities.REVOKE_USER_ACCESS_FROM_USERSITE(UserName, SiteName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion
    }
}