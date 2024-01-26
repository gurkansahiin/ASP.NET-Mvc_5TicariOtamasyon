using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class yapilacak
    {
        [Key]
        public int yapilacakID { get; set; }

        [Column(TypeName = "Varchar")]

        [StringLength(100)]
        public String baslik { get; set; }

        [Column(TypeName = "bit")]

    
        public bool durum { get; set; }

       
    }
}