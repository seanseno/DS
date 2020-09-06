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
        public IList<Categories> CategoryList(FrmCategories frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.Find(Keywords);
        }
        public IList<Categories> CategoryListWithSelect()
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.FindWithSelect();
        }

        public void AddCategory(FrmAddCategory frm)
        {
            var factory = new ISFactory();
            factory.CategoriesRepository.Insert(frm._Categories);
        }
        public void InsertCategory(Categories model)
        {
            var factory = new ISFactory();
            factory.CategoriesRepository.Insert(model);
        }
        public bool CheckDup(Categories model)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.CategoriesStrategy.CheckDuplicate(model.CategoryId, model.CategoryName);
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
        public void UpdateCategory(Categories Category)
        {
            var factory = new ISFactory();
            factory.CategoriesRepository.Update(Category);
        }

        public void DeleteCategory(Categories Category)
        {
            var factory = new ISFactory();
            factory.CategoriesRepository.Delete(Category);
        }
        public Categories LoadEdit(string CategoryId)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.FindWithCategoryId(CategoryId);
        }

        public bool CheckCategoryIfAlreadyInUse(string CategoryId)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.CategoriesStrategy.CategoryAlreadyInUse(CategoryId);
        }

        public string GetPercentSuggestedPrice(string CategoryId)
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.GetPercentSuggestedPrice(CategoryId);
        }

        public string GetNextId()
        {
            var factory = new ISFactory();
            return factory.CategoriesRepository.GetNextId();
        }
    }
}
