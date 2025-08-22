// Fayl: AzAgroPOS.Varliglar/Rol.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemdəki istifadəçi rollarını (məsələn, Admin, Kassir) təyin edir.
/// Diqqət: Bu sinif, istifadəçilərin sistemdəki müxtəlif rollarını və onların hüquqlarını təmsil edir.
/// Qeyd: Hər bir rol, müəyyən hüquqlara və icazələrə malikdir, məsələn, "Admin" rolu bütün idarəetmə funksiyalarına sahib ola bilər, "Kassir" rolu isə yalnız satış əməliyyatlarını idarə edə bilər.
/// </summary>
public class Rol : BazaVarligi
{
    /// <summary>
    /// Ad, yəni rolun adı (məsələn, "Admin", "Kassir").
    /// Diqqət: Rol adı boş ola bilməz və unikal olmalıdır.
    /// Qeyd: Rol adı, istifadəçilərin sistemdəki funksiyalarını və hüquqlarını müəyyən etmək üçün vacibdir, məsələn, "Admin" rolu bütün idarəetmə funksiyalarına sahib ola bilər, "Kassir" rolu isə yalnız satış əməliyyatlarını idarə edə bilər.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// istifadəçilər, yəni bu rola təyin edilmiş istifadəçilərin siyahısı.
    /// diqqət: Bu kolleksiya, rola aid olan bütün istifadəçiləri ehtiva edir.
    /// Qeyd: İstifadəçilər kolleksiyası, rola aid olan istifadəçilərin siyahısını saxlamaq və onların rollarını idarə etmək üçün vacibdir.
    /// </summary>
    public ICollection<Istifadeci> Istifadeciler { get; set; } = new List<Istifadeci>();
}