// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IZHesabatArxivView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

public interface IZHesabatArxivView
{
    int? SecilmisNovbeId { get; }
    DateTime BaslangicTarixi { get; }
    DateTime BitisTarixi { get; }

    event EventHandler FormYuklendi;
    event EventHandler HesabatGosterIstek;
    event EventHandler HesabatCapIstek;
    event EventHandler TarixFiltrDeyisdi;

    void NovbeleriGoster(List<BaglanmisNovbeDto> novbeler);
    void HesabatiGoster(string hesabatMetni);
    void HesabatDetallariGoster(ZHesabatDto hesabat);
    void MesajGoster(string mesaj);
    void XulaseGoster(int novbeSayi, decimal cemiSatis, decimal nagdSatis, decimal kartSatis);
    void YuklemeGoster();
    void YuklemeGizle();
}
