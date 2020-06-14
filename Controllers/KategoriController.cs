using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapiMalzemeleriOdev.Models.EntityFramework;

namespace YapiMalzemeleriOdev.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        YapimalzemeleriEntities2 db = new YapimalzemeleriEntities2();
       
        public ActionResult Kategori(string ara)
        {
            var model = db.Kategori.Where(x => x.Kategori_ad.Contains(ara) || ara == null).ToList();
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult Yeni()
        {
            return View("KategoriForm", new Kategori());
        }
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "A")]
        public ActionResult Kaydet(Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriForm");
            }
            if (kategori.Kategori_id == 0)
            {
                db.Kategori.Add(kategori);
            }
            else
            {
                var kategoriGuncelle = db.Kategori.Find(kategori.Kategori_id);
                if (kategoriGuncelle == null)
                {
                    return HttpNotFound();
                }
                kategoriGuncelle.Kategori_ad = kategori.Kategori_ad;
            }
            db.SaveChanges();
            return RedirectToAction("Kategori", "Kategori");
        }
        [Authorize(Roles = "A")]
        public ActionResult Guncelle(int id)
        {
            var model = db.Kategori.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("KategoriForm", model);
        }
        [Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
            var silinecekKategori = db.Kategori.Find(id);
            if(silinecekKategori == null)
            {
                return HttpNotFound();
            }
            db.Kategori.Remove(silinecekKategori);
            db.SaveChanges();
            return RedirectToAction("Kategori");
        }
    }
}