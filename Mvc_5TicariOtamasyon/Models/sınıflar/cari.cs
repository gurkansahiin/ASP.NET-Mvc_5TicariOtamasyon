using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class cari
    {
        [Key]
        public int cariID { get; set; }
        [Column(TypeName = "Varchar")]

        [Display(Name = "Ad:")]

        [StringLength(30,ErrorMessage ="En fazla 30 karakter girebilirsiniz")]
        public string cariAd { get; set;}

        [Display(Name = "Soyad:")]
        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string cariSoyad { get; set;}

        [Display(Name = "Şehir:")]
        [Column(TypeName = "Varchar")]

        [StringLength(13)]

        public string cariSehir { get; set; }
        [Display(Name = "Mail:")]
        [Column(TypeName = "Varchar")]

        public string carimeslek { get; set; }
        [Display(Name = "Meslek:")]
        [Column(TypeName = "Varchar")]

        public string caritel { get; set; }
        [Display(Name = "Telefon:")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string cariMail { get; set; }

        [Display(Name = "Şifre:")]
        [Column(TypeName = "Varchar")]

        [StringLength(20)]
        public string cariSifre { get; set; }
        public bool durum { get; set; }

        public ICollection<satis_hareketi> satis_Hareketis { get; set; }

        //her cari birden birden fazla satış hareketi içerebilir
    }
}