namespace kutuphaneApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_kitaplar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_kitaplar()
        {
            tb_kitap_odunc = new HashSet<tb_kitap_odunc>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string isbn_no { get; set; }

        [StringLength(50)]
        public string adi { get; set; }

        public int? basim_yili { get; set; }

        public int? sayfa_sayisi { get; set; }

        public int? yayin_evi_id { get; set; }

        public int? yazar_id { get; set; }

        public int? tur_id { get; set; }

        public bool? durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_kitap_odunc> tb_kitap_odunc { get; set; }

        public virtual tb_turler tb_turler { get; set; }

        public virtual tb_yayin_evleri tb_yayin_evleri { get; set; }

        public virtual tb_yazarlar tb_yazarlar { get; set; }
    }
}
