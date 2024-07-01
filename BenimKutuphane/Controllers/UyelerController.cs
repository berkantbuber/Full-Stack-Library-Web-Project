using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace BenimKutuphane.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TabloUyeler.ToList();
            var degerler = db.TabloUyeler.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TabloUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TabloUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TabloUyeler.Find(id);
            db.TabloUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TabloUyeler.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TabloUyeler p)
        {
            var uye = db.TabloUyeler.Find(p.ID);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Fotograf = p.Fotograf;
            uye.Telefon = p.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmisi(int id)
        {
            var ktpgecmis = db.TabloHareket.Where(x => x.Uye == id).ToList();
            var uyekit = db.TabloUyeler.Where(y => y.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgecmis);
        }
    }
}