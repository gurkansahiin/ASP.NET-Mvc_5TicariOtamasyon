using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class detay
    {
        [Key]
        public int detayid { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public string urunad { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(2000)]
        public string bilgi { get; set; }
    }
}