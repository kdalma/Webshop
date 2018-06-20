using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;
using System.Data.Entity;

namespace Webshop.Controllers
{
    public class MyPreviousPurchasesController : Controller
    {
        WebshopDBEntities db = new WebshopDBEntities();

        // GET: MyPreviousPurchases
        [HttpGet]
        public ActionResult PreviousPurchases()
        {
            Purchase myPurchase = new Purchase();
            Product myProducts = new Product();
            int currentId = (int)Session["userId"];
            
            var purchaseList = db.Purchase.Include(p => p.Product).Where(u => u.UserId == currentId)
                .Select(p => new PurchaseModel() {Date = p.Date, PurchaseProduct = p.Product.ToList(),
                 TotalPrice = p.TotalPrice, UserId = currentId }).ToList();

            MyPreviousPurchases model = new MyPreviousPurchases()
            {
                FormerPurchases = purchaseList
            };

            return View(model.FormerPurchases);
        }
    }
}