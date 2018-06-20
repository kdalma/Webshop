using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;
using System.Data.Entity;


namespace Webshop.Controllers
{
    public class FavoriteController : Controller
    {
        private WebshopDBEntities db = new WebshopDBEntities();

        // GET: Favorite
        [HttpGet]
        public ActionResult Index()
        {
            var currentId = (int)Session["userId"];
            Product product = new Product();
            FavoriteModel favorite = new FavoriteModel()
            {
                Name = product.Name,
                Image = product.Image,
                Price = product.Price,
                ProductId = product.Id,
                UserId = currentId
            };

            favorite.MyFavoriteProducts = db.Favorite.Include(p => p.Product).Include(u => u.User).Where(u => u.UserId == currentId).ToList();
            return View(favorite);
        }

        [HttpPost]
        public ActionResult MyFavorite(int Id)
        {
            Product productThatWeSearchWith = db.Product.Find(Id);
            Product product = db.Product.
                Where(p => p.Name == productThatWeSearchWith.Name
                && p.Description == productThatWeSearchWith.Description).FirstOrDefault();

            var favoriteList = db.Favorite.Select(f => f.Id);
            Favorite favoriteProduct = new Favorite();
            favoriteProduct.ProductId = product.Id;
            favoriteProduct.UserId = (int)Session["userId"];
            db.Favorite.Add(favoriteProduct);

            db.SaveChanges();

            return RedirectToAction("Index", "AllProducts");
        }

        [HttpGet]
        public ActionResult Remove(int Id)
        {
            Favorite itemToDelete = new Favorite();
            itemToDelete = db.Favorite.Where(f => f.Id == Id).FirstOrDefault();
            db.Favorite.Remove(itemToDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Favorite");
        }
    }
}