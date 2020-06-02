using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
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

                var select = "INSERT INTO Categories (CategoryName,Description) Values " +
                    "('" + Categories.CategoryName.ToUpper() + "','" + Categories.Description.ToUpper() + "')";

  
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Update(Categories Categories)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Categories SET CategoryName = '" + Categories.CategoryName.ToUpper() + "'," +
                    " Description ='" + Categories.Description.ToUpper() + "', " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + Categories.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Delete(Categories Categories)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "DELETE FROM Categories " +
                    " WHERE Id = " + Categories.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public Categories FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Categories" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Categories = new Categories
                            {
                                Id = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                            };
                            if (!reader.IsDBNull(4))
                            {
                                Categories.UpdateTime = reader.GetDateTime(4);
                            }

                            return Categories;
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
                var select = "SELECT *  FROM Categories" +
                        " WHERE CategoryName Like '%" + keyword + "%' OR Description Like '%" + keyword + "%' ORDER BY CategoryName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Categories> Items = new List<Categories>();
                        while (reader.Read())
                        {
                            var brand = new Categories
                            {
                                Id = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                            };
                            if (!reader.IsDBNull(4))
                            {
                                brand.UpdateTime = reader.GetDateTime(4);
                            }

                            Items.Add(brand);
                        }
                        return Items;
                    }
                }
            }
        }

        public IList<Categories> FindWithSelect()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Categories ORDER BY CategoryName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Categories> Items = new List<Categories>
                        {
                            new Categories { CategoryName = "-SELECT-", Id = 0 }
                        };
                        while (reader.Read())
                        {
                            var company = new Categories
                            {
                                Id = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                            };
                            if (!reader.IsDBNull(4))
                            {
                                company.UpdateTime = reader.GetDateTime(4);
                            }

                            Items.Add(company);
                        }
                        return Items;
                    }
                }
            }
        }
        public CategoriesStrategy CategoriesStrategy => new CategoriesStrategy();
    }
}
