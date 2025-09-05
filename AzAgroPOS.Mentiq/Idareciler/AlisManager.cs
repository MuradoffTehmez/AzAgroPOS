// Fayl: AzAgroPOS.Mentiq/Idareciler/AlisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Alış prosesini idarə edən menecer.
/// Bu menecer tədarükçülərin qeydiyyatı, alış sifarişlərinin yaradılması, 
/// mal qəbulu və tədarükçülərə olan borcların uçotunu həyata keçirir.
/// </summary>
public class AlisManager
{
    private readonly IUnitOfWork _unitOfWork;

    public AlisManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Tədarükçü Əməliyyatları

    /// <summary>
    /// Bütün tədarükçüləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<TedarukcuDto>>> ButunTedarukculeriGetirAsync()
    {
        try
        {
            var tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            var dtolar = tedarukculer.Select(t => new TedarukcuDto
            {
                Id = t.Id,
                Ad = t.Ad,
                Voen = t.Voen,
                Unvan = t.Unvan,
                Telefon = t.Telefon,
                Email = t.Email,
                BankHesabi = t.BankHesabi,
                Aktivdir = t.Aktivdir
            }).ToList();

            return EmeliyyatNeticesi<List<TedarukcuDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<TedarukcuDto>>.Ugursuz($"Tədarükçüləri gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə tədarükçü məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<TedarukcuDto>> TedarukcuGetirAsync(int id)
    {
        try
        {
            var tedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(id);
            if (tedarukcu == null)
                return EmeliyyatNeticesi<TedarukcuDto>.Ugursuz("Tədarükçü tapılmadı.");

            var dto = new TedarukcuDto
            {
                Id = tedarukcu.Id,
                Ad = tedarukcu.Ad,
                Voen = tedarukcu.Voen,
                Unvan = tedarukcu.Unvan,
                Telefon = tedarukcu.Telefon,
                Email = tedarukcu.Email,
                BankHesabi = tedarukcu.BankHesabi,
                Aktivdir = tedarukcu.Aktivdir
            };

            return EmeliyyatNeticesi<TedarukcuDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<TedarukcuDto>.Ugursuz($"Tədarükçü məlumatlarını gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni tədarükçü yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> TedarukcuYaratAsync(TedarukcuDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü adı boş ola bilməz.");

            // Yeni tədarükçü obyekti yaradırıq
            var yeniTedarukcu = new Tedarukcu
            {
                Ad = dto.Ad,
                Voen = dto.Voen,
                Unvan = dto.Unvan,
                Telefon = dto.Telefon,
                Email = dto.Email,
                BankHesabi = dto.BankHesabi,
                Aktivdir = dto.Aktivdir
            };

            await _unitOfWork.Tedarukculer.ElaveEtAsync(yeniTedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniTedarukcu.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Tədarükçü yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Mövcud tədarükçünün məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuYenileAsync(TedarukcuDto dto)
    {
        try
        {
            var movcudTedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(dto.Id);
            if (movcudTedarukcu == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün tədarükçü tapılmadı.");

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi.Ugursuz("Tədarükçü adı boş ola bilməz.");

            // Məlumatları yeniləyirik
            movcudTedarukcu.Ad = dto.Ad;
            movcudTedarukcu.Voen = dto.Voen;
            movcudTedarukcu.Unvan = dto.Unvan;
            movcudTedarukcu.Telefon = dto.Telefon;
            movcudTedarukcu.Email = dto.Email;
            movcudTedarukcu.BankHesabi = dto.BankHesabi;
            movcudTedarukcu.Aktivdir = dto.Aktivdir;

            _unitOfWork.Tedarukculer.Yenile(movcudTedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü məlumatlarını yeniləmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Tədarükçü silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuSilAsync(int id)
    {
        try
        {
            var tedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(id);
            if (tedarukcu == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək tədarükçü tapılmadı.");

            _unitOfWork.Tedarukculer.Sil(tedarukcu);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Tədarükçü silmək alınmadı: {ex.Message}");
        }
    }

    #endregion

    #region Alış Sifarişi Əməliyyatları

    /// <summary>
    /// Bütün alış sifarişlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<AlisSifarisDto>>> ButunAlisSifarisleriniGetirAsync()
    {
        try
        {
            var sifarisler = await _unitOfWork.AlisSifarisleri.ButununuGetirAsync();
            var tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            
            var dtolar = sifarisler.Select(s => new AlisSifarisDto
            {
                Id = s.Id,
                SifarisNomresi = s.SifarisNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TesdiqTarixi = s.TesdiqTarixi,
                GozlenilenTehvilTarixi = s.GozlenilenTehvilTarixi,
                FaktikiTehvilTarixi = s.FaktikiTehvilTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler
            }).ToList();

            return EmeliyyatNeticesi<List<AlisSifarisDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<AlisSifarisDto>>.Ugursuz($"Alış sifarişlərini gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə alış sifarişi məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<AlisSifarisDto>> AlisSifarisGetirAsync(int id)
    {
        try
        {
            var sifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(id);
            if (sifaris == null)
                return EmeliyyatNeticesi<AlisSifarisDto>.Ugursuz("Alış sifarişi tapılmadı.");

            var tedarukcu = await _unitOfWork.Tedarukculer.GetirAsync(sifaris.TedarukcuId);
            var sifarisSetirleri = await _unitOfWork.AlisSifarisSetirleri.AxtarAsync(s => s.AlisSifarisId == sifaris.Id);
            var mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();

            var dto = new AlisSifarisDto
            {
                Id = sifaris.Id,
                SifarisNomresi = sifaris.SifarisNomresi,
                YaradilmaTarixi = sifaris.YaradilmaTarixi,
                TesdiqTarixi = sifaris.TesdiqTarixi,
                GozlenilenTehvilTarixi = sifaris.GozlenilenTehvilTarixi,
                FaktikiTehvilTarixi = sifaris.FaktikiTehvilTarixi,
                TedarukcuId = sifaris.TedarukcuId,
                TedarukcuAdi = tedarukcu?.Ad ?? "Naməlum",
                UmumiMebleg = sifaris.UmumiMebleg,
                Status = sifaris.Status,
                Qeydler = sifaris.Qeydler,
                SifarisSetirleri = sifarisSetirleri.Select(s => new AlisSifarisSetiriDto
                {
                    Id = s.Id,
                    AlisSifarisId = s.AlisSifarisId,
                    MehsulId = s.MehsulId,
                    MehsulAdi = mehsullar.FirstOrDefault(m => m.Id == s.MehsulId)?.Ad ?? "Naməlum",
                    Miqdar = s.Miqdar,
                    BirVahidQiymet = s.BirVahidQiymet,
                    CemiMebleg = s.CemiMebleg,
                    TehvilAlinanMiqdar = s.TehvilAlinanMiqdar,
                    QalanMiqdar = s.QalanMiqdar
                }).ToList()
            };

            return EmeliyyatNeticesi<AlisSifarisDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<AlisSifarisDto>.Ugursuz($"Alış sifarişi məlumatlarını gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni alış sifarişi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> AlisSifarisYaratAsync(AlisSifarisDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SifarisNomresi))
                return EmeliyyatNeticesi<int>.Ugursuz("Sifariş nömrəsi boş ola bilməz.");

            if (dto.TedarukcuId <= 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");

            // Yeni alış sifarişi obyekti yaradırıq
            var yeniSifaris = new AlisSifaris
            {
                SifarisNomresi = dto.SifarisNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TesdiqTarixi = dto.TesdiqTarixi,
                GozlenilenTehvilTarixi = dto.GozlenilenTehvilTarixi,
                TedarukcuId = dto.TedarukcuId,
                UmumiMebleg = dto.UmumiMebleg,
                Status = dto.Status,
                Qeydler = dto.Qeydler
            };

            await _unitOfWork.AlisSifarisleri.ElaveEtAsync(yeniSifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Sifariş sətirlərini yaradırıq
            foreach (var setirDto in dto.SifarisSetirleri)
            {
                var setir = new AlisSifarisSetiri
                {
                    AlisSifarisId = yeniSifaris.Id,
                    MehsulId = setirDto.MehsulId,
                    Miqdar = setirDto.Miqdar,
                    BirVahidQiymet = setirDto.BirVahidQiymet,
                    CemiMebleg = setirDto.CemiMebleg,
                    TehvilAlinanMiqdar = setirDto.TehvilAlinanMiqdar
                };

                await _unitOfWork.AlisSifarisSetirleri.ElaveEtAsync(setir);
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniSifaris.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Alış sifarişi yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Alış sifarişini təsdiqləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> AlisSifarisiniTesdiqleAsync(int id)
    {
        try
        {
            var sifaris = await _unitOfWork.AlisSifarisleri.GetirAsync(id);
            if (sifaris == null)
                return EmeliyyatNeticesi.Ugursuz("Təsdiqlənmək üçün alış sifarişi tapılmadı.");

            if (sifaris.Status != AlisSifarisStatusu.Yaradildi)
                return EmeliyyatNeticesi.Ugursuz("Yalnız yaradılmış sifarişləri təsdiqləmək olar.");

            sifaris.Status = AlisSifarisStatusu.Tesdiqlendi;
            sifaris.TesdiqTarixi = DateTime.Now;

            _unitOfWork.AlisSifarisleri.Yenile(sifaris);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Alış sifarişini təsdiqləmək alınmadı: {ex.Message}");
        }
    }

    #endregion

    #region Alış Sənədi Əməliyyatları

    /// <summary>
    /// Bütün alış sənədlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<AlisSenedDto>>> ButunAlisSenetleriniGetirAsync()
    {
        try
        {
            var senetler = await _unitOfWork.AlisSenetleri.ButununuGetirAsync();
            var tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            
            var dtolar = senetler.Select(s => new AlisSenedDto
            {
                Id = s.Id,
                SenedNomresi = s.SenedNomresi,
                YaradilmaTarixi = s.YaradilmaTarixi,
                TedarukcuId = s.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == s.TedarukcuId)?.Ad ?? "Naməlum",
                TehvilTarixi = s.TehvilTarixi,
                UmumiMebleg = s.UmumiMebleg,
                Status = s.Status,
                Qeydler = s.Qeydler
            }).ToList();

            return EmeliyyatNeticesi<List<AlisSenedDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<AlisSenedDto>>.Ugursuz($"Alış sənədlərini gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni alış sənədi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> AlisSenedYaratAsync(AlisSenedDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.SenedNomresi))
                return EmeliyyatNeticesi<int>.Ugursuz("Sənəd nömrəsi boş ola bilməz.");

            if (dto.TedarukcuId <= 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");

            // Yeni alış sənədi obyekti yaradırıq
            var yeniSened = new AlisSened
            {
                SenedNomresi = dto.SenedNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TedarukcuId = dto.TedarukcuId,
                TehvilTarixi = dto.TehvilTarixi,
                UmumiMebleg = dto.UmumiMebleg,
                Status = dto.Status,
                Qeydler = dto.Qeydler
            };

            await _unitOfWork.AlisSenetleri.ElaveEtAsync(yeniSened);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            // Sənəd sətirlərini yaradırıq
            foreach (var setirDto in dto.SenedSetirleri)
            {
                var setir = new AlisSenedSetiri
                {
                    AlisSenedId = yeniSened.Id,
                    MehsulId = setirDto.MehsulId,
                    Miqdar = setirDto.Miqdar,
                    BirVahidQiymet = setirDto.BirVahidQiymet,
                    CemiMebleg = setirDto.CemiMebleg,
                    AlisSifarisSetiriId = setirDto.AlisSifarisSetiriId
                };

                await _unitOfWork.AlisSenedSetirleri.ElaveEtAsync(setir);

                // Məhsulun anbar miqdarını artırırıq
                var mehsul = await _unitOfWork.Mehsullar.GetirAsync(setirDto.MehsulId);
                if (mehsul != null)
                {
                    mehsul.MovcudSay += (int)setirDto.Miqdar;
                    mehsul.AlisQiymeti = setirDto.BirVahidQiymet;
                    _unitOfWork.Mehsullar.Yenile(mehsul);
                }
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniSened.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Alış sənədi yaratmaq alınmadı: {ex.Message}");
        }
    }

    #endregion

    #region Tədarükçü Ödənişi Əməliyyatları

    /// <summary>
    /// Bütün tədarükçü ödənişlərini DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<TedarukcuOdemeDto>>> ButunTedarukcuOdemeleriniGetirAsync()
    {
        try
        {
            var odemeler = await _unitOfWork.TedarukcuOdemeleri.ButununuGetirAsync();
            var tedarukculer = await _unitOfWork.Tedarukculer.ButununuGetirAsync();
            var senetler = await _unitOfWork.AlisSenetleri.ButununuGetirAsync();
            
            var dtolar = odemeler.Select(o => new TedarukcuOdemeDto
            {
                Id = o.Id,
                OdemeNomresi = o.OdemeNomresi,
                YaradilmaTarixi = o.YaradilmaTarixi,
                TedarukcuId = o.TedarukcuId,
                TedarukcuAdi = tedarukculer.FirstOrDefault(t => t.Id == o.TedarukcuId)?.Ad ?? "Naməlum",
                AlisSenedId = o.AlisSenedId,
                AlisSenedNomresi = o.AlisSenedId.HasValue ? senetler.FirstOrDefault(s => s.Id == o.AlisSenedId.Value)?.SenedNomresi : null,
                OdemeTarixi = o.OdemeTarixi,
                Mebleg = o.Mebleg,
                OdemeUsulu = o.OdemeUsulu,
                Status = o.Status,
                Qeydler = o.Qeydler,
                BankMelumatlari = o.BankMelumatlari
            }).ToList();

            return EmeliyyatNeticesi<List<TedarukcuOdemeDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<TedarukcuOdemeDto>>.Ugursuz($"Tədarükçü ödənişlərini gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni tədarükçü ödənişi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> TedarukcuOdemeYaratAsync(TedarukcuOdemeDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.OdemeNomresi))
                return EmeliyyatNeticesi<int>.Ugursuz("Ödəniş nömrəsi boş ola bilməz.");

            if (dto.TedarukcuId <= 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Tədarükçü seçilməlidir.");

            if (dto.Mebleg <= 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Ödəniş məbləği müsbət olmalıdır.");

            // Yeni tədarükçü ödənişi obyekti yaradırıq
            var yeniOdeme = new TedarukcuOdeme
            {
                OdemeNomresi = dto.OdemeNomresi,
                YaradilmaTarixi = dto.YaradilmaTarixi,
                TedarukcuId = dto.TedarukcuId,
                AlisSenedId = dto.AlisSenedId,
                OdemeTarixi = dto.OdemeTarixi,
                Mebleg = dto.Mebleg,
                OdemeUsulu = dto.OdemeUsulu,
                Status = dto.Status,
                Qeydler = dto.Qeydler,
                BankMelumatlari = dto.BankMelumatlari
            };

            await _unitOfWork.TedarukcuOdemeleri.ElaveEtAsync(yeniOdeme);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniOdeme.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Tədarükçü ödənişi yaratmaq alınmadı: {ex.Message}");
        }
    }

    #endregion
}