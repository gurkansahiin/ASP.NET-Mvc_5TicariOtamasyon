using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class mesajlar
    {
        [Key]
        public int mesajID { get; set; }

        [Column (TypeName = "Varchar")]
        [StringLength (50)]
        public String gönderici { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String alici { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public String konu { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public String icerik { get; set; }



        [Column(TypeName = "Smalldatetime")]

        public DateTime tarih { get; set; }

        public bool durum { get; set; }

    }
}