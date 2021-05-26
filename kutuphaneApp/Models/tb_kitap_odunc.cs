namespace kutuphaneApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_kitap_odunc
    {
        public int id { get; set; }

        public int? uye_id { get; set; }

        public int? kitap_id { get; set; }

        public int? kullanici_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? baslangic_tarih { get; set; }

        [Column(TypeName = "date")]
        public DateTime? bitis_tarih { get; set; }

        public virtual tb_kitaplar tb_kitaplar { get; set; }

        public virtual tb_kullanıcılar tb_kullanıcılar { get; set; }

        public virtual tb_uyeler tb_uyeler { get; set; }
    }
}
