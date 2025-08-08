// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ISatisView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;

public interface ISatisView
{
    // View-dan datanı oxumaq
    string BarkodAxtaris { get; }

    // View-a məlumat göndərmək
    void SebeteMehsulGoster(IEnumerable<SatisSebetiElementiDto> sebet);
    void UmumiMebligiGoster(decimal mebleg);
    void FormuSifirla();

    // Hadisələr
    event EventHandler BarkodDaxilEdildi_Istek;
    event EventHandler SatisiTesdiqle_Istek;

    // Mesajlaşma
    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}