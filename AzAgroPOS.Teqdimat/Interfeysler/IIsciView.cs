// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IIsciView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;

public interface IIsciView
{
    // İşçi məlumatları
    int IsciId { get; set; }
    string TamAd { get; set; }
    DateTime DogumTarixi { get; set; }
    string TelefonNomresi { get; set; }
    string Unvan { get; set; }
    string Email { get; set; }
    DateTime IseBaslamaTarixi { get; set; }
    decimal Maas { get; set; }
    string Vezife { get; set; }
    string Departament { get; set; }
    IsciStatusu Status { get; set; }
    string SvsNo { get; set; }
    string QeydiyyatUnvani { get; set; }
    string BankMəlumatları { get; set; }

    // View metodları
    void IscileriGoster(List<IsciDto> isciler);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler IsciYarat_Istek;
    event EventHandler IsciYenile_Istek;
    event EventHandler IsciSil_Istek;
    event EventHandler FormuTemizle_Istek;
}