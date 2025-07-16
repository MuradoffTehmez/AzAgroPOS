using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class ModernSplashScreen : Form
    {
        private Timer progressTimer;
        private int progressValue = 0;
        private Panel progressPanel;
        private Label lblProgress;
        private Label lblStatus;
        private Label lblTitle;
        private IconPictureBox picLogo;
        private Panel progressBar;
        private Panel progressBarContainer;

        // Round corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public ModernSplashScreen()
        {
            InitializeComponent();
            SetupSplashScreen();
            StartProgress();
        }

        private void SetupSplashScreen()
        {
            // Form settings
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Apply rounded corners
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Main panel
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(45, 45, 48)
            };
            mainPanel.Paint += MainPanel_Paint;

            // Logo
            picLogo = new IconPictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(210, 50),
                IconChar = IconChar.Seedling,
                IconColor = Color.FromArgb(76, 175, 80),
                IconSize = 80,
                BackColor = Color.Transparent
            };

            // Title
            lblTitle = new Label
            {
                Text = "AzAgroPOS",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblTitle.Location = new Point((this.Width - lblTitle.Width) / 2, 140);

            // Version info
            var lblVersion = new Label
            {
                Text = "Versiya 2.0",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblVersion.Location = new Point((this.Width - lblVersion.Width) / 2, 180);

            // Progress bar container
            progressBarContainer = new Panel
            {
                Size = new Size(300, 6),
                Location = new Point(100, 220),
                BackColor = Color.FromArgb(60, 60, 60)
            };
            progressBarContainer.Paint += ProgressBarContainer_Paint;

            // Progress bar
            progressBar = new Panel
            {
                Size = new Size(0, 6),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(63, 81, 181)
            };
            progressBar.Paint += ProgressBar_Paint;
            progressBarContainer.Controls.Add(progressBar);

            // Status label
            lblStatus = new Label
            {
                Text = "Başladılır...",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                Location = new Point(100, 240),
                BackColor = Color.Transparent
            };

            // Progress percentage
            lblProgress = new Label
            {
                Text = "0%",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 180, 180),
                AutoSize = true,
                Location = new Point(370, 240),
                BackColor = Color.Transparent
            };

            // Add controls to main panel
            mainPanel.Controls.AddRange(new Control[] 
            { 
                picLogo, lblTitle, lblVersion, progressBarContainer, lblStatus, lblProgress 
            });

            // Add main panel to form
            this.Controls.Add(mainPanel);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create gradient background
            var rect = this.ClientRectangle;
            using (var brush = new LinearGradientBrush(rect, 
                Color.FromArgb(45, 45, 48), 
                Color.FromArgb(30, 30, 32), 
                LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(brush, rect);
            }

            // Add subtle border
            using (var pen = new Pen(Color.FromArgb(80, 80, 80), 2))
            {
                graphics.DrawRectangle(pen, 1, 1, this.Width - 3, this.Height - 3);
            }
        }

        private void ProgressBarContainer_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw rounded container
            var rect = new Rectangle(0, 0, progressBarContainer.Width, progressBarContainer.Height);
            using (var path = GetRoundedRectPath(rect, 3))
            {
                using (var brush = new SolidBrush(Color.FromArgb(60, 60, 60)))
                {
                    graphics.FillPath(brush, path);
                }
            }
        }

        private void ProgressBar_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw rounded progress bar
            var rect = new Rectangle(0, 0, progressBar.Width, progressBar.Height);
            using (var path = GetRoundedRectPath(rect, 3))
            {
                using (var brush = new LinearGradientBrush(rect, 
                    Color.FromArgb(63, 81, 181), 
                    Color.FromArgb(83, 101, 201), 
                    LinearGradientMode.Horizontal))
                {
                    graphics.FillPath(brush, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            if (rect.Width > 0 && rect.Height > 0)
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
            }
            return path;
        }

        private void StartProgress()
        {
            progressTimer = new Timer();
            progressTimer.Interval = 50;
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            
            // Update progress bar width
            progressBar.Width = (int)(progressBarContainer.Width * progressValue / 100.0);
            lblProgress.Text = $"{progressValue}%";
            
            // Update status text
            if (progressValue <= 20)
                lblStatus.Text = "Modullar yüklənir...";
            else if (progressValue <= 40)
                lblStatus.Text = "Verilənlər bazası hazırlanır...";
            else if (progressValue <= 60)
                lblStatus.Text = "Xidmətlər başladılır...";
            else if (progressValue <= 80)
                lblStatus.Text = "İstifadəçi interfeysi hazırlanır...";
            else if (progressValue <= 95)
                lblStatus.Text = "Son yoxlamalar...";
            else
                lblStatus.Text = "Hazır!";

            if (progressValue >= 100)
            {
                progressTimer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            progressTimer?.Stop();
            progressTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}