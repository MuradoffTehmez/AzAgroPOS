using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AzAgroPOS.BLL.Services
{
    public class PrinterService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public PrinterService(IUnitOfWork unitOfWork, IAuditLogService auditLogService = null)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService;
        }

        #region Printer Configuration Management

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetAllPrintersAsync()
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.GetAllAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> GetPrinterByIdAsync(int id)
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PrinterKonfiqurasiyasi>> GetActivePrintersAsync()
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.GetActivePrintersAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> GetDefaultPrinterAsync()
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.GetDefaultPrinterAsync();
        }

        public async Task<PrinterKonfiqurasiyasi> CreatePrinterAsync(PrinterKonfiqurasiyasi printer)
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.AddAsync(printer);
        }

        public async Task<PrinterKonfiqurasiyasi> UpdatePrinterAsync(PrinterKonfiqurasiyasi printer)
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.UpdateAsync(printer);
        }

        public async Task DeletePrinterAsync(int id)
        {
            await _unitOfWork.PrinterKonfiqurasiyas.DeleteAsync(id);
        }

        public async Task<bool> TestPrinterConnectionAsync(int printerId)
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.TestPrinterConnectionAsync(printerId);
        }

        public async Task<bool> SetDefaultPrinterAsync(int printerId)
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.SetAsDefaultAsync(printerId);
        }

        #endregion

        #region Template Management

        public async Task<IEnumerable<PrintSablonu>> GetAllTemplatesAsync()
        {
            return await _unitOfWork.PrintSablonlari.GetAllAsync();
        }

        public async Task<PrintSablonu> GetTemplateByIdAsync(int id)
        {
            return await _unitOfWork.PrintSablonlari.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PrintSablonu>> GetActiveTemplatesAsync()
        {
            return await _unitOfWork.PrintSablonlari.GetActiveTemplatesAsync();
        }

        public async Task<PrintSablonu> GetDefaultTemplateAsync(string templateType, string printerType)
        {
            return await _unitOfWork.PrintSablonlari.GetDefaultTemplateAsync(templateType, printerType);
        }

        public async Task<PrintSablonu> CreateTemplateAsync(PrintSablonu template)
        {
            return await _unitOfWork.PrintSablonlari.AddAsync(template);
        }

        public async Task<PrintSablonu> UpdateTemplateAsync(PrintSablonu template)
        {
            return await _unitOfWork.PrintSablonlari.UpdateAsync(template);
        }

        public async Task DeleteTemplateAsync(int id)
        {
            await _unitOfWork.PrintSablonlari.DeleteAsync(id);
        }

        #endregion

        #region Printing Operations

        public async Task<PrintLogKaydi> PrintLabelAsync(int printerId, int templateId, string mehsulAdi, string barkod, decimal qiymet, int userId, int copies = 1)
        {
            var printer = await _unitOfWork.PrinterKonfiqurasiyas.GetByIdAsync(printerId);
            var template = await _unitOfWork.PrintSablonlari.GetByIdAsync(templateId);

            if (printer == null || template == null)
                throw new ArgumentException("Printer və ya şablon tapılmadı");

            var logKaydi = new PrintLogKaydi
            {
                PrinterKonfiqurasiId = printerId,
                PrintSablonuId = templateId,
                IstifadeciId = userId,
                PrintTarixi = DateTime.Now,
                SuretiSayi = copies,
                PrintTipi = PrintLogKaydi.PrintTipleri.Etiket,
                MenbeModul = PrintLogKaydi.PrintMenbeLeri.Manual,
                PrintStatusu = PrintLogKaydi.PrintStatuslari.Gozleyir
            };

            try
            {
                var stopwatch = Stopwatch.StartNew();

                // Generate print code
                var printCode = await _unitOfWork.PrintSablonlari.GenerateTemplateCodeAsync(template, mehsulAdi, barkod, qiymet);
                logKaydi.PrintKomandasi = printCode.Length > 100 ? printCode.Substring(0, 100) + "..." : printCode;
                logKaydi.PrintMezmunu = $"Məhsul: {mehsulAdi}, Barkod: {barkod}, Qiymət: {qiymet:C}";

                // Send to printer
                var success = await SendToPrinterAsync(printer, printCode, copies);

                stopwatch.Stop();
                logKaydi.PrintMuddeti = (decimal)stopwatch.ElapsedMilliseconds;
                logKaydi.PrintStatusu = success ? PrintLogKaydi.PrintStatuslari.Ugurlu : PrintLogKaydi.PrintStatuslari.Ugursuz;
                
                if (!success)
                    logKaydi.XetaMesaji = "Print əməliyyatı uğursuz oldu";

                // Calculate paper usage (simplified)
                logKaydi.KagizIstifadeOlcusu = template.SablonGenisligi * template.SablonUzunlugu * copies;

                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
            catch (Exception ex)
            {
                logKaydi.PrintStatusu = PrintLogKaydi.PrintStatuslari.Ugursuz;
                logKaydi.XetaMesaji = ex.Message;
                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
        }

        public async Task<PrintLogKaydi> PrintProductLabelAsync(int mehsulId, int userId, int? printerId = null, int? templateId = null, int copies = 1)
        {
            // This would typically get product information from the product repository
            // For now, we'll use placeholder data
            var mehsulAdi = "Məhsul Adı";
            var barkod = "1234567890123";
            var qiymet = 15.50m;

            var actualPrinterId = printerId ?? (await GetDefaultPrinterAsync())?.Id ?? 0;
            var actualTemplateId = templateId ?? (await GetDefaultTemplateAsync(PrintSablonu.SablonTipleri.Mehsul, PrinterKonfiqurasiyasi.PrinterTipleri.ZPL))?.Id ?? 0;

            var logKaydi = await PrintLabelAsync(actualPrinterId, actualTemplateId, mehsulAdi, barkod, qiymet, userId, copies);
            logKaydi.MehsulId = mehsulId;
            logKaydi.MenbeModul = PrintLogKaydi.PrintMenbeLeri.Mehsul;
            return await _unitOfWork.PrintLogKayitlari.UpdateAsync(logKaydi);
        }

        public async Task<PrintLogKaydi> PrintSalesReceiptAsync(int satisId, int userId, int? printerId = null)
        {
            var printer = printerId.HasValue ? 
                await _unitOfWork.PrinterKonfiqurasiyas.GetByIdAsync(printerId.Value) : 
                await GetDefaultPrinterAsync();

            if (printer == null)
                throw new ArgumentException("Printer tapılmadı");

            var logKaydi = new PrintLogKaydi
            {
                PrinterKonfiqurasiId = printer.Id,
                IstifadeciId = userId,
                SatisId = satisId,
                PrintTarixi = DateTime.Now,
                SuretiSayi = 1,
                PrintTipi = PrintLogKaydi.PrintTipleri.Qebz,
                MenbeModul = PrintLogKaydi.PrintMenbeLeri.Satis,
                PrintStatusu = PrintLogKaydi.PrintStatuslari.Gozleyir,
                ReferansNomre = $"SAT{satisId:D6}"
            };

            try
            {
                var stopwatch = Stopwatch.StartNew();

                // Generate receipt content (this would be more sophisticated in reality)
                var receiptContent = GenerateReceiptContent(satisId);
                logKaydi.PrintMezmunu = receiptContent;

                // Send to printer
                var success = await SendToPrinterAsync(printer, receiptContent, 1);

                stopwatch.Stop();
                logKaydi.PrintMuddeti = (decimal)stopwatch.ElapsedMilliseconds;
                logKaydi.PrintStatusu = success ? PrintLogKaydi.PrintStatuslari.Ugurlu : PrintLogKaydi.PrintStatuslari.Ugursuz;

                if (!success)
                    logKaydi.XetaMesaji = "Qəbz yazdırma uğursuz oldu";

                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
            catch (Exception ex)
            {
                logKaydi.PrintStatusu = PrintLogKaydi.PrintStatuslari.Ugursuz;
                logKaydi.XetaMesaji = ex.Message;
                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
        }

        public async Task<PrintLogKaydi> TestPrintAsync(int printerId, int userId)
        {
            var printer = await _unitOfWork.PrinterKonfiqurasiyas.GetByIdAsync(printerId);
            if (printer == null)
                throw new ArgumentException("Printer tapılmadı");

            var logKaydi = new PrintLogKaydi
            {
                PrinterKonfiqurasiId = printerId,
                IstifadeciId = userId,
                PrintTarixi = DateTime.Now,
                SuretiSayi = 1,
                PrintTipi = PrintLogKaydi.PrintTipleri.Test,
                MenbeModul = PrintLogKaydi.PrintMenbeLeri.Sistem,
                PrintStatusu = PrintLogKaydi.PrintStatuslari.Gozleyir,
                PrintMezmunu = "Test Print"
            };

            try
            {
                var stopwatch = Stopwatch.StartNew();

                // Generate test content
                var testContent = GenerateTestPrintContent(printer);
                logKaydi.PrintKomandasi = testContent;

                // Send to printer
                var success = await SendToPrinterAsync(printer, testContent, 1);

                stopwatch.Stop();
                logKaydi.PrintMuddeti = (decimal)stopwatch.ElapsedMilliseconds;
                logKaydi.PrintStatusu = success ? PrintLogKaydi.PrintStatuslari.Ugurlu : PrintLogKaydi.PrintStatuslari.Ugursuz;

                if (!success)
                    logKaydi.XetaMesaji = "Test print uğursuz oldu";

                // Update printer test status
                await _unitOfWork.PrinterKonfiqurasiyas.TestPrinterConnectionAsync(printerId);

                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
            catch (Exception ex)
            {
                logKaydi.PrintStatusu = PrintLogKaydi.PrintStatuslari.Ugursuz;
                logKaydi.XetaMesaji = ex.Message;
                return await _unitOfWork.PrintLogKayitlari.AddAsync(logKaydi);
            }
        }

        private async Task<bool> SendToPrinterAsync(PrinterKonfiqurasiyasi printer, string content, int copies)
        {
            try
            {
                switch (printer.BaglantiTipi)
                {
                    case PrinterKonfiqurasiyasi.BaglantiTipleri.IP:
                        return await SendToPrinterViaIPAsync(printer.PrinterIP, printer.PrinterPort, content, copies);
                    
                    case PrinterKonfiqurasiyasi.BaglantiTipleri.USB:
                        return await SendToPrinterViaUSBAsync(printer.PrinterUSB, content, copies);
                    
                    case PrinterKonfiqurasiyasi.BaglantiTipleri.Serial:
                        return await SendToPrinterViaSerialAsync(printer.PrinterSerial, content, copies);
                    
                    default:
                        throw new NotSupportedException($"Bağlantı tipi dəstəklənmir: {printer.BaglantiTipi}");
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SendToPrinterViaIPAsync(string ipAddress, int port, string content, int copies)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(ipAddress, port);
                    using (var stream = client.GetStream())
                    {
                        for (int i = 0; i < copies; i++)
                        {
                            var data = Encoding.UTF8.GetBytes(content);
                            await stream.WriteAsync(data, 0, data.Length);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SendToPrinterViaUSBAsync(string usbPort, string content, int copies)
        {
            try
            {
                // In a real implementation, this would use proper USB printing libraries
                // For now, we'll simulate the operation
                await Task.Delay(500); // Simulate printing delay
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> SendToPrinterViaSerialAsync(string serialPort, string content, int copies)
        {
            try
            {
                // In a real implementation, this would use SerialPort class
                // For now, we'll simulate the operation
                await Task.Delay(1000); // Simulate printing delay
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Print Log Management

        public async Task<IEnumerable<PrintLogKaydi>> GetAllPrintLogsAsync()
        {
            return await _unitOfWork.PrintLogKayitlari.GetAllAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetRecentPrintLogsAsync(int count = 50)
        {
            return await _unitOfWork.PrintLogKayitlari.GetRecentPrintsAsync(count);
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetPrintLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.PrintLogKayitlari.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetFailedPrintLogsAsync()
        {
            return await _unitOfWork.PrintLogKayitlari.GetFailedPrintsAsync();
        }

        #endregion

        #region Helper Methods

        private string GenerateTestPrintContent(PrinterKonfiqurasiyasi printer)
        {
            if (printer.PrinterTipi == PrinterKonfiqurasiyasi.PrinterTipleri.ZPL)
            {
                return @"^XA
^FO50,50^A0N,30,30^FDAzAgroPOS Test^FS
^FO50,100^A0N,20,20^FDPrinter: " + printer.PrinterAdi + @"^FS
^FO50,130^A0N,20,20^FDTarix: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + @"^FS
^FO50,160^BCN,60,Y,N,N^FD123456789^FS
^XZ";
            }
            else if (printer.PrinterTipi == PrinterKonfiqurasiyasi.PrinterTipleri.EPL)
            {
                return @"N
A50,50,0,3,1,1,N,""AzAgroPOS Test""
A50,100,0,2,1,1,N,""Printer: " + printer.PrinterAdi + @"""
A50,130,0,2,1,1,N,""Tarix: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + @"""
B50,160,0,1,2,2,60,B,""123456789""
P1";
            }
            else
            {
                return "AzAgroPOS Test Print\nPrinter: " + printer.PrinterAdi + "\nTarix: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }
        }

        private string GenerateReceiptContent(int satisId)
        {
            // This would typically generate a proper receipt based on sales data
            return $@"        AzAgroPOS
      ****************
      
Satış No: SAT{satisId:D6}
Tarix: {DateTime.Now:dd.MM.yyyy HH:mm}

Məhsul 1    x1    15.50₼
Məhsul 2    x2    25.00₼
      
      ----------------
Toplam:           65.50₼
ƏDV (18%):        11.79₼
      ----------------
Yekun:            77.29₼

Teşekkür edirik!
      ****************";
        }

        #endregion

        #region Statistics and Reports

        public async Task<Dictionary<string, object>> GetPrintStatisticsAsync()
        {
            var stats = await _unitOfWork.PrintLogKayitlari.GetDetailedPrintStatisticsAsync();
            var printerStats = await _unitOfWork.PrinterKonfiqurasiyas.GetPrinterHealthStatisticsAsync();
            var templateStats = await _unitOfWork.PrintSablonlari.GetTemplateUsageStatisticsAsync();

            return new Dictionary<string, object>
            {
                { "PrintStatistics", stats },
                { "PrinterHealth", printerStats },
                { "TemplateUsage", templateStats }
            };
        }

        public async Task<double> GetPrintSuccessRateAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await _unitOfWork.PrintLogKayitlari.GetPrintSuccessRateAsync(startDate, endDate);
        }

        public async Task<decimal> GetTotalPaperUsageAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            return await _unitOfWork.PrintLogKayitlari.GetTotalPaperUsageAsync(startDate, endDate);
        }

        #endregion

        #region Maintenance

        public async Task<int> CleanupOldLogsAsync(int daysOld = 90)
        {
            return await _unitOfWork.PrintLogKayitlari.DeleteOldLogsAsync(daysOld);
        }

        public async Task<bool> TestAllPrintersAsync()
        {
            return await _unitOfWork.PrinterKonfiqurasiyas.TestAllActivePrintersAsync();
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _unitOfWork?.Dispose();
                _disposed = true;
            }
        }
    }
}