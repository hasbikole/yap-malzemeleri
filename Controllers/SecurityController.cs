using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YapiMalzemeleriOdev.Models.EntityFramework;

namespace YapiMalzemeleriOdev.Controllers
{
    public class SecurityController : Controller
    {
        YapimalzemeleriEntities2 db = new YapimalzemeleriEntities2();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User kullanici)
        {
            


                var kullaniciInDb = db.User.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
                if (kullaniciInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Geçersiz kullanıcı adı veya parola";
                    return View();
                }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}