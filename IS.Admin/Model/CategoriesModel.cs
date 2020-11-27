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
    public class CategoriesModel
    {
        public IList<Categories> CategoryListWithSelect()
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.FindWithSelect();
        }
        public void InsertCategory(Categories model)
        {
            var factory = new ISFactory();
            factory.CategoriesRepository.Insert(model);
        }
        public bool CheckDup(FrmAddCategory frm)
        {
           var factory = new ISFactory();
           return factory.CategoriesRepository.CategoriesStrategy.CheckDuplicate(frm._Categories.CategoryId,frm._Categories.CategoryName);
        }
        public bool CheckEditDup(string name, int? CategoryId)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.CategoriesStrategy.CheckEditDuplicate(name, CategoryId);
        }


        public string GetNextId()
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.GetNextId();
        }
    }
}
