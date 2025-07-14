namespace AzAgroPOS.PL.Forms
{
    partial class TamirStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotesLabel = new System.Windows.Forms.Label();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.lblNewStatusLabel = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatusLabel = new System.Windows.Forms.Label();
            this.lblRepairInfo = new System.Windows.Forms.Label();
            this.lblRepairInfoLabel = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Status Dəyişdir";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtNotes);
            this.panel2.Controls.Add(this.lblNotesLabel);
            this.panel2.Controls.Add(this.cmbNewStatus);
            this.panel2.Controls.Add(this.lblNewStatusLabel);
            this.panel2.Controls.Add(this.lblCurrentStatus);
            this.panel2.Controls.Add(this.lblCurrentStatusLabel);
            this.panel2.Controls.Add(this.lblRepairInfo);
            this.panel2.Controls.Add(this.lblRepairInfoLabel);
            this.panel2.Controls.Add(this.lblFormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(500, 290);
            this.panel2.TabIndex = 1;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(30, 200);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            //this.txtNotes.PlaceholderText = "Status dəyişikliyi haqqında əlavə qeydlər...";
            this.txtNotes.Size = new System.Drawing.Size(440, 60);
            this.txtNotes.TabIndex = 8;
            // 
            // lblNotesLabel
            // 
            this.lblNotesLabel.AutoSize = true;
            this.lblNotesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNotesLabel.Location = new System.Drawing.Point(30, 175);
            this.lblNotesLabel.Name = "lblNotesLabel";
            this.lblNotesLabel.Size = new System.Drawing.Size(62, 19);
            this.lblNotesLabel.TabIndex = 7;
            this.lblNotesLabel.Text = "Qeydlər:";
            // 
            // cmbNewStatus
            // 
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNewStatus.FormattingEnabled = true;
            this.cmbNewStatus.Location = new System.Drawing.Point(150, 130);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(200, 25);
            this.cmbNewStatus.TabIndex = 6;
            // 
            // lblNewStatusLabel
            // 
            this.lblNewStatusLabel.AutoSize = true;
            this.lblNewStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNewStatusLabel.Location = new System.Drawing.Point(30, 130);
            this.lblNewStatusLabel.Name = "lblNewStatusLabel";
            this.lblNewStatusLabel.Size = new System.Drawing.Size(84, 19);
            this.lblNewStatusLabel.TabIndex = 5;
            this.lblNewStatusLabel.Text = "Yeni Status:";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblCurrentStatus.Location = new System.Drawing.Point(150, 100);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(15, 19);
            this.lblCurrentStatus.TabIndex = 4;
            this.lblCurrentStatus.Text = "-";
            // 
            // lblCurrentStatusLabel
            // 
            this.lblCurrentStatusLabel.AutoSize = true;
            this.lblCurrentStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCurrentStatusLabel.Location = new System.Drawing.Point(30, 100);
            this.lblCurrentStatusLabel.Name = "lblCurrentStatusLabel";
            this.lblCurrentStatusLabel.Size = new System.Drawing.Size(106, 19);
            this.lblCurrentStatusLabel.TabIndex = 3;
            this.lblCurrentStatusLabel.Text = "Hazırkı Status:";
            // 
            // lblRepairInfo
            // 
            this.lblRepairInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepairInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblRepairInfo.Location = new System.Drawing.Point(150, 70);
            this.lblRepairInfo.Name = "lblRepairInfo";
            this.lblRepairInfo.Size = new System.Drawing.Size(320, 19);
            this.lblRepairInfo.TabIndex = 2;
            this.lblRepairInfo.Text = "-";
            // 
            // lblRepairInfoLabel
            // 
            this.lblRepairInfoLabel.AutoSize = true;
            this.lblRepairInfoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepairInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRepairInfoLabel.Location = new System.Drawing.Point(30, 70);
            this.lblRepairInfoLabel.Name = "lblRepairInfoLabel";
            this.lblRepairInfoLabel.Size = new System.Drawing.Size(49, 19);
            this.lblRepairInfoLabel.TabIndex = 1;
            this.lblRepairInfoLabel.Text = "Təmir:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFormTitle.Location = new System.Drawing.Point(25, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(224, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Status Yeniləməsi";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 70);
            this.panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(320, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TamirStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TamirStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status Dəyişdir";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblRepairInfoLabel;
        private System.Windows.Forms.Label lblRepairInfo;
        private System.Windows.Forms.Label lblCurrentStatusLabel;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Label lblNewStatusLabel;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotesLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}