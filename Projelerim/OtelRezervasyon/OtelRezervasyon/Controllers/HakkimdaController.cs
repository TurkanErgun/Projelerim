using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using OtelRezervasyon.Models.Entity;

namespace OtelRezervasyon.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Default
        OtelRezervasyonContext db = new OtelRezervasyonContext();

        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }

        public PartialViewResult PartialFooter() //sitenin en alt kısmı nın tasarımı yer alıyo
        {
            var doluoda = db.TblOda.Where(x => x.Durum != 1).Count(); //durum 1 den farklı ise oda dolu anlamına geliyor
            ViewBag.d = doluoda; //dolu oda deiğişkeninden gelen buraya yazılıcak
            var bosoda = db.TblOda.Where(x => x.Durum == 1).Count();// boş oda için şartım durum bir olan olan odalar dolu
            ViewBag.b = bosoda;
            return PartialView();
        }
        
        public PartialViewResult PartialSosyalMedya()
        {
            return  PartialView();
        }
    }
}