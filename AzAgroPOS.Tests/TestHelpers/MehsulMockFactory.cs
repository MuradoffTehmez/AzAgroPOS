// Fayl: AzAgroPOS.Tests/TestHelpers/MehsulMockFactory.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Tests.TestHelpers;

/// <summary>
/// Test üçün Məhsul mock data factory
/// </summary>
public static class MehsulMockFactory
{
    /// <summary>
    /// Valid Mehsul entity yaradır
    /// </summary>
    public static Mehsul CreateValid(int id = 1)
    {
        return new Mehsul
        {
            Id = id,
            Ad = $"Test Məhsul {id}",
            StokKodu = $"STK{id:D6}",
            Barkod = $"1234567890{id:D3}",
            PerakendeSatisQiymeti = 20.00m,
            TopdanSatisQiymeti = 15.00m,
            TekEdedSatisQiymeti = 18.00m,
            AlisQiymeti = 10.50m,
            MovcudSay = 100,
            MinimumStok = 10,
            OlcuVahidi = OlcuVahidi.Ədəd,
            Silinib = false,
            YaradilmaTarixi = DateTime.Now.AddDays(-30),
            YaradanIstifadeciId = 1
        };
    }

    /// <summary>
    /// Valid MehsulDto yaradır
    /// </summary>
    public static MehsulDto CreateValidDto(int id = 1)
    {
        return new MehsulDto
        {
            Id = id,
            Ad = $"Test Məhsul {id}",
            StokKodu = $"STK{id:D6}",
            Barkod = $"1234567890{id:D3}",
            PerakendeSatisQiymeti = 20.00m,
            TopdanSatisQiymeti = 15.00m,
            TekEdedSatisQiymeti = 18.00m,
            AlisQiymeti = 10.50m,
            MovcudSay = 100,
            MinimumStok = 10,
            OlcuVahidi = OlcuVahidi.Ədəd
        };
    }

    /// <summary>
    /// Məhsul siyahısı yaradır
    /// </summary>
    public static List<Mehsul> CreateList(int count = 10)
    {
        return Enumerable.Range(1, count)
            .Select(i => CreateValid(i))
            .ToList();
    }

    /// <summary>
    /// Stokda olmayan məhsul yaradır (test üçün)
    /// </summary>
    public static Mehsul CreateOutOfStock(int id = 1)
    {
        var mehsul = CreateValid(id);
        mehsul.MovcudSay = 0;
        return mehsul;
    }

    /// <summary>
    /// Minimum stokun altında olan məhsul yaradır
    /// </summary>
    public static Mehsul CreateLowStock(int id = 1)
    {
        var mehsul = CreateValid(id);
        mehsul.MovcudSay = 5;
        mehsul.MinimumStok = 10;
        return mehsul;
    }

    /// <summary>
    /// Silinmiş məhsul yaradır
    /// </summary>
    public static Mehsul CreateDeleted(int id = 1)
    {
        var mehsul = CreateValid(id);
        mehsul.Silinib = true;
        mehsul.SilinmeTarixi = DateTime.Now;
        mehsul.SilenIstifadeciId = 1;
        return mehsul;
    }
}
