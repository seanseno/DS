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
        public  (int?,bool,string) CheckAdministratorLogin(string Loginname, string Password)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    return (null, false, ex.Message);
                }
                var select = "SELECT * FROM Administrators WHERE Loginname='" + Loginname + "' AND Password ='" + Encryption.CreateMD5(Password.ToUpper(), this.IsEncrypt) + "' AND Active = " + (int)EnumActive.Active;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);

                                return (Id, true,string.Empty);
                            }
                        }
                        return (null, false, string.Empty);
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
