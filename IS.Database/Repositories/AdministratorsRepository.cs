using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class AdministratorsRepository : Helper
    {

        public void Insert(Administrators Administrator)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO Administrators (LoginName,Fullname,Password) Values " +
                    "('" + Administrator.Loginname.ToUpper() + "'," +
                    "'" + Administrator.Fullname.ToUpper() + "'," +
                    "'" + Encrypt.CreateMD5(Administrator.Password,this.IsEncrypt) + "')";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        public IList<Administrators> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Administrators" +
                             "  WHERE Loginname Like '%" + keyword + "%' " +
                             "  OR Fullname Like '%" + keyword + "%' " +
                             " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Administrators> Administrators = new List<Administrators>();
                        while (reader.Read())
                        {
                            var Administrator = new Administrators();

                            Administrator.Id = reader.GetInt32(0);
                            Administrator.Loginname = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                Administrator.Fullname = reader.GetString(2);
                            }
                            Administrator.Password = reader.GetString(3);
                            Administrator.InsertTime = reader.GetDateTime(4);
                            if (!reader.IsDBNull(5))
                            {
                                Administrator.UpdateTime = reader.GetDateTime(5);
                            }
                            Administrator.Active = reader.GetInt32(6);

                            Administrators.Add(Administrator);
                        }
                        return Administrators;
                    }
                }
            }
        }
        public Administrators FindAdministratorWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Administrators WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var Administrator = new Administrators
                            {
                                Id = reader.GetInt32(0),
                                Loginname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                                Active = reader.GetInt32(6),
                            };
                            return Administrator;
                        }
                        return null;
                    }
                }
            }
        }

        public IList<Administrators> FindAdministratorListWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM Administrators WHERE Id = " + id + " Order by Fullname";
                if (id == null)
                {
                    select = "SELECT * FROM Administrators  Order by Fullname";
                }

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var AdministratorList = new List<Administrators>();

                        AdministratorList.Add(new Administrators
                        {
                            Id = 0,
                            Fullname = "-SELECT-"
                        });

                        while (reader.Read())
                        {
                            var Administrator = new Administrators
                            {
                                Id = reader.GetInt32(0),
                                Loginname = reader.GetString(1),
                                Fullname = reader.GetString(2),
                            };
                            AdministratorList.Add(Administrator);
                        }
                        return AdministratorList;
                    }
                }
            }
        }


        public void Delete(Administrators brand)
        {
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();

            //    var select = "DELETE FROM Administrators " +
            //        " WHERE Id = " + Administrator.Id;

            //    using (SqlCommand cmd = new SqlCommand(select, connection))
            //    {
            //        cmd.ExecuteNonQuery();
            //    }

            //    if (connection.State == System.Data.ConnectionState.Open)
            //        connection.Close();

            //}
        }

        public void Update(Administrators Administrator)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Administrators SET Fullname = '" + Administrator.Fullname.ToUpper() + "'," +
                    " Active =" + Administrator.Active + ", " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + Administrator.Id;
                if(!string.IsNullOrEmpty(Administrator.Password.ToUpper()))
                {
                    select = "UPDATE Administrators SET Fullname = '" + Administrator.Fullname.ToUpper() + "'," +
                        " Password ='" + Encrypt.CreateMD5(Administrator.Password.ToUpper(), this.IsEncrypt) + "'," +
                        " Active =" + Administrator.Active + ", " +
                        " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                        " WHERE Id = " + Administrator.Id;
                }
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }
        public AdministratorsStrategy AdministratorsStrategy => new AdministratorsStrategy();

    }
}
