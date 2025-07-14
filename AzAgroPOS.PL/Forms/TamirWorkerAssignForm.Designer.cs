namespace AzAgroPOS.PL.Forms
{
    partial class TamirWorkerAssignForm
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
            this.cmbWorker = new System.Windows.Forms.ComboBox();
            this.lblNewWorkerLabel = new System.Windows.Forms.Label();
            this.lblCurrentWorker = new System.Windows.Forms.Label();
            this.lblCurrentWorkerLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblPriorityLabel = new System.Windows.Forms.Label();
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "İşçi Təyinatı";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtNotes);
            this.panel2.Controls.Add(this.lblNotesLabel);
            this.panel2.Controls.Add(this.cmbWorker);
            this.panel2.Controls.Add(this.lblNewWorkerLabel);
            this.panel2.Controls.Add(this.lblCurrentWorker);
            this.panel2.Controls.Add(this.lblCurrentWorkerLabel);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblStatusLabel);
            this.panel2.Controls.Add(this.lblPriority);
            this.panel2.Controls.Add(this.lblPriorityLabel);
            this.panel2.Controls.Add(this.lblRepairInfo);
            this.panel2.Controls.Add(this.lblRepairInfoLabel);
            this.panel2.Controls.Add(this.lblFormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(550, 340);
            this.panel2.TabIndex = 1;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(30, 250);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            //this.txtNotes.PlaceholderText = "İşçi təyinatı haqqında əlavə qeydlər...";
            this.txtNotes.Size = new System.Drawing.Size(490, 60);
            this.txtNotes.TabIndex = 12;
            // 
            // lblNotesLabel
            // 
            this.lblNotesLabel.AutoSize = true;
            this.lblNotesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNotesLabel.Location = new System.Drawing.Point(30, 225);
            this.lblNotesLabel.Name = "lblNotesLabel";
            this.lblNotesLabel.Size = new System.Drawing.Size(62, 19);
            this.lblNotesLabel.TabIndex = 11;
            this.lblNotesLabel.Text = "Qeydlər:";
            // 
            // cmbWorker
            // 
            this.cmbWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbWorker.FormattingEnabled = true;
            this.cmbWorker.Location = new System.Drawing.Point(170, 180);
            this.cmbWorker.Name = "cmbWorker";
            this.cmbWorker.Size = new System.Drawing.Size(350, 25);
            this.cmbWorker.TabIndex = 10;
            // 
            // lblNewWorkerLabel
            // 
            this.lblNewWorkerLabel.AutoSize = true;
            this.lblNewWorkerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewWorkerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNewWorkerLabel.Location = new System.Drawing.Point(30, 180);
            this.lblNewWorkerLabel.Name = "lblNewWorkerLabel";
            this.lblNewWorkerLabel.Size = new System.Drawing.Size(72, 19);
            this.lblNewWorkerLabel.TabIndex = 9;
            this.lblNewWorkerLabel.Text = "Yeni İşçi:";
            // 
            // lblCurrentWorker
            // 
            this.lblCurrentWorker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblCurrentWorker.Location = new System.Drawing.Point(170, 150);
            this.lblCurrentWorker.Name = "lblCurrentWorker";
            this.lblCurrentWorker.Size = new System.Drawing.Size(350, 19);
            this.lblCurrentWorker.TabIndex = 8;
            this.lblCurrentWorker.Text = "-";
            // 
            // lblCurrentWorkerLabel
            // 
            this.lblCurrentWorkerLabel.AutoSize = true;
            this.lblCurrentWorkerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentWorkerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCurrentWorkerLabel.Location = new System.Drawing.Point(30, 150);
            this.lblCurrentWorkerLabel.Name = "lblCurrentWorkerLabel";
            this.lblCurrentWorkerLabel.Size = new System.Drawing.Size(102, 19);
            this.lblCurrentWorkerLabel.TabIndex = 7;
            this.lblCurrentWorkerLabel.Text = "Hazırkı İşçi:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(170, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(15, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "-";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(30, 120);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(53, 19);
            this.lblStatusLabel.TabIndex = 5;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriority.Location = new System.Drawing.Point(170, 90);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(15, 19);
            this.lblPriority.TabIndex = 4;
            this.lblPriority.Text = "-";
            // 
            // lblPriorityLabel
            // 
            this.lblPriorityLabel.AutoSize = true;
            this.lblPriorityLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPriorityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPriorityLabel.Location = new System.Drawing.Point(30, 90);
            this.lblPriorityLabel.Name = "lblPriorityLabel";
            this.lblPriorityLabel.Size = new System.Drawing.Size(71, 19);
            this.lblPriorityLabel.TabIndex = 3;
            this.lblPriorityLabel.Text = "Prioritet:";
            // 
            // lblRepairInfo
            // 
            this.lblRepairInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepairInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblRepairInfo.Location = new System.Drawing.Point(170, 60);
            this.lblRepairInfo.Name = "lblRepairInfo";
            this.lblRepairInfo.Size = new System.Drawing.Size(350, 19);
            this.lblRepairInfo.TabIndex = 2;
            this.lblRepairInfo.Text = "-";
            // 
            // lblRepairInfoLabel
            // 
            this.lblRepairInfoLabel.AutoSize = true;
            this.lblRepairInfoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepairInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRepairInfoLabel.Location = new System.Drawing.Point(30, 60);
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
            this.lblFormTitle.Size = new System.Drawing.Size(180, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "İşçi Təyinatı";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 330);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 70);
            this.panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(370, 15);
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
            this.btnSave.Location = new System.Drawing.Point(200, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Təyin Et";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TamirWorkerAssignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TamirWorkerAssignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İşçi Təyinatı";
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
        private System.Windows.Forms.Label lblPriorityLabel;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentWorkerLabel;
        private System.Windows.Forms.Label lblCurrentWorker;
        private System.Windows.Forms.ComboBox cmbWorker;
        private System.Windows.Forms.Label lblNewWorkerLabel;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotesLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}