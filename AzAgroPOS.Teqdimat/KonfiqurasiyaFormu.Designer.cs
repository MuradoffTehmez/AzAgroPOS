// AzAgroPOS.Teqdimat/KonfiqurasiyaFormu.Designer.cs
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    partial class KonfiqurasiyaFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialTabControl1 = new MaterialTabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            materialLabel1 = new MaterialLabel();
            txtSirketAdi = new MaterialTextBox();
            materialLabel2 = new MaterialLabel();
            txtSirketUnvani = new MaterialTextBox();
            materialLabel3 = new MaterialLabel();
            txtSirketVoen = new MaterialTextBox();
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel4 = new MaterialLabel();
            nudEdvDerəcəsi = new NumericUpDown();
            tabPage3 = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            materialLabel5 = new MaterialLabel();
            txtQəbzPrinteri = new MaterialTextBox();
            materialLabel6 = new MaterialLabel();
            txtBarkodPrinteri = new MaterialTextBox();
            tabPage4 = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            chkSatisdanSonraQəbziÇapEt = new MaterialCheckbox();
            btnSaxla = new MaterialButton();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdvDerəcəsi).BeginInit();
            tabPage3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabPage4.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialTabControl1.Location = new Point(3, 24);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1364, 523);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(242, 242, 242);
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1356, 493);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Şirkət Məlumatları";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtSirketAdi, 1, 0);
            tableLayoutPanel1.Controls.Add(materialLabel2, 0, 1);
            tableLayoutPanel1.Controls.Add(txtSirketUnvani, 1, 1);
            tableLayoutPanel1.Controls.Add(materialLabel3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtSirketVoen, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1350, 487);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(72, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Şirkət Adı:";
            // 
            // txtSirketAdi
            // 
            txtSirketAdi.AnimateReadOnly = false;
            txtSirketAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketAdi.BorderStyle = BorderStyle.None;
            txtSirketAdi.Depth = 0;
            txtSirketAdi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketAdi.LeadingIcon = null;
            txtSirketAdi.Location = new Point(107, 3);
            txtSirketAdi.MaxLength = 50;
            txtSirketAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketAdi.Multiline = false;
            txtSirketAdi.Name = "txtSirketAdi";
            txtSirketAdi.Size = new Size(300, 50);
            txtSirketAdi.TabIndex = 1;
            txtSirketAdi.Text = "";
            txtSirketAdi.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(3, 50);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(98, 19);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Şirkət Ünvanı:";
            // 
            // txtSirketUnvani
            // 
            txtSirketUnvani.AnimateReadOnly = false;
            txtSirketUnvani.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketUnvani.BorderStyle = BorderStyle.None;
            txtSirketUnvani.Depth = 0;
            txtSirketUnvani.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketUnvani.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketUnvani.LeadingIcon = null;
            txtSirketUnvani.Location = new Point(107, 53);
            txtSirketUnvani.MaxLength = 100;
            txtSirketUnvani.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketUnvani.Multiline = false;
            txtSirketUnvani.Name = "txtSirketUnvani";
            txtSirketUnvani.Size = new Size(300, 50);
            txtSirketUnvani.TabIndex = 3;
            txtSirketUnvani.Text = "";
            txtSirketUnvani.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel3.Location = new Point(3, 100);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(46, 19);
            materialLabel3.TabIndex = 4;
            materialLabel3.Text = "VÖEN:";
            // 
            // txtSirketVoen
            // 
            txtSirketVoen.AnimateReadOnly = false;
            txtSirketVoen.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketVoen.BorderStyle = BorderStyle.None;
            txtSirketVoen.Depth = 0;
            txtSirketVoen.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketVoen.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketVoen.LeadingIcon = null;
            txtSirketVoen.Location = new Point(107, 103);
            txtSirketVoen.MaxLength = 20;
            txtSirketVoen.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketVoen.Multiline = false;
            txtSirketVoen.Name = "txtSirketVoen";
            txtSirketVoen.Size = new Size(300, 50);
            txtSirketVoen.TabIndex = 5;
            txtSirketVoen.Text = "";
            txtSirketVoen.TrailingIcon = null;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(242, 242, 242);
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1356, 493);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Vergi Parametrləri";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.Controls.Add(materialLabel4, 0, 0);
            tableLayoutPanel2.Controls.Add(nudEdvDerəcəsi, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(1350, 487);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel4.Location = new Point(3, 0);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(101, 19);
            materialLabel4.TabIndex = 0;
            materialLabel4.Text = "ƏDV Dərəcəsi:";
            // 
            // nudEdvDerəcəsi
            // 
            nudEdvDerəcəsi.BackColor = Color.FromArgb(242, 242, 242);
            nudEdvDerəcəsi.DecimalPlaces = 2;
            nudEdvDerəcəsi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            nudEdvDerəcəsi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            nudEdvDerəcəsi.Location = new Point(408, 3);
            nudEdvDerəcəsi.Name = "nudEdvDerəcəsi";
            nudEdvDerəcəsi.Size = new Size(120, 24);
            nudEdvDerəcəsi.TabIndex = 1;
            nudEdvDerəcəsi.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(242, 242, 242);
            tabPage3.Controls.Add(tableLayoutPanel3);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1356, 493);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Printer Tənzimləmələri";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.Controls.Add(materialLabel5, 0, 0);
            tableLayoutPanel3.Controls.Add(txtQəbzPrinteri, 1, 0);
            tableLayoutPanel3.Controls.Add(materialLabel6, 0, 1);
            tableLayoutPanel3.Controls.Add(txtBarkodPrinteri, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(1350, 487);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel5.Location = new Point(3, 0);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(95, 19);
            materialLabel5.TabIndex = 0;
            materialLabel5.Text = "Qəbz Printeri:";
            // 
            // txtQəbzPrinteri
            // 
            txtQəbzPrinteri.AnimateReadOnly = false;
            txtQəbzPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            txtQəbzPrinteri.BorderStyle = BorderStyle.None;
            txtQəbzPrinteri.Depth = 0;
            txtQəbzPrinteri.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQəbzPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQəbzPrinteri.LeadingIcon = null;
            txtQəbzPrinteri.Location = new Point(408, 3);
            txtQəbzPrinteri.MaxLength = 50;
            txtQəbzPrinteri.MouseState = MaterialSkin.MouseState.OUT;
            txtQəbzPrinteri.Multiline = false;
            txtQəbzPrinteri.Name = "txtQəbzPrinteri";
            txtQəbzPrinteri.Size = new Size(300, 50);
            txtQəbzPrinteri.TabIndex = 1;
            txtQəbzPrinteri.Text = "";
            txtQəbzPrinteri.TrailingIcon = null;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel6.Location = new Point(3, 50);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(109, 19);
            materialLabel6.TabIndex = 2;
            materialLabel6.Text = "Barkod Printeri:";
            // 
            // txtBarkodPrinteri
            // 
            txtBarkodPrinteri.AnimateReadOnly = false;
            txtBarkodPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            txtBarkodPrinteri.BorderStyle = BorderStyle.None;
            txtBarkodPrinteri.Depth = 0;
            txtBarkodPrinteri.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkodPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBarkodPrinteri.LeadingIcon = null;
            txtBarkodPrinteri.Location = new Point(408, 53);
            txtBarkodPrinteri.MaxLength = 50;
            txtBarkodPrinteri.MouseState = MaterialSkin.MouseState.OUT;
            txtBarkodPrinteri.Multiline = false;
            txtBarkodPrinteri.Name = "txtBarkodPrinteri";
            txtBarkodPrinteri.Size = new Size(300, 50);
            txtBarkodPrinteri.TabIndex = 3;
            txtBarkodPrinteri.Text = "";
            txtBarkodPrinteri.TrailingIcon = null;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(242, 242, 242);
            tabPage4.Controls.Add(tableLayoutPanel4);
            tabPage4.Location = new Point(4, 26);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1356, 493);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Proqram Davranışı";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel4.Controls.Add(chkSatisdanSonraQəbziÇapEt, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(1350, 487);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // chkSatisdanSonraQəbziÇapEt
            // 
            chkSatisdanSonraQəbziÇapEt.AutoSize = true;
            chkSatisdanSonraQəbziÇapEt.BackColor = Color.FromArgb(242, 242, 242);
            chkSatisdanSonraQəbziÇapEt.Depth = 0;
            chkSatisdanSonraQəbziÇapEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkSatisdanSonraQəbziÇapEt.Location = new Point(405, 0);
            chkSatisdanSonraQəbziÇapEt.Margin = new Padding(0);
            chkSatisdanSonraQəbziÇapEt.MouseLocation = new Point(-1, -1);
            chkSatisdanSonraQəbziÇapEt.MouseState = MaterialSkin.MouseState.HOVER;
            chkSatisdanSonraQəbziÇapEt.Name = "chkSatisdanSonraQəbziÇapEt";
            chkSatisdanSonraQəbziÇapEt.ReadOnly = false;
            chkSatisdanSonraQəbziÇapEt.Ripple = true;
            chkSatisdanSonraQəbziÇapEt.Size = new Size(231, 37);
            chkSatisdanSonraQəbziÇapEt.TabIndex = 0;
            chkSatisdanSonraQəbziÇapEt.Text = "Satışdan sonra qəbzi çap et";
            chkSatisdanSonraQəbziÇapEt.UseVisualStyleBackColor = false;
            // 
            // btnSaxla
            // 
            btnSaxla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaxla.BackColor = Color.FromArgb(242, 242, 242);
            btnSaxla.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSaxla.Depth = 0;
            btnSaxla.Dock = DockStyle.Bottom;
            btnSaxla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSaxla.HighEmphasis = true;
            btnSaxla.Icon = null;
            btnSaxla.Location = new Point(3, 547);
            btnSaxla.Margin = new Padding(4, 6, 4, 6);
            btnSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaxla.Name = "btnSaxla";
            btnSaxla.NoAccentTextColor = Color.Empty;
            btnSaxla.Size = new Size(1364, 36);
            btnSaxla.TabIndex = 1;
            btnSaxla.Text = "Saxla";
            btnSaxla.Type = MaterialButton.MaterialButtonType.Contained;
            btnSaxla.UseAccentColor = false;
            btnSaxla.UseVisualStyleBackColor = false;
            btnSaxla.Click += btnSaxla_Click;
            // 
            // KonfiqurasiyaFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 608);
            Controls.Add(materialTabControl1);
            Controls.Add(btnSaxla);
            FormStyle = FormStyles.ActionBar_None;
            Name = "KonfiqurasiyaFormu";
            Padding = new Padding(3, 24, 3, 3);
            Text = "Tənzimləmələr";
            Load += KonfiqurasiyaFormu_Load;
            Controls.SetChildIndex(btnSaxla, 0);
            Controls.SetChildIndex(materialTabControl1, 0);
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdvDerəcəsi).EndInit();
            tabPage3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialLabel materialLabel1;
        private MaterialTextBox txtSirketAdi;
        private MaterialLabel materialLabel2;
        private MaterialTextBox txtSirketUnvani;
        private MaterialLabel materialLabel3;
        private MaterialTextBox txtSirketVoen;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialLabel materialLabel4;
        private NumericUpDown nudEdvDerəcəsi;
        private TabPage tabPage3;
        private TableLayoutPanel tableLayoutPanel3;
        private MaterialLabel materialLabel5;
        private MaterialTextBox txtQəbzPrinteri;
        private MaterialLabel materialLabel6;
        private MaterialTextBox txtBarkodPrinteri;
        private TabPage tabPage4;
        private TableLayoutPanel tableLayoutPanel4;
        private MaterialCheckbox chkSatisdanSonraQəbziÇapEt;
        private MaterialButton btnSaxla;
    }
}