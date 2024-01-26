using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string aciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKod { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string personel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string alici { get; set; }
        public DateTime tarih { get; set; }
    }
}