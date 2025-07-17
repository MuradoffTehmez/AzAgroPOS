using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Performance optimization üçün caching servisi
    /// ORTA PRİORİTET: Tez-tez istifadə olunan məlumatların cache edilməsi
    /// </summary>
    public sealed class CacheService : IDisposable
    {
        private static readonly Lazy<CacheService> _instance = new Lazy<CacheService>(() => new CacheService());
        public static CacheService Instance => _instance.Value;

        private readonly ConcurrentDictionary<string, CacheItem> _cache;
        private readonly Timer _cleanupTimer;
        private readonly ReaderWriterLockSlim _rwLock;
        private readonly ILoggerService _logger;
        private bool _disposed = false;

        private CacheService()
        {
            _cache = new ConcurrentDictionary<string, CacheItem>();
            _rwLock = new ReaderWriterLockSlim();
            _logger = new FileLoggerService(); // Direct instantiation for singleton
            
            // Cleanup timer - hər 5 dəqiqədə bir köhnə cache item-ları təmizlə
            _cleanupTimer = new Timer(CleanupExpiredItems, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
        }

        /// <summary>
        /// Cache-ə məlumat əlavə edir
        /// </summary>
        /// <typeparam name="T">Məlumat tipi</typeparam>
        /// <param name="key">Cache açarı</param>
        /// <param name="value">Məlumat</param>
        /// <param name="expiration">Bitmə müddəti</param>
        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            if (string.IsNullOrEmpty(key) || value == null)
                return;

            _rwLock.EnterWriteLock();
            try
            {
                var cacheItem = new CacheItem
                {
                    Key = key,
                    Value = value,
                    ExpirationTime = DateTime.UtcNow.Add(expiration),
                    CreatedAt = DateTime.UtcNow,
                    AccessCount = 0,
                    LastAccessTime = DateTime.UtcNow
                };

                _cache.AddOrUpdate(key, cacheItem, (k, v) => cacheItem);
                _logger?.LogInfo($"Cache SET: {key} (expires in {expiration.TotalMinutes:F1} minutes)");
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Cache-dən məlumat oxuyur
        /// </summary>
        /// <typeparam name="T">Məlumat tipi</typeparam>
        /// <param name="key">Cache açarı</param>
        /// <param name="value">Çıxış məlumatı</param>
        /// <returns>Tapılıb-tapılmadığı</returns>
        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);
            
            if (string.IsNullOrEmpty(key))
                return false;

            _rwLock.EnterReadLock();
            try
            {
                if (_cache.TryGetValue(key, out var cacheItem))
                {
                    if (DateTime.UtcNow < cacheItem.ExpirationTime)
                    {
                        // Update access statistics
                        cacheItem.AccessCount++;
                        cacheItem.LastAccessTime = DateTime.UtcNow;
                        
                        value = (T)cacheItem.Value;
                        _logger?.LogInfo($"Cache HIT: {key} (access count: {cacheItem.AccessCount})");
                        return true;
                    }
                    else
                    {
                        // Expired, remove from cache
                        _cache.TryRemove(key, out _);
                        _logger?.LogInfo($"Cache EXPIRED: {key}");
                    }
                }
                
                _logger?.LogInfo($"Cache MISS: {key}");
                return false;
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Cache-dən məlumat oxuyur və ya yenisini yüklər
        /// </summary>
        /// <typeparam name="T">Məlumat tipi</typeparam>
        /// <param name="key">Cache açarı</param>
        /// <param name="factory">Məlumat yükləyən funksiya</param>
        /// <param name="expiration">Bitmə müddəti</param>
        /// <returns>Məlumat</returns>
        public T GetOrSet<T>(string key, Func<T> factory, TimeSpan expiration)
        {
            if (TryGet<T>(key, out var cachedValue))
            {
                return cachedValue;
            }

            var value = factory();
            Set(key, value, expiration);
            return value;
        }

        /// <summary>
        /// Async cache get-or-set
        /// </summary>
        /// <typeparam name="T">Məlumat tipi</typeparam>
        /// <param name="key">Cache açarı</param>
        /// <param name="factory">Async məlumat yükləyən funksiya</param>
        /// <param name="expiration">Bitmə müddəti</param>
        /// <returns>Məlumat</returns>
        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan expiration)
        {
            if (TryGet<T>(key, out var cachedValue))
            {
                return cachedValue;
            }

            var value = await factory();
            Set(key, value, expiration);
            return value;
        }

        /// <summary>
        /// Cache-dən məlumat sil
        /// </summary>
        /// <param name="key">Cache açarı</param>
        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;

            _rwLock.EnterWriteLock();
            try
            {
                if (_cache.TryRemove(key, out _))
                {
                    _logger?.LogInfo($"Cache REMOVE: {key}");
                }
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Müəyyən pattern-ə uyğun cache açarlarını sil
        /// </summary>
        /// <param name="pattern">Pattern (məs: "user_*")</param>
        public void RemoveByPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return;

            _rwLock.EnterWriteLock();
            try
            {
                var keysToRemove = _cache.Keys
                    .Where(key => IsPatternMatch(key, pattern))
                    .ToList();

                foreach (var key in keysToRemove)
                {
                    _cache.TryRemove(key, out _);
                }

                _logger?.LogInfo($"Cache REMOVE BY PATTERN: {pattern} ({keysToRemove.Count} items removed)");
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Bütün cache-i təmizlə
        /// </summary>
        public void Clear()
        {
            _rwLock.EnterWriteLock();
            try
            {
                var count = _cache.Count;
                _cache.Clear();
                _logger?.LogInfo($"Cache CLEAR: {count} items removed");
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Cache statistikalarını əldə edir
        /// </summary>
        /// <returns>Cache statistikaları</returns>
        public CacheStatistics GetStatistics()
        {
            _rwLock.EnterReadLock();
            try
            {
                var now = DateTime.UtcNow;
                var items = _cache.Values.ToList();
                
                return new CacheStatistics
                {
                    TotalItems = items.Count,
                    ExpiredItems = items.Count(i => i.ExpirationTime < now),
                    ActiveItems = items.Count(i => i.ExpirationTime >= now),
                    TotalAccessCount = items.Sum(i => i.AccessCount),
                    AverageAccessCount = items.Count > 0 ? items.Average(i => i.AccessCount) : 0,
                    OldestItem = items.OrderBy(i => i.CreatedAt).FirstOrDefault()?.CreatedAt,
                    NewestItem = items.OrderByDescending(i => i.CreatedAt).FirstOrDefault()?.CreatedAt,
                    MostAccessedKey = items.OrderByDescending(i => i.AccessCount).FirstOrDefault()?.Key,
                    GeneratedAt = now
                };
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Köhnə cache item-larını təmizlə
        /// </summary>
        /// <param name="state">Timer state</param>
        private void CleanupExpiredItems(object state)
        {
            try
            {
                _rwLock.EnterWriteLock();
                try
                {
                    var now = DateTime.UtcNow;
                    var expiredKeys = _cache
                        .Where(kvp => kvp.Value.ExpirationTime < now)
                        .Select(kvp => kvp.Key)
                        .ToList();

                    foreach (var key in expiredKeys)
                    {
                        _cache.TryRemove(key, out _);
                    }

                    if (expiredKeys.Count > 0)
                    {
                        _logger?.LogInfo($"Cache CLEANUP: {expiredKeys.Count} expired items removed");
                    }
                }
                finally
                {
                    _rwLock.ExitWriteLock();
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception("Cache cleanup error", ex));
            }
        }

        /// <summary>
        /// Pattern matching helper
        /// </summary>
        /// <param name="input">Giriş mətni</param>
        /// <param name="pattern">Pattern</param>
        /// <returns>Uyğunluq</returns>
        private bool IsPatternMatch(string input, string pattern)
        {
            if (pattern.EndsWith("*"))
            {
                return input.StartsWith(pattern.Substring(0, pattern.Length - 1));
            }
            if (pattern.StartsWith("*"))
            {
                return input.EndsWith(pattern.Substring(1));
            }
            return input.Equals(pattern);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _cleanupTimer?.Dispose();
                _rwLock?.Dispose();
                _cache?.Clear();
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Cache item
    /// </summary>
    internal class CacheItem
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public DateTime ExpirationTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int AccessCount { get; set; }
    }

    /// <summary>
    /// Cache statistikaları
    /// </summary>
    public class CacheStatistics
    {
        public int TotalItems { get; set; }
        public int ExpiredItems { get; set; }
        public int ActiveItems { get; set; }
        public long TotalAccessCount { get; set; }
        public double AverageAccessCount { get; set; }
        public DateTime? OldestItem { get; set; }
        public DateTime? NewestItem { get; set; }
        public string MostAccessedKey { get; set; }
        public DateTime GeneratedAt { get; set; }
    }

    /// <summary>
    /// Cache extension methods
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Müştəri məlumatlarını cache-dən əldə edir
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        /// <param name="customerId">Müştəri ID</param>
        /// <param name="customerLoader">Müştəri yükləyən funksiya</param>
        /// <returns>Müştəri məlumatları</returns>
        public static async Task<T> GetCustomerAsync<T>(this CacheService cache, int customerId, Func<Task<T>> customerLoader)
        {
            var key = $"customer_{customerId}";
            return await cache.GetOrSetAsync(key, customerLoader, TimeSpan.FromMinutes(15));
        }

        /// <summary>
        /// Məhsul məlumatlarını cache-dən əldə edir
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        /// <param name="productId">Məhsul ID</param>
        /// <param name="productLoader">Məhsul yükləyən funksiya</param>
        /// <returns>Məhsul məlumatları</returns>
        public static async Task<T> GetProductAsync<T>(this CacheService cache, int productId, Func<Task<T>> productLoader)
        {
            var key = $"product_{productId}";
            return await cache.GetOrSetAsync(key, productLoader, TimeSpan.FromMinutes(30));
        }

        /// <summary>
        /// Sistem konfiqurasiyasını cache-dən əldə edir
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        /// <param name="configKey">Konfiqurasiya açarı</param>
        /// <param name="configLoader">Konfiqurasiya yükləyən funksiya</param>
        /// <returns>Konfiqurasiya dəyəri</returns>
        public static T GetSystemConfig<T>(this CacheService cache, string configKey, Func<T> configLoader)
        {
            var key = $"config_{configKey}";
            return cache.GetOrSet(key, configLoader, TimeSpan.FromHours(1));
        }

        /// <summary>
        /// Müştəri cache-ini yenilə
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        /// <param name="customerId">Müştəri ID</param>
        public static void InvalidateCustomer(this CacheService cache, int customerId)
        {
            cache.Remove($"customer_{customerId}");
        }

        /// <summary>
        /// Məhsul cache-ini yenilə
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        /// <param name="productId">Məhsul ID</param>
        public static void InvalidateProduct(this CacheService cache, int productId)
        {
            cache.Remove($"product_{productId}");
        }

        /// <summary>
        /// Bütün məhsul cache-ini yenilə
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        public static void InvalidateAllProducts(this CacheService cache)
        {
            cache.RemoveByPattern("product_*");
        }

        /// <summary>
        /// Bütün müştəri cache-ini yenilə
        /// </summary>
        /// <param name="cache">Cache servisi</param>
        public static void InvalidateAllCustomers(this CacheService cache)
        {
            cache.RemoveByPattern("customer_*");
        }
    }
}