using System;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Helper class for showing status messages in the status strip
    /// </summary>
    public static class StatusMesajiGostericisi
    {
        private static ToolStripStatusLabel _statusLabel;
        private static System.Windows.Forms.Timer _clearTimer;

        /// <summary>
        /// Initializes the status message helper with the status strip label
        /// </summary>
        /// <param name="statusLabel">The status label from the status strip</param>
        public static void Initialize(ToolStripStatusLabel statusLabel)
        {
            _statusLabel = statusLabel;
            _clearTimer = new System.Windows.Forms.Timer
            {
                Interval = 3000 // 3 seconds
            };
            _clearTimer.Tick += ClearTimer_Tick;
        }

        /// <summary>
        /// Shows a success message in the status strip
        /// </summary>
        /// <param name="message">Message to display</param>
        public static void UgurluMesajGoster(string message)
        {
            if (_statusLabel != null)
            {
                _statusLabel.Text = message;
                _statusLabel.ForeColor = System.Drawing.Color.Green;
                StartClearTimer();
            }
        }

        /// <summary>
        /// Shows an error message in the status strip
        /// </summary>
        /// <param name="message">Message to display</param>
        public static void XetaMesajiGoster(string message)
        {
            if (_statusLabel != null)
            {
                _statusLabel.Text = message;
                _statusLabel.ForeColor = System.Drawing.Color.Red;
                StartClearTimer();
            }
        }

        /// <summary>
        /// Shows an information message in the status strip
        /// </summary>
        /// <param name="message">Message to display</param>
        public static void MelumatMesajiGoster(string message)
        {
            if (_statusLabel != null)
            {
                _statusLabel.Text = message;
                _statusLabel.ForeColor = System.Drawing.Color.Blue;
                StartClearTimer();
            }
        }

        private static void StartClearTimer()
        {
            _clearTimer?.Stop();
            _clearTimer?.Start();
        }

        private static void ClearTimer_Tick(object sender, EventArgs e)
        {
            _clearTimer.Stop();
            if (_statusLabel != null)
            {
                _statusLabel.Text = "Hazır";
                _statusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }
    }
}