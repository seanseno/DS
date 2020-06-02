using IS.Common.Utilities;
using IS.Database.Entities;
using IS.Database.Strategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IS.Database.Repositories
{
    public class CashierCashOnHandRepository : Helper
    {

        public IList<CashierCashOnHand> FindCashiers(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT C.Id, C.Loginname,C.Fullname,CCH.Amount,CCH.InsertTime,CCH.UpdateTime " +
                            " FROM Cashiers as C " +
                            " LEFT JOIN CashierCashOnHand as CCH on CCH.CashierId = C.Id " +
                            " WHERE C.Loginname LIKE '%" + keyword + "%' and Fullname  LIKE '%" + keyword + "%' " +
                            " ORDER BY C.Fullname; ";

                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var cashierList = new List<CashierCashOnHand>();
                        while (reader.Read())
                        {
                            var cashier = new CashierCashOnHand
                            {
                                CashierId = reader.GetInt32(0),
                                Loginname = reader.GetString(1),
                            };
                            if (!reader.IsDBNull(2))
                            {
                                cashier.Fullname = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                cashier.Amount = reader.GetDecimal(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                cashier.InsertTime = reader.GetDateTime(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                cashier.UpdateTime = reader.GetDateTime(5);
                            }
                            cashierList.Add(cashier);
                        }
                        return cashierList;
                    }
                }
            }
        }
    }
}
