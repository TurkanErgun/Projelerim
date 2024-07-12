using projee.Models;
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projee.Controllers
{
    public class HastaController : Controller
    {
        // GET: Hasta
        KanBankasiContext db = new KanBankasiContext();

        public ActionResult Index()
        {
            var hasta = db.Hasta.ToList();
            return View(hasta);
        }
        [HttpGet]
        public ActionResult YeniHasta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHasta(Hasta h1)

        {
            db.Hasta.Add(h1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hasta = db.Hasta.Find(id);
            db.Hasta.Remove(hasta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaDüzelt(int id)
        {
            var hasta = db.Hasta.Find(id);
            return View("HastaDüzelt", hasta);
        }
        public ActionResult Guncelle(Hasta c)
        {
            var hasta = db.Hasta.Find(c.hastaID);
            hasta.ad = c.ad;
            hasta.soyad = c.soyad;
            hasta.tc = c.tc;
            hasta.cinsiyet = c.cinsiyet;
            hasta.yas = c.yas;
            hasta.tel = c.tel;
            hasta.adres = c.adres;
            hasta.kanGrup = c.kanGrup;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Stok()
        {
            var kritik = db.Transfer.Where(x => x.kanStok <= 100).ToList();
            return View(kritik);
        }

    }
}