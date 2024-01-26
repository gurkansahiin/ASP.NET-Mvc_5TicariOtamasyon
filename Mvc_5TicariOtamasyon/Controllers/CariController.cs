using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.caris.Where(x => x.durum ==true).ToList();
            return View("Index",degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(cari x)
        {
           c.caris.Add(x);
            c.SaveChanges ();

            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var carisil = c.caris.Find(id);
            carisil.durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cgetir=c.caris.Find(id);    
            return View("CariGetir", cgetir);
        }

        public ActionResult CariGuncelle(cari car)
        {

            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var dgr = c.caris.Find(car.cariID);
            dgr.cariAd = car.cariAd;
            dgr.cariSoyad = car.cariSoyad;
            dgr.cariSehir = car.cariSehir;
            dgr.cariMail = car.cariMail;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult MüsteriSatis(int id)
        {
            var cr = c.caris.Where(x => x.cariID == id).Select(y => y.cariAd + " " + y.cariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            var degerlers = c.satis_Hareketis.Where(x => x.cariid == id).ToList();
            return View("MüsteriSatis", degerlers);

        }


        //eğer admin kısmında yetkiye göre bu sayfanın görünüp görünmeme durumunu göstermek istiyorsan csharedden adminlayouta git  ve if bloğu içine al o kısımı
    }
}