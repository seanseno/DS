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
    public class SalesRepository : Helper
    {
        public void Insert(string customerName, int CashierId, int ItemId, int? Qty, int LedgerId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO Sales (ItemId,Qty,LedgerId) Values " +
                    "('" + ItemId + "'," + Qty + "," + LedgerId + ")";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                    var factory = new ISFactory();
                    var stock = new Stocks
                    {
                        ItemId = ItemId,
                        Stock = Qty
                    };
                    factory.StocksRepository.Update(stock, Qty, EnumStock.Debit);
                }
            }
        }
        public IList<Sales> Find(int? CashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Items.Description, Sales.Qty, (Items.Price * Sales.Qty) as Amount " +
                            "FROM Sales INNER JOIN Items on Items.id = Sales.ItemId " +
                            "WHERE CashieId = " + CashierId + " "+
                            " ORDER BY Sales.Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Sales> Items = new List<Sales>();
                        while (reader.Read())
                        {
                            var item = new Sales();

                            item.Name = reader.GetString(0);
                            item.Qty = reader.GetInt32(1);
                            item.Amount = Math.Round(reader.GetDecimal(2), 2);
                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }

        public IList<Sales> FindWithLedger(int? CashierId,int? LedgerId, EnumActive enumActive)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Items.Description,Sales.Qty, (Items.Price * Sales.Qty) as Amount " +
                            "FROM Sales INNER JOIN Items on Items.id = Sales.ItemId " +
                            "WHERE CashierId = " + CashierId + " " +
                            "       AND Sales.LedgerId  = " + LedgerId + " " +
                            " ORDER BY Sales.Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Sales> Items = new List<Sales>();
                        while (reader.Read())
                        {
                            var item = new Sales();

                            item.Name = reader.GetString(0);
                            item.Qty = reader.GetInt32(1);
                            item.Amount = Math.Round(reader.GetDecimal(2), 2);
                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }

        public decimal FindTotal(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT SUM(Items.Price * Sales.Qty) as TotalAmount FROM Sales INNER JOIN Items on Items.id = Sales.ItemId";
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


        public IList<Sales> Find(int? CashierId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = " SELECT C.Fullname,I.GenericName, I.BrandName,I.Description, SUM(O.Qty * I.Price) as Amount, SUM(O.Qty) as Qty FROM Sales as O " +
                             " INNER JOIN Items as I on I.Id = O.ItemId " +
                             " INNER JOIN LedgerSales as LO on LO.Id = O.LedgerId " +
                             " INNER JOIN Cashiers as C on C.Id = LO.CashierId " +
                             " WHERE C.Id = " + CashierId + "" +
                             "   AND O.InsertTime BETWEEN ( CONVERT(datetime,'" + DateTimeConvertion.ConvertDateString((DateTime)dateFrom) + "', 120)) AND ( CONVERT(datetime,'" + DateTimeConvertion.ConvertDateString((DateTime)dateTo) + "', 120)) " +
                             " GROUP BY I.BrandName,I.GenericName, C.Fullname, I.Description ORDER BY C.Fullname,I.BrandName";
                if (CashierId == null || CashierId == 0)
                {
                    select = " SELECT C.Fullname, I.GenericName,I.BrandName,I.Description, SUM(O.Qty * I.Price) as Amount, SUM(O.Qty) as Qty FROM Sales as O " +
                                                 " INNER JOIN Items as I on I.Id = O.ItemId " +
                                                 " INNER JOIN LedgerSales as LO on LO.Id = O.LedgerId " +
                                                 " INNER JOIN Cashiers as C on C.Id = LO.CashierId " +
                                                 " WHERE O.InsertTime BETWEEN ( CONVERT(datetime,'" + DateTimeConvertion.ConvertDateString((DateTime)dateFrom) + "', 120)) AND ( CONVERT(datetime,'" + DateTimeConvertion.ConvertDateString((DateTime)dateTo) + "', 120)) " +
                                                 " GROUP BY I.BrandName,I.GenericName, C.Fullname, I.Description ORDER BY C.Fullname,I.BrandName";
                }
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Sales> Sales = new List<Sales>();
                        while (reader.Read())
                        {
                            var Sale = new Sales();

                            Sale.CashierName = reader.GetString(0);
                            Sale.GenericName = reader.GetString(1);
                            Sale.BrandName = reader.GetString(2);
                            Sale.Description = reader.GetString(3);
                            Sale.Amount = Math.Round(reader.GetDecimal(4), 2);
                            Sale.Qty = reader.GetInt32(5);

                            Sales.Add(Sale);
                        }
                        return Sales;
                    }
                }
            }
        }
    }
}
