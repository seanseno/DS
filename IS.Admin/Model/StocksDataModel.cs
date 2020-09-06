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
        public IList<StocksData> StockDataList(string Keywords)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.Find(Keywords);
        }

        public IList<StocksData> StockDataListReport()
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.Find(null);
        }
        public IList<StocksData> FindWithRemainingQTY(string Keywords)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.FindWithRemainingQTY(Keywords);
        }

        public IList<StocksData> StockDataListWithSelect()
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.FindWithSelect();
        }

        public void InsertStockData(StocksData model)
        {
            var factory = new ISFactory();
            factory.StocksDataRepository.Insert(model);
        }
        public bool CheckDup(StocksData model)
        {
            //var factory = new ISFactory();
            //return factory.StocksDataRepository.StocksDataStrategy.CheckDuplicate(model.StockDataId, model.StockDataName);
            return true;
        }

        public bool CheckDup(FrmAddStockData frm)
        {
            return true;
            //var factory = new ISFactory();
            //return factory.StocksDataRepository.StocksDataStrategy.CheckDuplicate(frm._StocksData.StockDataId,frm._StocksData.StockDataName);
        }
        public bool CheckEditDup(string name, int? StockDataId)
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.StocksDataStrategy.CheckEditDuplicate(name, StockDataId);
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

        public bool CheckStockDataIfAlreadyInUse(string StockDataId)
        {
            //var factory = new ISFactory();
            //return factory.StocksDataRepository.StocksDataStrategy.StockDataAlreadyInUse(StockDataId);
            return true;
        }

        public string GetNextId()
        {
            var factory = new ISFactory();
            return factory.StocksDataRepository.GetNextId();
        }
    }
}
