using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;
namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c=new Context();
        public ActionResult Index()
        {
            var deger1=c.caris.Count().ToString();  
            var deger2=c.uruns.Count().ToString();  
            var deger3=c.kategoris.Count().ToString();
            var deger4 = c.caris.Select(x => x.cariSehir).Distinct().Count().ToString();

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;

            var yap=c.yapilacaks.Where(x=>x.durum==true).ToList();
            return View(yap);
        }


        [HttpGet]
        public ActionResult Eklee()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult Eklee(yapilacak y)
        {
            c.yapilacaks.Add(y);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult sill(int id)
        {
            var sil = c.yapilacaks.Find(id);
            sil.durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}