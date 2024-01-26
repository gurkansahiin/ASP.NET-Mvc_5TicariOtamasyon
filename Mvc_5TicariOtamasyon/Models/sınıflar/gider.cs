using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class gider
    {
        [Key]
        public int giderID { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string Aciklama { get; set; }
        public decimal tutar { get; set; }
        public DateTime tarih { get; set; }

    }
}