using OtelRezervasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelRezervasyon.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        OtelRezervasyonContext db = new OtelRezervasyonContext();
        [Authorize]//kişi ilk önce giriş yapıp sonra rezervasyon yapıcak
        [HttpGet]
        public ActionResult Index()
        {
            var odalar = db.TblOda.Select(o => o.OdaNo).ToList();
            return View(odalar);
          
        }
        [HttpPost]
        public ActionResult Index(TblRezervasyon p)
        {
            p.Durum = 13;
            db.TblRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
       

    }
}