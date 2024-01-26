using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_5TicariOtamasyon.Models.sınıflar;


namespace Mvc_5TicariOtamasyon.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        public ActionResult Index()
        {
            return View();
        }
    }
}