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
    public class CategoryDiscountedRepository : Helper
    {
        public List<CategoryDiscounted> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vCategoryDiscounted";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<CategoryDiscounted> Categorys = new List<CategoryDiscounted>();
                        var List = new ReflectionPopulator<CategoryDiscounted>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public void Insert(CategoryDiscounted model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCategoryDiscountedInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", model.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@IsSenior", model.IsSenior));
                    cmd.Parameters.Add(new SqlParameter("@IsPwd", model.IsPWD));;
                    
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public void Update(CategoryDiscounted model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCategoryDiscountedUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", model.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@IsSenior", model.IsSenior));
                    cmd.Parameters.Add(new SqlParameter("@IsPwd", model.IsPWD)); ;

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public void Delete(string Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spCategoryDiscountedDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", Id));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
