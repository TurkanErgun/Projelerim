using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace projee.Models
{
    public partial class KanBankasiContext : DbContext
    {
        public KanBankasiContext()
            : base("name=KanBankasiContext")
        {
        }

        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<Hasta> Hasta { get; set; }
        public virtual DbSet<KanBagisi> KanBagisi { get; set; }
        public virtual DbSet<KanStogu> KanStogu { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<TransferBagis> TransferBagis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .Property(e => e.cinsiyet)
                .IsFixedLength();
        }
    }
}
