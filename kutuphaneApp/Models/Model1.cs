namespace kutuphaneApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

       
        public virtual DbSet<tb_kitap_odunc> tb_kitap_odunc { get; set; }
        public virtual DbSet<tb_kitaplar> tb_kitaplar { get; set; }
        public virtual DbSet<tb_kullanıcılar> tb_kullanıcılar { get; set; }
        public virtual DbSet<tb_turler> tb_turler { get; set; }
        public virtual DbSet<tb_uyeler> tb_uyeler { get; set; }
        public virtual DbSet<tb_yayin_evleri> tb_yayin_evleri { get; set; }
        public virtual DbSet<tb_yazarlar> tb_yazarlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_kitaplar>()
                .HasMany(e => e.tb_kitap_odunc)
                .WithOptional(e => e.tb_kitaplar)
                .HasForeignKey(e => e.kitap_id);

            modelBuilder.Entity<tb_kullanıcılar>()
                .HasMany(e => e.tb_kitap_odunc)
                .WithOptional(e => e.tb_kullanıcılar)
                .HasForeignKey(e => e.kullanici_id);

            modelBuilder.Entity<tb_turler>()
                .HasMany(e => e.tb_kitaplar)
                .WithOptional(e => e.tb_turler)
                .HasForeignKey(e => e.tur_id);

            modelBuilder.Entity<tb_uyeler>()
                .HasMany(e => e.tb_kitap_odunc)
                .WithOptional(e => e.tb_uyeler)
                .HasForeignKey(e => e.uye_id);

            modelBuilder.Entity<tb_yayin_evleri>()
                .HasMany(e => e.tb_kitaplar)
                .WithOptional(e => e.tb_yayin_evleri)
                .HasForeignKey(e => e.yayin_evi_id);

            modelBuilder.Entity<tb_yazarlar>()
                .HasMany(e => e.tb_kitaplar)
                .WithOptional(e => e.tb_yazarlar)
                .HasForeignKey(e => e.yazar_id);
        }
    }
}
