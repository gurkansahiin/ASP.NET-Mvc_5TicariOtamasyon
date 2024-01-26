using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;
namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.personels.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAD,
                                               Value = x.departmanID.ToString()
                                           }
                                       ).ToList();

            //deger1 i nasıl  Viewe taşıyacağız ?

            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(personel p)
        {

            if (Request.Files.Count>0) //yaptığım isteklerim içinde dosya tutuyorsam
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //hafızada (istekte) tutmuş olduğum dosyanın, dosya yolundaki  dosya adı kısmını al
                string uzanti = Path.GetExtension(Request.Files[0].FileName); //Extension=uzantı
                string yol = "~/image/" + dosyaadi + uzanti; //nereye kaydedecek bu dosyayı burada kaydediceğimiz yolu belirlemş olduk
                Request.Files[0].SaveAs(Server.MapPath(yol)); //işaretlenmiş yoldaki yol adlı yere kaydet
                p.personelgörsel = "/image/"+dosyaadi+ uzanti;


            }
            c.personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()

                                               //burda ir ögeyi seç.seçmil olduğum ögenin bir bize görünen yüzü olan text kısmı olacak bir de arka planda köprü görev görecek value kısmı olacak
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAD,
                                               Value = x.departmanID.ToString()
                                           }
                               ).ToList();

            //deger1 i nasıl  Viewe taşıyacağız ?

            ViewBag.dgr2 = deger1;
            var pers = c.personels.Find(id);
            return View("PersonelGetir", pers);


        }

        public ActionResult PersonelGuncelle(personel p)
        {
            var pers = c.personels.Find(p.PersonelID);
            pers.PersonelAd = p.PersonelAd;
            pers.PersonelSoyAD = p.PersonelSoyAD;
            pers.personelgörsel = p.personelgörsel;
            pers.PersonelSehir = p.PersonelSehir;
            pers.PersonelTel = p.PersonelTel;
            pers.departmanid = p.departmanid;

            string dosyaadi = Path.GetFileName(Request.Files[0].FileName); //hafızada (istekte) tutmuş olduğum dosyanın, dosya yolundaki  dosya adı kısmını al
            string uzanti = Path.GetExtension(Request.Files[0].FileName); //Extension=uzantı
            string yol = "~/image/" + dosyaadi + uzanti; //nereye kaydedecek bu dosyayı burada kaydediceğimiz yolu belirlemş olduk
            Request.Files[0].SaveAs(Server.MapPath(yol)); //işaretlenmiş yoldaki yol adlı yere kaydet
            pers.personelgörsel = "/image/" + dosyaadi + uzanti;
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        { 
            var sorgu=c.personels.ToList();
            return View(sorgu); 
        }
    }
}