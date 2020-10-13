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
    public class ReturnItemsRepository : Helper
    {
        public  IList<ReturnIemsView> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vReturnItems", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<ReturnIemsView>().CreateList(reader);
                    }
                }
            }
        }
    }
}
