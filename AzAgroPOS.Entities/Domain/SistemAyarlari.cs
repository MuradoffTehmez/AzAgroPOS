using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("SistemAyarlari")]
    public class SistemAyarlari : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Acar { get; set; } // Setting key (unique identifier)

        [Required]
        [StringLength(1000)]
        public string Deyer { get; set; } // Setting value

        [StringLength(200)]
        public string Aciqlama { get; set; } // Description

        [StringLength(50)]
        public string Kateqoriya { get; set; } // Category (General, Appearance, Regional, etc.)

        [StringLength(20)]
        public string DataTipi { get; set; } // Data type (string, int, bool, decimal, etc.)

        public bool IstifadeciDeyise { get; set; } = true; // Can user change this setting

        public bool SystemAyari { get; set; } = false; // Is this a system-level setting

        // Static property names for easy access
        public static class Keys
        {
            // Regional Settings
            public const string Dil = "sistem.dil";
            public const string Valyuta = "sistem.valyuta";
            public const string TarixFormati = "sistem.tarix_formati";
            public const string SaatFormati = "sistem.saat_formati";
            public const string OndalikNoqte = "sistem.ondalik_noqte";

            // Appearance Settings  
            public const string Tema = "gorunus.tema";
            public const string EsasReng = "gorunus.esas_reng";
            public const string YaziOlcusu = "gorunus.yazi_olcusu";
            public const string LogoYolu = "gorunus.logo_yolu";
            public const string SirketAdi = "gorunus.sirket_adi";
            public const string SirketUnvani = "gorunus.sirket_unvani";

            // POS Settings
            public const string QebzCapi = "pos.qebz_capi";
            public const string PrinterAdi = "pos.printer_adi";
            public const string KassaAdi = "pos.kassa_adi";
            public const string BarkodTarayici = "pos.barkod_tarayici";
            public const string AvtomatikQebz = "pos.avtomatik_qebz";

            // Business Settings
            public const string EdvDerecesi = "biznes.edv_derecesi";
            public const string EdvNomresi = "biznes.edv_nomresi";
            public const string SirketAdresi = "biznes.sirket_adresi";
            public const string TelefonNomresi = "biznes.telefon_nomresi";
            public const string EmailAdresi = "biznes.email_adresi";
            
            // Database Settings
            public const string BackupMuddeti = "database.backup_muddeti";
            public const string BackupYolu = "database.backup_yolu";
            public const string LogSaxlamaMuddeti = "database.log_saxlama_muddeti";
            public const string PerformansOptimization = "database.performans_optimization";

            // Security Settings
            public const string ParolMurakkebliyi = "tehlukesizlik.parol_murakkebliyi";
            public const string GirisCehdSayi = "tehlukesizlik.giris_cehd_sayi";
            public const string BloklananMuddet = "tehlukesizlik.bloklanan_muddet";
            public const string SessionMuddeti = "tehlukesizlik.session_muddeti";

            // Notification Settings
            public const string MehsulQitligi = "bildiriş.mehsul_qitligi";
            public const string BorcXeberdarliqi = "bildiriş.borc_xeberdarliqi";
            public const string TamirXeberdarliqi = "bildiriş.tamir_xeberdarliqi";
            public const string SmsAktiv = "bildiriş.sms_aktiv";
            public const string EmailAktiv = "bildiriş.email_aktiv";
        }

        public static class Categories
        {
            public const string Regional = "Regional";
            public const string Gorunus = "Görünüş";
            public const string POS = "POS";
            public const string Biznes = "Biznes";
            public const string Database = "Verilənlər Bazası";
            public const string Tehlukesizlik = "Təhlükəsizlik";
            public const string Bildiriş = "Bildirişlər";
        }

        public static class DataTypes
        {
            public const string String = "string";
            public const string Integer = "int";
            public const string Decimal = "decimal";
            public const string Boolean = "bool";
            public const string Date = "date";
            public const string Time = "time";
            public const string Color = "color";
            public const string File = "file";
            public const string Email = "email";
            public const string Phone = "phone";
        }
    }
}