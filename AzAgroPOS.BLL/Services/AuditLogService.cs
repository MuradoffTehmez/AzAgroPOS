using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class AuditLogService
    {
        public async Task LogAsync(int? istifadeciId, string modul, string emeliyyat, string clientInfo, string detal = null)
        {
            try
            {
                using (var context = new AzAgroDbContext())
                {
                    var auditLog = new AuditLog
                    {
                        IstifadeciId = istifadeciId,
                        Emeliyyat = $"{modul} - {emeliyyat}",
                        Detal = detal,
                        IP = ExtractIP(clientInfo),
                        Browser = ExtractBrowser(clientInfo),
                        Platform = ExtractPlatform(clientInfo),
                        Tarix = DateTime.Now
                    };

                    context.AuditLoglar.Add(auditLog);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                // Log xətalarını susdurmaq - sistem işləməsinə mane olmamalı
            }
        }

        public async Task<List<AuditLog>> GetLogsAsync(int? istifadeciId = null, DateTime? startDate = null, 
            DateTime? endDate = null, string modul = null, int skip = 0, int take = 100)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.AuditLoglar
                    .Include(a => a.Istifadeci)
                    .AsQueryable();

                if (istifadeciId.HasValue)
                {
                    query = query.Where(a => a.IstifadeciId == istifadeciId.Value);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(a => a.Tarix >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(a => a.Tarix <= endDate.Value);
                }

                if (!string.IsNullOrEmpty(modul))
                {
                    query = query.Where(a => a.Emeliyyat.Contains(modul));
                }

                return await query
                    .OrderByDescending(a => a.Tarix)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
            }
        }

        public async Task<int> GetLogCountAsync(int? istifadeciId = null, DateTime? startDate = null, 
            DateTime? endDate = null, string modul = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.AuditLoglar.AsQueryable();

                if (istifadeciId.HasValue)
                {
                    query = query.Where(a => a.IstifadeciId == istifadeciId.Value);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(a => a.Tarix >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(a => a.Tarix <= endDate.Value);
                }

                if (!string.IsNullOrEmpty(modul))
                {
                    query = query.Where(a => a.Emeliyyat.Contains(modul));
                }

                return await query.CountAsync();
            }
        }

        public async Task<List<AuditLog>> GetUserActivityAsync(int istifadeciId, int days = 30)
        {
            var startDate = DateTime.Now.AddDays(-days);
            
            using (var context = new AzAgroDbContext())
            {
                return await context.AuditLoglar
                    .Include(a => a.Istifadeci)
                    .Where(a => a.IstifadeciId == istifadeciId && a.Tarix >= startDate)
                    .OrderByDescending(a => a.Tarix)
                    .Take(50)
                    .ToListAsync();
            }
        }

        public async Task<Dictionary<string, int>> GetActivitySummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.AuditLoglar.AsQueryable();

                if (startDate.HasValue)
                {
                    query = query.Where(a => a.Tarix >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(a => a.Tarix <= endDate.Value);
                }

                var summary = await query
                    .GroupBy(a => a.Emeliyyat)
                    .Select(g => new { Operation = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Operation, x => x.Count);

                return summary;
            }
        }

        public async Task CleanOldLogsAsync(int daysToKeep = 90)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
            
            using (var context = new AzAgroDbContext())
            {
                var oldLogs = await context.AuditLoglar
                    .Where(a => a.Tarix < cutoffDate)
                    .ToListAsync();

                if (oldLogs.Any())
                {
                    context.AuditLoglar.RemoveRange(oldLogs);
                    await context.SaveChangesAsync();
                }
            }
        }

        private string ExtractIP(string clientInfo)
        {
            if (string.IsNullOrEmpty(clientInfo)) return "Unknown";
            
            var parts = clientInfo.Split(',');
            var ipPart = parts.FirstOrDefault(p => p.Trim().StartsWith("IP:"));
            
            if (ipPart != null)
            {
                return ipPart.Replace("IP:", "").Trim();
            }
            
            return "Unknown";
        }

        private string ExtractBrowser(string clientInfo)
        {
            if (string.IsNullOrEmpty(clientInfo)) return "Desktop App";
            
            var parts = clientInfo.Split(',');
            var browserPart = parts.FirstOrDefault(p => p.Trim().StartsWith("Browser:"));
            
            if (browserPart != null)
            {
                return browserPart.Replace("Browser:", "").Trim();
            }
            
            return "Desktop App";
        }

        private string ExtractPlatform(string clientInfo)
        {
            if (string.IsNullOrEmpty(clientInfo)) return "Windows";
            
            var parts = clientInfo.Split(',');
            var platformPart = parts.FirstOrDefault(p => p.Trim().StartsWith("Platform:"));
            
            if (platformPart != null)
            {
                return platformPart.Replace("Platform:", "").Trim();
            }
            
            return "Windows";
        }
    }
}