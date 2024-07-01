using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TabloUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TabloUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}