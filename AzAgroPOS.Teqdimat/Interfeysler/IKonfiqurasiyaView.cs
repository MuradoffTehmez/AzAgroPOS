// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IKonfiqurasiyaView.cs
using System;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    /// <summary>
    /// Konfiqurasiya formu üçün interfeys. Presenter-in View ilə necə əlaqə quracağını təyin edir.
    /// </summary>
    public interface IKonfiqurasiyaView
    {
        #region Şirkət Məlumatları Properties

        /// <summary>Şirkət adı</summary>
        string SirketAdi { get; set; }

        /// <summary>Şirkət ünvanı</summary>
        string SirketUnvani { get; set; }

        /// <summary>Şirkət VÖEN-i</summary>
        string SirketVoen { get; set; }

        /// <summary>Şirkət telefonu</summary>
        string SirketTelefon { get; set; }

        /// <summary>Şirkət email-i</summary>
        string SirketEmail { get; set; }

        /// <summary>Şirkət veb saytı</summary>
        string SirketVebSayt { get; set; }

        /// <summary>Şirkət logo yolu</summary>
        string SirketLogo { get; set; }

        #endregion

        #region Vergi Parametrləri Properties

        /// <summary>ƏDV dərəcəsi (%)</summary>
        decimal EdvDerecesi { get; set; }

        #endregion

        #region Printer Tənzimləmələri Properties

        /// <summary>Qəbz printer adı</summary>
        string QebzPrinteri { get; set; }

        /// <summary>Barkod printer adı</summary>
        string BarkodPrinteri { get; set; }

        /// <summary>Printer kağız ölçüsü</summary>
        string PrinterKagizOlcusu { get; set; }

        #endregion

        #region Proqram Davranışı Properties

        /// <summary>Satışdan sonra qəbzi avtomatik çap et</summary>
        bool QebzAvtoCap { get; set; }

        /// <summary>Avtomatik yedekləmə aktivdir</summary>
        bool AvtomatikYedekleme { get; set; }

        /// <summary>Yedekləmə saatı (HH:mm formatında)</summary>
        string YedeklemeSaati { get; set; }

        #endregion

        #region Sistem Parametrləri Properties

        /// <summary>Proqram dili</summary>
        string SistemDil { get; set; }

        /// <summary>Əsas valyuta</summary>
        string SistemValyuta { get; set; }

        /// <summary>Tarix formatı</summary>
        string SistemTarixFormati { get; set; }

        /// <summary>Rəqəm formatı</summary>
        string SistemReqemFormati { get; set; }

        /// <summary>İnterfeys teması</summary>
        string SistemTema { get; set; }

        /// <summary>Sessiya timeout (dəqiqə)</summary>
        int SistemSessiyaTimeout { get; set; }

        #endregion

        #region State Properties

        /// <summary>Formda dəyişiklik olub-olmadığı (Unsaved changes)</summary>
        bool IsDirty { get; set; }

        /// <summary>Form hazırda yükləmə vəziyyətindədir</summary>
        bool IsLoading { get; }

        #endregion

        #region UI Control Methods

        /// <summary>
        /// Mesaj göstərir
        /// </summary>
        void MesajGoster(string mesaj, string basliq,
            System.Windows.Forms.MessageBoxButtons duymeler,
            System.Windows.Forms.MessageBoxIcon ikon);

        /// <summary>
        /// Validasiya xətalarını göstərir
        /// </summary>
        void ValidasiyaXetalariGoster(string xetalar);

        /// <summary>
        /// Uğurlu əməliyyat mesajı göstərir
        /// </summary>
        void UgurMesajiGoster(string mesaj);

        /// <summary>
        /// Xəta mesajı göstərir
        /// </summary>
        void XetaMesajiGoster(string mesaj);

        /// <summary>
        /// Xəbərdarlıq mesajı göstərir
        /// </summary>
        void XeberdarlikMesajiGoster(string mesaj);

        /// <summary>
        /// Təsdiq soruşur və cavabı qaytarır
        /// </summary>
        bool TesdiqSorusu(string mesaj);

        #endregion

        #region Loading State Methods

        /// <summary>
        /// Yükləmə göstəricisini göstərir və formu blok edir
        /// </summary>
        void YuklemeGoster(string mesaj = "Yüklənir...");

        /// <summary>
        /// Yükləmə göstəricisini gizlədir və formu aktiv edir
        /// </summary>
        void YuklemeGizle();

        #endregion

        #region Button State Methods

        /// <summary>
        /// Yadda saxla düyməsini aktivləşdirir/deaktivləşdirir
        /// </summary>
        void YaddaSaxlaDuymesiniBiraktir(bool aktiv);

        /// <summary>
        /// Ləğv et düyməsini aktivləşdirir/deaktivləşdirir
        /// </summary>
        void LegvEtDuymesiniBiraktir(bool aktiv);

        /// <summary>
        /// Bütün daxiletmə sahələrini aktivləşdirir/deaktivləşdirir
        /// </summary>
        void DaxiletmeSaheleriniAktivlesdirme(bool aktiv);

        #endregion

        #region Printer Methods

        /// <summary>
        /// Printer seçmə dialoqu göstərir
        /// </summary>
        /// <param name="hazirkiPrinter">Hazırki seçilmiş printer</param>
        /// <returns>Seçilmiş printer adı və ya null</returns>
        string PrinterSecDialoquGoster(string hazirkiPrinter);

        /// <summary>
        /// Printer test səhifəsi çap edir
        /// </summary>
        bool PrinterTestCap(string printerAdi);

        /// <summary>
        /// Quraşdırılmış printerləri qaytarır
        /// </summary>
        System.Collections.Generic.List<string> QurasdirilanPrinterleriGetir();

        #endregion

        #region Logo Methods

        /// <summary>
        /// Logo seçmə dialoqu göstərir
        /// </summary>
        /// <returns>Seçilmiş logo fayl yolu və ya null</returns>
        string LogoSecDialoquGoster();

        /// <summary>
        /// Logonu göstərir (PictureBox-da)
        /// </summary>
        void LogoGoster(string logoYolu);

        #endregion

        #region Data Refresh Methods

        /// <summary>
        /// Formu yeniləyir - bütün məlumatları yenidən yükləyir
        /// </summary>
        void FormuYenile();

        /// <summary>
        /// Formu sıfırlayır - bütün sahələri təmizləyir
        /// </summary>
        void FormuSifirla();

        /// <summary>
        /// Formu varsayılan dəyərlərlə doldurur
        /// </summary>
        void VarsayilanDeyerleriYukle();

        #endregion

        #region Combo Box Population Methods

        /// <summary>
        /// Dil combo box-ını doldurur
        /// </summary>
        void DilComboBoxDoldur(System.Collections.Generic.Dictionary<string, string> diller, string secilmisDil);

        /// <summary>
        /// Valyuta combo box-ını doldurur
        /// </summary>
        void ValyutaComboBoxDoldur(System.Collections.Generic.List<string> valyutalar, string secilmisValyuta);

        /// <summary>
        /// Kağız ölçüsü combo box-ını doldurur
        /// </summary>
        void KagizOlcusuComboBoxDoldur(System.Collections.Generic.List<string> olculer, string secilmisOlcu);

        /// <summary>
        /// Tema combo box-ını doldurur
        /// </summary>
        void TemaComboBoxDoldur(System.Collections.Generic.List<string> temalar, string secilmisTema);

        #endregion

        #region Events

        /// <summary>
        /// Yadda saxla düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler YaddaSaxlaClick;

        /// <summary>
        /// Ləğv et düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler LegvEtClick;

        /// <summary>
        /// Qəbz printer seç düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler QebzPrinterSecClick;

        /// <summary>
        /// Barkod printer seç düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler BarkodPrinterSecClick;

        /// <summary>
        /// Logo seç düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler LogoSecClick;

        /// <summary>
        /// Hər hansı bir dəyişiklik olduqda işə düşür
        /// </summary>
        event EventHandler DeyerDeyisdi;

        /// <summary>
        /// Form yükləndikdə işə düşür
        /// </summary>
        event EventHandler FormYuklendi;

        #endregion
    }
}