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
    public class ProductsHistoryRepository : Helper
    {
        public List<ProductsHistory> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vProductsHistory";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ProductsHistory> Products = new List<ProductsHistory>();
                        var List = new ReflectionPopulator<ProductsHistory>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
    }
}
