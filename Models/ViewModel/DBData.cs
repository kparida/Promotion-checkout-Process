using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PromotionEngineCheckoutProcess.Models.ViewModel
{
    public class DBData:DbContext
    {
            public DbSet<SKUDetails> Skus { get; set; }
            public DbSet<Promotion> Promotions { get; set; }
    }
}
