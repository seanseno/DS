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
    public class LedgerSalesRepository : Helper
    {
        public IList<LedgerSales> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM LedgerSales";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<LedgerSales>().CreateList(reader);
                    }
                }
            }
        }
        public int Insert(Cashiers cashier, decimal PayAmount, decimal Change,string customerName, string additionalInfo, int tempLedgerSaleId)
        {
            int LedgerId = 0;
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                //STORE PROC INSERT ITEM and STOCKS
                using (SqlCommand cmd = new SqlCommand("spInsertKioskSale", connection))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CashierId", cashier.CashierId));
                    cmd.Parameters.Add(new SqlParameter("@PayAmount", PayAmount));
                    cmd.Parameters.Add(new SqlParameter("@Change", Change));
                    cmd.Parameters.Add(new SqlParameter("@CustomerName", string.IsNullOrEmpty(customerName)? "" : customerName));
                    cmd.Parameters.Add(new SqlParameter("@AdditionalInfo", string.IsNullOrEmpty(additionalInfo) ? "" : additionalInfo));
                    cmd.Parameters.Add(new SqlParameter("@TempLedgerSaleId", tempLedgerSaleId));
   

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<LedgerSales> Items = new List<LedgerSales>();
                        while (reader.Read())
                        {
                           LedgerId = reader.GetInt32(0);
                           break;
                        }
                       
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
                return LedgerId;
            }
        }

        public int ReturnItem(int StockDataId, int SalesId, int Quantity, int QuantityReturn, string Remarks, string LoginName)
        {
            int LedgerId = 0;
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spReturnItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StockDataId", StockDataId));
                    cmd.Parameters.Add(new SqlParameter("@SalesId", SalesId));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
                    cmd.Parameters.Add(new SqlParameter("@QuantityReturn", QuantityReturn));
                    cmd.Parameters.Add(new SqlParameter("@Remarks", Remarks));
                    cmd.Parameters.Add(new SqlParameter("@LoginName", LoginName));
                    
                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
                return LedgerId;
            }
        }
    }
}
