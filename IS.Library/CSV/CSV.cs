using CsvHelper;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IS.Library.CSV
{
    public class CSV 
    {
        public string WriteSalesCSV(string DownloadPath, 
            IList<SalesCSV> list,
            DateTime dateFrom, 
            DateTime dateTo, 
            string PreparedBY,
            string TotalAmount,
            string TotalQty)
        {
            using (var writer = new StreamWriter( DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                
                writer.WriteLine("Sales Report");
                writer.WriteLine("Date: " + dateFrom.ToShortDateString() + " - " + dateTo.ToShortDateString());
                writer.WriteLine("Prepared by :" + PreparedBY);
                writer.WriteLine("");
                csv.WriteRecords(list);

                writer.WriteLine("");
                var total = new SalesCSV();
                total.CashierName = "TOTAL:";
                total.ProductName = string.Empty;
                total.Amount = TotalAmount;
                total.Qty = TotalQty;
                csv.WriteRecord(total);

                return DownloadPath;
            }
        }
        public string WriteStocksDataCSV(string DownloadPath,
            IList<StocksDataReportCSV> list,
            DateTime dateFrom,
            DateTime dateTo,
            string PreparedBY,
            string TotalRemainingQty,
            string TotalSales,
            string TotalProfit)
        {
            using (var writer = new StreamWriter(DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                writer.WriteLine("Stocks Data Report");
                writer.WriteLine("Date: " + dateFrom.ToShortDateString() + " - " + dateTo.ToShortDateString());
                writer.WriteLine("Prepared by :" + PreparedBY);
                writer.WriteLine("");

                csv.WriteRecords(list);

                writer.WriteLine("");
                var total = new StocksDataReportCSV();
                total.PrincipalName = "TOTAL:";
                total.RemainingQuanity = TotalRemainingQty;
                total.TotalSales = TotalSales;
                total.Profit = TotalProfit;
                csv.WriteRecord(total);

                return DownloadPath;
            }

        }

        public string WriteSalesProfitCSV(
            string DownloadPath,
            IList<SalesProfitCSV> list,
            DateTime dateFrom,
            DateTime dateTo,
            string PreparedBY,
            string TotalSales,
            string TotalProfit)
        {
            using (var writer = new StreamWriter(DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                writer.WriteLine("Stocks Data Report");
                writer.WriteLine("Date: " + dateFrom.ToShortDateString() + " - " + dateTo.ToShortDateString());
                writer.WriteLine("Prepared by :" + PreparedBY);
                writer.WriteLine("");

                csv.WriteRecords(list);

                writer.WriteLine("");
                var total = new SalesProfitCSV();
                total.Fullname = "TOTAL:";
                total.TotalSales = TotalSales;
                total.Profit = TotalProfit;
                csv.WriteRecord(total);

                return DownloadPath;
            }

        }
    }
}
