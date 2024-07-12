using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using projee.Models;


namespace projee.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        StokTakipContext db = new StokTakipContext();

        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult YeniSatis() 

        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Satis p) 
        {
            db.Satis.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}