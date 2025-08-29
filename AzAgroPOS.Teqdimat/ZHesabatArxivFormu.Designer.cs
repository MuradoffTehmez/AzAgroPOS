// Fayl: AzAgroPOS.Teqdimat/ZHesabatArxivFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class ZHesabatArxivFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvNovbeler = new DataGridView();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)dgvNovbeler).BeginInit();
            SuspendLayout();
            // 
            // dgvNovbeler
            // 
            dgvNovbeler.AllowUserToAddRows = false;
            dgvNovbeler.AllowUserToDeleteRows = false;
            dgvNovbeler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNovbeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNovbeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNovbeler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvNovbeler.Location = new Point(23, 85);
            dgvNovbeler.MultiSelect = false;
            dgvNovbeler.Name = "dgvNovbeler";
            dgvNovbeler.ReadOnly = true;
            dgvNovbeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNovbeler.Size = new Size(938, 510);
            dgvNovbeler.TabIndex = 0;
            // 
            // btnGoster
            // 
            btnGoster.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGoster.BackColor = Color.FromArgb(242, 242, 242);
            btnGoster.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGoster.Depth = 0;
            btnGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGoster.HighEmphasis = true;
            btnGoster.Icon = null;
            btnGoster.Location = new Point(740, 615);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(221, 36);
            btnGoster.TabIndex = 1;
            btnGoster.Text = "Seçilmiş Hesabatı Göstər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            btnGoster.Click += btnGoster_Click;
            // 
            // ZHesabatArxivFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 672);
            Controls.Add(btnGoster);
            Controls.Add(dgvNovbeler);
            Name = "ZHesabatArxivFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Z-Hesabat Arxivi";
            Load += ZHesabatArxivFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNovbeler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private DataGridView dgvNovbeler;
        private MaterialSkin.Controls.MaterialButton btnGoster;
    }
}