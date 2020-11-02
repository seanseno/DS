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
    public class PrinterCoordinatesRepository : Helper
    {
        public void Insert(PrinterCoordinates obj)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spPrinterCoordinatesInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PrintLabel", obj.PrintingLabel));
                    cmd.Parameters.Add(new SqlParameter("@PrintType", (int)PrinterType.Kiosk));
                    cmd.Parameters.Add(new SqlParameter("@X", obj.X));
                    cmd.Parameters.Add(new SqlParameter("@Y", obj.Y));
                    cmd.Parameters.Add(new SqlParameter("@Size", obj.Size));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public void Delete(PrinterType PType)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPrinterCoordinatesDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PrintingType", (int)PType));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public List<PrinterCoordinates> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM PrinterCoordinates";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<PrinterCoordinates> Products = new List<PrinterCoordinates>();
                        var List = new ReflectionPopulator<PrinterCoordinates>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
    }
}
