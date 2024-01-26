    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

    namespace Mvc_5TicariOtamasyon.Models.sınıflar
    {
        public class departman
        {
            [Key]
            public int departmanID { get; set; }
        [Column(TypeName = "Varchar")]

        [StringLength(30)]


        public string departmanAD { get; set; }
        public bool durum { get; set; }

        //her personelin birden fazla departmanı olabilir

        public ICollection<personel> personels { get; set; }
    }
    }