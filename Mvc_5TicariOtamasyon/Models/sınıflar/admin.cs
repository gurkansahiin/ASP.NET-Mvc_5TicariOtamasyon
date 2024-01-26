using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class admin
    {
        [Key]

        public int adminID { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(10)]
        public string KullaniciAd { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(10)]
        public string sifre { get; set; }
        [Column(TypeName = "Char")]

        [StringLength(1)]
        public string yetki { get; set; }
    }
}