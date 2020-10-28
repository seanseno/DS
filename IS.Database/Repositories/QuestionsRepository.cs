using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class QuestionsRepository : Helper
    {
        public  IList<Questions> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Questions", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<Questions>().CreateList(reader);
                    }
                }
            }
        }
        public void Insert(Questions question)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spQuestionsInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Question", question.Question));
                    cmd.Parameters.Add(new SqlParameter("@Answer", question.Answer));
                  
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Questions question)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spQuestionsUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", question.Id));
                    cmd.Parameters.Add(new SqlParameter("@Question", question.Question));
                    cmd.Parameters.Add(new SqlParameter("@Answer", question.Answer));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spQuestionsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
   
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        //public void Update(Settings settings)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConStr))
        //    {
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand("spSettingsUpdate", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@Id", settings.Id));
        //            cmd.Parameters.Add(new SqlParameter("@ExpirationAlert", settings.ExpirationAlert));
        //            cmd.Parameters.Add(new SqlParameter("@SeniorDiscount", settings.SeniorDiscount));
        //            cmd.Parameters.Add(new SqlParameter("@PWDDiscount", settings.PWDDiscount));
        //            cmd.Parameters.Add(new SqlParameter("@ReturnItem", settings.ReturnItem));
        //            int rowAffected = cmd.ExecuteNonQuery();

        //            if (connection.State == System.Data.ConnectionState.Open)
        //                connection.Close();
        //        }

        //    }
        //}
    }
}
