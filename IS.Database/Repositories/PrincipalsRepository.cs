using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace IS.Database.Repositories
{
    public class PrincipalsRepository : Helper
    {
        ISFactory factory = new ISFactory();
        public IList<Principals> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vPrincipals";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Principals>().CreateList(reader);
                        return List;
                    }
                }
            }
        }


        public void Insert(Principals Principals)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPrincipalsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", Principals.PrincipalId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalName", Principals.PrincipalName));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Principals Principals)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPrincipalsUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", Principals.PrincipalId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalName", Principals.PrincipalName));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public void Delete(Principals Principals)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spPrincipalsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", Principals.PrincipalId.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public Principals FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT *  FROM vPrincipals" +
                        " WHERE Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<Principals>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }
        public Principals FindWithPrincipalId(string PrincipalId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vPrincipals " +
                        " WHERE PrincipalId = '" + PrincipalId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var List = new ReflectionPopulator<Principals>().CreateList(reader);
                            return List[0];
                        }
                        return null;
                    }
                }
            }
        }

       
        public IList<Principals> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vPrincipals" +
                        " WHERE PrincipalName Like '%" + keyword + "%' ORDER BY PrincipalName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Principals>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public IList<Principals> FindWithSelect()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vPrincipals ORDER BY PrincipalName";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var List = new ReflectionPopulator<Principals>().CreateList(reader);
                        return List;
                    }
                }
            }
        }

        public string GetNextId()
        {
            var obj = factory.PrincipalsRepository.GetList().OrderByDescending(x => x.Id).FirstOrDefault();
            if (obj != null)
            {
                var catId = Convert.ToInt32(obj.PrincipalId.Substring(1, obj.PrincipalId.Length - 1)) + 1;
                var newId = "P" + catId.ToString("0000");
                return newId;
            }
            else
            {
                return "P0001";
            }
            //using (SqlConnection connection = new SqlConnection(ConStr))
            //{
            //    connection.Open();
            //    var select = "SELECT Id + 1 as Id From Principals ORDER BY id DESC";

            //    using (SqlCommand cmd = new SqlCommand(select, connection))
            //    {
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    int Id = reader.GetInt32(0);
            //                    return "P" + Id.ToString("0000");
            //                }
            //            }
            //            else
            //            {
            //                return "P0001";
            //            }
            //            return null;

            //        }
            //    }
            //}
        }
        public PrincipalsStrategy PrincipalsStrategy => new PrincipalsStrategy();
    }
}
