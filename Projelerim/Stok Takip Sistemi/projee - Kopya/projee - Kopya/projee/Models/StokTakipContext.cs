using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace projee.Models
{
    public partial class StokTakipContext : DbContext
    {
        public StokTakipContext()
            : base("name=StokTakipContext")
        {
        }

        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .Property(e => e.cinsiyet)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.cinsiyet)
                .IsFixedLength();
        }
    }
}
