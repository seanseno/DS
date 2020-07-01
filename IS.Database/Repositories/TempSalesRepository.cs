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
    public class TempSalesRepository : Helper
    {
        public void Insert(string customerName, int CashierId, int ItemId, int Qty, int TempLedgerId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO TempSales (ItemId,Qty,TempLedgerId) Values " +
                    "('" + ItemId + "'," + Qty + "," + TempLedgerId + ")";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<TempSales> Find(int? CashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Items.Description, TempSales.Qty, (Items.Price * TempSales.Qty) as Amount " +
                            "FROM TempSales INNER JOIN Items on Items.id = TempSales.ProductId " +
                            "WHERE CashieId = " + CashierId + " "+
                            " ORDER BY TempSales.Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempSales> Items = new List<TempSales>();
                        while (reader.Read())
                        {
                            var item = new TempSales();

                            item.Description = reader.GetString(0);
                            item.Qty = reader.GetInt32(1);
                            item.Amount = Math.Round(reader.GetDecimal(2), 2);
                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }

        public IList<TempSales> FindWithLedger(int? CashierId,int? LedgerId, EnumActive enumActive)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = " SELECT Items.GenericName, Items.BrandName, Items.Description,TempSales.Qty, (Items.Price * TempSales.Qty) as Amount,Items.Id,TempSales.Id,Co.CompanyName,Ca.CategoryName" +
                            " FROM TempSales " +
                            "   INNER JOIN Items on Items.id = TempSales.ProductId " +
                            "   INNER JOIN TempLedgerSales on TempLedgerSales.Id = TempSales.TempLedgerId " +
                            "   LEFT JOIN Companies as Co on Co.id = Items.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = Items.CategoryId " +
                            " WHERE CashierId = " + CashierId + " " +
                            " AND TempSales.TempLedgerId  = " + LedgerId + " " +
                            " ORDER BY TempSales.Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempSales> Items = new List<TempSales>();
                        while (reader.Read())
                        {
                            var item = new TempSales
                            {
                                GenericName = reader.GetString(0),
                                BrandName = reader.GetString(1),
                                Description = reader.GetString(2),
                                Qty = reader.GetInt32(3),
                                Amount = Math.Round(reader.GetDecimal(4), 2),
                                ItemId = reader.GetInt32(5),
                                Id = reader.GetInt32(6),
                                CategoryName = reader.GetString(7),
                                CompanyName = reader.GetString(8)
                            };
                            Items.Add(item);
                        }
                        if(Items.Count > 0)
                        {
                            return Items;
                        }
                        return null;
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

        public void DeleteAll(TempLedgerSales ledger)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM TempSales WHERE TempLedgerId = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM TempSales WHERE Id = " + Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TempSalesStrategy TempSalesStrategy => new TempSalesStrategy();
    }
}
