using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace IS.Database.Strategy
{
    public class RequestOrderItemsStrategy : Helper
    {
        public bool CheckDuplicate(string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT RequestOrderName FROM RequestOrderItems WHERE Name = '" + Name + "'";
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
