using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace IS.Database.Entities.Criteria
{
    public class StocksDataCriteria
    {
        public static List<StocksData> MeetCriteria(List<StocksData> entities,
            DateTime? DeliveryDateFrom = null,
            DateTime? DeliveryDateTo = null,
            string keyword = null)
        {
            var predicates = new List<Func<StocksData, bool>>();

            DeliveryDateFrom = new DateTime(DeliveryDateFrom.Value.Year, DeliveryDateFrom.Value.Month, DeliveryDateFrom.Value.Day,0,0,0);
            DeliveryDateTo = new DateTime(DeliveryDateTo.Value.Year, DeliveryDateTo.Value.Month, DeliveryDateTo.Value.Day, 23, 59, 59);

            if (!string.IsNullOrEmpty(keyword))
            {
                predicates.Add(s => s.ProductId.Contains(keyword) ||
                s.CategoryName.Contains(keyword) ||
                s.ProductName.Contains(keyword) ||
                s.PrincipalName.Contains(keyword));
            }
            if (DeliveryDateFrom.HasValue && DeliveryDateTo.HasValue)
            {
                predicates.Add(s => DeliveryDateFrom <= s.DeliveryDate && s.DeliveryDate <= DeliveryDateTo);
            }

            return ApplyAndPredicates(predicates, entities).ToList();
        }

        private static IEnumerable<StocksData> ApplyAndPredicates(IEnumerable<Func<StocksData, bool>> predicates, IEnumerable<StocksData> _myStores)
        {
            
            var filteredStores = _myStores;
            foreach (var predicate in predicates)
            {
                filteredStores = filteredStores.Where(predicate);
            }
            return filteredStores;
        }

    }
}
