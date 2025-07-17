using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Resursların düzgün idarə edilməsi üçün base servis
    /// YÜKSƏK PRİORİTET PROBLEMİ: IDisposable pattern-in düzgün tətbiqi
    /// </summary>
    public abstract class BaseDisposableService : IDisposable
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILoggerService _logger;
        protected bool _disposed = false;

        protected BaseDisposableService(IUnitOfWork unitOfWork, ILoggerService logger = null)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger;
        }

        /// <summary>
        /// Resursları təhlükəsiz şəkildə azad edir
        /// </summary>
        /// <param name="disposing">Managed resurslar azad edilsin</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        // Managed resources
                        _unitOfWork?.Dispose();
                        _logger?.LogInfo($"{GetType().Name} disposed successfully");
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(new Exception($"{GetType().Name} dispose error", ex));
                    }
                }

                // Unmanaged resources burada azad edilər
                _disposed = true;
            }
        }

        /// <summary>
        /// Public dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer (son çarə)
        /// </summary>
        ~BaseDisposableService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Servisi dispose olunmuş vəziyyətdə istifadə etmək cəhdini yoxlayır
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }

    /// <summary>
    /// Resurslara nəzarət edən və memory leak-ləri izləyən servis
    /// </summary>
    public class ResourceMonitoringService : BaseDisposableService
    {
        private readonly Dictionary<string, ResourceInfo> _trackedResources;
        private readonly object _lockObject = new object();

        public ResourceMonitoringService(IUnitOfWork unitOfWork, ILoggerService logger = null) 
            : base(unitOfWork, logger)
        {
            _trackedResources = new Dictionary<string, ResourceInfo>();
        }

        /// <summary>
        /// Resursun açıldığını qeyd edir
        /// </summary>
        /// <param name="resourceId">Resurs identifikatoru</param>
        /// <param name="resourceType">Resurs növü</param>
        /// <param name="description">Açıqlama</param>
        public void TrackResource(string resourceId, string resourceType, string description = null)
        {
            ThrowIfDisposed();

            lock (_lockObject)
            {
                var resourceInfo = new ResourceInfo
                {
                    Id = resourceId,
                    Type = resourceType,
                    Description = description,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                _trackedResources[resourceId] = resourceInfo;
                _logger?.LogInfo($"Resource tracked: {resourceType} - {resourceId}");
            }
        }

        /// <summary>
        /// Resursun bağlandığını qeyd edir
        /// </summary>
        /// <param name="resourceId">Resurs identifikatoru</param>
        public void UntrackResource(string resourceId)
        {
            ThrowIfDisposed();

            lock (_lockObject)
            {
                if (_trackedResources.TryGetValue(resourceId, out var resourceInfo))
                {
                    resourceInfo.IsActive = false;
                    resourceInfo.DisposedAt = DateTime.Now;
                    resourceInfo.LifeTime = resourceInfo.DisposedAt.Value - resourceInfo.CreatedAt;
                    
                    _logger?.LogInfo($"Resource untracked: {resourceInfo.Type} - {resourceId} (Lifetime: {resourceInfo.LifeTime})");
                }
            }
        }

        /// <summary>
        /// Aktiv resursların siyahısını qaytarır
        /// </summary>
        /// <returns>Aktiv resurs siyahısı</returns>
        public List<ResourceInfo> GetActiveResources()
        {
            ThrowIfDisposed();

            lock (_lockObject)
            {
                var activeResources = new List<ResourceInfo>();
                foreach (var kvp in _trackedResources)
                {
                    if (kvp.Value.IsActive)
                    {
                        activeResources.Add(kvp.Value);
                    }
                }
                return activeResources;
            }
        }

        /// <summary>
        /// Memory leak şübhəli resursları tapır
        /// </summary>
        /// <param name="maxLifeTimeMinutes">Maksimum yaşayış müddəti (dəqiqə)</param>
        /// <returns>Şübhəli resurs siyahısı</returns>
        public List<ResourceInfo> GetSuspiciousResources(int maxLifeTimeMinutes = 30)
        {
            ThrowIfDisposed();

            lock (_lockObject)
            {
                var suspiciousResources = new List<ResourceInfo>();
                var threshold = DateTime.Now.AddMinutes(-maxLifeTimeMinutes);

                foreach (var kvp in _trackedResources)
                {
                    var resource = kvp.Value;
                    if (resource.IsActive && resource.CreatedAt < threshold)
                    {
                        suspiciousResources.Add(resource);
                    }
                }

                if (suspiciousResources.Count > 0)
                {
                    _logger?.LogWarning($"Suspicious resources found: {suspiciousResources.Count} resources older than {maxLifeTimeMinutes} minutes");
                }

                return suspiciousResources;
            }
        }

        /// <summary>
        /// Resurs statistikası
        /// </summary>
        /// <returns>Resurs statistikası</returns>
        public ResourceStatistics GetResourceStatistics()
        {
            ThrowIfDisposed();

            lock (_lockObject)
            {
                var stats = new ResourceStatistics
                {
                    TotalResources = _trackedResources.Count,
                    ActiveResources = 0,
                    DisposedResources = 0,
                    GeneratedAt = DateTime.Now
                };

                var totalLifeTime = TimeSpan.Zero;
                int disposedCount = 0;

                foreach (var kvp in _trackedResources)
                {
                    var resource = kvp.Value;
                    if (resource.IsActive)
                    {
                        stats.ActiveResources++;
                    }
                    else
                    {
                        stats.DisposedResources++;
                        if (resource.LifeTime.HasValue)
                        {
                            totalLifeTime += resource.LifeTime.Value;
                            disposedCount++;
                        }
                    }
                }

                stats.AverageLifeTime = disposedCount > 0 ? totalLifeTime.TotalSeconds / disposedCount : 0;
                
                return stats;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                // Aktiv resursları log-la
                var activeResources = GetActiveResources();
                if (activeResources.Count > 0)
                {
                    _logger?.LogWarning($"ResourceMonitoringService disposed with {activeResources.Count} active resources - potential memory leak");
                }

                lock (_lockObject)
                {
                    _trackedResources.Clear();
                }
            }

            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Resurs məlumatları
    /// </summary>
    public class ResourceInfo
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DisposedAt { get; set; }
        public TimeSpan? LifeTime { get; set; }
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// Resurs statistikası
    /// </summary>
    public class ResourceStatistics
    {
        public int TotalResources { get; set; }
        public int ActiveResources { get; set; }
        public int DisposedResources { get; set; }
        public double AverageLifeTime { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}