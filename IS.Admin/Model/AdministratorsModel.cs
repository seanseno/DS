﻿using IS.Admin.Setup;
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
        public void AddAdministrator(FrmAddAdministrator frm)
        {
            var factory = new ISFactory();
            factory.AdministratorsRepository.Insert(frm._Administrators);
        }
        public bool CheckDup(FrmAddAdministrator frm)
        {
           var factory = new ISFactory();
            return factory.AdministratorsRepository.AdministratorsStrategy.CheckDuplicate(frm._Administrators.Loginname);
        }
        //public bool CheckEditDup(string name, int? AdministratorId)
        //{
        //    var factory = new Factory();
        //    //return factory.AdministratorsRepository.AdministratorsStrategy.CheckEditDuplicate(name, AdministratorId);
        //    return true;
        //}
        public void UpdateAdministrator(Administrators Administrator)
        {
            var factory = new ISFactory();
            factory.AdministratorsRepository.Update(Administrator);
        }

        public void DeleteAdministrator(Administrators Administrator)
        {
            var factory = new ISFactory();
            factory.AdministratorsRepository.Delete(Administrator);
        }
        public Administrators LoadEdit(int? AdministratorId)
        {
            var factory = new ISFactory();
            return factory.AdministratorsRepository.FindAdministratorWithId(AdministratorId);
        }

        public bool CheckAdministratorIfAlreadyInUse(int? AdministratorId)
        {
            var factory = new ISFactory();
            //return factory.AdministratorsRepository.AdministratorsStrategy.AdministratorAlreadyInUse(AdministratorId);
            return false;
        }
    }
}