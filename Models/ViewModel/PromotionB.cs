using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineCheckoutProcess.Models.ViewModel
{
    public class PromotionB : IPromotionCalculation
    {
        public List<SKUOrder> CalculatePromotion(List<SKUOrder> list)
        {
            if (list.Where(f => f.SKUID == 2 && f.Quantity > 0).Count() > 0)
            {
                var sku = list.Where(f => f.SKUID == 2 && f.Quantity > 0).First();
                if (sku.Quantity > 1)
                {
                    int quotient = sku.Quantity / 2;
                    int remainder = sku.Quantity % 2;
                    int index = list.IndexOf(sku);
                    sku.Price = (quotient * 45) + ((remainder) * 30);
                    list[index].Price = sku.Price;
                }
            }
            else
            {
                if (list.Where(f => f.SKUID == 2 && f.Quantity > 0).Count() == 0)
                {
                    var skuB = list.Where(f => f.SKUID == 2).First();
                    int skuBIndex = list.IndexOf(skuB);
                    list[skuBIndex].Price = 0;
                }
            }
            return list;
        }
    }
}
