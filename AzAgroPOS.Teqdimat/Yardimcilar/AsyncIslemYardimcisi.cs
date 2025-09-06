using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Helper class for executing async operations with loading indicators
    /// </summary>
    public static class AsyncIslemYardimcisi
    {
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
    }
}