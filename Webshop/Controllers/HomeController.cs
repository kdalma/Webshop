using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using Webshop.Models;
using System.Web.Helpers;


namespace Webshop.Controllers
{
    public class HomeController : Controller
    {
        WebshopDBEntities db = new WebshopDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            model.ImagePathes = db.Product.Include(s => s.Size).Where(p => p.SizeId == 1).Select(i => i.Image).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            IndexModel model2 = new IndexModel();
            model2.ImagePathes = db.Product.Include(s => s.Size).Where(p => p.SizeId == 1).Select(i => i.Image).ToList();

            var userNameList = db.User.Select(u => u.Email);

            if (!(userNameList.Contains(model.Email)))
            {
                ModelState.AddModelError(nameof(model.Email), "Nem létező felhasználónév és/vagy jelszó");
                return View("Index", "Home", model);
            }
            var hashedPassword = db.User.Where(u => u.Email == model.Email).Select(p => p.Password).FirstOrDefault();
            if (model.PlainTextPassword == null || Crypto.SHA256(model.PlainTextPassword) != hashedPassword)
            {
                ModelState.AddModelError(nameof(hashedPassword), "Nem megfelelő jelszó");
                return View("Index", "Home", model);
            }
            Session["Cart"] = new List<Product>();
            Session["role"] = "member";
            Session["email"] = db.User.Where(u => u.Email == model.Email).Select(u => u.Email).FirstOrDefault();
            var userId = db.User.Where(u => u.Email == model.Email).Select(u => u.Id).FirstOrDefault();
            Session["userId"] = userId;
            return RedirectToAction("Index", "AllProducts");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Az alkalmazás leírása.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Kapcsolatok oldal.";

            return View();
        }
    }
}