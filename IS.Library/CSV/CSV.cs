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
        public string WriteCSV(string DownloadPath, IList<SalesCSV> list)
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
    }
}
