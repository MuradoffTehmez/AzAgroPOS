// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IBonusIdareetmeView.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Interfeysler;
/// <summary>
/// Bonus idarəetmə forması üçün interfeys.
/// </summary>
public interface IBonusIdareetmeView
{
    // Bonus parametrləri
    int SecilenMusteriId { get; }
    decimal BalMiqdari { get; }
    string Aciklama { get; }
    MusteriBonus? SecilenMusteriBonus { get; }

    // View metodları
    void MusterileriGoster(List<MusteriDto> musteriler);
    void ButunBonuslariGoster(List<MusteriBonus> bonuslar);
    void BonusTarixcesiniGoster(List<BonusQeydi> qeydler);
    void MusteriBonusMelumatlariniGoster(MusteriBonus? bonus);
    void BonusMelumatlariniTemizle();
    void EmeliyyatSaheleriniTemizle();
    void TablolariDuzenle();
    void DuymeleriBloklama();
    void MesajGoster(string mesaj, string basliq, System.Windows.Forms.MessageBoxButtons duymeler, System.Windows.Forms.MessageBoxIcon ikon);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler MusteriSecildi;
    event EventHandler BalElaveEt_Istek;
    event EventHandler BalIstifadeEt_Istek;
    event EventHandler BalLegvEt_Istek;
    event EventHandler ManualBalElaveEt_Istek;
    event EventHandler Yenile_Istek;
}
