using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;
namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c=new Context();
        public ActionResult Index(string p)
        {
            var deger = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                deger=deger.Where(y=>y.TakipKod.Contains(p)); //contains içermek
            }
            return View(deger.ToList());
        }

        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "L", "M", "N" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            //s1(3karakter)+karakterler[k1](1karakter)+ s2(2karakter)+karakterler[k2](1karakter)+s3(2karakter)+karakterler[k3](1karakter)=10 karakter
            int s1, s2, s3;    
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 100);
            s3 = rnd.Next(10, 100);

            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takipkodu = kod;
            return View();  
        }
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay p)
        {
            c.kargoDetays.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //DIŞARIDAN GÖNDERDİĞİMİZ ID OLAYINA BENZER ŞEKİLDE  GİBİ STRİNG P PARAMETRESİNİ ALMIYOR SORUNUN NEDENİ
        //ROUTE CONFİG AYARI
        //çÖZÜM => Global.asax dosyasına git ROUTE CONFİG sağ tıkla Go the Defination =>url: "{controller}/{action}/{id}",  id olduğu için id ye göre işlem yapacağız sanıyor ama biz koda göre işlem yapacağız o yüzden değişkenimizin adı id olmak zorunda 
        //çözüm string id


        public ActionResult KargoTakip(string id)
        {
           
           var detay=c.kargoTakips.Where(x=>x.TakipKod==id).ToList();
            ViewBag.id = id;
            var tarih= @Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            ViewBag.trh = tarih;
            return View(detay);
        }
        public ActionResult KargoKaydet(string TakipKod, string aciklama, DateTime tarih )



        {
            KargoTakip k = new KargoTakip();
            k.TakipKod = TakipKod;
            k.aciklama = aciklama;
            k.tarih = tarih;
          

           

            c.kargoTakips.Add(k);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}