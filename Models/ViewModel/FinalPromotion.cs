using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineCheckoutProcess.Models.ViewModel
{
    public class FinalPromotion
    {
        public List<SKUOrder> CalculatePromotion(List<SKUOrder> list)
        {
            if (list.Count() > 0)
            {
                list = new PromotionA().CalculatePromotion(list);
                list = new PromotionB().CalculatePromotion(list);
                list = new PromotionC().CalculatePromotion(list);
            }
            return list;
        }
    }
}
