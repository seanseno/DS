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
    public class CompaniesRepository : Helper
    {
        public void Insert(Companies company)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "INSERT INTO Companies (CompanyName,Description) Values " +
                    "('" + company.CompanyName.ToUpper() + "','" + company.Description.ToUpper() + "')";

  
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Update(Companies company)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Companies SET CompanyName = '" + company.CompanyName.ToUpper() + "'," +
                    " Description ='" + company.Description.ToUpper() + "', " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + company.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Delete(Companies company)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "DELETE FROM Companies " +
                    " WHERE Id = " + company.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public Companies FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Companies" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var company = new Companies
                            {
                                Id = reader.GetInt32(0),
                                CompanyName = reader.GetString(1),
                                Description = reader.GetString(2),
                                InsertTime = reader.GetDateTime(3),
                            };
                            if (!reader.IsDBNull(4))
                            {
                                company.UpdateTime = reader.GetDateTime(4);
                            }

                            return company;
                        }
                        return null;
                    }
                }
            }
        }

        public IList<Companies> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Companies" +
                        " WHERE CompanyName Like '%" + keyword + "%' OR Description Like '%" + keyword + "%' ORDER BY CompanyName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Companies> Items = new List<Companies>();
                        while (reader.Read())
                        {
                            var company = new Companies
                            {
                                Id = reader.GetInt32(0),
                                CompanyName = reader.GetString(1),
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

        public IList<Companies> FindWithSelect()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM Companies ORDER BY CompanyName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Companies> Items = new List<Companies>
                        {
                            new Companies { CompanyName = "-SELECT-", Id = 0 }
                        };
                        while (reader.Read())
                        {
                            var company = new Companies
                            {
                                Id = reader.GetInt32(0),
                                CompanyName = reader.GetString(1),
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
        public CompaniesStrategy CompaniesStrategy => new CompaniesStrategy();
    }
}
