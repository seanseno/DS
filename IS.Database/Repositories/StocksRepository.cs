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
    public class StocksRepository : Helper
    {
        public void Insert(Stocks stock)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                //connection.Open();
                //var select = "INSERT INTO Stocks (ItemId,Stock,Active) Values " +
                //    "(" + stock.ProductId + "," + stock.Stock + "," + (int)EnumActive.Active + ")";
                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{

                //    var stocks = new Stocks
                //    {
                //        Id = Convert.ToInt32(cmd.ExecuteScalar()),
                //        ItemId = stock.ProductId,
                //        Stock = stock.Stock,
                //        InsertTime = DateTime.Now,
                //        Active = (int)EnumActive.Active,
                //    };

                //}
                //if (connection.State == System.Data.ConnectionState.Open)
                //    connection.Close();
            }
            ISFactory factory = new ISFactory();
            factory.StocksHistoryRepository.Insert(stock, stock.Stock,EnumStock.Credit);
        }

        public void Update(Stocks stock, int? qty, EnumStock enumStock)
        {
            //var currentStock = FindWithItemId(stock.ProductId);
            //int newStock = 0;
            //if (enumStock == EnumStock.Credit)
            //{
            //    newStock = (int)currentStock.Stock + (int)qty;
            //}
            //else
            //{
            //    newStock = (int)currentStock.Stock - (int)qty;
            //}
            //stock.Stock = newStock;
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();
            //    var select = "UPDATE  Stocks SET  Stocks.Stock  = " + newStock + "  " +
            //        " WHERE ItemId = " + stock.ProductId;

            //    using (SqlCommand cmd = new SqlCommand(select, connection))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }

            //    if (connection.State == System.Data.ConnectionState.Open)
            //        connection.Close();
            //}

            //ISFactory factory = new ISFactory();
            //factory.StocksHistoryRepository.Insert(stock, qty, enumStock);
        }

        public Products FindWithItemId(int? ItemID)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                //var select = "SELECT i.Id, i.BrandName,i.Description,s.Stock  From Stocks as s" +
                //            " INNER JOIN Products as i on i.Id = s.ProductId " +
                //            " WHERE s.ProductId = " + ItemID;

                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        List<Products> Products = new List<Products>();
                //        while (reader.Read())
                //        {
                //            var item = new Products
                //            {
                //                Id = reader.GetInt32(0),
                //                BrandName = reader.GetString(1),
                //                Description = reader.GetString(2),
                //                Stock = reader.GetInt32(3),
                //            };
                //            return item;
                //        }
                //        return null;
                //    }
                //}
                return null;
            }

        }
        public IList<Products> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                return null;
                //var select = "SELECT i.Id, i.GenericName, i.BrandName,i.Description,s.Stock  From Stocks as s" +
                //            " INNER JOIN Products as i on i.Id = s.ProductId " +
                //            " WHERE i.BrandName Like '%" + keyword + "%' AND i.Description Like '%" + keyword + "%'" +
                //            " ";
                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        List<Products> Products = new List<Products>();
                //        while (reader.Read())
                //        {
                //            var item = new Products
                //            {
                //                Id = reader.GetInt32(0),
                //                GenericName = reader.GetString(1),
                //                BrandName = reader.GetString(2),
                //                Description = reader.GetString(3),
                //                Stock = reader.GetInt32(4),
                //                //InsertTime = reader.GetDateTime(4),
                //                //Active = reader.GetInt32(6)
                //            };

                //            Products.Add(item);
                //        }
                //        return Products;
                //    }
                //}
            }
        }
        public StocksStrategy StocksStrategy => new StocksStrategy();
    }
}
