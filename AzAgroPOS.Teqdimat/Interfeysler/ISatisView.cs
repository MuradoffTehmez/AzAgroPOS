// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ISatisView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System.Collections.Generic;

/// <summary>
///  Satis view interfeysi.
/// </summary>
public interface ISatisView
{
    // View-dan datanı oxumaq
    string BarkodAxtaris { get; }
    int? SecilmisMusteriId { get; }

    // View-a məlumat göndərmək
    void SebeteMehsulGoster(IEnumerable<SatisSebetiElementiDto> sebet);
    void UmumiMebligiGoster(decimal mebleg);
    void MusteriSiyahisiniGoster(List<MusteriDto> musteriler);
    void FormuSifirla();

    // Hadisələr (Köhnəni yeni ilə əvəz edirik)
    event EventHandler BarkodDaxilEdildi_Istek;
    event EventHandler<OdenisMetodu> SatisiTesdiqle_Istek; // Ödəniş metodunu parametr kimi ötürürük

    // Mesajlaşma
    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}