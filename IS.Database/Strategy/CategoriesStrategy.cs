using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Common.Utilities;
using System.Linq;

namespace IS.Database.Strategy
{
    public class CategoriesStrategy : Helper
    {
        public bool CheckDuplicate(string CategoryId,string CategoryName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT CategoryName FROM vCategories WHERE CategoryId = '" + CategoryId + "' OR CategoryName = '" + SingleQuoteCorrection.convert(CategoryName)  + "'";
                using (SqlCommand cmd = new SqlCommand(select,connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                           return true;
                        }
                        return false;
                    }
                }
            }
        }


        public bool CheckEditDuplicate(string Name, int? CategoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT CategoryName FROM vCategories WHERE CategoryName = '" + Name + "' AND ID != " + CategoryId;
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        public bool CategoryAlreadyInUse(string CategoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData WHERE CategoryId  = '" + CategoryId + "'";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        public decimal? GetPercentSuggestedPrice(string CategoryId,decimal supplierPrice)
        {
            ISFactory factory = new ISFactory();
            var repsone = factory.CategoriesRepository.GetList().Where(x=>x.CategoryId == CategoryId).ToList().FirstOrDefault();
            if (repsone == null)
            {
                return null;
            }
            var sellingPrice = ((supplierPrice * (repsone.PercentSuggestedPrice / 100)) + supplierPrice);
            return sellingPrice;
        }
    }
}
