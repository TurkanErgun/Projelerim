namespace projee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KanStogu")]
    public partial class KanStogu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KanStogu()
        {
            KanBagisi = new HashSet<KanBagisi>();
        }

        public int kanStoguID { get; set; }

        [StringLength(50)]
        public string kanGrup { get; set; }

        public int? kanStok { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KanBagisi> KanBagisi { get; set; }
    }
}
