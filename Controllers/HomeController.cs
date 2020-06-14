using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapiMalzemeleriOdev.Models.EntityFramework;
using System.Linq.Dynamic;

namespace YapiMalzemeleriOdev.Controllers
{
    public class HomeController : Controller
    {
        YapimalzemeleriEntities2 db = new YapimalzemeleriEntities2();
        public ActionResult Index(string sort= "Urunler ad", string sortdir= "asc", string search= "")
        {
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}