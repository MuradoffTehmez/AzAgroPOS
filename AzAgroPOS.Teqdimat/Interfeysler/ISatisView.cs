using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System.ComponentModel;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface ISatisView
    {
        // View-dan məlumat oxumaq
        string AxtarisMetni { get; }
        string SecilmisMehsulMiqdari { get; }
        MehsulDto? SecilmisAxtarisMehsulu { get; }
        SatisSebetiElementiDto? SecilmisSebetElementi { get; }
        int? SecilmisMusteriId { get; }

        // Hadisələr (Events)
        event EventHandler FormYuklendiIstek;
        event EventHandler MehsulAxtarIstek;
        event EventHandler<MehsulDto> SuretliSatisIstek;
        event EventHandler SebeteElaveEtIstek;
        event EventHandler SebetdenSilIstek;
        event EventHandler SebetiTemizleIstek;
        event EventHandler SatisiGozletIstek;
        event EventHandler GozleyenSatisiAcIstek;
        event EventHandler<OdenisMetodu> SatisiTesdiqleIstek;
        event EventHandler<EndirimParametrləriDto> IndirimIstek;
        event EventHandler<int> SebetMiqdarArtirIstek;
        event EventHandler<int> SebetMiqdarAzaltIstek;
        event EventHandler YeniMusteriFormuAcIstek;
        event EventHandler MusteriSiyahisiniYenileIstek;
        event EventHandler OdemeIstek;
        event EventHandler NisyeEtIstek;
        event EventHandler TaxirEtIstek;
        event EventHandler TemizleIstek;
        event EventHandler SatisEtIstek;
        event EventHandler YeniMusteriIstek;
        event EventHandler BarkodCapIstek;

        // View-a məlumat göndərmək
        void SuretliSatisMehsullariniGoster(List<MehsulDto> mehsullar);
        void GozleyenSatislarSayiniGuncelle(int say);
        void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar);
        void AxtarisPaneliniSifirla();
        void SebeteMehsullariGoster(BindingList<SatisSebetiElementiDto> sebet);
        void UmumiMebligiGoster(decimal umumiMebleg, decimal endirim, decimal yekunMebleg);
        void MusteriSiyahisiniGoster(List<MusteriDto> musteriler);
        void GozleyenSatislarMenyusunuGoster(List<GozleyenSatis> gozleyenSatislar);
        void FormuTamSifirla();
        DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);

        // Status mesajları
        void StatusMesajiGoster(string mesaj, StatusMesajiNovu nov);

        // Müştəri ekranı dəstəyi
        void MusteriEkraniYenile(string mehsulAdi, decimal qiymet, decimal miqdar);

        // Müştəri borcuna görə rəngləmə üçün məlumat
        string GetMusteriBorcRengi(decimal borc);

        // Async əməliyyatlar üçün yükləmə göstərgəsi
        Task EmeliyyatIcraEtAsync(Func<Task> emeliyyat, string mesaj);
    }
}