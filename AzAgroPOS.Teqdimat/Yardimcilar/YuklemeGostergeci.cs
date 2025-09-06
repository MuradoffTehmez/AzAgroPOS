namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// Professional green-toned loading overlay with animated spinner
    /// </summary>
    public partial class YuklemeGostergeci : UserControl
    {
        private System.Windows.Forms.Timer _animationTimer;
        private int _currentAngle = 0;
        private string _loadingText = "Məlumatlar yüklənir...";
        private bool _isAnimating = false;

        public YuklemeGostergeci()
        {
            InitializeComponent();
            this.Visible = false;
            this.BackColor = Color.FromArgb(160, 0, 0, 0); // Overlay: yarı şəffaf qara
            this.Dock = DockStyle.Fill;

            // Timer animasiya
            _animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 60 // ~16 FPS
            };
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        public string LoadingText
        {
            get => _loadingText;
            set
            {
                _loadingText = value;
                if (lblMessage != null)
                    lblMessage.Text = value;
            }
        }

        public bool IsAnimating => _isAnimating;

        public void Start()
        {
            if (!_isAnimating)
            {
                _isAnimating = true;
                _currentAngle = 0;
                this.Visible = true;
                _animationTimer.Start();
            }
        }

        public void Stop()
        {
            if (_isAnimating)
            {
                _isAnimating = false;
                _animationTimer.Stop();
                this.Visible = false;
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _currentAngle = (_currentAngle + 30) % 360;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!_isAnimating) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Mərkəz nöqtəsi
            var centerX = this.Width / 2;
            var centerY = this.Height / 2 - 30;
            var radius = 40;
            var circleRadius = 7;

            // Spinner elementləri
            for (int i = 0; i < 12; i++)
            {
                var angle = (_currentAngle + i * 30) * Math.PI / 180;
                var x = centerX + (int)(radius * Math.Cos(angle)) - circleRadius;
                var y = centerY + (int)(radius * Math.Sin(angle)) - circleRadius;

                int opacity = 255 - (i * 18);
                if (opacity < 50) opacity = 50;

                // Yaşıl tonlu gradient effekti
                Color dotColor = Color.FromArgb(opacity, 0, 200 - (i * 10), 0 + (i * 15));
                using (var brush = new SolidBrush(dotColor))
                {
                    g.FillEllipse(brush, x, y, circleRadius * 2, circleRadius * 2);
                }
            }
        }

        private void InitializeComponent()
        {
            lblMessage = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = false;
            lblMessage.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.FromArgb(0, 230, 118); // Yaşıl vurğu
            lblMessage.BackColor = Color.Transparent;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Padding = new Padding(0, 10, 0, 30);
            lblMessage.Text = "Məlumatlar yüklənir...";
            // 
            // YuklemeGostergeci
            // 
            Controls.Add(lblMessage);
            Name = "YuklemeGostergeci";
            Size = new Size(500, 400);
            ResumeLayout(false);
        }

        private Label lblMessage;
    }
}
