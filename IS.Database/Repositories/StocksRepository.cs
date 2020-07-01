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

        public void Update(string ProductId, int Stock ,int CurrentStock, EnumStock enumStock)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spStocksUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", ProductId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Stocks", Stock));
                    cmd.Parameters.Add(new SqlParameter("@CurrentStocks", CurrentStock));
                    cmd.Parameters.Add(new SqlParameter("@Operation", (int)enumStock));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public Stocks FindWithProductId(string ProductID)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProducts " +
                            " WHERE ProductId = '" + ProductID + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return new ReflectionPopulator<Stocks>().CreateList(reader)[0];
                        }
                        return null;
                    }
                }
            }

        }
        public IList<Stocks> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocks " +
                            " WHERE ProductId like '%" + keyword + "%' OR" +
                            " ProductName like '%" + keyword + "%'" +
                            " ORDER BY ProductName";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return new ReflectionPopulator<Stocks>().CreateList(reader);
                        }
                        return null;
                    }
                }
            }
        }
        public StocksStrategy StocksStrategy => new StocksStrategy();
    }
}
