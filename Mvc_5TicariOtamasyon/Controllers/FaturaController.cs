using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;


namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.faturalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(faturalar f)
        {
            c.faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.faturalars.Find(id);
            return View(ftr);
        }
        public ActionResult FaturaGuncelle(faturalar f)
        {
            var fatura = c.faturalars.Find(f.faturaID);
            fatura.faturaSıraNo = f.faturaSıraNo;
            fatura.faturaSeriNo = f.faturaSeriNo;
            fatura.vergiDairesi = f.vergiDairesi;
            fatura.teslimEden = f.teslimEden;
            fatura.teslimAlan = f.teslimAlan;
            fatura.faturaTarih = f.faturaTarih;
            fatura.saat = f.saat;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var değerler = c.faturaKalems.Where(x => x.faturaid == id).ToList();



            return View(değerler);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle(int faturaID)
        {
            ViewBag.FaturaID = faturaID;

            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(faturaKalem f)
        {

            c.faturaKalems.Add(f);

            c.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {

            faturadinamik cs= new faturadinamik();  
            cs.deger1=c.faturalars.OrderByDescending(y=>y.faturaID).ToList();
            cs.deger2=c.faturaKalems.ToList();
            return View(cs);
        }

        public ActionResult FaturaKaydet(string faturaSeriNo, string faturaSıraNo,DateTime faturaTarih,string vergiDairesi,
            string saat,string teslimEden,string teslimAlan,string toplam, faturaKalem[] kalemler
            )

        {
         faturalar f=new faturalar();
            f.faturaSeriNo=faturaSeriNo;
            f.faturaSıraNo = faturaSıraNo;
            f.faturaTarih=faturaTarih;
            f.vergiDairesi=vergiDairesi;    
            f.saat=saat;
            f.teslimAlan=teslimAlan;
            f.teslimEden=teslimEden;
            f.toplam =decimal.Parse( toplam);

            foreach (var x in kalemler)
            {
                faturaKalem fk = new faturaKalem();
                fk.aciklama=x.aciklama; 
                fk.faturaid=x.faturaid;
                fk.birimFiyat=x.birimFiyat;
                fk.miktar=x.miktar;
                fk.tutar=x.tutar;

                c.faturaKalems.Add( fk );
            }

            c.faturalars.Add(f);
            c.SaveChanges   ();
            
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }

    }
}