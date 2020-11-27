using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Common.Utilities;
using System.Linq;

namespace IS.Database.Strategy
{
    public class PrincipalsStrategy : Helper
    {
        ISFactory factory = new ISFactory();
        public bool CheckDuplicate(string PrincipalId,string PrincipalName)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                return factory.PrincipalsRepository.GetList()
                     .Where(x => x.PrincipalId.ToUpper().Contains(PrincipalId.ToUpper()) ||
                        x.PrincipalName == SingleQuoteCorrection.convert(PrincipalName).ToUpper()).Count() > 0;
            }
        }


        public bool CheckEditDuplicate(string Name, int? PrincipalId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT PrincipalName FROM vPrincipals WHERE PrincipalName = '" + Name + "' AND ID != " + PrincipalId;
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

        public bool PrincipalAlreadyInUse(string PrincipalId)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                var select = "SELECT * FROM vStocksData WHERE PrincipalId  = '" + PrincipalId + "'";
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
    }
}
