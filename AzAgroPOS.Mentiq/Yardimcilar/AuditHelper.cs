// Fayl: AzAgroPOS.Mentiq/Yardimcilar/AuditHelper.cs
namespace AzAgroPOS.Mentiq.Yardimcilar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Threading.Tasks;

/// <summary>
/// Audit jurnalı yazılması üçün yardımçı sinif.
/// Diqqət: Bu sinif Manager siniflərində kritik əməliyyatlar zamanı istifadə olunur.
/// Qeyd: Audit yazılması asinxron həyata keçirilir.
/// </summary>
public class AuditHelper
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly int _istifadeciId;

    public AuditHelper(IUnitOfWork unitOfWork, int istifadeciId)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _istifadeciId = istifadeciId;
    }

    /// <summary>
    /// Yeni obyektin əlavə edilməsi üçün audit qeydi yazır.
    /// </summary>
    /// <param name="cedvelAdi">Cədvəl adı (məsələn: "Mehsul")</param>
    /// <param name="obyektId">Obyektin ID-si</param>
    /// <param name="aciklama">Əməliyyatın təfərrüatlı izahı</param>
    public async Task ElaveAuditYazAsync(string cedvelAdi, int obyektId, string aciklama)
    {
        try
        {
            var audit = new EmeliyyatJurnali
            {
                IstifadeciId = _istifadeciId,
                EmeliyyatTarixi = DateTime.UtcNow,
                EmeliyyatNovu = AuditEmeliyyatNovu.Elave,
                CədvəlAdi = cedvelAdi,
                ObyektId = obyektId,
                Aciklama = aciklama
            };

            await _unitOfWork.EmeliyyatJurnallari.ElaveEtAsync(audit);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Audit yazıldı: {cedvelAdi} - {aciklama}");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Audit yazılması zamanı xəta");
            // Audit xətası əsas əməliyyatı dayandırmamalıdır
        }
    }

    /// <summary>
    /// Obyektin yenilənməsi üçün audit qeydi yazır.
    /// </summary>
    /// <param name="cedvelAdi">Cədvəl adı</param>
    /// <param name="obyektId">Obyektin ID-si</param>
    /// <param name="deyisiklikler">Dəyişikliklərin təsviri (məsələn: "Qiymet: 15.00 → 16.50")</param>
    public async Task YenilemeAuditYazAsync(string cedvelAdi, int obyektId, string deyisiklikler)
    {
        try
        {
            var audit = new EmeliyyatJurnali
            {
                IstifadeciId = _istifadeciId,
                EmeliyyatTarixi = DateTime.UtcNow,
                EmeliyyatNovu = AuditEmeliyyatNovu.Yenileme,
                CədvəlAdi = cedvelAdi,
                ObyektId = obyektId,
                Aciklama = $"Yeniləndi: {deyisiklikler}"
            };

            await _unitOfWork.EmeliyyatJurnallari.ElaveEtAsync(audit);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Audit yazıldı: {cedvelAdi} yeniləndi - {deyisiklikler}");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Audit yazılması zamanı xəta");
        }
    }

    /// <summary>
    /// Obyektin silinməsi üçün audit qeydi yazır.
    /// </summary>
    /// <param name="cedvelAdi">Cədvəl adı</param>
    /// <param name="obyektId">Obyektin ID-si</param>
    /// <param name="aciklama">Silinmənin səbəbi və ya təsviri</param>
    public async Task SilmeAuditYazAsync(string cedvelAdi, int obyektId, string aciklama)
    {
        try
        {
            var audit = new EmeliyyatJurnali
            {
                IstifadeciId = _istifadeciId,
                EmeliyyatTarixi = DateTime.UtcNow,
                EmeliyyatNovu = AuditEmeliyyatNovu.Silme,
                CədvəlAdi = cedvelAdi,
                ObyektId = obyektId,
                Aciklama = $"Silindi: {aciklama}"
            };

            await _unitOfWork.EmeliyyatJurnallari.ElaveEtAsync(audit);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Audit yazıldı: {cedvelAdi} silindi - {aciklama}");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Audit yazılması zamanı xəta");
        }
    }

    /// <summary>
    /// Kritik əməliyyat üçün audit qeydi yazır.
    /// Məsələn: "İcazə verildi", "Qiymət dəyişdirildi", "Endirim tətbiq edildi"
    /// </summary>
    /// <param name="cedvelAdi">Cədvəl adı</param>
    /// <param name="obyektId">Obyektin ID-si (varsa)</param>
    /// <param name="emeliyyatTipi">Əməliyyatın tipi</param>
    /// <param name="aciklama">Əməliyyatın təfərrüatlı izahı</param>
    public async Task KritikEmeliyyatAuditYazAsync(
        string cedvelAdi,
        int obyektId,
        AuditEmeliyyatNovu emeliyyatTipi,
        string aciklama)
    {
        try
        {
            var audit = new EmeliyyatJurnali
            {
                IstifadeciId = _istifadeciId,
                EmeliyyatTarixi = DateTime.UtcNow,
                EmeliyyatNovu = emeliyyatTipi,
                CədvəlAdi = cedvelAdi,
                ObyektId = obyektId,
                Aciklama = $"[KRİTİK] {aciklama}"
            };

            await _unitOfWork.EmeliyyatJurnallari.ElaveEtAsync(audit);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Kritik audit yazıldı: {cedvelAdi} - {aciklama}");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kritik audit yazılması zamanı xəta");
        }
    }

    /// <summary>
    /// İki dəyəri müqayisə edib dəyişiklik varsa string qaytarır.
    /// </summary>
    /// <typeparam name="T">Dəyərin tipi</typeparam>
    /// <param name="saheAdi">Sahənin adı</param>
    /// <param name="kohneDeyer">Köhnə dəyər</param>
    /// <param name="yeniDeyer">Yeni dəyər</param>
    /// <returns>Dəyişikliyin təsviri və ya null (dəyişiklik yoxdursa)</returns>
    public static string? DeyisiklikYarat<T>(string saheAdi, T? kohneDeyer, T? yeniDeyer)
    {
        if (Equals(kohneDeyer, yeniDeyer))
            return null;

        return $"{saheAdi}: {kohneDeyer} → {yeniDeyer}";
    }

    /// <summary>
    /// Çoxlu dəyişiklikləri birləşdirib bir string halında qaytarır.
    /// </summary>
    /// <param name="deyisiklikler">Dəyişikliklərin siyahısı</param>
    /// <returns>Birləşdirilmiş dəyişikliklər</returns>
    public static string? DeyisikleriBirlesdir(params string?[] deyisiklikler)
    {
        var deyisiklikSiyahisi = deyisiklikler
            .Where(d => !string.IsNullOrEmpty(d))
            .ToList();

        return deyisiklikSiyahisi.Any()
            ? string.Join(", ", deyisiklikSiyahisi)
            : "Dəyişiklik yoxdur";

    }
}

