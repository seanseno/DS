using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using IS.Database.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class ReturnStocksDataRepository : Helper
    {
        public IList<ReturnItemsToSupplierView> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vStocksDataReturnToSupplier", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<ReturnItemsToSupplierView>().CreateList(reader);
                    }
                }
            }
        }

        public void Insert(ReturnStocksData model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spReturnStockData", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StockDataId", model.StockDataId));
                    cmd.Parameters.Add(new SqlParameter("@QuantityReturn", model.ReturnQty));
                    cmd.Parameters.Add(new SqlParameter("@Remarks", model.Remarks.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@LoginName", model.LoginName));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
