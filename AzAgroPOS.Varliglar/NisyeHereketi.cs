// Fayl: AzAgroPOS.Varliglar/NisyeHereketi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Müştərinin hər bir nisyə əməliyyatını (alış və ya ödəniş) təmsil edir.
/// diqqət: Bu sinif, müştərinin nisyə əməliyyatlarını izləmək və idarə etmək üçün istifadə olunur.
/// qeyd: Nisyə əməliyyatları, müştərinin borc vəziyyətini və ödəniş tarixçəsini izləmək üçün vacibdir.
/// </summary>
public class NisyeHereketi : BazaVarligi
{
    /// <summary>
    /// müştərinin ID-si (əlaqəli müştəri).
    /// diqqət: Bu sahə boş ola bilməz və mövcud bir müştəriyə istinad etməlidir.
    /// qeyd: Müştəri ID-si, əməliyyatın hansı müştəriyə aid olduğunu müəyyən etmək üçün vacibdir.
    /// </summary>
    
    public int MusteriId { get; set; }

    /// <summary>
    /// müştəri obyekti (əlaqəli müştəri).
    /// diqqət: Bu sahə boş ola bilər, lakin mövcud bir müştəri obyektini ehtiva edə bilər.
    /// qeyd: Müştəri obyekti, əməliyyatın hansı müştəriyə aid olduğunu və müştəri məlumatlarına asanlıqla daxil olmağı təmin edir.
    /// </summary>
    
    public Musteri? Musteri { get; set; }

    /// <summary>
    /// Tarix və zaman (əməliyyatın baş verdiyi vaxt).
    /// Diqqət: Bu sahə boş ola bilməz və əməliyyatın baş verdiyi dəqiq vaxtı ehtiva etməlidir.
    /// Qeyd: Tarix və zaman sahəsi, əməliyyatların vaxtını izləmək və hesabatlar üçün vacibdir.
    /// </summary>
    
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Eməliyyatın növü (satis - nisyə satış, odenis - nisyə ödənişi).
    /// Diqqət: Bu sahə boş ola bilməz və yalnız "satis" və ya "odenis" dəyərlərini qəbul edir.
    /// Qeyd: EmeliyyatNovu sahəsi, əməliyyatın növünü müəyyən etmək və müştərinin borc vəziyyətini izləmək üçün vacibdir.
    /// </summary>
   
    public EmeliyyatNovu EmeliyyatNovu { get; set; }

    /// <summary>
    /// Əməliyyatın məbləği (artırırsa borc, azaldırsa ödəniş).
    /// Diqqət: Bu sahə boş ola bilməz və müsbət bir dəyər olmalıdır.
    /// Qeyd: Mebleg sahəsi, əməliyyatın maliyyə təsirini müəyyən etmək və müştərinin ümumi borc vəziyyətini izləmək üçün vacibdir.
    /// </summary>
    

    public decimal Mebleg { get; set; }

    /// <summary>
    /// Əgər əməliyyat satışdan yaranıbsa, əlaqəli satışın ID-si (borc artıran əməliyyatlar üçün).
    /// Diqqət: Bu sahə boş ola bilər, lakin mövcud bir satışa istinad edə bilər.   
    /// Qeyd: SatisId sahəsi, əməliyyatın hansı satışa aid olduğunu müəyyən etmək və satışla əlaqəli nisyə əməliyyatlarını izləmək üçün faydalıdır.
    /// </summary>
    
    public int? SatisId { get; set; }
    
    /// <summary>
    /// Satış obyekti (əlaqəli satış, borc artıran əməliyyatlar üçün).
    /// Diqqət: Bu sahə boş ola bilər, lakin mövcud bir satış obyektini ehtiva edə bilər.
    /// Q
    /// </summary>
    
    public Satis? Satis { get; set; }

    /// <summary>
    /// Əməliyyat haqqında əlavə qeyd və ya məlumat (satış və ya ödənişlə bağlı).
    /// Diqqət: Bu sahə boş ola bilər və əlavə məlumat ehtiva edə bilər.
    /// Qeyd: Qeyd sahəsi, əməliyyatla bağlı əlavə məlumatları saxlamaq və gələcək istinadlar üçün faydalıdır.
    /// </summary>
    
    public string? Qeyd { get; set; }
}