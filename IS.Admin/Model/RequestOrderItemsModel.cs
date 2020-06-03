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
        public string OrderDate(int Id)
        {
            var factory = new ISFactory();
            var response = factory.RequestOrderItemsRepository.GetOrderRequestInfoWithId(Id);
            if (response != null)
            {
                return string.Format("Order Date: {0}", response.OrderDate.ToString("MM/dd/yyyy"));
            }
            else
            {
                return null;
            }
        }
        public void Insert(string RequestOrdersName, IList<Items> RequestOrdersList)
        {
            var factory = new ISFactory();
            int? Id = factory.RequestOrderItemsRepository.Insert(Globals.LoginId, RequestOrdersName);
            if(Id != null)
            {
                foreach(var itm in RequestOrdersList)
                {
                    factory.RequestOrderItemDetailsRepository.Insert(itm, (int)Id);
                }
            }
        }
        public void Update(int? RequestId, IList<Items> RequestOrdersList)
        {
            var factory = new ISFactory();
            factory.RequestOrderItemDetailsRepository.Delete(RequestId);
            foreach (var itm in RequestOrdersList)
            {
                factory.RequestOrderItemDetailsRepository.Insert(itm, (int)RequestId);
            }
        }


        public bool CheckDupRequestName(string RequestOrdersNamet)
        {
            var factory = new ISFactory();
            return factory.RequestOrderItemsRepository.RequestOrderItemsStrategy.CheckDuplicate(RequestOrdersNamet);
        }
    }
}
