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
    public class ItemsRepository : Helper
    {
        public void Insert(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC INSERT ITEM and STOCKS
                using (SqlCommand cmd = new SqlCommand("spInsertItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@CompanyId", item.CompanyId));
                    cmd.Parameters.Add(new SqlParameter("@GenericName", item.GenericName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@BrandName", item.BrandName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@Stock", item.Stock));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public Items UploadItem(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                //STORE PROC INSERT ITEM and STOCKS
                using (SqlCommand cmd = new SqlCommand("spUploadItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", item.CategoryName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", item.CompanyName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@GenericName", item.GenericName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@BrandName", item.BrandName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@Stock", item.Stock));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));
                    cmd.Parameters.Add(new SqlParameter("@DateManufactured", DateTimeConvertion.ConvertDateString(item.DateManufactured)));
                    cmd.Parameters.Add(new SqlParameter("@ExpirationDate", DateTimeConvertion.ConvertDateString(item.ExpirationDate)));
                    cmd.Parameters.Add(new SqlParameter("@AdministratorId", Globals.LoginId));
                    cmd.Parameters.Add(new SqlParameter("@RequestOrderItemId", item.RequestOrderId));

                    var IsAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (IsAffected <= 0)
                    {
                        return item;
                    }
                    return null ;
                }

            }
        }

        public void Update(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "UPDATE Items SET " +
                    " CategoryId = " + item.CategoryId + ", " +
                    " CompanyId = " + item.CompanyId + ", " +
                    " GenericName = '" + item.GenericName  + "', " +
                    " BrandName = '" + item.BrandName?.ToUpper() + "'," +
                    " Description ='" + item.Description.ToUpper() + "', " +
                    " Price = " + item.Price + ", " +
                    " BarCode ='" + item.BarCode + "', " +
                    " UpdateTime ='" + DateTimeConvertion.ConvertDateString(DateTime.Now) + "' " +
                    " WHERE Id = " + item.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

            }
        }

        public void Delete(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                var select = "DELETE FROM Items " +
                    " WHERE Id = " + item.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                select = "DELETE FROM StocksHistory " +
                " WHERE ItemId = " + item.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                select = "DELETE FROM Stocks " +
                " WHERE ItemId = " + item.Id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }


                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        public Items FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT I.Id, I.CompanyId, I.GenericName, I.BrandName, I.Description, I.Price , " +
                                " S.Stock,Co.CompanyName,Ca.CategoryName,I.BarCode" +
                                " FROM Items as I " +
                                " LEFT JOIN Stocks as S on S.ItemId = I.id " +
                                " LEFT JOIN Companies as Co on Co.id = I.CompanyId" +
                                " LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId" +
                                " WHERE I.Id = " + id;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var item = new Items();

                            item.Id = reader.GetInt32(0);
                            
                            
                            item.Description = reader.GetString(4);
                            item.Price = Math.Round(reader.GetDecimal(5), 2);
                            item.Stock = reader.GetInt32(6);


                            if (!reader.IsDBNull(1))
                            {
                                item.CompanyId = reader.GetInt32(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                item.GenericName = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                item.BrandName = reader.GetString(3);
                            }

                            if (!reader.IsDBNull(7))
                            {
                                item.CompanyName = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                item.CategoryName = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                item.BarCode = reader.GetString(9);
                            }

                            return item;
                        }
                        return null;
                    }
                }
            }
        }

        public IList<Items> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT I.Id, I.CompanyId, I.GenericName, I.BrandName, I.Description, I.Price , S.Stock,Co.CompanyName,Ca.CategoryName,I.BarCode" +
                             " FROM Items AS I " +
                                " LEFT JOIN Stocks as S on S.ItemId = I.id " +
                                " LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                                " LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId " +
                                " WHERE I.BrandName Like '%" + keyword + "%'" +
                                " OR I.Description Like '%" + keyword + "%' " +
                                " OR I.GenericName Like '%" + keyword + "%' " +
                                " OR I.BarCode Like '%" + keyword + "%' " +
                                " OR Co.CompanyName Like '%" + keyword + "%' " +
                                " OR Ca.CategoryName Like '%" + keyword + "%' " +
                            " ORDER BY I.Id";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Items> Items = new List<Items>();
                        while (reader.Read())
                        {
                            var item = new Items();

                            item.Id = reader.GetInt32(0);
                            item.CompanyId = reader.GetInt32(1);
                            item.GenericName = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                item.BrandName = reader.GetString(3);
                            }
                            item.Description = reader.GetString(4);
                            item.Price = Math.Round(reader.GetDecimal(5), 2);

                            if (!reader.IsDBNull(6))
                            {
                                item.Stock = reader.GetInt32(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                item.CompanyName = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                item.CategoryName = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                item.BarCode = reader.GetString(9);
                            }

                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }
        public ItemsStrategy ItemsStrategy => new ItemsStrategy();

    }
}
