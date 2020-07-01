using IS.Database;
using IS.Database.Entities;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.KIOSK.Model
{
    public class MainModel
    {
        ISFactory factory = new ISFactory();
        public IList<Products> LoadItems(FrmMain frm, string keywords)
        {
            var resultList = factory.ProductsRepository.Find(keywords);
            return resultList;
        }

        public (IList<TempSales>,decimal) LoadTempOders(FrmMain frm)
        {
            var tempLedger = factory.TempLedgerSalesRepository.FindDefault(frm._Cashier.CashierId);
            if (tempLedger != null)
            {
                var tempOders = factory.TempSalesRepository.FindWithLedger(frm._Cashier.CashierId, tempLedger.Id, EnumActive.Active);
                if (tempOders != null)
                {
                    return (tempOders, tempOders.Sum(x => x.Amount));
                }
            }
            return (null,0);
        }

        public void SaveOrders(FrmMain frm)
        {
            factory.TempLedgerSalesRepository.Update(frm._TempLedgerSales, EnumActive.NonActive);
            frm._TempOrderList = null;
        }

        public void DeleteTempOrder(FrmMain frm,int? Id)
        {
            factory.TempSalesRepository.Delete(Id);
            frm._TempOrderList = null;
        }
        public void DeleteAllTempOrder(FrmMain frm)
        {
            factory.TempSalesRepository.DeleteAll(frm._TempLedgerSales);
            frm._TempOrderList = null;
        }
    }
}
