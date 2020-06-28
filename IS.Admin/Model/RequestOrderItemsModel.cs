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
        public IList<Items> RequestOrderItemDetailsListWithItemId(int itemId)
        {
            var factory = new ISFactory();
            return factory.RequestOrderItemDetailsRepository.GetListWithItemId(itemId);
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
        public int InsertRequestOrderItemsWithUploadItem(DateTime DeliveryDate)
        {
            var factory = new ISFactory();
            int IdNextIdent = (int)factory.RequestOrderItemsRepository.GetNextIdent();
            string RequestOrdersName = "From Upload Item_" + DeliveryDate.ToShortDateString() + "_" + (IdNextIdent + 1);
            int Id = factory.RequestOrderItemsRepository.Insert(Globals.LoginId, RequestOrdersName);
            return Id;
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
