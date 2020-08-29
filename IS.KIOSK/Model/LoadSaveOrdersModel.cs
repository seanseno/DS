using IS.Database;
using IS.Database.Entities;
using IS.Database.Entities.Extender;
using IS.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.KIOSK.Model
{
    public class LoadSaveOrdersModel
    {
        ISFactory _Factory = new ISFactory();
        public IList<TotalTempLedgerInfo> LoadSaveOrderList(FrmMain frm)
        {
            var resultList = _Factory.TempLedgerSalesRepository.Find(frm._Cashier.CashierId);
            return resultList;
        }

        public void Select(FrmMain frm, int Id)
        {
            //DELETE 
            _Factory.TempLedgerSalesRepository.Delete(frm._TempLedgerSales);

            //Activate Selected Id
            var tempLedgerSales = new TempLedgerSales();
            tempLedgerSales.Id = Convert.ToInt32(Id);
            _Factory.TempLedgerSalesRepository.Update(tempLedgerSales, EnumActive.Active);

        }
    }
}
