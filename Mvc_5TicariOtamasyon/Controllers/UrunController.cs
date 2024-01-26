using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.uruns.Where(x => x.durum == true).ToList(); //x öyleki xi durumları trueye eşit olanları getir sadece
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {

            //seçilebilir bir liste oluşturdum deger1 adında. Bu liste değerlerini nerden alacak c.kategoris listelenmiş halinden

            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAD,
                                               Value = x.kategoriID.ToString()
                                           }
                                         ).ToList();

            //deger1 i nasıl  Viewe taşıyacağız ?

            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(urun p)
        {
            c.uruns.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urn = c.uruns.Find(id);
            urn.durum = false;
            //c.uruns.Remove(urn);
            c.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAD,
                                               Value = x.kategoriID.ToString()
                                           }
                                        ).ToList();

            //deger1 i nasıl  Viewe taşıyacağız ?

            ViewBag.dgr1 = deger1;

            var urngetir = c.uruns.Find(id);
            return View("UrunGetir", urngetir);

        }

        public ActionResult UrunGuncelle(urun u)
        {
            var urngucel = c.uruns.Find(u.urunID);
            urngucel.urunAD = u.urunAD;
            urngucel.marka = u.marka;
            urngucel.stock = u.stock;
            urngucel.AlisFiyati = u.AlisFiyati;
            urngucel.SatisFiyati = u.SatisFiyati;
            urngucel.SatisFiyati = u.SatisFiyati;
            urngucel.durum = u.durum;
            urngucel.kategoriID = u.kategoriID;
            urngucel.urungörsel = u.urungörsel;
            urngucel.urunAciklama=u.urunAciklama;
            urngucel.urunOzellikler = u.urunOzellikler;
            c.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = c.uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunSatis(int id)
        {

            List<SelectListItem> deger1 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.PersonelAd+ " "+x.PersonelSoyAD,
                                               Value=x.PersonelID.ToString()

                                           }
                                            ).ToList();

            ViewBag.dgr1 = deger1;

            var deger2 = c.uruns.Find(id);
            ViewBag.dgr2 = deger2.urunID;  
            ViewBag.dgr3 = deger2.SatisFiyati;  
            return View();
        }
        [HttpPost]
        public ActionResult UrunSatis(satis_hareketi p)
        {

            c.satis_Hareketis.Add(p);
            c.SaveChanges();


            return RedirectToAction("Index", "Satis");
        }

    }
}