using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Database.Enums;
using IS.Common.Utilities;
using IS.Database.Entities;
using System.Linq;

namespace IS.Database.Strategy
{
    public class CashiersStrategy : Helper
    {
        ISFactory factory = new ISFactory();
        public (string,bool,string) CheckCashierLogin(string Loginname, string Password)
        {
            try
            {
                var res = factory.CashiersRepository.GetList()
                    .Where(x => x.Loginname == Loginname
                        && x.Password == Encryption.EncryptString(Password, this.IsEncrypt)
                        && x.Active == (int)EnumActive.Active).FirstOrDefault();
                if (res != null)
                {
                    return (res.CashierId, true, string.Empty);
                }
                else
                {
                    return (string.Empty, false, string.Empty);
                }
            }
            catch (SqlException ex)
            {
                return (null, false, ex.Message);
            }
        }

        public bool CheckDuplicate(string LoginName)
        {
            return factory.CashiersRepository.GetList()
                    .Where(x => x.Loginname == LoginName).Count() > 0;
        }
    }
}
