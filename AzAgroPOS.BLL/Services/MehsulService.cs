using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class MehsulService
    {
        private readonly MehsulRepository _mehsulRepository;
        private readonly MehsulKateqoriyasiRepository _kateqoriyaRepository;
        private readonly VahidRepository _vahidRepository;
        private readonly AuditLogService _auditLogService;

        public MehsulService()
        {
            _mehsulRepository = new MehsulRepository();
            _kateqoriyaRepository = new MehsulKateqoriyasiRepository();
            _vahidRepository = new VahidRepository();
            _auditLogService = new AuditLogService();
        }

        public async Task<(bool Success, string Message, int? MehsulId)> CreateMehsulAsync(Mehsul mehsul, int istifadeciId)
        {
            try
            {
                // Barkod yoxlaması
                if (await _mehsulRepository.BarkodMevcudAsync(mehsul.Barkod))
                {
                    return (false, "Bu barkod artıq mövcuddur.", null);
                }

                // SKU yoxlaması
                if (await _mehsulRepository.SKUMevcudAsync(mehsul.SKU))
                {
                    return (false, "Bu SKU artıq mövcuddur.", null);
                }

                // Kateqoriya yoxlaması
                var kateqoriya = await _kateqoriyaRepository.GetByIdAsync(mehsul.KateqoriyaId);
                if (kateqoriya == null || kateqoriya.Status != "Aktiv")
                {
                    return (false, "Seçilən kateqoriya mövcud deyil və ya aktiv deyil.", null);
                }

                // Vahid yoxlaması
                var vahid = await _vahidRepository.GetByIdAsync(mehsul.VahidId);
                if (vahid == null || vahid.Status != "Aktiv")
                {
                    return (false, "Seçilən vahid mövcud deyil və ya aktiv deyil.", null);
                }

                // Qiymət yoxlaması
                if (mehsul.SatisQiymeti <= mehsul.AlisQiymeti)
                {
                    return (false, "Satış qiyməti alış qiymətindən böyük olmalıdır.", null);
                }

                var mehsulId = await _mehsulRepository.AddAsync(mehsul);

                // Audit log
                await _auditLogService.LogAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Əlavə Etmə", 
                    "Desktop App", $"Yeni məhsul yaradıldı: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla yaradıldı.", mehsulId);
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateMehsulAsync(Mehsul mehsul, int istifadeciId)
        {
            try
            {
                // Mövcudluq yoxlaması
                var existingMehsul = await _mehsulRepository.GetByIdAsync(mehsul.Id);
                if (existingMehsul == null)
                {
                    return (false, "Məhsul tapılmadı.");
                }

                // Barkod yoxlaması (özü istisna olmaqla)
                if (await _mehsulRepository.BarkodMevcudAsync(mehsul.Barkod, mehsul.Id))
                {
                    return (false, "Bu barkod başqa məhsulda mövcuddur.");
                }

                // SKU yoxlaması (özü istisna olmaqla)
                if (await _mehsulRepository.SKUMevcudAsync(mehsul.SKU, mehsul.Id))
                {
                    return (false, "Bu SKU başqa məhsulda mövcuddur.");
                }

                // Kateqoriya yoxlaması
                var kateqoriya = await _kateqoriyaRepository.GetByIdAsync(mehsul.KateqoriyaId);
                if (kateqoriya == null || kateqoriya.Status != "Aktiv")
                {
                    return (false, "Seçilən kateqoriya mövcud deyil və ya aktiv deyil.");
                }

                // Vahid yoxlaması
                var vahid = await _vahidRepository.GetByIdAsync(mehsul.VahidId);
                if (vahid == null || vahid.Status != "Aktiv")
                {
                    return (false, "Seçilən vahid mövcud deyil və ya aktiv deyil.");
                }

                // Qiymət yoxlaması
                if (mehsul.SatisQiymeti <= mehsul.AlisQiymeti)
                {
                    return (false, "Satış qiyməti alış qiymətindən böyük olmalıdır.");
                }

                // Yaradılma tarixini saxla
                mehsul.YaradilmaTarixi = existingMehsul.YaradilmaTarixi;

                await _mehsulRepository.UpdateAsync(mehsul);

                // Audit log
                await _auditLogService.LogAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Yeniləmə", 
                    "Desktop App", $"Məhsul yeniləndi: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla yeniləndi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> DeleteMehsulAsync(int mehsulId, int istifadeciId)
        {
            try
            {
                var mehsul = await _mehsulRepository.GetByIdAsync(mehsulId);
                if (mehsul == null)
                {
                    return (false, "Məhsul tapılmadı.");
                }

                if (!await _mehsulRepository.CanDeleteAsync(mehsulId))
                {
                    return (false, "Bu məhsul silinə bilməz çünki digər əməliyyatlarda istifadə olunur.");
                }

                await _mehsulRepository.DeleteAsync(mehsulId);

                // Audit log
                await _auditLogService.LogAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Silmə", 
                    "Desktop App", $"Məhsul silindi: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla silindi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> UpdateMehsulStatusAsync(int mehsulId, string status, int istifadeciId)
        {
            try
            {
                var mehsul = await _mehsulRepository.GetByIdAsync(mehsulId);
                if (mehsul == null)
                {
                    return (false, "Məhsul tapılmadı.");
                }

                var oldStatus = mehsul.Status;
                mehsul.Status = status;
                await _mehsulRepository.UpdateAsync(mehsul);

                // Audit log
                await _auditLogService.LogAsync(istifadeciId, "Məhsul İdarəetməsi", "Status Dəyişikliyi", 
                    "Desktop App", $"Məhsul statusu dəyişdi: {mehsul.Ad} ({oldStatus} → {status})");

                return (true, $"Məhsul statusu {status} olaraq dəyişdirildi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        public async Task<string> GenerateBarkodAsync()
        {
            var random = new Random();
            string barkod;
            
            do
            {
                // 13 rəqəmli EAN-13 formatında barkod
                barkod = "299" + random.Next(1000000000).ToString("D10");
            }
            while (await _mehsulRepository.BarkodMevcudAsync(barkod));

            return barkod;
        }

        public async Task<string> GenerateSKUAsync(string mehsulAdi, string kateqoriyaKodu)
        {
            // Məhsul adından ilk 3 hərf
            var mehsulPrefix = "";
            var words = mehsulAdi.Split(' ');
            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    mehsulPrefix += word[0];
                    if (mehsulPrefix.Length >= 3) break;
                }
            }
            mehsulPrefix = mehsulPrefix.PadRight(3, 'X').ToUpper();

            // Kateqoriya kodu və ya "GEN"
            var katPrefix = !string.IsNullOrEmpty(kateqoriyaKodu) ? kateqoriyaKodu : "GEN";

            string sku;
            int counter = 1;
            
            do
            {
                sku = $"{katPrefix}-{mehsulPrefix}-{counter:D4}";
                counter++;
            }
            while (await _mehsulRepository.SKUMevcudAsync(sku));

            return sku;
        }

        public async Task<(bool Success, string Message)> UpdateStokMiqdarAsync(int mehsulId, decimal yeniMiqdar, int istifadeciId, string sebet = null)
        {
            try
            {
                var mehsul = await _mehsulRepository.GetByIdAsync(mehsulId);
                if (mehsul == null)
                {
                    return (false, "Məhsul tapılmadı.");
                }

                if (yeniMiqdar < 0)
                {
                    return (false, "Stok miqdarı mənfi ola bilməz.");
                }

                var kohMiqdar = mehsul.MovcudMiqdar;
                await _mehsulRepository.UpdateMiqdarAsync(mehsulId, yeniMiqdar);

                // Audit log
                var detal = sebet ?? $"Stok miqdarı dəyişdi: {kohMiqdar} → {yeniMiqdar}";
                await _auditLogService.LogAsync(istifadeciId, "Məhsul İdarəetməsi", "Stok Yeniləmə", 
                    "Desktop App", $"{mehsul.Ad}: {detal}");

                return (true, "Stok miqdarı uğurla yeniləndi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        public async Task<List<Mehsul>> GetStoktanKenardaMehsullarAsync()
        {
            return await _mehsulRepository.GetStoktanKenardaAsync();
        }

        public async Task<decimal> HesablaUmumiStokDegeriAsync()
        {
            var mehsullar = await _mehsulRepository.GetAllActiveAsync();
            return mehsullar.Sum(m => m.MovcudMiqdar * m.SatisQiymeti);
        }

        public async Task<Dictionary<string, object>> GetMehsulStatistikalarAsync()
        {
            return await _mehsulRepository.GetStatistikalarAsync();
        }

        public async Task<List<Mehsul>> GetMehsullarByFiltersAsync(string searchTerm = null, int? kateqoriyaId = null, string status = null)
        {
            var mehsullar = await _mehsulRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var term = searchTerm.ToLower();
                mehsullar = mehsullar.Where(m => 
                    m.Ad.ToLower().Contains(term) ||
                    m.Barkod.ToLower().Contains(term) ||
                    m.SKU.ToLower().Contains(term) ||
                    m.Tesvir?.ToLower().Contains(term) == true).ToList();
            }

            if (kateqoriyaId.HasValue)
            {
                mehsullar = mehsullar.Where(m => m.KateqoriyaId == kateqoriyaId.Value).ToList();
            }

            if (!string.IsNullOrEmpty(status))
            {
                mehsullar = mehsullar.Where(m => m.Status == status).ToList();
            }

            return mehsullar;
        }

        public List<Mehsul> GetAllActive()
        {
            throw new NotImplementedException();
        }
    }
}