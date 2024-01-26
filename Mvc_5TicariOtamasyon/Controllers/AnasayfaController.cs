using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [AllowAnonymous] //hariç tutuyoruz global.asaxdaki authorizden 

    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.uruns.Where(x=>x.durum==true).ToList();  
            return View(degerler);
        }
    }
}