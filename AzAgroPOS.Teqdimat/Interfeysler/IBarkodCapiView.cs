// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IBarkodCapiView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System.Collections.Generic;

public interface IBarkodCapiView
{
    // View-dan məlumat oxumaq
    string AxtarisMetni { get; }
    List<BarkodEtiketDto> CapSiyahisi { get; }

    // Hadisələr
    event EventHandler AxtarisIstek;
    event EventHandler SiyahiniCapaGonderIstek;

    // View-a məlumat göndərmək
    void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar);
    void CapSiyahisiniYenile(List<BarkodEtiketDto> siyahı);
    void AxtarisXetasiGoster(string mesaj);
    void MesajGoster(string mesaj, string basliq);
}