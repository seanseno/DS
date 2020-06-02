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
        public IList<Items> StockList(string Keywords)
        {
            var factory = new ISFactory();
            return factory.StocksRepository.Find(Keywords);
        }
        public void UpdateStock(Items item,int? Qty,EnumStock enumStock)
        {
            //INSERT STOCK
            var stock = new Stocks
            {
                ItemId = item.Id,
                Stock = item.Stock
            };

            var factory = new ISFactory();
            factory.StocksRepository.Update(stock, Qty, enumStock);
        }

        public Items LoadEdit(int? ItemId)
        {
            var factory = new ISFactory();
            return factory.StocksRepository.FindWithItemId(ItemId);
        }

    }
}
