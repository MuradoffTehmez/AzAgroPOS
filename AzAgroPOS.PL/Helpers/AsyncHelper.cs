using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Helpers
{
    /// <summary>
    /// Async Operations Helper
    /// WinForms və UI thread-lər üçün async əməliyyatların idarəetməsi
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// UI thread-də async əməliyyatı təhlükəsiz şəkildə icra etmək
        /// </summary>
        /// <param name="control">UI control (form, button və s.)</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onError">Xəta baş verdikdə çağırılacaq metod</param>
        /// <param name="onFinally">Həmişə çağırılacaq metod</param>
        public static async Task ExecuteAsync(Control control, Func<Task> operation, 
            Action<Exception> onError = null, Action onFinally = null)
        {
            try
            {
                if (control.InvokeRequired)
                {
                    await Task.Run(async () =>
                    {
                        await operation();
                    });
                }
                else
                {
                    await operation();
                }
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => onError(ex)));
                    }
                    else
                    {
                        onError(ex);
                    }
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (onFinally != null)
                {
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => onFinally()));
                    }
                    else
                    {
                        onFinally();
                    }
                }
            }
        }

        /// <summary>
        /// UI thread-də async əməliyyatı təhlükəsiz şəkildə icra etmək (generic return type)
        /// </summary>
        /// <typeparam name="T">Geri qaytarılan tip</typeparam>
        /// <param name="control">UI control</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onError">Xəta baş verdikdə çağırılacaq metod</param>
        /// <param name="onFinally">Həmişə çağırılacaq metod</param>
        /// <returns>Operation nəticəsi</returns>
        public static async Task<T> ExecuteAsync<T>(Control control, Func<Task<T>> operation, 
            Action<Exception> onError = null, Action onFinally = null, T defaultValue = default(T))
        {
            try
            {
                if (control.InvokeRequired)
                {
                    return await Task.Run(async () =>
                    {
                        return await operation();
                    });
                }
                else
                {
                    return await operation();
                }
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => onError(ex)));
                    }
                    else
                    {
                        onError(ex);
                    }
                }
                else
                {
                    throw;
                }
                return defaultValue;
            }
            finally
            {
                if (onFinally != null)
                {
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(() => onFinally()));
                    }
                    else
                    {
                        onFinally();
                    }
                }
            }
        }

        /// <summary>
        /// UI thread-də loading state-ni idarə edən async əməliyyat
        /// </summary>
        /// <param name="control">Ana control</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="loadingControl">Loading göstəriləcək control (null olsa ana control istifadə edilir)</param>
        /// <param name="onError">Xəta handler</param>
        public static async Task ExecuteWithLoadingAsync(Control control, Func<Task> operation, 
            Control loadingControl = null, Action<Exception> onError = null)
        {
            var targetControl = loadingControl ?? control;
            var originalCursor = control.Cursor;
            var originalEnabled = targetControl.Enabled;

            try
            {
                // Loading state-ni set et
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Cursor = Cursors.WaitCursor;
                        targetControl.Enabled = false;
                    }));
                }
                else
                {
                    control.Cursor = Cursors.WaitCursor;
                    targetControl.Enabled = false;
                }

                // Async əməliyyatı icra et
                await ExecuteAsync(control, operation, onError);
            }
            finally
            {
                // Loading state-ni bərpa et
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Cursor = originalCursor;
                        targetControl.Enabled = originalEnabled;
                    }));
                }
                else
                {
                    control.Cursor = originalCursor;
                    targetControl.Enabled = originalEnabled;
                }
            }
        }

        /// <summary>
        /// Button click event-ini async edən helper
        /// </summary>
        /// <param name="button">Button kontrolü</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="disableButton">Click zamanı button-u disable etmək</param>
        public static async Task HandleButtonClickAsync(Button button, Func<Task> operation, 
            Action<Exception> onError = null, bool disableButton = true)
        {
            var originalEnabled = button.Enabled;
            var originalText = button.Text;

            try
            {
                if (disableButton)
                {
                    button.Enabled = false;
                    button.Text = "Gözləyin...";
                }

                await ExecuteAsync(button, operation, onError);
            }
            finally
            {
                if (disableButton)
                {
                    button.Enabled = originalEnabled;
                    button.Text = originalText;
                }
            }
        }

        /// <summary>
        /// DataGridView-i async yükləmək
        /// </summary>
        /// <param name="dataGridView">DataGridView kontrolü</param>
        /// <param name="loadDataOperation">Data yüklənməsi əməliyyatı</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="showLoadingMessage">Loading mesajı göstərmək</param>
        public static async Task LoadDataGridViewAsync<T>(DataGridView dataGridView, 
            Func<Task<System.Collections.Generic.List<T>>> loadDataOperation, 
            Action<Exception> onError = null, bool showLoadingMessage = true)
        {
            var originalDataSource = dataGridView.DataSource;

            try
            {
                if (showLoadingMessage)
                {
                    // Loading mesajını göstər
                    dataGridView.DataSource = null;
                    dataGridView.Refresh();
                }

                // Async data yüklənməsi
                var data = await ExecuteAsync(dataGridView, loadDataOperation, onError);

                // Data-nı set et
                if (dataGridView.InvokeRequired)
                {
                    dataGridView.Invoke(new Action(() =>
                    {
                        dataGridView.DataSource = data;
                        dataGridView.Refresh();
                    }));
                }
                else
                {
                    dataGridView.DataSource = data;
                    dataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                // Xəta halında köhnə data source-u bərpa et
                if (dataGridView.InvokeRequired)
                {
                    dataGridView.Invoke(new Action(() =>
                    {
                        dataGridView.DataSource = originalDataSource;
                        dataGridView.Refresh();
                    }));
                }
                else
                {
                    dataGridView.DataSource = originalDataSource;
                    dataGridView.Refresh();
                }

                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Form loading event-ini async edən helper
        /// </summary>
        /// <param name="form">Form kontrolü</param>
        /// <param name="initializeOperation">Başlatma əməliyyatı</param>
        /// <param name="onError">Xəta handler</param>
        public static async Task HandleFormLoadAsync(Form form, Func<Task> initializeOperation, 
            Action<Exception> onError = null)
        {
            try
            {
                form.UseWaitCursor = true;
                await ExecuteAsync(form, initializeOperation, onError);
            }
            finally
            {
                form.UseWaitCursor = false;
            }
        }

        /// <summary>
        /// Timeout ilə async əməliyyat
        /// </summary>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="timeoutMilliseconds">Timeout müddəti (millisaniyə)</param>
        /// <param name="onTimeout">Timeout baş verdikdə çağırılacaq metod</param>
        /// <returns>Operation nəticəsi</returns>
        public static async Task<T> ExecuteWithTimeoutAsync<T>(Func<Task<T>> operation, 
            int timeoutMilliseconds = 30000, Action onTimeout = null)
        {
            try
            {
                var timeoutTask = Task.Delay(timeoutMilliseconds);
                var operationTask = operation();
                
                var completedTask = await Task.WhenAny(operationTask, timeoutTask);
                
                if (completedTask == timeoutTask)
                {
                    onTimeout?.Invoke();
                    throw new TimeoutException($"Əməliyyat {timeoutMilliseconds}ms müddətində tamamlanmadı");
                }
                
                return await operationTask;
            }
            catch (TimeoutException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Async əməliyyat xətası: {ex.Message}", ex);
            }
        }
    }
}