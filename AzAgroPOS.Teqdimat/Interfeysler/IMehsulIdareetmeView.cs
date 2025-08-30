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
    OlcuVahidi SecilmisOlcuVahidi { get; }
    string AxtarisMetni { get; set; }

    void MehsullariGoster(IEnumerable<MehsulDto> mehsullar);
    void OlcuVahidleriniGoster(Array olcuVahidleri);

    event EventHandler FormYuklendi_Istek;
    event EventHandler MehsulElaveEt_Istek;
    event EventHandler MehsulYenile_Istek;
    event EventHandler MehsulSil_Istek;
    event EventHandler FormuTemizle_Istek;
    event EventHandler CedvelSecimiDeyisdi_Istek;
    event EventHandler Axtaris_Istek;
    event EventHandler StokKoduGeneralasiyaIstek;
    event EventHandler BarkodGeneralasiyaIstek;

    DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);
}