using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.KIOSK.Model
{
    public class ProductsModel
    {
        public IList<Products> FindListActive(string Keywords)
        {
            var factory = new ISFactory();
            return factory.ProductsRepository.FindListActive(Keywords);
        }
        public int GetTotalCount()
        {
            var factory = new ISFactory();
            return factory.ProductsRepository.GetTotalCount();
        }
    }
}
