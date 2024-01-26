using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class Class1
    {
        public IEnumerable<urun> Deger1 { get; set; }
        public IEnumerable<detay> Deger2 { get; set; } //deger1  ve deger2 ilişkili classlarındaki degerleri tutan koleksiyon görevi görüyor
    }
}