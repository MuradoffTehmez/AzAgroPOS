using AzAgroPOS.PL.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Extensions
{
    /// <summary>
    /// Async Operations Extension Methods
    /// WinForms kontrolları üçün async extension metodları
    /// </summary>
    public static class AsyncExtensions
    {
        /// <summary>
        /// Button-u async click handler ilə təmin etmək
        /// </summary>
        /// <param name="button">Button kontrolü</param>
        /// <param name="clickHandler">Async click handler</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="disableButton">Click zamanı button-u disable etmək</param>
        public static void SetAsyncClick(this Button button, Func<Task> clickHandler, 
            Action<Exception> onError = null, bool disableButton = true)
        {
            button.Click += async (sender, e) =>
            {
                await AsyncHelper.HandleButtonClickAsync(button, clickHandler, onError, disableButton);
            };
        }

        /// <summary>
        /// Form-u async load handler ilə təmin etmək
        /// </summary>
        /// <param name="form">Form kontrolü</param>
        /// <param name="loadHandler">Async load handler</param>
        /// <param name="onError">Xəta handler</param>
        public static void SetAsyncLoad(this Form form, Func<Task> loadHandler, 
            Action<Exception> onError = null)
        {
            form.Load += async (sender, e) =>
            {
                await AsyncHelper.HandleFormLoadAsync(form, loadHandler, onError);
            };
        }

        /// <summary>
        /// DataGridView-i async data ilə yükləmək
        /// </summary>
        /// <typeparam name="T">Data tipi</typeparam>
        /// <param name="dataGridView">DataGridView kontrolü</param>
        /// <param name="loadDataOperation">Data yüklənməsi əməliyyatı</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="showLoadingMessage">Loading mesajı göstərmək</param>
        public static async Task LoadDataAsync<T>(this DataGridView dataGridView, 
            Func<Task<System.Collections.Generic.List<T>>> loadDataOperation, 
            Action<Exception> onError = null, bool showLoadingMessage = true)
        {
            await AsyncHelper.LoadDataGridViewAsync(dataGridView, loadDataOperation, onError, showLoadingMessage);
        }

        /// <summary>
        /// TextBox-a async text changed handler əlavə etmək
        /// </summary>
        /// <param name="textBox">TextBox kontrolü</param>
        /// <param name="textChangedHandler">Async text changed handler</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="debounceMilliseconds">Debounce müddəti (millisaniyə)</param>
        public static void SetAsyncTextChanged(this TextBox textBox, Func<string, Task> textChangedHandler, 
            Action<Exception> onError = null, int debounceMilliseconds = 300)
        {
            System.Threading.Timer debounceTimer = null;

            textBox.TextChanged += (sender, e) =>
            {
                debounceTimer?.Dispose();
                debounceTimer = new System.Threading.Timer(async (state) =>
                {
                    try
                    {
                        var text = textBox.InvokeRequired ? 
                            (string)textBox.Invoke(new Func<string>(() => textBox.Text)) : 
                            textBox.Text;
                        
                        await textChangedHandler(text);
                    }
                    catch (Exception ex)
                    {
                        if (onError != null)
                        {
                            if (textBox.InvokeRequired)
                            {
                                textBox.Invoke(new Action(() => onError(ex)));
                            }
                            else
                            {
                                onError(ex);
                            }
                        }
                    }
                    finally
                    {
                        debounceTimer?.Dispose();
                    }
                }, null, debounceMilliseconds, System.Threading.Timeout.Infinite);
            };
        }

        /// <summary>
        /// ComboBox-a async selection changed handler əlavə etmək
        /// </summary>
        /// <param name="comboBox">ComboBox kontrolü</param>
        /// <param name="selectionChangedHandler">Async selection changed handler</param>
        /// <param name="onError">Xəta handler</param>
        public static void SetAsyncSelectionChanged(this ComboBox comboBox, 
            Func<object, Task> selectionChangedHandler, Action<Exception> onError = null)
        {
            comboBox.SelectedIndexChanged += async (sender, e) =>
            {
                try
                {
                    var selectedItem = comboBox.SelectedItem;
                    await selectionChangedHandler(selectedItem);
                }
                catch (Exception ex)
                {
                    if (onError != null)
                    {
                        if (comboBox.InvokeRequired)
                        {
                            comboBox.Invoke(new Action(() => onError(ex)));
                        }
                        else
                        {
                            onError(ex);
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Control-u loading state-ə keçirmək
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="isLoading">Loading state</param>
        /// <param name="loadingText">Loading mesajı</param>
        public static void SetLoadingState(this Control control, bool isLoading, string loadingText = "Yüklənir...")
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => SetLoadingStateInternal(control, isLoading, loadingText)));
            }
            else
            {
                SetLoadingStateInternal(control, isLoading, loadingText);
            }
        }

        private static void SetLoadingStateInternal(Control control, bool isLoading, string loadingText)
        {
            control.Enabled = !isLoading;
            control.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

            // Əgər control Button-dursa, text-ni dəyişdirmək
            if (control is Button button)
            {
                if (isLoading)
                {
                    button.Tag = button.Text; // Orijinal text-ni saxla
                    button.Text = loadingText;
                }
                else
                {
                    button.Text = button.Tag?.ToString() ?? button.Text;
                }
            }

            // Əgər control Label-dursa, text-ni dəyişdirmək
            if (control is Label label)
            {
                if (isLoading)
                {
                    label.Tag = label.Text; // Orijinal text-ni saxla
                    label.Text = loadingText;
                }
                else
                {
                    label.Text = label.Tag?.ToString() ?? label.Text;
                }
            }
        }

        /// <summary>
        /// DataGridView-də seçilmiş sətiri async əməliyyat ilə işləmək
        /// </summary>
        /// <typeparam name="T">Data tipi</typeparam>
        /// <param name="dataGridView">DataGridView kontrolü</param>
        /// <param name="operation">Async əməliyyat</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="noSelectionMessage">Seçim olmadıqda göstəriləcək mesaj</param>
        public static async Task ProcessSelectedRowAsync<T>(this DataGridView dataGridView, 
            Func<T, Task> operation, Action<Exception> onError = null, 
            string noSelectionMessage = "Əməliyyat üçün sətir seçin")
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show(noSelectionMessage, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedItem = (T)dataGridView.SelectedRows[0].DataBoundItem;
                if (selectedItem == null)
                {
                    MessageBox.Show("Seçilmiş sətir məlumatı tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await operation(selectedItem);
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    MessageBox.Show($"Əməliyyat zamanı xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Multiple async operations-i parallel icra etmək
        /// </summary>
        /// <param name="form">Form kontrolü</param>
        /// <param name="operations">Async əməliyyatlar</param>
        /// <param name="onError">Xəta handler</param>
        /// <param name="showProgress">Progress göstərmək</param>
        public static async Task ExecuteParallelAsync(this Form form, 
            Func<Task>[] operations, Action<Exception> onError = null, bool showProgress = true)
        {
            try
            {
                if (showProgress)
                {
                    form.UseWaitCursor = true;
                }

                await Task.WhenAll(operations.Select(op => op()));
            }
            catch (Exception ex)
            {
                if (onError != null)
                {
                    onError(ex);
                }
                else
                {
                    throw;
                }
            }
            finally
            {
                if (showProgress)
                {
                    form.UseWaitCursor = false;
                }
            }
        }
    }
}