// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ILoginView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

public interface ILoginView
{
    string IstifadeciAdi { get; }
    string Parol { get; }
    bool UgurluDaxilOlundu { get; set; }

    event EventHandler DaxilOl_Istek;

    void MesajGoster(string mesaj);
    void FormuBagla();
}