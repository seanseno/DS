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
    public class AdministratorsRepository : Helper
    {

        public IList<Administrators> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vAdministrators";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Administrators>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public void Insert(Administrators Administrator)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spAdministratorsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdminId", Administrator.AdminId));
                    cmd.Parameters.Add(new SqlParameter("@Loginname", Administrator.Loginname));
                    cmd.Parameters.Add(new SqlParameter("@Fullname", Administrator.Fullname));
                    cmd.Parameters.Add(new SqlParameter("@Password", Encryption.EncryptString(Administrator.Password, this.IsEncrypt)));
                   
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public IList<Administrators> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vAdministrators" +
                             "  WHERE Loginname Like '%" + keyword + "%' " +
                             "  OR Fullname Like '%" + keyword + "%' " +
                             " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Administrators>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public Administrators FindAdministratorWithAdminId(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vAdministrators WHERE AdminId = '" + id + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Administrators>().CreateList(reader)[0];
                    }
                }
            }
        }
        public Administrators FindAdministratorWithLoginname(string Loginname)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vAdministrators WHERE loginname = '" + Loginname + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Administrators>().CreateList(reader)[0];
                    }
                }
            }
        }

        public string GetNextId()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id + 1 as Id From Administrators ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                return "A" + Id.ToString("0000");
                            }
                        }
                        else
                        {
                            return "A0001";
                        }
                        return null;
                    }
                }
            }
        }


        public void Delete(Administrators Administrators)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spAdministratorsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdminId", Administrators.AdminId.ToUpper()));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Administrators Administrator)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spAdministratorsUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdminId", Administrator.AdminId));
                    cmd.Parameters.Add(new SqlParameter("@Fullname", Administrator.Fullname));
                    cmd.Parameters.Add(new SqlParameter("@Password", Administrator.Password == "" ? "" : Encryption.EncryptString(Administrator.Password, this.IsEncrypt)));
                    cmd.Parameters.Add(new SqlParameter("@Active", Administrator.Active));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public AdministratorsStrategy AdministratorsStrategy => new AdministratorsStrategy();

    }
}
