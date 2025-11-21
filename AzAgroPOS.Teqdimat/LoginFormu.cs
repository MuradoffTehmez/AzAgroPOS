// Fayl: AzAgroPOS.Teqdimat/LoginFormu.cs
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AzAgroPOS.Teqdimat
{
    public partial class LoginFormu : BazaForm, ILoginView
    {
        private LoginPresenter _presenter = null!;
        private bool _parolGorunur = false;
        private bool _girişEdilir = false;

        // CAPS LOCK detection
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);
        private const int VK_CAPITAL = 0x14;

        public bool UgurluDaxilOlundu { get; set; } = false;
        public string IstifadeciAdi => txtIstifadeciAdi.Text;
        public string Parol => txtParol.Text;
        public bool MeniXatirla => chkMeniXatirla.Checked;

        public event EventHandler? DaxilOl_Istek;

        public LoginFormu()
        {
            InitializeComponent();

            // Versiya nömrəsini göstər
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"v{version?.Major}.{version?.Minor}.{version?.Build}";

            // Hadisələri qoş
            txtParol.KeyUp += TxtParol_KeyUp;
            txtParol.Enter += TxtParol_Enter;
            btnParolGoster.Click += BtnParolGoster_Click;
            this.Load += LoginFormu_Load;
            this.KeyPreview = true;
            this.KeyUp += LoginFormu_KeyUp;

            // Logo üçün placeholder rəng
            picLogo.Paint += PicLogo_Paint;
        }

        private void LoginFormu_Load(object? sender, EventArgs e)
        {
            // CAPS LOCK vəziyyətini yoxla
            CapsLockYoxla();

            // "Məni xatırla" seçimi saxlanılıbsa yüklə
            YaddaSaxlananMelumatlarıYukle();

            // Login card-ı mərkəzləşdir
            CenterLoginCard();
        }

        private void CenterLoginCard()
        {
            if (pnlLoginCard != null && pnlMain != null)
            {
                int x = (pnlMain.ClientSize.Width - pnlLoginCard.Width) / 2;
                int y = (pnlMain.ClientSize.Height - pnlLoginCard.Height) / 2 - 20;
                pnlLoginCard.Location = new Point(x, Math.Max(20, y));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLoginCard();
        }

        private void PicLogo_Paint(object? sender, PaintEventArgs e)
        {
            // Logo olmadıqda "AZ" yazısı göstər
            if (picLogo.Image == null)
            {
                using var font = new Font("Segoe UI", 24F, FontStyle.Bold);
                using var brush = new SolidBrush(Color.White);
                var text = "AZ";
                var size = e.Graphics.MeasureString(text, font);
                var x = (picLogo.Width - size.Width) / 2;
                var y = (picLogo.Height - size.Height) / 2;
                e.Graphics.DrawString(text, font, brush, x, y);
            }
        }

        public void InitializePresenter(LoginPresenter presenter)
        {
            _presenter = presenter;
        }

        private void LoginFormu_KeyUp(object? sender, KeyEventArgs e)
        {
            CapsLockYoxla();
        }

        private void TxtParol_KeyUp(object? sender, KeyEventArgs e)
        {
            CapsLockYoxla();
        }

        private void TxtParol_Enter(object? sender, EventArgs e)
        {
            CapsLockYoxla();
        }

        private void CapsLockYoxla()
        {
            bool capsLockAktiv = (GetKeyState(VK_CAPITAL) & 1) == 1;
            lblCapsLock.Visible = capsLockAktiv;
        }

        private void BtnParolGoster_Click(object? sender, EventArgs e)
        {
            _parolGorunur = !_parolGorunur;

            if (_parolGorunur)
            {
                txtParol.PasswordChar = '\0';
                btnParolGoster.Text = "🙈";
            }
            else
            {
                txtParol.PasswordChar = '●';
                btnParolGoster.Text = "👁";
            }
        }

        private void btnDaxilOl_Click(object sender, EventArgs e)
        {
            if (_girişEdilir) return;

            YuklemeGoster();
            DaxilOl_Istek?.Invoke(this, EventArgs.Empty);
        }

        public void YuklemeGoster()
        {
            _girişEdilir = true;
            btnDaxilOl.Visible = false;
            pnlLoading.Visible = true;
            txtIstifadeciAdi.Enabled = false;
            txtParol.Enabled = false;
            chkMeniXatirla.Enabled = false;
        }

        public void YuklemeGizle()
        {
            _girişEdilir = false;
            btnDaxilOl.Visible = true;
            pnlLoading.Visible = false;
            txtIstifadeciAdi.Enabled = true;
            txtParol.Enabled = true;
            chkMeniXatirla.Enabled = true;
        }

        public void MesajGoster(string mesaj)
        {
            YuklemeGizle();
            MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FormuBagla()
        {
            // "Məni xatırla" seçilibsə məlumatları saxla
            if (chkMeniXatirla.Checked)
            {
                MelumatlarıYaddaSaxla();
            }
            else
            {
                YaddaSaxlananMelumatlariSil();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private static readonly string _settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AzAgroPOS", "login_settings.txt");

        private void MelumatlarıYaddaSaxla()
        {
            try
            {
                var dir = Path.GetDirectoryName(_settingsPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(_settingsPath, txtIstifadeciAdi.Text);
            }
            catch
            {
                // Ayarlar saxlanıla bilmirsə səssiz keç
            }
        }

        private void YaddaSaxlananMelumatlarıYukle()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var savedUsername = File.ReadAllText(_settingsPath);
                    if (!string.IsNullOrWhiteSpace(savedUsername))
                    {
                        txtIstifadeciAdi.Text = savedUsername;
                        chkMeniXatirla.Checked = true;
                        txtParol.Focus();
                    }
                }
            }
            catch
            {
                // Ayarlar oxuna bilmirsə səssiz keç
            }
        }

        private void YaddaSaxlananMelumatlariSil()
        {
            try
            {
                if (File.Exists(_settingsPath))
                    File.Delete(_settingsPath);
            }
            catch
            {
                // Səssiz keç
            }
        }

        public void XetaGoster(Control control, string message)
        {
            YuklemeGizle();
            errorProvider1.SetError(control, message);
            errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(control, 2);
        }

        public void XetaniTemizle(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }

        public void ButunXetalariTemizle()
        {
            foreach (Control control in this.Controls)
            {
                ClearErrorsRecursive(control);
            }
        }

        private void ClearErrorsRecursive(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
            foreach (Control child in control.Controls)
            {
                ClearErrorsRecursive(child);
            }
        }
    }
}
