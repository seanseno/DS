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
    public class MenuAccessRepository : Helper
    {

        public MenuAccess Insert(MenuAccess menuAccess)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spMenuAccessInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdminId", menuAccess.AdminId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@MenuText", menuAccess.MenuText));
                  
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                    
                    return null;
                }

            }
        }

       
      

        public void Delete(MenuAccess menuAccess)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spMenuAccessDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdminId", menuAccess.AdminId.ToUpper()));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public IList<MenuAccess> GetListWithAdminId(string adminId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vMenuAccess" +
                             "  WHERE AdminId ='" + adminId + "'" +
                             " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<MenuAccess>().CreateList(reader);
                    }
                }
            }
        }
    }
}
