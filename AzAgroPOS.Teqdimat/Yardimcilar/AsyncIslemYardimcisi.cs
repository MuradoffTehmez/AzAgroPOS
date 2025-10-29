namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Helper class for executing async operations with loading indicators
    /// </summary>
    public static class AsyncIslemYardimcisi
    {
        private static readonly Dictionary<string, CancellationTokenSource> _activeTasks = new();
        private static readonly Dictionary<string, System.Timers.Timer> _debounceTimers = new();
        private static readonly object _lock = new();

        /// <summary>
        /// Executes an async operation with loading indicator
        /// </summary>
        /// <param name="form">Form to show loading indicator on</param>
        /// <param name="operation">Async operation to execute</param>
        public static async Task IslemiIcraEt(BazaForm form, Func<Task> operation)
        {
            try
            {
                form.YuklemeBasladi();
                await operation();
            }
            finally
            {
                form.YuklemeBitdi();
            }
        }

        /// <summary>
        /// Executes an async operation with loading indicator and returns a result
        /// </summary>
        /// <typeparam name="T">Type of result</typeparam>
        /// <param name="form">Form to show loading indicator on</param>
        /// <param name="operation">Async operation to execute</param>
        /// <returns>Result of the operation</returns>
        public static async Task<T> IslemiIcraEt<T>(BazaForm form, Func<Task<T>> operation)
        {
            try
            {
                form.YuklemeBasladi();
                return await operation();
            }
            finally
            {
                form.YuklemeBitdi();
            }
        }

        /// <summary>
        /// Executes a debounced search operation with automatic cancellation of previous searches
        /// diqqət: Axtarış əməliyyatlarında istifadə üçün - debouncing və cancellation dəstəkləyir
        /// qeyd: Eyni açar ilə yeni axtarış başladıqda əvvəlki axtarış ləğv edilir
        /// </summary>
        /// <param name="key">Unique key to identify the search operation (e.g., form name + control name)</param>
        /// <param name="operation">Async search operation to execute</param>
        /// <param name="debounceMilliseconds">Debounce delay in milliseconds (default: 300ms)</param>
        public static void DebouncedAxtaris(string key, Func<CancellationToken, Task> operation, int debounceMilliseconds = 300)
        {
            lock (_lock)
            {
                // Cancel previous search with same key
                if (_activeTasks.TryGetValue(key, out var existingCts))
                {
                    existingCts.Cancel();
                    existingCts.Dispose();
                    _activeTasks.Remove(key);
                }

                // Stop existing debounce timer
                if (_debounceTimers.TryGetValue(key, out var existingTimer))
                {
                    existingTimer.Stop();
                    existingTimer.Dispose();
                    _debounceTimers.Remove(key);
                }

                // Create new debounce timer
                var timer = new System.Timers.Timer(debounceMilliseconds);
                timer.AutoReset = false;
                timer.Elapsed += async (s, e) =>
                {
                    lock (_lock)
                    {
                        _debounceTimers.Remove(key);
                    }

                    // Create new cancellation token for this search
                    var cts = new CancellationTokenSource();
                    lock (_lock)
                    {
                        _activeTasks[key] = cts;
                    }

                    try
                    {
                        await operation(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Search was cancelled, this is expected
                    }
                    catch (Exception ex)
                    {
                        // Log error but don't crash
                        System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
                    }
                    finally
                    {
                        lock (_lock)
                        {
                            if (_activeTasks.TryGetValue(key, out var currentCts) && currentCts == cts)
                            {
                                _activeTasks.Remove(key);
                            }
                            cts.Dispose();
                        }
                    }
                };

                _debounceTimers[key] = timer;
                timer.Start();
            }
        }

        /// <summary>
        /// Cancels all active search operations with the given key
        /// </summary>
        /// <param name="key">Key of the search to cancel</param>
        public static void AxtarisiLeqvEt(string key)
        {
            lock (_lock)
            {
                if (_activeTasks.TryGetValue(key, out var cts))
                {
                    cts.Cancel();
                    cts.Dispose();
                    _activeTasks.Remove(key);
                }

                if (_debounceTimers.TryGetValue(key, out var timer))
                {
                    timer.Stop();
                    timer.Dispose();
                    _debounceTimers.Remove(key);
                }
            }
        }
    }
}