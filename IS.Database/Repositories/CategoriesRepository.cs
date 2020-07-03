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
    public class CategoriesRepository : Helper
    {
        public void Insert(Categories Categories)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spCategoriesInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", Categories.CategoryName.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Categories Categories)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spCategoriesUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", Categories.CategoryName.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public void Delete(Categories Categories)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spCategoriesDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", Categories.CategoryId.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public Categories FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM vCategories" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<Categories>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }
        public Categories FindWithCategoryId(string CategoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCategories " +
                        " WHERE CategoryId = '" + CategoryId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<Categories>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }


        public IList<Categories> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCategories" +
                        " WHERE CategoryName Like '%" + keyword + "%' or CategoryId Like '%" + keyword + "%' ORDER BY CategoryName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Categories>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public IList<Categories> FindWithSelect()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCategories ORDER BY CategoryName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Categories>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public CategoriesStrategy CategoriesStrategy => new CategoriesStrategy();
    }
}
