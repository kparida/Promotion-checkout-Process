using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngineCheckoutProcess.Models
{
    public class CartDetails
    {
            public int CartID { get; set; }
            public List<SKUOrder> SkuList { get; set; }
    }
}
