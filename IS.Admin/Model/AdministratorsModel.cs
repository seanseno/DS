using IS.Admin.Setup;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class AdministratorsModel
    {
        public IList<Administrators> AdministratorList(FrmAdministrators frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.Find(Keywords);
        }

        public void UpdateAdministrator(Administrators Administrator)
        {
            var factory = new ISFactory();
            factory.AdministratorsRepository.Update(Administrator);
        }

        public Administrators LoadEdit(string AdminId)
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.FindAdministratorWithAdminId(AdminId);
        }
        public Administrators FindAdministratorWithLoginname(string Loginname)
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.FindAdministratorWithLoginname(Loginname);
        }
        public string GetNextId()
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.GetNextId();
        }
    }
}
