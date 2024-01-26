using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class satis_hareketi
    {
        [Key]
        public int satisID { get; set; }
        //ÜRÜN
        
        //CARİ

        //PERSONEL

        public DateTime tarih { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal toplamtutar { get; set; }

        //sadece ıcollection yapısınının bağlantılı olduğu karşı sayfada en alttakieri virtual yapıp yerine kendimiz id değerleri sütunu oluşturduk
        public int urunid { get; set; }
        public int  cariid{ get; set; }
        public int personelid { get; set; }

        public  virtual urun urun { get; set; }
        public  virtual cari cari { get; set; }
        public  virtual  personel personel { get; set; }
    }
}