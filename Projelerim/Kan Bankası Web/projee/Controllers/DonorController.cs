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
    public class DonorController : Controller
    {
        // GET: Urun
       KanBankasiContext db = new KanBankasiContext();

        public ActionResult Index()
        {
            var donor = db.Donor.ToList();
            return View(donor);

        }
        [HttpGet]//sayfa yüklendiğinde
        public ActionResult YeniDonor()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult YeniDonor(Donor k1)

        {
       
            db.Donor.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult Sil(int id)
        {
            var donor = db.Donor.Find(id);
            db.Donor.Remove(donor);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DonorDüzelt(int id)
        {
            var donor = db.Donor.Find(id);
            return View("DonorDüzelt",donor);
        }
        public ActionResult Guncelle(Donor c)
        {
            var donor = db.Donor.Find(c.donorID);
            donor.ad = c.ad;
            donor.soyad = c.soyad;
            donor.tc = c.tc;
            donor.cinsiyet= c.cinsiyet;
            donor.yas = c.yas;
            donor.tel = c.tel;
            donor.adres = c.adres;
            donor.kanGrup = c.kanGrup;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KritikStok()
        {
          var kritik = db.KanStogu.Where(x => x.kanStok <=100).ToList();
            return View(kritik);
        }
       
       
        
    }
}