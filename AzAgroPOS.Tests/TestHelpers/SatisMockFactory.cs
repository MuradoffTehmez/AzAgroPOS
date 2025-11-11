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
            OdenisMetodu = OdenisMetodu.Nağd,
            UmumiMebleg = 100m,
            Tarix = DateTime.Now,
            Silinib = false,
            YaradilmaTarixi = DateTime.Now,
            YaradanIstifadeciId = 1
        };
    }

    /// <summary>
    /// SatisDetali ilə birlikdə satış yaradır
    /// </summary>
    public static Satis CreateWithDetails(int id = 1, int mehsulId = 1, decimal miqdar = 2)
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
                Qiymet = 50m,
                UmumiMebleg = miqdar * 50m
            }
        };
        satis.UmumiMebleg = miqdar * 50m;
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
            OdenisMetodu = OdenisMetodu.Nağd,
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    Miqdar = 2,
                    VahidinQiymeti = 50m,
                    MehsulAdi = "Test Məhsul"
                }
            },
            UmumiMebleg = 100m
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
        satis.OdenisMetodu = OdenisMetodu.Nisyə;
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
                Qiymet = 50m,
                UmumiMebleg = 100m
            },
            new SatisDetali
            {
                Id = 2,
                SatisId = id,
                MehsulId = 2,
                Miqdar = 3,
                Qiymet = 30m,
                UmumiMebleg = 90m
            },
            new SatisDetali
            {
                Id = 3,
                SatisId = id,
                MehsulId = 3,
                Miqdar = 1,
                Qiymet = 20m,
                UmumiMebleg = 20m
            }
        };
        satis.UmumiMebleg = 210m;
        return satis;
    }

    /// <summary>
    /// Silinmiş satış yaradır
    /// </summary>
    public static Satis CreateDeleted(int id = 1)
    {
        var satis = CreateValid(id);
        satis.Silinib = true;
        return satis;
    }
}
