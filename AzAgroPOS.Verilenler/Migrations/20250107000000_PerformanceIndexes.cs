using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzAgroPOS.Verilenler.Migrations
{
    /// <inheritdoc />
    public partial class PerformanceIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ===== İSTİFADƏÇİLƏR =====
            // IstifadeciAdi - Login zamanı tez-tez axtarılır
            migrationBuilder.CreateIndex(
                name: "IX_Istifadeciler_IstifadeciAdi",
                table: "Istifadeciler",
                column: "IstifadeciAdi",
                unique: true);

            // HesabAktivdir - Aktiv istifadəçiləri filter etmək üçün
            migrationBuilder.CreateIndex(
                name: "IX_Istifadeciler_HesabAktivdir",
                table: "Istifadeciler",
                column: "HesabAktivdir");

            // ===== MƏHSULLAR =====
            // Barkod - Satış zamanı ən çox istifadə olunan axtarış
            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_Barkod",
                table: "Mehsullar",
                column: "Barkod",
                unique: true,
                filter: "[Barkod] IS NOT NULL");

            // Ad - Məhsul adı ilə axtarış
            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_Ad",
                table: "Mehsullar",
                column: "Ad");

            // MovcudSay - Stok sorğuları üçün (minimum stok yoxlamaları)
            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_MovcudSay",
                table: "Mehsullar",
                column: "MovcudSay");

            // ===== SATIŞLAR =====
            // Tarix - Hesabatlar və tarix aralığı sorğuları
            migrationBuilder.CreateIndex(
                name: "IX_Satislar_Tarix",
                table: "Satislar",
                column: "Tarix");

            // KassirId + Tarix - Kassir əsaslı hesabatlar
            migrationBuilder.CreateIndex(
                name: "IX_Satislar_KassirId_Tarix",
                table: "Satislar",
                columns: new[] { "KassirId", "Tarix" });

            // NovbeId - Növbə hesabatları
            migrationBuilder.CreateIndex(
                name: "IX_Satislar_NovbeId",
                table: "Satislar",
                column: "NovbeId",
                filter: "[NovbeId] IS NOT NULL");

            // ===== MÜŞTƏRİLƏR =====
            // TelefonNomresi - Müştəri axtarışı
            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_TelefonNomresi",
                table: "Musteriler",
                column: "TelefonNomresi",
                filter: "[TelefonNomresi] IS NOT NULL");

            // Email
            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_Email",
                table: "Musteriler",
                column: "Email",
                filter: "[Email] IS NOT NULL");

            // ===== STOK HƏRƏKƏTLƏRİ =====
            // Tarix - Tarixə görə sorğular
            migrationBuilder.CreateIndex(
                name: "IX_StokHereketleri_Tarix",
                table: "StokHereketleri",
                column: "Tarix");

            // MehsulId + Tarix - Məhsul üzrə stok tarixçəsi
            migrationBuilder.CreateIndex(
                name: "IX_StokHereketleri_MehsulId_Tarix",
                table: "StokHereketleri",
                columns: new[] { "MehsulId", "Tarix" });

            // ===== NÖVBƏLƏr =====
            // BaslamaTarixi + Status - Aktiv növbəni tapmaq
            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_BaslamaTarixi_Status",
                table: "Novbeler",
                columns: new[] { "BaslamaTarixi", "Status" });

            // IstifadeciId + Status - İstifadəçinin aktiv növbəsi
            migrationBuilder.CreateIndex(
                name: "IX_Novbeler_IstifadeciId_Status",
                table: "Novbeler",
                columns: new[] { "IstifadeciId", "Status" });

            // ===== GİRİŞ LOQULARI =====
            // CehdTarixi - Təhlükəsizlik audit sorğuları
            migrationBuilder.CreateIndex(
                name: "IX_GirisLoquKaydlari_CehdTarixi",
                table: "GirisLoquKaydlari",
                column: "CehdTarixi");

            // IstifadeciAdi + CehdTarixi - İstifadəçi əsaslı audit
            migrationBuilder.CreateIndex(
                name: "IX_GirisLoquKaydlari_IstifadeciAdi_CehdTarixi",
                table: "GirisLoquKaydlari",
                columns: new[] { "IstifadeciAdi", "CehdTarixi" });

            // Ugurlu - Uğursuz girişləri filter etmək
            migrationBuilder.CreateIndex(
                name: "IX_GirisLoquKaydlari_Ugurlu",
                table: "GirisLoquKaydlari",
                column: "Ugurlu");

            // ===== SESSİYALAR =====
            // IstifadeciId + Aktivdir - Aktiv sessiyaları tapmaq
            migrationBuilder.CreateIndex(
                name: "IX_IstifadeciSessiyalari_IstifadeciId_Aktivdir",
                table: "IstifadeciSessiyalari",
                columns: new[] { "IstifadeciId", "Aktivdir" });

            // BaslamaTarixi - Sessiya tarixçəsi
            migrationBuilder.CreateIndex(
                name: "IX_IstifadeciSessiyalari_BaslamaTarixi",
                table: "IstifadeciSessiyalari",
                column: "BaslamaTarixi");

            // ===== XƏRCLƏR =====
            // Tarix - Xərc hesabatları
            migrationBuilder.CreateIndex(
                name: "IX_Xercler_Tarix",
                table: "Xercler",
                column: "Tarix");

            // KateqoriyaId + Tarix - Kateqoriya əsaslı hesabatlar
            migrationBuilder.CreateIndex(
                name: "IX_Xercler_KateqoriyaId_Tarix",
                table: "Xercler",
                columns: new[] { "KateqoriyaId", "Tarix" });

            // ===== TEMİRLƏR =====
            // MusteriId - Müştəri əsaslı sorğular
            migrationBuilder.CreateIndex(
                name: "IX_Temirler_MusteriId",
                table: "Temirler",
                column: "MusteriId");

            // Status + QebulTarixi - Status əsaslı filter
            migrationBuilder.CreateIndex(
                name: "IX_Temirler_Status_QebulTarixi",
                table: "Temirler",
                columns: new[] { "Status", "QebulTarixi" });

            // ===== TEDARÜKÇÜLƏr =====
            // TelefonNomresi
            migrationBuilder.CreateIndex(
                name: "IX_Tedarukculer_TelefonNomresi",
                table: "Tedarukculer",
                column: "TelefonNomresi",
                filter: "[TelefonNomresi] IS NOT NULL");

            // Email
            migrationBuilder.CreateIndex(
                name: "IX_Tedarukculer_Email",
                table: "Tedarukculer",
                column: "Email",
                filter: "[Email] IS NOT NULL");

            // ===== ALIŞ SİFARİŞLƏRİ =====
            // YaradilmaTarixi
            migrationBuilder.CreateIndex(
                name: "IX_AlisSifarisleri_YaradilmaTarixi",
                table: "AlisSifarisleri",
                column: "YaradilmaTarixi");

            // Status + YaradilmaTarixi
            migrationBuilder.CreateIndex(
                name: "IX_AlisSifarisleri_Status_YaradilmaTarixi",
                table: "AlisSifarisleri",
                columns: new[] { "Status", "YaradilmaTarixi" });

            // ===== SİLİNİB COLUMN (Soft Delete) =====
            // Bütün əsas cədvəllər üçün Silinib sütunu index
            migrationBuilder.CreateIndex(
                name: "IX_Istifadeciler_Silinib",
                table: "Istifadeciler",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Mehsullar_Silinib",
                table: "Mehsullar",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_Silinib",
                table: "Musteriler",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_Silinib",
                table: "Satislar",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Tedarukculer_Silinib",
                table: "Tedarukculer",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Temirler_Silinib",
                table: "Temirler",
                column: "Silinib");

            migrationBuilder.CreateIndex(
                name: "IX_Isciler_Silinib",
                table: "Isciler",
                column: "Silinib");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // İstifadəçilər
            migrationBuilder.DropIndex(name: "IX_Istifadeciler_IstifadeciAdi", table: "Istifadeciler");
            migrationBuilder.DropIndex(name: "IX_Istifadeciler_HesabAktivdir", table: "Istifadeciler");
            migrationBuilder.DropIndex(name: "IX_Istifadeciler_Silinib", table: "Istifadeciler");

            // Məhsullar
            migrationBuilder.DropIndex(name: "IX_Mehsullar_Barkod", table: "Mehsullar");
            migrationBuilder.DropIndex(name: "IX_Mehsullar_Ad", table: "Mehsullar");
            migrationBuilder.DropIndex(name: "IX_Mehsullar_MovcudSay", table: "Mehsullar");
            migrationBuilder.DropIndex(name: "IX_Mehsullar_Silinib", table: "Mehsullar");

            // Satışlar
            migrationBuilder.DropIndex(name: "IX_Satislar_Tarix", table: "Satislar");
            migrationBuilder.DropIndex(name: "IX_Satislar_KassirId_Tarix", table: "Satislar");
            migrationBuilder.DropIndex(name: "IX_Satislar_NovbeId", table: "Satislar");
            migrationBuilder.DropIndex(name: "IX_Satislar_Silinib", table: "Satislar");

            // Müştərilər
            migrationBuilder.DropIndex(name: "IX_Musteriler_TelefonNomresi", table: "Musteriler");
            migrationBuilder.DropIndex(name: "IX_Musteriler_Email", table: "Musteriler");
            migrationBuilder.DropIndex(name: "IX_Musteriler_Silinib", table: "Musteriler");

            // Stok hərəkətləri
            migrationBuilder.DropIndex(name: "IX_StokHereketleri_Tarix", table: "StokHereketleri");
            migrationBuilder.DropIndex(name: "IX_StokHereketleri_MehsulId_Tarix", table: "StokHereketleri");

            // Növbələr
            migrationBuilder.DropIndex(name: "IX_Novbeler_BaslamaTarixi_Status", table: "Novbeler");
            migrationBuilder.DropIndex(name: "IX_Novbeler_IstifadeciId_Status", table: "Novbeler");

            // Giriş loquları
            migrationBuilder.DropIndex(name: "IX_GirisLoquKaydlari_CehdTarixi", table: "GirisLoquKaydlari");
            migrationBuilder.DropIndex(name: "IX_GirisLoquKaydlari_IstifadeciAdi_CehdTarixi", table: "GirisLoquKaydlari");
            migrationBuilder.DropIndex(name: "IX_GirisLoquKaydlari_Ugurlu", table: "GirisLoquKaydlari");

            // Sessiyalar
            migrationBuilder.DropIndex(name: "IX_IstifadeciSessiyalari_IstifadeciId_Aktivdir", table: "IstifadeciSessiyalari");
            migrationBuilder.DropIndex(name: "IX_IstifadeciSessiyalari_BaslamaTarixi", table: "IstifadeciSessiyalari");

            // Xərclər
            migrationBuilder.DropIndex(name: "IX_Xercler_Tarix", table: "Xercler");
            migrationBuilder.DropIndex(name: "IX_Xercler_KateqoriyaId_Tarix", table: "Xercler");

            // Təmirlər
            migrationBuilder.DropIndex(name: "IX_Temirler_MusteriId", table: "Temirler");
            migrationBuilder.DropIndex(name: "IX_Temirler_Status_QebulTarixi", table: "Temirler");
            migrationBuilder.DropIndex(name: "IX_Temirler_Silinib", table: "Temirler");

            // Tədarükçülər
            migrationBuilder.DropIndex(name: "IX_Tedarukculer_TelefonNomresi", table: "Tedarukculer");
            migrationBuilder.DropIndex(name: "IX_Tedarukculer_Email", table: "Tedarukculer");
            migrationBuilder.DropIndex(name: "IX_Tedarukculer_Silinib", table: "Tedarukculer");

            // Alış sifarişləri
            migrationBuilder.DropIndex(name: "IX_AlisSifarisleri_YaradilmaTarixi", table: "AlisSifarisleri");
            migrationBuilder.DropIndex(name: "IX_AlisSifarisleri_Status_YaradilmaTarixi", table: "AlisSifarisleri");

            // İşçilər
            migrationBuilder.DropIndex(name: "IX_Isciler_Silinib", table: "Isciler");
        }
    }
}
