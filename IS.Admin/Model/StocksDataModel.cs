using IS.Admin.Transactions;
using IS.Database;
using IS.Database.Entities;
using IS.Database.Entities.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class StocksDataModel
    {

        public void InsertStockData(StocksData model)
        {
            var factory = new ISFactory();
            factory.StocksDataRepository.Insert(model);
        }

        public void UpdateStockData(StocksData StockData)
        {
            var factory = new ISFactory();
            factory.StocksDataRepository.Update(StockData);
        }

        public void DeleteStockData(int Id)
        {
            var factory = new ISFactory();
            factory.StocksDataRepository.Delete(Id);
        }
        public StocksData LoadEdit(int? Id)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.FindWithStockDataId(Id);
        }

        public bool CheckStockDataIfAlreadyInUse(int Id)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.StocksDataStrategy.StockDataAlreadyInUse(Id);
        }

        public bool CheckOngoingStockData(string ProductId)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.StocksDataStrategy.CheckOngoingStockData(ProductId);
        }
    }
}
