using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Helper class for managing ErrorProvider controls in forms
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
    }
}