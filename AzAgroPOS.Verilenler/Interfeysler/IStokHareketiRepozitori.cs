// Fayl: AzAgroPOS.Verilenler/Interfeysler/IStokHareketiRepozitori.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler
{
    /// <summary>
    /// StokHareketi varlığı üçün xüsusi repozitori interfeysi
    /// diqqət: Bu interfeys, anbar stok hərəkətləri ilə bağlı xüsusi əməliyyatları təyin edir.
    /// qeyd: Ümumi CRUD əməliyyatları IRepozitori<StokHareketi> interfeysdən miras alınır.
    /// </summary>
    public interface IStokHareketiRepozitori : IRepozitori<StokHareketi>
    {
        /// <summary>
        /// Məhsulun anbar qalığını hesablayır
        /// diqqət: Bu metod, məhsulun bütün daxilolma və çıxış hərəkətlərini toplayaraq cari qalığı hesablayır.
        /// qeyd: Qalıq = Daxilolmalar - Çıxışlar
        /// </summary>
        /// <param name="mehsulId">Məhsulun ID-si</param>
        /// <returns>Məhsulun cari anbar qalığı</returns>
        Task<int> MehsulQaliginHesabla(int mehsulId);

        /// <summary>
        /// Məhsulun bütün stok hərəkətlərini tarix aralığında gətirir
        /// diqqət: Bu metod, məhsulun müəyyən tarix aralığındakı bütün hərəkətlərini qaytarır.
        /// qeyd: Hesabat və audit üçün istifadə olunur.
        /// </summary>
        /// <param name="mehsulId">Məhsulun ID-si</param>
        /// <param name="baslangicTarixi">Başlanğıc tarixi</param>
        /// <param name="bitisTarixi">Bitmə tarixi</param>
        /// <returns>Stok hərəkətləri siyahısı</returns>
        Task<IEnumerable<StokHareketi>> MehsulHereketleriniGetir(int mehsulId, DateTime? baslangicTarixi = null, DateTime? bitisTarixi = null);

        /// <summary>
        /// Sənədə əsasən stok hərəkətlərini gətirir
        /// diqqət: Bu metod, müəyyən bir sənədə (məsələn, alış sənədi, satış sənədi) aid hərəkətləri qaytarır.
        /// qeyd: Sənədin təsirini anbar üzərində izləmək üçün istifadə olunur.
        /// </summary>
        /// <param name="senedNovu">Sənədin növü (Alış, Satış və s.)</param>
        /// <param name="senedId">Sənədin ID-si</param>
        /// <returns>Sənədə aid stok hərəkətləri siyahısı</returns>
        Task<IEnumerable<StokHareketi>> SenedHereketleriniGetir(SenedNovu senedNovu, int senedId);

        /// <summary>
        /// Bütün məhsulların anbar qalıqlarını hesablayır
        /// diqqət: Bu metod, sistemdəki bütün məhsulların cari anbar qalıqlarını hesablayır.
        /// qeyd: Performance baxımından yalnız lazım olduqda istifadə edilməlidir.
        /// </summary>
        /// <returns>Məhsul ID-si və qalığı cütləri</returns>
        Task<Dictionary<int, int>> ButunMehsulQaliqlariniHesabla();

        /// <summary>
        /// Tarix aralığında bütün stok hərəkətlərini gətirir
        /// diqqət: Bu metod, müəyyən tarix aralığındakı bütün stok hərəkətlərini qaytarır.
        /// qeyd: Geniş hesabatlar və audit üçün istifadə olunur.
        /// </summary>
        /// <param name="baslangicTarixi">Başlanğıc tarixi</param>
        /// <param name="bitisTarixi">Bitmə tarixi</param>
        /// <returns>Stok hərəkətləri siyahısı</returns>
        Task<IEnumerable<StokHareketi>> TarixAraligindaHereketleriGetir(DateTime baslangicTarixi, DateTime bitisTarixi);
    }
}
