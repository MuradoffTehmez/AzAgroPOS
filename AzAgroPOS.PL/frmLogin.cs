// Fayl: AzAgroPOS.PL/frmLogin.cs

using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmLogin : Form
    {
        // BLL qatımızdan bir obyekt yaradırıq. Bütün məntiq buradan idarə olunacaq.
        private readonly IstifadeciBLL _istifadeciBll;

        public frmLogin()
        {
            InitializeComponent();
            _istifadeciBll = new IstifadeciBLL();
            // --- MÜVƏQQƏTİ KOD BAŞLANĞICI ---
            // Bu kodu yalnız bir dəfə istifadə edib sonra siləcəyik.
            var (hash, salt) = AzAgroPOS.BLL.Helpers.PasswordHelper.HashPassword("Admin123");
            System.Diagnostics.Debug.WriteLine("--- YENİ DƏYƏRLƏR ---");
            System.Diagnostics.Debug.WriteLine("Parol Hash: " + hash);
            System.Diagnostics.Debug.WriteLine("Parol Salt: " + salt);
            System.Diagnostics.Debug.WriteLine("----------------------");
            // --- MÜVƏQQƏTİ KOD SONU ---
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. TextBox-lardan dəyərləri götürürük
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // 2. Sadə yoxlama (boş olmasın)
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("İstifadəçi adı və parol boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. BLL-dəki Login metodunu çağırırıq
            Istifadeci loggedInUser = _istifadeciBll.Login(username, password);

            // 4. Nəticəni yoxlayırıq
            if (loggedInUser != null)
            {
                // Giriş uğurludur!
                MessageBox.Show($"Xoş gəldiniz, {loggedInUser.Ad} {loggedInUser.Soyad}!", "Uğurlu Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gələcəkdə burada əsas ana pəncərəni (dashboard) açacağıq.
                // Hələlik sadəcə login pəncərəsini bağlayaq.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Giriş uğursuzdur!
                MessageBox.Show("İstifadəçi adı və ya parol yanlışdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Ləğv et düyməsinə basdıqda proqramdan çıxırıq
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}