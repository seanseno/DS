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
        public int Insert(Cashiers cashier, decimal PayAmount, decimal Change,string customerName,int tempLedgerSaleId)
        {
            int LedgerId = 0;
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                //STORE PROC INSERT ITEM and STOCKS
                using (SqlCommand cmd = new SqlCommand("spInsertKioskSale", connection))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CashierId", cashier.Id));
                    cmd.Parameters.Add(new SqlParameter("@PayAmount", PayAmount));
                    cmd.Parameters.Add(new SqlParameter("@Change", Change));
                    cmd.Parameters.Add(new SqlParameter("@CustomerName", customerName));
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

        public void Update(LedgerSales ledger, EnumActive enumActive)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "UPDATE  LedgerSales SET Active =" + (int)enumActive + " WHERE Id = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(LedgerSales ledger)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM LedgerSales WHERE Id = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public LedgerSales FindDefault(int? cashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id From LedgerSales  WHERE Active = " + (int)EnumActive.Active + " ORDER BY InsertTime";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new LedgerSales();

                            item.Id = reader.GetInt32(0);
                            return item;
                        }
                        return null;
                    }
                }
            }
        }

        public IList<LedgerSales> Find(int? cashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT LedgerSales.Id, Orders.CashierId,Cashiers.Fullname, SUM(Items.Price) as TotalAmount, SUM(Orders.Qty) as TotalQty ,LedgerSales.InsertTime " +
                            " FROM Orders " +
                            " INNER JOIN Items on Items.Id = Orders.ProductId " +
                            " INNER JOIN   LedgerSales on LedgerSales.CashierId = Orders.CashierId AND LedgerSales.id = Orders.LedgerId " +
                            " INNER JOIN   Cashiers on Cashiers.id = LedgerSales.CashierId " +
                            " GROUP BY LedgerSales.Id,Orders.CashierId,Cashiers.Fullname,LedgerSales.Active,LedgerSales.InsertTime " +
                            " HAVING Orders.CashierId = " + cashierId + " AND LedgerSales.Active = " + (int)EnumActive.NonActive  + "" + 
                            " ORDER BY LedgerSales.InsertTime "; 


                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<LedgerSales> Items = new List<LedgerSales>();
                        while (reader.Read())
                        {
                            var item = new LedgerSales();

                            item.Id = reader.GetInt32(0);
                            item.CashierId = reader.GetInt32(1);
                            item.Fullname = reader.GetString(2);
                            item.TotalAmount = reader.GetDecimal(3);
                            item.TotalQty = reader.GetInt32(4);
                            item.InsertTime = reader.GetDateTime(5);
                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }

        public Decimal FindTotal(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT SUM(Items.Price * Orders.Qty) as TotalAmount FROM Orders INNER JOIN Items on Items.id = Orders.ProductId";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Sales> Items = new List<Sales>();
                        while (reader.Read())
                        {
                            return reader.GetDecimal(0);                   
                        }
                    }
                    return 0;
                }
            }
        }

         //public LedgerSalesStrategy LedgerSalesStrategy => new LedgerSalesStrategy();
    }
}
