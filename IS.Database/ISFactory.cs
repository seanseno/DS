using IS.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database
{
    public class ISFactory
    {
        public AdministratorsRepository AdministratorsRepository => new AdministratorsRepository();
        public CashiersRepository CashiersRepository => new CashiersRepository();
        public ItemsRepository ItemsRepository => new ItemsRepository();
        public TempLedgerSalesRepository TempLedgerSalesRepository => new TempLedgerSalesRepository();
        public TempSalesRepository TempSalesRepository => new TempSalesRepository();
        public SalesRepository SalesRepository => new SalesRepository();
        public LedgerSalesRepository LedgerSalesRepository => new LedgerSalesRepository();
        public StocksRepository StocksRepository => new StocksRepository();
        public StocksHistoryRepository StocksHistoryRepository => new StocksHistoryRepository();
        public BrandsRepository BrandsRepository => new BrandsRepository();
        public CompaniesRepository CompaniesRepository => new CompaniesRepository();
        public CashierCashOnHandDenominationRepository CashierCashOnHandDenominationRepository => new CashierCashOnHandDenominationRepository();
        public CashierCashOnHandRepository CashierCashOnHandRepository => new CashierCashOnHandRepository();
        public CategoriesRepository CategoriesRepository => new CategoriesRepository();
        public RequestOrderItemsRepository RequestOrderItemsRepository  => new RequestOrderItemsRepository();
        public RequestOrderItemDetailsRepository RequestOrderItemDetailsRepository => new RequestOrderItemDetailsRepository();
        public OrderReceivedRepository OrderReceivedRepository = new OrderReceivedRepository();
    }
}
