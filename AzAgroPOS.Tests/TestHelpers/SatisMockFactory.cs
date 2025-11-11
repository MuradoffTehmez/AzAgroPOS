// Fayl: AzAgroPOS.Tests/TestHelpers/SatisMockFactory.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Tests.TestHelpers;

/// <summary>
/// Test üçün Satış mock data factory
/// </summary>
public static class SatisMockFactory
{
    /// <summary>
    /// Valid Satis entity yaradır
    /// </summary>
    public static Satis CreateValid(int id = 1, int? musteriId = null, int novbeId = 1)
    {
        return new Satis
        {
            Id = id,
            NovbeId = novbeId,
            MusteriId = musteriId,
            OdenisMetodu = OdenisMetodu.Negd,
            UmumiMebleg = 100m,
            Endirim = 0m,
            YekunMebleg = 100m,
            Tarix = DateTime.Now,
            Qeyd = $"Test satış {id}",
            Silinib = false,
            YaradilmaTarixi = DateTime.Now,
            YaradanIstifadeciId = 1
        };
    }

    /// <summary>
    /// SatisDetali ilə birlikdə satış yaradır
    /// </summary>
    public static Satis CreateWithDetails(int id = 1, int mehsulId = 1, int miqdar = 2)
    {
        var satis = CreateValid(id);
        satis.SatisDetallari = new List<SatisDetali>
        {
            new SatisDetali
            {
                Id = 1,
                SatisId = id,
                MehsulId = mehsulId,
                Miqdar = miqdar,
                VahidinQiymeti = 50m,
                UmumiMebleg = miqdar * 50m,
                Endirim = 0m
            }
        };
        satis.UmumiMebleg = miqdar * 50m;
        satis.YekunMebleg = miqdar * 50m;
        return satis;
    }

    /// <summary>
    /// Valid SatisYaratDto yaradır
    /// </summary>
    public static SatisYaratDto CreateValidYaratDto(int novbeId = 1)
    {
        return new SatisYaratDto
        {
            NovbeId = novbeId,
            MusteriId = null,
            OdenisMetodu = OdenisMetodu.Negd,
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    Miqdar = 2,
                    VahidinQiymeti = 50m,
                    UmumiMebleg = 100m
                }
            },
            UmumiMebleg = 100m,
            Endirim = 0m,
            YekunMebleg = 100m,
            Qeyd = "Test satış"
        };
    }

    /// <summary>
    /// Nəğdsiz ödəniş ilə satış yaradır
    /// </summary>
    public static Satis CreateCashless(int id = 1)
    {
        var satis = CreateValid(id);
        satis.OdenisMetodu = OdenisMetodu.Kart;
        return satis;
    }

    /// <summary>
    /// Nisyə ilə satış yaradır
    /// </summary>
    public static Satis CreateCredit(int id = 1, int musteriId = 1)
    {
        var satis = CreateValid(id, musteriId);
        satis.OdenisMetodu = OdenisMetodu.Nisye;
        return satis;
    }

    /// <summary>
    /// Endirimlə satış yaradır
    /// </summary>
    public static Satis CreateWithDiscount(int id = 1, decimal endirim = 10m)
    {
        var satis = CreateValid(id);
        satis.UmumiMebleg = 100m;
        satis.Endirim = endirim;
        satis.YekunMebleg = 100m - endirim;
        return satis;
    }

    /// <summary>
    /// Çox məhsullu satış yaradır
    /// </summary>
    public static Satis CreateWithMultipleProducts(int id = 1)
    {
        var satis = CreateValid(id);
        satis.SatisDetallari = new List<SatisDetali>
        {
            new SatisDetali
            {
                Id = 1,
                SatisId = id,
                MehsulId = 1,
                Miqdar = 2,
                VahidinQiymeti = 50m,
                UmumiMebleg = 100m
            },
            new SatisDetali
            {
                Id = 2,
                SatisId = id,
                MehsulId = 2,
                Miqdar = 3,
                VahidinQiymeti = 30m,
                UmumiMebleg = 90m
            },
            new SatisDetali
            {
                Id = 3,
                SatisId = id,
                MehsulId = 3,
                Miqdar = 1,
                VahidinQiymeti = 20m,
                UmumiMebleg = 20m
            }
        };
        satis.UmumiMebleg = 210m;
        satis.YekunMebleg = 210m;
        return satis;
    }

    /// <summary>
    /// Silinmiş satış yaradır
    /// </summary>
    public static Satis CreateDeleted(int id = 1)
    {
        var satis = CreateValid(id);
        satis.Silinib = true;
        satis.SilinmeTarixi = DateTime.Now;
        satis.SilenIstifadeciId = 1;
        return satis;
    }
}
