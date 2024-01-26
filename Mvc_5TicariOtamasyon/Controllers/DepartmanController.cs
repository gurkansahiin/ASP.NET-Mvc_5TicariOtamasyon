using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize] //böyllikle her actionun üzerine eklemeye gerek kalmadı
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c=new Context();
      
        public ActionResult Index()
        {
            var degerler=c.departmans.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }

        //Yetkilendirme beşinci adım  roller  klasörünün içndeki sınıfta yer alıyor diğer adımlar 
        [Authorize(Roles ="A")] //Yetkisi A olan sadece bu kısma giriş yapabilsin
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(departman d)
        {
            c.departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.departmans.Find(id);
            dep.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var depgtr = c.departmans.Find(id);
            return View("DepartmanGetir", depgtr);

            


        }

        public ActionResult DepartmanGuncelle(departman d)
        {
            var depart = c.departmans.Find(d.departmanID);
            depart.departmanAD = d.departmanAD;
            c.SaveChanges();    
            return RedirectToAction("Index");




        }

        public ActionResult DepartmanDetay(int id)
        {
            var pers=c.personels.Where(x=>x.departmanid==id).ToList();
            var dep=c.departmans.Where(x=>x.departmanID==id).Select(y=>y.departmanAD).FirstOrDefault();//sadece tek değeri taşıma işlemlerinde kullanılır
            ViewBag.d = dep;//controller tarafından çektiğimiz veriyi view sayfasına taşır
            return View("DepartmanDetay", pers);




        }

        public ActionResult DepartmanPersonelSatis(int id)

        {
            var degerler=c.satis_Hareketis.Where(x=>x.personelid==id).ToList();
            var dps=c.personels.Where(x=>x.PersonelID==id).Select(y=>y.PersonelAd +" "+  y.PersonelSoyAD).FirstOrDefault();
            ViewBag.dpersonel=dps;
            return View(degerler);

        }

        public ActionResult DepartmanPersSatisYazdır(int id)
        {
            var degerler = c.satis_Hareketis.Where(x => x.satisID == id).ToList();
            return View(degerler);
        }
    }
}