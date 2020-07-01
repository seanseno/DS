using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace IS.Database.Strategy
{
    public class StocksStrategy : Helper
    {
        public bool CheckStock(string ProductId, int? Qty)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT stock FROM Stocks WHERE ProductId = '" + ProductId + "'";
                using (SqlCommand cmd = new SqlCommand(select,connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var Stock = reader.GetInt32(0);
                                if(Stock >= Qty)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
        }
    }
}
