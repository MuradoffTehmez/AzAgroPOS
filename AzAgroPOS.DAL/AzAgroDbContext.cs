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
        
        // Procurement Module
        public DbSet<Tedarukcu> Tedarukciler { get; set; }
        public DbSet<AlisOrder> AlisOrderleri { get; set; }
        public DbSet<AlisOrderDetali> AlisOrderDetallari { get; set; }
        public DbSet<AlisSeined> AlisSenedleri { get; set; }
        public DbSet<AlisSenedDetali> AlisSenedDetallari { get; set; }
        public DbSet<TedarukcuOdeme> TedarukcuOdemeleri { get; set; }
        
        // Warehouse Module
        public DbSet<Anbar> Anbarlar { get; set; }
        public DbSet<AnbarQalik> AnbarQaliqları { get; set; }
        public DbSet<AnbarHereketi> AnbarHereketleri { get; set; }
        public DbSet<AnbarTransfer> AnbarTransferleri { get; set; }
        public DbSet<AnbarTransferDetali> AnbarTransferDetallari { get; set; }
        
        // Debt/Credit Module
        public DbSet<MusteriBorc> MusteriBorcları { get; set; }
        public DbSet<BorcOdenis> BorcOdenisleri { get; set; }
        
        // Repair/Service Module
        public DbSet<TamirIsi> TamirIsleri { get; set; }
        public DbSet<TamirMerhele> TamirMerheleri { get; set; }


        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<MusteriQrupu> MusteriQruplari { get; set; }
        
        // Employee Module
        public DbSet<Isci> Isciler { get; set; }
        public DbSet<NovbeKaydi> NovbeKayitlari { get; set; }
        public DbSet<IsciPerformans> IsciPerformans { get; set; }
        
        // Shift Management Module
        public DbSet<NovbeCedveli> NovbeCedvelleri { get; set; }
        public DbSet<NovbeDetali> NovbeDetallari { get; set; }
        public DbSet<IsciIzni> IsciIzinleri { get; set; }
        
        // Expense Module
        public DbSet<Gider> Giderler { get; set; }
        
        // System Settings Module
        public DbSet<SistemAyarlari> SistemAyarlari { get; set; }
        
        // Backup Module
        public DbSet<BackupKaydi> BackupKayitlari { get; set; }
        public DbSet<BackupTenzimleme> BackupTenzimlemeleri { get; set; }
        
        // Notification Module
        public DbSet<Bildiris> Bildirisler { get; set; }
        public DbSet<BildirisAyari> BildirisAyarlari { get; set; }
        
        // Printer Module
        public DbSet<PrinterKonfiqurasiyasi> PrinterKonfiqurasiyas { get; set; }
        public DbSet<PrintSablonu> PrintSablonlari { get; set; }
        public DbSet<PrintLogKaydi> PrintLogKayitlari { get; set; }
        
        // Reports Module
        public DbSet<SatisHesabati> SatisHesabatlari { get; set; }

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

            // Procurement Module Configurations
            modelBuilder.Entity<Tedarukcu>(entity =>
            {
                entity.HasIndex(e => e.Kod).IsUnique();
                entity.HasIndex(e => e.Ad);
                entity.HasIndex(e => e.VOEN);
                entity.HasIndex(e => e.Status);
            });

            modelBuilder.Entity<AlisOrder>(entity =>
            {
                entity.HasIndex(e => e.OrderNomresi).IsUnique();
                entity.HasIndex(e => e.OrderTarixi);
                entity.HasIndex(e => e.TedarukcuId);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.Tedarukcu)
                    .WithMany(t => t.AlisOrderleri)
                    .HasForeignKey(e => e.TedarukcuId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.YaradanIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.YaradanIstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.TesdiqleyenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.TesdiqleyenIstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AlisOrderDetali>(entity =>
            {
                entity.HasIndex(e => e.AlisOrderId);
                entity.HasIndex(e => e.MehsulId);

                entity.HasOne(e => e.AlisOrder)
                    .WithMany(ao => ao.OrderDetallari)
                    .HasForeignKey(e => e.AlisOrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AlisSeined>(entity =>
            {
                entity.HasIndex(e => e.SenedNomresi).IsUnique();
                entity.HasIndex(e => e.SenedTarixi);
                entity.HasIndex(e => e.TedarukcuId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.OdemeStatus);

                entity.HasOne(e => e.Tedarukcu)
                    .WithMany(t => t.AlisSenedleri)
                    .HasForeignKey(e => e.TedarukcuId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AlisOrder)
                    .WithMany()
                    .HasForeignKey(e => e.AlisOrderId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Anbar)
                    .WithMany()
                    .HasForeignKey(e => e.AnbarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AlisSenedDetali>(entity =>
            {
                entity.HasIndex(e => e.AlisSenedId);
                entity.HasIndex(e => e.MehsulId);

                entity.HasOne(e => e.AlisSeined)
                    .WithMany(as1 => as1.SenedDetallari)
                    .HasForeignKey(e => e.AlisSenedId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TedarukcuOdeme>(entity =>
            {
                entity.HasIndex(e => e.OdemeNomresi).IsUnique();
                entity.HasIndex(e => e.OdemeTarixi);
                entity.HasIndex(e => e.TedarukcuId);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.Tedarukcu)
                    .WithMany(t => t.Odemeler)
                    .HasForeignKey(e => e.TedarukcuId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AlisSeined)
                    .WithMany(as1 => as1.Odemeler)
                    .HasForeignKey(e => e.AlisSenedId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Warehouse Module Configurations
            modelBuilder.Entity<Anbar>(entity =>
            {
                entity.HasIndex(e => e.Kod).IsUnique();
                entity.HasIndex(e => e.Ad);
                entity.HasIndex(e => e.Status);
            });

            modelBuilder.Entity<AnbarQalik>(entity =>
            {
                entity.HasIndex(e => new { e.AnbarId, e.MehsulId }).IsUnique();
                entity.HasIndex(e => e.AnbarId);
                entity.HasIndex(e => e.MehsulId);

                entity.HasOne(e => e.Anbar)
                    .WithMany(a => a.AnbarQaliqları)
                    .HasForeignKey(e => e.AnbarId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AnbarHereketi>(entity =>
            {
                entity.HasIndex(e => e.HereketTarixi);
                entity.HasIndex(e => e.AnbarId);
                entity.HasIndex(e => e.MehsulId);
                entity.HasIndex(e => e.HereketTipi);
                entity.HasIndex(e => e.SenedNomresi);

                entity.HasOne(e => e.Anbar)
                    .WithMany(a => a.AnbarHereketleri)
                    .HasForeignKey(e => e.AnbarId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Istifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.IstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AnbarTransfer>(entity =>
            {
                entity.HasIndex(e => e.TransferNomresi).IsUnique();
                entity.HasIndex(e => e.TransferTarixi);
                entity.HasIndex(e => e.MenbAnbarId);
                entity.HasIndex(e => e.HedefAnbarId);
                entity.HasIndex(e => e.Status);

                entity.HasOne(e => e.MenbAnbar)
                    .WithMany(a => a.GidenTransferler)
                    .HasForeignKey(e => e.MenbAnbarId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.HedefAnbar)
                    .WithMany(a => a.GelenTransferler)
                    .HasForeignKey(e => e.HedefAnbarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AnbarTransferDetali>(entity =>
            {
                entity.HasIndex(e => e.AnbarTransferId);
                entity.HasIndex(e => e.MehsulId);

                entity.HasOne(e => e.AnbarTransfer)
                    .WithMany(at => at.TransferDetallari)
                    .HasForeignKey(e => e.AnbarTransferId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Mehsul)
                    .WithMany()
                    .HasForeignKey(e => e.MehsulId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Debt/Credit Module Configurations
            modelBuilder.Entity<MusteriBorc>(entity =>
            {
                entity.HasIndex(e => e.BorcNomresi).IsUnique();
                entity.HasIndex(e => e.BorcTarixi);
                entity.HasIndex(e => e.MusteriId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.SonOdemeTarixi);

                entity.HasOne(e => e.Musteri)
                    .WithMany()
                    .HasForeignKey(e => e.MusteriId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Satis)
                    .WithMany()
                    .HasForeignKey(e => e.SatisId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.YaradanIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.YaradanIstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BorcOdenis>(entity =>
            {
                entity.HasIndex(e => e.OdenisNomresi).IsUnique();
                entity.HasIndex(e => e.OdenisTarixi);
                entity.HasIndex(e => e.MusteriBorcId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.OdenisTipi);

                entity.HasOne(e => e.MusteriBorc)
                    .WithMany(mb => mb.BorcOdenisleri)
                    .HasForeignKey(e => e.MusteriBorcId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.QebulEdenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.QebulEdenIstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Repair/Service Module Configurations
            modelBuilder.Entity<TamirIsi>(entity =>
            {
                entity.HasIndex(e => e.TamirNomresi).IsUnique();
                entity.HasIndex(e => e.QebulTarixi);
                entity.HasIndex(e => e.MusteriId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.Prioritet);

                entity.HasOne(e => e.Musteri)
                    .WithMany()
                    .HasForeignKey(e => e.MusteriId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.QebulEdenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.QebulEdenIstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.TeyinEdilenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.TeyinEdilenIstifadeciId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.TehvilEdenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.TehvilEdenIstifadeciId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TamirMerhele>(entity =>
            {
                entity.HasIndex(e => e.TamirIsiId);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.Sira);

                entity.HasOne(e => e.TamirIsi)
                    .WithMany(ti => ti.TamirMerheleri)
                    .HasForeignKey(e => e.TamirIsiId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TeyinEdilenIstifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.TeyinEdilenIstifadeciId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Expense Module Configurations
            modelBuilder.Entity<Gider>(entity =>
            {
                entity.HasIndex(e => e.Tarix);
                entity.HasIndex(e => e.Kateqoriya);
                entity.HasIndex(e => e.IstifadeciId);
                entity.HasIndex(e => e.TesdiqEdildi);
                entity.HasIndex(e => e.Ad);

                entity.HasOne(e => e.Istifadeci)
                    .WithMany()
                    .HasForeignKey(e => e.IstifadeciId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data-nı DatabaseInitializationService-də edirik
        }
    }
}