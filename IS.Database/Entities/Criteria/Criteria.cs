using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities.Criteria
{
    public class Criteria
    {

        public ProductCriteria ProductCriteria => new ProductCriteria();
        public StocksDataCriteria StocksDataCriteria => new StocksDataCriteria();
        public ReportTotalSalesCriteria ReportTotalSalesCriteria => new ReportTotalSalesCriteria();
    }
}
