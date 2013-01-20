using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace MB_Pipeline.Helper
{
    public class Contacts
    {
        public static List<SelectListItem> GetStateDropdown()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            using (SqlCommand cmd = new SqlCommand("SELECT state, state_abr from States ORDER BY state_abr asc"))
            {
                List<MB_Pipeline.Controllers.Models.State> states = SqlHelper.ReadQuery<MB_Pipeline.Controllers.Models.State>(cmd);
                foreach (MB_Pipeline.Controllers.Models.State state in states)
                {
                    result.Add(new SelectListItem() { Text = state.state_abr, Value = state.state });
                }
            }
            return result;
        }

        public static bool Update(MB_Pipeline.Controllers.Models.Contact contact)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_UpdateContact]";
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = contact.id;
                cmd.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.title) ? contact.title : DBNull.Value.ToString());
                cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.name) ? contact.name : DBNull.Value.ToString());
                cmd.Parameters.Add("address", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.address) ? contact.address : DBNull.Value.ToString());
                cmd.Parameters.Add("address_line2", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.address_line2) ? contact.address_line2 : DBNull.Value.ToString());
                cmd.Parameters.Add("state", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.state) ? contact.state : DBNull.Value.ToString());
                cmd.Parameters.Add("zip_code", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.zip_code) ? contact.zip_code : DBNull.Value.ToString());
                cmd.Parameters.Add("email", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.email) ? contact.email : DBNull.Value.ToString());
                cmd.Parameters.Add("country", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.country) ? contact.country : DBNull.Value.ToString());
                cmd.Parameters.Add("phone_number", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.phone_number) ? contact.phone_number : DBNull.Value.ToString());
                cmd.Parameters.Add("secondary_number", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.secondary_number) ? contact.secondary_number : DBNull.Value.ToString());
                cmd.Parameters.Add("city", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.city) ? contact.city : DBNull.Value.ToString());
                if (Helper.SqlHelper.ExecuteQuery(cmd))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool New(MB_Pipeline.Controllers.Models.Contact contact, int account)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_NewContact]";
                cmd.Parameters.Add("account", System.Data.SqlDbType.Int).Value = account;
                cmd.Parameters.Add("title", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.title) ? contact.title : DBNull.Value.ToString());
                cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.name) ? contact.name : DBNull.Value.ToString());
                cmd.Parameters.Add("address", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.address) ? contact.address : DBNull.Value.ToString());
                cmd.Parameters.Add("address_line2", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.address_line2) ? contact.address_line2 : DBNull.Value.ToString());
                cmd.Parameters.Add("state", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.state) ? contact.state : DBNull.Value.ToString());
                cmd.Parameters.Add("zip_code", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.zip_code) ? contact.zip_code : DBNull.Value.ToString());
                cmd.Parameters.Add("email", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.email) ? contact.email : DBNull.Value.ToString());
                cmd.Parameters.Add("country", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.country) ? contact.country : DBNull.Value.ToString());
                cmd.Parameters.Add("phone_number", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.phone_number) ? contact.phone_number : DBNull.Value.ToString());
                cmd.Parameters.Add("secondary_number", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.secondary_number) ? contact.secondary_number : DBNull.Value.ToString());
                cmd.Parameters.Add("city", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(contact.city) ? contact.city : DBNull.Value.ToString());
                if (Helper.SqlHelper.ExecuteQuery(cmd))
                {
                    return true;
                }
                return false;
            }
        }
    }
}