using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AzAgroPOS.DAL
{
    public class AzAgroDbContext : DbContext
    {
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Tema> Temalar { get; set; }
        public DbSet<Istifadeci> Istifadeciler { get; set; }
        public DbSet<RolIcazesi> RolIcazeleri { get; set; }
        public DbSet<AuditLog> AuditLoglar { get; set; }
        public DbSet<Mehsul> Mehsullar { get; set; }
        public DbSet<MehsulKateqoriyasi> MehsulKateqoriyalari { get; set; }
        public DbSet<Vahid> Vahidler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetali> SatisDetallari { get; set; }
        public DbSet<SatisOdemesi> SatisOdemeleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=azagropos.db");
                optionsBuilder.EnableSensitiveDataLogging(false);
                optionsBuilder.EnableServiceProviderCaching(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Istifadeci>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                
                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.Istifadeciler)
                    .HasForeignKey(e => e.RolId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Tema)
                    .WithMany(t => t.Istifadeciler)
                    .HasForeignKey(e => e.TemaId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<RolIcazesi>(entity =>
            {
                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.RolIcazeleri)
                    .HasForeignKey(e => e.RolId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.RolId, e.Modul, e.Emeliyyat }).IsUnique();
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasOne(e => e.Istifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.IstifadeciId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.Tarix);
                entity.HasIndex(e => e.IstifadeciId);
            });

            modelBuilder.Entity<Mehsul>(entity =>
            {
                entity.HasIndex(e => e.Barkod).IsUnique();
                entity.HasIndex(e => e.SKU).IsUnique();
                entity.HasIndex(e => e.Ad);
                entity.HasIndex(e => e.KateqoriyaId);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.Kateqoriya)
                    .WithMany(k => k.Mehsullar)
                    .HasForeignKey(e => e.KateqoriyaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Vahid)
                    .WithMany(v => v.Mehsullar)
                    .HasForeignKey(e => e.VahidId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MehsulKateqoriyasi>(entity =>
            {
                entity.HasIndex(e => e.Ad);
                entity.HasIndex(e => e.Kod).IsUnique();
                entity.HasIndex(e => e.UstKateqoriyaId);

                entity.HasOne(e => e.UstKateqoriya)
                    .WithMany(k => k.AltKateqoriyalar)
                    .HasForeignKey(e => e.UstKateqoriyaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Vahid>(entity =>
            {
                entity.HasIndex(e => e.Ad);
                entity.HasIndex(e => e.QisaAd).IsUnique();
                entity.HasIndex(e => e.AnaVahidId);

                entity.HasOne(e => e.AnaVahid)
                    .WithMany(v => v.AltVahidler)
                    .HasForeignKey(e => e.AnaVahidId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Satis>(entity =>
            {
                entity.HasIndex(e => e.SatisNomresi).IsUnique();
                entity.HasIndex(e => e.SatisTarixi);
                entity.HasIndex(e => e.KassirId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.OdemeNovu);

                entity.HasOne(e => e.Kassir)
                    .WithMany()
                    .HasForeignKey(e => e.KassirId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SatisDetali>(entity =>
            {
                entity.HasIndex(e => e.SatisId);
                entity.HasIndex(e => e.MehsulId);

                entity.HasOne(e => e.Satis)
                    .WithMany(s => s.SatisDetallari)
                    .HasForeignKey(e => e.SatisId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SatisOdemesi>(entity =>
            {
                entity.HasIndex(e => e.SatisId);
                entity.HasIndex(e => e.OdemeTarixi);
                entity.HasIndex(e => e.OdemeNovu);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.Satis)
                    .WithMany(s => s.SatisOdemeleri)
                    .HasForeignKey(e => e.SatisId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed data-nı DatabaseInitializationService-də edirik
        }
    }
}