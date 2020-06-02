using CsvHelper;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class LoginModel
    {
        public bool CheckAdminLogin(string LoginName, string Password)
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.AdministratorsStrategy.CheckAdministratorLogin(LoginName, Password);
        }

    }
}
