// Fayl: AzAgroPOS.Varliglar/StokHareketi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Anbar stok hərəkətlərini qeyd edən varlıq.
/// diqqət: Bu varlıq, hər bir məhsulun anbar hərəkətini izləməyə və anbar qalıqlarını hesablamağa imkan verir.
/// qeyd: Bütün alış, satış, qaytarma və inventarizasiya əməliyyatları bu cədvəldə qeyd olunur.
/// rol: Bu sinif, anbar uçotunun əsasını təşkil edir və bütün stok hərəkətlərinin tarixini saxlayır.
/// </summary>
public class StokHareketi : BazaVarligi
{
    /// <summary>
    /// Stok hərəkətinin tipi (Daxilolma və ya Çıxış)
    /// diqqət: Bu sahə, məhsulun anbara daxil olub-olmamasını və ya çıxıb-çıxmamasını göstərir.
    /// qeyd: Daxilolma (+), Çıxış (-) kimi hesablanır.
    /// </summary>
    public StokHareketTipi HareketTipi { get; set; }

    /// <summary>
    /// Hərəkətə səbəb olan sənədin növü
    /// diqqət: Bu sahə, stok hərəkətinin hansı əməliyyatla bağlı olduğunu göstərir.
    /// qeyd: Məsələn, Alış, Satış, Qaytarma, İnventarizasiya və s.
    /// </summary>
    public SenedNovu SenedNovu { get; set; }

    /// <summary>
    /// Əməliyyata aid sənədin ID-si
    /// diqqət: Bu sahə, hansı sənədin bu stok hərəkətinə səbəb olduğunu göstərir.
    /// qeyd: Məsələn, satış sənədinin ID-si, alış sənədinin ID-si və s.
    /// Null ola bilər (məsələn, inventarizasiya zamanı).
    /// </summary>
    public int? SenedId { get; set; }

    /// <summary>
    /// Hərəkət edilən məhsulun ID-si
    /// diqqət: Bu sahə, hansı məhsulun stokda dəyişiklik olduğunu göstərir.
    /// qeyd: Məhsul cədvəlinə foreign key.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsul navigasiya xassəsi
    /// diqqət: Bu navigasiya xassəsi, məhsul məlumatlarına asanlıqla çatmağa imkan verir.
    /// </summary>
    public Mehsul Mehsul { get; set; } = null!;

    /// <summary>
    /// Hərəkət edilən məhsul miqdarı
    /// diqqət: Bu sahə, nə qədər məhsulun daxil olduğunu və ya çıxdığını göstərir.
    /// qeyd: Həmişə müsbət rəqəm olmalıdır. Mənfi olması, HareketTipi ilə müəyyən edilir.
    /// </summary>
    public int Miqdar { get; set; }

    /// <summary>
    /// Stok hərəkətinin baş verdiyi tarix və vaxt
    /// diqqət: Bu sahə, hərəkətin nə zaman baş verdiyini göstərir.
    /// qeyd: Tarix və vaxt məlumatı, anbar tarixini izləməyə kömək edir.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Əlavə qeyd və ya izahat
    /// diqqət: Bu sahə, stok hərəkəti ilə bağlı əlavə məlumat saxlamaq üçündür.
    /// qeyd: Məsələn, "Inventarizasiya zamanı çatışmazlıq aşkar edildi" və ya "Xarab məhsul".
    /// Null ola bilər.
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Əməliyyatı həyata keçirən istifadəçinin ID-si
    /// diqqət: Bu sahə, hansı istifadəçinin bu əməliyyatı yerinə yetirdiyini göstərir.
    /// qeyd: İstifadeçi cədvəlinə foreign key. Null ola bilər (sistem avtomatik əməliyyatlar üçün).
    /// </summary>
    public int? IstifadeciId { get; set; }

    /// <summary>
    /// İstifadəçi navigasiya xassəsi
    /// diqqət: Bu navigasiya xassəsi, istifadəçi məlumatlarına asanlıqla çatmağa imkan verir.
    /// </summary>
    public Istifadeci? Istifadeci { get; set; }
}
