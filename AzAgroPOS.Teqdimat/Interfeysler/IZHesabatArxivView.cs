// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IZHesabatArxivView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

public interface IZHesabatArxivView
{
    int? SecilmisNovbeId { get; }

    event EventHandler FormYuklendi;
    event EventHandler HesabatGosterIstek;

    void NovbeleriGoster(List<BaglanmisNovbeDto> novbeler);
    void HesabatiGoster(string hesabatMetni);
    void MesajGoster(string mesaj);
}