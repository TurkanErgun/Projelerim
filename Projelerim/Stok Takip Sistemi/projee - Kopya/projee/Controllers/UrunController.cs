using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using projee.Models;


namespace projee.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
       StokTakipContext db = new StokTakipContext();

        public ActionResult Index()
        {
            var urun = db.Urun.ToList();
            return View(urun);

        }
        [HttpGet]//sayfa yüklendiğinde
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> urun = (from i in db.Kategori.ToList()//kategorileriyi listele bunu i değişkenine ata
                                         select new SelectListItem // yeni listeyi seç
                                         {
                                             Text = i.ad,// text ve value biz adı seçicez o arka kısımda ID sini alıcak
                                             Value = i.kategoriID.ToString()

                                         }).ToList();
            ViewBag.urun = urun;//diğer sayfaya taşımak için yeni ürün sayfasına urundeki değerleri alıcak

            return View();
        }

        [HttpPost]
        public ActionResult YeniÜrün(Urun k1)

        {
            var kategori = db.Kategori.Where(m => m.kategoriID == k1.Kategori.kategoriID).FirstOrDefault();//kategoriID yi almak için
            k1.Kategori = kategori;
            db.Urun.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");//kaydetdikden sonra Index geri götürsün
            
        }
      
        public ActionResult Sil(int id)
        {
            var urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ÜrünDüzelt(int id)
        {
            var urun = db.Urun.Find(id);//bul IDyi
            List<SelectListItem> urn = (from i in db.Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.ad,
                                            Value = i.kategoriID.ToString()

                                        }).ToList();
            ViewBag.urun = urn;

            return View("ÜrünDüzelt", urun);
        }
        public ActionResult Guncelle(Urun c)
        {
            var urun = db.Urun.Find(c.urunID);
            urun.ad = c.ad; 
            urun.marka = c.marka;
            urun.fiyat = c.fiyat;
            urun.stok = c.stok;
            urun.populer = c.populer;
            var kategori = db.Kategori.Where(m => m.kategoriID == c.Kategori.kategoriID).FirstOrDefault();//atama işlemi yaparak kategori ıd ye ulaşdık ve guncellendi
            urun.Kategori.kategoriID = kategori.kategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KritikStok()
        {
          var kritik = db.Urun.Where(x=> x.stok <=100).ToList();
            return View(kritik);
        }
        public PartialViewResult StokCount()
        {
            if (User.Identity.IsAuthenticated)//kullanıcı giriş yaptıysa
            {
                var count = db.Urun.Where(x => x.stok < 100).Count();//count sayısını al
                ViewBag.count = count;
                var azalan = db.Urun.Where(x => x.stok == 100).Count();
                ViewBag.azalan = azalan;
            }
            return PartialView();
        }
       
        
    }
}