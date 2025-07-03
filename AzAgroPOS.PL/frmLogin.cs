// Fayl: AzAgroPOS.PL/frmLogin.cs

using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmLogin : Form
    {
        private readonly IstifadeciBLL _istifadeciBll;

        /// <summary>
        /// Uğurla daxil olan istifadəçini yadda saxlamaq üçün public xüsusiyyət.
        /// Program.cs bu xüsusiyyətdən istifadə edəcək.
        /// </summary>
        public Istifadeci LoggedInUser { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
            _istifadeciBll = new IstifadeciBLL();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("İstifadəçi adı və parol boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // BLL vasitəsilə istifadəçini yoxlayırıq
            Istifadeci user = _istifadeciBll.Login(username, password);

            if (user != null)
            {
                // İstifadəçi tapılıbsa, onu public xüsusiyyətə mənimsədirik
                this.LoggedInUser = user;
                // Formanın nəticəsini OK olaraq təyin edirik ki, Program.cs bunu bilsin
                this.DialogResult = DialogResult.OK;
                // Və login formasını bağlayırıq
                this.Close();
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya parol yanlışdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Formanın nəticəsini Cancel olaraq təyin edirik
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}