using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// UI responsiveness üçün async/await implementasiyası
    /// ORTA PRİORİTET: Uzun çəkən əməliyyatların asinxron edilməsi
    /// </summary>
    public class AsyncUIService : BaseDisposableService
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public AsyncUIService(IUnitOfWork unitOfWork, ILoggerService logger = null) 
            : base(unitOfWork, logger)
        {
            _semaphore = new SemaphoreSlim(1, 1);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// UI-da progress göstərərək uzun çəkən əməliyyatı icra edir
        /// </summary>
        /// <typeparam name="T">Nəticə tipi</typeparam>
        /// <param name="operation">İcra ediləcək əməliyyat</param>
        /// <param name="progressCallback">Progress callback</param>
        /// <param name="description">Əməliyyat açıqlaması</param>
        /// <returns>Əməliyyat nəticəsi</returns>
        public async Task<T> ExecuteWithProgressAsync<T>(
            Func<IProgress<ProgressInfo>, CancellationToken, Task<T>> operation,
            Action<ProgressInfo> progressCallback = null,
            string description = "Yüklənir...")
        {
            ThrowIfDisposed();
            
            var progress = new Progress<ProgressInfo>(info => 
            {
                progressCallback?.Invoke(info);
                _logger?.LogInfo($"Progress: {info.Message} ({info.Percentage}%)");
            });

            try
            {
                // UI cursor-unu wait-ə çevir
                var originalCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    progress.Report(new ProgressInfo { Message = description, Percentage = 0 });
                    
                    var result = await operation(progress, _cancellationTokenSource.Token);
                    
                    progress.Report(new ProgressInfo { Message = "Tamamlandı", Percentage = 100 });
                    
                    return result;
                }
                finally
                {
                    Cursor.Current = originalCursor;
                }
            }
            catch (OperationCanceledException)
            {
                _logger?.LogInfo($"Operation cancelled: {description}");
                throw;
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception($"Async operation failed: {description}", ex));
                throw;
            }
        }

        /// <summary>
        /// Bütün müştəriləri asinxron yüklər
        /// </summary>
        /// <param name="progress">Progress reporter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Müştəri siyahısı</returns>
        public async Task<List<Musteri>> LoadAllCustomersAsync(
            IProgress<ProgressInfo> progress = null, 
            CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            
            await _semaphore.WaitAsync(cancellationToken);
            
            try
            {
                progress?.Report(new ProgressInfo { Message = "Müştəri məlumatları yüklənir...", Percentage = 0 });
                
                // Simulate database delay for demonstration
                await Task.Delay(500, cancellationToken);
                
                var customers = await Task.Run(() => 
                    _unitOfWork.Musteriler.GetAll().ToList(), cancellationToken);
                
                progress?.Report(new ProgressInfo { Message = "Məlumatlar emal edilir...", Percentage = 50 });
                
                // Process customers in batches to show progress
                var processedCustomers = new List<Musteri>();
                int batchSize = 100;
                
                for (int i = 0; i < customers.Count; i += batchSize)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    
                    var batch = customers.Skip(i).Take(batchSize).ToList();
                    processedCustomers.AddRange(batch);
                    
                    int percentage = (int)((double)(i + batchSize) / customers.Count * 50) + 50;
                    progress?.Report(new ProgressInfo 
                    { 
                        Message = $"Emal edildi: {Math.Min(i + batchSize, customers.Count)}/{customers.Count}", 
                        Percentage = Math.Min(percentage, 100) 
                    });
                    
                    // Small delay to demonstrate progress
                    await Task.Delay(50, cancellationToken);
                }
                
                progress?.Report(new ProgressInfo { Message = "Tamamlandı", Percentage = 100 });
                
                return processedCustomers;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Böyük məlumat dəstini asinxron yüklər və cache edir
        /// </summary>
        /// <typeparam name="T">Entity tipi</typeparam>
        /// <param name="dataLoader">Data loader funksiyası</param>
        /// <param name="cacheKey">Cache key</param>
        /// <param name="description">Əməliyyat açıqlaması</param>
        /// <returns>Məlumat siyahısı</returns>
        public async Task<List<T>> LoadLargeDatasetAsync<T>(
            Func<Task<List<T>>> dataLoader,
            string cacheKey,
            string description = "Məlumatlar yüklənir...")
        {
            ThrowIfDisposed();
            
            return await ExecuteWithProgressAsync(async (progress, cancellationToken) =>
            {
                progress.Report(new ProgressInfo { Message = description, Percentage = 0 });
                
                // Check cache first
                if (CacheService.Instance.TryGet<List<T>>(cacheKey, out var cachedData))
                {
                    progress.Report(new ProgressInfo { Message = "Cache-dən yüklənir...", Percentage = 100 });
                    return cachedData;
                }
                
                progress.Report(new ProgressInfo { Message = "Verilənlər bazasından yüklənir...", Percentage = 25 });
                
                var data = await dataLoader();
                
                progress.Report(new ProgressInfo { Message = "Cache-ə saxlanılır...", Percentage = 75 });
                
                // Cache for 5 minutes
                CacheService.Instance.Set(cacheKey, data, TimeSpan.FromMinutes(5));
                
                return data;
            }, null, description);
        }

        /// <summary>
        /// Batch əməliyyatlarını asinxron icra edir
        /// </summary>
        /// <typeparam name="T">Item tipi</typeparam>
        /// <param name="items">Emal ediləcək itemlər</param>
        /// <param name="processor">Processor funksiyası</param>
        /// <param name="batchSize">Batch ölçüsü</param>
        /// <param name="description">Əməliyyat açıqlaması</param>
        /// <returns>Emal nəticələri</returns>
        public async Task<List<TResult>> ProcessBatchAsync<T, TResult>(
            List<T> items,
            Func<T, Task<TResult>> processor,
            int batchSize = 10,
            string description = "Batch emal edilir...")
        {
            ThrowIfDisposed();
            
            return await ExecuteWithProgressAsync(async (progress, cancellationToken) =>
            {
                var results = new List<TResult>();
                
                for (int i = 0; i < items.Count; i += batchSize)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    
                    var batch = items.Skip(i).Take(batchSize).ToList();
                    var batchTasks = batch.Select(processor).ToList();
                    
                    var batchResults = await Task.WhenAll(batchTasks);
                    results.AddRange(batchResults);
                    
                    int percentage = (int)((double)(i + batchSize) / items.Count * 100);
                    progress.Report(new ProgressInfo 
                    { 
                        Message = $"Emal edildi: {Math.Min(i + batchSize, items.Count)}/{items.Count}", 
                        Percentage = Math.Min(percentage, 100) 
                    });
                }
                
                return results;
            }, null, description);
        }

        /// <summary>
        /// Əməliyyatı iptal edir
        /// </summary>
        public void CancelOperation()
        {
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Yeni cancellation token yaradır
        /// </summary>
        public CancellationToken CreateCancellationToken()
        {
            return _cancellationTokenSource.Token;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource?.Dispose();
                _semaphore?.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// Progress məlumatları
    /// </summary>
    public class ProgressInfo
    {
        public string Message { get; set; }
        public int Percentage { get; set; }
        public object Data { get; set; }
    }

    /// <summary>
    /// Async form helper
    /// </summary>
    public static class AsyncFormHelper
    {
        /// <summary>
        /// Form-da async əməliyyat icra edir
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onCompleted">Tamamlandıqda çağrılacaq callback</param>
        /// <param name="onError">Xəta zamanı çağrılacaq callback</param>
        public static async void ExecuteAsync(
            this Form form,
            Func<Task> operation,
            Action onCompleted = null,
            Action<Exception> onError = null)
        {
            try
            {
                form.Enabled = false;
                form.Cursor = Cursors.WaitCursor;
                
                await operation();
                
                onCompleted?.Invoke();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
            finally
            {
                form.Enabled = true;
                form.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Form-da async əməliyyat icra edir və nəticə qaytarır
        /// </summary>
        /// <typeparam name="T">Nəticə tipi</typeparam>
        /// <param name="form">Form</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onCompleted">Tamamlandıqda çağrılacaq callback</param>
        /// <param name="onError">Xəta zamanı çağrılacaq callback</param>
        public static async void ExecuteAsync<T>(
            this Form form,
            Func<Task<T>> operation,
            Action<T> onCompleted = null,
            Action<Exception> onError = null)
        {
            try
            {
                form.Enabled = false;
                form.Cursor = Cursors.WaitCursor;
                
                var result = await operation();
                
                onCompleted?.Invoke(result);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
            finally
            {
                form.Enabled = true;
                form.Cursor = Cursors.Default;
            }
        }
    }
}