using projee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projee.Controllers
{
    public class TransferBagisiController : Controller
    {
        // GET: TransferBagisi
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
        public ActionResult YeniBagisi(TransferBagis m)
        {
            db.TransferBagis.Add(m);
            db.SaveChanges();
            return View("Index");
        }
    }
}