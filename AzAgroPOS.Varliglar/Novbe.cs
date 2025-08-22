// Fayl: AzAgroPOS.Varliglar/Novbe.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Kassirin iş növbəsini təmsil edir.
/// </summary>
public class Novbe : BazaVarligi
{
    /// <summary>
    /// İşçi ID-si, bu növbəni açan və ya idarə edən istifadəçinin unikal identifikatorudur.
    /// diqqət: Bu ID, sistemdəki istifadəçilərin unikal identifikatorudur və hər bir işçi üçün fərqlidir.
    /// qeyd: İşçi ID-si, növbənin hansı işçi tərəfindən açıldığını və ya idarə edildiyini göstərir, məsələn, "12345" və ya "67890".
    /// </summary>
    public int IsciId { get; set; }
    /// <summary>
    /// İşçi, yəni kassir haqqında məlumatları saxlayır.
    /// diqqət: Bu, növbəni açan və ya idarə edən istifadəçinin məlumatlarını ehtiva edir.
    /// qeyd: İşçi məlumatları, istifadəçinin adını, soyadını, telefon nömrəsini və digər əlaqəli məlumatları ehtiva edə bilər.
    /// </summary>
    public Istifadeci? Isci { get; set; }
    /// <summary>
    /// Açılış tarixi, növbənin başladığı vaxtı göstərir.
    /// diqqət: Bu tarix, növbənin açıldığı anı təmsil edir və növbənin qeydə alındığı vaxtı göstərir.
    /// qeyd: Açılış tarixi, növbənin başladığı gün və saatı əhatə edir, məsələn, "2025-09-13 09:00:00".
    /// </summary>
    public DateTime AcilmaTarixi { get; set; }
    /// <summary>
    /// Bağlanma tarixi, növbənin bağlandığı vaxtı göstərir.
    /// diqqət: Bu tarix, növbənin bağlandığı anı təmsil edir və növbənin qeydə alındığı vaxtı göstərir.
    /// qeyd: Bağlanma tarixi, növbənin bağlandığı gün və saatı əhatə edir, məsələn, "2025-09-13 18:00:00".
    /// </summary>
    public DateTime? BaglanmaTarixi { get; set; }

    /// <summary>
    /// Növbə başlayarkən kassada olan nağd pul.
    /// diqqət: Bu məbləğ, növbənin açıldığı zaman kassada olan başlanğıc məbləğini təmsil edir.
    /// qeyd: Başlanğıc məbləğ, növbənin açıldığı zaman kassada olan nağd pulun miqdarını göstərir, məsələn, "100.00" AZN.
    /// </summary>
    public decimal BaslangicMebleg { get; set; }

    /// <summary>
    /// Növbə bağlanarkən kassada olmalı olan hesablanmış nağd pul.
    /// diqqət: Bu məbləğ, növbənin bağlanması zamanı kassada olması gözlənilən məbləği təmsil edir.
    /// qeyd: Gözlənilən məbləğ, növbənin bağlanması zamanı kassada olmalı olan nağd pulun miqdarını göstərir, məsələn, "150.00" AZN.
    /// </summary>
    public decimal GozlenilenMebleg { get; set; }

    /// <summary>
    /// Növbə bağlanarkən kassada sayılan faktiki nağd pul.
    /// diqqət: Bu məbləğ, növbənin bağlanması zamanı kassada faktiki olaraq olan məbləği təmsil edir.
    /// qeyd: Faktiki məbləğ, növbənin bağlanması zamanı kassada faktiki olaraq sayılan nağd pulun miqdarını göstərir, məsələn, "145.00" AZN.
    /// </summary>
    public decimal FaktikiMebleg { get; set; }
    /// <summary>
    /// Növbənin statusu, yəni açıq və ya bağlı olduğunu göstərir.
    /// diqqət: Bu status, növbənin cari vəziyyətini təmsil edir və növbənin açıq və ya bağlı olduğunu göstərir.
    /// qeyd: Növbə statusu, "Açıq" və ya "Bağlı" ola bilər. Açıq növbə, hələ bağlanmamış və satışların davam etdiyi növbəni göstərir, bağlı növbə isə artıq bağlanmış və satışların tamamlandığı növbəni göstərir.
    /// </summary>
    public NovbeStatusu Status { get; set; }
    /// <summary>
    /// Satışların bu növbə ilə əlaqəli siyahısı.
    /// diqqət: Bu kolleksiya, növbə bağlandıqda və ya açıldıqda satışların izlənməsi üçün istifadə olunur.
    /// qeyd: Növbə açıq olduqda, bu kolleksiya boş ola bilər, lakin növbə bağlandıqda, bu kolleksiya növbə ilə əlaqəli bütün satışları saxlayır.
    /// </summary>
    public ICollection<Satis> Satislar { get; set; } = new List<Satis>();
}