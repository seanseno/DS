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
            return factory.ItemReceivedOrdersRepository.FindList(keyword, RequestId);
        }

        public IList<ItemReceivedOrders> OrderReceivedWithItemId(int itemId)
        {
            var factory = new ISFactory();
            return factory.ItemReceivedOrdersRepository.FindListWithItemId(itemId);
        }

        public IList<Products> ItemList(string keyword)
        {
            var factory = new ISFactory();
            return factory.ProductsRepository.Find(keyword);
        }

        public IList<RequestOrderItems> RequestOrderListWithItemId(int ItemId)
        {
            var factory = new ISFactory();
            var response = factory.RequestOrderProductsRepository.GetListWithItemList(ItemId);
            return response;
        }

        public RequestOrderItems GetOrderRequestInfoWithId(int ItemId)
        {
            var factory = new ISFactory();
            var response = factory.RequestOrderProductsRepository.GetOrderRequestInfoWithId(ItemId);
            return response;
        }
    }
}
