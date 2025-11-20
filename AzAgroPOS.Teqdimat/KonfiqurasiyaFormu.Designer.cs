// AzAgroPOS.Teqdimat/KonfiqurasiyaFormu.Designer.cs
using MaterialSkin.Controls;
using System.Windows.Forms;

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
            tabControl = new MaterialTabControl();
            tabSirket = new TabPage();
            tblSirket = new TableLayoutPanel();
            lblSirketAdi = new MaterialLabel();
            txtSirketAdi = new MaterialTextBox();
            lblSirketUnvani = new MaterialLabel();
            txtSirketUnvani = new MaterialTextBox();
            lblSirketVoen = new MaterialLabel();
            txtSirketVoen = new MaterialTextBox();
            lblSirketTelefon = new MaterialLabel();
            txtSirketTelefon = new MaterialTextBox();
            lblSirketEmail = new MaterialLabel();
            txtSirketEmail = new MaterialTextBox();
            lblSirketVebSayt = new MaterialLabel();
            txtSirketVebSayt = new MaterialTextBox();
            lblSirketLogo = new MaterialLabel();
            pnlLogo = new Panel();
            picLogo = new PictureBox();
            btnLogoSec = new MaterialButton();
            tabVergi = new TabPage();
            tblVergi = new TableLayoutPanel();
            lblEdvDerecesi = new MaterialLabel();
            nudEdvDerecesi = new NumericUpDown();
            lblEdvInfo = new MaterialLabel();
            tabPrinter = new TabPage();
            tblPrinter = new TableLayoutPanel();
            lblQebzPrinteri = new MaterialLabel();
            pnlQebzPrinter = new Panel();
            txtQebzPrinteri = new MaterialTextBox();
            btnQebzPrinterSec = new MaterialButton();
            lblBarkodPrinteri = new MaterialLabel();
            pnlBarkodPrinter = new Panel();
            txtBarkodPrinteri = new MaterialTextBox();
            btnBarkodPrinterSec = new MaterialButton();
            lblKagizOlcusu = new MaterialLabel();
            cmbKagizOlcusu = new MaterialComboBox();
            tabDavranis = new TabPage();
            tblDavranis = new TableLayoutPanel();
            chkQebzAvtoCap = new MaterialCheckbox();
            chkAvtomatikYedekleme = new MaterialCheckbox();
            lblYedeklemeSaati = new MaterialLabel();
            txtYedeklemeSaati = new MaterialTextBox();
            tabSistem = new TabPage();
            tblSistem = new TableLayoutPanel();
            lblDil = new MaterialLabel();
            cmbDil = new MaterialComboBox();
            lblValyuta = new MaterialLabel();
            cmbValyuta = new MaterialComboBox();
            lblTarixFormati = new MaterialLabel();
            txtTarixFormati = new MaterialTextBox();
            lblReqemFormati = new MaterialLabel();
            txtReqemFormati = new MaterialTextBox();
            lblTema = new MaterialLabel();
            cmbTema = new MaterialComboBox();
            lblSessiyaTimeout = new MaterialLabel();
            nudSessiyaTimeout = new NumericUpDown();
            pnlButtons = new Panel();
            btnLegvEt = new MaterialButton();
            btnSaxla = new MaterialButton();
            tabControl.SuspendLayout();
            tabSirket.SuspendLayout();
            tblSirket.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tabVergi.SuspendLayout();
            tblVergi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdvDerecesi).BeginInit();
            tabPrinter.SuspendLayout();
            tblPrinter.SuspendLayout();
            pnlQebzPrinter.SuspendLayout();
            pnlBarkodPrinter.SuspendLayout();
            tabDavranis.SuspendLayout();
            tblDavranis.SuspendLayout();
            tabSistem.SuspendLayout();
            tblSistem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSessiyaTimeout).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabSirket);
            tabControl.Controls.Add(tabVergi);
            tabControl.Controls.Add(tabPrinter);
            tabControl.Controls.Add(tabDavranis);
            tabControl.Controls.Add(tabSistem);
            tabControl.Depth = 0;
            tabControl.Dock = DockStyle.Fill;
            tabControl.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tabControl.Location = new Point(3, 24);
            tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1244, 551);
            tabControl.TabIndex = 0;
            // 
            // tabSirket
            // 
            tabSirket.BackColor = Color.FromArgb(242, 242, 242);
            tabSirket.Controls.Add(tblSirket);
            tabSirket.Location = new Point(4, 26);
            tabSirket.Name = "tabSirket";
            tabSirket.Padding = new Padding(15);
            tabSirket.Size = new Size(1236, 521);
            tabSirket.TabIndex = 0;
            tabSirket.Text = "Şirkət Məlumatları";
            // 
            // tblSirket
            // 
            tblSirket.BackColor = Color.FromArgb(242, 242, 242);
            tblSirket.ColumnCount = 2;
            tblSirket.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tblSirket.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSirket.Controls.Add(lblSirketAdi, 0, 0);
            tblSirket.Controls.Add(txtSirketAdi, 1, 0);
            tblSirket.Controls.Add(lblSirketUnvani, 0, 1);
            tblSirket.Controls.Add(txtSirketUnvani, 1, 1);
            tblSirket.Controls.Add(lblSirketVoen, 0, 2);
            tblSirket.Controls.Add(txtSirketVoen, 1, 2);
            tblSirket.Controls.Add(lblSirketTelefon, 0, 3);
            tblSirket.Controls.Add(txtSirketTelefon, 1, 3);
            tblSirket.Controls.Add(lblSirketEmail, 0, 4);
            tblSirket.Controls.Add(txtSirketEmail, 1, 4);
            tblSirket.Controls.Add(lblSirketVebSayt, 0, 5);
            tblSirket.Controls.Add(txtSirketVebSayt, 1, 5);
            tblSirket.Controls.Add(lblSirketLogo, 0, 6);
            tblSirket.Controls.Add(pnlLogo, 1, 6);
            tblSirket.Dock = DockStyle.Fill;
            tblSirket.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tblSirket.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tblSirket.Location = new Point(15, 15);
            tblSirket.Name = "tblSirket";
            tblSirket.RowCount = 8;
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tblSirket.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSirket.Size = new Size(1206, 491);
            tblSirket.TabIndex = 0;
            // 
            // lblSirketAdi
            // 
            lblSirketAdi.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketAdi.Depth = 0;
            lblSirketAdi.Dock = DockStyle.Fill;
            lblSirketAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketAdi.Location = new Point(3, 0);
            lblSirketAdi.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketAdi.Name = "lblSirketAdi";
            lblSirketAdi.Size = new Size(174, 60);
            lblSirketAdi.TabIndex = 0;
            lblSirketAdi.Text = "Şirkət Adı *";
            lblSirketAdi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketAdi
            // 
            txtSirketAdi.AnimateReadOnly = false;
            txtSirketAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketAdi.BorderStyle = BorderStyle.None;
            txtSirketAdi.Depth = 0;
            txtSirketAdi.Dock = DockStyle.Fill;
            txtSirketAdi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketAdi.Hint = "Şirkətin rəsmi adını daxil edin";
            txtSirketAdi.LeadingIcon = null;
            txtSirketAdi.Location = new Point(183, 3);
            txtSirketAdi.MaxLength = 200;
            txtSirketAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketAdi.Multiline = false;
            txtSirketAdi.Name = "txtSirketAdi";
            txtSirketAdi.Size = new Size(1020, 50);
            txtSirketAdi.TabIndex = 1;
            txtSirketAdi.Text = "";
            txtSirketAdi.TrailingIcon = null;
            // 
            // lblSirketUnvani
            // 
            lblSirketUnvani.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketUnvani.Depth = 0;
            lblSirketUnvani.Dock = DockStyle.Fill;
            lblSirketUnvani.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketUnvani.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketUnvani.Location = new Point(3, 60);
            lblSirketUnvani.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketUnvani.Name = "lblSirketUnvani";
            lblSirketUnvani.Size = new Size(174, 80);
            lblSirketUnvani.TabIndex = 2;
            lblSirketUnvani.Text = "Şirkət Ünvanı";
            lblSirketUnvani.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketUnvani
            // 
            txtSirketUnvani.AnimateReadOnly = false;
            txtSirketUnvani.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketUnvani.BorderStyle = BorderStyle.None;
            txtSirketUnvani.Depth = 0;
            txtSirketUnvani.Dock = DockStyle.Fill;
            txtSirketUnvani.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketUnvani.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketUnvani.Hint = "Şirkətin qeydiyyat ünvanını daxil edin";
            txtSirketUnvani.LeadingIcon = null;
            txtSirketUnvani.Location = new Point(183, 63);
            txtSirketUnvani.MaxLength = 500;
            txtSirketUnvani.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketUnvani.Multiline = false;
            txtSirketUnvani.Name = "txtSirketUnvani";
            txtSirketUnvani.Size = new Size(1020, 50);
            txtSirketUnvani.TabIndex = 3;
            txtSirketUnvani.Text = "";
            txtSirketUnvani.TrailingIcon = null;
            // 
            // lblSirketVoen
            // 
            lblSirketVoen.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketVoen.Depth = 0;
            lblSirketVoen.Dock = DockStyle.Fill;
            lblSirketVoen.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketVoen.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketVoen.Location = new Point(3, 140);
            lblSirketVoen.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketVoen.Name = "lblSirketVoen";
            lblSirketVoen.Size = new Size(174, 60);
            lblSirketVoen.TabIndex = 4;
            lblSirketVoen.Text = "VÖEN";
            lblSirketVoen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketVoen
            // 
            txtSirketVoen.AnimateReadOnly = false;
            txtSirketVoen.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketVoen.BorderStyle = BorderStyle.None;
            txtSirketVoen.Depth = 0;
            txtSirketVoen.Dock = DockStyle.Fill;
            txtSirketVoen.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketVoen.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketVoen.Hint = "10 rəqəmli VÖEN";
            txtSirketVoen.LeadingIcon = null;
            txtSirketVoen.Location = new Point(183, 143);
            txtSirketVoen.MaxLength = 10;
            txtSirketVoen.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketVoen.Multiline = false;
            txtSirketVoen.Name = "txtSirketVoen";
            txtSirketVoen.Size = new Size(1020, 50);
            txtSirketVoen.TabIndex = 5;
            txtSirketVoen.Text = "";
            txtSirketVoen.TrailingIcon = null;
            // 
            // lblSirketTelefon
            // 
            lblSirketTelefon.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketTelefon.Depth = 0;
            lblSirketTelefon.Dock = DockStyle.Fill;
            lblSirketTelefon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketTelefon.Location = new Point(3, 200);
            lblSirketTelefon.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketTelefon.Name = "lblSirketTelefon";
            lblSirketTelefon.Size = new Size(174, 60);
            lblSirketTelefon.TabIndex = 6;
            lblSirketTelefon.Text = "Telefon";
            lblSirketTelefon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketTelefon
            // 
            txtSirketTelefon.AnimateReadOnly = false;
            txtSirketTelefon.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketTelefon.BorderStyle = BorderStyle.None;
            txtSirketTelefon.Depth = 0;
            txtSirketTelefon.Dock = DockStyle.Fill;
            txtSirketTelefon.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketTelefon.Hint = "+994501234567";
            txtSirketTelefon.LeadingIcon = null;
            txtSirketTelefon.Location = new Point(183, 203);
            txtSirketTelefon.MaxLength = 20;
            txtSirketTelefon.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketTelefon.Multiline = false;
            txtSirketTelefon.Name = "txtSirketTelefon";
            txtSirketTelefon.Size = new Size(1020, 50);
            txtSirketTelefon.TabIndex = 7;
            txtSirketTelefon.Text = "";
            txtSirketTelefon.TrailingIcon = null;
            // 
            // lblSirketEmail
            // 
            lblSirketEmail.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketEmail.Depth = 0;
            lblSirketEmail.Dock = DockStyle.Fill;
            lblSirketEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketEmail.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketEmail.Location = new Point(3, 260);
            lblSirketEmail.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketEmail.Name = "lblSirketEmail";
            lblSirketEmail.Size = new Size(174, 60);
            lblSirketEmail.TabIndex = 8;
            lblSirketEmail.Text = "Email";
            lblSirketEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketEmail
            // 
            txtSirketEmail.AnimateReadOnly = false;
            txtSirketEmail.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketEmail.BorderStyle = BorderStyle.None;
            txtSirketEmail.Depth = 0;
            txtSirketEmail.Dock = DockStyle.Fill;
            txtSirketEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketEmail.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketEmail.Hint = "info@company.az";
            txtSirketEmail.LeadingIcon = null;
            txtSirketEmail.Location = new Point(183, 263);
            txtSirketEmail.MaxLength = 100;
            txtSirketEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketEmail.Multiline = false;
            txtSirketEmail.Name = "txtSirketEmail";
            txtSirketEmail.Size = new Size(1020, 50);
            txtSirketEmail.TabIndex = 9;
            txtSirketEmail.Text = "";
            txtSirketEmail.TrailingIcon = null;
            // 
            // lblSirketVebSayt
            // 
            lblSirketVebSayt.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketVebSayt.Depth = 0;
            lblSirketVebSayt.Dock = DockStyle.Fill;
            lblSirketVebSayt.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketVebSayt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketVebSayt.Location = new Point(3, 320);
            lblSirketVebSayt.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketVebSayt.Name = "lblSirketVebSayt";
            lblSirketVebSayt.Size = new Size(174, 60);
            lblSirketVebSayt.TabIndex = 10;
            lblSirketVebSayt.Text = "Veb Sayt";
            lblSirketVebSayt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSirketVebSayt
            // 
            txtSirketVebSayt.AnimateReadOnly = false;
            txtSirketVebSayt.BackColor = Color.FromArgb(242, 242, 242);
            txtSirketVebSayt.BorderStyle = BorderStyle.None;
            txtSirketVebSayt.Depth = 0;
            txtSirketVebSayt.Dock = DockStyle.Fill;
            txtSirketVebSayt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSirketVebSayt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSirketVebSayt.Hint = "https://www.company.az";
            txtSirketVebSayt.LeadingIcon = null;
            txtSirketVebSayt.Location = new Point(183, 323);
            txtSirketVebSayt.MaxLength = 200;
            txtSirketVebSayt.MouseState = MaterialSkin.MouseState.OUT;
            txtSirketVebSayt.Multiline = false;
            txtSirketVebSayt.Name = "txtSirketVebSayt";
            txtSirketVebSayt.Size = new Size(1020, 50);
            txtSirketVebSayt.TabIndex = 11;
            txtSirketVebSayt.Text = "";
            txtSirketVebSayt.TrailingIcon = null;
            // 
            // lblSirketLogo
            // 
            lblSirketLogo.BackColor = Color.FromArgb(242, 242, 242);
            lblSirketLogo.Depth = 0;
            lblSirketLogo.Dock = DockStyle.Fill;
            lblSirketLogo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSirketLogo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSirketLogo.Location = new Point(3, 380);
            lblSirketLogo.MouseState = MaterialSkin.MouseState.HOVER;
            lblSirketLogo.Name = "lblSirketLogo";
            lblSirketLogo.Size = new Size(174, 120);
            lblSirketLogo.TabIndex = 12;
            lblSirketLogo.Text = "Şirkət Loqosu";
            lblSirketLogo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(242, 242, 242);
            pnlLogo.Controls.Add(picLogo);
            pnlLogo.Controls.Add(btnLogoSec);
            pnlLogo.Dock = DockStyle.Fill;
            pnlLogo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlLogo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlLogo.Location = new Point(183, 383);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(1020, 114);
            pnlLogo.TabIndex = 13;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.FromArgb(242, 242, 242);
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            picLogo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            picLogo.Location = new Point(0, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(100, 100);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // btnLogoSec
            // 
            btnLogoSec.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogoSec.BackColor = Color.FromArgb(242, 242, 242);
            btnLogoSec.Density = MaterialButton.MaterialButtonDensity.Default;
            btnLogoSec.Depth = 0;
            btnLogoSec.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnLogoSec.HighEmphasis = false;
            btnLogoSec.Icon = null;
            btnLogoSec.Location = new Point(110, 10);
            btnLogoSec.Margin = new Padding(4, 6, 4, 6);
            btnLogoSec.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogoSec.Name = "btnLogoSec";
            btnLogoSec.NoAccentTextColor = Color.Empty;
            btnLogoSec.Size = new Size(90, 36);
            btnLogoSec.TabIndex = 1;
            btnLogoSec.Text = "Logo Seç";
            btnLogoSec.Type = MaterialButton.MaterialButtonType.Outlined;
            btnLogoSec.UseAccentColor = false;
            btnLogoSec.UseVisualStyleBackColor = false;
            // 
            // tabVergi
            // 
            tabVergi.BackColor = Color.FromArgb(242, 242, 242);
            tabVergi.Controls.Add(tblVergi);
            tabVergi.Location = new Point(4, 26);
            tabVergi.Name = "tabVergi";
            tabVergi.Padding = new Padding(15);
            tabVergi.Size = new Size(1236, 521);
            tabVergi.TabIndex = 1;
            tabVergi.Text = "Vergi Parametrləri";
            // 
            // tblVergi
            // 
            tblVergi.BackColor = Color.FromArgb(242, 242, 242);
            tblVergi.ColumnCount = 2;
            tblVergi.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tblVergi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblVergi.Controls.Add(lblEdvDerecesi, 0, 0);
            tblVergi.Controls.Add(nudEdvDerecesi, 1, 0);
            tblVergi.Controls.Add(lblEdvInfo, 1, 1);
            tblVergi.Dock = DockStyle.Fill;
            tblVergi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tblVergi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tblVergi.Location = new Point(15, 15);
            tblVergi.Name = "tblVergi";
            tblVergi.RowCount = 3;
            tblVergi.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblVergi.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblVergi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblVergi.Size = new Size(1206, 491);
            tblVergi.TabIndex = 0;
            // 
            // lblEdvDerecesi
            // 
            lblEdvDerecesi.BackColor = Color.FromArgb(242, 242, 242);
            lblEdvDerecesi.Depth = 0;
            lblEdvDerecesi.Dock = DockStyle.Fill;
            lblEdvDerecesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEdvDerecesi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEdvDerecesi.Location = new Point(3, 0);
            lblEdvDerecesi.MouseState = MaterialSkin.MouseState.HOVER;
            lblEdvDerecesi.Name = "lblEdvDerecesi";
            lblEdvDerecesi.Size = new Size(174, 60);
            lblEdvDerecesi.TabIndex = 0;
            lblEdvDerecesi.Text = "ƏDV Dərəcəsi (%)";
            lblEdvDerecesi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudEdvDerecesi
            // 
            nudEdvDerecesi.BackColor = Color.FromArgb(242, 242, 242);
            nudEdvDerecesi.DecimalPlaces = 2;
            nudEdvDerecesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            nudEdvDerecesi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            nudEdvDerecesi.Location = new Point(183, 3);
            nudEdvDerecesi.Name = "nudEdvDerecesi";
            nudEdvDerecesi.Size = new Size(150, 24);
            nudEdvDerecesi.TabIndex = 1;
            nudEdvDerecesi.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // lblEdvInfo
            // 
            lblEdvInfo.AutoSize = true;
            lblEdvInfo.BackColor = Color.FromArgb(242, 242, 242);
            lblEdvInfo.Depth = 0;
            lblEdvInfo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEdvInfo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEdvInfo.Location = new Point(183, 60);
            lblEdvInfo.MouseState = MaterialSkin.MouseState.HOVER;
            lblEdvInfo.Name = "lblEdvInfo";
            lblEdvInfo.Size = new Size(386, 19);
            lblEdvInfo.TabIndex = 2;
            lblEdvInfo.Text = "Qəbzlərdə və hesablarda tətbiq olunacaq ƏDV dərəcəsi";
            // 
            // tabPrinter
            // 
            tabPrinter.BackColor = Color.FromArgb(242, 242, 242);
            tabPrinter.Controls.Add(tblPrinter);
            tabPrinter.Location = new Point(4, 26);
            tabPrinter.Name = "tabPrinter";
            tabPrinter.Padding = new Padding(15);
            tabPrinter.Size = new Size(1236, 521);
            tabPrinter.TabIndex = 2;
            tabPrinter.Text = "Printer Tənzimləmələri";
            // 
            // tblPrinter
            // 
            tblPrinter.BackColor = Color.FromArgb(242, 242, 242);
            tblPrinter.ColumnCount = 2;
            tblPrinter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tblPrinter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPrinter.Controls.Add(lblQebzPrinteri, 0, 0);
            tblPrinter.Controls.Add(pnlQebzPrinter, 1, 0);
            tblPrinter.Controls.Add(lblBarkodPrinteri, 0, 1);
            tblPrinter.Controls.Add(pnlBarkodPrinter, 1, 1);
            tblPrinter.Controls.Add(lblKagizOlcusu, 0, 2);
            tblPrinter.Controls.Add(cmbKagizOlcusu, 1, 2);
            tblPrinter.Dock = DockStyle.Fill;
            tblPrinter.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tblPrinter.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tblPrinter.Location = new Point(15, 15);
            tblPrinter.Name = "tblPrinter";
            tblPrinter.RowCount = 4;
            tblPrinter.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblPrinter.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblPrinter.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblPrinter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPrinter.Size = new Size(1206, 491);
            tblPrinter.TabIndex = 0;
            // 
            // lblQebzPrinteri
            // 
            lblQebzPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            lblQebzPrinteri.Depth = 0;
            lblQebzPrinteri.Dock = DockStyle.Fill;
            lblQebzPrinteri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQebzPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblQebzPrinteri.Location = new Point(3, 0);
            lblQebzPrinteri.MouseState = MaterialSkin.MouseState.HOVER;
            lblQebzPrinteri.Name = "lblQebzPrinteri";
            lblQebzPrinteri.Size = new Size(174, 60);
            lblQebzPrinteri.TabIndex = 0;
            lblQebzPrinteri.Text = "Qəbz Printeri";
            lblQebzPrinteri.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlQebzPrinter
            // 
            pnlQebzPrinter.BackColor = Color.FromArgb(242, 242, 242);
            pnlQebzPrinter.Controls.Add(txtQebzPrinteri);
            pnlQebzPrinter.Controls.Add(btnQebzPrinterSec);
            pnlQebzPrinter.Dock = DockStyle.Fill;
            pnlQebzPrinter.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlQebzPrinter.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlQebzPrinter.Location = new Point(180, 0);
            pnlQebzPrinter.Margin = new Padding(0);
            pnlQebzPrinter.Name = "pnlQebzPrinter";
            pnlQebzPrinter.Size = new Size(1026, 60);
            pnlQebzPrinter.TabIndex = 1;
            // 
            // txtQebzPrinteri
            // 
            txtQebzPrinteri.AnimateReadOnly = true;
            txtQebzPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            txtQebzPrinteri.BorderStyle = BorderStyle.None;
            txtQebzPrinteri.Depth = 0;
            txtQebzPrinteri.Dock = DockStyle.Fill;
            txtQebzPrinteri.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQebzPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQebzPrinteri.Hint = "Printer seçilməyib";
            txtQebzPrinteri.LeadingIcon = null;
            txtQebzPrinteri.Location = new Point(0, 0);
            txtQebzPrinteri.MaxLength = 50;
            txtQebzPrinteri.MouseState = MaterialSkin.MouseState.OUT;
            txtQebzPrinteri.Multiline = false;
            txtQebzPrinteri.Name = "txtQebzPrinteri";
            txtQebzPrinteri.ReadOnly = true;
            txtQebzPrinteri.Size = new Size(914, 50);
            txtQebzPrinteri.TabIndex = 0;
            txtQebzPrinteri.Text = "";
            txtQebzPrinteri.TrailingIcon = null;
            // 
            // btnQebzPrinterSec
            // 
            btnQebzPrinterSec.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQebzPrinterSec.BackColor = Color.FromArgb(242, 242, 242);
            btnQebzPrinterSec.Density = MaterialButton.MaterialButtonDensity.Default;
            btnQebzPrinterSec.Depth = 0;
            btnQebzPrinterSec.Dock = DockStyle.Right;
            btnQebzPrinterSec.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnQebzPrinterSec.HighEmphasis = false;
            btnQebzPrinterSec.Icon = null;
            btnQebzPrinterSec.Location = new Point(914, 0);
            btnQebzPrinterSec.Margin = new Padding(4, 6, 4, 6);
            btnQebzPrinterSec.MouseState = MaterialSkin.MouseState.HOVER;
            btnQebzPrinterSec.Name = "btnQebzPrinterSec";
            btnQebzPrinterSec.NoAccentTextColor = Color.Empty;
            btnQebzPrinterSec.Size = new Size(112, 60);
            btnQebzPrinterSec.TabIndex = 1;
            btnQebzPrinterSec.Text = "Printer Seç";
            btnQebzPrinterSec.Type = MaterialButton.MaterialButtonType.Outlined;
            btnQebzPrinterSec.UseAccentColor = false;
            btnQebzPrinterSec.UseVisualStyleBackColor = false;
            // 
            // lblBarkodPrinteri
            // 
            lblBarkodPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            lblBarkodPrinteri.Depth = 0;
            lblBarkodPrinteri.Dock = DockStyle.Fill;
            lblBarkodPrinteri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBarkodPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBarkodPrinteri.Location = new Point(3, 60);
            lblBarkodPrinteri.MouseState = MaterialSkin.MouseState.HOVER;
            lblBarkodPrinteri.Name = "lblBarkodPrinteri";
            lblBarkodPrinteri.Size = new Size(174, 60);
            lblBarkodPrinteri.TabIndex = 2;
            lblBarkodPrinteri.Text = "Barkod Printeri";
            lblBarkodPrinteri.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBarkodPrinter
            // 
            pnlBarkodPrinter.BackColor = Color.FromArgb(242, 242, 242);
            pnlBarkodPrinter.Controls.Add(txtBarkodPrinteri);
            pnlBarkodPrinter.Controls.Add(btnBarkodPrinterSec);
            pnlBarkodPrinter.Dock = DockStyle.Fill;
            pnlBarkodPrinter.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlBarkodPrinter.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlBarkodPrinter.Location = new Point(180, 60);
            pnlBarkodPrinter.Margin = new Padding(0);
            pnlBarkodPrinter.Name = "pnlBarkodPrinter";
            pnlBarkodPrinter.Size = new Size(1026, 60);
            pnlBarkodPrinter.TabIndex = 3;
            // 
            // txtBarkodPrinteri
            // 
            txtBarkodPrinteri.AnimateReadOnly = true;
            txtBarkodPrinteri.BackColor = Color.FromArgb(242, 242, 242);
            txtBarkodPrinteri.BorderStyle = BorderStyle.None;
            txtBarkodPrinteri.Depth = 0;
            txtBarkodPrinteri.Dock = DockStyle.Fill;
            txtBarkodPrinteri.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkodPrinteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBarkodPrinteri.Hint = "Printer seçilməyib";
            txtBarkodPrinteri.LeadingIcon = null;
            txtBarkodPrinteri.Location = new Point(0, 0);
            txtBarkodPrinteri.MaxLength = 50;
            txtBarkodPrinteri.MouseState = MaterialSkin.MouseState.OUT;
            txtBarkodPrinteri.Multiline = false;
            txtBarkodPrinteri.Name = "txtBarkodPrinteri";
            txtBarkodPrinteri.ReadOnly = true;
            txtBarkodPrinteri.Size = new Size(914, 50);
            txtBarkodPrinteri.TabIndex = 0;
            txtBarkodPrinteri.Text = "";
            txtBarkodPrinteri.TrailingIcon = null;
            // 
            // btnBarkodPrinterSec
            // 
            btnBarkodPrinterSec.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBarkodPrinterSec.BackColor = Color.FromArgb(242, 242, 242);
            btnBarkodPrinterSec.Density = MaterialButton.MaterialButtonDensity.Default;
            btnBarkodPrinterSec.Depth = 0;
            btnBarkodPrinterSec.Dock = DockStyle.Right;
            btnBarkodPrinterSec.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBarkodPrinterSec.HighEmphasis = false;
            btnBarkodPrinterSec.Icon = null;
            btnBarkodPrinterSec.Location = new Point(914, 0);
            btnBarkodPrinterSec.Margin = new Padding(4, 6, 4, 6);
            btnBarkodPrinterSec.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodPrinterSec.Name = "btnBarkodPrinterSec";
            btnBarkodPrinterSec.NoAccentTextColor = Color.Empty;
            btnBarkodPrinterSec.Size = new Size(112, 60);
            btnBarkodPrinterSec.TabIndex = 1;
            btnBarkodPrinterSec.Text = "Printer Seç";
            btnBarkodPrinterSec.Type = MaterialButton.MaterialButtonType.Outlined;
            btnBarkodPrinterSec.UseAccentColor = false;
            btnBarkodPrinterSec.UseVisualStyleBackColor = false;
            // 
            // lblKagizOlcusu
            // 
            lblKagizOlcusu.BackColor = Color.FromArgb(242, 242, 242);
            lblKagizOlcusu.Depth = 0;
            lblKagizOlcusu.Dock = DockStyle.Fill;
            lblKagizOlcusu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKagizOlcusu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKagizOlcusu.Location = new Point(3, 120);
            lblKagizOlcusu.MouseState = MaterialSkin.MouseState.HOVER;
            lblKagizOlcusu.Name = "lblKagizOlcusu";
            lblKagizOlcusu.Size = new Size(174, 60);
            lblKagizOlcusu.TabIndex = 4;
            lblKagizOlcusu.Text = "Kağız Ölçüsü";
            lblKagizOlcusu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbKagizOlcusu
            // 
            cmbKagizOlcusu.AutoResize = false;
            cmbKagizOlcusu.BackColor = Color.FromArgb(242, 242, 242);
            cmbKagizOlcusu.Depth = 0;
            cmbKagizOlcusu.DrawMode = DrawMode.OwnerDrawVariable;
            cmbKagizOlcusu.DropDownHeight = 174;
            cmbKagizOlcusu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKagizOlcusu.DropDownWidth = 121;
            cmbKagizOlcusu.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbKagizOlcusu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbKagizOlcusu.FormattingEnabled = true;
            cmbKagizOlcusu.Hint = "Kağız ölçüsü seçin";
            cmbKagizOlcusu.IntegralHeight = false;
            cmbKagizOlcusu.ItemHeight = 43;
            cmbKagizOlcusu.Location = new Point(183, 123);
            cmbKagizOlcusu.MaxDropDownItems = 4;
            cmbKagizOlcusu.MouseState = MaterialSkin.MouseState.OUT;
            cmbKagizOlcusu.Name = "cmbKagizOlcusu";
            cmbKagizOlcusu.Size = new Size(300, 49);
            cmbKagizOlcusu.StartIndex = 0;
            cmbKagizOlcusu.TabIndex = 5;
            // 
            // tabDavranis
            // 
            tabDavranis.BackColor = Color.FromArgb(242, 242, 242);
            tabDavranis.Controls.Add(tblDavranis);
            tabDavranis.Location = new Point(4, 26);
            tabDavranis.Name = "tabDavranis";
            tabDavranis.Padding = new Padding(15);
            tabDavranis.Size = new Size(1236, 521);
            tabDavranis.TabIndex = 3;
            tabDavranis.Text = "Proqram Davranışı";
            // 
            // tblDavranis
            // 
            tblDavranis.BackColor = Color.FromArgb(242, 242, 242);
            tblDavranis.ColumnCount = 2;
            tblDavranis.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tblDavranis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDavranis.Controls.Add(chkQebzAvtoCap, 1, 0);
            tblDavranis.Controls.Add(chkAvtomatikYedekleme, 1, 1);
            tblDavranis.Controls.Add(lblYedeklemeSaati, 0, 2);
            tblDavranis.Controls.Add(txtYedeklemeSaati, 1, 2);
            tblDavranis.Dock = DockStyle.Fill;
            tblDavranis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tblDavranis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tblDavranis.Location = new Point(15, 15);
            tblDavranis.Name = "tblDavranis";
            tblDavranis.RowCount = 4;
            tblDavranis.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblDavranis.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblDavranis.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblDavranis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDavranis.Size = new Size(1206, 491);
            tblDavranis.TabIndex = 0;
            // 
            // chkQebzAvtoCap
            // 
            chkQebzAvtoCap.AutoSize = true;
            chkQebzAvtoCap.BackColor = Color.FromArgb(242, 242, 242);
            chkQebzAvtoCap.Depth = 0;
            chkQebzAvtoCap.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkQebzAvtoCap.Location = new Point(180, 0);
            chkQebzAvtoCap.Margin = new Padding(0);
            chkQebzAvtoCap.MouseLocation = new Point(-1, -1);
            chkQebzAvtoCap.MouseState = MaterialSkin.MouseState.HOVER;
            chkQebzAvtoCap.Name = "chkQebzAvtoCap";
            chkQebzAvtoCap.ReadOnly = false;
            chkQebzAvtoCap.Ripple = true;
            chkQebzAvtoCap.Size = new Size(306, 37);
            chkQebzAvtoCap.TabIndex = 0;
            chkQebzAvtoCap.Text = "Satışdan sonra qəbzi avtomatik çap et";
            chkQebzAvtoCap.UseVisualStyleBackColor = false;
            // 
            // chkAvtomatikYedekleme
            // 
            chkAvtomatikYedekleme.AutoSize = true;
            chkAvtomatikYedekleme.BackColor = Color.FromArgb(242, 242, 242);
            chkAvtomatikYedekleme.Depth = 0;
            chkAvtomatikYedekleme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkAvtomatikYedekleme.Location = new Point(180, 50);
            chkAvtomatikYedekleme.Margin = new Padding(0);
            chkAvtomatikYedekleme.MouseLocation = new Point(-1, -1);
            chkAvtomatikYedekleme.MouseState = MaterialSkin.MouseState.HOVER;
            chkAvtomatikYedekleme.Name = "chkAvtomatikYedekleme";
            chkAvtomatikYedekleme.ReadOnly = false;
            chkAvtomatikYedekleme.Ripple = true;
            chkAvtomatikYedekleme.Size = new Size(224, 37);
            chkAvtomatikYedekleme.TabIndex = 1;
            chkAvtomatikYedekleme.Text = "Avtomatik yedekləmə aktiv";
            chkAvtomatikYedekleme.UseVisualStyleBackColor = false;
            // 
            // lblYedeklemeSaati
            // 
            lblYedeklemeSaati.BackColor = Color.FromArgb(242, 242, 242);
            lblYedeklemeSaati.Depth = 0;
            lblYedeklemeSaati.Dock = DockStyle.Fill;
            lblYedeklemeSaati.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblYedeklemeSaati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblYedeklemeSaati.Location = new Point(3, 100);
            lblYedeklemeSaati.MouseState = MaterialSkin.MouseState.HOVER;
            lblYedeklemeSaati.Name = "lblYedeklemeSaati";
            lblYedeklemeSaati.Size = new Size(174, 60);
            lblYedeklemeSaati.TabIndex = 2;
            lblYedeklemeSaati.Text = "Yedekləmə Saatı";
            lblYedeklemeSaati.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtYedeklemeSaati
            // 
            txtYedeklemeSaati.AnimateReadOnly = false;
            txtYedeklemeSaati.BackColor = Color.FromArgb(242, 242, 242);
            txtYedeklemeSaati.BorderStyle = BorderStyle.None;
            txtYedeklemeSaati.Depth = 0;
            txtYedeklemeSaati.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtYedeklemeSaati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtYedeklemeSaati.Hint = "HH:mm (məs: 02:00)";
            txtYedeklemeSaati.LeadingIcon = null;
            txtYedeklemeSaati.Location = new Point(183, 103);
            txtYedeklemeSaati.MaxLength = 5;
            txtYedeklemeSaati.MouseState = MaterialSkin.MouseState.OUT;
            txtYedeklemeSaati.Multiline = false;
            txtYedeklemeSaati.Name = "txtYedeklemeSaati";
            txtYedeklemeSaati.Size = new Size(150, 50);
            txtYedeklemeSaati.TabIndex = 3;
            txtYedeklemeSaati.Text = "";
            txtYedeklemeSaati.TrailingIcon = null;
            // 
            // tabSistem
            // 
            tabSistem.BackColor = Color.FromArgb(242, 242, 242);
            tabSistem.Controls.Add(tblSistem);
            tabSistem.Location = new Point(4, 26);
            tabSistem.Name = "tabSistem";
            tabSistem.Padding = new Padding(15);
            tabSistem.Size = new Size(1236, 521);
            tabSistem.TabIndex = 4;
            tabSistem.Text = "Sistem Parametrləri";
            // 
            // tblSistem
            // 
            tblSistem.BackColor = Color.FromArgb(242, 242, 242);
            tblSistem.ColumnCount = 2;
            tblSistem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tblSistem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblSistem.Controls.Add(lblDil, 0, 0);
            tblSistem.Controls.Add(cmbDil, 1, 0);
            tblSistem.Controls.Add(lblValyuta, 0, 1);
            tblSistem.Controls.Add(cmbValyuta, 1, 1);
            tblSistem.Controls.Add(lblTarixFormati, 0, 2);
            tblSistem.Controls.Add(txtTarixFormati, 1, 2);
            tblSistem.Controls.Add(lblReqemFormati, 0, 3);
            tblSistem.Controls.Add(txtReqemFormati, 1, 3);
            tblSistem.Controls.Add(lblTema, 0, 4);
            tblSistem.Controls.Add(cmbTema, 1, 4);
            tblSistem.Controls.Add(lblSessiyaTimeout, 0, 5);
            tblSistem.Controls.Add(nudSessiyaTimeout, 1, 5);
            tblSistem.Dock = DockStyle.Fill;
            tblSistem.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tblSistem.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tblSistem.Location = new Point(15, 15);
            tblSistem.Name = "tblSistem";
            tblSistem.RowCount = 7;
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblSistem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSistem.Size = new Size(1206, 491);
            tblSistem.TabIndex = 0;
            // 
            // lblDil
            // 
            lblDil.BackColor = Color.FromArgb(242, 242, 242);
            lblDil.Depth = 0;
            lblDil.Dock = DockStyle.Fill;
            lblDil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDil.Location = new Point(3, 0);
            lblDil.MouseState = MaterialSkin.MouseState.HOVER;
            lblDil.Name = "lblDil";
            lblDil.Size = new Size(174, 60);
            lblDil.TabIndex = 0;
            lblDil.Text = "Dil";
            lblDil.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbDil
            // 
            cmbDil.AutoResize = false;
            cmbDil.BackColor = Color.FromArgb(242, 242, 242);
            cmbDil.Depth = 0;
            cmbDil.DrawMode = DrawMode.OwnerDrawVariable;
            cmbDil.DropDownHeight = 174;
            cmbDil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDil.DropDownWidth = 121;
            cmbDil.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbDil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbDil.FormattingEnabled = true;
            cmbDil.Hint = "Dil seçin";
            cmbDil.IntegralHeight = false;
            cmbDil.ItemHeight = 43;
            cmbDil.Location = new Point(183, 3);
            cmbDil.MaxDropDownItems = 4;
            cmbDil.MouseState = MaterialSkin.MouseState.OUT;
            cmbDil.Name = "cmbDil";
            cmbDil.Size = new Size(300, 49);
            cmbDil.StartIndex = 0;
            cmbDil.TabIndex = 1;
            // 
            // lblValyuta
            // 
            lblValyuta.BackColor = Color.FromArgb(242, 242, 242);
            lblValyuta.Depth = 0;
            lblValyuta.Dock = DockStyle.Fill;
            lblValyuta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblValyuta.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblValyuta.Location = new Point(3, 60);
            lblValyuta.MouseState = MaterialSkin.MouseState.HOVER;
            lblValyuta.Name = "lblValyuta";
            lblValyuta.Size = new Size(174, 60);
            lblValyuta.TabIndex = 2;
            lblValyuta.Text = "Valyuta";
            lblValyuta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbValyuta
            // 
            cmbValyuta.AutoResize = false;
            cmbValyuta.BackColor = Color.FromArgb(242, 242, 242);
            cmbValyuta.Depth = 0;
            cmbValyuta.DrawMode = DrawMode.OwnerDrawVariable;
            cmbValyuta.DropDownHeight = 174;
            cmbValyuta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbValyuta.DropDownWidth = 121;
            cmbValyuta.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbValyuta.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbValyuta.FormattingEnabled = true;
            cmbValyuta.Hint = "Valyuta seçin";
            cmbValyuta.IntegralHeight = false;
            cmbValyuta.ItemHeight = 43;
            cmbValyuta.Location = new Point(183, 63);
            cmbValyuta.MaxDropDownItems = 4;
            cmbValyuta.MouseState = MaterialSkin.MouseState.OUT;
            cmbValyuta.Name = "cmbValyuta";
            cmbValyuta.Size = new Size(200, 49);
            cmbValyuta.StartIndex = 0;
            cmbValyuta.TabIndex = 3;
            // 
            // lblTarixFormati
            // 
            lblTarixFormati.BackColor = Color.FromArgb(242, 242, 242);
            lblTarixFormati.Depth = 0;
            lblTarixFormati.Dock = DockStyle.Fill;
            lblTarixFormati.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTarixFormati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTarixFormati.Location = new Point(3, 120);
            lblTarixFormati.MouseState = MaterialSkin.MouseState.HOVER;
            lblTarixFormati.Name = "lblTarixFormati";
            lblTarixFormati.Size = new Size(174, 60);
            lblTarixFormati.TabIndex = 4;
            lblTarixFormati.Text = "Tarix Formatı";
            lblTarixFormati.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTarixFormati
            // 
            txtTarixFormati.AnimateReadOnly = false;
            txtTarixFormati.BackColor = Color.FromArgb(242, 242, 242);
            txtTarixFormati.BorderStyle = BorderStyle.None;
            txtTarixFormati.Depth = 0;
            txtTarixFormati.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTarixFormati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTarixFormati.Hint = "dd.MM.yyyy";
            txtTarixFormati.LeadingIcon = null;
            txtTarixFormati.Location = new Point(183, 123);
            txtTarixFormati.MaxLength = 20;
            txtTarixFormati.MouseState = MaterialSkin.MouseState.OUT;
            txtTarixFormati.Multiline = false;
            txtTarixFormati.Name = "txtTarixFormati";
            txtTarixFormati.Size = new Size(200, 50);
            txtTarixFormati.TabIndex = 5;
            txtTarixFormati.Text = "";
            txtTarixFormati.TrailingIcon = null;
            // 
            // lblReqemFormati
            // 
            lblReqemFormati.BackColor = Color.FromArgb(242, 242, 242);
            lblReqemFormati.Depth = 0;
            lblReqemFormati.Dock = DockStyle.Fill;
            lblReqemFormati.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblReqemFormati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblReqemFormati.Location = new Point(3, 180);
            lblReqemFormati.MouseState = MaterialSkin.MouseState.HOVER;
            lblReqemFormati.Name = "lblReqemFormati";
            lblReqemFormati.Size = new Size(174, 60);
            lblReqemFormati.TabIndex = 6;
            lblReqemFormati.Text = "Rəqəm Formatı";
            lblReqemFormati.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtReqemFormati
            // 
            txtReqemFormati.AnimateReadOnly = false;
            txtReqemFormati.BackColor = Color.FromArgb(242, 242, 242);
            txtReqemFormati.BorderStyle = BorderStyle.None;
            txtReqemFormati.Depth = 0;
            txtReqemFormati.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtReqemFormati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtReqemFormati.Hint = "N2";
            txtReqemFormati.LeadingIcon = null;
            txtReqemFormati.Location = new Point(183, 183);
            txtReqemFormati.MaxLength = 10;
            txtReqemFormati.MouseState = MaterialSkin.MouseState.OUT;
            txtReqemFormati.Multiline = false;
            txtReqemFormati.Name = "txtReqemFormati";
            txtReqemFormati.Size = new Size(150, 50);
            txtReqemFormati.TabIndex = 7;
            txtReqemFormati.Text = "";
            txtReqemFormati.TrailingIcon = null;
            // 
            // lblTema
            // 
            lblTema.BackColor = Color.FromArgb(242, 242, 242);
            lblTema.Depth = 0;
            lblTema.Dock = DockStyle.Fill;
            lblTema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTema.Location = new Point(3, 240);
            lblTema.MouseState = MaterialSkin.MouseState.HOVER;
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(174, 60);
            lblTema.TabIndex = 8;
            lblTema.Text = "Tema";
            lblTema.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTema
            // 
            cmbTema.AutoResize = false;
            cmbTema.BackColor = Color.FromArgb(242, 242, 242);
            cmbTema.Depth = 0;
            cmbTema.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTema.DropDownHeight = 174;
            cmbTema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTema.DropDownWidth = 121;
            cmbTema.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTema.FormattingEnabled = true;
            cmbTema.Hint = "Tema seçin";
            cmbTema.IntegralHeight = false;
            cmbTema.ItemHeight = 43;
            cmbTema.Location = new Point(183, 243);
            cmbTema.MaxDropDownItems = 4;
            cmbTema.MouseState = MaterialSkin.MouseState.OUT;
            cmbTema.Name = "cmbTema";
            cmbTema.Size = new Size(200, 49);
            cmbTema.StartIndex = 0;
            cmbTema.TabIndex = 9;
            // 
            // lblSessiyaTimeout
            // 
            lblSessiyaTimeout.BackColor = Color.FromArgb(242, 242, 242);
            lblSessiyaTimeout.Depth = 0;
            lblSessiyaTimeout.Dock = DockStyle.Fill;
            lblSessiyaTimeout.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSessiyaTimeout.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSessiyaTimeout.Location = new Point(3, 300);
            lblSessiyaTimeout.MouseState = MaterialSkin.MouseState.HOVER;
            lblSessiyaTimeout.Name = "lblSessiyaTimeout";
            lblSessiyaTimeout.Size = new Size(174, 60);
            lblSessiyaTimeout.TabIndex = 10;
            lblSessiyaTimeout.Text = "Sessiya Timeout (dəqiqə)";
            lblSessiyaTimeout.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudSessiyaTimeout
            // 
            nudSessiyaTimeout.BackColor = Color.FromArgb(242, 242, 242);
            nudSessiyaTimeout.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            nudSessiyaTimeout.ForeColor = Color.FromArgb(222, 0, 0, 0);
            nudSessiyaTimeout.Location = new Point(183, 303);
            nudSessiyaTimeout.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            nudSessiyaTimeout.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudSessiyaTimeout.Name = "nudSessiyaTimeout";
            nudSessiyaTimeout.Size = new Size(150, 24);
            nudSessiyaTimeout.TabIndex = 11;
            nudSessiyaTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(242, 242, 242);
            pnlButtons.Controls.Add(btnLegvEt);
            pnlButtons.Controls.Add(btnSaxla);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlButtons.Location = new Point(3, 575);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(10);
            pnlButtons.Size = new Size(1244, 60);
            pnlButtons.TabIndex = 1;
            // 
            // btnLegvEt
            // 
            btnLegvEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLegvEt.BackColor = Color.FromArgb(242, 242, 242);
            btnLegvEt.Density = MaterialButton.MaterialButtonDensity.Default;
            btnLegvEt.Depth = 0;
            btnLegvEt.Dock = DockStyle.Right;
            btnLegvEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnLegvEt.HighEmphasis = false;
            btnLegvEt.Icon = null;
            btnLegvEt.Location = new Point(1036, 10);
            btnLegvEt.Margin = new Padding(4, 6, 4, 6);
            btnLegvEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnLegvEt.Name = "btnLegvEt";
            btnLegvEt.NoAccentTextColor = Color.Empty;
            btnLegvEt.Size = new Size(80, 40);
            btnLegvEt.TabIndex = 1;
            btnLegvEt.Text = "Ləğv Et";
            btnLegvEt.Type = MaterialButton.MaterialButtonType.Text;
            btnLegvEt.UseAccentColor = false;
            btnLegvEt.UseVisualStyleBackColor = false;
            // 
            // btnSaxla
            // 
            btnSaxla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaxla.BackColor = Color.FromArgb(242, 242, 242);
            btnSaxla.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSaxla.Depth = 0;
            btnSaxla.Dock = DockStyle.Right;
            btnSaxla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSaxla.HighEmphasis = true;
            btnSaxla.Icon = null;
            btnSaxla.Location = new Point(1116, 10);
            btnSaxla.Margin = new Padding(4, 6, 4, 6);
            btnSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaxla.Name = "btnSaxla";
            btnSaxla.NoAccentTextColor = Color.Empty;
            btnSaxla.Size = new Size(118, 40);
            btnSaxla.TabIndex = 0;
            btnSaxla.Text = "Yadda Saxla";
            btnSaxla.Type = MaterialButton.MaterialButtonType.Contained;
            btnSaxla.UseAccentColor = true;
            btnSaxla.UseVisualStyleBackColor = false;
            // 
            // KonfiqurasiyaFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 660);
            Controls.Add(tabControl);
            Controls.Add(pnlButtons);
            FormStyle = FormStyles.ActionBar_None;
            Name = "KonfiqurasiyaFormu";
            Padding = new Padding(3, 24, 3, 3);
            Text = "Tənzimləmələr";
            Controls.SetChildIndex(pnlButtons, 0);
            Controls.SetChildIndex(tabControl, 0);
            tabControl.ResumeLayout(false);
            tabSirket.ResumeLayout(false);
            tblSirket.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tabVergi.ResumeLayout(false);
            tblVergi.ResumeLayout(false);
            tblVergi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdvDerecesi).EndInit();
            tabPrinter.ResumeLayout(false);
            tblPrinter.ResumeLayout(false);
            pnlQebzPrinter.ResumeLayout(false);
            pnlQebzPrinter.PerformLayout();
            pnlBarkodPrinter.ResumeLayout(false);
            pnlBarkodPrinter.PerformLayout();
            tabDavranis.ResumeLayout(false);
            tblDavranis.ResumeLayout(false);
            tblDavranis.PerformLayout();
            tabSistem.ResumeLayout(false);
            tblSistem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSessiyaTimeout).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Tab Control
        private MaterialTabControl tabControl;
        private TabPage tabSirket;
        private TabPage tabVergi;
        private TabPage tabPrinter;
        private TabPage tabDavranis;
        private TabPage tabSistem;

        // Şirkət tab
        private TableLayoutPanel tblSirket;
        private MaterialLabel lblSirketAdi;
        private MaterialTextBox txtSirketAdi;
        private MaterialLabel lblSirketUnvani;
        private MaterialTextBox txtSirketUnvani;
        private MaterialLabel lblSirketVoen;
        private MaterialTextBox txtSirketVoen;
        private MaterialLabel lblSirketTelefon;
        private MaterialTextBox txtSirketTelefon;
        private MaterialLabel lblSirketEmail;
        private MaterialTextBox txtSirketEmail;
        private MaterialLabel lblSirketVebSayt;
        private MaterialTextBox txtSirketVebSayt;
        private MaterialLabel lblSirketLogo;
        private Panel pnlLogo;
        private PictureBox picLogo;
        private MaterialButton btnLogoSec;

        // Vergi tab
        private TableLayoutPanel tblVergi;
        private MaterialLabel lblEdvDerecesi;
        private NumericUpDown nudEdvDerecesi;
        private MaterialLabel lblEdvInfo;

        // Printer tab
        private TableLayoutPanel tblPrinter;
        private MaterialLabel lblQebzPrinteri;
        private Panel pnlQebzPrinter;
        private MaterialTextBox txtQebzPrinteri;
        private MaterialButton btnQebzPrinterSec;
        private MaterialLabel lblBarkodPrinteri;
        private Panel pnlBarkodPrinter;
        private MaterialTextBox txtBarkodPrinteri;
        private MaterialButton btnBarkodPrinterSec;
        private MaterialLabel lblKagizOlcusu;
        private MaterialComboBox cmbKagizOlcusu;

        // Davranış tab
        private TableLayoutPanel tblDavranis;
        private MaterialCheckbox chkQebzAvtoCap;
        private MaterialCheckbox chkAvtomatikYedekleme;
        private MaterialLabel lblYedeklemeSaati;
        private MaterialTextBox txtYedeklemeSaati;

        // Sistem tab
        private TableLayoutPanel tblSistem;
        private MaterialLabel lblDil;
        private MaterialComboBox cmbDil;
        private MaterialLabel lblValyuta;
        private MaterialComboBox cmbValyuta;
        private MaterialLabel lblTarixFormati;
        private MaterialTextBox txtTarixFormati;
        private MaterialLabel lblReqemFormati;
        private MaterialTextBox txtReqemFormati;
        private MaterialLabel lblTema;
        private MaterialComboBox cmbTema;
        private MaterialLabel lblSessiyaTimeout;
        private NumericUpDown nudSessiyaTimeout;

        // Action buttons
        private Panel pnlButtons;
        private MaterialButton btnSaxla;
        private MaterialButton btnLegvEt;
    }
}
