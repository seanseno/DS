using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using IS.Database.Entities;
using System.Linq;

namespace IS.Database.Strategy
{
    public class PromoStrategy : Helper
    {
        ISFactory factory = new ISFactory();
        public string CheckPromo(List<string> listProducId)
        {
            var obj = factory.PromoDetailsRepository.GetList().Where(x => listProducId.Contains(x.ProductId)).ToList();
            if (obj.Count > 0)
            {

                int PromoDetailsCount = factory.PromoDetailsRepository.GetList().Where(x => x.PromoId == obj.FirstOrDefault().PromoId).Count();
                var obj1 = from c in obj
                           group c by c.PromoId into grp
                           where grp.Count() == PromoDetailsCount
                           select grp.Key;
                if (obj1.Count() > 0)
                {
                    return factory.PromoRepository.GetList().Where(x => x.Id == obj.FirstOrDefault().PromoId).FirstOrDefault().PromoName;
                }
            }
            return null;
        }
    }
}
