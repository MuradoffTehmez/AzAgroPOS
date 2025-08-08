// Fayl: AzAgroPOS.Teqdimat/Interfeysler/INovbeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using System;
public interface INovbeView
{
    decimal BaslangicMebleg { get; }
    decimal FaktikiMebleg { get; }
    void NovbeAciqdirGoster(string isci, DateTime acilisTarixi);
    void NovbeBaxlidirGoster();
    void HesabatGoster(string hesabatMetni);
    event EventHandler NovbeAc_Istek;
    event EventHandler NovbeBagla_Istek;
}