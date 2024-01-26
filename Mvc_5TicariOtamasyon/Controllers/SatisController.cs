using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
   
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.satis_Hareketis.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunAD,
                                               Value = x.urunID.ToString()
                                           }
                                         ).ToList();
            

          List<SelectListItem>  deger2=(from x in c.caris.ToList()
                     select new SelectListItem
                     {
                         Text=x.cariAd +" "+x.cariSoyad,
                         Value=x.cariID.ToString()
                     }
                     ).ToList();
            

            List<SelectListItem> deger3=(from x in c.personels.ToList() //listelenmiş halde ögeleri personel tablosundan aldık
                                         select new SelectListItem //seçilebilir halde getirdik
                                         {
                                             Text=x.PersonelAd+" "+x.PersonelSoyAD, //bize gözüken kısmı
                                             Value=x.PersonelID.ToString() //arka planda dönen kısım
                                         }
                                         ).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3=deger3;//view kısmına veriyi taşıma işlemi
            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(satis_hareketi s)
        {
            s.tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satis_Hareketis.Add(s);
          c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.urunAD,
                                               Value = x.urunID.ToString()
                                           }
                             ).ToList();

            List<SelectListItem> deger2 = (from x in c.caris.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd+" "+x.cariSoyad,
                                               Value = x.cariID.ToString()
                                           }
                             ).ToList();


            List<SelectListItem> deger3 = (from x in c.personels.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAD,
                                               Value = x.PersonelID.ToString()
                                           }
                             ).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.satis_Hareketis.Find(id);
            return View(deger);
        }
        public ActionResult SatisGuncelle(satis_hareketi s)
        {
            var satis = c.satis_Hareketis.Find(s.satisID);
            satis.urunid=s.urunid;
            satis.cariid=s.cariid;
            satis.personelid = s.personelid;
            satis.adet = s.adet;    
            satis.fiyat=s.fiyat;
            satis.toplamtutar=s.toplamtutar;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisDetaylar(int id)
        {
          var degerler=c.satis_Hareketis.Where(x=>x.satisID==id).ToList();
            return View(degerler);

        }
    }
}