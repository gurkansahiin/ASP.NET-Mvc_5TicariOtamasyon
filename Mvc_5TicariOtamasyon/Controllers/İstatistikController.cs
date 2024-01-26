using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.caris.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = c.kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.uruns.Sum(x => x.stock).ToString();
            ViewBag.d5 = deger5;


            var deger6 = (from x in c.uruns select x.marka).Distinct().Count().ToString(); //Distinct tekrarsız
            ViewBag.d6 = deger6;

            var deger7 = c.uruns.Count(x => x.stock < 20).ToString();
            ViewBag.d7 = deger7;


            var deger8 = (from x in c.uruns select x.SatisFiyati).Max().ToString();
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.uruns select x.SatisFiyati).Min().ToString();
            ViewBag.d9 = deger9;

            var deger12 = (from x in c.uruns select x.marka).Max().ToString();
            ViewBag.d12 = deger12;

            var deger10 = c.uruns.Count(x => x.urunAD == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            var deger11 = c.uruns.Count(x => x.urunAD == "Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger13 = c.uruns.Where(u => u.urunID == c.satis_Hareketis.GroupBy(a => a.urunid).OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault()).Select(z => z.urunAD + " ").FirstOrDefault();
            ViewBag.d13 = deger13;


            var deger14 = c.satis_Hareketis.Sum(x => x.toplamtutar).ToString();
            ViewBag.d14 = deger14;

            var deger15 = c.satis_Hareketis.Count(x => x.tarih == DateTime.Today).ToString();
            ViewBag.d15 = deger15;


            var deger16 = c.satis_Hareketis.Where(x => x.tarih == DateTime.Today).Sum(x => (decimal?)x.toplamtutar).ToString();
            ViewBag.d16 = deger16; //(decimal?) eğer null döndürüyorsan hata fırlatma ((Nullable type))




            return View();
        }
        public ActionResult basictablolar()
        {
            var sorgu = from x in c.caris //cariler tablosunda çalışacağım x. ile carilerin tüm içeriğine ulaşabilirim
                        group x by x.cariSehir into g //grupla neye göre =x'e göre grupla  xin içindeki sehirler tarafından grupla ve g içine aktar. Bu satır, caris koleksiyonundaki öğeleri cariSehir özelliğine göre gruplar. g ise bu grupların her birini temsil eder.
                        select new grupsinif //: Bu bölüm, her bir grup için yeni bir nesne oluşturur.
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.personels
                         group x by x.departman.departmanAD into g
                         select new grupsinif2
                         {
                             departman = g.Key,
                             sayi = g.Count()

                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var degerler = c.caris.ToList();
            return PartialView(degerler);


        }
        public PartialViewResult Partial3()
        {
            var degerler = c.uruns.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.uruns
                        group x by x.marka into g
                        select new grupsinif3
                        {
                            marka = g.Key,
                            sayi = g.Count()

                        };
            return PartialView(sorgu);
        }
        public PartialViewResult Partial5()
        {
            var sorgu = from x in c.uruns
                        group x by x.kategori.kategoriAD into g
                        select new grupsinif4
                        {
                          kategori=g.Key, sayi=g.Count()


                        };
            return PartialView(sorgu);
        }
    }
}