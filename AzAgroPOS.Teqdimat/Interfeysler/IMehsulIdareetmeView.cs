// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IMehsulIdareetmeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System.Collections.Generic;
using System.Windows.Forms;
using AzAgroPOS.Varliglar;


/// <summary>
/// MehsulIdareetmeFormu üçün "müqavilə". Presenter-in View ilə necə əlaqə quracağını təyin edir.
/// Detallı olaraq, mehsul idarəetmə əməliyyatlarını (əlavə etmə, yeniləmə, silmə və axtarış) idarə etmək üçün istifadə olunur.
/// </summary>
public interface IMehsulIdareetmeView
{
    // View-dan datanı oxumaq və yazmaq üçün xüsusiyyətlər
    string MehsulId { get; set; }
    string MehsulAdi { get; set; }
    string StokKodu { get; set; }
    string Barkod { get; set; }
    string SatisQiymeti { get; set; }
    string AlisQiymeti { get; set; }
    string MovcudSay { get; set; }
    string AxtarisMetni { get; set; }
    OlcuVahidi SecilmisOlcuVahidi { get; }

    // Cədvəli (DataGridView) məlumatla doldurmaq üçün metod
    void MehsullariGoster(IEnumerable<MehsulDto> mehsullar);
    void OlcuVahidleriniGoster(Array olcuVahidleri);

    // View-da baş verən hadisələri Presenter-ə bildirmək üçün
    event EventHandler FormYuklendi_Istek;
    event EventHandler MehsulElaveEt_Istek;
    event EventHandler MehsulYenile_Istek;
    event EventHandler MehsulSil_Istek;
    event EventHandler FormuTemizle_Istek;
    event EventHandler CedvelSecimiDeyisdi_Istek;
    event EventHandler Axtaris_Istek;
    event EventHandler StokKoduGeneralasiyaIstek; 
    event EventHandler BarkodGeneralasiyaIstek;

    //event EventHandler KodGeneralasiyaIstek;


    /// <summary>
    /// Presenter-in View-da mesaj göstərməsini və istifadəçi reaksiyasını almasını təmin edir.
    /// </summary>
    /// <returns>İstifadəçinin kliklədiyi düymənin nəticəsi (məsələn, DialogResult.Yes).</returns>
    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}