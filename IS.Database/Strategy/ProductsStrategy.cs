using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace IS.Database.Strategy
{
    public class ProductsStrategy : Helper
    {
        public bool CheckDuplicate(string ProductId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT ProductId FROM Products WHERE ProductId = '" + ProductId + "'";
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


        public bool CheckEditDuplicate(string Description, int? itemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT BrandName FROM items WHERE Description = '" + Description + "'  AND ID != " + itemId;
                using (SqlCommand cmd = new SqlCommand(select, connection))
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
        public bool ItemAlreadyInUse(string ProductId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = " SELECT ProductId FROM Sales " +
                            " WHERE ProductId = '" + ProductId + "'" +
                            " UNION " +
                            " SELECT ProductId FROM TempSales " +
                            " WHERE ProductId = '" + ProductId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
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
