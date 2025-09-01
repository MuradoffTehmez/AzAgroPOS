// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ISatisView.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms; // DialogResult üçün əlavə edildi

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface ISatisView
    {
        // View-dan məlumat oxumaq üçün
        string AxtarisMetni { get; }
        string SecilmisMehsulMiqdari { get; }
        MehsulDto? SecilmisAxtarisMehsulu { get; }
        SatisSebetiElementiDto? SecilmisSebetElementi { get; }
        int? SecilmisMusteriId { get; }

        // Hadisələr
        event EventHandler FormYuklendiIstek;
        event EventHandler MehsulAxtarIstek;
        event EventHandler SebeteElaveEtIstek;
        event EventHandler SebetdenSilIstek;
        event EventHandler SebetiTemizleIstek;
        event EventHandler MiqdariDeyisIstek;
        event EventHandler SatisiGozletIstek;
        event EventHandler GozleyenSatisiAcIstek;
        event EventHandler<OdenisMetodu> SatisiTesdiqleIstek;

        // View-a məlumat göndərmək üçün
        void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar);
        void AxtarisPaneliniSifirla();
        void SebeteMehsullariGoster(BindingList<SatisSebetiElementiDto> sebet);
        void UmumiMebligiGoster(decimal mebleg);
        void MusteriSiyahisiniGoster(List<MusteriDto> musteriler);
        void GozleyenSatislarMenyusunuGoster(List<GozleyenSatis> gozleyenSatislar);
        void FormuTamSifirla();
        DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
    }
}