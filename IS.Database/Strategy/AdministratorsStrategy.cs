using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Common.Utilities;
using IS.Database.Enums;

namespace IS.Database.Strategy
{
    public class AdministratorsStrategy : Helper
    {
        public  bool CheckAdministratorLogin(string Loginname, string Password)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Administrators WHERE Loginname='" + Loginname + "' AND Password ='" + Encrypt.CreateMD5(Password.ToUpper(), this.IsEncrypt) + "' AND Active = " + (int)EnumActive.Active;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return  true;
                            }
                        }
                        return false;
                    }
                }
            }
        }

        public bool CheckDuplicate(string LoginName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Loginname FROM Administrators WHERE Loginname = '" + LoginName + "'";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
    }
}
