// Fayl: AzAgroPOS.Varliglar/Satis.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Bir satış əməliyyatının başlığını təmsil edir.
/// Ümumi məbləğ, tarix və müştəri kimi məlumatları saxlayır.
/// </summary>
public class Satis : BazaVarligi
{
    /// <summary>
    /// Tarix, satışın baş verdiyi vaxtı göstərir.
    /// diqqət: Bu tarix, satışın baş verdiyi anı təmsil edir və satışın qeydə alındığı vaxtı göstərir.
    /// qeyd: Tarix məlumatı, satışın baş verdiyi gün və saatı əhatə edir, məsələn, "2025-09-13 14:30:00".
    /// </summary>
    public DateTime Tarix { get; set; }
    /// <summary>
    /// Umumi məbləğ, satışın ümumi dəyərini göstərir.
    /// diqqət: Bu məbləğ, satışın baş verdiyi zaman ödənilən və ya alınan ümumi məbləği təmsil edir.
    /// qeyd: Umumi məbləğ, satışın bütün məhsul və xidmətlərinin qiymətlərinin cəmini əhatə edir, məsələn, "150.00" AZN.
    /// </summary>
    public decimal UmumiMebleg { get; set; }
    /// <summary>
    /// OdenisMetodu, satışın ödəniş üsulunu göstərir (məsələn, nağd, kart və s.).
    /// diqqət: Bu ödəniş metodu, satışın baş verdiyi zaman istifadə olunan ödəniş üsulunu təmsil edir.
    /// qeyd: OdenisMetodu, satışın ödənişinin necə həyata keçirildiyini göstərir, məsələn, "Nağd", "Kart", "Transfer" və s.
    /// </summary>
    public OdenisMetodu OdenisMetodu { get; set; }
    /// <summary>
    /// MusteriId, satışın aid olduğu müştərinin unikal identifikatorunu göstərir.
    /// diqqət: Bu müştəri, satışın baş verdiyi zaman mövcud olan müştəridir.
    /// qeyd: Müştəri ID-si, satışın baş verdiyi zaman müştərinin sistemdə qeydiyyatdan keçmiş unikal identifikatorudur.
    /// </summary>
    public int? MusteriId { get; set; }
    /// <summary>
    /// Musteri, satışın aid olduğu müştəri haqqında məlumatları saxlayır.
    /// diqqət: Bu müştəri, satışın baş verdiyi zaman mövcud olan müştəridir.
    /// qeyd: Müştəri məlumatları, satışın baş verdiyi zaman müştərinin adını, telefon nömrəsini və digər əlaqəli məlumatları ehtiva edə bilər.
    /// </summary>
    public Musteri? Musteri { get; set; }
    /// <summary>
    /// NovbeId, satışın aid olduğu növbənin unikal identifikatorunu göstərir.
    /// diqqət: Bu növbə, satışın baş verdiyi zaman açıq olan növbədir.
    /// qeyd: Növbə ID-si, satışın baş verdiyi zaman kassada olan növbənin unikal identifikatorudur.
    /// </summary>
    public int NovbeId { get; set; }
    /// <summary>
    /// Novbe, satışın aid olduğu növbə haqqında məlumatları saxlayır.
    /// diqqət: Bu növbə, satışın baş verdiyi zaman açıq olan növbədir.
    /// qeyd: Növbə məlumatları, satışın baş verdiyi zaman kassada olan nağd pul, açılış və bağlanma tarixləri və digər əlaqəli məlumatları ehtiva edə bilər.
    /// </summary>
    public Novbe? Novbe { get; set; }
    /// <summary>
    /// SatisDetallari, satışın detallı məlumatlarını saxlayır.
    /// diqqət: Bu kolleksiya, satışın baş verdiyi zaman satılan məhsul və miqdarlarını ehtiva edir.
    /// qeyd: Hər bir satış detalı, məhsulun ID-sini, miqdarını və qiymətini ehtiva edir.
    /// </summary>
    public ICollection<SatisDetali> SatisDetallari { get; set; } = new List<SatisDetali>();

    /// <summary>
    /// Bu satışa aid qaytarmaların siyahısı.
    /// </summary>
    public ICollection<Qaytarma> Qaytarmalar { get; set; } = new List<Qaytarma>();
}