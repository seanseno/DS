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
    public class BrandsRepository : Helper
    {
        public void Insert(Brands brand)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "INSERT INTO Brands (Name,Description,Active) Values " +
                    "('" + brand.Name.ToUpper() + "','" + brand.Description.ToUpper() + "'," +
                    "" + brand.Active + ")";

  
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Update(Brands brand)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Brands SET Name = '" + brand.Name.ToUpper() + "'," +
                    " Description ='" + brand.Description.ToUpper() + "', " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + brand.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Delete(Brands brand)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "DELETE FROM Brands " +
                    " WHERE Id = " + brand.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public Brands FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Brands" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var brand = new Brands
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                                Active = reader.GetInt32(5)
                            };
                            if (!reader.IsDBNull(4))
                            {
                                brand.UpdateTime = reader.GetDateTime(4);
                            }

                            return brand;
                        }
                        return null;
                    }
                }
            }
        }

        public IList<Brands> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Brands" +
                        " WHERE Name Like '%" + keyword + "%' OR Description Like '%" + keyword + "%' ORDER BY Name";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Brands> Items = new List<Brands>();
                        while (reader.Read())
                        {
                            var brand = new Brands
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                                Active = reader.GetInt32(5)
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

        public BrandsStrategy BrandsStrategy => new BrandsStrategy();
    }
}
