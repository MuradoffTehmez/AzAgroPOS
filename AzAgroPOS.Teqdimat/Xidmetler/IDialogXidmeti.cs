// Fayl: AzAgroPOS.Teqdimat/Xidmetler/IDialogXidmeti.cs

namespace AzAgroPOS.Teqdimat.Xidmetler;

/// <summary>
/// Dialog və mesaj göstərmək üçün xidmət interfeysi
/// Məqsəd: MessageBox.Show təkrarlarını aradan qaldırmaq və test edilə bilən kod yazmaq
/// </summary>
public interface IDialogXidmeti
{
    /// <summary>
    /// Məlumat mesajı göstərir
    /// </summary>
    void MelumatGoster(string mesaj, string basliq = "Məlumat");

    /// <summary>
    /// Xəta mesajı göstərir
    /// </summary>
    void XetaGoster(string mesaj, string basliq = "Xəta");

    /// <summary>
    /// Xəbərdarlıq mesajı göstərir
    /// </summary>
    void XeberdarligGoster(string mesaj, string basliq = "Xəbərdarlıq");

    /// <summary>
    /// Uğur mesajı göstərir
    /// </summary>
    void UgurGoster(string mesaj, string basliq = "Uğurlu");

    /// <summary>
    /// Təsdiq soruşuğu göstərir (Bəli/Xeyr)
    /// </summary>
    /// <returns>true əgər istifadəçi Bəli düyməsinə bassа</returns>
    bool TesdiqSorus(string mesaj, string basliq = "Təsdiq");

    /// <summary>
    /// Seçim soruşuğu göstərir (Bəli/Xeyr/Ləğv et)
    /// </summary>
    /// <returns>DialogResult</returns>
    DialogResult SecimSorus(string mesaj, string basliq = "Seçim");
}
