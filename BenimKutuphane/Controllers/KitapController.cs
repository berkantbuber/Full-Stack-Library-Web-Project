using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TabloKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.Ad.Contains(p));
            }
            // var kitaplar = db.TabloKitap.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TabloKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TabloYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TabloKitap p)
        {
            var ktg = db.TabloKategori.Where(k => k.ID == p.TabloKategori.ID).FirstOrDefault();
            var yzr = db.TabloYazar.Where(y => y.ID == p.TabloYazar.ID).FirstOrDefault();
            p.TabloKategori = ktg;
            p.TabloYazar = yzr;
            db.TabloKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TabloKitap.Find(id);
            db.TabloKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TabloKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TabloKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TabloYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TabloKitap p)
        {
            var ktp = db.TabloKitap.Find(p.ID);
            ktp.Ad = p.Ad;
            ktp.BasimYili = p.BasimYili;
            ktp.YayinEvi = p.YayinEvi;
            ktp.KitapDurum = true;
            var ktg = db.TabloKategori.Where(k => k.ID == p.TabloKategori.ID).FirstOrDefault();
            var yzr = db.TabloYazar.Where(y => y.ID == p.TabloYazar.ID).FirstOrDefault();
            ktp.Kategori = ktg.ID;
            ktp.Yazar = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}