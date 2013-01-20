using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace MB_Pipeline.Helper
{
    public class Locations
    {
        public static bool Update(MB_Pipeline.Controllers.Models.Location location)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_UpdateLocation]";
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = location.id;
                cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.name) ? location.name : DBNull.Value.ToString());
                cmd.Parameters.Add("address", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.address) ? location.address : DBNull.Value.ToString());
                cmd.Parameters.Add("address_line2", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.address_line2) ? location.address_line2 : DBNull.Value.ToString());
                cmd.Parameters.Add("state", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.state) ? location.state : DBNull.Value.ToString());
                cmd.Parameters.Add("zip_code", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.zip_code) ? location.zip_code : DBNull.Value.ToString());
                //cmd.Parameters.Add("country", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.country) ? location.country : DBNull.Value.ToString());
                cmd.Parameters.Add("city", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.city) ? location.city : DBNull.Value.ToString());
                //cmd.Parameters.Add("location_type", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.location_type) ? location.location_type : DBNull.Value.ToString());
                //cmd.Parameters.Add("role", System.Data.SqlDbType.Int).Value = Helper.Sessions.GetUserFromSession().ID;
                if (Helper.SqlHelper.ExecuteQuery(cmd))
                {
                    Helper.MapsHelper.UpdateCords(location);
                    return true;
                }
                return false;
            }
        }

        public static bool New(MB_Pipeline.Controllers.Models.Location location, int account)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_NewAccountLocation]";
                cmd.Parameters.Add("account", System.Data.SqlDbType.Int).Value = account;
                cmd.Parameters.Add("address", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.address) ? location.address : DBNull.Value.ToString());
                cmd.Parameters.Add("address_line2", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.address_line2) ? location.address_line2 : DBNull.Value.ToString());
                cmd.Parameters.Add("state", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.state) ? location.state : DBNull.Value.ToString());
                cmd.Parameters.Add("zip_code", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.zip_code) ? location.zip_code : DBNull.Value.ToString());
                //cmd.Parameters.Add("country", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.country) ? location.country : DBNull.Value.ToString());
                cmd.Parameters.Add("city", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.city) ? location.city : DBNull.Value.ToString());
                cmd.Parameters.Add("location_type", System.Data.SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(location.location_type) ? location.location_type : DBNull.Value.ToString());
                cmd.Parameters.Add("role", System.Data.SqlDbType.Int).Value = Helper.Sessions.GetUserFromSession().ID;

                var l = Helper.SqlHelper.ReadQuery<int>(cmd);
                if (l.Count > 0)
                {
                    location.id = l[0];
                    Helper.MapsHelper.UpdateCords(location);
                    return true;
                }
                return false;
            }
        }

        public static MB_Pipeline.Controllers.Models.Location GetLocation(int id, int account)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_GetLocation]";
                cmd.Parameters.Add("id", System.Data.SqlDbType.Int).Value = id;
                cmd.Parameters.Add("accountId", System.Data.SqlDbType.Int).Value = account;
                var result = Helper.SqlHelper.ReadQuery<MB_Pipeline.Controllers.Models.Location>(cmd);
                if (result != null && result.Count > 0)
                {
                    return result[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}