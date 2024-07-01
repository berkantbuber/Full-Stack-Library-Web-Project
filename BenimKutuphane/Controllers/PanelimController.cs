using BenimKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BenimKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TabloUyeler.FirstOrDefault(z => z.Mail == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TabloUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TabloUyeler.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre = p.Sifre;
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Fotograf = p.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TabloUyeler.Where(x=>x.Mail==kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();
            var degerler = db.TabloHareket.Where(x => x.Uye == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");     
        }
    }
}