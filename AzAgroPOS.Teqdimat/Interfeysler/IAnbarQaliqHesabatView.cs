// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAnbarQaliqHesabatView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

public interface IAnbarQaliqHesabatView
{
    string LimitSay { get; }
    string KateqoriyaFilter { get; }
    bool YalnizTukenenleri { get; }

    event EventHandler HesabatiGosterIstek;

    void HesabatiGoster(List<AnbarQaliqDetayDto> hesabat);
    void MesajGoster(string mesaj);
    void XulaseGoster(int mehsulSayi, decimal umumiDeger, int kritikSay, int tukenmisSay);
    void KateqoriyalariYukle(List<string> kateqoriyalar);
    void YuklemeGoster();
    void YuklemeGizle();
}
