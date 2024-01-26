using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class faturaKalem
    {
        [Key]
        public int faturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public string aciklama { get; set; }
        public int miktar { get; set; }
        public decimal birimFiyat { get; set; }
        public decimal tutar { get; set; }

        //bir fatura kaleminin de sadece bir tane faturası olabilir

        public int faturaid { get; set; }
        public virtual faturalar faturalar { get; set; }
    }
}