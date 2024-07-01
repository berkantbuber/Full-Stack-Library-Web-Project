using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;
namespace BenimKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloKategori.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult KategoriEkle(TabloKategori p)
        {
            db.TabloKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TabloKategori.Find(id);
            db.TabloKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TabloKategori.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(TabloKategori p)
        {
            var ktg = db.TabloKategori.Find(p.ID);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}