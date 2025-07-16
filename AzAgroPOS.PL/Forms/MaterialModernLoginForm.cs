using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MaterialModernLoginForm : MaterialForm
    {
        private readonly AuthService _authService;
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly IServiceProvider _serviceProvider;
        private bool _isAutoLoginAttempted = false;

        // UI Controls
        private Panel pnlMain;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlLoginCard;
        private MaterialLabel lblWelcome;
        private MaterialLabel lblSubtitle;
        private MaterialTextBox txtEmail;
        private MaterialTextBox txtPassword;
        private MaterialCheckbox chkRememberMe;
        private MaterialButton btnLogin;
        private MaterialButton btnClose;
        private MaterialButton btnMinimize;
        private MaterialLabel lblTitle;
        private MaterialLabel lblVersion;
        private IconPictureBox picLogo;
        private Timer animationTimer;
        private float animationProgress = 0f;

        // Round corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public MaterialModernLoginForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authService = serviceProvider.GetRequiredService<AuthService>();
            _istifadeciRepository = serviceProvider.GetRequiredService<IstifadeciRepository>();
            
            InitializeMaterialDesign();
            InitializeCustomComponents();
            InitializeAnimations();
            
            this.Load += async (s, e) => await TryAutoLoginAsync();
        }

        public MaterialModernLoginForm() : this(Program.ServiceProvider)
        {
        }

        private void InitializeMaterialDesign()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE);
        }

        private void InitializeCustomComponents()
        {
            // Form settings
            this.Text = "AzAgroPOS - Modern Giriş";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(45, 45, 48);
            
            // Apply rounded corners after form is shown to prevent shaking
            this.Shown += (s, e) => {
                try
                {
                    this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                }
                catch (Exception ex)
                {
                    // Fallback if rounded corners fail
                    System.Diagnostics.Debug.WriteLine($"Rounded corners failed: {ex.Message}");
                }
            };

            // Main container
            pnlMain = new Panel
            {
                Name = "pnlMain",
                Location = new Point(0, 0),
                Size = new Size(1000, 650),
                BackColor = Color.FromArgb(45, 45, 48)
            };

            // Left panel with branding
            pnlLeft = new Panel
            {
                Name = "pnlLeft",
                Location = new Point(0, 0),
                Size = new Size(500, 650),
                BackColor = Color.FromArgb(63, 81, 181) // Material Indigo
            };
            pnlLeft.Paint += PnlLeft_Paint;

            // Right panel with login form
            pnlRight = new Panel
            {
                Name = "pnlRight",
                Location = new Point(500, 0),
                Size = new Size(500, 650),
                BackColor = Color.FromArgb(55, 55, 58)
            };

            // Login card with rounded corners
            pnlLoginCard = new Panel
            {
                Name = "pnlLoginCard",
                Location = new Point(50, 75),
                Size = new Size(400, 500),
                BackColor = Color.FromArgb(69, 69, 72)
            };
            pnlLoginCard.Paint += PnlLoginCard_Paint;

            // Title and window controls
            CreateTitleBarControls();
            CreateLeftPanelContent();
            CreateLoginControls();

            // Add controls to login card
            pnlLoginCard.Controls.AddRange(new Control[]
            {
                lblWelcome, lblSubtitle, txtEmail, txtPassword, chkRememberMe, btnLogin
            });

            // Add controls to right panel
            pnlRight.Controls.Add(pnlLoginCard);

            // Add panels to main
            pnlMain.Controls.AddRange(new Control[] { pnlLeft, pnlRight });

            // Add main panel to form
            this.Controls.Add(pnlMain);

            // Load last user email
            LoadLastUserEmail();
        }

        private void CreateTitleBarControls()
        {
            // Close button
            btnClose = new MaterialButton
            {
                Name = "btnClose",
                Size = new Size(40, 30),
                Location = new Point(950, 10),
                Text = "✕",
                BackColor = Color.FromArgb(232, 17, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnClose.Click += (s, e) => this.Close();
            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(255, 50, 50);
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.FromArgb(232, 17, 35);

            // Minimize button
            btnMinimize = new MaterialButton
            {
                Name = "btnMinimize",
                Size = new Size(40, 30),
                Location = new Point(905, 10),
                Text = "−",
                BackColor = Color.FromArgb(80, 80, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Color.FromArgb(100, 100, 100);
            btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.FromArgb(80, 80, 80);

            pnlMain.Controls.AddRange(new Control[] { btnClose, btnMinimize });
        }

        private void CreateLeftPanelContent()
        {
            // Logo
            picLogo = new IconPictureBox
            {
                Name = "picLogo",
                Size = new Size(80, 80),
                Location = new Point(50, 80),
                IconChar = IconChar.Seedling,
                IconColor = Color.White,
                IconSize = 80,
                BackColor = Color.Transparent
            };

            // Title
            lblTitle = new MaterialLabel
            {
                Name = "lblTitle",
                Text = "AzAgroPOS",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(50, 180),
                BackColor = Color.Transparent
            };

            // Version
            lblVersion = new MaterialLabel
            {
                Name = "lblVersion",
                Text = "Versiya 2.0 - Müasir Kənd Təsərrüfatı İdarəetmə Sistemi",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 255, 255, 255),
                AutoSize = false,
                Size = new Size(400, 50),
                Location = new Point(50, 240),
                BackColor = Color.Transparent
            };

            // Features with icons
            var features = new[]
            {
                new { Icon = IconChar.ShoppingCart, Text = "Satış və anbar idarəetməsi" },
                new { Icon = IconChar.Users, Text = "Müştəri və tədarükçü bazası" },
                new { Icon = IconChar.ChartBar, Text = "Maliyyə hesabatları" },
                new { Icon = IconChar.Tools, Text = "Təmir xidməti modulu" },
                new { Icon = IconChar.Shield, Text = "Təhlükəsiz çoxistifadəçili sistem" }
            };

            int yPos = 320;
            foreach (var feature in features)
            {
                var iconPic = new IconPictureBox
                {
                    Name = $"iconFeature{yPos}",
                    Size = new Size(18, 18),
                    Location = new Point(50, yPos),
                    IconChar = feature.Icon,
                    IconColor = Color.FromArgb(129, 199, 132),
                    IconSize = 18,
                    BackColor = Color.Transparent
                };

                var lblFeature = new MaterialLabel
                {
                    Name = $"lblFeature{yPos}",
                    Text = feature.Text,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.FromArgb(230, 255, 255, 255),
                    AutoSize = true,
                    Location = new Point(75, yPos),
                    BackColor = Color.Transparent
                };

                pnlLeft.Controls.AddRange(new Control[] { iconPic, lblFeature });
                yPos += 35;
            }

            pnlLeft.Controls.AddRange(new Control[] { picLogo, lblTitle, lblVersion });
        }

        private void CreateLoginControls()
        {
            // Welcome label
            lblWelcome = new MaterialLabel
            {
                Name = "lblWelcome",
                Text = "Xoş gəldiniz!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(40, 40),
                BackColor = Color.Transparent
            };

            // Subtitle
            lblSubtitle = new MaterialLabel
            {
                Name = "lblSubtitle",
                Text = "Hesabınıza daxil olmaq üçün məlumatlarınızı daxil edin",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = false,
                Size = new Size(320, 30),
                Location = new Point(40, 85),
                BackColor = Color.Transparent
            };

            // Email textbox
            txtEmail = new MaterialTextBox
            {
                Name = "txtEmail",
                Size = new Size(320, 45),
                Location = new Point(40, 140),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Hint = "   Email adresi",
                BackColor = Color.FromArgb(69, 69, 72),
                ForeColor = Color.White
            };
            txtEmail.KeyDown += TxtEmail_KeyDown;
            
            // Add email icon
            var emailIcon = new IconPictureBox
            {
                Name = "emailIcon",
                Size = new Size(18, 18),
                Location = new Point(50, (txtEmail.Location.Y + (txtEmail.Height - 18) / 2)),
                IconChar = IconChar.Envelope,
                IconColor = Color.FromArgb(150, 150, 150),
                IconSize = 18,
                BackColor = Color.Transparent
            };
            pnlLoginCard.Controls.Add(emailIcon);

            // Password textbox
            txtPassword = new MaterialTextBox
            {
                Name = "txtPassword",
                Size = new Size(320, 45),
                Location = new Point(40, 210),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Hint = "   Şifrə",
                Password = true,
                BackColor = Color.FromArgb(69, 69, 72),
                ForeColor = Color.White
            };
            txtPassword.KeyDown += TxtPassword_KeyDown;
            
            // Add password icon
            var passwordIcon = new IconPictureBox
            {
                Name = "passwordIcon",
                Size = new Size(18, 18),
                Location = new Point(50, (txtPassword.Location.Y + (txtPassword.Height - 18) / 2)),
                IconChar = IconChar.Lock,
                IconColor = Color.FromArgb(150, 150, 150),
                IconSize = 18,
                BackColor = Color.Transparent
            };
            pnlLoginCard.Controls.Add(passwordIcon);

            // Remember me checkbox
            chkRememberMe = new MaterialCheckbox
            {
                Name = "chkRememberMe",
                Text = "Məni xatırla",
                Location = new Point(40, 280),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true
            };

            // Login button
            btnLogin = new MaterialButton
            {
                Name = "btnLogin",
                Text = "  Daxil Ol",
                Size = new Size(320, 45),
                Location = new Point(40, 330),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(83, 101, 201);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(63, 81, 181);

            // Add login icon to button
            var loginIcon = new IconPictureBox
            {
                Name = "loginIcon",
                Size = new Size(18, 18),
                Location = new Point(12, (btnLogin.Height - 18) / 2),
                IconChar = IconChar.SignInAlt,
                IconColor = Color.White,
                IconSize = 18,
                BackColor = Color.Transparent
            };
            btnLogin.Controls.Add(loginIcon);
        }

        private void InitializeAnimations()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 100; // Slower animation to prevent shaking
            animationTimer.Tick += AnimationTimer_Tick;
            
            // Start animation after form is fully loaded
            this.Shown += (s, e) => animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationProgress += 0.01f; // Slower progression
            if (animationProgress > 1f) animationProgress = 0f;
            
            // Only invalidate if form is visible and stable
            if (this.Visible && this.WindowState != FormWindowState.Minimized)
            {
                pnlLeft?.Invalidate();
            }
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            // Create animated gradient background
            var rect = pnlLeft.ClientRectangle;
            var color1 = Color.FromArgb(63, 81, 181);
            var color2 = Color.FromArgb(48, 63, 159);
            var color3 = Color.FromArgb(26, 35, 126);

            using (var brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Add animated circles
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Floating circles animation
            for (int i = 0; i < 5; i++)
            {
                var alpha = (int)(50 + 30 * Math.Sin(animationProgress * Math.PI * 2 + i));
                var radius = 30 + i * 10;
                var x = 100 + i * 80 + (int)(20 * Math.Sin(animationProgress * Math.PI + i));
                var y = 400 + i * 30 + (int)(15 * Math.Cos(animationProgress * Math.PI + i));

                using (var brush = new SolidBrush(Color.FromArgb(alpha, 255, 255, 255)))
                {
                    graphics.FillEllipse(brush, x, y, radius, radius);
                }
            }

            // Decorative line
            using (var pen = new Pen(Color.FromArgb(100, 255, 255, 255), 3))
            {
                graphics.DrawLine(pen, 60, 300, 300, 300);
            }
        }

        private void PnlLoginCard_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw rounded rectangle
            var rect = new Rectangle(0, 0, pnlLoginCard.Width, pnlLoginCard.Height);
            using (var path = GetRoundedRectPath(rect, 15))
            {
                // Card shadow
                var shadowRect = new Rectangle(5, 5, pnlLoginCard.Width, pnlLoginCard.Height);
                using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                using (var shadowPath = GetRoundedRectPath(shadowRect, 15))
                {
                    graphics.FillPath(shadowBrush, shadowPath);
                }

                // Card background
                using (var cardBrush = new SolidBrush(Color.FromArgb(69, 69, 72)))
                {
                    graphics.FillPath(cardBrush, path);
                }

                // Card border
                using (var borderPen = new Pen(Color.FromArgb(90, 90, 90), 1))
                {
                    graphics.DrawPath(borderPen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private async Task TryAutoLoginAsync()
        {
            if (_isAutoLoginAttempted) return;
            _isAutoLoginAttempted = true;

            var savedToken = GetSavedToken();
            if (!string.IsNullOrEmpty(savedToken))
            {
                this.Enabled = false;
                lblSubtitle.Text = "Avtomatik giriş yoxlanılır...";

                var (success, user) = await _authService.LoginWithTokenAsync(savedToken);
                if (success)
                {
                    ShowMainForm(user);
                }
                else
                {
                    ClearSavedToken();
                    LoadLastUserEmail();
                }

                this.Enabled = true;
                lblSubtitle.Text = "Hesabınıza daxil olmaq üçün məlumatlarınızı daxil edin";
            }
            else
            {
                LoadLastUserEmail();
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (!ValidateInput(email, password)) return;

                btnLogin.Enabled = false;
                btnLogin.Text = "Yoxlanılır...";

                string loginResult = await _authService.LoginAsync(email, password);

                if (loginResult.Contains("Uğurlu"))
                {
                    var user = await _istifadeciRepository.GetByEmailAsync(email);
                    if (user != null)
                    {
                        if (chkRememberMe.Checked)
                        {
                            await HandleRememberMe(user);
                        }
                        else
                        {
                            await ClearRememberMe(user);
                        }

                        SaveLastUserEmail(email);
                        ShowMainForm(user);
                    }
                }
                else
                {
                    ShowMaterialError(loginResult);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowMaterialError($"Xəta baş verdi: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "  Daxil Ol";
            }
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowMaterialError("Email mütləqdir!");
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(email))
            {
                ShowMaterialError("Düzgün email formatı daxil edin!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowMaterialError("Şifrə mütləqdir!");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void ShowMainForm(Istifadeci user)
        {
            SessionManager.SetCurrentUser(user);
            
            this.Hide();
            var mainForm = new MainForm(user, _serviceProvider);
            mainForm.ShowDialog();
            
            SessionManager.ClearSession();
            this.Close();
        }

        private async Task HandleRememberMe(Istifadeci user)
        {
            var token = GenerateSecureToken();
            user.RememberMeToken = token;
            user.RememberMeTokenExpiry = DateTime.Now.AddDays(30);
            await _istifadeciRepository.UpdateAsync(user);
            SaveTokenToRegistry(token);
        }

        private async Task ClearRememberMe(Istifadeci user)
        {
            user.RememberMeToken = null;
            user.RememberMeTokenExpiry = null;
            await _istifadeciRepository.UpdateAsync(user);
            ClearSavedToken();
        }

        private string GenerateSecureToken()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] tokenBytes = new byte[32];
                rng.GetBytes(tokenBytes);
                return Convert.ToBase64String(tokenBytes);
            }
        }

        private void SaveTokenToRegistry(string token)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    key?.SetValue("RememberMeToken", token);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Token qeyd edilərkən xəta: {ex.Message}");
            }
        }

        private string GetSavedToken()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    return key?.GetValue("RememberMeToken")?.ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Token oxunarkən xəta: {ex.Message}");
                return null;
            }
        }

        private void ClearSavedToken()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS", true))
                {
                    key?.DeleteValue("RememberMeToken", false);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Token silinərkən xəta: {ex.Message}");
            }
        }

        private void SaveLastUserEmail(string email)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    key?.SetValue("LastUserEmail", email);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email qeyd edilərkən xəta: {ex.Message}");
            }
        }

        private void LoadLastUserEmail()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AzAgroPOS"))
                {
                    var lastEmail = key?.GetValue("LastUserEmail")?.ToString();
                    if (!string.IsNullOrEmpty(lastEmail))
                    {
                        txtEmail.Text = lastEmail;
                        txtPassword.Focus();
                    }
                    else
                    {
                        txtEmail.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Email oxunarkən xəta: {ex.Message}");
                txtEmail.Focus();
            }
        }

        private void ShowMaterialError(string message)
        {
            // Create modern material error dialog
            var errorDialog = new MaterialForm
            {
                Text = "Xəta",
                Size = new Size(450, 220),
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(55, 55, 58)
            };

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(errorDialog);

            var iconPic = new IconPictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(30, 50),
                IconChar = IconChar.ExclamationTriangle,
                IconColor = Color.FromArgb(255, 152, 0),
                IconSize = 40,
                BackColor = Color.Transparent
            };

            var messageLabel = new MaterialLabel
            {
                Text = message,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(350, 60),
                Location = new Point(80, 60),
                BackColor = Color.Transparent
            };

            var okButton = new MaterialButton
            {
                Text = "Tamam",
                Size = new Size(100, 40),
                Location = new Point(175, 140),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };

            errorDialog.Controls.AddRange(new Control[] { iconPic, messageLabel, okButton });
            errorDialog.AcceptButton = okButton;
            errorDialog.ShowDialog(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            animationTimer?.Stop();
            animationTimer?.Dispose();
            base.OnFormClosing(e);
        }

        // Allow form to be dragged by clicking anywhere on the form
        protected override void WndProc(ref Message m)
        {
            try
            {
                const int WM_NCHITTEST = 0x84;
                const int HTCLIENT = 0x1;
                const int HTCAPTION = 0x2;

                if (m.Msg == WM_NCHITTEST)
                {
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"WndProc error: {ex.Message}");
                base.WndProc(ref m);
            }
        }
    }
}