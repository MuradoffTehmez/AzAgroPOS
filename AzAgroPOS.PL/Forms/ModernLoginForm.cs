using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class ModernLoginForm : BaseForm
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
        private Label lblWelcome;
        private Label lblSubtitle;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkRememberMe;
        private Button btnLogin;
        private Label lblTitle;
        private Label lblVersion;
        private PictureBox picLogo;

        public ModernLoginForm(IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authService = serviceProvider.GetRequiredService<AuthService>();
            _istifadeciRepository = serviceProvider.GetRequiredService<IstifadeciRepository>();
            this.Load += async (s, e) => await TryAutoLoginAsync();
        }

        public ModernLoginForm() : this(Program.ServiceProvider)
        {
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form settings
            this.Text = "AzAgroPOS - Giriş";
            this.Size = new Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ModernTheme.Colors.Background;

            // Main panel
            pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            // Left panel with branding
            pnlLeft = new Panel
            {
                Width = 600,
                Dock = DockStyle.Left,
                BackColor = ModernTheme.Colors.Primary
            };
            pnlLeft.Paint += PnlLeft_Paint;

            // Right panel with login form
            pnlRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.Colors.Surface,
                Padding = new Padding(60, 80, 60, 80)
            };

            // Login card
            pnlLoginCard = new Panel
            {
                Size = new Size(400, 500),
                BackColor = Color.White,
                Anchor = AnchorStyles.None
            };
            pnlLoginCard.Location = new Point(
                (pnlRight.Width - pnlLoginCard.Width) / 2,
                (pnlRight.Height - pnlLoginCard.Height) / 2
            );
            pnlLoginCard.Paint += PnlLoginCard_Paint;

            // Welcome label
            lblWelcome = new Label
            {
                Text = "Xoş gəldiniz!",
                Font = ModernTheme.Fonts.Title,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(40, 40)
            };

            // Subtitle
            lblSubtitle = new Label
            {
                Text = "Hesabınıza daxil olmaq üçün məlumatlarınızı daxil edin",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = false,
                Size = new Size(320, 40),
                Location = new Point(40, 90),
                TextAlign = ContentAlignment.TopLeft
            };

            // Email label
            lblEmail = new Label
            {
                Text = "Email",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(40, 160)
            };

            // Email textbox
            txtEmail = new TextBox
            {
                Size = new Size(320, 35),
                Location = new Point(40, 185),
                Font = ModernTheme.Fonts.Body,
                BorderStyle = BorderStyle.None,
                BackColor = ModernTheme.Colors.Background
            };
            txtEmail.GotFocus += TxtEmail_GotFocus;
            txtEmail.LostFocus += TxtEmail_LostFocus;
            txtEmail.KeyDown += TxtEmail_KeyDown;

            // Password label
            lblPassword = new Label
            {
                Text = "Şifrə",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(40, 240)
            };

            // Password textbox
            txtPassword = new TextBox
            {
                Size = new Size(320, 35),
                Location = new Point(40, 265),
                Font = ModernTheme.Fonts.Body,
                BorderStyle = BorderStyle.None,
                BackColor = ModernTheme.Colors.Background,
                PasswordChar = '●'
            };
            txtPassword.GotFocus += TxtPassword_GotFocus;
            txtPassword.LostFocus += TxtPassword_LostFocus;
            txtPassword.KeyDown += TxtPassword_KeyDown;

            // Remember me checkbox
            chkRememberMe = new CheckBox
            {
                Text = "Məni xatırla",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(40, 320),
                FlatStyle = FlatStyle.Flat
            };

            // Login button
            btnLogin = new Button
            {
                Text = "🔑 Daxil Ol",
                Size = new Size(320, 45),
                Location = new Point(40, 360),
                Font = ModernTheme.Fonts.Button,
                BackColor = ModernTheme.Colors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = ModernTheme.Colors.PrimaryDark;
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = ModernTheme.Colors.Primary;

            // Left panel content
            CreateLeftPanelContent();

            // Add controls to login card
            pnlLoginCard.Controls.AddRange(new Control[]
            {
                lblWelcome, lblSubtitle, lblEmail, txtEmail,
                lblPassword, txtPassword, chkRememberMe, btnLogin
            });

            // Add controls to right panel
            pnlRight.Controls.Add(pnlLoginCard);

            // Add panels to main
            pnlMain.Controls.AddRange(new Control[] { pnlLeft, pnlRight });

            // Add main panel to form
            this.Controls.Add(pnlMain);

            // Load last user email
            LoadLastUserEmail();

            this.ResumeLayout(false);
        }

        private void CreateLeftPanelContent()
        {
            // Title
            lblTitle = new Label
            {
                Text = "🌾 AzAgroPOS",
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(60, 100)
            };

            // Version
            lblVersion = new Label
            {
                Text = "Versiya 2.0 - Müasir Kənd Təsərrüfatı İdarəetmə Sistemi",
                Font = ModernTheme.Fonts.Body,
                ForeColor = Color.FromArgb(200, 255, 255, 255),
                AutoSize = false,
                Size = new Size(400, 60),
                Location = new Point(60, 160),
                TextAlign = ContentAlignment.TopLeft
            };

            // Features list
            var features = new[]
            {
                "✓ Satış və anbar idarəetməsi",
                "✓ Müştəri və tədarükçü bazası",
                "✓ Maliyyə hesabatları",
                "✓ Təmir xidməti modulu",
                "✓ Çoxistifadəçili sistem"
            };

            int yPos = 280;
            foreach (var feature in features)
            {
                var lblFeature = new Label
                {
                    Text = feature,
                    Font = ModernTheme.Fonts.Body,
                    ForeColor = Color.FromArgb(230, 255, 255, 255),
                    AutoSize = true,
                    Location = new Point(60, yPos)
                };
                pnlLeft.Controls.Add(lblFeature);
                yPos += 35;
            }

            pnlLeft.Controls.AddRange(new Control[] { lblTitle, lblVersion });
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            // Create gradient background
            using (var brush = new LinearGradientBrush(
                pnlLeft.ClientRectangle,
                ModernTheme.Colors.Primary,
                ModernTheme.Colors.PrimaryDark,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            }

            // Add some decorative elements
            using (var pen = new Pen(Color.FromArgb(50, 255, 255, 255), 2))
            {
                e.Graphics.DrawLine(pen, 40, 250, 200, 250);
            }
        }

        private void PnlLoginCard_Paint(object sender, PaintEventArgs e)
        {
            // Draw shadow
            var shadowRect = new Rectangle(5, 5, pnlLoginCard.Width, pnlLoginCard.Height);
            using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(shadowBrush, shadowRect);
            }

            // Draw card background
            using (var cardBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(cardBrush, pnlLoginCard.ClientRectangle);
            }

            // Draw border
            using (var borderPen = new Pen(ModernTheme.Colors.Border))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, pnlLoginCard.Width - 1, pnlLoginCard.Height - 1);
            }
        }

        private void TxtEmail_GotFocus(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
        }

        private void TxtEmail_LostFocus(object sender, EventArgs e)
        {
            txtEmail.BackColor = ModernTheme.Colors.Background;
        }

        private void TxtPassword_GotFocus(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void TxtPassword_LostFocus(object sender, EventArgs e)
        {
            txtPassword.BackColor = ModernTheme.Colors.Background;
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

        private async 
        Task
TryAutoLoginAsync()
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
                    ShowError(loginResult);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Xəta baş verdi: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "🔑 Daxil Ol";
            }
        }

        private bool ValidateInput(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowError("Email mütləqdir!");
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(email))
            {
                ShowError("Düzgün email formatı daxil edin!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Şifrə mütləqdir!");
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
    }
}