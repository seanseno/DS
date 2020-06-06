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
    public class OrderReceivedRepository : Helper
    {
        public void Insert(ItemReceivedOrders model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC INSERT ItemReceivedOrders and STOCKS
                using (SqlCommand cmd = new SqlCommand("spItemReceivedOrders", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RequestOrderId", model.RequestOrderId));
                    cmd.Parameters.Add(new SqlParameter("@ItemId", model.ItemId));
                    cmd.Parameters.Add(new SqlParameter("@DateReceived", model.DateReceived));
                    cmd.Parameters.Add(new SqlParameter("@DateManufactured", model.DateManufactured));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationDate", model.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@OrderPrice", model.OrderPrice));
                    cmd.Parameters.Add(new SqlParameter("@SellingPricePerPiece", model.SellingPricePerPiece));
                    cmd.Parameters.Add(new SqlParameter("@InputQuantity", model.Quantity));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Delete(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC DELETE ItemReceivedOrders and STOCKS
                using (SqlCommand cmd = new SqlCommand("spDeleteItemReceivedOrders", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public IList<ItemReceivedOrders> Find(string Keywords, int requestId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.OrderPrice,IRO.SellingPricePerPiece" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ItemId " +
                            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId   " +
                            " WHERE " +
                            "   (Ca.CategoryName Like '%"+ Keywords+ "%' OR " +
                            "   Co.CompanyName Like '%" + Keywords + "%' OR " +
                            "   I.GenericName Like '%" + Keywords + "%' OR " +
                            "   I.BrandName Like '%" + Keywords + "%' OR " +
                            "   I.Description Like '%" + Keywords +"%') AND  IRO.RequestOrderId = " + requestId +" " +
                            " ORDER BY IRO.Id ASC ";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ItemReceivedOrders> Items = new List<ItemReceivedOrders>();
                        while (reader.Read())
                        {
                            var item = new ItemReceivedOrders();

                            item.Id = reader.GetInt32(0);
                            item.CategoryName = reader.GetString(1);
                            item.CompanyName = reader.GetString(2);
                            item.GenericName = reader.GetString(3);
                            item.BrandName = reader.GetString(4);
                            item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.OrderPrice = reader.GetDecimal(10);
                            item.SellingPricePerPiece = reader.GetDecimal(11);
                            Items.Add(item);
                        }
                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();
                        return Items;
                    }
                }
            }
        }


        public ItemReceivedOrders FindWithId(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.OrderPrice,IRO.SellingPricePerPiece" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ItemId " +
                            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId   " +
                            " WHERE IRO.Id = " + Id + " " +
                            " ORDER BY IRO.Id ASC ";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ItemReceivedOrders> Items = new List<ItemReceivedOrders>();
                        var item = new ItemReceivedOrders();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            
                            item.Id = reader.GetInt32(0);
                            item.CategoryName = reader.GetString(1);
                            item.CompanyName = reader.GetString(2);
                            item.GenericName = reader.GetString(3);
                            item.BrandName = reader.GetString(4);
                            item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.OrderPrice = reader.GetDecimal(10);
                            item.SellingPricePerPiece = reader.GetDecimal(11);
                           
                        }

                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();

                        return item;
                    }
                }
            }
        }

        public void Update(ItemReceivedOrders itm)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC DELETE ItemReceivedOrders and STOCKS
                using (SqlCommand cmd = new SqlCommand("spUpdateItemReceivedOrders", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", itm.Id));
                    cmd.Parameters.Add(new SqlParameter("@InputQuantity", itm.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@DateReceived", itm.DateReceived));
                    cmd.Parameters.Add(new SqlParameter("@DateManufactured", itm.DateManufactured));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationDate", itm.ExpirationDate));
                    cmd.Parameters.Add(new SqlParameter("@OrderPrice", itm.OrderPrice));
                    cmd.Parameters.Add(new SqlParameter("@SellingPrice", itm.SellingPricePerPiece));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
