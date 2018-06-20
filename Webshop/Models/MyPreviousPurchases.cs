using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class MyPreviousPurchases
    {
        public List<Product> Products { get; set; }
        public List<PurchaseModel> FormerPurchases { get; set; }
    }
}