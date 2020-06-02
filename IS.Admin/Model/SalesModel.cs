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

        public (IList<Sales>,decimal) SaleList(int? CashierId, DateTime? DateFrom, DateTime? DateTo)
        {
            var factory = new ISFactory();
            var sale = factory.SalesRepository.Find(CashierId, DateFrom, DateTo);
            return (sale, sale.Sum(x => x.Amount));
        }
    }
}
