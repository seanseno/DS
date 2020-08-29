using IS.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database
{
    public class ISFactory
    {
        public CategoriesRepository CategoriesRepository => new CategoriesRepository();
        public PrincipalsRepository PrincipalsRepository => new PrincipalsRepository();


        public AdministratorsRepository AdministratorsRepository => new AdministratorsRepository();
        public CashiersRepository CashiersRepository => new CashiersRepository();
        public ProductsRepository ProductsRepository => new ProductsRepository();
        public TempLedgerSalesRepository TempLedgerSalesRepository => new TempLedgerSalesRepository();
        public TempSalesRepository TempSalesRepository => new TempSalesRepository();
        public SalesRepository SalesRepository => new SalesRepository();
        public LedgerSalesRepository LedgerSalesRepository => new LedgerSalesRepository();
        public StocksRepository StocksRepository => new StocksRepository();
        public StocksHistoryRepository StocksHistoryRepository => new StocksHistoryRepository();
        public CashierCashOnHandDenominationRepository CashierCashOnHandDenominationRepository => new CashierCashOnHandDenominationRepository();
        public CashierCashOnHandRepository CashierCashOnHandRepository => new CashierCashOnHandRepository();
       
        public RequestOrderProductsRepository RequestOrderProductsRepository  => new RequestOrderProductsRepository();

        public StocksDataRepository StocksDataRepository => new StocksDataRepository();

        public RequestOrderItemDetailsRepository RequestOrderItemDetailsRepository => new RequestOrderItemDetailsRepository();
        public ItemReceivedOrdersRepository ItemReceivedOrdersRepository = new ItemReceivedOrdersRepository();
    }
}
