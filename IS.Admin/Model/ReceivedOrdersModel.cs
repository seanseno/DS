using IS.Admin.Setup;
using IS.Common.Utilities;
using IS.Database;
using IS.Database.Entities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class ReceivedOrdersModel
    {
        public IList<ItemReceivedOrders> OrderReceivedList(string keyword,int RequestId)
        {
            var factory = new ISFactory();
            return factory.OrderReceivedRepository.Find(keyword, RequestId);
        }
        public IList<Items> ItemList(string keyword)
        {
            var factory = new ISFactory();
            return factory.ItemsRepository.Find(keyword);
        }
        public void Delete(int? Id)
        {
            var factory = new ISFactory();
            factory.OrderReceivedRepository.Delete(Id);
        }
        public void Insert(ItemReceivedOrders model)
        {
            var factory = new ISFactory();
            factory.OrderReceivedRepository.Insert(model);
        }

        public ItemReceivedOrders FindWithId(int? Id)
        {
            var factory = new ISFactory();
           return  factory.OrderReceivedRepository.FindWithId(Id);
        }
        public void Update(ItemReceivedOrders itm)
        {
            var factory = new ISFactory();
            factory.OrderReceivedRepository.Update(itm);
        }
    }
}
