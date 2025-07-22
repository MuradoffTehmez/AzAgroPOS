using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.PL.Forms
{
    public partial class MaterialModernLoginForm : MaterialForm
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AuthService _authService;
        private bool _isAutoLoginAttempted = false;
        private Panel pnlLeft;
        private Panel pnlLoginCard;
        private TextBox txtEmail; // Changed from MaterialTextBox to TextBox
        private TextBox txtPassword; // Changed from MaterialTextBox to TextBox
        private MaterialCheckbox chkRememberMe;
        private MaterialButton btnLogin;
        private MaterialButton btnClose;
        private MaterialButton btnMinimize;
        private MaterialProgressBar progressBar;
        private System.Windows.Forms.Timer _animationTimer;
        private float _animationProgress = 0;

        // Round corners
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public MaterialModernLoginForm(IServiceProvider serviceProvider) 
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authService = _serviceProvider.GetRequiredService<AuthService>(); // Fixed GetService to GetRequiredService

            InitializeMaterialDesign();
            InitializeCustomComponents();
            CreateTitleBarControls();
            CreateLeftPanelContent();
            CreateLoginControls();
            InitializeAnimations();

            this.Load += async (s, e) => await TryAutoLoginAsync();
        }

        public MaterialModernLoginForm() : this(Program.ServiceProvider)
        {
        }

        private void InitializeMaterialDesign()
        {
            var materialSkinManager = MaterialTheme.MaterialSkinManager;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500,
                Primary.Indigo700,
                Primary.Indigo100,
                Accent.Pink200,
                TextShade.WHITE
            );
        }

        private void InitializeCustomComponents()
        {
            this.FormStyle = FormStyles.ActionBar_None;
            this.BackColor = MaterialTheme.Colors.DarkBackground;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "AzAgroPOS Giriş";
        }

        private void CreateTitleBarControls()
        {
            // Close button
            btnClose = new MaterialButton
            {
                Text = "✕",
                Width = 46,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                UseAccentColor = true,
                Location = new Point(this.Width - 46, 0)
            };
            btnClose.Click += (s, e) => Application.Exit();

            // Minimize button
            btnMinimize = new MaterialButton
            {
                Text = "—",
                Width = 46,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(this.Width - 92, 0)
            };
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            this.Controls.AddRange(new Control[] { btnClose, btnMinimize });
        }

        private void CreateLeftPanelContent()
        {
            pnlLeft = new Panel
            {
                Width = this.Width / 2,
                Dock = DockStyle.Left,
                BackColor = MaterialTheme.Colors.DarkBackground
            };

            var lblTitle = new MaterialLabel
            {
                Text = "🌾 AzAgroPOS",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(40, 100)
            };

            var lblSubtitle = new MaterialLabel
            {
                Text = "Kənd Təsərrüfatı İdarəetmə Sistemi",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true,
                Location = new Point(40, lblTitle.Bottom + 10)
            };

            pnlLeft.Paint += PnlLeft_Paint;
            pnlLeft.Controls.AddRange(new Control[] { lblTitle, lblSubtitle });
            this.Controls.Add(pnlLeft);
        }

        private void CreateLoginControls()
        {
            pnlLoginCard = new Panel
            {
                Width = 350,
                Height = 400,
                Location = new Point(pnlLeft.Right + 75, (this.Height - 400) / 2),
                BackColor = MaterialTheme.Colors.DarkCard
            };
            pnlLoginCard.Paint += PnlLoginCard_Paint;

            var lblWelcome = new MaterialLabel
            {
                Text = "Xoş gəlmisiniz!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 30)
            };

            txtEmail = new TextBox
            {
                Location = new Point(30, lblWelcome.Bottom + 40),
                Size = new Size(290, 50),
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };
            ModernTheme.ApplyTextBoxStyle(txtEmail);
            txtEmail.KeyDown += TxtEmail_KeyDown;

            txtPassword = new TextBox
            {
                Location = new Point(30, txtEmail.Bottom + 20),
                Size = new Size(290, 50),
                Font = new Font("Segoe UI", 10),
                UseSystemPasswordChar = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            ModernTheme.ApplyTextBoxStyle(txtPassword);
            txtPassword.KeyDown += TxtPassword_KeyDown;

            chkRememberMe = new MaterialCheckbox
            {
                Text = "Məni xatırla",
                Location = new Point(30, txtPassword.Bottom + 20),
                Font = new Font("Segoe UI", 10)
            };

            btnLogin = MaterialTheme.CreateMaterialButton("Daxil ol", FontAwesome.Sharp.IconChar.SignInAlt,
                MaterialTheme.Colors.Primary, new Point(30, chkRememberMe.Bottom + 30), new Size(290, 45));
            btnLogin.Click += async (s, e) => await BtnLogin_Click(s, e);

            progressBar = new MaterialProgressBar
            {
                Location = new Point(30, btnLogin.Bottom + 20),
                Size = new Size(290, 2),
                Visible = false
            };

            pnlLoginCard.Controls.AddRange(new Control[] 
            { 
                lblWelcome, txtEmail, txtPassword, chkRememberMe, btnLogin, progressBar 
            });

            this.Controls.Add(pnlLoginCard);

            LoadLastUserEmail();
        }

        private void InitializeAnimations()
        {
            _animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 16 // ~60 FPS
            };
            _animationTimer.Tick += AnimationTimer_Tick;
            _animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _animationProgress += 0.02f;
            if (_animationProgress > 1) _animationProgress = 0;
            pnlLeft.Invalidate();
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient background
            using (var brush = new LinearGradientBrush(
                pnlLeft.ClientRectangle,
                MaterialTheme.Colors.Primary,
                MaterialTheme.Colors.PrimaryDark,
                45f))
            {
                e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            }

            // Animated pattern
            using (var pen = new Pen(Color.FromArgb(50, Color.White), 1))
            {
                for (int i = -pnlLeft.Height; i < pnlLeft.Width; i += 30)
                {
                    var y = i + (pnlLeft.Height * _animationProgress);
                    e.Graphics.DrawLine(pen, new Point(-100, (int)y), 
                        new Point(pnlLeft.Width + 100, (int)y + 300));
                }
            }
        }

        private void PnlLoginCard_Paint(object sender, PaintEventArgs e)
        {
            var path = GetRoundedRectPath(pnlLoginCard.ClientRectangle, 10);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw shadow
            using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                var shadowRect = pnlLoginCard.ClientRectangle;
                shadowRect.Offset(3, 3);
                var shadowPath = GetRoundedRectPath(shadowRect, 10);
                e.Graphics.FillPath(shadowBrush, shadowPath);
            }

            // Draw card
            using (var cardBrush = new SolidBrush(pnlLoginCard.BackColor))
            {
                e.Graphics.FillPath(cardBrush, path);
            }

            // Draw border
            using (var borderPen = new Pen(Color.FromArgb(60, 60, 60), 1))
            {
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task TryAutoLoginAsync()
        {
            if (_isAutoLoginAttempted) return;
            _isAutoLoginAttempted = true;

            try
            {
                var token = GetSavedToken();
                if (string.IsNullOrEmpty(token)) return;

                progressBar.Visible = true;
                var (success, user) = await _authService.LoginWithTokenAsync(token);

                if (success && user != null)
                {
                    ShowMainForm(user);
                }
                else
                {
                    ClearSavedToken();
                }
            }
            catch
            {
                ClearSavedToken();
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private async 
        Task
BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (!ValidateInput(email, password))
            {
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                progressBar.Visible = true;

                var token = await _authService.LoginAsync(email, password);
                if (string.IsNullOrEmpty(token))
                {
                    ShowMaterialError("E-poçt və ya şifrə yanlışdır");
                    return;
                }

                var (success, user) = await _authService.LoginWithTokenAsync(token);
                if (success && user != null)
                {
                    if (chkRememberMe.Checked)
                    {
                        SaveTokenToRegistry(token);
                        SaveLastUserEmail(email);
                    }
                    else
                    {
                        ClearSavedToken();
                    }

                    ShowMainForm(user);
                }
                else
                {
                    ShowMaterialError("Giriş zamanı xəta baş verdi");
                }
            }
            catch (Exception ex)
            {
                ShowMaterialError($"Sistem xətası: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowMaterialError("E-poçt daxil edin");
                txtEmail.Focus();
                return false;
            }

            if (!email.Contains("@"))
            {
                ShowMaterialError("Düzgün e-poçt daxil edin");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowMaterialError("Şifrə daxil edin");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void ShowMainForm(Istifadeci user)
        {
            this.Hide();
            var mainForm = new MainForm(user, _serviceProvider);
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private string GenerateSecureToken()
        {
            var random = new byte[32];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(random);
            }
            return Convert.ToBase64String(random);
        }

        private void SaveTokenToRegistry(string token)
        {
            try
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS")
                    .SetValue("RememberMeToken", token);
            }
            catch { }
        }

        private string GetSavedToken()
        {
            try
            {
                return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS")
                    ?.GetValue("RememberMeToken") as string;
            }
            catch
            {
                return null;
            }
        }

        private void ClearSavedToken()
        {
            try
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS")
                    .DeleteValue("RememberMeToken", false);
            }
            catch { }
        }

        private void SaveLastUserEmail(string email)
        {
            try
            {
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS")
                    .SetValue("LastUserEmail", email);
            }
            catch { }
        }

        private void LoadLastUserEmail()
        {
            try
            {
                var email = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS")
                    ?.GetValue("LastUserEmail") as string;
                if (!string.IsNullOrEmpty(email))
                {
                    txtEmail.Text = email;
                    txtPassword.Focus();
                }
            }
            catch { }
        }

        private void ShowMaterialError(string message)
        {
            MessageBox.Show(message, "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _animationTimer?.Stop();
            _animationTimer?.Dispose();
            base.OnFormClosing(e);
        }

        // Allow form to be dragged by clicking anywhere on the form
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 0x1;
            const int HTCAPTION = 0x2;

            if (m.Msg == WM_NCHITTEST)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < 32)
                {
                    m.Result = (IntPtr)HTCAPTION;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}