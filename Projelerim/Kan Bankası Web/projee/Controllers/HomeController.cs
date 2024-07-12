using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projee.Models;

namespace Projee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string eposta, string sifre)
        {
            KanBankasiContext db = new KanBankasiContext();
            Kullanici kullanici = db.Kullanici.Where(x => x.email == eposta && x.sifre == sifre).SingleOrDefault();
            if (kullanici == null) // yoksa
            {
                ViewBag.sonuc = "Kullanıcı bulunamadı.";
                return View();
            }
            else
            {
                Session["Kullanici"] = kullanici;
                return RedirectToAction("Anasayfa");
            }

        }

        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}