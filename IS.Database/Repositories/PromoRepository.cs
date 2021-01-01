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
    public class PromoRepository : Helper
    {
        public IList<Promo> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Promo";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Promo>().CreateList(reader);
                    }
                }
            }
        }


        public void Insert(Promo Promo)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPromoInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PromoName", Promo.PromoName));
                    cmd.Parameters.Add(new SqlParameter("@DateFrom", Promo.DateFrom));
                    cmd.Parameters.Add(new SqlParameter("@DateTo", Promo.DateTo));
                    cmd.Parameters.Add(new SqlParameter("@LoginId", Globals.LoginId));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Promo Promo)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPromoUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PromoId", Promo.Id));
                    cmd.Parameters.Add(new SqlParameter("@PromoName", Promo.PromoName));
                    cmd.Parameters.Add(new SqlParameter("@DateFrom", Promo.DateFrom));
                    cmd.Parameters.Add(new SqlParameter("@DateTo", Promo.DateTo));
                    cmd.Parameters.Add(new SqlParameter("@LoginId", Globals.LoginId));
                    cmd.Parameters.Add(new SqlParameter("@Active", Promo.Active));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public PromoStrategy PromoStrategy => new PromoStrategy();
    }
}
