using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloDuyuru.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TabloDuyuru d)
        {
            db.TabloDuyuru.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TabloDuyuru.Find(id);
            db.TabloDuyuru.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TabloDuyuru p)
        {
            var duyuru = db.TabloDuyuru.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TabloDuyuru t)
        {
            var duyuru = db.TabloDuyuru.Find(t.ID);
            duyuru.DuyuruKategori = t.DuyuruKategori;
            duyuru.DuyuruIcerik = t.DuyuruIcerik;
            duyuru.DuyuruTarih = t.DuyuruTarih;
            db.SaveChanges() ;
            return RedirectToAction("Index");
        }
    }
}