using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelRezervasyon.Models.Entity;

namespace OtelRezervasyon.Controllers
{
    [Authorize]//sisteme oturum açmadan girilmez
    public class MisafirController : Controller
    {
        // GET: Misafir
        OtelRezervasyonContext db= new OtelRezervasyonContext();

        public ActionResult Index()
        {
            var misafirmail = (string)Session["Email"];
            var misafirbilgi = db.TblMisafir.Where(x => x.Email == misafirmail).FirstOrDefault();
            return View(misafirbilgi);
        }
        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Email"];
            //ViewBag.a = misafirmail;
            var misafirid =db.TblMisafir.Where(x=> x.Email == misafirmail).Select(y=> y.AdSoyad).FirstOrDefault();
            //ViewBag.a= misafirid;
            var degerler=db.TblRezervasyon.Where(x=>x.RezervasyonAdSoyad== misafirid).ToList();
            return View(degerler);
        }
        public ActionResult MisafirBilgiGuncelle(TblMisafir p)
        {
            var misafir = db.TblMisafir.Find(p.MisafirID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Telefon = p.Telefon;
            misafir.Email = p.Email;
            misafir.Sifre = p.Sifre;
            db.SaveChanges();//değişiklikleri kaydet
            return RedirectToAction("Index"); 
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//oturumu kapa
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Email"];
            var mesajlar =db.TblMesaj2.Where(x=> x.Alici == misafirmail).ToList();//sisteme girilen maile ait mesajları listeleyecek
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
            p.Gonderen = misafirmail;
            p.Alici = "turkan@gmail.com";
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesaj2.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

    }
}