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
    public class StocksDataRepository : Helper
    {
        public void Insert(StocksData StocksData)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spStocksDataInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", StocksData.ProductId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", StocksData.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@SupplierPrice", StocksData.SupplierPrice));
                    cmd.Parameters.Add(new SqlParameter("@TotalAmount", StocksData.TotalAmount));
                    cmd.Parameters.Add(new SqlParameter("@RealUnitPrice", StocksData.RealUnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@RemainingQuantity", StocksData.RemainingQuantity));
                    cmd.Parameters.Add(new SqlParameter("@DeliveryDate", StocksData.DeliveryDate));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationDate", StocksData.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@Duration", StocksData.Duration));
                    cmd.Parameters.Add(new SqlParameter("@Remarks", StocksData.Remarks));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(StocksData StocksData)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spStocksDataUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", StocksData.Id));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", StocksData.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@SupplierPrice", StocksData.SupplierPrice));
                    cmd.Parameters.Add(new SqlParameter("@TotalAmount", StocksData.TotalAmount));
                    cmd.Parameters.Add(new SqlParameter("@RealUnitPrice", StocksData.RealUnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@RemainingQuantity", StocksData.RemainingQuantity));
                    cmd.Parameters.Add(new SqlParameter("@DeliveryDate", StocksData.DeliveryDate));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationDate", StocksData.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@Duration", StocksData.Duration));
                    cmd.Parameters.Add(new SqlParameter("@Remarks", StocksData.Remarks));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spStocksDataDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public StocksData FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM vStocksData" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<StocksData>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }
        public StocksData FindWithStockDataId(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData " +
                        " WHERE Id = '" + Id + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<StocksData>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }

        
        public IList<StocksData> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData WHERE " +
                    "ProductName Like '%" + keyword + "%' " +
                    "OR ProductId Like '%" + keyword + "%' " +
                    "OR CategoryName Like '%" + keyword + "%' " +
                    "OR PrincipalName Like '%" + keyword + "%' " +
                    "ORDER BY ProductName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<StocksData>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public IList<StocksData> FindWithRemainingQTY(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData WHERE " +
                    "(ProductName Like '%" + keyword + "%' " +
                    "OR ProductId Like '%" + keyword + "%' " +
                    "OR CategoryName Like '%" + keyword + "%' " +
                    "OR PrincipalName Like '%" + keyword + "%') AND RemainingQuantity > 0" +
                    "ORDER BY ProductName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<StocksData>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public IList<StocksData> FindWithSelect()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData ORDER BY StockDataName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<StocksData>().CreateList(reader);
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
                var select = "SELECT Id + 1 as Id From StocksData ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                return "C" + Id.ToString("0000");
                            }
                        }
                        else
                        {
                            return "C0001";
                        }
                        return null;

                    }
                }
            }
        }
        public StocksDataStrategy StocksDataStrategy => new StocksDataStrategy();
    }
}
