using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TabloMesajlar.Where(x => x.Alici == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult Gonderilen()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TabloMesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TabloMesajlar m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.Gonderen = uyemail.ToString();
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TabloMesajlar.Add(m);
            db.SaveChanges();
            return RedirectToAction("Gonderilen","Mesajlar");
        }
    }
}