namespace AzAgroPOS.PL.Forms
{
    partial class MusteriGroupManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnClose;

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
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // btnAddGroup
            this.btnAddGroup.Location = new System.Drawing.Point(100, 200);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "Qrup Əlavə Et";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(200, 200);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Bağla";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // MusteriGroupManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddGroup);
            this.Name = "MusteriGroupManagementForm";
            this.Text = "Müştəri Qruplarının İdarə Edilməsi";
            this.ResumeLayout(false);
        }
    }
}