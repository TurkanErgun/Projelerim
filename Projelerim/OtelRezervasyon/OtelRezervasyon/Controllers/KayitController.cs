using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelRezervasyon.Models.Entity;
namespace OtelRezervasyon.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        OtelRezervasyonContext db = new OtelRezervasyonContext();
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TblMisafir p)
        {
            db.TblMisafir.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}