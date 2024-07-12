using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using projee.Models;


namespace projee.Controllers
{
    public class KanBagisiController : Controller
    {
        // GET: Satis
        KanBankasiContext db = new KanBankasiContext();

        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult YeniBagisi() 

        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBagisi(KanBagisi p) 
        {
            db.KanBagisi.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}