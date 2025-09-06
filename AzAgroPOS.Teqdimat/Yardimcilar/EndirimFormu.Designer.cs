// EndirimFormu.Designer.cs
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
            components = new System.ComponentModel.Container();
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
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbSelectedItem);
            groupBox1.Controls.Add(rbCart);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(34, 139, 34);
            groupBox1.Location = new Point(15, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 75);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Endirim Əhatəsi";
            // 
            // rbSelectedItem
            // 
            rbSelectedItem.AutoSize = true;
            rbSelectedItem.Font = new Font("Segoe UI", 9F);
            rbSelectedItem.Location = new Point(10, 45);
            rbSelectedItem.Name = "rbSelectedItem";
            rbSelectedItem.Size = new Size(110, 19);
            rbSelectedItem.TabIndex = 0;
            rbSelectedItem.Text = "Seçilmiş Məhsul";
            rbSelectedItem.UseVisualStyleBackColor = true;
            rbSelectedItem.CheckedChanged += rbSelectedItem_CheckedChanged;
            // 
            // rbCart
            // 
            rbCart.AutoSize = true;
            rbCart.Checked = true;
            rbCart.Font = new Font("Segoe UI", 9F);
            rbCart.Location = new Point(10, 20);
            rbCart.Name = "rbCart";
            rbCart.Size = new Size(54, 19);
            rbCart.TabIndex = 1;
            rbCart.TabStop = true;
            rbCart.Text = "Səbət";
            rbCart.UseVisualStyleBackColor = true;
            rbCart.CheckedChanged += rbCart_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbFixedAmount);
            groupBox2.Controls.Add(rbPercentage);
            groupBox2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(34, 139, 34);
            groupBox2.Location = new Point(15, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 75);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Endirim Növü";
            // 
            // rbFixedAmount
            // 
            rbFixedAmount.AutoSize = true;
            rbFixedAmount.Font = new Font("Segoe UI", 9F);
            rbFixedAmount.Location = new Point(10, 45);
            rbFixedAmount.Name = "rbFixedAmount";
            rbFixedAmount.Size = new Size(94, 19);
            rbFixedAmount.TabIndex = 0;
            rbFixedAmount.Text = "Sabit Məbləğ";
            rbFixedAmount.UseVisualStyleBackColor = true;
            // 
            // rbPercentage
            // 
            rbPercentage.AutoSize = true;
            rbPercentage.Checked = true;
            rbPercentage.Font = new Font("Segoe UI", 9F);
            rbPercentage.Location = new Point(10, 20);
            rbPercentage.Name = "rbPercentage";
            rbPercentage.Size = new Size(66, 19);
            rbPercentage.TabIndex = 1;
            rbPercentage.TabStop = true;
            rbPercentage.Text = "Faiz (%)";
            rbPercentage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(34, 139, 34);
            label1.Location = new Point(15, 185);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Dəyər";
            // 
            // txtEndirimDeyer
            // 
            txtEndirimDeyer.BorderStyle = BorderStyle.FixedSingle;
            txtEndirimDeyer.Font = new Font("Segoe UI", 10F);
            txtEndirimDeyer.Location = new Point(83, 182);
            txtEndirimDeyer.Name = "txtEndirimDeyer";
            txtEndirimDeyer.Size = new Size(182, 25);
            txtEndirimDeyer.TabIndex = 2;
            // 
            // btnTətbiqEt
            // 
            btnTətbiqEt.BackColor = Color.FromArgb(46, 204, 113);
            btnTətbiqEt.FlatStyle = FlatStyle.Flat;
            btnTətbiqEt.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnTətbiqEt.ForeColor = Color.White;
            btnTətbiqEt.Location = new Point(15, 225);
            btnTətbiqEt.Name = "btnTətbiqEt";
            btnTətbiqEt.Size = new Size(120, 35);
            btnTətbiqEt.TabIndex = 1;
            btnTətbiqEt.Text = "✔ Tətbiq Et";
            btnTətbiqEt.UseVisualStyleBackColor = false;
            btnTətbiqEt.Click += btnTətbiqEt_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(145, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 35);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "✖ Ləğv Et";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EndirimFormu
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(280, 280);
            Controls.Add(btnCancel);
            Controls.Add(btnTətbiqEt);
            Controls.Add(txtEndirimDeyer);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EndirimFormu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "🟢 Endirim Tətbiqi";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ErrorProvider errorProvider1;
    }
}
