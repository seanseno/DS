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
    public class OrderReceivedRepository : Helper
    {
        public void Insert(ItemReceivedOrders model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "INSERT INTO ItemReceivedOrders (RequestOrderId,ItemId,DateReceived,DateManufactured,ExpirationDate,Quantity,OrderPrice,SellingPricePerPiece)" +
                            " VALUES (" + model.RequestOrderId + "," + model.ItemId + "," +
                            " '" + model.DateReceived + "','" + model.DateManufactured + "','" + model.ExpirationDate + "'," +
                            " " + model.Quantity + "," + model.OrderPrice + "," + model.SellingPricePerPiece + ")";
                
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(ItemReceivedOrders model)
        {

        }

        public void Delete(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM ItemReceivedOrders" +
                            " WHERE Id = " + Id;
                  
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public IList<ItemReceivedOrders> Find(string Keywords)
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
                            "   Ca.CategoryName Like '%"+ Keywords+ "%' OR " +
                            "   Co.CompanyName Like '%" + Keywords + "%' OR " +
                            "   I.GenericName Like '%" + Keywords + "%' OR " +
                            "   I.BrandName Like '%" + Keywords + "%' OR " +
                            "   I.Description Like '%%' " +
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
    }
}
