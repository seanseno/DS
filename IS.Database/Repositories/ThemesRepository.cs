using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using IS.Database.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class ThemesRepository : Helper
    {

        public IList<Themes> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Themes";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Themes>().CreateList(reader);
                    }
                }
            }
        }


        public void Update(Themes model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spThemesUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", model.CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@Logo", model.Logo));
                    cmd.Parameters.Add(new SqlParameter("@WallPaper", model.WallPaper));
                    cmd.Parameters.Add(new SqlParameter("@Red", model.Red));
                    cmd.Parameters.Add(new SqlParameter("@Green", model.Green));
                    cmd.Parameters.Add(new SqlParameter("@Blue", model.Blue));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }
        
    }
}
