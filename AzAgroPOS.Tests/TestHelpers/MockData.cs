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
            OlcuVahidi = "Ədəd",
            Silinib = false
        };
    }

    public static Musteri CreateMusteri(int id = 1, string ad = "Test Müştəri")
    {
        return new Musteri
        {
            Id = id,
            TamAd = ad,
            TelefonNomresi = "+994501234567",
            Email = $"test{id}@example.com",
            Unvan = "Test ünvanı",
            KreditLimiti = 1000m,
            UmumiBorc = 0m,
            BonusXali = 0,
            Silinib = false
        };
    }

    public static Tedarukcu CreateTedarukcu(int id = 1, string ad = "Test Tədarükçü")
    {
        return new Tedarukcu
        {
            Id = id,
            Ad = ad,
            ElaqeNomresi = "+994501234567",
            Email = $"tedarukcu{id}@example.com",
            Unvan = "Test ünvanı",
            UmumiBorc = 0m,
            Silinib = false
        };
    }

    public static Rol CreateRol(int id = 1, string ad = "Test Rol")
    {
        return new Rol
        {
            Id = id,
            Ad = ad,
            Izahlar = $"{ad} rolu",
            Silinib = false
        };
    }

    public static Istifadeci CreateIstifadeci(int id = 1, string istifadeciAdi = "testuser", int rolId = 1)
    {
        return new Istifadeci
        {
            Id = id,
            IstifadeciAdi = istifadeciAdi,
            TamAd = "Test İstifadəçi",
            SifreHash = BCrypt.Net.BCrypt.HashPassword("test123"),
            RolId = rolId,
            Email = $"{istifadeciAdi}@test.com",
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

    public static List<Musteri> CreateMusteriList(int count = 5)
    {
        var list = new List<Musteri>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateMusteri(i, $"Müştəri {i}"));
        }
        return list;
    }
}
