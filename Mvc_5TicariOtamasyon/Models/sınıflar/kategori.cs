using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class kategori
    {
        [Key]
        public int kategoriID { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public string kategoriAD { get; set; }

        public ICollection< urun> uruns { get; set; }

      
        //her kategoiri de birden fazla urun  yer alabilir ve dbsm de uruns tablosu adıyla oluşacak


    }
}