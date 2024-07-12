using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projee.Models;


namespace projee.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        StokTakipContext db = new StokTakipContext();

        public ActionResult Index()
        {
            var kullanici = db.Kullanici.ToList();
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult YeniKullanici()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKullanici(Kullanici a1)
        {
            db.Kullanici.Add(a1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kullanici = db.Kullanici.Find(id);
            db.Kullanici.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KullaniciDüzelt(int id)
        {
            var kullanici = db.Kullanici.Find(id);
            return View("KullaniciDüzelt", kullanici);
        }
        public ActionResult Guncelle(Kullanici p1)
        {
            var kullanici = db.Kullanici.Find(p1.kullaniciID);
            kullanici.ad = p1.ad;
            kullanici.soyad = p1.soyad;
            kullanici.telefon = p1.telefon;
            kullanici.cinsiyet = p1.cinsiyet;
            kullanici.email = p1.email;
            kullanici.adres = p1.adres;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}