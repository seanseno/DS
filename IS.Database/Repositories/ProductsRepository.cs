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
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", item.PrincipalId.ToUpper()));
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
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", item.PrincipalId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", item.ProductName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@Active", item.Active));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));
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

        public Products FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                return null;
                //var select = "SELECT I.Id, I.CompanyId, I.GenericName, I.BrandName, I.Description, I.Price , " +
                //                " S.Stock,Co.CompanyName,Ca.CategoryName,I.BarCode" +
                //                " FROM Products as I " +
                //                " LEFT JOIN Stocks as S on S.ProductId = I.id " +
                //                " LEFT JOIN Companies as Co on Co.id = I.CompanyId" +
                //                " LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId" +
                //                " WHERE I.Id = " + id;

                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {

                //        while (reader.Read())
                //        {
                //            var item = new Products();

                //            item.Id = reader.GetInt32(0);
                            
                            
                //            item.Description = reader.GetString(4);
                //            item.SellingPricePerPiece = Math.Round(reader.GetDecimal(5), 2);
                //            item.Stock = reader.GetInt32(6);


                //            if (!reader.IsDBNull(1))
                //            {
                //                item.CompanyId = reader.GetInt32(1);
                //            }
                //            if (!reader.IsDBNull(2))
                //            {
                //                item.GenericName = reader.GetString(2);
                //            }
                //            if (!reader.IsDBNull(3))
                //            {
                //                item.BrandName = reader.GetString(3);
                //            }

                //            if (!reader.IsDBNull(7))
                //            {
                //                item.CompanyName = reader.GetString(7);
                //            }
                //            if (!reader.IsDBNull(8))
                //            {
                //                item.CategoryName = reader.GetString(8);
                //            }
                //            if (!reader.IsDBNull(9))
                //            {
                //                item.BarCode = reader.GetString(9);
                //            }

                //            return item;
                //        }
                //        return null;
                //    }
                //}
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

        public string GetNextId()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id + 1 as Id From vProducts ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                return "I" + Id.ToString("0000");
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
