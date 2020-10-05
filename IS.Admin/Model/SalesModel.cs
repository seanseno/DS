using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class SalesModel
    {
        public IList<Cashiers> CashierList(int? Id)
        {
            var factory = new ISFactory();
            return factory.CashiersRepository.FindCashierListWithId(Id);
        }

    }
}
