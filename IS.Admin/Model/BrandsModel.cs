using IS.Admin.Setup;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class BrandsModel
    {
        public IList<Brands> BrandList(FrmBrands frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.BrandsRepository.Find(Keywords);
        }
        public void AddBrand(FrmAddBrand frm)
        {
            var factory = new ISFactory();
            factory.BrandsRepository.Insert(frm._Brands);
        }
        public bool CheckDup(FrmAddBrand frm)
        {
           var factory = new ISFactory();
           return factory.BrandsRepository.BrandsStrategy.CheckDuplicate(frm._Brands.Name);
        }
        public bool CheckEditDup(string name, int? brandId)
        {
            var factory = new ISFactory();
            return factory.BrandsRepository.BrandsStrategy.CheckEditDuplicate(name, brandId);
        }
        public void UpdateBrand(Brands brand)
        {
            var factory = new ISFactory();
            factory.BrandsRepository.Update(brand);
        }

        public void DeleteBrand(Brands brand)
        {
            var factory = new ISFactory();
            factory.BrandsRepository.Delete(brand);
        }
        public Brands LoadEdit(int? brandId)
        {
            var factory = new ISFactory();
            return factory.BrandsRepository.FindWithId(brandId);
        }

        public bool CheckBrandIfAlreadyInUse(int? brandId)
        {
            var factory = new ISFactory();
            return factory.BrandsRepository.BrandsStrategy.BrandAlreadyInUse(brandId);
        }
    }
}
