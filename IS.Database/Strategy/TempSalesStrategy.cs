using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Database.Entities;

namespace IS.Database.Strategy
{
    public class TempSalesStrategy : Helper
    {
        public bool CheckIfOrderExist(TempLedgerSales tempLedgerSales, int? ItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM TempSales WHERE ItemId = " + ItemId  + " AND  TempLedgerId = " + tempLedgerSales.Id + "";
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
