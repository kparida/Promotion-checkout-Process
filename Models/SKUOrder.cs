using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngineCheckoutProcess.Models
{
    public class SKUOrder: SKUDetails
    {

        public int Quantity { get; set; }
        public IPromotionCalculation promotionCalculation { get; set; }
    }

}
