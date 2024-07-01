using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;
using BenimKutuphane.Models.Siniflarim;


namespace BenimKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TabloKitap.ToList();
            cs.Deger2 = db.TabloHakkımızda.ToList();
            //var degerler = db.TabloKitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Tabloİletisim t)
        {
            db.Tabloİletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}