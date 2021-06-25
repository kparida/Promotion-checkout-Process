using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineCheckoutProcess.Models.ViewModel
{
    public class PromotionC : IPromotionCalculation
    {
        public List<SKUOrder> CalculatePromotion(List<SKUOrder> list)
        {
            if (list.Where(f => f.SKUID == 3 && f.Quantity > 0).Count() > 0 && list.Where(f => f.SKUID == 4 && f.Quantity > 0).Count() > 0)
            {
                var skuC = list.Where(f => f.SKUID == 3).First();
                int skuCIndex = list.IndexOf(skuC);
                var skuD = list.Where(f => f.SKUID == 4).First();
                int skuDIndex = list.IndexOf(skuD);
                if (skuC.Quantity > 0 && skuD.Quantity > 0)
                {
                    if (skuC.Quantity == skuD.Quantity)
                    {
                        skuC.Price = 0;
                        skuD.Price = skuD.Quantity * 30;
                    }
                    else if (skuC.Quantity > skuD.Quantity)
                    {
                        int difference = skuC.Quantity - skuD.Quantity;
                        skuC.Price = difference * 20;
                        skuD.Price = skuD.Quantity * 30;
                    }
                    else if (skuC.Quantity < skuD.Quantity)
                    {
                        int difference = skuD.Quantity - skuC.Quantity;
                        skuC.Price = 0;
                        skuD.Price = (skuC.Quantity * 30) + (difference * 15);
                    }
                }
            }
            else
            {
                if (list.Where(f => f.SKUID == 3 && f.Quantity > 0).Count() == 0)
                {
                    var skuC = list.Where(f => f.SKUID == 3).First();
                    int skuCIndex = list.IndexOf(skuC);
                    list[skuCIndex].Price = 0;
                }
                if (list.Where(f => f.SKUID == 4 && f.Quantity > 0).Count() == 0)
                {
                    var skuD = list.Where(f => f.SKUID == 4).First();
                    int skuDIndex = list.IndexOf(skuD);
                    list[skuDIndex].Price = 0;
                }
            }
            return list;
        }
    }
}
