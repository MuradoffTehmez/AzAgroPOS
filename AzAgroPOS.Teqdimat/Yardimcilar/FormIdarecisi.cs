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

        /// <summary>
        /// Opens a form and shows it. This is a convenience method that combines FormuGetir and Show.
        /// diqqət: Əgər form artıq açıqdırsa, fokuslayır; yoxdursa, yeni açır.
        /// qeyd: Modal olmayan formlarda istifadə üçün.
        /// </summary>
        /// <typeparam name="T">Type of form</typeparam>
        public static void AcVeGoster<T>() where T : Form, new()
        {
            var form = FormuGetir<T>();
            form.Show();
        }

        /// <summary>
        /// Opens a form and shows it as a dialog. This is a convenience method that combines FormuGetir and ShowDialog.
        /// diqqət: Bu metod modal (dialog) formlarda istifadə üçündür.
        /// qeyd: Form bağlanana qədər əsas pəncərə bloklanır.
        /// </summary>
        /// <typeparam name="T">Type of form</typeparam>
        /// <returns>Dialog result</returns>
        public static DialogResult AcVeDialogGoster<T>() where T : Form, new()
        {
            var form = FormuGetir<T>();
            return form.ShowDialog();
        }

        /// <summary>
        /// Closes all open forms tracked by the manager
        /// diqqət: Bütün açıq formları bağlayır.
        /// qeyd: Tətbiqin bağlanması zamanı istifadə olunur.
        /// </summary>
        public static void ButunFormlaBagla()
        {
            var formlar = _aciqFormlar.Values.ToList();
            foreach (var form in formlar)
            {
                if (!form.IsDisposed)
                {
                    form.Close();
                }
            }
            _aciqFormlar.Clear();
        }

        /// <summary>
        /// Gets the count of currently open forms
        /// </summary>
        /// <returns>Number of open forms</returns>
        public static int AciqFormSayini()
        {
            // Remove disposed forms from tracking
            var disposedKeys = _aciqFormlar.Where(kvp => kvp.Value.IsDisposed).Select(kvp => kvp.Key).ToList();
            foreach (var key in disposedKeys)
            {
                _aciqFormlar.Remove(key);
            }

            return _aciqFormlar.Count;
        }
    }
}