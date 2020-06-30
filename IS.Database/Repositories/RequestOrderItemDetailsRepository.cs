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
    public class RequestOrderItemDetailsRepository : Helper
    {
        public void Insert(Items model, int RequestId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                //connection.Open();
                //var select = "INSERT INTO RequestOrderItemDetails (RequestOrderItemId,ItemId,Qty,EstimatedPrice) " +
                //        " VALUES ("+ RequestId + ","+ model.TempItemId + "," + model.Stock + "," + model.SupplierPrice + ")";

                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    cmd.ExecuteNonQuery();
                //}
                
            }
        }

        public void Update(RequestOrderItemDetails model)
        {
          
        }

        public void Delete(int? RequestOrderItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM RequestOrderItemDetails " +
                        " WHERE  RequestOrderItemId = " +RequestOrderItemId;

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public IList<Items> GetListWithId(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                return null;
                //var select = "SELECT ROID.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName, I.Description,ROID.EstimatedPrice,ROID.Qty,I.BarCode,ROID.InsertTime,I.Id as ItemId" +
                //            " FROM RequestOrderItemDetails as ROID " +
                //            "   LEFT JOIN RequestOrderItems  as ROI on ROI.Id = ROID.RequestOrderItemId " +
                //            "   LEFT JOIN Items as I on I.id = ROID.ItemId " +
                //            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                //            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId " +
                //            " WHERE ROI.Id = " + Id + "" +
                //            " ORDER BY ROID.Id ASC ";
                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        List<Items> Items = new List<Items>();
                //        while (reader.Read())
                //        {
                //            var item = new Items();

                //            item.Id = reader.GetInt32(0);
                //            item.CategoryName = reader.GetString(1);
                //            item.CompanyName = reader.GetString(2);
                //            item.GenericName = reader.GetString(3);
                //            item.BrandName = reader.GetString(4);
                //            item.Description = reader.GetString(5);
                //            item.SellingPricePerPiece = reader.GetDecimal(6);
                //            item.Stock = reader.GetInt32(7);
                //            if(!reader.IsDBNull(8))
                //            {
                //                item.BarCode = reader.GetString(8);
                //            }

                //            item.InsertTime = reader.GetDateTime(9);
                //            item.TempItemId = reader.GetInt32(10);
                //            Items.Add(item);
                //        }
                //        return Items;
                //    }
                //}
            }
        }

        public IList<Items> GetListWithItemId(int? ItemId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                return null;
                //var select = "SELECT ROID.Id,Ca.CategoryName,Co.CompanyName,I.GenericName,I.BrandName, I.Description,ROID.EstimatedPrice,ROID.Qty,I.BarCode,ROID.InsertTime,I.Id as ItemId" +
                //            " FROM RequestOrderItemDetails as ROID " +
                //            "   LEFT JOIN RequestOrderItems  as ROI on ROI.Id = ROID.RequestOrderItemId " +
                //            "   LEFT JOIN Items as I on I.id = ROID.ItemId " +
                //            "   LEFT JOIN Companies as Co on Co.id = I.CompanyId " +
                //            "   LEFT JOIN Categories as Ca on Ca.Id = I.CategoryId " +
                //            " WHERE ROID.ItemId = " + ItemId + "" +
                //            " ORDER BY ROID.Id ASC ";
                //using (SqlCommand cmd = new SqlCommand(select, connection))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        List<Items> Items = new List<Items>();
                //        while (reader.Read())
                //        {
                //            var item = new Items();

                //            item.Id = reader.GetInt32(0);
                //            item.CategoryName = reader.GetString(1);
                //            item.CompanyName = reader.GetString(2);
                //            item.GenericName = reader.GetString(3);
                //            item.BrandName = reader.GetString(4);
                //            item.Description = reader.GetString(5);
                //            item.SellingPricePerPiece = reader.GetDecimal(6);
                //            item.Stock = reader.GetInt32(7);
                //            if (!reader.IsDBNull(8))
                //            {
                //                item.BarCode = reader.GetString(8);
                //            }

                //            item.InsertTime = reader.GetDateTime(9);
                //            item.TempItemId = reader.GetInt32(10);
                //            Items.Add(item);
                //        }
                //        return Items;
                //    }
                //}
            }
        }
    }
}
