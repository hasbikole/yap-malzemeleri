using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YapiMalzemeleriOdev.Models.EntityFramework;
using YapiMalzemeleriOdev.ViewModels;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace YapiMalzemeleriOdev.Controllers
{
    public class UrunlerController : Controller
    {
        YapimalzemeleriEntities2 db = new YapimalzemeleriEntities2();
        
        public ActionResult Index(string ara)
        {
            var model = db.Urunler.Where(x => x.urun_ad.Contains(ara) || ara == null).Include(x => x.Kategori).ToList();
            return View(model);
        }

        [Authorize(Roles = "A")]
        public ActionResult Yeni()
        {
            var model = new KategoriFormViewModels() {
                Kategoriler = db.Kategori.ToList(),
                urunler = new Urunler()
            };
            return View("UrunlerForm", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Urunler urunler)
        {
            if (!ModelState.IsValid)
            {
                var model = new KategoriFormViewModels()
                {
                    Kategoriler = db.Kategori.ToList(),
                    urunler = urunler
                };
                return View("UrunlerForm");
            }
            if (urunler.urun_id == 0)
            {
                db.Urunler.Add(urunler);
            }
            else
            {
                db.Entry(urunler).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult Guncelle(int id)
        {
            var model = new KategoriFormViewModels()
            {
                Kategoriler = db.Kategori.ToList(),
                urunler = db.Urunler.Find(id)
            };
            return View("UrunlerForm", model);
        }
        [Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
            var silinecekUrun = db.Urunler.Find(id);
            if (silinecekUrun == null)
            {
                return HttpNotFound();
            }
            db.Urunler.Remove(silinecekUrun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public int? ToplamMaas()
        //{
        //    return db.Urunler.Sum(x => x.urun_adet);
        //}

        
    }
}