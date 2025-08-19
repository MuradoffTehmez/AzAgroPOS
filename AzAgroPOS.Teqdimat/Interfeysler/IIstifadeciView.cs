// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IIstifadeciView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
/// <summary>
/// bu interfeys, istifadəçi idarəetmə əməliyyatlarını təqdim edir.
/// Daxil olan metodlar və hadisələr, istifadəçi məlumatlarını göstərmək, istifadəçi yaratmaq və silmək kimi əməliyyatları əhatə edir.
/// </summary>
public interface IIstifadeciView
{
    /// <summary>
    /// İstifadəçiİd - istifadəçinin unikal identifikatoru.
    /// </summary>
    string IstifadeciId { get; set; }
    /// <summary>
    /// İstifadəçiAdı - istifadəçinin giriş adı.
    /// </summary>
    string IstifadeciAdi { get; set; }
    /// <summary>
    /// TamAd - istifadəçinin tam adı (ad və soyad).
    /// </summary>
    string TamAd { get; set; }
    /// <summary>
    /// Parol - istifadəçinin giriş parolu.
    /// </summary>
    string Parol { get; set; }
    /// <summary>
    /// SecilmisRolId - istifadəçinin seçilmiş rolu.
    /// </summary>
    int SecilmisRolId { get; }

    /// <summary>
    /// İstifadəçiləri göstərmək üçün istifadə olunur.
    /// Daha əvvəlki istifadəçi siyahısını yeniləyir və yeni istifadəçiləri göstərir.
    /// </summary>
    /// <param name="istifadeciler"></param>
    void IstifadecileriGoster(List<IstifadeciDto> istifadeciler);
    /// <summary>
    /// Rolları göstərmək üçün istifadə olunur.
    /// Daha dəqiq desək, istifadəçi rollarını göstərir və istifadəçinin hansı rollara malik olduğunu göstərir.
    /// </summary>
    /// <param name="rollar"></param>
    void RollariGoster(List<Rol> rollar);
    /// <summary>
    /// Form yükləndikdə çağırılan hadisə. Dəyişikliklər varsa, form yükləndikdə bütün istifadəçiləri yükləyir və göstərir.
    /// </summary>
    event EventHandler FormYuklendi;
    /// <summary>
    /// İstifadəçi yaratmaq üçün istifadəçi tərəfindən çağırılan hadisə. Dəyişikliklər varsa, yeni istifadəçi yaratmaq üçün istifadəçi tərəfindən çağırılan hadisə.
    /// </summary>
    event EventHandler IstifadeciYarat_Istek;
    /// <summary>
    /// İstifadəçi silmək üçün istifadəçi tərəfindən çağırılan hadisə. Dəyişikliklər varsa, istifadəçi silmək üçün istifadəçi tərəfindən çağırılan hadisə.
    /// </summary>
    event EventHandler IstifadeciSil_Istek;
    /// <summary>
    /// MesajGoster - istifadəçiyə mesaj göstərmək üçün istifadə olunur.
    /// Məsələn, əməliyyatın uğurlu olub olmadığını bildirmək üçün istifadə olunur.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <param name="xetadir"></param>
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();
}