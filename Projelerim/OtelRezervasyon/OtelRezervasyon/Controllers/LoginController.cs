using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelRezervasyon.Models.Entity;

namespace OtelRezervasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        OtelRezervasyonContext db = new OtelRezervasyonContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMisafir p)
        {
            var bilgiler=db.TblMisafir.FirstOrDefault(x=>x.Email == p.Email && x.Sifre==p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                Session["Email"] = bilgiler.Email.ToString();
                return RedirectToAction("Index","Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}