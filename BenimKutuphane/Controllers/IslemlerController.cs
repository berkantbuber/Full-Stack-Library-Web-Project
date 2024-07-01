using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;

namespace BenimKutuphane.Controllers
{
    public class IslemlerController : Controller
    {
        // GET: Islemler
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult Index()
        {
            var degerler = db.TabloHareket.Where(x => x.IslemDurum == true).ToList();
            return View(degerler);
        }
    }
}