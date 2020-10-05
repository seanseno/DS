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
    public class ProductsRepository : Helper
    {
        public List<Products> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProducts";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Products> Products = new List<Products>();
                        var List = new ReflectionPopulator<Products>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public List<ProductsKiosk> GetListFromKiosk()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProductsKiosk";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ProductsKiosk> Products = new List<ProductsKiosk>();
                        var List = new ReflectionPopulator<ProductsKiosk>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        
        public void Insert(Products item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC INSERT ITEM and STOCKS
                using (SqlCommand cmd = new SqlCommand("spProductsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", item.ProductId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", item.ProductName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Products item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spProductsUpdate", connection))
                {
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", item.ProductId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", item.ProductName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@Active", item.Active));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));
                    cmd.Parameters.Add(new SqlParameter("@LoginName", Globals.LoginName));
              
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public void Delete(Products item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spProductsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", item.ProductId.ToUpper()));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public Products FindWithProductId(string ProductId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProducts " +
                          " WHERE ProductId Like '" + ProductId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Products> Products = new List<Products>();
                        var List = new ReflectionPopulator<Products>().CreateList(reader);
                        return List[0];
                    }
                }
            }
        }

        public int GetTotalCount()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Count(ProductId) as Counts FROM vProducts";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return reader.GetInt32(0);
                            }
                        }
                        return 0;
                    }
                }
            }
        }

        public IList<Products> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProducts " +
                                " WHERE ProductName Like '%" + keyword + "%'" +
                                " OR CategoryName Like '%" + keyword + "%' " +
                                " OR PrincipalName Like '%" + keyword + "%' " +
                                " OR BarCode Like '%" + keyword + "%' " +
                            " ORDER BY ProductName";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Products> Products = new List<Products>();
                        var List = new ReflectionPopulator<Products>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public IList<Products> FindListActive(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProducts " +
                                " WHERE (ProductName Like '%" + keyword + "%'" +
                                " OR ProductId Like '%" + keyword + "%' " +
                                " OR CategoryName Like '%" + keyword + "%' " +
                                " OR PrincipalName Like '%" + keyword + "%' " +
                                " OR BarCode Like '%" + keyword + "%' )" +
                                " AND Price > 0 " +
                                " AND Active = " + (int)EnumActive.Active +
                            " ORDER BY ProductName";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Products> Products = new List<Products>();
                        var List = new ReflectionPopulator<Products>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public string GetNextId()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id + 1 as Id From Products ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                return "I" + Id.ToString("000000");
                            }
                        }
                        else
                        {
                            return "I000001";
                        }
                        return null;

                    }
                }
            }
        }
        public ProductsStrategy ProductsStrategy => new ProductsStrategy();

    }
}
