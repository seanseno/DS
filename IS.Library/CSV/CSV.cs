﻿using CsvHelper;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.CSV;
using IS.Database.Views;
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
        IList<SalesCSV> listCSV,
        IList<SalesViewReport> listView,
        DateTime dateFrom,
        DateTime dateTo,
        string PreparedBY)
        {
            using (var writer = new StreamWriter(DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                writer.WriteLine("Sales Report");
                writer.WriteLine("Date: " + dateFrom.ToShortDateString() + " - " + dateTo.ToShortDateString());
                writer.WriteLine("Prepared By: " + PreparedBY);
                writer.WriteLine("Prepared Date: " + DateTime.Now);
                writer.WriteLine("");
                csv.WriteRecords(listCSV);

                writer.WriteLine("");
                var total = new SalesCSV();
                total.Date = "TOTAL";
                    
                total.SoldQuantity = listView.Sum(x => x.SoldQuantity).ToString("N0");
                total.SellingPrice = listView.Sum(x => x.SellingPrice).ToString("N2");
                total.TotalAmount = listView.Sum(x => x.TotalAmount).ToString("N2");
                total.SupplierPrice = listView.Sum(x => x.SupplierPrice).ToString("N2");
                total.Profit = listView.Sum(x => x.Profit).ToString("N2");
                csv.WriteRecord(total);

                return DownloadPath;
            }
        }


        public string WriteStocksCSV(string DownloadPath,
        IList<StocksCSV> listCSV,
        IList<StocksDataViewReport> listView,
        DateTime dateFrom,
        DateTime dateTo,
        string PreparedBY)
        {
            using (var writer = new StreamWriter(DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                writer.WriteLine("Sales Report");
                writer.WriteLine("Date: " + dateFrom.ToShortDateString() + " - " + dateTo.ToShortDateString());
                writer.WriteLine("Prepared By: " + PreparedBY);
                writer.WriteLine("Prepared Date: " + DateTime.Now);
                writer.WriteLine("");
                csv.WriteRecords(listCSV);

                writer.WriteLine("");
                var total = new StocksCSV();
                total.PrincipalName = "TOTAL";

                total.Quantity = listView.Sum(x => x.Quantity).ToString("N0");
                total.SupplierPrice = listView.Sum(x => x.SupplierPrice).ToString("N2");
                total.TotalAmount = listView.Sum(x => x.TotalAmount).ToString("N2");
                total.UnitPriceWithAddedFormula = listView.Sum(x => x.UnitPriceWithAddedFormula).ToString("N2");
                total.SellingPrice = listView.Sum(x => x.SellingPrice).ToString("N2");
                total.UnitSold = listView.Sum(x => x.UnitSold).ToString("N0");
                total.RemainingQuantity = listView.Sum(x => x.RemainingQuantity).ToString("N0");
                total.RemainingAmount = listView.Sum(x => x.RemainingAmount).ToString("N2");
                csv.WriteRecord(total);

                return DownloadPath;
            }
        }
        public string WriteExpiredNearlyCSV(string DownloadPath,
        IList<ExpiredNearlyCSV> listCSV,
        IList<StocksDataExpireViewReport> listView,
        string PreparedBY)
        {
            using (var writer = new StreamWriter(DownloadPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                writer.WriteLine("Sales Report");
                writer.WriteLine("Prepared By: " + PreparedBY);
                writer.WriteLine("Prepared Date: " + DateTime.Now);
                writer.WriteLine("");
                csv.WriteRecords(listCSV);

                writer.WriteLine("");
                var total = new ExpiredNearlyCSV();
                total.PrincipalName = "TOTAL";

                total.RemainingQuantity = listView.Sum(x => x.RemainingQuantity).ToString("N0");
                total.RemainingAmount = listView.Sum(x => x.RemainingAmount).ToString("N2");
                csv.WriteRecord(total);

                return DownloadPath;
            }
        }

    }
}
