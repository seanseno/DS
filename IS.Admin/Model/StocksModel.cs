using IS.Admin.Setup;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class StocksModel
    {
        public IList<Stocks> StockList(string Keywords)
        {
            var factory = new ISFactory();
            return factory.StocksRepository.Find(Keywords);
        }
        public void UpdateStock(string ProductId,int Stock, int CurrectStock, EnumStock enumStock)
        {
            var factory = new ISFactory();
            factory.StocksRepository.Update(ProductId, Stock, CurrectStock, enumStock);
        }

        public Stocks LoadEdit(string ProductId)
        {
            var factory = new ISFactory();
            return factory.StocksRepository.FindWithProductId(ProductId);
        }

    }
}
