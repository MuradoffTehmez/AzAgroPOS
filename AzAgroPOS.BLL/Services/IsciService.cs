using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class IsciService : IDisposable
    {
        private readonly AzAgroDbContext _context;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public IsciService(AzAgroDbContext context = null, IAuditLogService auditLogService = null)
        {
            _context = context ?? new AzAgroDbContext();
            _auditLogService = auditLogService ?? new AuditLogService(_context);
        }

        #region İşçi CRUD Operations

        public async Task<IEnumerable<Isci>> GetAllWorkersAsync()
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .OrderBy(i => i.Ad)
                .ToListAsync();
        }

        public async Task<IEnumerable<Isci>> GetActiveWorkersAsync()
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Where(i => i.Status == SystemConstants.Status.Active)
                .OrderBy(i => i.Ad)
                .ToListAsync();
        }

        public async Task<Isci> GetWorkerByIdAsync(int id)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Include(i => i.NovbeKayitlari)
                .Include(i => i.PerformansKayitlari)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Isci> GetWorkerByCodeAsync(string isciKodu)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .FirstOrDefaultAsync(i => i.IsciKodu == isciKodu);
        }

        public async Task<(bool Success, string Message, int? WorkerId)> CreateWorkerAsync(Isci isci, int istifadeciId)
        {
            try
            {
                // Validation
                if (await _context.Isciler.AnyAsync(i => i.IsciKodu == isci.IsciKodu))
                    return (false, "Bu işçi kodu artıq mövcuddur.", null);

                if (await _context.Isciler.AnyAsync(i => i.Email == isci.Email && !string.IsNullOrEmpty(isci.Email)))
                    return (false, "Bu email artıq mövcuddur.", null);

                isci.YaradanIstifadeciId = istifadeciId;
                isci.YaradilmaTarixi = DateTime.Now;

                _context.Isciler.Add(isci);
                await _context.SaveChangesAsync();

                await _auditLogService.LogAsync("İşçi İdarəetməsi", isci.Id, "İşçi Əlavə Etmə", 
                    $"Yeni işçi yaradıldı: {isci.TamAd} ({isci.IsciKodu})", istifadeciId);

                return (true, "İşçi uğurla yaradıldı.", isci.Id);
            }
            catch (Exception ex)
            {
                return (false, $"İşçi yaradılarkən xəta: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateWorkerAsync(Isci isci, int istifadeciId)
        {
            try
            {
                var existingWorker = await _context.Isciler.FindAsync(isci.Id);
                if (existingWorker == null)
                    return (false, "İşçi tapılmadı.");

                // Check for duplicate code
                if (await _context.Isciler.AnyAsync(i => i.IsciKodu == isci.IsciKodu && i.Id != isci.Id))
                    return (false, "Bu işçi kodu artıq mövcuddur.");

                // Update properties
                existingWorker.Ad = isci.Ad;
                existingWorker.Soyad = isci.Soyad;
                existingWorker.Telefon = isci.Telefon;
                existingWorker.Email = isci.Email;
                existingWorker.Vezife = isci.Vezife;
                existingWorker.Maas = isci.Maas;
                existingWorker.IseBaslamaTarixi = isci.IseBaslamaTarixi;
                existingWorker.IseQurtarmaTarixi = isci.IseQurtarmaTarixi;
                existingWorker.Qeydler = isci.Qeydler;
                existingWorker.Status = isci.Status;
                existingWorker.YenilenmeTarixi = DateTime.Now;

                await _context.SaveChangesAsync();

                await _auditLogService.LogAsync("İşçi İdarəetməsi", isci.Id, "İşçi Yenilənməsi", 
                    $"İşçi yeniləndi: {isci.TamAd} ({isci.IsciKodu})", istifadeciId);

                return (true, "İşçi uğurla yeniləndi.");
            }
            catch (Exception ex)
            {
                return (false, $"İşçi yenilənərkən xəta: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> DeleteWorkerAsync(int id, int istifadeciId)
        {
            try
            {
                var worker = await _context.Isciler.FindAsync(id);
                if (worker == null)
                    return (false, "İşçi tapılmadı.");

                worker.Status = SystemConstants.Status.Deleted;
                worker.YenilenmeTarixi = DateTime.Now;

                await _context.SaveChangesAsync();

                await _auditLogService.LogAsync("İşçi İdarəetməsi", id, "İşçi Silmə", 
                    $"İşçi silindi: {worker.TamAd} ({worker.IsciKodu})", istifadeciId);

                return (true, "İşçi uğurla silindi.");
            }
            catch (Exception ex)
            {
                return (false, $"İşçi silinərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Növbə İdarəetməsi

        public async Task<(bool Success, string Message)> StartShiftAsync(int isciId, int istifadeciId)
        {
            try
            {
                var activeShift = await _context.NovbeKayitlari
                    .FirstOrDefaultAsync(n => n.IsciId == isciId && !n.CixisTarixi.HasValue);

                if (activeShift != null)
                    return (false, "Bu işçinin aktiv növbəsi var.");

                var newShift = new NovbeKaydi
                {
                    IsciId = isciId,
                    GirisTarixi = DateTime.Now,
                    YaradilmaTarixi = DateTime.Now
                };

                _context.NovbeKayitlari.Add(newShift);
                await _context.SaveChangesAsync();

                var worker = await _context.Isciler.FindAsync(isciId);
                await _auditLogService.LogAsync("Növbə İdarəetməsi", isciId, "Növbə Başlanğıcı", 
                    $"Növbə başladı: {worker?.TamAd}", istifadeciId);

                return (true, "Növbə uğurla başladı.");
            }
            catch (Exception ex)
            {
                return (false, $"Növbə başladırkən xəta: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> EndShiftAsync(int isciId, int istifadeciId)
        {
            try
            {
                var activeShift = await _context.NovbeKayitlari
                    .FirstOrDefaultAsync(n => n.IsciId == isciId && !n.CixisTarixi.HasValue);

                if (activeShift == null)
                    return (false, "Bu işçinin aktiv növbəsi yoxdur.");

                activeShift.CixisTarixi = DateTime.Now;
                activeShift.IslemeSaati = (decimal)activeShift.ToplamIsSaati.TotalHours;

                await _context.SaveChangesAsync();

                var worker = await _context.Isciler.FindAsync(isciId);
                await _auditLogService.LogAsync("Növbə İdarəetməsi", isciId, "Növbə Bitməsi", 
                    $"Növbə bitdi: {worker?.TamAd}, Müddət: {activeShift.IslemeSaati:F2} saat", istifadeciId);

                return (true, "Növbə uğurla bitdi.");
            }
            catch (Exception ex)
            {
                return (false, $"Növbə bitirərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Performans İzlənməsi

        public async Task<IEnumerable<IsciPerformans>> GetWorkerPerformanceAsync(int isciId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.IsciPerformans
                .Include(p => p.Isci)
                .Where(p => p.IsciId == isciId);

            if (startDate.HasValue)
                query = query.Where(p => p.TarixAraligi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.TarixAraligi <= endDate.Value);

            return await query.OrderByDescending(p => p.TarixAraligi).ToListAsync();
        }

        public async Task<(bool Success, string Message)> RecordPerformanceAsync(IsciPerformans performans, int istifadeciId)
        {
            try
            {
                performans.YaradilmaTarixi = DateTime.Now;
                
                _context.IsciPerformans.Add(performans);
                await _context.SaveChangesAsync();

                var worker = await _context.Isciler.FindAsync(performans.IsciId);
                await _auditLogService.LogAsync("Performans İzlənməsi", performans.IsciId, "Performans Qeydiyyatı", 
                    $"Performans qeydə alındı: {worker?.TamAd}", istifadeciId);

                return (true, "Performans uğurla qeydə alındı.");
            }
            catch (Exception ex)
            {
                return (false, $"Performans qeydə alınarkən xəta: {ex.Message}");
            }
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _context?.Dispose();
                _disposed = true;
            }
        }
    }
}