using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc_5TicariOtamasyon.Models.sınıflar;
using PagedList;

namespace Mvc_5TicariOtamasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        //Web configde authentication yaptık yani bilgiler uyyşmuyorsa engelliyecek  bu authentication ı  CariPanelControllera uygulamak için de 
        //Authorize kullanmış olucam bunun aynısını Personel Panelinin index Controlerina da uygulayacağım
        Context c = new Context();
        [Authorize]

        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.mesajlars.Where(x => x.alici == mail).Where(y=>y.durum==true).ToList();
            ViewBag.m = mail;

            var mailid=c.caris.Where(x=>x.cariMail==mail).Select(y=>y.cariID).FirstOrDefault();
            ViewBag.mid=mailid;


            var toplamsatis=c.satis_Hareketis.Where(x=>x.cariid==mailid).Count();
            ViewBag.topsat=toplamsatis;

            var toplams =c.satis_Hareketis.Where(x => x.cariid == mailid).Sum(y => (decimal?)y.toplamtutar).ToString();
            ViewBag.toptutar= toplams;  // (decimal?)eğer null döndürüyorsan hata fırlatma((Nullable type))

            var toplamurun = c.satis_Hareketis.Where(x => x.cariid == mailid).Sum(y => (decimal?)y.adet).ToString();
            ViewBag.topurun = toplamurun;

            var adsoyad=c.caris.Where(x=>x.cariMail==mail).Select(y=>y.cariAd+" "+y.cariSoyad).FirstOrDefault();
            ViewBag.adsoy=adsoyad;

            var sehir = c.caris.Where(x => x.cariMail == mail).Select(y => y.cariSehir ).FirstOrDefault();
            ViewBag.shr = sehir;


            var meslek = c.caris.Where(x => x.cariMail == mail).Select(y => y.carimeslek).FirstOrDefault();
            ViewBag.mslk = meslek;


            var no = c.caris.Where(x => x.cariMail == mail).Select(y => y.caritel).FirstOrDefault();
            ViewBag.tel = no;


            ViewBag.email = mail;
            return View(degerler);
        }
        [Authorize]
        public ActionResult ProfilGuncelle(cari p)
        {
            var bilgi = c.caris.Find(p.cariID);
            bilgi.cariAd = p.cariAd;
            bilgi.cariSoyad = p.cariSoyad;
            bilgi.cariMail = p.cariMail;
            bilgi.cariSehir = p.cariSehir;
            bilgi.cariSifre = p.cariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Siparisler()
        {
            var mail = (string)Session["CariMail"];
            var id = c.caris.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();
            var ad = c.caris.Where(x => x.cariMail == mail).Select(y => y.cariAd + " " + y.cariSoyad).FirstOrDefault();
            ViewBag.adi = ad;


            var degerler = c.satis_Hareketis.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult Kargotakip(string p)
        {
            var deger = from x in c.kargoDetays select x;

            deger = deger.Where(y => y.TakipKod.Contains(p)); //contains içermek

            return View(deger.ToList());


        }

        [Authorize]
        public ActionResult CariKargotakip(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKod == id).ToList();



            return View(degerler);


        }


        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.mesajlars.Where(x => x.alici == mail).Where(y => y.durum == true).OrderByDescending(y => y.mesajID).ToList();

            var gelensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.alici == mail).ToString();
            ViewBag.gelensayi = gelensayi;


            var gidensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.gönderici == mail).ToString();
            ViewBag.gidensayi = gidensayi;

            var cöp = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Count(c => c.durum == false).ToString();
            ViewBag.cöpsayi = cöp;
            return View(mesaj);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.mesajlars.Where(x => x.gönderici == mail).Where(y => y.durum == true).OrderByDescending(y => y.mesajID).ToList();

            var gelensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.alici == mail).ToString();
            ViewBag.gelensayi = gelensayi;

            var gidensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.gönderici == mail).ToString();
            ViewBag.gidensayi = gidensayi;


            var cöp = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Count(c => c.durum == false).ToString();
            ViewBag.cöpsayi = cöp;
            return View(mesaj);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var idsi = id;
            ViewBag.idsi = idsi;

            var mesajdetayi = c.mesajlars.Where(x => x.mesajID == id).ToList();

            var mail = (string)Session["CariMail"];
            var gelensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.alici == mail).ToString();
            ViewBag.gelensayi = gelensayi;

            var gidensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.gönderici == mail).ToString();
            ViewBag.gidensayi = gidensayi;


            var cöp = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Count(c => c.durum == false).ToString();
            ViewBag.cöpsayi = cöp;
            return View(mesajdetayi);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];

            ViewBag.gönderen = mail;
            var gelensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.alici == mail).ToString();
            ViewBag.gelensayi = gelensayi;

            var gidensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.gönderici == mail).ToString();
            ViewBag.gidensayi = gidensayi;


            var cöp = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Count(c => c.durum == false).ToString();
            ViewBag.cöpsayi = cöp;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.gönderici = mail;
            m.durum = true;
            c.mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

        public ActionResult MesajSil(int id)
        {
            var sil = c.mesajlars.Find(id);
            sil.durum = false;
            c.SaveChanges();
            return RedirectToAction("CöpKutusu");
        }

        public ActionResult CöpKutusu()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Where(y => y.durum == false).OrderByDescending(y => y.mesajID).ToList();

            var gelensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.alici == mail).ToString();
            ViewBag.gelensayi = gelensayi;

            var gidensayi = c.mesajlars.Where(y => y.durum == true).Count(c => c.gönderici == mail).ToString();
            ViewBag.gidensayi = gidensayi;


            var cöp = c.mesajlars.Where(y => y.gönderici == mail || y.alici == mail).Count(c => c.durum == false).ToString();
            ViewBag.cöpsayi = cöp;
            return View(mesaj);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//tüm emirleri sessionları engelle
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult Ayarlar()
        {

            var mail = (string)Session["CariMail"];
            var id=c.caris.Where(x=>x.cariMail == mail).Select(y=>y.cariID).FirstOrDefault();
            var ayar = c.caris.Find(id);
            return PartialView(ayar);
        }

        public ActionResult AyarGuncelle(cari car)
        {

            var mail = (string)Session["CariMail"];
            var id = c.caris.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();

            var dgr = c.caris.Find(id);
            dgr.cariAd = car.cariAd;
            dgr.cariSoyad = car.cariSoyad;
            dgr.cariSehir = car.cariSehir;
            dgr.carimeslek = car.carimeslek;
            dgr.caritel = car.caritel;
            if (car.cariSifre != null)
            {
                dgr.cariSifre = car.cariSifre;
            }
         
            c.SaveChanges();

            return RedirectToAction("Index","CariPanel");
        }

        public PartialViewResult Duyurular()
        {

            var duy=c.mesajlars.Where(x=>x.gönderici=="admin").OrderByDescending(y=>y.mesajID).ToList();

   
            return PartialView(duy);
        }

        public ActionResult Urun()
        {
            var degerler = c.uruns.Where(x => x.durum == true).ToList();


            return View(degerler);
        }

        public ActionResult UrunDetay(int id)
        {
            var degerler = c.uruns.Where(x => x.durum == true & x.urunID==id).ToList();


            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunSatis(int id)
        {

            List<SelectListItem> deger1 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAD,
                                               Value = x.PersonelID.ToString()

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
            var mail = (string)Session["CariMail"];
            var cari = c.caris.FirstOrDefault(x => x.cariMail == mail);

            if (cari != null)
            {
                p.cariid = cari.cariID;
                
                c.satis_Hareketis.Add(p);
                c.SaveChanges();
            }

            return RedirectToAction("Siparisler", "CariPanel");
        }


        [HttpGet]
        public ActionResult Siparis(int id)
        {
            List<SelectListItem> deger1 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAD,
                                               Value = x.PersonelID.ToString()

                                           }
                                             ).ToList();

            ViewBag.dgr1 = deger1;

            var deger2 = c.uruns.Find(id);
            ViewBag.dgr2 = deger2.urunID;
            ViewBag.dgr3 = deger2.SatisFiyati;
            ViewBag.resim = deger2.urungörsel;
            ViewBag.ad = deger2.urunAD;


            return View();
        }

        [HttpPost]
        public ActionResult Siparis(basket p)
        {
            var mail = (string)Session["CariMail"];
            var cari = c.caris.FirstOrDefault(x => x.cariMail == mail);
            if (cari != null)
            {
                p.cari = cari.cariMail;
                p.tarih = DateTime.Now;

                c.baskets.Add(p);
                c.SaveChanges();
            }
            return RedirectToAction("urun1");
        }
      
        public ActionResult Sepet()
        {
            var mail = (string)Session["CariMail"];
            var cari = c.caris.FirstOrDefault(x => x.cariMail == mail);
           
            var degerler=c.baskets.Where(x=>x.cari==cari.cariMail).ToList();

            var maaliyet = c.baskets.Where(x => x.cari == cari.cariMail).Sum(y => (decimal?)y.maaliyet);
            ViewBag.total = maaliyet;


            return View(degerler);
        }

        
       
        public ActionResult SepetSil(int id)
        {
   

            var silinecek = c.baskets.Find(id);
            c.baskets.Remove(silinecek);
            c.SaveChanges();

            return RedirectToAction("Sepet");
        }

        public ActionResult SiparisTamamla(satis_hareketi p)
        {
            var mail = (string)Session["CariMail"];
            var cari = c.caris.FirstOrDefault(x => x.cariMail == mail);
            var cariID = c.caris.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();

            var sepettekiUrunler = c.baskets.Where(x => x.cari == mail).ToList();
            foreach (var urun in sepettekiUrunler)
            {
                // Yeni bir satış hareketi oluşturun
                var yeniSatishareketi = new satis_hareketi
                {
                    // Satış hareketi ile ilgili gerekli bilgileri doldurun
                    urunid = urun.urunid, // Ürün ID
                    cariid = cariID, // Müşteri ID (Müşteri bilgisi)
                    adet = urun.adet, // Ürün adeti
                    toplamtutar = urun.maaliyet , // Ürün maliyeti
                    tarih = DateTime.Today, // Satış tarihi (şu anki tarih)
                    fiyat = urun.maaliyet / urun.adet, // Ürün fiyatı (varsa)
                    personelid = 1, // Örnek personel ID - İstediğiniz gibi ayarlayabilirsiniz.
                                    // Diğer gerekli bilgileri doldurun
                };

                // Oluşturulan satış hareketini veritabanına ekleyin
                c.satis_Hareketis.Add(yeniSatishareketi);

                // Sepetin içinden bu ürünü kaldırın (eğer gerekiyorsa)
                c.baskets.Remove(urun);
            }

            // Değişiklikleri veritabanına kaydedin
            c.SaveChanges();

            return RedirectToAction("Tesekkürler");
        }

        public ActionResult Tesekkürler()
        {
            return View();
        }
        







        [HttpGet]
        public ActionResult UrunSatisv2(int id)
        {

            List<SelectListItem> deger1 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyAD,
                                               Value = x.PersonelID.ToString()

                                           }
                                            ).ToList();

            ViewBag.dgr1 = deger1;

            var deger2 = c.uruns.Find(id);
            ViewBag.dgr2 = deger2.urunID;
            ViewBag.dgr3 = deger2.SatisFiyati;
            ViewBag.resim = deger2.urungörsel;
            ViewBag.ad = deger2.urunAD;


            return View();
        }

        [HttpPost]
        public ActionResult UrunSatisv2(satis_hareketi p)
        {
            var mail = (string)Session["CariMail"];
            var cari = c.caris.FirstOrDefault(x => x.cariMail == mail);
        
            if (cari != null)
            {
                p.cariid = cari.cariID;
                p.tarih=DateTime.Now;

                c.satis_Hareketis.Add(p);
                c.SaveChanges();
            }

            return RedirectToAction("Siparisler", "CariPanel");
        }

        public ActionResult urun1(int sayfa = 1)
        {

            var degerler = c.uruns.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 10);


            return View(degerler);
         
        }
        public PartialViewResult parça()
        {
            var degerler = c.uruns.Where(x => x.durum == true).ToList();

            return PartialView(degerler);
        }

    }
}