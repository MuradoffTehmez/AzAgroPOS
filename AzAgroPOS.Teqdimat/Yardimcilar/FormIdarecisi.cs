using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Form instance management helper to prevent multiple instances of the same form
    /// </summary>
    public static class FormIdarecisi
    {
        private static readonly Dictionary<Type, Form> _aciqFormlar = new Dictionary<Type, Form>();

        /// <summary>
        /// Gets an existing instance of a form or creates a new one if it doesn't exist
        /// </summary>
        /// <typeparam name="T">Type of form</typeparam>
        /// <returns>Form instance</returns>
        public static T FormuGetir<T>() where T : Form, new()
        {
            var formTipi = typeof(T);

            if (_aciqFormlar.ContainsKey(formTipi))
            {
                var movcudForm = _aciqFormlar[formTipi];
                if (!movcudForm.IsDisposed)
                {
                    // Bring to front if already open
                    if (movcudForm.WindowState == FormWindowState.Minimized)
                        movcudForm.WindowState = FormWindowState.Normal;
                    
                    movcudForm.BringToFront();
                    movcudForm.Activate();
                    return (T)movcudForm;
                }
                else
                {
                    // Remove disposed form from tracking
                    _aciqFormlar.Remove(formTipi);
                }
            }

            // Create new instance
            var yeniForm = new T();
            _aciqFormlar[formTipi] = yeniForm;
            
            // Track when form is closed to remove from tracking
            yeniForm.FormClosed += (s, e) => 
            {
                if (_aciqFormlar.ContainsKey(formTipi))
                    _aciqFormlar.Remove(formTipi);
            };

            return yeniForm;
        }

        /// <summary>
        /// Checks if a form of the specified type is already open
        /// </summary>
        /// <typeparam name="T">Type of form</typeparam>
        /// <returns>True if form is open, false otherwise</returns>
        public static bool FormAcikmi<T>() where T : Form
        {
            var formTipi = typeof(T);
            return _aciqFormlar.ContainsKey(formTipi) && !_aciqFormlar[formTipi].IsDisposed;
        }

        /// <summary>
        /// Closes and removes a form from tracking
        /// </summary>
        /// <typeparam name="T">Type of form</typeparam>
        public static void FormuBagla<T>() where T : Form
        {
            var formTipi = typeof(T);
            if (_aciqFormlar.ContainsKey(formTipi))
            {
                var form = _aciqFormlar[formTipi];
                if (!form.IsDisposed)
                {
                    form.Close();
                }
                _aciqFormlar.Remove(formTipi);
            }
        }
    }
}