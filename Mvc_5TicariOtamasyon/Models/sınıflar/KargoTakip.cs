using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
    }
}