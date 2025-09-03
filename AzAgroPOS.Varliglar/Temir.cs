// Fayl: AzAgroPOS.Varliglar/Temir.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Təmirə qəbul edilmiş bir sifarişi təmsil edir
/// diqqət: Bu sinif, müştərinin təmir üçün təqdim etdiyi cihaz və onun vəziyyəti haqqında məlumatları ehtiva edir.
/// qeyd: Təmir sifarişləri, müştəri məlumatları, cihaz məlumatları, təmir prosesi və xərclər kimi müxtəlif aspektləri əhatə edir.
/// </summary>
public class Temir : BazaVarligi
{
    // Müştəri Məlumatları
    /// <summary>
    /// Müştərinin adı və əlaqə məlumatları.
    /// diqqət: Müştərinin adı boş ola bilməz və müştərinin əlaqə məlumatlarını ehtiva etməlidir.
    /// qeyd: Müştərinin adı, müştəri ilə əlaqə və identifikasiya üçün vacibdir.
    /// </summary>
    public string MusteriAdi { get; set; } = string.Empty;
    /// <summary>
    /// Müştərinin telefon nömrəsi.
    /// diqqət: Telefon nömrəsi boş ola bilməz və müştərinin əlaqə nömrəsini ehtiva etməlidir.
    /// qeyd: Müştərinin telefon nömrəsi, müştəri ilə əlaqə saxlamaq üçün vacibdir.
    /// </summary>
    public string MusteriTelefonu { get; set; } = string.Empty;


    // Cihaz Məlumatları
    /// <summary>
    /// Cihazın növü (məsələn, telefon, planşet, kompüter və s.).
    /// Diqqət: Cihaz növü boş ola bilməz və cihazın növünü ehtiva etməlidir.
    /// Qeyd: Cihaz növü, təmir prosesində istifadə olunan ehtiyat hissələri və xidmətlər üçün vacibdir.
    /// </summary>
    public string CihazAdi { get; set; } = string.Empty;
    /// <summary>
    /// problem təsviri, yəni müştərinin cihazda müşahidə etdiyi problemlərin ətraflı izahı.
    /// Diqqət: Problem təsviri boş ola bilməz və cihazın vəziyyətini və problemlərini ətraflı şəkildə izah etməlidir.
    /// Qeyd: Problem təsviri, təmir prosesində düzgün diaqnoz və həll yollarının müəyyənləşdirilməsi üçün vacibdir.
    /// </summary>
    public string ProblemTesviri { get; set; } = string.Empty;

    // Təmir Prosesi Məlumatları
    /// <summary>
    /// Qəbul tarixi, yəni cihazın təmir üçün qəbul edildiyi tarix.
    /// Diqqət: Qəbul tarixi boş ola bilməz və cihazın təmir üçün qəbul edildiyi vaxtı ehtiva etməlidir.
    /// Qeyd: Qəbul tarixi, təmir prosesinin başlanğıcını və müddətini izləmək üçün vacibdir.
    /// </summary>
    public DateTime QebulTarixi { get; set; }
    /// <summary>
    /// Tamamlanma tarixi, yəni cihazın təmir prosesinin tamamlandığı tarix.
    /// Diqqət: Tamamlanma tarixi boş ola bilər, çünki təmir prosesi hələ tamamlanmamış ola bilər.
    /// Qeyd: Tamamlanma tarixi, təmir prosesinin bitişini və müştəriyə cihazın qaytarılma vaxtını izləmək üçün vacibdir.
    /// </summary>
    public DateTime? TamamlanmaTarixi { get; set; }
    /// <summary>
    /// Status, yəni təmir sifarişinin cari vəziyyəti (məsələn, "gözləyir", "təmir olunur", "tamamlandı" və s.).
    /// Diqqət: Status boş ola bilməz və yalnız müəyyən edilmiş dəyərləri qəbul etməlidir.
    /// Qeyd: Status, təmir prosesinin mərhələsini izləmək və müştəriyə məlumat vermək üçün vacibdir.
    /// </summary>
    public TemirStatusu Status { get; set; }

    // Xərclər
    /// <summary>
    /// Təmir xərci, yəni təmir prosesində istifadə olunan ehtiyat hissələri və xidmətlərin ümumi dəyəri.
    /// Diqqət: Təmir xərci boş ola bilməz və müsbət bir dəyər olmalıdır.
    /// Qeyd: Təmir xərci, müştəriyə təqdim ediləcək ümumi məbləği və təmir prosesinin maliyyə aspektlərini izləmək üçün vacibdir.
    /// </summary>
    public decimal TemirXerci { get; set; }
    /// <summary>
    /// Yekun məbləğ, yəni müştərinin ödəməli olduğu ümumi məbləğ (təmir xərci + əlavə xidmətlər və s.).
    /// Diqqət: Yekun məbləğ boş ola bilməz və müsbət bir dəyər olmalıdır.
    /// Qeyd: Yekun məbləğ, müştəriyə təqdim ediləcək ümumi məbləği və təmir prosesinin maliyyə aspektlərini izləmək üçün vacibdir.
    /// </summary>
    public decimal YekunMebleg { get; set; }

    // Əlaqəli İşçi
    /// <summary>
    /// İşçi ID-si, yəni təmir sifarişini qəbul edən və ya idarə edən işçinin unikal identifikatoru.
    /// Diqqət: İşçi ID-si boş ola bilər, çünki bəzi təmir sifarişləri işçi tərəfindən hələ qəbul edilməmiş ola bilər.
    /// Qeyd: İşçi ID-si, təmir sifarişinin hansı işçi tərəfindən qəbul edildiyini və ya idarə edildiyini izləmək üçün vacibdir.
    /// </summary>
    public int? IsciId { get; set; }
    /// <summary>
    /// İşçi, yəni təmir sifarişini qəbul edən və ya idarə edən işçi haqqında məlumatları saxlayır.
    /// Diqqət: Bu sahə boş ola bilər, çünki bəzi təmir sifarişləri işçi tərəfindən hələ qəbul edilməmiş ola bilər.
    /// Qeyd: İşçi məlumatları, istifadəçinin adını, soyadını, telefon nömrəsini və digər əlaqəli məlumatları ehtiva edə bilər.
    /// </summary>
    public Istifadeci? Isci { get; set; }
}