using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;


namespace BenimKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloYazar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TabloYazar p)
        {
            db.TabloYazar.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TabloYazar.Find(id);
            db.TabloYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TabloYazar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TabloYazar p)
        {
            var yzr = db.TabloYazar.Find(p.ID);
            yzr.Ad = p.Ad;
            yzr.Soyad = p.Soyad;
            yzr.Detay = p.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}