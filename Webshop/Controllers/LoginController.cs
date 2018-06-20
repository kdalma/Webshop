using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;
using System.Web.Helpers;

namespace Webshop.Controllers
{
    public class LoginController : Controller
    {
        WebshopDBEntities db = new WebshopDBEntities();

        // GET: login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: login
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var userNameList = db.User.Select(u => u.Email);

            if (!(userNameList.Contains(model.Email)))
            {
                ModelState.AddModelError(nameof(model.Email), "Nem létező felhasználónév és/vagy jelszó");
                return View("Index", "Home", model);
            }
            var hashedPassword = db.User.Where(u => u.Email == model.Email).Select(p => p.Password).FirstOrDefault();
            if (model.Password == null || Crypto.SHA256(model.Password) != hashedPassword)
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
    }
}