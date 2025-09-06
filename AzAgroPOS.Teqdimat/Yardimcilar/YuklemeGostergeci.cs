using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /// <summary>
    /// A loading indicator control that can be shown over other controls during long operations
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
            this.BackColor = Color.FromArgb(128, 0, 0, 0); // Semi-transparent black
            this.Dock = DockStyle.Fill;
            
            // Setup animation timer
            _animationTimer = new System.Windows.Forms.Timer
            {
                Interval = 50 // 20 FPS
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
            this.Invalidate(); // Trigger repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_isAnimating) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw semi-transparent background
            using (var brush = new SolidBrush(Color.FromArgb(200, Color.Black)))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // Calculate center point
            var centerX = this.Width / 2;
            var centerY = this.Height / 2;
            var radius = 30;
            var circleRadius = 8;

            // Draw loading spinner
            for (int i = 0; i < 12; i++)
            {
                var angle = (_currentAngle + i * 30) * Math.PI / 180;
                var x = centerX + (int)(radius * Math.Cos(angle)) - circleRadius;
                var y = centerY + (int)(radius * Math.Sin(angle)) - circleRadius;
                
                // Calculate opacity based on position
                var opacity = 255 - (i * 20);
                if (opacity < 50) opacity = 50;
                
                using (var brush = new SolidBrush(Color.FromArgb(opacity, Color.White)))
                {
                    g.FillEllipse(brush, x, y, circleRadius * 2, circleRadius * 2);
                }
            }

            // Draw message text
            if (!string.IsNullOrEmpty(_loadingText))
            {
                using (var font = new Font("Segoe UI", 12, FontStyle.Regular))
                using (var brush = new SolidBrush(Color.White))
                {
                    var textSize = g.MeasureString(_loadingText, font);
                    var textX = centerX - textSize.Width / 2;
                    var textY = centerY + radius + 20;
                    g.DrawString(_loadingText, font, brush, textX, textY);
                }
            }
        }

        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(140, 130);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(157, 21);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Məlumatlar yüklənir...";
            // 
            // YuklemeGostergeci
            // 
            this.Controls.Add(this.lblMessage);
            this.Name = "YuklemeGostergeci";
            this.Size = new System.Drawing.Size(434, 291);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblMessage;
    }
}