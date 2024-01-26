using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();   // detay ve urun sınıflarındaki bilgilerin tutulduğu class 1 den nesne türetmiş olduk böylelikle cs yardımı ile hem detay hem urun bilgilerine tek tuşla ulaşmış olacağız
            cs.Deger1 = c.uruns.Where(x => x.urunID == 1).ToList();
            cs.Deger2 = c.detays.Where(y => y.detayid == 1).ToList();

            return View(cs);
        }
    }
}