using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;
using System.Web.Helpers;

namespace Webshop.Controllers
{
    public class RegisterController : Controller
    {
        WebshopDBEntities db = new WebshopDBEntities();

        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                var emailList = db.User.Select(u => u.Email).ToList();
                if (emailList.Contains(model.Email))
                    ModelState.AddModelError(nameof(model.Email), "A felhasználó már létezik");
                if (model.Password != model.ConfirmPassword)
                    ModelState.AddModelError(nameof(model.ConfirmPassword), "Nem egyezik a jelszó");

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var hashedPassword = Crypto.SHA256(model.Password);
                User user = new User();
                user.Email = model.Email;
                user.Password = hashedPassword;

                db.User.Add(user);
                db.SaveChanges();

                Session["role"] = "member";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}