// Fayl: AzAgroPOS.Verilenler/Realizasialar/StokHareketiRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    /// <summary>
    /// StokHareketi varlığı üçün repozitori realizasiyası
    /// diqqət: Bu sinif, anbar stok hərəkətləri ilə bağlı verilənlər bazası əməliyyatlarını yerinə yetirir.
    /// qeyd: Ümumi CRUD əməliyyatları Repozitori<StokHareketi> bazasından miras alınır.
    /// </summary>
    public class StokHareketiRepozitori : Repozitori<StokHareketi>, IStokHareketiRepozitori
    {
        public StokHareketiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
        {
        }

        /// <summary>
        /// Məhsulun anbar qalığını hesablayır
        /// diqqət: Daxilolmalar (+) və çıxışlar (-) toplanaraq qalıq tapılır.
        /// qeyd: Bu metod yalnız aktiv (silinməmiş) hərəkətləri nəzərə alır.
        /// </summary>
        public async Task<int> MehsulQaliginHesabla(int mehsulId)
        {
            var daxilolmalar = await _dbSet
                .Where(sh => sh.MehsulId == mehsulId &&
                            sh.HareketTipi == StokHareketTipi.Daxilolma &&
                            !sh.Silinib)
                .SumAsync(sh => sh.Miqdar);

            var cixislar = await _dbSet
                .Where(sh => sh.MehsulId == mehsulId &&
                            sh.HareketTipi == StokHareketTipi.Cixis &&
                            !sh.Silinib)
                .SumAsync(sh => sh.Miqdar);

            return daxilolmalar - cixislar;
        }

        /// <summary>
        /// Məhsulun bütün stok hərəkətlərini tarix aralığında gətirir
        /// diqqət: Tarix parametrləri null olarsa, bütün hərəkətlər qaytarılır.
        /// qeyd: Hərəkətlər tarix üzrə artan qaydada sıralanır.
        /// </summary>
        public async Task<IEnumerable<StokHareketi>> MehsulHereketleriniGetir(
            int mehsulId,
            DateTime? baslangicTarixi = null,
            DateTime? bitisTarixi = null)
        {
            var query = _dbSet
                .Where(sh => sh.MehsulId == mehsulId && !sh.Silinib)
                .Include(sh => sh.Mehsul)
                .Include(sh => sh.Istifadeci)
                .AsQueryable();

            if (baslangicTarixi.HasValue)
            {
                query = query.Where(sh => sh.Tarix >= baslangicTarixi.Value);
            }

            if (bitisTarixi.HasValue)
            {
                query = query.Where(sh => sh.Tarix <= bitisTarixi.Value);
            }

            return await query.OrderBy(sh => sh.Tarix).ToListAsync();
        }

        /// <summary>
        /// Sənədə əsasən stok hərəkətlərini gətirir
        /// diqqət: Müəyyən bir sənədin (alış, satış və s.) anbar üzərindəki təsirini izləyir.
        /// qeyd: Related varlıqlar (Məhsul, İstifadəçi) daxil edilir.
        /// </summary>
        public async Task<IEnumerable<StokHareketi>> SenedHereketleriniGetir(
            SenedNovu senedNovu,
            int senedId)
        {
            return await _dbSet
                .Where(sh => sh.SenedNovu == senedNovu &&
                            sh.SenedId == senedId &&
                            !sh.Silinib)
                .Include(sh => sh.Mehsul)
                .Include(sh => sh.Istifadeci)
                .OrderBy(sh => sh.Tarix)
                .ToListAsync();
        }

        /// <summary>
        /// Bütün məhsulların anbar qalıqlarını hesablayır
        /// diqqət: Bu əməliyyat resource-intensive olduğundan ehtiyatla istifadə edilməlidir.
        /// qeyd: Nəticə Dictionary<MehsulId, Qaliq> formatında qaytarılır.
        /// </summary>
        public async Task<Dictionary<int, int>> ButunMehsulQaliqlariniHesabla()
        {
            var daxilolmalar = await _dbSet
                .Where(sh => sh.HareketTipi == StokHareketTipi.Daxilolma && !sh.Silinib)
                .GroupBy(sh => sh.MehsulId)
                .Select(g => new { MehsulId = g.Key, Miqdar = g.Sum(sh => sh.Miqdar) })
                .ToListAsync();

            var cixislar = await _dbSet
                .Where(sh => sh.HareketTipi == StokHareketTipi.Cixis && !sh.Silinib)
                .GroupBy(sh => sh.MehsulId)
                .Select(g => new { MehsulId = g.Key, Miqdar = g.Sum(sh => sh.Miqdar) })
                .ToListAsync();

            var qaliqlar = new Dictionary<int, int>();

            // Daxilolmaları əlavə et
            foreach (var item in daxilolmalar)
            {
                qaliqlar[item.MehsulId] = item.Miqdar;
            }

            // Çıxışları çıx
            foreach (var item in cixislar)
            {
                if (qaliqlar.ContainsKey(item.MehsulId))
                {
                    qaliqlar[item.MehsulId] -= item.Miqdar;
                }
                else
                {
                    qaliqlar[item.MehsulId] = -item.Miqdar;
                }
            }

            return qaliqlar;
        }

        /// <summary>
        /// Tarix aralığında bütün stok hərəkətlərini gətirir
        /// diqqət: Bu metod geniş hesabatlar üçün istifadə olunur.
        /// qeyd: Performans səbəbindən çox geniş tarix aralıqları tövsiyə olunmur.
        /// </summary>
        public async Task<IEnumerable<StokHareketi>> TarixAraligindaHereketleriGetir(
            DateTime baslangicTarixi,
            DateTime bitisTarixi)
        {
            return await _dbSet
                .Where(sh => sh.Tarix >= baslangicTarixi &&
                            sh.Tarix <= bitisTarixi &&
                            !sh.Silinib)
                .Include(sh => sh.Mehsul)
                .Include(sh => sh.Istifadeci)
                .OrderBy(sh => sh.Tarix)
                .ToListAsync();
        }
    }
}
