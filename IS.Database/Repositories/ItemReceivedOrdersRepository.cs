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
    public class ItemReceivedOrdersRepository : Helper
    {

        public IList<ItemReceivedOrders> FindList(string Keywords, int requestId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.SupplierPrice,IRO.SellingPricePerPiece" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ProductId " +
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
                           // item.CategoryName = reader.GetString(1);
                            //item.CompanyName = reader.GetString(2);
                            //item.GenericName = reader.GetString(3);
                            //item.BrandName = reader.GetString(4);
                            //item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.SupplierPrice = reader.GetDecimal(10);
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

        public IList<ItemReceivedOrders> FindListWithItemId(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.SupplierPrice,IRO.SellingPricePerPiece" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ProductId " +
                            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId   " +
                            " WHERE I.Id = " + itemId + " " +
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
                            //item.CategoryName = reader.GetString(1);
                            //item.CompanyName = reader.GetString(2);
                            //item.GenericName = reader.GetString(3);
                            //item.BrandName = reader.GetString(4);
                            //item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.SupplierPrice = reader.GetDecimal(10);
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
        public IList<ItemReceivedOrders> FindListAll()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.SupplierPrice,IRO.SellingPricePerPiece" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ProductId " +
                            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId   " +
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
                            //item.CategoryName = reader.GetString(1);
                            //item.CompanyName = reader.GetString(2);
                            //item.GenericName = reader.GetString(3);
                            //item.BrandName = reader.GetString(4);
                            //item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.SupplierPrice = reader.GetDecimal(10);
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

        public ItemReceivedOrders FindItemReceivedOrderWithId(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.SupplierPrice,IRO.SellingPricePerPiece,IRO.RequestOrderId" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ProductId " +
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
                            //item.CategoryName = reader.GetString(1);
                            //item.CompanyName = reader.GetString(2);
                            //item.GenericName = reader.GetString(3);
                            //item.BrandName = reader.GetString(4);
                            //item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.SupplierPrice = reader.GetDecimal(10);
                            item.SellingPricePerPiece = reader.GetDecimal(11);
                            item.RequestOrderId = reader.GetInt32(12);
                        }

                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();

                        return item;
                    }
                }
            }
        }
        public IList<ItemReceivedOrders> GetItemReceivedOrderListWithRequestOrderIdAndItemId(int? RequestOrderId,int? ItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT IRO.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName,I.Description," +
                            "   IRO.Quantity,IRO.DateReceived,IRO.DateManufactured,IRO.ExpirationDate,IRO.SupplierPrice,IRO.SellingPricePerPiece,IRO.RequestOrderId" +
                            " FROM ItemReceivedOrders as IRO " +
                            "   LEFT JOIN Items as I on I.id = IRO.ProductId " +
                            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId   " +
                            " WHERE IRO.RequestOrderId = " + RequestOrderId + " AND  IRO.ProductId = " + ItemId + " " +
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
                           //item.CategoryName = reader.GetString(1);
                            //item.CompanyName = reader.GetString(2);
                            //item.GenericName = reader.GetString(3);
                            //item.BrandName = reader.GetString(4);
                            //item.Description = reader.GetString(5);
                            item.Quantity = reader.GetInt32(6);
                            item.DateReceived = reader.GetDateTime(7);
                            item.DateManufactured = reader.GetDateTime(8);
                            item.ExpirationDate = reader.GetDateTime(9);
                            item.SupplierPrice = reader.GetDecimal(10);
                            item.SellingPricePerPiece = reader.GetDecimal(11);
                            item.RequestOrderId = reader.GetInt32(12);
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
