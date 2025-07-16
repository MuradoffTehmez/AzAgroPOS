using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class PrintSablonuRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public PrintSablonuRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PrintSablonu>> GetAllAsync()
        {
            return await _context.PrintSablonlari
                .OrderByDescending(ps => ps.Aktiv)
                .ThenByDescending(ps => ps.StandartSablon)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<PrintSablonu> GetByIdAsync(int id)
        {
            return await _context.PrintSablonlari
                .FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task<IEnumerable<PrintSablonu>> GetActiveTemplatesAsync()
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.Aktiv)
                .OrderByDescending(ps => ps.StandartSablon)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintSablonu>> GetByTemplateTypeAsync(string templateType)
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.SablonTipi == templateType && ps.Aktiv)
                .OrderByDescending(ps => ps.StandartSablon)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintSablonu>> GetByPrinterTypeAsync(string printerType)
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.PrinterTipi == printerType && ps.Aktiv)
                .OrderByDescending(ps => ps.StandartSablon)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<PrintSablonu> GetDefaultTemplateAsync(string templateType, string printerType)
        {
            return await _context.PrintSablonlari
                .FirstOrDefaultAsync(ps => ps.SablonTipi == templateType && 
                                         ps.PrinterTipi == printerType &&
                                         ps.Aktiv && ps.StandartSablon);
        }

        public async Task<IEnumerable<PrintSablonu>> GetStandardTemplatesAsync()
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.StandartSablon && ps.Aktiv)
                .OrderBy(ps => ps.SablonTipi)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintSablonu>> GetRecentlyUsedTemplatesAsync(int count = 10)
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.Aktiv && ps.IstifadeSayisi > 0)
                .OrderByDescending(ps => ps.SonIstifadeTarixi)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintSablonu>> GetMostUsedTemplatesAsync(int count = 10)
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.Aktiv && ps.IstifadeSayisi > 0)
                .OrderByDescending(ps => ps.IstifadeSayisi)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintSablonu>> GetUnusedTemplatesAsync()
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.Aktiv && ps.IstifadeSayisi == 0)
                .OrderBy(ps => ps.YaranmaTarixi)
                .ToListAsync();
        }

        public async Task<bool> IsNameUniqueAsync(string templateName, int? excludeId = null)
        {
            var query = _context.PrintSablonlari.Where(ps => ps.SablonAdi == templateName);
            
            if (excludeId.HasValue)
                query = query.Where(ps => ps.Id != excludeId.Value);

            return !await query.AnyAsync();
        }

        public async Task<PrintSablonu> AddAsync(PrintSablonu entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Əgər bu standart şablon olaraq təyin olunursa, eyni tip və printer tipindəki digərlərini standart olmayan et
            if (entity.StandartSablon)
            {
                await RemoveDefaultFlagFromSameTypeAsync(entity.SablonTipi, entity.PrinterTipi);
            }
            
            _context.PrintSablonlari.Add(entity);
            return entity;
        }

        public async Task<PrintSablonu> UpdateAsync(PrintSablonu entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Əgər bu standart şablon olaraq təyin olunursa, eyni tip və printer tipindəki digərlərini standart olmayan et
            if (entity.StandartSablon)
            {
                await RemoveDefaultFlagFromSameTypeAsync(entity.SablonTipi, entity.PrinterTipi, entity.Id);
            }
            
            _context.PrintSablonlari.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.PrintSablonlari.Remove(entity);
                }
        }

        public async Task<bool> SetAsDefaultAsync(int id)
        {
            var template = await GetByIdAsync(id);
            if (template != null && template.Aktiv)
            {
                await RemoveDefaultFlagFromSameTypeAsync(template.SablonTipi, template.PrinterTipi);
                template.StandartSablon = true;
                await UpdateAsync(template);
                return true;
            }
            return false;
        }

        public async Task<bool> ActivateTemplateAsync(int id)
        {
            var template = await GetByIdAsync(id);
            if (template != null)
            {
                template.Aktiv = true;
                await UpdateAsync(template);
                return true;
            }
            return false;
        }

        public async Task<bool> DeactivateTemplateAsync(int id)
        {
            var template = await GetByIdAsync(id);
            if (template != null)
            {
                template.Aktiv = false;
                template.StandartSablon = false; // Deaktiv şablon standart ola bilməz
                await UpdateAsync(template);
                return true;
            }
            return false;
        }

        public async Task<bool> IncrementUsageCountAsync(int id)
        {
            var template = await GetByIdAsync(id);
            if (template != null)
            {
                template.IstifadeSayisiniArtir();
                await UpdateAsync(template);
                return true;
            }
            return false;
        }

        public async Task<Dictionary<string, int>> GetTemplateStatisticsByTypeAsync()
        {
            return await _context.PrintSablonlari
                .GroupBy(ps => ps.SablonTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetTemplateStatisticsByPrinterTypeAsync()
        {
            return await _context.PrintSablonlari
                .GroupBy(ps => ps.PrinterTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, object>> GetTemplateUsageStatisticsAsync()
        {
            var totalTemplates = await _context.PrintSablonlari.CountAsync();
            var activeTemplates = await _context.PrintSablonlari.CountAsync(ps => ps.Aktiv);
            var usedTemplates = await _context.PrintSablonlari.CountAsync(ps => ps.IstifadeSayisi > 0);
            var totalUsage = await _context.PrintSablonlari.SumAsync(ps => ps.IstifadeSayisi);
            
            var recentUsage = await _context.PrintSablonlari
                .Where(ps => ps.SonIstifadeTarixi >= DateTime.Now.AddDays(-7))
                .CountAsync();

            return new Dictionary<string, object>
            {
                { "TotalTemplates", totalTemplates },
                { "ActiveTemplates", activeTemplates },
                { "UsedTemplates", usedTemplates },
                { "UnusedTemplates", activeTemplates - usedTemplates },
                { "TotalUsage", totalUsage },
                { "RecentUsage", recentUsage }
            };
        }

        public async Task<IEnumerable<PrintSablonu>> SearchAsync(string searchTerm)
        {
            return await _context.PrintSablonlari
                .Where(ps => ps.SablonAdi.Contains(searchTerm) ||
                           ps.Aciqlama.Contains(searchTerm) ||
                           ps.SablonTipi.Contains(searchTerm) ||
                           ps.PrinterTipi.Contains(searchTerm))
                .OrderByDescending(ps => ps.Aktiv)
                .ThenBy(ps => ps.SablonAdi)
                .ToListAsync();
        }

        public async Task<PrintSablonu> CloneTemplateAsync(int sourceId, string newName)
        {
            var source = await GetByIdAsync(sourceId);
            if (source == null)
                return null;

            var clone = new PrintSablonu
            {
                SablonAdi = newName,
                SablonTipi = source.SablonTipi,
                Aciqlama = $"Klonlandı: {source.SablonAdi}",
                PrinterTipi = source.PrinterTipi,
                SablonGenisligi = source.SablonGenisligi,
                SablonUzunlugu = source.SablonUzunlugu,
                SablonKodu = source.SablonKodu,
                SablonParametrleri = source.SablonParametrleri,
                Aktiv = false, // Clone starts as inactive
                StandartSablon = false,
                BarkodTipi = source.BarkodTipi,
                BarkodX = source.BarkodX,
                BarkodY = source.BarkodY,
                BarkodGenisligi = source.BarkodGenisligi,
                BarkodUzunlugu = source.BarkodUzunlugu,
                BarkodYazisiGoster = source.BarkodYazisiGoster,
                BarkodFontu = source.BarkodFontu,
                BarkodFontOlcusu = source.BarkodFontOlcusu,
                MehsulAdiGoster = source.MehsulAdiGoster,
                MehsulAdiX = source.MehsulAdiX,
                MehsulAdiY = source.MehsulAdiY,
                MehsulAdiFontu = source.MehsulAdiFontu,
                MehsulAdiFontOlcusu = source.MehsulAdiFontOlcusu,
                MehsulAdiMaksimumUzunlugu = source.MehsulAdiMaksimumUzunlugu,
                QiymetGoster = source.QiymetGoster,
                QiymetX = source.QiymetX,
                QiymetY = source.QiymetY,
                QiymetFontu = source.QiymetFontu,
                QiymetFontOlcusu = source.QiymetFontOlcusu,
                QiymetFormati = source.QiymetFormati,
                TarixGoster = source.TarixGoster,
                TarixX = source.TarixX,
                TarixY = source.TarixY,
                TarixFontu = source.TarixFontu,
                TarixFontOlcusu = source.TarixFontOlcusu,
                TarixFormati = source.TarixFormati,
                SirketAdiGoster = source.SirketAdiGoster,
                SirketAdiX = source.SirketAdiX,
                SirketAdiY = source.SirketAdiY,
                SirketAdiFontu = source.SirketAdiFontu,
                SirketAdiFontOlcusu = source.SirketAdiFontOlcusu,
                LogoGoster = source.LogoGoster,
                LogoX = source.LogoX,
                LogoY = source.LogoY,
                LogoGenisligi = source.LogoGenisligi,
                LogoUzunlugu = source.LogoUzunlugu,
                XususiMetinGoster = source.XususiMetinGoster,
                XususiMetinX = source.XususiMetinX,
                XususiMetinY = source.XususiMetinY,
                XususiMetinFontu = source.XususiMetinFontu,
                XususiMetinFontOlcusu = source.XususiMetinFontOlcusu,
                XususiMetinMesaj = source.XususiMetinMesaj
            };

            return await AddAsync(clone);
        }

        public async Task<string> GenerateTemplateCodeAsync(PrintSablonu template, string mehsulAdi, string barkod, decimal qiymet)
        {
            // Generate ZPL or EPL code based on template configuration
            string templateCode;
            
            if (template.PrinterTipi == PrinterKonfiqurasiyasi.PrinterTipleri.ZPL)
            {
                templateCode = GenerateZPLCode(template, mehsulAdi, barkod, qiymet);
            }
            else if (template.PrinterTipi == PrinterKonfiqurasiyasi.PrinterTipleri.EPL)
            {
                templateCode = GenerateEPLCode(template, mehsulAdi, barkod, qiymet);
            }
            else
            {
                templateCode = template.SablonKodu; // Use custom template code
            }

            // Replace parameters
            templateCode = template.ParametrleriEvedEt(mehsulAdi, barkod, qiymet, DateTime.Now);

            await IncrementUsageCountAsync(template.Id);
            return templateCode;
        }

        private string GenerateZPLCode(PrintSablonu template, string mehsulAdi, string barkod, decimal qiymet)
        {
            var zpl = "^XA"; // Start of ZPL code
            
            // Add barcode
            if (template.BarkodYazisiGoster)
            {
                zpl += $"^FO{template.BarkodX},{template.BarkodY}";
                zpl += $"^BCN,{template.BarkodUzunlugu},{template.BarkodYazisiGoster},{template.BarkodYazisiGoster},N";
                zpl += $"^FD{barkod}^FS";
            }

            // Add product name
            if (template.MehsulAdiGoster)
            {
                var truncatedName = mehsulAdi.Length > template.MehsulAdiMaksimumUzunlugu 
                    ? mehsulAdi.Substring(0, template.MehsulAdiMaksimumUzunlugu) 
                    : mehsulAdi;
                zpl += $"^FO{template.MehsulAdiX},{template.MehsulAdiY}";
                zpl += $"^A0N,{template.MehsulAdiFontOlcusu},{template.MehsulAdiFontOlcusu}";
                zpl += $"^FD{truncatedName}^FS";
            }

            // Add price
            if (template.QiymetGoster)
            {
                var formattedPrice = qiymet.ToString(template.QiymetFormati);
                zpl += $"^FO{template.QiymetX},{template.QiymetY}";
                zpl += $"^A0N,{template.QiymetFontOlcusu},{template.QiymetFontOlcusu}";
                zpl += $"^FD{formattedPrice}^FS";
            }

            // Add date
            if (template.TarixGoster)
            {
                var formattedDate = DateTime.Now.ToString(template.TarixFormati);
                zpl += $"^FO{template.TarixX},{template.TarixY}";
                zpl += $"^A0N,{template.TarixFontOlcusu},{template.TarixFontOlcusu}";
                zpl += $"^FD{formattedDate}^FS";
            }

            zpl += "^XZ"; // End of ZPL code
            return zpl;
        }

        private string GenerateEPLCode(PrintSablonu template, string mehsulAdi, string barkod, decimal qiymet)
        {
            var epl = "N\n"; // Start of EPL code
            
            // Add barcode
            if (template.BarkodYazisiGoster)
            {
                epl += $"B{template.BarkodX},{template.BarkodY},0,1,{template.BarkodGenisligi},{template.BarkodUzunlugu},30,B,\"{barkod}\"\n";
            }

            // Add product name
            if (template.MehsulAdiGoster)
            {
                var truncatedName = mehsulAdi.Length > template.MehsulAdiMaksimumUzunlugu 
                    ? mehsulAdi.Substring(0, template.MehsulAdiMaksimumUzunlugu) 
                    : mehsulAdi;
                epl += $"A{template.MehsulAdiX},{template.MehsulAdiY},0,{template.MehsulAdiFontOlcusu},1,1,N,\"{truncatedName}\"\n";
            }

            // Add price
            if (template.QiymetGoster)
            {
                var formattedPrice = qiymet.ToString(template.QiymetFormati);
                epl += $"A{template.QiymetX},{template.QiymetY},0,{template.QiymetFontOlcusu},1,1,N,\"{formattedPrice}\"\n";
            }

            epl += "P1\n"; // Print command
            return epl;
        }

        private async Task RemoveDefaultFlagFromSameTypeAsync(string templateType, string printerType, int? excludeId = null)
        {
            var defaultTemplates = _context.PrintSablonlari
                .Where(ps => ps.SablonTipi == templateType && 
                           ps.PrinterTipi == printerType && 
                           ps.StandartSablon);
            
            if (excludeId.HasValue)
                defaultTemplates = defaultTemplates.Where(ps => ps.Id != excludeId.Value);

            await foreach (var template in defaultTemplates.AsAsyncEnumerable())
            {
                template.StandartSablon = false;
                _context.PrintSablonlari.Update(template);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}