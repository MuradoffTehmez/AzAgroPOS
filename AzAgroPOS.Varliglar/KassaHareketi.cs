// Fayl: AzAgroPOS.Varliglar/KassaHareketi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Kassa hərəkətinin növünü təyin edir
/// diqqət: Bu enum, kassa əməliyyatlarının istiqamətini müəyyən edir.
/// qeyd: Hərəkət daxil olarsa (nağd gəlir) - Daxilolma, çıxarsa (nağd xərc) - Cixis.
/// </summary>
public enum KassaHareketiNovu
{
    /// <summary>
    /// Kassaya daxil olan vəsait (gəlir)
    /// </summary>
    Daxilolma = 1,

    /// <summary>
    /// Kassadan çıxan vəsait (xərc)
    /// </summary>
    Cixis = 2
}

/// <summary>
/// Kassa hərəkətlərini təmsil edən varlıq
/// diqqət: Bu varlıq, kassadakı nağd vəsaitin hərəkətlərini qeyd edir.
/// qeyd: Bütün gəlir və xərclər bu cədvəldə qeyd olunur.
/// rol: Kassa uçotu və rəsmi hesabatlar üçün vacibdir.
/// </summary>
public class KassaHareketi : BazaVarligi
{
    /// <summary>
    /// Hərəkət növü (Daxilolma və ya Çıxış)
    /// diqqət: Bu sahə, əməliyyatın hansı istiqamətdə olduğunu göstərir.
    /// qeyd: Daxilolma (+) və ya Cixis (-).
    /// </summary>
    public KassaHareketiNovu HareketNovu { get; set; }

    /// <summary>
    /// Əməliyyat növü
    /// diqqət: Bu sahə, hansı əməliyyat növü ilə əlaqəli olduğunu göstərir.
    /// qeyd: Məsələn, satış gəliri, xərc ödənişi, qaytarma və s.
    /// </summary>
    public EmeliyyatNovu EmeliyyatNovu { get; set; }

    /// <summary>
    /// Əməliyyatın ID-si
    /// diqqət: Bu sahə, hansı konkret əməliyyatla əlaqəli olduğunu göstərir.
    /// qeyd: Satış ID, xərc ID və ya digər əməliyyat ID-si ola bilər.
    /// </summary>
    public int? EmeliyyatId { get; set; }

    /// <summary>
    /// Hərəkət edilən məbləğ
    /// diqqət: Bu sahə, həmişə müsbət məbləği saxlayır, istiqamət HareketNovu ilə müəyyən edilir.
    /// qeyd: Məbləğ mənfi ola bilməz, istiqamət HareketNovu ilə təyin olunur.
    /// </summary>
    public decimal Mebleg { get; set; }

    /// <summary>
    /// Hərəkətin baş verdiyi tarix və vaxt
    /// diqqət: Bu sahə, hərəkətin hansı tarixdə və vaxtda baş verdiyini göstərir.
    /// qeyd: Hesabatlar üçün vacibdir.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Əlavə qeyd
    /// diqqət: Bu sahə, əməliyyatla bağlı əlavə izahatlar saxlayır.
    /// qeyd: Məsələn, əməliyyatın təfərrüatları.
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Əməliyyatı həyata keçirən istifadəçinin ID-si
    /// diqqət: Bu sahə, hansı istifadəçinin bu əməliyyatı etdiyini göstərir.
    /// qeyd: İstifadeçi cədvəlinə foreign key.
    /// </summary>
    public int? IstifadeciId { get; set; }

    /// <summary>
    /// İstifadəçi navigasiya xassəsi
    /// diqqət: Bu navigasiya xassəsi, istifadəçi məlumatlarına asanlıqla çatmağa imkan verir.
    /// </summary>
    public Istifadeci? Istifadeci { get; set; }
}