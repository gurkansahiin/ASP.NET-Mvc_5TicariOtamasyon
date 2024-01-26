using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;
using PagedList;// BiR SAYFADA LİSETELENCEK ÖGE SAYISI
using PagedList.Mvc;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize] //her defasında actionlara yazmaya gerek kalmıyor bunu tüm controllera uygulamak içinse  global.asax da authorize atributesine aktif hale getirmek kalıyor .loginsiz girişe izin vermiyor
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c=new Context();
        //tablolara ulaşabilmek için context sınıfından bir nesne türettik
        public ActionResult Index( int sayfa=1 )
        {
            //tüm veri tiplerini kapsaması için var türünde değişken oluşturduk
            var degerler=c.kategoris.ToList().ToPagedList(sayfa,4);// BiR SAYFADA LİSETELENCEK ÖGE SAYISI sayfa degerinden başlasın ,bitiş degerinde bitsin

            //teker teker kategori tablosunun içeriklerini degerler değişkenine aktarmak yerine ToList 
            //metodu ile tekte aktarmış olduk.
            return View(degerler);

            //Oradaki return View(); metodu bize o tabloları gördüğümüz sayfayı getiriyor. View in içine değişkeni attığımızda o değişkeni
            //sayfamızda veri olarak kullanabiliyoruz. Bunu yapmak için sayfada da o değişken adında bir model yarattık
            //hatırlayacaksınız @model List<kategori> diye, yani gönderdiğimiz değişken türünde bir model oluşturup gönderdiğimiz o değişkeni web sayfasında kullandık.
        }

        [HttpGet] /*Aksi durumda sayfayı geriye döndür */
        public ActionResult KategoriEkle()
        {


            return View();  
        }

        [HttpPost] /*KategoriEkle viewinin içindeki butona basınca ekleme işlemi gerçekleştir*/
        public ActionResult KategoriEkle(kategori k) //katetori tablo alanından k parametresi yardımmıyla ekeleme işlemi yaparız
        {
            //model yapısı kategori sınıfına bağlı kategori sınıfı da kategoris tablosuna ( Mvc_5TicariOtamasyon.Models.sınıflar.kategori ile kategoriye bağlı oluyor )
            //kategori de k degişkenine bağlanıyor .k değişkenini de c nesnesi le kategoris tablosuna ekleme oluyor.

            c.kategoris.Add(k); //k parametresinden gelecek olan degerleri ekle. k parametresinden gelecek olan degerleri de view ile halldeceğiz
             c.SaveChanges  (); 

            //şu halde null olarak ekler
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg=c.kategoris.Find(id);
            c.kategoris.Remove(ktg);
            c.SaveChanges ();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {

            var kateg=c.kategoris.Find(id); 
            return View("KategoriGetir",kateg); //bana KategoriGetir sayfasını döndür ve bunu kateg değişkenimle beraber yap
        }

        public ActionResult KategoriGuncelle(kategori k)
        {
            //k parametresini  ActionResult KategoriGetir den alacak

            var ktgr =c.kategoris.Find(k.kategoriID);
            ktgr.kategoriAD= k.kategoriAD; //sağ taraf yeni degeri
            c.SaveChanges();
            return RedirectToAction("Index");

           
        }

        public ActionResult casceding()
        {
            Casceding cs = new Casceding(); //sınıftan yeni nesne türettik

            cs.Kategoriler = new SelectList(c.kategoris, "kategoriID", "kategoriAD");
            cs.Urunler = new SelectList(c.uruns, "urunID", "urunAD");

            return View(cs);
        }
        public JsonResult cascedingbagla(int p)
        {

            var urunlistesi=(from x in c.uruns
                             join y in c.kategoris
                             on x.kategori.kategoriID equals y.kategoriID
                             where x.kategori.kategoriID==p
                             select new
                             {
                                 Text=x.urunAD,
                                 Value=x.urunID.ToString()
                             }
                             ).ToList();

            return Json(urunlistesi,JsonRequestBehavior.AllowGet);
        }
    }
}