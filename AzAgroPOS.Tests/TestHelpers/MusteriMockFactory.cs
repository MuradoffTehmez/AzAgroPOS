// Fayl: AzAgroPOS.Tests/TestHelpers/MusteriMockFactory.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Tests.TestHelpers;

/// <summary>
/// Test üçün Müştəri mock data factory
/// </summary>
public static class MusteriMockFactory
{
    /// <summary>
    /// Valid Musteri entity yaradır
    /// </summary>
    public static Musteri CreateValid(int id = 1)
    {
        return new Musteri
        {
            Id = id,
            TamAd = $"Test Müştəri {id}",
            TelefonNomresi = $"+994501234{id:D3}",
            Email = $"test{id}@azagropos.az",
            Unvan = $"Bakı şəhəri, Test küçəsi {id}",
            KreditLimiti = 1000m,
            UmumiBorc = 0m,
            BonusBalans = 0m,
            Silinib = false,
            YaradilmaTarixi = DateTime.Now.AddDays(-60),
            YaradanIstifadeciId = 1
        };
    }

    /// <summary>
    /// Valid MusteriDto yaradır
    /// </summary>
    public static MusteriDto CreateValidDto(int id = 1)
    {
        return new MusteriDto
        {
            Id = id,
            TamAd = $"Test Müştəri {id}",
            TelefonNomresi = $"+994501234{id:D3}",
            Email = $"test{id}@azagropos.az",
            Unvan = $"Bakı şəhəri, Test küçəsi {id}",
            KreditLimiti = 1000m,
            UmumiBorc = 0m
        };
    }

    /// <summary>
    /// Müştəri siyahısı yaradır
    /// </summary>
    public static List<Musteri> CreateList(int count = 10)
    {
        return Enumerable.Range(1, count)
            .Select(i => CreateValid(i))
            .ToList();
    }

    /// <summary>
    /// Borc olan müştəri yaradır
    /// </summary>
    public static Musteri CreateWithDebt(int id = 1, decimal debt = 500m)
    {
        var musteri = CreateValid(id);
        musteri.UmumiBorc = debt;
        return musteri;
    }

    /// <summary>
    /// Kredit limitinə çatmış müştəri yaradır
    /// </summary>
    public static Musteri CreateAtCreditLimit(int id = 1)
    {
        var musteri = CreateValid(id);
        musteri.KreditLimiti = 1000m;
        musteri.UmumiBorc = 1000m;
        return musteri;
    }

    /// <summary>
    /// Kredit limiti keçmiş müştəri yaradır (test üçün)
    /// </summary>
    public static Musteri CreateOverCreditLimit(int id = 1)
    {
        var musteri = CreateValid(id);
        musteri.KreditLimiti = 1000m;
        musteri.UmumiBorc = 1200m; // Over limit
        return musteri;
    }

    /// <summary>
    /// Bonus balansı olan müştəri yaradır
    /// </summary>
    public static Musteri CreateWithBonus(int id = 1, decimal bonus = 50m)
    {
        var musteri = CreateValid(id);
        musteri.BonusBalans = bonus;
        return musteri;
    }

    /// <summary>
    /// Silinmiş müştəri yaradır
    /// </summary>
    public static Musteri CreateDeleted(int id = 1)
    {
        var musteri = CreateValid(id);
        musteri.Silinib = true;
        musteri.SilinmeTarixi = DateTime.Now;
        musteri.SilenIstifadeciId = 1;
        return musteri;
    }
}
