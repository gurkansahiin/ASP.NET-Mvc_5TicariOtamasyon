using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc_5TicariOtamasyon.Models.sınıflar;
namespace Mvc_5TicariOtamasyon.Controllers
{
    [AllowAnonymous] //hariç tutuyoruz global.asaxdaki authorizden 
    public class LoginController : Controller
    {
        // GET: Login
        Context c=new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult partial1()
        {

            return PartialView();   
        }

        [HttpPost]
        public PartialViewResult partial1(cari ca)
        {
            c.caris.Add(ca);
            c.SaveChanges();

            return PartialView();
        }

        //Giriş Yapma Olayı
        [HttpGet]
        public ActionResult CariGiris()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CariGiris(cari p)
        {
            var bilgiler = c.caris.FirstOrDefault(x => x.cariMail == p.cariMail && x.cariSifre == p.cariSifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.cariMail, false);
                Session["CariMail"]=bilgiler.cariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
          
        }

        [HttpGet]
        public ActionResult PersonelGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelGiris(admin a)
        {
            var bilgi=c.admins.FirstOrDefault(x=>x.KullaniciAd==a.KullaniciAd && x.sifre==a.sifre); 
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAd, false);
                Session["kuad"]=bilgi.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
    }
}