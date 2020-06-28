using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class UploadExcelItem
    {
        public string Categories { get; set; }
        public string Companies { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal SellingPricePerPiece { get; set; }
        public int Quantity { get; set; }
        public DateTime DateManufactured { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
