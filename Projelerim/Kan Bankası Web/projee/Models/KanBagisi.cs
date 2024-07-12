namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KanBagisi")]
    public partial class KanBagisi
    {
        public int kanBagisiID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(11)]
        public string tc { get; set; }

        [StringLength(50)]
        public string cinsiyet { get; set; }

        public int? adet { get; set; }

        [StringLength(50)]
        public string kanGrup { get; set; }

        public int? donorID { get; set; }

        public int? kullaniciID { get; set; }

        public int? kanStoguID { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual KanStogu KanStogu { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
