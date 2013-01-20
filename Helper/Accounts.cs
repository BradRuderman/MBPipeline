using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB_Pipeline.Controllers.Models;
using System.Data.SqlClient;

namespace MB_Pipeline.Helper
{
    public class Accounts
    {
        public static List<Account_Dashboard> GetAccountDashboard(int user)
        {
            List<Account_Dashboard> result = new List<Account_Dashboard>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetAccountDashboards]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = user;
                result = SqlHelper.ReadQuery<Account_Dashboard>(cmd);
            }
            return result;
        }

        public static Account_Dashboard GetAccountDetails(int user, int account_id)
        {
            List<Account_Dashboard> result = new List<Account_Dashboard>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetAccountDetails]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = account_id;
                cmd.Parameters.Add("user", System.Data.SqlDbType.Int).Value = user;
                result = SqlHelper.ReadQuery<Account_Dashboard>(cmd);
            }
            return (result != null ? result[0] : null);
        }

        public static List<Contact> GetContacts(int account_id)
        {
            List<Contact> result = new List<Contact>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetAccountContacts]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = account_id;
                result = SqlHelper.ReadQuery<Contact>(cmd);
            }
            return result;
        }

        public static List<Contact_Owner> GetContact(int contact_id)
        {
            List<Contact_Owner> result = new List<Contact_Owner>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetContact]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = contact_id;
                result = SqlHelper.ReadQuery<Contact_Owner>(cmd);
            }
            return result;
        }

        public static List<Parent_Account> GetParentAccounts(int User_Id)
        {
            List<Parent_Account> result = new List<Parent_Account>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetParentAccount]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", System.Data.SqlDbType.Int).Value = User_Id;
                result = SqlHelper.ReadQuery<Parent_Account>(cmd);
            }
            return result;
        }

        public static bool CreateAccount(string name, int parent_account, int user_id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_CreateAccount]";
                cmd.Parameters.Add("ParentId", System.Data.SqlDbType.Int).Value = parent_account;
                cmd.Parameters.Add("UserId", System.Data.SqlDbType.Int).Value = user_id;
                cmd.Parameters.Add("Name", System.Data.SqlDbType.NVarChar).Value = name;
                if (Helper.SqlHelper.ExecuteQuery(cmd))
                {
                    return true;
                }
                return false;
            }
        }

        public static List<Location> GetLocations(int account_id)
        {
            List<Location> result = new List<Location>();
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_GetAccountLocations]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("accountid", System.Data.SqlDbType.Int).Value = account_id;
                result = SqlHelper.ReadQuery<Location>(cmd);
            }
            return result;
        }

        public static bool UpdateSalesInformation(Account_Dashboard act)
        {
            bool result = false;
            using (SqlCommand cmd = new SqlCommand("[dbo].[usp_UpdateSalesInformation]"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = act.ID;
                cmd.Parameters.Add("sales_stage", System.Data.SqlDbType.NVarChar).Value = act.sales_stage;
                cmd.Parameters.Add("account_rank", System.Data.SqlDbType.NVarChar).Value = act.account_rank;
                cmd.Parameters.Add("volume", System.Data.SqlDbType.Float).Value = act.volume;
                cmd.Parameters.Add("units", System.Data.SqlDbType.NVarChar).Value = act.units;
                cmd.Parameters.Add("revenue", System.Data.SqlDbType.Decimal).Value = act.revenue;
                cmd.Parameters.Add("visits_per_year", System.Data.SqlDbType.Int).Value = act.visits_per_year;
                result = SqlHelper.ExecuteQuery(cmd);
            }
            return result;
        }
    }
}