using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class CashiersRepository : Helper
    {

        public Cashiers Insert(Cashiers Cashier)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCashiersInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CashierId", Cashier.CashierId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Loginname", Cashier.Loginname.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Fullname", Cashier.Fullname.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Password", Encrypt.CreateMD5(Cashier.Password, this.IsEncrypt)));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                    
                    if (rowAffected > 0)
                    {
                       return  this.FindCashierWithCashierId(Cashier.CashierId.ToUpper());
                    }
                    return null;
                }

            }
        }

        public IList<Cashiers> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCashiers" +
                             "  WHERE Loginname Like '%" + keyword + "%' " +
                             "  OR Fullname Like '%" + keyword + "%' " +
                             " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Cashiers>().CreateList(reader);
                    }
                }
            }
        }
        public Cashiers FindCashierWithCashierId(string CashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCashiers WHERE CashierId = '" + CashierId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Cashiers>().CreateList(reader)[0];
                    }
                }
            }
        }

        public IList<Cashiers> FindCashierListWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Cashiers WHERE Id = " + id + " Order by Fullname";
                if (id == null)
                {
                    select = "SELECT * FROM Cashiers  Order by Fullname";
                }

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var CashierList = new List<Cashiers>();

                        CashierList.Add(new Cashiers
                        {
                            Id = 0,
                            Fullname = "-SELECT-"
                        });

                        while (reader.Read())
                        {
                            var cashier = new Cashiers
                            {
                                Id = reader.GetInt32(0),
                                Loginname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                            };
                            CashierList.Add(cashier);
                        }
                        return CashierList;
                    }
                }
            }
        }


        public void Delete(Cashiers Cashiers)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCashiersDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CashierId", Cashiers.CashierId.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Cashiers Cashier)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCashiersUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CashierId", Cashier.CashierId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Fullname", Cashier.Fullname.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Password", Cashier.Password == "" ? "" : Encrypt.CreateMD5(Cashier.Password, this.IsEncrypt)));
                    cmd.Parameters.Add(new SqlParameter("@Active", Cashier.Active));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public string GetNextId()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id + 1 as Id From Cashiers ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                return "M" + Id.ToString("0000");
                            }
                        }
                        else
                        {
                            return "M0001";
                        }
                        return null;
                    }
                }
            }
        }

        public CashiersStrategy CashiersStrategy => new CashiersStrategy();

    }
}
