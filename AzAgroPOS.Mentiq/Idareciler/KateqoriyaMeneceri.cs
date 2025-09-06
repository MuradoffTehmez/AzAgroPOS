// Fayl: AzAgroPOS.Mentiq/Idareciler/KateqoriyaMeneceri.cs
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
/// Kateqoriya əməliyyatlarını idarə edən menecer.
/// Bu menecer kateqoriya yaratma, yeniləmə, silmə və axtarış əməliyyatlarını həyata keçirir.
/// </summary>
public class KateqoriyaMeneceri
{
    private readonly IUnitOfWork _unitOfWork;

    public KateqoriyaMeneceri(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün kateqoriyaları DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<KateqoriyaDto>>> ButunKateqoriyalariGetirAsync()
    {
        try
        {
            var kateqoriyalar = await _unitOfWork.Kateqoriyalar.ButununuGetirAsync();
            var dtolar = kateqoriyalar.Select(k => new KateqoriyaDto
            {
                Id = k.Id,
                Ad = k.Ad,
                Tesvir = k.Tesvir,
                Aktivdir = k.Aktivdir
            }).ToList();

            return EmeliyyatNeticesi<List<KateqoriyaDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<List<KateqoriyaDto>>.Ugursuz($"Kateqoriyaları gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə kateqoriya məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<KateqoriyaDto>> KateqoriyaGetirAsync(int id)
    {
        try
        {
            var kateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(id);
            if (kateqoriya == null)
                return EmeliyyatNeticesi<KateqoriyaDto>.Ugursuz("Kateqoriya tapılmadı.");

            var dto = new KateqoriyaDto
            {
                Id = kateqoriya.Id,
                Ad = kateqoriya.Ad,
                Tesvir = kateqoriya.Tesvir,
                Aktivdir = kateqoriya.Aktivdir
            };

            return EmeliyyatNeticesi<KateqoriyaDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<KateqoriyaDto>.Ugursuz($"Kateqoriya məlumatlarını gətirmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Yeni kateqoriya yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> KateqoriyaYaratAsync(KateqoriyaDto dto)
    {
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi<int>.Ugursuz("Kateqoriya adı boş ola bilməz.");

            // Yeni kateqoriya obyekti yaradırıq
            var yeniKateqoriya = new Kateqoriya
            {
                Ad = dto.Ad,
                Tesvir = dto.Tesvir,
                Aktivdir = dto.Aktivdir
            };

            await _unitOfWork.Kateqoriyalar.ElaveEtAsync(yeniKateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniKateqoriya.Id);
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi<int>.Ugursuz($"Kateqoriya yaratmaq alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Mövcud kateqoriyanın məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> KateqoriyaYenileAsync(KateqoriyaDto dto)
    {
        try
        {
            var movcudKateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(dto.Id);
            if (movcudKateqoriya == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün kateqoriya tapılmadı.");

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
                return EmeliyyatNeticesi.Ugursuz("Kateqoriya adı boş ola bilməz.");

            // Məlumatları yeniləyirik
            movcudKateqoriya.Ad = dto.Ad;
            movcudKateqoriya.Tesvir = dto.Tesvir;
            movcudKateqoriya.Aktivdir = dto.Aktivdir;

            _unitOfWork.Kateqoriyalar.Yenile(movcudKateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Kateqoriya məlumatlarını yeniləmək alınmadı: {ex.Message}");
        }
    }

    /// <summary>
    /// Kateqoriya silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> KateqoriyaSilAsync(int id)
    {
        try
        {
            var kateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(id);
            if (kateqoriya == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək kateqoriya tapılmadı.");

            _unitOfWork.Kateqoriyalar.Sil(kateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            return EmeliyyatNeticesi.Ugursuz($"Kateqoriya silmək alınmadı: {ex.Message}");
        }
    }
}