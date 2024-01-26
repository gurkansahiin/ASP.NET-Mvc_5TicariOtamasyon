using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;
namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class GrafikController : Controller
    {
        // GET: Grafik

        //aşağıdakiler biraz küt kalıyor daha kaliteli Chartlar kullnamak için paket yönetici Konsolundan
        //    Newtonsoft.Json eklentisini kur
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafik = new Chart(600, 600);
            grafik.AddTitle(text: "Kategori-Ürün Stok Sayısı");
            grafik.AddLegend(title: "Stok");
            grafik.AddSeries(
                name: "Değerler",
                xValue: new[] { "Beyaz Eşya", "Televizyon", "Bilgisayar" },
                yValues: new[] { 85, 65, 98 }

                ).Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuc = c.uruns.ToList();
            sonuc.ToList().ForEach(x => xvalue.Add(x.urunAD));
            sonuc.ToList().ForEach(y => yvalue.Add(y.stock));

            var grafik = new Chart(600, 600);
            grafik.AddTitle(text: "Ürün/Stok İlişkisi");
            grafik.AddLegend(title: "Stok Sayısı");

            grafik.AddSeries(
                chartType: "Pie",
                name: "Stok Verileri",
                xValue: xvalue,
                yValues: yvalue

                ).Write();
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }
        public PartialViewResult deneme()
        {

            return PartialView();
        }
        //google chartlardaki görselleştirmeye ulaşabilmek için
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        //--------------DİNAMİK OLMAYAN KULLANIM ŞEKLE ELLE VERİLERİ GİRMEK
        public List<sinifgooglechart> Urunlistesi()
        {
            List<sinifgooglechart> nesne = new List<sinifgooglechart>();
            nesne.Add(new sinifgooglechart()
            {
                urunad = "Bilgisayar",
                stock = 120

            });

            nesne.Add(new sinifgooglechart()
            {
                urunad = "Telefon",
                stock = 80
            });

            nesne.Add(new sinifgooglechart()
            {
                urunad = "Kulaklık",
                stock = 60
            });

            nesne.Add(new sinifgooglechart()
            {
                urunad = "Beyaz Eşya",
                stock = 150
            });

            return nesne;
        }


        //-----DİNAMİK OLARAK VT DAN VERİ ÇEKME 

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {

            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<dinamikchart> Urunlistesi2()
        {
            List<dinamikchart> nesne= new List<dinamikchart>(); 
            using(var c=new Context())
            {
                nesne = c.uruns.Select(x => new dinamikchart()
                {
                    urnad=x.urunAD,
                    stk=x.stock
                }).ToList();
            }

            return nesne;
        }


        public PartialViewResult kategoriurun()
        {
            var sonuc1 = c.caris.ToList();

            // Verileri JavaScript tarafına taşı
            ViewBag.ChartData = sonuc1.GroupBy(x=>x.cariSehir).Select(group => new {sehir=group.Key ,adet=group.Count()}).ToList();

            return PartialView();
        }


        public PartialViewResult kategoriurun2()
        {
            var urunler = c.uruns.ToList();
            var kategoriler = c.kategoris.ToList();

            // Verileri JavaScript tarafına taşı
            var chartData = kategoriler
                .Select(kategori => new
                {
                    kateg = kategori.kategoriAD,
                    urun = urunler.Count(u => u.kategoriID == kategori.kategoriID)
                })
                .ToList();

            ViewBag.ChartData = chartData;


            return PartialView();
        }


        public ActionResult ColumnGrafik()
        {
            return View();
        }

        public ActionResult AreaGrafik()
        {
            return View();
        }



    }
}