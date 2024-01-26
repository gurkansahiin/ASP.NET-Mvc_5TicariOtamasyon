using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;

namespace Mvc_5TicariOtamasyon.Controllers
{
    [Authorize]
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.uruns.ToList();
            return View(degerler);
        }
    }
}