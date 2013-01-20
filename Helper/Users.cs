using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MB_Pipeline.Controllers.Models;
using System.Data.SqlClient;
using System.Data;

namespace MB_Pipeline.Helper
{
    public static class Users
    {
        public static List<User> User(int i = 0)
        {
            return Helper.SqlHelper.ReadQuery<User>("SELECT * FROM users");
        }

        public static User GetUser(string Email)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM USERS WHERE EMAIL = @Email";
                cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
                var user = Helper.SqlHelper.ReadQuery<User>(cmd);
                if (user != null && user.Count > 0)
                {
                    return user[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}