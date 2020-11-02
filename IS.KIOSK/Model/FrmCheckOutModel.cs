using IS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.KIOSK.Model
{
    public class FrmCheckOutModel
    {
        ISFactory factory = new ISFactory();
        public int ExecutePayment(FrmCheckOut frmCheckout,FrmMain frmMain)
        {
           return factory.LedgerSalesRepository.Insert(frmMain._Cashier, frmCheckout.payAmount, frmCheckout.changeAmount, frmMain._CustomerName, frmMain._AdditionalInfo,(int)frmMain._TempLedgerSales.Id);
        }
    }
}
