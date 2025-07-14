namespace AzAgroPOS.PL.Forms
{
    partial class MusteriGroupManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.GroupBox grpGroupInfo;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.Button btnCancelGroup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.grpGroupInfo = new System.Windows.Forms.GroupBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnCancelGroup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.grpGroupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "👥 Müştəri Qruplarının İdarə Edilməsi";
            
            // panel2
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.btnAddGroup);
            this.panel2.Controls.Add(this.btnEditGroup);
            this.panel2.Controls.Add(this.btnDeleteGroup);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 60);
            this.panel2.TabIndex = 1;
            
            // btnAddGroup
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddGroup.Location = new System.Drawing.Point(20, 15);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(110, 30);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "➕ Qrup Əlavə Et";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            
            // btnEditGroup
            this.btnEditGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditGroup.ForeColor = System.Drawing.Color.White;
            this.btnEditGroup.Location = new System.Drawing.Point(140, 15);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(110, 30);
            this.btnEditGroup.TabIndex = 1;
            this.btnEditGroup.Text = "✏️ Qrup Redaktə Et";
            this.btnEditGroup.UseVisualStyleBackColor = false;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            
            // btnDeleteGroup
            this.btnDeleteGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGroup.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGroup.Location = new System.Drawing.Point(260, 15);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteGroup.TabIndex = 2;
            this.btnDeleteGroup.Text = "🗑️ Qrup Sil";
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            
            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(700, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✗ Bağla";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // dgvGroups
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(20, 80);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(480, 440);
            this.dgvGroups.TabIndex = 2;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.dgvGroups_SelectionChanged);
            
            // grpGroupInfo
            this.grpGroupInfo.BackColor = System.Drawing.Color.White;
            this.grpGroupInfo.Controls.Add(this.lblGroupName);
            this.grpGroupInfo.Controls.Add(this.txtGroupName);
            this.grpGroupInfo.Controls.Add(this.lblDescription);
            this.grpGroupInfo.Controls.Add(this.txtDescription);
            this.grpGroupInfo.Controls.Add(this.lblDiscount);
            this.grpGroupInfo.Controls.Add(this.nudDiscount);
            this.grpGroupInfo.Controls.Add(this.btnSaveGroup);
            this.grpGroupInfo.Controls.Add(this.btnCancelGroup);
            this.grpGroupInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpGroupInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpGroupInfo.Location = new System.Drawing.Point(520, 80);
            this.grpGroupInfo.Name = "grpGroupInfo";
            this.grpGroupInfo.Size = new System.Drawing.Size(260, 440);
            this.grpGroupInfo.TabIndex = 3;
            this.grpGroupInfo.TabStop = false;
            this.grpGroupInfo.Text = "📋 Qrup Məlumatları";
            this.grpGroupInfo.Visible = false;
            
            // lblGroupName
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGroupName.Location = new System.Drawing.Point(15, 40);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(70, 19);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Qrup Adı:";
            
            // txtGroupName
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGroupName.Location = new System.Drawing.Point(15, 65);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(230, 25);
            this.txtGroupName.TabIndex = 1;
            
            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(15, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 19);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Açıqlama:";
            
            // txtDescription
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(15, 135);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(230, 80);
            this.txtDescription.TabIndex = 3;
            
            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(15, 235);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(120, 19);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Endirim Faizi (%):";
            
            // nudDiscount
            this.nudDiscount.DecimalPlaces = 2;
            this.nudDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDiscount.Location = new System.Drawing.Point(15, 260);
            this.nudDiscount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(230, 25);
            this.nudDiscount.TabIndex = 5;
            
            // btnSaveGroup
            this.btnSaveGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveGroup.ForeColor = System.Drawing.Color.White;
            this.btnSaveGroup.Location = new System.Drawing.Point(15, 320);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(110, 30);
            this.btnSaveGroup.TabIndex = 6;
            this.btnSaveGroup.Text = "✓ Saxla";
            this.btnSaveGroup.UseVisualStyleBackColor = false;
            this.btnSaveGroup.Click += new System.EventHandler(this.btnSaveGroup_Click);
            
            // btnCancelGroup
            this.btnCancelGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelGroup.ForeColor = System.Drawing.Color.White;
            this.btnCancelGroup.Location = new System.Drawing.Point(135, 320);
            this.btnCancelGroup.Name = "btnCancelGroup";
            this.btnCancelGroup.Size = new System.Drawing.Size(110, 30);
            this.btnCancelGroup.TabIndex = 7;
            this.btnCancelGroup.Text = "✗ Ləğv Et";
            this.btnCancelGroup.UseVisualStyleBackColor = false;
            this.btnCancelGroup.Click += new System.EventHandler(this.btnCancelGroup_Click);
            
            // MusteriGroupManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.grpGroupInfo);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MusteriGroupManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müştəri Qruplarının İdarə Edilməsi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.grpGroupInfo.ResumeLayout(false);
            this.grpGroupInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
        }
    }
}