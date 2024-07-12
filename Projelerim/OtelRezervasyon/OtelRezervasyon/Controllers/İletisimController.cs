using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelRezervasyon.Models.Entity;

namespace OtelRezervasyon.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        OtelRezervasyonContext db = new OtelRezervasyonContext();
        public ActionResult Index()
        {
            var bilgiler = db.Tblİletisim.ToList();
            return View(bilgiler);
        }
        [HttpGet]//sayfa yüklendiğinde bu kısım çalışcak
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }

        [HttpPost]//butona bastığımda
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesaj.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}