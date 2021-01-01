using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class TempPromoDetailsRepository : Helper
    {

        public void Insert(TempPromoDetails model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spTempPromoDetailsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", model.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Price", model.Price));
                    cmd.Parameters.Add(new SqlParameter("@LoginId", Globals.LoginId));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public void Delete()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM TempPromoDetails WHERE LoginId ='" + Globals.LoginId + "'", connection))
                {
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
