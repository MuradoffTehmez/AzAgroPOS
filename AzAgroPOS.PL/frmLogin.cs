using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// İstifadəçi girişi üçün login forması. İstifadəçilərin sistemə daxil olmasını təmin edir.
    /// </summary>
    public partial class frmLogin : AzAgroPOS.PL.Themes.BaseForm
    {
        private readonly IstifadeciBLL _istifadeciBll;

        /// <summary>
        /// Uğurla daxil olan istifadəçini saxlayan xüsusiyyət.
        /// Program.cs bu xüsusiyyətdən istifadə edərək əsas formaya ötürür.
        /// </summary>
        public Istifadeci LoggedInUser { get; private set; }

        /// <summary>
        /// frmLogin konstruktoru. İstifadəçi BLL sinifini işə salır.
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Tag = "Success";
            btnCancel.Tag = "Secondary"; 
            _istifadeciBll = new IstifadeciBLL();
        }

        #region Event Handlers

        /// <summary>
        /// Daxil ol düyməsinə klik edildikdə işə düşən metod.
        /// İstifadəçi məlumatlarını yoxlayır və sistemə girişi təmin edir.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                // Validasiya
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("İstifadəçi adı və parol boş ola bilməz.",
                                  "Xəta",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                // İstifadəçi yoxlanışı
                Istifadeci user = _istifadeciBll.Login(username, password);

                if (user != null)
                {
                    // Uğurlu giriş
                    this.LoggedInUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("İstifadəçi adı və ya parol yanlışdır.",
                                  "Xəta",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş zamanı xəta baş verdi: {ex.Message}",
                              "Xəta",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ləğv et düyməsinə klik edildikdə işə düşən metod.
        /// Proqramı bağlamaq üçün istifadə olunur.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Enter düyməsinə basıldıqda girişi aktivləşdirir.
        /// </summary>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        #endregion
    }
}