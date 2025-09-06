namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    partial class EndirimFormu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSelectedItem = new System.Windows.Forms.RadioButton();
            this.rbCart = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFixedAmount = new System.Windows.Forms.RadioButton();
            this.rbPercentage = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndirimDeyer = new System.Windows.Forms.TextBox();
            this.btnTətbiqEt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSelectedItem);
            this.groupBox1.Controls.Add(this.rbCart);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(0, 128, 64);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 80);
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endirim Əhatəsi";
            // 
            // rbSelectedItem
            // 
            this.rbSelectedItem.AutoSize = true;
            this.rbSelectedItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbSelectedItem.Location = new System.Drawing.Point(12, 48);
            this.rbSelectedItem.Name = "rbSelectedItem";
            this.rbSelectedItem.Size = new System.Drawing.Size(118, 19);
            this.rbSelectedItem.Text = "Seçilmiş Məhsul";
            this.rbSelectedItem.UseVisualStyleBackColor = true;
            this.rbSelectedItem.CheckedChanged += new System.EventHandler(this.rbSelectedItem_CheckedChanged);
            // 
            // rbCart
            // 
            this.rbCart.AutoSize = true;
            this.rbCart.Checked = true;
            this.rbCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbCart.Location = new System.Drawing.Point(12, 23);
            this.rbCart.Name = "rbCart";
            this.rbCart.Size = new System.Drawing.Size(57, 19);
            this.rbCart.TabStop = true;
            this.rbCart.Text = "Səbət";
            this.rbCart.UseVisualStyleBackColor = true;
            this.rbCart.CheckedChanged += new System.EventHandler(this.rbCart_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFixedAmount);
            this.groupBox2.Controls.Add(this.rbPercentage);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(0, 128, 64);
            this.groupBox2.Location = new System.Drawing.Point(20, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 80);
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endirim Növü";
            // 
            // rbFixedAmount
            // 
            this.rbFixedAmount.AutoSize = true;
            this.rbFixedAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFixedAmount.Location = new System.Drawing.Point(12, 48);
            this.rbFixedAmount.Name = "rbFixedAmount";
            this.rbFixedAmount.Size = new System.Drawing.Size(96, 19);
            this.rbFixedAmount.Text = "Sabit Məbləğ";
            this.rbFixedAmount.UseVisualStyleBackColor = true;
            // 
            // rbPercentage
            // 
            this.rbPercentage.AutoSize = true;
            this.rbPercentage.Checked = true;
            this.rbPercentage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbPercentage.Location = new System.Drawing.Point(12, 23);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Size = new System.Drawing.Size(63, 19);
            this.rbPercentage.TabStop = true;
            this.rbPercentage.Text = "Faiz (%)";
            this.rbPercentage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(0, 128, 64);
            this.label1.Location = new System.Drawing.Point(20, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "Dəyər";
            // 
            // txtEndirimDeyer
            // 
            this.txtEndirimDeyer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndirimDeyer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEndirimDeyer.Location = new System.Drawing.Point(75, 202);
            this.txtEndirimDeyer.Name = "txtEndirimDeyer";
            this.txtEndirimDeyer.Size = new System.Drawing.Size(225, 25);
            // 
            // btnTətbiqEt
            // 
            this.btnTətbiqEt.BackColor = System.Drawing.Color.FromArgb(0, 158, 96);
            this.btnTətbiqEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTətbiqEt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnTətbiqEt.ForeColor = System.Drawing.Color.White;
            this.btnTətbiqEt.Location = new System.Drawing.Point(20, 245);
            this.btnTətbiqEt.Name = "btnTətbiqEt";
            this.btnTətbiqEt.Size = new System.Drawing.Size(130, 38);
            this.btnTətbiqEt.Text = "✔ Tətbiq Et";
            this.btnTətbiqEt.UseVisualStyleBackColor = false;
            this.btnTətbiqEt.Click += new System.EventHandler(this.btnTətbiqEt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(170, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 38);
            this.btnCancel.Text = "✖ Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EndirimFormu
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(330, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTətbiqEt);
            this.Controls.Add(this.txtEndirimDeyer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndirimFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🟢 Endirim Tətbiqi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSelectedItem;
        private System.Windows.Forms.RadioButton rbCart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFixedAmount;
        private System.Windows.Forms.RadioButton rbPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndirimDeyer;
        private System.Windows.Forms.Button btnTətbiqEt;
        private System.Windows.Forms.Button btnCancel;
    }
}
