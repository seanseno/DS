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
    public class CashiersModel
    {
        public IList<Cashiers> CashierList(FrmCashiers frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.CashiersRepository.Find(Keywords);
        }
        public Cashiers AddCashier(FrmAddCashier frm)
        {
            var factory = new ISFactory();
            return factory.CashiersRepository.Insert(frm._Cashiers);
        }
        public bool CheckDup(FrmAddCashier frm)
        {
           var factory = new ISFactory();
            return factory.CashiersRepository.CashiersStrategy.CheckDuplicate(frm._Cashiers.Loginname);
        }
        //public bool CheckEditDup(string name, int? CashierId)
        //{
        //    var factory = new Factory();
        //    //return factory.CashiersRepository.CashiersStrategy.CheckEditDuplicate(name, CashierId);
        //    return true;
        //}
        public void UpdateCashier(Cashiers Cashier)
        {
            var factory = new ISFactory();
            factory.CashiersRepository.Update(Cashier);
        }

        public void DeleteCashier(Cashiers Cashier)
        {
            var factory = new ISFactory();
            factory.CashiersRepository.Delete(Cashier);
        }
        public Cashiers LoadEdit(int? CashierId)
        {
            var factory = new ISFactory();
            return factory.CashiersRepository.FindCashierWithId(CashierId);
        }

        public bool CheckCashierIfAlreadyInUse(int? CashierId)
        {
            var factory = new ISFactory();
            //return factory.CashiersRepository.CashiersStrategy.CashierAlreadyInUse(CashierId);
            return false;
        }
    }
}
