using OtelRezervasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtelRezervasyon.Controllers
{
    public class YoneticiLoginController : Controller
    {
        // GET: YoneticiLogin
        OtelRezervasyonContext db = new OtelRezervasyonContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblPersonel p)
        {
            var bilgiler = db.TblPersonel.FirstOrDefault(x => x.Email == p.Email && x.TC == p.TC);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                Session["Email"] = bilgiler.Email.ToString();
                return RedirectToAction("Index", "Yonetici");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}