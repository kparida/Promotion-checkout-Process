using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromotionEngineCheckoutProcess.Models.ViewModel;
using PromotionEngineCheckoutProcess.Models;

namespace PromotionEngineCheckoutProcess.Controllers
{
    public class ProductController : Controller
    {
 
        // GET: /<controller>/
        public IActionResult Index()
        {
            DBData dbPromotion = new DBData();
            CartDetails cart = new CartDetails();
            cart.SkuList= new List<SKUOrder>();
            var skulist = dbPromotion.Skus.ToList();
            if (skulist.Count() > 0)
            {
                for (int i = 0; i < skulist.Count(); i++)
                {
                    cart.SkuList.Add(new SKUOrder()
                    {
                        SKUID = skulist[i].SKUID,
                        Name = skulist[i].Name,
                        Price = skulist[i].Price
                    });
                    Console.WriteLine("Enter the product " + skulist[i].Name + " quantity.");
                    cart.SkuList[i].Quantity = Convert.ToInt32(Console.ReadLine());

                }

                if (cart.SkuList.Where(e => e.Quantity > 0).Count() > 0)
                {


                    Console.WriteLine("Enter");
                    Console.WriteLine("SKU's\totalQty\totalPrice");
                    Console.WriteLine("Update");

                    FinalPromotion fp = new FinalPromotion();
                    cart.SkuList = fp.CalculatePromotion(cart.SkuList);
                    for (int i = 0; i < cart.SkuList.Count(); i++)
                    {
                        if (cart.SkuList[i].Quantity > 0)
                        {
                            Console.WriteLine(cart.SkuList[i].Name + "\t" + cart.SkuList[i].Quantity
                                + "\t" + (cart.SkuList[i].Price == 0 ? "-" : "" + cart.SkuList[i].Price));
                        }
                    }
                    Console.WriteLine("Details");
                    float totalPrice = cart.SkuList.Sum(x => Convert.ToInt32(x.Price));
                    Console.WriteLine("Total" + totalPrice);

                }
            }
            else
            {
                Console.WriteLine("No SKU details available.");
            }
            Console.ReadLine();
            return View();
        }
    }
}
