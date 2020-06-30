using IS.Admin.Setup;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class ItemsModel
    {
        public IList<Items> ItemList(string Keywords)
        {
            var factory = new ISFactory();
            return factory.ItemsRepository.Find(Keywords);
        }

        public void AddItem(FrmAddItem frm)
        {
            var factory = new ISFactory();

            //INSERT ITEM
            factory.ItemsRepository.Insert(frm._Items);
        }
        public bool CheckDup(FrmAddItem frm)
        {
            var factory = new ISFactory();
            //return factory.ItemsRepository.ItemsStrategy.CheckDuplicate(frm._Items.Name);
            return true;
        }
        public bool CheckEditDup(string name, int? itemId)
        {
            var factory = new ISFactory();
            return factory.ItemsRepository.ItemsStrategy.CheckEditDuplicate(name, itemId);
        }
        public void UpdateItem(Items item)
        {
            var factory = new ISFactory();
            factory.ItemsRepository.Update(item);
        }

        public void DeleteItem(Items item)
        {
            var factory = new ISFactory();
            factory.ItemsRepository.Delete(item);
        }
        public Items LoadEdit(string itemId)
        {
            var factory = new ISFactory();
            return factory.ItemsRepository.FindWithItemId(itemId);
        }

        public bool CheckItemIfAlreadyInUse(string itemId)
        {
            var factory = new ISFactory();
            return factory.ItemsRepository.ItemsStrategy.ItemAlreadyInUse(itemId);
        }

        //public Items UploadExcel( Items entity)
        //{
        //   var factory = new ISFactory();
        //   return  factory.ItemsRepository.UploadItem(entity);
        //}

        public void InsertItem(Items model)
        {
            var factory = new ISFactory();
            factory.ItemsRepository.Insert(model);
        }
    }
}
