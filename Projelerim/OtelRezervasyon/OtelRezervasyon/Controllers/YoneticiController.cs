using OtelRezervasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtelRezervasyon.Controllers
{
    [Authorize]//sisteme oturum açmadan girilmez
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        OtelRezervasyonContext db = new OtelRezervasyonContext();

        public ActionResult Index()
        {
            var personelmail = (string)Session["Email"];
            var personelbilgi = db.TblPersonel.Where(x => x.Email == personelmail).FirstOrDefault();
            return View(personelbilgi);
        }
        public ActionResult YoneticiBilgiGuncelle(TblPersonel p)
        {
            var personel = db.TblPersonel.Find(p.PersonelID);
            personel.AdSoyad = p.AdSoyad;
            personel.TC = p.TC;
            personel.Telefon = p.Telefon;
            personel.Adres = p.Adres;
            personel.Email = p.Email;
            db.SaveChanges();//değişiklikleri kaydet
            return RedirectToAction("Index");
        }
        public ActionResult Rezervasyonlar()
        {
            var rezervasyon = db.TblRezervasyon.ToList();
            return View(rezervasyon);
        }
        public ActionResult RezervasyonGuncelle(TblRezervasyon p)
        {
            var rezervasyon = db.TblRezervasyon.Find(p.RezervasyonID);
            rezervasyon.RezervasyonAdSoyad = p.RezervasyonAdSoyad;
            rezervasyon.Telefon = p.Telefon;
            rezervasyon.Aciklama = p.Aciklama;
            rezervasyon.GirisTarih = p.GirisTarih;
            rezervasyon.CikisTarih = p.CikisTarih;
            rezervasyon.Kisi = p.Kisi;
            var oda = db.TblOda.Where(m => m.OdaID == p.TblOda.OdaID).FirstOrDefault();//atama işlemi yaparak oda ıd ye ulaşdık ve guncellendi
            rezervasyon.Oda = oda.OdaID;
            db.SaveChanges();//değişiklikleri kaydet
            return RedirectToAction("Rezervasyonlar");
        }
        public ActionResult RezervasyonDetay(int id)
        {
            var rezervasyon = db.TblRezervasyon.Find(id);
            List<SelectListItem> drm = (from i in db.TblOda.ToList()//oda listele bunu i değişkenine ata
                                        select new SelectListItem // yeni listeyi seç
                                        {
                                            Text = i.OdaNo,// text ve value biz adı seçicez o arka kısımda ID sini alıcak
                                            Value = i.OdaID.ToString()

                                        }).ToList();
            ViewBag.oda = drm;//diğer sayfaya taşımak için yeni oda sayfasına oda değerleri alıcak
           // var rezervasyon = db.TblRezervasyon.Find(id);
            return View("RezervasyonDetay", rezervasyon);
        }
        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Email"];
            var mesajlar = db.TblMesaj2.Where(x => x.Alici == misafirmail).ToList();//sisteme girilen maile ait mesajları listeleyecek
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var misafirmail = (string)Session["Email"];
            var mesajlar = db.TblMesaj2.Where(x => x.Gonderen == misafirmail).ToList();//sisteme girilen maile ait mesajları listeleyecek
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var mesaj = db.TblMesaj2.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }
        [HttpGet]//SAYFA AÇILDIĞIND boş eklemesin
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj2 p)
        {
            var misafirmail = (string)Session["Email"];
            p.Gonderen = "turkan@gmail.com";
            //p.Alici = misafirmail;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesaj2.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//oturumu kapa
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
        public ActionResult Sil(int id)
        {
            var rezervasyon = db.TblRezervasyon.Find(id);
            db.TblRezervasyon.Remove(rezervasyon);    
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlar");

        }
        public ActionResult Oda()
        {
            var oda = db.TblOda.ToList();
            return View(oda);
        }
        public ActionResult OdaGuncelle(TblOda p)
        {
            var oda = db.TblOda.Find(p.OdaID);
            oda.OdaNo = p.OdaNo;
            oda.Kat = p.Kat;
            oda.Kapasite = p.Kapasite;
            oda.Aciklama = p.Aciklama;
            oda.Telefon = p.Telefon;
            var durum = db.TblDurum.Where(m => m.DurumID == p.TblDurum.DurumID).FirstOrDefault();//atama işlemi yaparak durum ıd ye ulaşdık ve guncellendi
            oda.Durum = durum.DurumID;
            db.SaveChanges();//değişiklikleri kaydet
            return RedirectToAction("Oda");
        }
        public ActionResult OdaDetay(int id)
        {
            var oda = db.TblOda.Find(id);
            List<SelectListItem> drm = (from i in db.TblDurum.ToList()//kategorileriyi listele bunu i değişkenine ata
                                         select new SelectListItem // yeni listeyi seç
                                         {
                                             Text = i.DurumAd,// text ve value biz adı seçicez o arka kısımda ID sini alıcak
                                             Value = i.DurumID.ToString()

                                         }).ToList();
            ViewBag.Durumlar = drm;//diğer sayfaya taşımak için yeni ürün sayfasına urundeki değerleri alıcak

           

            //var oda = db.TblOda.Find(id);
            return View("OdaDetay", oda);
            
        }
        public ActionResult Sil1(int id)
        {
            var oda = db.TblOda.Find(id);
            db.TblOda.Remove(oda);
            db.SaveChanges();
            return RedirectToAction("Oda");

        }
       

    }
}