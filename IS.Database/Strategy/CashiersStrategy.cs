using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Database.Enums;
using IS.Common.Utilities;
using IS.Database.Entities;

namespace IS.Database.Strategy
{
    public class CashiersStrategy : Helper
    {
        public (string,bool) CheckCashierLogin(string Loginname, string Password)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCashiers WHERE Loginname='" + Loginname + "' AND Password ='" + Encrypt.CreateMD5(Password.ToUpper(), this.IsEncrypt) + "' AND Active = " + (int)EnumActive.Active;
                using (SqlCommand cmd = new SqlCommand(select,connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var cashier = new ReflectionPopulator<Cashiers>().CreateList(reader)[0];
                            return (cashier.CashierId, true);
                        }
                        return ("", false);
                    }
                }
            }
        }

        public bool CheckDuplicate(string LoginName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Loginname FROM Cashiers WHERE Loginname = '" + LoginName + "'";
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
