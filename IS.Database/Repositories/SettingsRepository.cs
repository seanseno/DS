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
        public void Insert(Settings Categories)
        {
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();

            //    using (SqlCommand cmd = new SqlCommand("spCategoriesInsert", connection))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));
            //        cmd.Parameters.Add(new SqlParameter("@CategoryName", Categories.CategoryName.ToUpper()));
            //        cmd.Parameters.Add(new SqlParameter("@PercentSuggestedPrice", Categories.PercentSuggestedPrice));
            //        int rowAffected = cmd.ExecuteNonQuery();

            //        if (connection.State == System.Data.ConnectionState.Open)
            //            connection.Close();
            //    }
            //}
        }

        public void Update(Categories Categories)
        {
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();

            //    using (SqlCommand cmd = new SqlCommand("spCategoriesUpdate", connection))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));
            //        cmd.Parameters.Add(new SqlParameter("@CategoryName", Categories.CategoryName.ToUpper()));
            //        cmd.Parameters.Add(new SqlParameter("@PercentSuggestedPrice", Categories.PercentSuggestedPrice));
            //        int rowAffected = cmd.ExecuteNonQuery();

            //        if (connection.State == System.Data.ConnectionState.Open)
            //            connection.Close();
            //    }

            //}
        }

        public void Delete(Categories Categories)
        {
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();

            //    using (SqlCommand cmd = new SqlCommand("spCategoriesDelete", connection))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));

            //        int rowAffected = cmd.ExecuteNonQuery();

            //        if (connection.State == System.Data.ConnectionState.Open)
            //            connection.Close();
            //    }

            //}
        }

    }
}
