using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class faturalar
    {
        [Key]

        public int faturaID { get; set;}

        [Column(TypeName = "Varchar")]

        [StringLength(6)]
        public string faturaSıraNo { get; set;}

        [Column(TypeName = "Char")]

        [StringLength(1)]
        public string faturaSeriNo { get; set;}

        [Column(TypeName = "Varchar")]

        [StringLength(60)]
        public string vergiDairesi { get; set;}

        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public string teslimEden { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(30)]
        public string teslimAlan { get; set; }
        public DateTime faturaTarih { get; set; }
        [Column(TypeName = "char")]

        [StringLength(5)]
        public string saat { get; set; }
        public decimal toplam { get; set; }

        //bir faturanın birden fazla kategorisi olabilir
        public ICollection<faturaKalem> faturaKalems { get; set; }
    }
}