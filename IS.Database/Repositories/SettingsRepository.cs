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
    public class SettingsRepository : Helper
    {
        public  IList<Settings> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Settings", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Settings>().CreateList(reader);
                    }
                }
            }
        }

        public void Update(Settings settings)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spSettingsUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", settings.Id));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationAlert", settings.ExpirationAlert));
                    cmd.Parameters.Add(new SqlParameter("@SeniorDiscount", settings.SeniorDiscount));
                    cmd.Parameters.Add(new SqlParameter("@PWDDiscount", settings.PWDDiscount));
                    cmd.Parameters.Add(new SqlParameter("@ReturnItem", settings.ReturnItem));
                    cmd.Parameters.Add(new SqlParameter("@WithPrinter", settings.WithPrinter));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }
    }
}
