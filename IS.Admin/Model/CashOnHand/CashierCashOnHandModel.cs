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
    public class CashierCashOnHandModel
    {
        public IList<CashierCashOnHand> CashierList(string Keywords)
        {
            var factory = new ISFactory();
            return factory.CashierCashOnHandRepository.FindCashiers(Keywords);
        }
    }
}
