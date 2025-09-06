// Fayl: AzAgroPOS.Mentiq/Idareciler/MehsulMeneceri.cs
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
/// Məhsul əməliyyatlarını idarə edən menecer.
/// Bu menecer məhsul yaratma, yeniləmə, silmə və axtarış əməliyyatlarını həyata keçirir.
/// </summary>
public class MehsulMeneceri
{
    private readonly IUnitOfWork _unitOfWork;

    public MehsulMeneceri(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün məhsulları DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> ButunMehsullariGetirAsync()
    {
        try
        {
            var mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();
            var dtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                Barkod = m.Barkod,
                StokKodu = m.StokKodu,
                AlisQiymeti = m.AlisQiymeti,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                MovcudSay = m.MovcudSay,
                Aktivdir = m.Aktivdir,
                OlcuVahidi = m.OlcuVahidi,
                AnbarMiqdari = m.MovcudSay,
                OlcuVahidiAdi = m.OlcuVahidi.ToString(),
                // Yeni əlavə edilən sahələr
                KateqoriyaId = m.KateqoriyaId,
                KateqoriyaAdi = m.Kateqoriya?.Ad,
                BrendId = m.BrendId,
                BrendAdi = m.Brend?.Ad,
                TedarukcuId = m.TedarukcuId,
                TedarukcuAdi = m.Tedarukcu?.Ad,
                MinimumStok = m.MinimumStok,
                SekilYolu = m.SekilYolu
            }).ToList();

            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz($"Məhsulları gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə məhsul məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<MehsulDto>> MehsulGetirAsync(int id)
    {
        try
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(id);
            if (mehsul == null)
                return EmeliyyatNeticesi<MehsulDto>.Ugursuz("Məhsul tapılmadı.");

            var dto = new MehsulDto
            {
                Id = mehsul.Id,
                Ad = mehsul.Ad,
                Barkod = mehsul.Barkod,
                StokKodu = mehsul.StokKodu,
                AlisQiymeti = mehsul.AlisQiymeti,
                PerakendeSatisQiymeti = mehsul.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = mehsul.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = mehsul.TekEdedSatisQiymeti,
                MovcudSay = mehsul.MovcudSay,
                Aktivdir = mehsul.Aktivdir,
                OlcuVahidi = mehsul.OlcuVahidi,
                AnbarMiqdari = mehsul.MovcudSay,
                OlcuVahidiAdi = mehsul.OlcuVahidi.ToString(),
                // Yeni əlavə edilən sahələr
                KateqoriyaId = mehsul.KateqoriyaId,
                KateqoriyaAdi = mehsul.Kateqoriya?.Ad,
                BrendId = mehsul.BrendId,
                BrendAdi = mehsul.Brend?.Ad,
                TedarukcuId = mehsul.TedarukcuId,
                TedarukcuAdi = mehsul.Tedarukcu?.Ad,
                MinimumStok = mehsul.MinimumStok,
                SekilYolu = mehsul.SekilYolu
            };

            return EmeliyyatNeticesi<MehsulDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<MehsulDto>.Ugursuz($"Məhsul məlumatlarını gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni məhsul yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul adı boş ola bilməz.");

            // Yeni məhsul obyekti yaradırıq
            var yeniMehsul = new Mehsul
            {
                Ad = dto.Ad,
                Barkod = dto.Barkod,
                StokKodu = dto.StokKodu,
                AlisQiymeti = dto.AlisQiymeti,
                PerakendeSatisQiymeti = dto.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = dto.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = dto.TekEdedSatisQiymeti,
                MovcudSay = dto.MovcudSay,
                Aktivdir = dto.Aktivdir,
                OlcuVahidi = dto.OlcuVahidi,
                // Yeni əlavə edilən sahələr
                KateqoriyaId = dto.KateqoriyaId,
                BrendId = dto.BrendId,
                TedarukcuId = dto.TedarukcuId,
                MinimumStok = dto.MinimumStok,
                SekilYolu = dto.SekilYolu
            };

            await _unitOfWork.Mehsullar.ElaveEtAsync(yeniMehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniMehsul.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Məhsul yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Mövcud məhsulun məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulYenileAsync(MehsulDto dto)
    {
        try
        {
            var movcudMehsul = await _unitOfWork.Mehsullar.GetirAsync(dto.Id);
            if (movcudMehsul == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün məhsul tapılmadı.");

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi.Ugursuz("Məhsul adı boş ola bilməz.");

            // Məlumatları yeniləyirik
            movcudMehsul.Ad = dto.Ad;
            movcudMehsul.Barkod = dto.Barkod;
            movcudMehsul.StokKodu = dto.StokKodu;
            movcudMehsul.AlisQiymeti = dto.AlisQiymeti;
            movcudMehsul.PerakendeSatisQiymeti = dto.PerakendeSatisQiymeti;
            movcudMehsul.TopdanSatisQiymeti = dto.TopdanSatisQiymeti;
            movcudMehsul.TekEdedSatisQiymeti = dto.TekEdedSatisQiymeti;
            movcudMehsul.MovcudSay = dto.MovcudSay;
            movcudMehsul.Aktivdir = dto.Aktivdir;
            movcudMehsul.OlcuVahidi = dto.OlcuVahidi;
            // Yeni əlavə edilən sahələr
            movcudMehsul.KateqoriyaId = dto.KateqoriyaId;
            movcudMehsul.BrendId = dto.BrendId;
            movcudMehsul.TedarukcuId = dto.TedarukcuId;
            movcudMehsul.MinimumStok = dto.MinimumStok;
            movcudMehsul.SekilYolu = dto.SekilYolu;

            _unitOfWork.Mehsullar.Yenile(movcudMehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Məhsul məlumatlarını yeniləmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsul silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulSilAsync(int id)
    {
        try
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(id);
            if (mehsul == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək məhsul tapılmadı.");

            _unitOfWork.Mehsullar.Sil(mehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Məhsul silmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsulun anbar miqdarını artırır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulMiqdariniArtirAsync(int mehsulId, int miqdar)
    {
        try
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
                return EmeliyyatNeticesi.Ugursuz("Məhsul tapılmadı.");

            mehsul.MovcudSay += miqdar;
            _unitOfWork.Mehsullar.Yenile(mehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Məhsul miqdarını artırmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Məhsulun anbar miqdarını azaltır.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulMiqdariniAzaltAsync(int mehsulId, int miqdar)
    {
        try
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
                return EmeliyyatNeticesi.Ugursuz("Məhsul tapılmadı.");

            if (mehsul.MovcudSay < miqdar)
                return EmeliyyatNeticesi.Ugursuz("Anbarda kifayət qədər məhsul yoxdur.");

            mehsul.MovcudSay -= miqdar;
            _unitOfWork.Mehsullar.Yenile(mehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Məhsul miqdarını azaltmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Minimum stok səviyyəsinə çatmış məhsulları gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> MinimumStokMehsullariniGetirAsync()
    {
        try
        {
            var mehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m => m.MovcudSay <= m.MinimumStok && m.Aktivdir);
            var dtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                Barkod = m.Barkod,
                StokKodu = m.StokKodu,
                AlisQiymeti = m.AlisQiymeti,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                MovcudSay = m.MovcudSay,
                Aktivdir = m.Aktivdir,
                OlcuVahidi = m.OlcuVahidi,
                AnbarMiqdari = m.MovcudSay,
                OlcuVahidiAdi = m.OlcuVahidi.ToString(),
                // Yeni əlavə edilən sahələr
                KateqoriyaId = m.KateqoriyaId,
                KateqoriyaAdi = m.Kateqoriya?.Ad,
                BrendId = m.BrendId,
                BrendAdi = m.Brend?.Ad,
                TedarukcuId = m.TedarukcuId,
                TedarukcuAdi = m.Tedarukcu?.Ad,
                MinimumStok = m.MinimumStok,
                SekilYolu = m.SekilYolu
            }).ToList();

            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz($"Minimum stok məhsullarını gətirmək alınmadı: {ex.Message}");
        }
    }
}