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
    public class TempLedgerSalesRepository : Helper
    {
        public TempLedgerSales Insert(int? cashierId, string customerName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO TempLedgerSales (CashierId,Active,CustomerName) Values " +
                    "("+ cashierId + ","+ (int)EnumActive.Active + ",'" + customerName + "'); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {

                    var tempLedgerSales = new TempLedgerSales
                    {
                        Id = Convert.ToInt32(cmd.ExecuteScalar()),
                        CashierId = (int)cashierId,
                        CustomerName = customerName,
                        InsertTime = DateTime.Now
                    };


                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    return tempLedgerSales;
                }
            }
        }

        public void Update(TempLedgerSales ledger, EnumActive enumActive)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "UPDATE  TempLedgerSales SET Active =" + (int)enumActive + " WHERE Id = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(TempLedgerSales ledger)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM TempLedgerSales WHERE Id = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TempLedgerSales FindDefault(int? cashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * From TempLedgerSales  WHERE Active = " + (int)EnumActive.Active + " AND CashierId = " + cashierId + " ORDER BY InsertTime";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var tempLedger = new TempLedgerSales
                                {
                                    Id = reader.GetInt32(0),
                                    CashierId = reader.GetInt32(1),
                                    InsertTime = reader.GetDateTime(2),
                                    Active = reader.GetInt32(3),
                                    CustomerName = reader.GetString(4)
                                };
                                return tempLedger;
                            }
                        }
                        else
                        {
                            var factory = new ISFactory();
                            return  factory.TempLedgerSalesRepository.Insert(cashierId,"TempCostumer");
                        }
                    }
                    return null;
                }
            }
        }

        public IList<TempLedgerSales> Find(int? cashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT TempLedgerSales.ID, Sum((Items.Price * TempSales.Qty)) as TotalAmount , SUM(TempSales.Qty) as TotalQty ,TempLedgerSales.InsertTime " +
                            " FROM TempLedgerSales " + 
                            " INNER JOIN TempSales on TempSales.TempLedgerId = TempLedgerSales.id " +
                            " INNER JOIN Items on Items.Id = TempSales.ProductId " +
                            " GROUP BY TempLedgerSales.ID,TempLedgerSales.CashierId ,TempLedgerSales.Active,TempLedgerSales.InsertTime " +
                            " HAVING TempLedgerSales.CashierId = " + cashierId + " AND TempLedgerSales.Active = " + (int)EnumActive.NonActive; 


                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempLedgerSales> Items = new List<TempLedgerSales>();
                        while (reader.Read())
                        {
                            var item = new TempLedgerSales();
                            item.Id = reader.GetInt32(0);
                            item.TotalAmount = reader.GetDecimal(1);
                            item.TotalQty = reader.GetInt32(2);
                            item.InsertTime = reader.GetDateTime(3);
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
                var select = "SELECT SUM(Items.Price * TempSales.Qty) as TotalAmount FROM TempSales INNER JOIN Items on Items.id = TempSales.ProductId";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempSales> Items = new List<TempSales>();
                        while (reader.Read())
                        {
                            return reader.GetDecimal(0);                   
                        }
                    }
                    return 0;
                }
            }
        }

         public TempLedgerSalesStrategy TempLedgerSalesStrategy => new TempLedgerSalesStrategy();
    }
}
