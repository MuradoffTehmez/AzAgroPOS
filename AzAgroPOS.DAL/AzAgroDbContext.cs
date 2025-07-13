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

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var baseDate = new DateTime(2025, 1, 1);

            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Ad = "Administrator", Aciklama = "Sistem administratoru", Status = "Aktiv", YaradilmaTarixi = baseDate },
                new Rol { Id = 2, Ad = "İstifadəçi", Aciklama = "Adi istifadəçi", Status = "Aktiv", YaradilmaTarixi = baseDate }
            );

            modelBuilder.Entity<Tema>().HasData(
                new Tema { Id = 1, Ad = "Açıq Tema", ArxaplanRengi = "#FFFFFF", MetinRengi = "#000000", Status = "Aktiv", YaradilmaTarixi = baseDate },
                new Tema { Id = 2, Ad = "Qaranlıq Tema", ArxaplanRengi = "#2C2C2C", MetinRengi = "#FFFFFF", Status = "Aktiv", YaradilmaTarixi = baseDate }
            );
        }
    }
}