namespace kutuphaneApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_uyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_uyeler()
        {
            tb_kitap_odunc = new HashSet<tb_kitap_odunc>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string ad_soyad { get; set; }

        [StringLength(50)]
        public string adres { get; set; }

        [StringLength(20)]
        public string telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_kitap_odunc> tb_kitap_odunc { get; set; }
    }
}
