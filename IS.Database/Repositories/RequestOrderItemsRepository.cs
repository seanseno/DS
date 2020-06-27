using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Enums;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class RequestOrderItemsRepository : Helper
    {
        public int Insert(int? AdminId,string OrderName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO RequestOrderItems (AdministratorId,RequestOrderName) " +
                        " VALUES ("+ AdminId + ",'"+ OrderName  + "');SELECT SCOPE_IDENTITY(); ";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    int Id = Convert.ToInt32(cmd.ExecuteScalar());

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                    return Id;
                }
            }
        }

        public void Update(RequestOrderItems model)
        {
          
        }

        public void Delete(RequestOrderItems model)
        {

        }

        public IList<RequestOrderItems> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * From RequestOrderItems" +
                            " ORDER BY OrderDate DESC ";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<RequestOrderItems> Items = new List<RequestOrderItems>();
                        while (reader.Read())
                        {
                            var item = new RequestOrderItems
                            {
                                Id = reader.GetInt32(0),
                                AdministratorId = reader.GetInt32(1),
                                RequestOrderName = reader.GetString(2),
                                OrderDate = reader.GetDateTime(3),
                                InsertTime = reader.GetDateTime(4),
                            };

                            Items.Add(item);
                        }
                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();
                        return Items;
                    }
                }
            }
        }

        public IList<RequestOrderItems> GetListWithItemList(int ItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT R.Id,R.OrderDate, R.RequestOrderName " +
                             " From RequestOrderItems as R " +
                             "  LEFT JOIN Administrators as A on A.Id =R.AdministratorId " +
                             "  INNER JOIN ItemReceivedOrders as IRO on IRO.RequestOrderId =r.Id " +
                             "  WHERE IRO.ItemId = " + ItemId + " AND IRO.Quantity > 0 ";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<RequestOrderItems> Items = new List<RequestOrderItems>();
                        while (reader.Read())
                        {
                            var item = new RequestOrderItems
                            {
                                Id = reader.GetInt32(0),
                                OrderDate = reader.GetDateTime(1),
                                RequestOrderName = reader.GetString(2),
                            };

                            Items.Add(item);
                        }
                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();
                        return Items;
                    }
                }
            }
        }

        public RequestOrderItems GetOrderRequestInfoWithId(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT A.Fullname,R.OrderDate, R.RequestOrderName From RequestOrderItems as R" +
                            "   LEFT JOIN Administrators as A on A.Id =R.AdministratorId " +
                            " WHERE R.Id = " + Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        if(reader.HasRows)
                        {
                            reader.Read();
                            var item = new RequestOrderItems
                            {
                                AdminName = reader.GetString(0),
                                OrderDate = reader.GetDateTime(1),
                                RequestOrderName = reader.GetString(2),
                            };
                            return item;
                        }
                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();
                        return null;
                    }
                }
            }
        }
        public RequestOrderItems GetRequestOrderItemsWithId(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Id,AdministratorId,RequestOrderName,OrderDate,InsertTime " +
                                " FROM RequestOrderItems " +
                             " WHERE Id = " + Id + "";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<RequestOrderItems> Items = new List<RequestOrderItems>();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            var item = new RequestOrderItems
                            {
                                Id = reader.GetInt32(0),
                                AdministratorId = reader.GetInt32(1),
                                RequestOrderName = reader.GetString(2),
                                OrderDate = reader.GetDateTime(3),
                                InsertTime = reader.GetDateTime(4),
                            };

                            if (connection.State == System.Data.ConnectionState.Open)
                                connection.Close();

                            return item;
                        }
                        return null;
                    }
                }
            }
        }


        public int? GetNextIdent()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT CAST(IDENT_CURRENT('RequestOrderItems') as INT) as Id3";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetInt32(0);
                        }
                        return null;
                    }
                }
            } 
        }

        public RequestOrderItemsStrategy RequestOrderItemsStrategy => new RequestOrderItemsStrategy();
    }
}
