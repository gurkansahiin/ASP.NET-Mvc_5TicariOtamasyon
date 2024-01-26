using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Mvc_5TicariOtamasyon.Models.sınıflar
{
    public class Context: DbContext
    {
        public DbSet<admin> admins { get; set; }
        public DbSet<cari> caris { get; set; }
        public DbSet<departman> departmans { get; set; }
        public DbSet<faturaKalem> faturaKalems { get; set; }
        public DbSet<faturalar> faturalars { get; set; }
        public DbSet<personel> personels { get; set; }
        public DbSet<gider> giders { get; set; }
        public DbSet<kategori> kategoris { get; set; }
        public DbSet<satis_hareketi> satis_Hareketis { get; set; }
        public DbSet<urun> uruns  { get; set; }
        public DbSet<detay> detays  { get; set; }
        public DbSet<yapilacak> yapilacaks  { get; set; }
        public DbSet<KargoDetay> kargoDetays  { get; set; }
        public DbSet<KargoTakip> kargoTakips  { get; set; }
        public DbSet<mesajlar> mesajlars  { get; set; }
        public DbSet<basket> baskets  { get; set; }

    }
}