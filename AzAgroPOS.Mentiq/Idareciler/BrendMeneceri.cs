// Fayl: AzAgroPOS.Mentiq/Idareciler/BrendMeneceri.cs
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
/// Brend əməliyyatlarını idarə edən menecer.
/// Bu menecer brend yaratma, yeniləmə, silmə və axtarış əməliyyatlarını həyata keçirir.
/// </summary>
public class BrendMeneceri
{
    private readonly IUnitOfWork _unitOfWork;

    public BrendMeneceri(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün brendləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<BrendDto>>> ButunBrendleriGetirAsync()
    {
        try
        {
            var brendler = await _unitOfWork.Brendler.ButununuGetirAsync();
            var dtolar = brendler.Select(b => new BrendDto
            {
                Id = b.Id,
                Ad = b.Ad,
                Olke = b.Olke,
                Vebsayt = b.Vebsayt,
                Tesvir = b.Tesvir,
                LoqoFaylYolu = b.LoqoFaylYolu,
                Aktivdir = b.Aktivdir
            }).ToList();

            return EmeliyyatNeticesi<List<BrendDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<BrendDto>>.Ugursuz($"Brendləri gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə brend məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<BrendDto>> BrendGetirAsync(int id)
    {
        try
        {
            var brend = await _unitOfWork.Brendler.GetirAsync(id);
            if (brend == null)
                return EmeliyyatNeticesi<BrendDto>.Ugursuz("Brend tapılmadı.");

            var dto = new BrendDto
            {
                Id = brend.Id,
                Ad = brend.Ad,
                Olke = brend.Olke,
                Vebsayt = brend.Vebsayt,
                Tesvir = brend.Tesvir,
                LoqoFaylYolu = brend.LoqoFaylYolu,
                Aktivdir = brend.Aktivdir
            };

            return EmeliyyatNeticesi<BrendDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<BrendDto>.Ugursuz($"Brend məlumatlarını gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni brend yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> BrendYaratAsync(BrendDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi<int>.Ugursuz("Brend adı boş ola bilməz.");

            // Yeni brend obyekti yaradırıq
            var yeniBrend = new Brend
            {
                Ad = dto.Ad,
                Olke = dto.Olke,
                Vebsayt = dto.Vebsayt,
                Tesvir = dto.Tesvir,
                LoqoFaylYolu = dto.LoqoFaylYolu,
                Aktivdir = dto.Aktivdir
            };

            await _unitOfWork.Brendler.ElaveEtAsync(yeniBrend);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniBrend.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Brend yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Mövcud brendin məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> BrendYenileAsync(BrendDto dto)
    {
        try
        {
            var movcudBrend = await _unitOfWork.Brendler.GetirAsync(dto.Id);
            if (movcudBrend == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün brend tapılmadı.");

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi.Ugursuz("Brend adı boş ola bilməz.");

            // Məlumatları yeniləyirik
            movcudBrend.Ad = dto.Ad;
            movcudBrend.Olke = dto.Olke;
            movcudBrend.Vebsayt = dto.Vebsayt;
            movcudBrend.Tesvir = dto.Tesvir;
            movcudBrend.LoqoFaylYolu = dto.LoqoFaylYolu;
            movcudBrend.Aktivdir = dto.Aktivdir;

            _unitOfWork.Brendler.Yenile(movcudBrend);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Brend məlumatlarını yeniləmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Brend silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> BrendSilAsync(int id)
    {
        try
        {
            var brend = await _unitOfWork.Brendler.GetirAsync(id);
            if (brend == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək brend tapılmadı.");

            _unitOfWork.Brendler.Sil(brend);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Brend silmək alınmadı: {ex.Message}");
        }
    }
}