namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donor")]
    public partial class Donor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donor()
        {
            KanBagisi = new HashSet<KanBagisi>();
        }

        public int donorID { get; set; }

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

        [StringLength(90)]
        public string adres { get; set; }

        [StringLength(50)]
        public string kanGrup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KanBagisi> KanBagisi { get; set; }
    }
}
