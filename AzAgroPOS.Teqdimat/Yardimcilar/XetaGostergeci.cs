namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    using AzAgroPOS.Mentiq.Istisnalar;

    /// <summary>
    /// Helper class for managing ErrorProvider controls in forms and displaying error messages
    /// </summary>
    public static class XetaGostergeci
    {
        /// <summary>
        /// Shows an error on a control
        /// </summary>
        /// <param name="errorProvider">ErrorProvider instance</param>
        /// <param name="control">Control to show error on</param>
        /// <param name="message">Error message</param>
        public static void XetaGoster(this ErrorProvider errorProvider, Control control, string message)
        {
            errorProvider.SetError(control, message);
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(control, 2);
        }

        /// <summary>
        /// Clears error from a control
        /// </summary>
        /// <param name="errorProvider">ErrorProvider instance</param>
        /// <param name="control">Control to clear error from</param>
        public static void XetaniTemizle(this ErrorProvider errorProvider, Control control)
        {
            errorProvider.SetError(control, string.Empty);
        }

        /// <summary>
        /// Clears all errors from all controls
        /// </summary>
        /// <param name="errorProvider">ErrorProvider instance</param>
        /// <param name="container">Container control that contains all controls to clear</param>
        public static void ButunXetalariTemizle(this ErrorProvider errorProvider, Control container)
        {
            foreach (Control control in GetAllControls(container))
            {
                errorProvider.SetError(control, string.Empty);
            }
        }

        /// <summary>
        /// Gets all controls in a container recursively
        /// </summary>
        /// <param name="container">Container control</param>
        /// <returns>List of all controls</returns>
        private static IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }

        /// <summary>
        /// Displays a BusinessException to the user with appropriate icon and message
        /// diqqət: BusinessException-un növünə görə uyğun ikona və başlıq seçilir
        /// qeyd: İstifadəçiyə anlayışlı və oxunaqlı mesaj göstərilir
        /// </summary>
        /// <param name="exception">Business exception</param>
        /// <param name="basliq">İxtiyari başlıq (təyin olunmasa, avtomatik təyin olunur)</param>
        public static void BusinessXetaGoster(BusinessException exception, string? basliq = null)
        {
            MessageBoxIcon icon;
            string defaultBasliq;

            switch (exception.XetaTipi)
            {
                case XetaTipi.Melumat:
                    icon = MessageBoxIcon.Information;
                    defaultBasliq = "Məlumat";
                    break;
                case XetaTipi.Xeberdarliq:
                    icon = MessageBoxIcon.Warning;
                    defaultBasliq = "Xəbərdarlıq";
                    break;
                case XetaTipi.Xeta:
                default:
                    icon = MessageBoxIcon.Error;
                    defaultBasliq = "Xəta";
                    break;
            }

            string mesaj = exception.Message;

            // Modul məlumatını əlavə et
            if (!string.IsNullOrWhiteSpace(exception.Modul))
            {
                mesaj = $"[{exception.Modul}]\n{mesaj}";
            }

            // Tövsiyyə məlumatını əlavə et
            if (!string.IsNullOrWhiteSpace(exception.Tovsiyye))
            {
                mesaj = $"{mesaj}\n\nTövsiyyə: {exception.Tovsiyye}";
            }

            MessageBox.Show(mesaj, basliq ?? defaultBasliq, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Displays any exception to the user with appropriate handling
        /// diqqət: BusinessException ayrıca, digər xətalar texniki olaraq emal edilir
        /// qeyd: Texniki xətalar log faylına yazılır, istifadəçiyə sadələşdirilmiş mesaj göstərilir
        /// </summary>
        /// <param name="exception">Any exception</param>
        /// <param name="modul">Xətanın baş verdiyi modul (ixtiyari)</param>
        public static void UmumiXetaGoster(Exception exception, string? modul = null)
        {
            if (exception is BusinessException businessException)
            {
                // Business exception - istifadəçiyə birbaşa göstər
                BusinessXetaGoster(businessException);
            }
            else
            {
                // Texniki exception - log et və sadələşdirilmiş mesaj göstər
                AzAgroPOS.Mentiq.Yardimcilar.Logger.XetaYaz(exception, modul ?? "Naməlum Modul");

                string mesaj = "Gözlənilməz xəta baş verdi. Əməliyyat tamamlana bilmədi.";

                if (!string.IsNullOrWhiteSpace(modul))
                {
                    mesaj = $"[{modul}] {mesaj}";
                }

                // Texniki detalları göstərmək üçün (yalnız development mühitində)
                #if DEBUG
                mesaj += $"\n\nTexniki detallar:\n{exception.Message}";
                #endif

                MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Displays a success message to the user
        /// diqqət: Uğurlu əməliyyatlar üçün istifadə olunur
        /// qeyd: Yaşıl tick ikona ilə göstərilir
        /// </summary>
        /// <param name="mesaj">Uğurlu əməliyyat mesajı</param>
        /// <param name="basliq">Başlıq (standart: "Uğurlu")</param>
        public static void UgurluMesajGoster(string mesaj, string basliq = "Uğurlu")
        {
            MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays a confirmation dialog and returns the user's choice
        /// diqqət: İstifadəçidən təsdiq tələb edən əməliyyatlar üçün istifadə olunur
        /// qeyd: Bəli/Xeyr düymələri ilə
        /// </summary>
        /// <param name="mesaj">Təsdiq mesajı</param>
        /// <param name="basliq">Başlıq (standart: "Təsdiq")</param>
        /// <returns>İstifadəçi "Bəli" seçibsə true, "Xeyr" seçibsə false</returns>
        public static bool TesdiqMesajiGoster(string mesaj, string basliq = "Təsdiq")
        {
            var result = MessageBox.Show(mesaj, basliq, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}