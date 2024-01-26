using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public String PersonelAd { get; set; }


        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public String PersonelSoyAD { get; set; }

        [Display(Name = "Personel Görseli ")]
        [Column(TypeName = "Varchar")]

        [StringLength(250)]

        public String personelgörsel { get; set; }

        [Display(Name = "Personel Şehri")]
        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public String PersonelSehir { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Column(TypeName = "Varchar")]

        [StringLength(11)]
        public String PersonelTel { get; set; }
        public ICollection<satis_hareketi> satis_Hareketis { get; set; }

        //her personel birden fazla satış hareketi içerebilir.

        public int departmanid { get; set; }
        [Display(Name = "Departmanı")]
        public virtual departman departman { get; set; }


    }
}