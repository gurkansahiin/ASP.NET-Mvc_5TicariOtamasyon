using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class urun
    {
        [Key]
        public int urunID { get; set; }

        [Column(TypeName ="Varchar")]

        [StringLength(30)]

        public string urunAD { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public string marka { get; set; }
        public short stock { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool durum { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(250)]
        public string urungörsel { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(3000)]

        public string urunAciklama { get; set; }


        [Column(TypeName = "Varchar")]

        [StringLength(5000)]

        public string urunOzellikler { get; set; }

        //bir ürünün sadece bir kategorisi olur
        public int kategoriID { get; set; }
        public virtual kategori kategori { get; set; }
        //kategori sınıfından kategori adlı bir deger aldı

        public ICollection<satis_hareketi> satis_hareketis { get; set; }
        public ICollection<basket> baskets { get; set; }
        

     
    }
}