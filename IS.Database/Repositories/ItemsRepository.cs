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
                using (SqlCommand cmd = new SqlCommand("spItemInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ItemId", item.ItemId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", item.PrincipalId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", item.ProductName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public void Update(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spItemsUpdate", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ItemId", item.ItemId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@CategoryId", item.CategoryId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@PrincipalId", item.PrincipalId.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", item.ProductName.ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@Price", item.Price));
                    cmd.Parameters.Add(new SqlParameter("@Active", item.Active));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", item.BarCode));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }

            }
        }

        public void Delete(Items item)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spItemsDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ItemId", item.ItemId.ToUpper()));
                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        public Items FindWithItemId(string ItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vItems " +
                          " WHERE ItemId Like '" + ItemId + "'";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Items> Items = new List<Items>();
                        var List = new ReflectionPopulator<Items>().CreateList(reader);
                        return List[0];
                    }
                }
            }
        }

        public Items FindWithId(int? id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                return null;
                //var select = "SELECT I.Id, I.CompanyId, I.GenericName, I.BrandName, I.Description, I.Price , " +
                //                " S.Stock,Co.CompanyName,Ca.CategoryName,I.BarCode" +
                //                " FROM Items as I " +
                //                " LEFT JOIN Stocks as S on S.ItemId = I.id " +
                //                " LEFT JOIN Companies as Co on Co.id = I.CompanyId" +
                //                " LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId" +
                //                " WHERE I.Id = " + id;

                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {

                //        while (reader.Read())
                //        {
                //            var item = new Items();

                //            item.Id = reader.GetInt32(0);
                            
                            
                //            item.Description = reader.GetString(4);
                //            item.SellingPricePerPiece = Math.Round(reader.GetDecimal(5), 2);
                //            item.Stock = reader.GetInt32(6);


                //            if (!reader.IsDBNull(1))
                //            {
                //                item.CompanyId = reader.GetInt32(1);
                //            }
                //            if (!reader.IsDBNull(2))
                //            {
                //                item.GenericName = reader.GetString(2);
                //            }
                //            if (!reader.IsDBNull(3))
                //            {
                //                item.BrandName = reader.GetString(3);
                //            }

                //            if (!reader.IsDBNull(7))
                //            {
                //                item.CompanyName = reader.GetString(7);
                //            }
                //            if (!reader.IsDBNull(8))
                //            {
                //                item.CategoryName = reader.GetString(8);
                //            }
                //            if (!reader.IsDBNull(9))
                //            {
                //                item.BarCode = reader.GetString(9);
                //            }

                //            return item;
                //        }
                //        return null;
                //    }
                //}
            }
        }

        public IList<Items> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vItems " +
                                " WHERE ProductName Like '%" + keyword + "%'" +
                                " OR CategoryName Like '%" + keyword + "%' " +
                                " OR PrincipalName Like '%" + keyword + "%' " +
                                " OR BarCode Like '%" + keyword + "%' " +
                            " ORDER BY ProductName";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Items> Items = new List<Items>();
                        var List = new ReflectionPopulator<Items>().CreateList(reader);
                        return List;
                    }
                }
            }
        }
        public ItemsStrategy ItemsStrategy => new ItemsStrategy();

    }
}
