using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloPersonel.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TabloPersonel p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TabloPersonel.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TabloPersonel.Find(id);
            db.TabloPersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TabloPersonel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TabloPersonel p)
        {
            var prs = db.TabloPersonel.Find(p.ID);
            prs.PersonelAdSoyad = p.PersonelAdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}