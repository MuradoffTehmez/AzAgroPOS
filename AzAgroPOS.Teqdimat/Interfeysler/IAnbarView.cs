// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAnbarView.cs
using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    /// <summary>
    /// Anbar idarəetmə formu üçün interfeys. Presenter-in View ilə necə əlaqə quracağını təyin edir.
    /// </summary>
    public interface IAnbarView
    {
        #region Properties - Input Data

        /// <summary>
        /// Axtarış mətni (Barkod və ya Stok Kodu)
        /// </summary>
        string AxtarisMetni { get; }

        /// <summary>
        /// Əlavə ediləcək və ya azaldılacaq say
        /// </summary>
        string ElaveOlunanSay { get; }

        /// <summary>
        /// Seçilmiş məhsulun ID-si
        /// </summary>
        int? SecilmisMehsulId { get; }

        /// <summary>
        /// Qeyd/Səbəb mətni
        /// </summary>
        string Qeyd { get; }

        /// <summary>
        /// Seçilmiş əməliyyat növü (Artırma/Azaltma/Düzəliş)
        /// </summary>
        string EmeliyyatNovu { get; }

        #endregion

        #region Properties - State

        /// <summary>
        /// Form hazırda yükləmə vəziyyətindədir
        /// </summary>
        bool IsLoading { get; }

        /// <summary>
        /// Məhsul seçilmişdir
        /// </summary>
        bool MehsulSecilmisdir { get; }

        #endregion

        #region Events

        /// <summary>
        /// Axtar düyməsinə basıldıqda və ya Enter basıldıqda işə düşür
        /// </summary>
        event EventHandler AxtarIstek;

        /// <summary>
        /// Stok artır düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler StokArtirIstek;

        /// <summary>
        /// Stok azalt düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler StokAzaltIstek;

        /// <summary>
        /// Stok düzəliş düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler StokDuzelisIstek;

        /// <summary>
        /// Təmizlə düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler TemizleIstek;

        /// <summary>
        /// Tarixçə göstər düyməsinə basıldıqda işə düşür
        /// </summary>
        event EventHandler TarixceGosterIstek;

        /// <summary>
        /// Form yükləndikdə işə düşür
        /// </summary>
        event EventHandler FormYuklendi;

        #endregion

        #region Methods - Display Data

        /// <summary>
        /// Məhsul məlumatlarını göstərir
        /// </summary>
        void MehsulMelumatlariniGoster(MehsulDto mehsul);

        /// <summary>
        /// Stok tarixçəsini göstərir
        /// </summary>
        void StokTarixcesiniGoster(List<StokHareketiDto> tarixce);

        #endregion

        #region Methods - UI Control

        /// <summary>
        /// Formu təmizləyir
        /// </summary>
        /// <param name="axtarisQutusuQalsin">Axtarış qutusunu təmizləməsin</param>
        void FormuTemizle(bool axtarisQutusuQalsin = false);

        /// <summary>
        /// Məhsul məlumat panelini göstərir/gizlədir
        /// </summary>
        void MehsulPaneliniGoster(bool goster);

        /// <summary>
        /// Əməliyyat düymələrini aktivləşdirir/deaktivləşdirir
        /// </summary>
        void EmeliyyatDuymeleriniAktivet(bool aktiv);

        /// <summary>
        /// Axtarış düyməsini aktivləşdirir/deaktivləşdirir
        /// </summary>
        void AxtarDuymesiniAktivet(bool aktiv);

        /// <summary>
        /// Focus-u axtarış sahəsinə verir
        /// </summary>
        void AxtarisFocus();

        /// <summary>
        /// Focus-u say sahəsinə verir
        /// </summary>
        void SayFocus();

        #endregion

        #region Methods - Validation

        /// <summary>
        /// Sahə üçün validasiya xətası göstərir
        /// </summary>
        void XetaGoster(Control control, string mesaj);

        /// <summary>
        /// Sahə üçün validasiya xətasını təmizləyir
        /// </summary>
        void XetaniTemizle(Control control);

        /// <summary>
        /// Bütün validasiya xətalarını təmizləyir
        /// </summary>
        void ButunXetalariTemizle();

        /// <summary>
        /// Validasiya xətalarını toplu şəkildə göstərir
        /// </summary>
        void ValidasiyaXetalariGoster(string xetalar);

        #endregion

        #region Methods - Messages

        /// <summary>
        /// Ümumi mesaj göstərir
        /// </summary>
        DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons duymeler, MessageBoxIcon ikon);

        /// <summary>
        /// Uğur mesajı göstərir
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
        /// Məlumat mesajı göstərir
        /// </summary>
        void MelumatMesajiGoster(string mesaj);

        /// <summary>
        /// Təsdiq soruşur
        /// </summary>
        bool TesdiqSorusu(string mesaj);

        #endregion

        #region Methods - Loading State

        /// <summary>
        /// Yükləmə göstəricisini göstərir və formu blok edir
        /// </summary>
        void YuklemeGoster(string mesaj = "Yüklənir...");

        /// <summary>
        /// Yükləmə göstəricisini gizlədir və formu aktiv edir
        /// </summary>
        void YuklemeGizle();

        #endregion

        #region Methods - Data Refresh

        /// <summary>
        /// Tarixçə grid-ini yeniləyir
        /// </summary>
        void TarixceGridiniYenile();

        #endregion
    }
}
