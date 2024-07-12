namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Satis
    {
        public int satisID { get; set; }

        public int? urunID { get; set; }

        public int? adet { get; set; }

        public decimal? fiyat { get; set; }

        public DateTime? tarih { get; set; }

        public int? kullaniciID { get; set; }

        public int? musteriID { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
