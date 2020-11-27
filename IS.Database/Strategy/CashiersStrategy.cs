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
        public Cashiers CheckCashierLogin(string Loginname, string Password)
        {
            var response = factory.CashiersRepository.GetList()
                    .Where(x => x.Loginname == Loginname
                        && x.Password == Encryption.EncryptString(Password, this.IsEncrypt)
                        && x.Active == (int)EnumActive.Active).FirstOrDefault();
            return response;
        }

        public bool CheckDuplicate(string LoginName)
        {
            return factory.CashiersRepository.GetList()
                    .Where(x => x.Loginname == LoginName).Count() > 0;
        }
    }
}
