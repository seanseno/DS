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
    public class SalesRepository : Helper
    {
        public IList<EndOfDayReportView> GetSalesDetailListReport()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {

                connection.Open();
                var select = "SELECT * FROM vSalesDetail";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<EndOfDayReportView>().CreateList(reader);
                    }
                }
            }
        }

        //public void Insert(string customerName, int CashierId, string ProductId, int? Qty, int LedgerId)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        connection.Open();
        //        //var select = "INSERT INTO Sales (ProductId,Qty,LedgerId) Values " +
        //        //    "('" + ProductId + "'," + Qty + "," + LedgerId + ")";
        //        //using (SqlCommand cmd = new SqlCommand(select, connection))
        //        //{
        //        //    cmd.ExecuteNonQuery();
        //        //    var factory = new ISFactory();
        //        //    var stock = new Stocks
        //        //    {
        //        //        ProductId = ProductId,
        //        //        Stock = Qty
        //        //    };
        //        //    factory.StocksRepository.Update(stock, Qty, EnumStock.Debit);
        //        //}
        //    }
        //}

        public IList<Sales> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Sales";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Sales>().CreateList(reader);
                    }
                }
            }
        }


        //public IList<Sales> Find(int? CashierId)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        connection.Open();
        //        var select = "SELECT Items.Description, Sales.Qty, (Items.Price * Sales.Qty) as Amount " +
        //                    "FROM Sales INNER JOIN Items on Items.id = Sales.ProductId " +
        //                    "WHERE CashieId = " + CashierId + " "+
        //                    " ORDER BY Sales.Id";
        //        using (SqlCommand cmd = new SqlCommand(select, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Sales> Items = new List<Sales>();
        //                while (reader.Read())
        //                {
        //                    var item = new Sales();

        //                    item.Name = reader.GetString(0);
        //                    item.Qty = reader.GetInt32(1);
        //                    item.Amount = Math.Round(reader.GetDecimal(2), 2);
        //                    Items.Add(item);
        //                }
        //                return Items;
        //            }
        //        }
        //    }
        //}

        //public IList<Sales> FindWithLedger(int? CashierId,int? LedgerId, EnumActive enumActive)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        connection.Open();
        //        var select = "SELECT Items.Description,Sales.Qty, (Items.Price * Sales.Qty) as Amount " +
        //                    "FROM Sales INNER JOIN Items on Items.id = Sales.ProductId " +
        //                    "WHERE CashierId = " + CashierId + " " +
        //                    "       AND Sales.LedgerId  = " + LedgerId + " " +
        //                    " ORDER BY Sales.Id";
        //        using (SqlCommand cmd = new SqlCommand(select, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Sales> Items = new List<Sales>();
        //                while (reader.Read())
        //                {
        //                    var item = new Sales();

        //                    item.Name = reader.GetString(0);
        //                    item.Qty = reader.GetInt32(1);
        //                    item.Amount = Math.Round(reader.GetDecimal(2), 2);
        //                    Items.Add(item);
        //                }
        //                return Items;
        //            }
        //        }
        //    }
        //}

        //public decimal FindTotal(string keyword)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        connection.Open();
        //        var select = "SELECT SUM(Items.Price * Sales.Qty) as TotalAmount FROM Sales INNER JOIN Items on Items.id = Sales.ProductId";
        //        using (SqlCommand cmd = new SqlCommand(select, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                List<Sales> Items = new List<Sales>();
        //                while (reader.Read())
        //                {
        //                    return reader.GetDecimal(0);                   
        //                }
        //            }
        //            return 0;
        //        }
        //    }
        //}


        //public IList<ReportTotalSales> GetTotalSales(DateTime? DateFrom,DateTime? DateTo)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        string QueryDate = string.Empty;
        //        if (DateFrom != null || DateTo != null)
        //        {
        //            QueryDate = "WHERE O.InsertTime BETWEEN '" + DateFrom + "' AND '"+ DateTo + "'";
        //        }
        //        connection.Open();
        //        var select = " SELECT C.Fullname,I.ProductId, I.ProductName, " +
        //                     " SUM(O.Qty * I.Price) as TotalAmount,  " +
	       //                  " SUM(O.Qty) as TotalQty " +
        //                     " FROM Sales as O " +
        //                     "  INNER JOIN Products as I on I.ProductId = O.ProductId " +
        //                     "  INNER JOIN LedgerSales as LO on LO.Id = O.LedgerId " +
        //                     "  INNER JOIN Cashiers as C on C.CashierId = LO.CashierId " +
        //                     " " + QueryDate + " " +
        //                     " GROUP BY I.ProductId,I.ProductName, C.Fullname ";

        //        using (SqlCommand cmd = new SqlCommand(select, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    return new ReflectionPopulator<ReportTotalSales>().CreateList(reader);
        //                }
        //                return null;
        //            }
        //        }
        //    }
        //}

        //public IList<SalesProfit> FindSalesProfit(int? CashierId, DateTime? dateFrom, DateTime? dateTo)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {

        //        connection.Open();
        //        var select = "SELECT * FROM vSalesProfit " +
        //                    " WHERE InsertTime BETWEEN '" + dateFrom + "' AND  '" + dateTo  + "'" +
        //                    " AND CashierId LIKE '%" + CashierId + "%'";

        //        using (SqlCommand cmd = new SqlCommand(select, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    return new ReflectionPopulator<SalesProfit>().CreateList(reader);
        //                }
        //                return null;
        //            }
        //        }
        //    }
        //}

        public IList<SalesViewReport> GetSalesListReport()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {

                connection.Open();
                var select = "SELECT * FROM vReportSales";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<SalesViewReport>().CreateList(reader);
                    }
                }
            }
        }
        
    }
}
