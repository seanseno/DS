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
    public class CompaniesModel
    {
        public IList<Companies> CompanyList(FrmCompanies frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.CompaniesRepository.Find(Keywords);
        }
        public IList<Companies> CompanyListWithSelect()
        {
            var factory = new ISFactory();
            return factory.CompaniesRepository.FindWithSelect();
        }
        
        public void AddCompany(FrmAddCompany frm)
        {
            var factory = new ISFactory();
            factory.CompaniesRepository.Insert(frm._Companies);
        }
        public bool CheckDup(FrmAddCompany frm)
        {
           var factory = new ISFactory();
           return factory.CompaniesRepository.CompaniesStrategy.CheckDuplicate(frm._Companies.CompanyName);
        }
        public bool CheckEditDup(string name, int? CompanyId)
        {
            var factory = new ISFactory();
            return factory.CompaniesRepository.CompaniesStrategy.CheckEditDuplicate(name, CompanyId);
        }
        public void UpdateCompany(Companies Company)
        {
            var factory = new ISFactory();
            factory.CompaniesRepository.Update(Company);
        }

        public void DeleteCompany(Companies Company)
        {
            var factory = new ISFactory();
            factory.CompaniesRepository.Delete(Company);
        }
        public Companies LoadEdit(int? CompanyId)
        {
            var factory = new ISFactory();
            return factory.CompaniesRepository.FindWithId(CompanyId);
        }


        public bool CheckCompanyIfAlreadyInUse(int? CompanyId)
        {
            var factory = new ISFactory();
            return factory.CompaniesRepository.CompaniesStrategy.CompanyAlreadyInUse(CompanyId);
        }
    }
}
