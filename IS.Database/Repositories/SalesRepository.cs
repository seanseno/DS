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
