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
    public class ItemReceivedOrdersModel
    {
        public ItemReceivedOrders ItemReceivedOrderWithId(int Id)
        {
            var factory = new ISFactory();
            return factory.ItemReceivedOrdersRepository.FindItemReceivedOrderWithId(Id);
        }

        public IList<ItemReceivedOrders> GetItemReceivedOrderListWithRequestOrderIdAndItemId(int RequestOrderId, int ItemId)
        {
            var factory = new ISFactory();
            return factory.ItemReceivedOrdersRepository.GetItemReceivedOrderListWithRequestOrderIdAndItemId(RequestOrderId,ItemId);
        }
        
    }
}
