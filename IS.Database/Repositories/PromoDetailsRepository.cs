using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IS.Database.Repositories
{
    public class PromoDetailsRepository : Helper
    {
        public IList<PromoDetails> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM PromoDetails";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<PromoDetails>().CreateList(reader);
                    }
                }
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPromoDetailsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Insert(PromoDetails promoDetails)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
          
                using (SqlCommand cmd = new SqlCommand("spPromoDetailsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PromoId", promoDetails.PromoId));
                    cmd.Parameters.Add(new SqlParameter("@ProductId", promoDetails.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Price", promoDetails.Price));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
