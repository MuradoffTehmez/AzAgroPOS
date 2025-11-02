// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IMehsulIdareetmeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System.Collections.Generic;
using System.Windows.Forms;

public interface IMehsulIdareetmeView
{
    string MehsulId { get; set; }
    string MehsulAdi { get; set; }
    string StokKodu { get; set; }
    string Barkod { get; set; }
    string PerakendeSatisQiymeti { get; set; }
    string TopdanSatisQiymeti { get; set; }
    string TekEdedSatisQiymeti { get; set; }
    string AlisQiymeti { get; set; }
    string MovcudSay { get; set; }
    string MinimumStok { get; set; }
    OlcuVahidi SecilmisOlcuVahidi { get; }
    int? SecilmisKateqoriyaId { get; }
    int? SecilmisBrendId { get; }
    int? SecilmisTedarukcuId { get; }
    string AxtarisMetni { get; set; }

    void MehsullariGoster(IEnumerable<MehsulDto> mehsullar);
    void OlcuVahidleriniGoster(Array olcuVahidleri);
    void KateqoriyalariGoster(IEnumerable<KateqoriyaDto> kateqoriyalar);
    void BrendleriGoster(IEnumerable<BrendDto> brendler);
    void TedarukculeriGoster(IEnumerable<TedarukcuDto> tedarukculer);
    void FormuTemizle();
    void SehifeMelumatlariGoster(int cariSehife, int umumiSehife, int umumiQeyd, bool evvelkiVar, bool novbetiVar);
    void XetaGoster(Control control, string message);
    void XetaniTemizle(Control control);
    void ButunXetalariTemizle();
    Task EmeliyyatIcraEtAsync(Func<Task> emeliyyat, string mesaj);

    event EventHandler FormYuklendi_Istek;
    event EventHandler MehsulElaveEt_Istek;
    event EventHandler MehsulYenile_Istek;
    event EventHandler MehsulSil_Istek;
    event EventHandler FormuTemizle_Istek;
    event EventHandler CedvelSecimiDeyisdi_Istek;
    event EventHandler Axtaris_Istek;
    event EventHandler StokKoduGeneralasiyaIstek;
    event EventHandler BarkodGeneralasiyaIstek;
    event EventHandler Kopyala_Istek;
    event EventHandler NovbetiSehifeIstek;
    event EventHandler EvvelkiSehifeIstek;

    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}