using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
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
                var select = "INSERT INTO Cashiers (LoginName,Fullname,Password) Values " +
                    "('" + Cashier.Loginname.ToUpper() + "'," +
                    "'" + Cashier.Fullname.ToUpper() + "'," +
                    "'" + Encrypt.CreateMD5(Cashier.Password, this.IsEncrypt) + "'); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    var model = new Cashiers
                    {
                        Id = Convert.ToInt32(cmd.ExecuteScalar()),
                        Loginname = Cashier.Loginname.ToUpper(),
                        Fullname = Cashier.Fullname,
                    };

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    return model;
                }

            }
        }

        public IList<Cashiers> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Cashiers" +
                             "  WHERE Loginname Like '%" + keyword + "%' " +
                             "  OR Fullname Like '%" + keyword + "%' " +
                             " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Cashiers> cashiers = new List<Cashiers>();
                        while (reader.Read())
                        {
                            var cashier = new Cashiers();

                            cashier.Id = reader.GetInt32(0);
                            cashier.Loginname = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                cashier.Fullname = reader.GetString(2);
                            }
                            cashier.Password = reader.GetString(3);
                            cashier.InsertTime = reader.GetDateTime(4);
                            if (!reader.IsDBNull(5))
                            {
                                cashier.UpdateTime = reader.GetDateTime(5);
                            }
                            cashier.Active = reader.GetInt32(6);

                            cashiers.Add(cashier);
                        }
                        return cashiers;
                    }
                }
            }
        }
        public Cashiers FindCashierWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Cashiers WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var cashier = new Cashiers
                            {
                                Id = reader.GetInt32(0),
                                Loginname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                                InsertTime = reader.GetDateTime(4),
                                Active = reader.GetInt32(6),
                            };
                            if (!reader.IsDBNull(5))
                            {
                                cashier.UpdateTime = reader.GetDateTime(5);
                            }
                            return cashier;
                        }
                        return null;
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


        public void Delete(Cashiers brand)
        {
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();

            //    var select = "DELETE FROM Cashiers " +
            //        " WHERE Id = " + Cashier.Id;

            //    using (SqlCommand cmd = new SqlCommand(select, connection))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }

            //    if (connection.State == System.Data.ConnectionState.Open)
            //        connection.Close();

            //}
        }

        public void Update(Cashiers Cashier)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Cashiers SET Fullname = '" + Cashier.Fullname.ToUpper() + "'," +
                    " Active =" + Cashier.Active + ", " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + Cashier.Id;
                if(!string.IsNullOrEmpty(Cashier.Password.ToUpper()))
                {
                    select = "UPDATE Cashiers SET Fullname = '" + Cashier.Fullname.ToUpper() + "'," +
                        " Password ='" + Encrypt.CreateMD5(Cashier.Password.ToUpper(), this.IsEncrypt) + "'," +
                        " Active =" + Cashier.Active + ", " +
                        " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                        " WHERE Id = " + Cashier.Id;
                }
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public CashiersStrategy CashiersStrategy => new CashiersStrategy();

    }
}
