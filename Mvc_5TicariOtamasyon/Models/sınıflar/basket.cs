using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class basket
    {
        [Key]
        public int basketid { get; set; }
        public int urunid { get; set; }
        public int adet { get; set; }

        public string cari { get; set; }
        public decimal maaliyet { get; set; }

        public DateTime tarih { get; set; }
        public virtual urun urun { get; set; }





    }
}