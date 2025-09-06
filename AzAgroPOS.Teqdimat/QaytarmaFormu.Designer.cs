namespace AzAgroPOS.Teqdimat
{
    partial class QaytarmaFormu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new MaterialSkin.Controls.MaterialCard();
            this.dgvSatisMehsullari = new System.Windows.Forms.DataGridView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtSatisNomresi = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnAxtar = new MaterialSkin.Controls.MaterialButton();
            this.btnQaytar = new MaterialSkin.Controls.MaterialButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatisMehsullari)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMain.Controls.Add(this.dgvSatisMehsullari);
            this.pnlMain.Controls.Add(this.materialLabel1);
            this.pnlMain.Controls.Add(this.txtSatisNomresi);
            this.pnlMain.Controls.Add(this.btnAxtar);
            this.pnlMain.Controls.Add(this.btnQaytar);
            this.pnlMain.Depth = 0;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMain.Location = new System.Drawing.Point(3, 64);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(14);
            this.pnlMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(14);
            this.pnlMain.Size = new System.Drawing.Size(1170, 637);
            this.pnlMain.TabIndex = 0;
            // 
            // dgvSatisMehsullari
            // 
            this.dgvSatisMehsullari.AllowUserToAddRows = false;
            this.dgvSatisMehsullari.AllowUserToDeleteRows = false;
            this.dgvSatisMehsullari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSatisMehsullari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSatisMehsullari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSatisMehsullari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSatisMehsullari.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSatisMehsullari.Location = new System.Drawing.Point(17, 106);
            this.dgvSatisMehsullari.MultiSelect = false;
            this.dgvSatisMehsullari.Name = "dgvSatisMehsullari";
            this.dgvSatisMehsullari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatisMehsullari.Size = new System.Drawing.Size(1136, 467);
            this.dgvSatisMehsullari.TabIndex = 4;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 15);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(106, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Satış Nömrəsi:";
            // 
            // txtSatisNomresi
            // 
            this.txtSatisNomresi.AnimateReadOnly = false;
            this.txtSatisNomresi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSatisNomresi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSatisNomresi.Depth = 0;
            this.txtSatisNomresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSatisNomresi.HideSelection = true;
            this.txtSatisNomresi.LeadingIcon = null;
            this.txtSatisNomresi.Location = new System.Drawing.Point(17, 37);
            this.txtSatisNomresi.MaxLength = 32767;
            this.txtSatisNomresi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSatisNomresi.Name = "txtSatisNomresi";
            this.txtSatisNomresi.PasswordChar = '\0';
            this.txtSatisNomresi.PrefixSuffixText = null;
            this.txtSatisNomresi.ReadOnly = false;
            this.txtSatisNomresi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSatisNomresi.SelectedText = "";
            this.txtSatisNomresi.SelectionLength = 0;
            this.txtSatisNomresi.SelectionStart = 0;
            this.txtSatisNomresi.ShortcutsEnabled = true;
            this.txtSatisNomresi.Size = new System.Drawing.Size(250, 48);
            this.txtSatisNomresi.TabIndex = 2;
            this.txtSatisNomresi.TabStop = false;
            this.txtSatisNomresi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSatisNomresi.TrailingIcon = null;
            this.txtSatisNomresi.UseSystemPasswordChar = false;
            // 
            // btnAxtar
            // 
            this.btnAxtar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAxtar.Depth = 0;
            this.btnAxtar.HighEmphasis = true;
            this.btnAxtar.Icon = null;
            this.btnAxtar.Location = new System.Drawing.Point(280, 42);
            this.btnAxtar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAxtar.Name = "btnAxtar";
            this.btnAxtar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAxtar.Size = new System.Drawing.Size(77, 36);
            this.btnAxtar.TabIndex = 1;
            this.btnAxtar.Text = "Axtar";
            this.btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAxtar.UseAccentColor = false;
            this.btnAxtar.UseVisualStyleBackColor = true;
            this.btnAxtar.Click += new System.EventHandler(this.btnAxtar_Click);
            // 
            // btnQaytar
            // 
            this.btnQaytar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQaytar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQaytar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnQaytar.Depth = 0;
            this.btnQaytar.HighEmphasis = true;
            this.btnQaytar.Icon = null;
            this.btnQaytar.Location = new System.Drawing.Point(1060, 586);
            this.btnQaytar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnQaytar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQaytar.Name = "btnQaytar";
            this.btnQaytar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnQaytar.Size = new System.Drawing.Size(93, 36);
            this.btnQaytar.TabIndex = 0;
            this.btnQaytar.Text = "Qaytar";
            this.btnQaytar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnQaytar.UseAccentColor = false;
            this.btnQaytar.UseVisualStyleBackColor = true;
            this.btnQaytar.Click += new System.EventHandler(this.btnQaytar_Click);
            // 
            // QaytarmaFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 704);
            this.Controls.Add(this.pnlMain);
            this.Name = "QaytarmaFormu";
            this.Text = "Qaytarma";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatisMehsullari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard pnlMain;
        private MaterialSkin.Controls.MaterialButton btnQaytar;
        private MaterialSkin.Controls.MaterialButton btnAxtar;
        private MaterialSkin.Controls.MaterialTextBox2 txtSatisNomresi;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvSatisMehsullari;
    }
}