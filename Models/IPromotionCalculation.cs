using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineCheckoutProcess.Models
{
    public interface IPromotionCalculation
    {
        List<SKUOrder> CalculatePromotion(List<SKUOrder> list);
    }
}
