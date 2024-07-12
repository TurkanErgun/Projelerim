namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransferBagis
    {
        public int transferBagisID { get; set; }

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

        public int? hastaID { get; set; }

        public int? transferID { get; set; }

        public virtual Hasta Hasta { get; set; }

        public virtual Transfer Transfer { get; set; }
    }
}
