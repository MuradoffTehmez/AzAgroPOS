// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAnbarQaliqHesabatView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

public interface IAnbarQaliqHesabatView
{
    string LimitSay { get; }
    event EventHandler HesabatiGosterIstek;
    void HesabatiGoster(List<AnbarQaliqDetayDto> hesabat);
    void MesajGoster(string mesaj);
}