using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Database.Entities;

namespace IS.Database.Strategy
{
    public class TempLedgerSalesStrategy : Helper
    {
        public bool CheckTempLedgerHasSales(TempLedgerSales tempLedgerSales)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM TempLedgerSales " +
                            "INNER JOIN TempSales on TempSales.TempLedgerId = TempLedgerSales.Id " +
                            "WHERE TempLedgerSales.Id = "+ tempLedgerSales.Id + "";
                using (SqlCommand cmd = new SqlCommand(select,connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
    }
}
