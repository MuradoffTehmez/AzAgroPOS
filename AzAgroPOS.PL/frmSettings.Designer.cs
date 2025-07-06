namespace AzAgroPOS.PL
{
    partial class frmSettings
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
            this.rbLightTheme = new System.Windows.Forms.RadioButton();
            this.rbDarkTheme = new System.Windows.Forms.RadioButton();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbLightTheme
            // 
            this.rbLightTheme.AutoSize = true;
            this.rbLightTheme.Location = new System.Drawing.Point(16, 46);
            this.rbLightTheme.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbLightTheme.Name = "rbLightTheme";
            this.rbLightTheme.Size = new System.Drawing.Size(141, 29);
            this.rbLightTheme.TabIndex = 0;
            this.rbLightTheme.TabStop = true;
            this.rbLightTheme.Text = "Açıq Tema";
            this.rbLightTheme.UseVisualStyleBackColor = true;
            // 
            // rbDarkTheme
            // 
            this.rbDarkTheme.AutoSize = true;
            this.rbDarkTheme.Location = new System.Drawing.Point(16, 104);
            this.rbDarkTheme.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.rbDarkTheme.Name = "rbDarkTheme";
            this.rbDarkTheme.Size = new System.Drawing.Size(184, 29);
            this.rbDarkTheme.TabIndex = 1;
            this.rbDarkTheme.TabStop = true;
            this.rbDarkTheme.Text = "Qaranlıq Tema";
            this.rbDarkTheme.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.White;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Location = new System.Drawing.Point(25, 158);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(164, 50);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Yadda Saxla";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click_1);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(227, 243);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.rbDarkTheme);
            this.Controls.Add(this.rbLightTheme);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbLightTheme;
        private System.Windows.Forms.RadioButton rbDarkTheme;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}