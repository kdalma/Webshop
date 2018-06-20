using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class PurchaseController : Controller
    {
        private WebshopDBEntities db = new WebshopDBEntities();

        // GET: Purchase
        [HttpGet]
        public ActionResult MyPurchase()
        {
            int price = 0;

            foreach (var item in (List<Product>)Session["Cart"])
            {
                price += item.Price;
            }
            return View(price);
        }

        // Remove product from Shopping-Cart
        [HttpGet]
        public ActionResult Remove(int Id)
        {
            List<Product> cart = (List<Product>)Session["Cart"];
            int index = isExist(Id);
            cart.RemoveAt(index);
            Session["Cart"] = cart;
            return RedirectToAction("MyPurchase", "Purchase");
        }

        // If it exists, it collects all products with incoming parameter
        private int isExist(int Id)
        {
            List<Product> cart = (List<Product>)Session["Cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Id.Equals(Id))
                    return i;
            return -1;
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var purchase = new Purchase();
            purchase.UserId = (int)Session["userId"];
            purchase.Date = DateTime.Now;
            
            foreach (var item in (List<Product>)Session["Cart"])
            {
                purchase.TotalPrice += item.Price;
                var dbItem = db.Product.FirstOrDefault(p => p.Id == item.Id);                
                purchase.Product.Add(dbItem);                
            }

            db.Purchase.Add(purchase);            
            db.SaveChanges();

            Session["Cart"] = new List<Product>();

            return RedirectToAction("PreviousPurchases", "MyPreviousPurchases");
        }

        public ActionResult PreviousPurchases()
        {
            return View();
        }
    }
}