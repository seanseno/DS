using IS.Admin.Setup;
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
    public class RequestOrderItemsModel
    {
        public IList<RequestOrderItems> ItemList()
        {
            var factory = new ISFactory();
            return factory.RequestOrderItemsRepository.GetList();
        }

        public IList<Items> RequestOrderItemDetailsList(int Id)
        {
            var factory = new ISFactory();
            return factory.RequestOrderItemDetailsRepository.GetListWithId(Id);
        }
        public string OrderInfo(int Id)
        {
            var factory = new ISFactory();
            var response = factory.RequestOrderItemsRepository.GetOrderRequestInfoWithId(Id);
            if (response != null)
            {
                return string.Format("Order Date: {0}, Order By {1}", response.OrderDate, response.AdminName);
            }
            else
            {
                return null;
            }
        }
    }
}
