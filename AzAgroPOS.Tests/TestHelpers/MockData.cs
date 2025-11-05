// Fayl: AzAgroPOS.Tests/TestHelpers/MockData.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Tests.TestHelpers;

/// <summary>
/// Test üçün mock data yaradır
/// </summary>
public static class MockData
{
    public static Mehsul CreateMehsul(int id = 1, string ad = "Test Məhsul", string stokKodu = "TEST001")
    {
        return new Mehsul
        {
            Id = id,
            Ad = ad,
            StokKodu = stokKodu,
            Barkod = $"BAR{id:D6}",
            PerakendeSatisQiymeti = 100m,
            TopdanSatisQiymeti = 80m,
            TekEdedSatisQiymeti = 95m,
            AlisQiymeti = 60m,
            MovcudSay = 50,
            OlcuVahidi = OlcuVahidi.Ədəd,
            Silinib = false
        };
    }

    public static List<Mehsul> CreateMehsulList(int count = 5)
    {
        var list = new List<Mehsul>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateMehsul(i, $"Məhsul {i}", $"TEST{i:D3}"));
        }
        return list;
    }
}
