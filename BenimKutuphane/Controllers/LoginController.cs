using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenimKutuphane.Models.Entity;
using System.Web.Security;

namespace BenimKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities1 db = new DBKUTUPHANEEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TabloUyeler p)
        {
            var bilgiler = db.TabloUyeler.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View(); 
            }
        }
    }
}