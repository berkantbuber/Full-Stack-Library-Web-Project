using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class OduncKitapController : Controller
    {
        // GET: OduncKitap
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloHareket.Where(x => x.IslemDurum == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TabloUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad + " " + x.Soyad,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in db.TabloKitap.Where(x=>x.KitapDurum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in db.TabloPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAdSoyad,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TabloHareket p)
        {
            var d1 = db.TabloUyeler.Where(x => x.ID == p.TabloUyeler.ID).FirstOrDefault();
            var d2 = db.TabloKitap.Where(y => y.ID == p.TabloKitap.ID).FirstOrDefault();
            var d3 = db.TabloPersonel.Where(z => z.ID == p.TabloPersonel.ID).FirstOrDefault();
            p.TabloUyeler = d1;
            p.TabloKitap = d2;
            p.TabloPersonel = d3;
            db.TabloHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncIade(TabloHareket p)
        {
            var odnc = db.TabloHareket.Find(p.ID);
            DateTime d1 = DateTime.Parse(odnc.IadeTarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("OduncIade", odnc);
        }
        public ActionResult OduncKitapGuncelle(TabloHareket p)
        {
            var odnc = db.TabloHareket.Find(p.ID);
            odnc.GetirdigiTarih = p.GetirdigiTarih;
            odnc.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}