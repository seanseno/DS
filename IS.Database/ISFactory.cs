﻿using IS.Database.Repositories;
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
        public ProductPriceHistoryRepository ProductPriceHistoryRepository => new ProductPriceHistoryRepository();
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
        public ItemReceivedOrdersRepository ItemReceivedOrdersRepository => new ItemReceivedOrdersRepository();
        public MenuAccessRepository MenuAccessRepository => new MenuAccessRepository();
        public StocksDataHistoryRepository StocksDataHistoryRepository =>  new StocksDataHistoryRepository();
        public SettingsRepository SettingsRepository => new SettingsRepository();
        public ProductsDiscountedRepository ProductsDiscountedRepository => new ProductsDiscountedRepository();
        public ReturnItemsRepository ReturnItemsRepository => new ReturnItemsRepository();

        public QuestionsRepository QuestionsRepository => new QuestionsRepository();
        public ReturnStocksDataRepository ReturnStocksDataRepository => new ReturnStocksDataRepository();
        public ThemesRepository ThemesRepository => new ThemesRepository();
        public ProductsHistoryRepository ProductsHistoryRepository => new ProductsHistoryRepository();
        public PrinterCoordinatesRepository PrinterCoordinatesRepository => new PrinterCoordinatesRepository();
        public CategoryDiscountedRepository CategoryDiscountedRepository => new CategoryDiscountedRepository();
        public PromoRepository PromoRepository => new PromoRepository();
        public PromoDetailsRepository PromoDetailsRepository => new PromoDetailsRepository();
        public TempPromoDetailsRepository TempPromoDetailsRepository => new TempPromoDetailsRepository();
        //public PromoRepository PromoRepository = new PromoRepository();
        //public PromoRepository PromoRepository  = new PromoRepository();
        //public PromoDetailsRepository PromoDetailsRepository = new PromoDetailsRepository();
    }
}
