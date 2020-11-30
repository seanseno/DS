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
    public class TempSalesRepository : Helper
    {
        public IList<TempSales> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vTempSales";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<TempSales>().CreateList(reader);
                    }
                }
            }
        }
        public void Insert(TempSales model)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("spTempSalesInsert", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", model.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Qty", model.Qty));
                    cmd.Parameters.Add(new SqlParameter("@Price", model.Price));
                    cmd.Parameters.Add(new SqlParameter("@PriceDiscounted", model.PriceDiscounted));
                    cmd.Parameters.Add(new SqlParameter("@Discounted", model.Discounted));
                    cmd.Parameters.Add(new SqlParameter("@TotalPrice", model.TotalPrice));
                    cmd.Parameters.Add(new SqlParameter("@TempLedgerId", model.TempLedgerId));
                    cmd.Parameters.Add(new SqlParameter("@IsSenior", model.IsSenior));
                    cmd.Parameters.Add(new SqlParameter("@IsPwd", model.IsPWD));

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        public IList<TempSales> Find(int? CashierId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT Items.Description, TempSales.Qty, (Items.Price * TempSales.Qty) as Amount " +
                            "FROM TempSales INNER JOIN Items on Items.id = TempSales.ProductId " +
                            "WHERE CashieId = " + CashierId + " "+
                            " ORDER BY TempSales.Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempSales> Items = new List<TempSales>();
                        while (reader.Read())
                        {
                            var item = new TempSales();

                            //item.Description = reader.GetString(0);
                            item.Qty = reader.GetInt32(1);
                            item.TotalPrice = reader.GetDecimal(2);
                            Items.Add(item);
                        }
                        return Items;
                    }
                }
            }
        }

        public IList<TempSales> FindWithLedger(string CashierId,int? LedgerId, EnumActive enumActive)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = " SELECT * FROM vTempsales " +
                            " WHERE CashierId = '" + CashierId + "' " +
                            " AND TempLedgerId  = " + LedgerId + " " +
                            " ORDER BY Id";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return new ReflectionPopulator<TempSales>().CreateList(reader);
                    }
                }
            }
        }

        public Decimal FindTotal(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT SUM(Items.Price * TempSales.Qty) as TotalAmount FROM TempSales INNER JOIN Items on Items.id = TempSales.ProductId";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TempSales> Items = new List<TempSales>();
                        while (reader.Read())
                        {
                            return reader.GetDecimal(0);                   
                        }
                    }
                    return 0;
                }
            }
        }

        public void DeleteAll(TempLedgerSales ledger)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM TempSales WHERE TempLedgerId = " + ledger.Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "DELETE FROM TempSales WHERE Id = " + Id;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(TempSales tempSales)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "UPDATE TempSales " +
                    "SET PriceDiscounted = " + tempSales.PriceDiscounted + "," +
                    "Discounted = " + tempSales.Discounted + "," +
                    "TotalPrice = " + tempSales.TotalPrice + ", " +
                    "IsSenior = " + tempSales.IsSenior + ", " +
                    "IsPwd = " + tempSales.IsPWD + " " +
                    "WHERE Id = " + tempSales.Id  ;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public TempSalesStrategy TempSalesStrategy => new TempSalesStrategy();
    }
}
