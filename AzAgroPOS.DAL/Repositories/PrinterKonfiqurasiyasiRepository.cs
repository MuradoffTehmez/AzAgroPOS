using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class PrinterKonfiqurasiyasiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public PrinterKonfiqurasiyasiRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetAllAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .OrderByDescending(pk => pk.Aktiv)
                .ThenByDescending(pk => pk.StandartPrinter)
                .ThenBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> GetByIdAsync(int id)
        {
            return await _context.PrinterKonfiqurasiyas
                .FirstOrDefaultAsync(pk => pk.Id == id);
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetActivePrintersAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.Aktiv)
                .OrderByDescending(pk => pk.StandartPrinter)
                .ThenBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> GetDefaultPrinterAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .FirstOrDefaultAsync(pk => pk.Aktiv && pk.StandartPrinter);
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetByConnectionTypeAsync(string connectionType)
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.BaglantiTipi == connectionType && pk.Aktiv)
                .OrderBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetByPrinterTypeAsync(string printerType)
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.PrinterTipi == printerType && pk.Aktiv)
                .OrderBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetOnlinePrintersAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.Aktiv && pk.SonTestUgurlu && 
                           pk.SonTestTarixi >= DateTime.Now.AddHours(-24))
                .OrderByDescending(pk => pk.StandartPrinter)
                .ThenBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetOfflinePrintersAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.Aktiv && (!pk.SonTestUgurlu || 
                           pk.SonTestTarixi < DateTime.Now.AddHours(-24)))
                .OrderBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<bool> IsNameUniqueAsync(string printerName, int? excludeId = null)
        {
            var query = _context.PrinterKonfiqurasiyas.Where(pk => pk.PrinterAdi == printerName);
            
            if (excludeId.HasValue)
                query = query.Where(pk => pk.Id != excludeId.Value);

            return !await query.AnyAsync();
        }

        public async Task<bool> IsIPAddressInUseAsync(string ipAddress, int port, int? excludeId = null)
        {
            var query = _context.PrinterKonfiqurasiyas
                .Where(pk => pk.PrinterIP == ipAddress && pk.PrinterPort == port && pk.Aktiv);
            
            if (excludeId.HasValue)
                query = query.Where(pk => pk.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> AddAsync(PrinterKonfiqurasiyasi entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Əgər bu standart printer olaraq təyin olunursa, digərlərini standart olmayan et
            if (entity.StandartPrinter)
            {
                await RemoveDefaultFlagFromAllAsync();
            }
            
            _context.PrinterKonfiqurasiyas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PrinterKonfiqurasiyasi> UpdateAsync(PrinterKonfiqurasiyasi entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Əgər bu standart printer olaraq təyin olunursa, digərlərini standart olmayan et
            if (entity.StandartPrinter)
            {
                await RemoveDefaultFlagFromAllAsync(entity.Id);
            }
            
            _context.PrinterKonfiqurasiyas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.PrinterKonfiqurasiyas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SetAsDefaultAsync(int id)
        {
            var printer = await GetByIdAsync(id);
            if (printer != null && printer.Aktiv)
            {
                await RemoveDefaultFlagFromAllAsync();
                printer.StandartPrinter = true;
                await UpdateAsync(printer);
                return true;
            }
            return false;
        }

        public async Task<bool> ActivatePrinterAsync(int id)
        {
            var printer = await GetByIdAsync(id);
            if (printer != null)
            {
                printer.Aktiv = true;
                await UpdateAsync(printer);
                return true;
            }
            return false;
        }

        public async Task<bool> DeactivatePrinterAsync(int id)
        {
            var printer = await GetByIdAsync(id);
            if (printer != null)
            {
                printer.Aktiv = false;
                if (printer.StandartPrinter)
                {
                    printer.StandartPrinter = false;
                    // Başqa aktiv printer varsa onu standart et
                    var firstActivePrinter = await _context.PrinterKonfiqurasiyas
                        .Where(pk => pk.Aktiv && pk.Id != id)
                        .FirstOrDefaultAsync();
                    if (firstActivePrinter != null)
                    {
                        firstActivePrinter.StandartPrinter = true;
                        _context.PrinterKonfiqurasiyas.Update(firstActivePrinter);
                    }
                }
                await UpdateAsync(printer);
                return true;
            }
            return false;
        }

        public async Task<bool> TestPrinterConnectionAsync(int id)
        {
            var printer = await GetByIdAsync(id);
            if (printer != null)
            {
                try
                {
                    // Bu real həyatda printer ilə əlaqə yoxlanılacaq
                    // İndi sadə simülasiya edirik
                    await Task.Delay(1000); // Şəbəkə gecikmesini simulyasiya et
                    
                    var random = new Random();
                    var isSuccessful = random.Next(1, 10) > 2; // 80% uğur şansı
                    
                    printer.SonTestTarixi = DateTime.Now;
                    printer.SonTestUgurlu = isSuccessful;
                    printer.SonTestNetice = isSuccessful ? "Bağlantı uğurlu" : "Bağlantı xətası - Printer cavab vermədi";
                    
                    await UpdateAsync(printer);
                    return isSuccessful;
                }
                catch (Exception ex)
                {
                    printer.SonTestTarixi = DateTime.Now;
                    printer.SonTestUgurlu = false;
                    printer.SonTestNetice = $"Test xətası: {ex.Message}";
                    await UpdateAsync(printer);
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> TestAllActivePrintersAsync()
        {
            var activePrinters = await GetActivePrintersAsync();
            var allSuccessful = true;
            
            foreach (var printer in activePrinters)
            {
                var result = await TestPrinterConnectionAsync(printer.Id);
                if (!result)
                    allSuccessful = false;
            }
            
            return allSuccessful;
        }

        public async Task<Dictionary<string, int>> GetPrinterStatisticsByTypeAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .GroupBy(pk => pk.PrinterTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetPrinterStatisticsByConnectionAsync()
        {
            return await _context.PrinterKonfiqurasiyas
                .GroupBy(pk => pk.BaglantiTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, object>> GetPrinterHealthStatisticsAsync()
        {
            var totalPrinters = await _context.PrinterKonfiqurasiyas.CountAsync();
            var activePrinters = await _context.PrinterKonfiqurasiyas.CountAsync(pk => pk.Aktiv);
            var onlinePrinters = await _context.PrinterKonfiqurasiyas
                .CountAsync(pk => pk.Aktiv && pk.SonTestUgurlu && 
                                pk.SonTestTarixi >= DateTime.Now.AddHours(-24));
            var offlinePrinters = activePrinters - onlinePrinters;
            
            var lastTestResults = await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.Aktiv)
                .GroupBy(pk => pk.SonTestUgurlu)
                .ToDictionaryAsync(g => g.Key ? "Uğurlu" : "Uğursuz", g => g.Count());

            return new Dictionary<string, object>
            {
                { "TotalPrinters", totalPrinters },
                { "ActivePrinters", activePrinters },
                { "OnlinePrinters", onlinePrinters },
                { "OfflinePrinters", offlinePrinters },
                { "LastTestResults", lastTestResults }
            };
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> SearchAsync(string searchTerm)
        {
            return await _context.PrinterKonfiqurasiyas
                .Where(pk => pk.PrinterAdi.Contains(searchTerm) ||
                           pk.PrinterIP.Contains(searchTerm) ||
                           pk.PrinterTipi.Contains(searchTerm) ||
                           pk.BaglantiTipi.Contains(searchTerm))
                .OrderByDescending(pk => pk.Aktiv)
                .ThenBy(pk => pk.PrinterAdi)
                .ToListAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> ClonePrinterAsync(int sourceId, string newName)
        {
            var source = await GetByIdAsync(sourceId);
            if (source == null)
                return null;

            var clone = new PrinterKonfiqurasiyasi
            {
                PrinterAdi = newName,
                PrinterTipi = source.PrinterTipi,
                PrinterIP = source.PrinterIP,
                PrinterPort = source.PrinterPort,
                PrinterUSB = source.PrinterUSB,
                PrinterSerial = source.PrinterSerial,
                BaglantiTipi = source.BaglantiTipi,
                PrinterGenisligi = source.PrinterGenisligi,
                PrinterUzunlugu = source.PrinterUzunlugu,
                KagizGenisligi = source.KagizGenisligi,
                KagizUzunlugu = source.KagizUzunlugu,
                FontAdi = source.FontAdi,
                FontOlcusu = source.FontOlcusu,
                Aktiv = false, // Clone starts as inactive
                StandartPrinter = false,
                KagizOrientasiyasi = source.KagizOrientasiyasi,
                PrintSureti = source.PrintSureti,
                PrintKeyfiyyeti = source.PrintKeyfiyyeti,
                BarkodTipi = source.BarkodTipi,
                BarkodUzunlugu = source.BarkodUzunlugu,
                BarkodGenisligi = source.BarkodGenisligi,
                BarkodYazisiGoster = source.BarkodYazisiGoster,
                TextAliglama = source.TextAliglama,
                BaslikSablonu = source.BaslikSablonu,
                AltBilgiSablonu = source.AltBilgiSablonu,
                LogoGoster = source.LogoGoster,
                LogoYolu = source.LogoYolu,
                LogoGenisligi = source.LogoGenisligi,
                LogoUzunlugu = source.LogoUzunlugu,
                LogoPozisiyasi = source.LogoPozisiyasi,
                ElaveTenzimlemeler = source.ElaveTenzimlemeler
            };

            return await AddAsync(clone);
        }

        private async Task RemoveDefaultFlagFromAllAsync(int? excludeId = null)
        {
            var defaultPrinters = _context.PrinterKonfiqurasiyas.Where(pk => pk.StandartPrinter);
            
            if (excludeId.HasValue)
                defaultPrinters = defaultPrinters.Where(pk => pk.Id != excludeId.Value);

            await foreach (var printer in defaultPrinters.AsAsyncEnumerable())
            {
                printer.StandartPrinter = false;
                _context.PrinterKonfiqurasiyas.Update(printer);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}