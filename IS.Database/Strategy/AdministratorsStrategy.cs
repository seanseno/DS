using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Common.Utilities;
using IS.Database.Enums;
using System.Linq;

namespace IS.Database.Strategy
{
    public class AdministratorsStrategy : Helper
    {
        ISFactory factory = new ISFactory();
        public  (int?,bool,string) CheckAdministratorLogin(string Loginname, string Password)
        {
            try
            {
                var response = factory.AdministratorsRepository.GetList()
                    .Where(x => x.Loginname == Loginname 
                        && x.Password == Encryption.EncryptString(Password, this.IsEncrypt)
                        && x.Active == (int)EnumActive.Active).FirstOrDefault();

                if (response != null)
                {
                    return (response.Id, true, null);
                }
                else
                {
                    return (null, false, null);
                }
            }
            catch (SqlException ex)
            {
                return (null, false, ex.Message);
            }
        }

        public bool CheckDuplicate(string LoginName)
        {
            return factory.AdministratorsRepository.GetList().Where(x => x.Loginname.ToUpper() == LoginName.ToUpper()).Count() > 0;
        }
    }
}
