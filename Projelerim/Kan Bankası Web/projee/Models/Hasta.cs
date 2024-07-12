namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hasta")]
    public partial class Hasta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hasta()
        {
            TransferBagis = new HashSet<TransferBagis>();
        }

        public int hastaID { get; set; }

        [StringLength(50)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(11)]
        public string tc { get; set; }

        [StringLength(50)]
        public string cinsiyet { get; set; }

        [StringLength(50)]
        public string yas { get; set; }

        [StringLength(11)]
        public string tel { get; set; }

        [StringLength(50)]
        public string adres { get; set; }

        [StringLength(50)]
        public string kanGrup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferBagis> TransferBagis { get; set; }
    }
}
