using CsvHelper;
using IS.Database;
using IS.Database.CSV;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace IS.Library.CSV
{
    public class CSV 
    {
        public string WriteSalesCSV(string DownloadPath, IList<SalesCSV> list)
        {
            string filename = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "" +
                "_"+ DateTime.Now.Hour  + DateTime.Now.Minute +  DateTime.Now.Second + " " +
                ".csv";
            using (var writer = new StreamWriter( DownloadPath + "\\" + filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
                return filename;
            }
        }
        public string WriteStocksDataCSV(string DownloadPath, IList<StocksDataReportCSV> list)
        {

            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
            }

            string filename = "StockDataReport_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "" +
                "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + " " +
                ".csv";
            using (var writer = new StreamWriter(DownloadPath + "\\" + filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
                return DownloadPath + filename;
            }

        }
    }
}
