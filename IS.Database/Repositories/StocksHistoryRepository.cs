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
    public class StocksHistoryRepository : Helper
    {
        public void Insert(Stocks stock,int? qty,EnumStock enumStock)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "INSERT INTO StocksHistory (ItemId,Stock,Credit,Debit) Values " +
                    "(" + stock.ItemId + "," + stock.Stock + "," +
                    "" + qty + ",0)";
                if (enumStock == EnumStock.Debit)
                {

                     select = "INSERT INTO StocksHistory (ItemId,Stock,Credit,Debit) Values " +
                        "(" + stock.ItemId + "," + stock.Stock + "," +
                        "0," + qty + ")";
                }
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }
    }
}
