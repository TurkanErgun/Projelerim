using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projee.Models;

namespace projee.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        StokTakipContext db = new StokTakipContext();   // tablolarıma ulaşmak için db
    
        public ActionResult Index()//kategorimi listelemek için oluştudum
        {
            var kategoriler = db.Kategori.ToList();
            return View(kategoriler);
        }
        [HttpGet]  //sayfa ilk yükendiğinde sadece view dönsün sayfa yenilendiğinde bunu yapıcak 
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost] //ben işlem yaptığımda butona bastığımda bu gerçekleşecek
        public ActionResult YeniKategori(Kategori p1)
        {
            db.Kategori.Add(p1);//p1 den gelen değerleri ekle
            db.SaveChanges();
            return View(); //sayfayı geri döndür 
        }
        public ActionResult Sil(int id)
        {
           var kategori = db.Kategori.Find(id);//urunu bulcak find bul
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
         public ActionResult KategoriDüzelt(int id)
        {
            var kategori = db.Kategori.Find(id);
            return View("KategoriDüzelt",kategori);
        }
        public ActionResult Guncelle (Kategori p1)
        {
            var kategori = db.Kategori.Find(p1.kategoriID);//find bul
            kategori.ad = p1.ad;//adı ID ye göre değişcek
            kategori.aciklama = p1.aciklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}