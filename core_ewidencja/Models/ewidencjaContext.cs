using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace core_ewidencja.Models
{
    public partial class ewidencjaContext : DbContext
    {
        public ewidencjaContext()
        {
        }

        public ewidencjaContext(DbContextOptions<ewidencjaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CzynnosciPojazdy> CzynnosciPojazdy { get; set; }
        public virtual DbSet<TblStats> TblStats { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblWaluty> TblWaluty { get; set; }
        public virtual DbSet<TblZuzycieEnergii> TblZuzycieEnergii { get; set; }
        public virtual DbSet<TblZuzycieGazu> TblZuzycieGazu { get; set; }
        public virtual DbSet<TblZuzycieWody> TblZuzycieWody { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=nasa;user id=nasa;password=nasa;port=000;database=nasa;");
               
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CzynnosciPojazdy>(entity =>
            {
                entity.ToTable("czynnosciPojazdy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPojazdu).HasColumnName("id_pojazdu");

                entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");

                entity.Property(e => e.OpisCzynnosci)
                    .HasColumnName("opis_czynnosci")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Przebieg)
                    .HasColumnName("przebieg")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStats>(entity =>
            {
                entity.ToTable("tblStats");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Counter).HasColumnName("counter");

                entity.Property(e => e.DateVisited)
                    .HasColumnName("date_visited")
                    .HasColumnType("datetime");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasMaxLength(420);

                entity.Property(e => e.VisitHostIp)
                    .HasColumnName("visit_host_ip")
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasColumnType("date");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(900)
                    .IsUnicode(false);

                entity.Property(e => e.TypeUser).HasColumnName("type_user");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(490)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblWaluty>(entity =>
            {
                entity.ToTable("tblWaluty");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AudValue)
                    .HasColumnName("aud_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.BgnValue)
                    .HasColumnName("bgn_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.BrlValue)
                    .HasColumnName("brl_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CadValue)
                    .HasColumnName("cad_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.ChfValue)
                    .HasColumnName("chf_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CnyValue)
                    .HasColumnName("cny_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.CzkValue)
                    .HasColumnName("czk_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.DkkValue)
                    .HasColumnName("dkk_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.GbpValue)
                    .HasColumnName("gbp_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.HkdValue)
                    .HasColumnName("hkd_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.HrkValue)
                    .HasColumnName("hrk_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.HufValue)
                    .HasColumnName("huf_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.IdrValue)
                    .HasColumnName("idr_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.IlsValue)
                    .HasColumnName("ils_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.InrValue)
                    .HasColumnName("inr_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.InsDate)
                    .HasColumnName("ins_date")
                    .HasColumnType("date");

                entity.Property(e => e.IskValue)
                    .HasColumnName("isk_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.JpyValue)
                    .HasColumnName("jpy_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.KrwValue)
                    .HasColumnName("krw_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MxnValue)
                    .HasColumnName("mxn_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.MyrValue)
                    .HasColumnName("myr_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.NokValue)
                    .HasColumnName("nok_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.NzdValue)
                    .HasColumnName("nzd_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.PhpValue)
                    .HasColumnName("php_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.PlnValue)
                    .HasColumnName("pln_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.RonValue)
                    .HasColumnName("ron_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.RubValue)
                    .HasColumnName("rub_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.SekValue)
                    .HasColumnName("sek_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.SgdValue)
                    .HasColumnName("sgd_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.ThbValue)
                    .HasColumnName("thb_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.TryValue)
                    .HasColumnName("try_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.UsdValue)
                    .HasColumnName("usd_value")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.ZarValue)
                    .HasColumnName("zar_value")
                    .HasColumnType("decimal(10, 6)");
            });

            modelBuilder.Entity<TblZuzycieEnergii>(entity =>
            {
                entity.ToTable("tblZuzycieEnergii");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Kwh)
                    .HasColumnName("kwh")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WskLicznika)
                    .HasColumnName("wsk_licznika")
                    .HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<TblZuzycieGazu>(entity =>
            {
                entity.ToTable("tblZuzycieGazu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Kwh)
                    .HasColumnName("kwh")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WskLicznika)
                    .HasColumnName("wsk_licznika")
                    .HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<TblZuzycieWody>(entity =>
            {
                entity.ToTable("tblZuzycieWody");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.WskLicznika)
                    .HasColumnName("wsk_licznika")
                    .HasColumnType("decimal(10, 6)");
            });
        }
    }
}
