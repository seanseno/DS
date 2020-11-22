using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Common.Utilities;
using IS.Database.Enums;
using System.Linq;
using IS.Database.Entities;

namespace IS.Database.Strategy
{
    public class AdministratorsStrategy : Helper
    {
        ISFactory factory = new ISFactory();
        public Administrators CheckAdministratorLogin(string Loginname, string Password)
        {
            var response = factory.AdministratorsRepository.GetList()
                .Where(x => x.Loginname == Loginname 
                    && x.Password == Encryption.EncryptString(Password, this.IsEncrypt)
                    && x.Active == (int)EnumActive.Active).FirstOrDefault();

            return response;
        }

        public bool CheckDuplicate(string LoginName)
        {
            return factory.AdministratorsRepository.GetList().Where(x => x.Loginname.ToUpper() == LoginName.ToUpper()).Count() > 0;
        }
    }
}
