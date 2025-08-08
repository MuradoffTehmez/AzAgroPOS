// Fayl: AzAgroPOS.Teqdimat/NovbeIdareetmesiFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class NovbeIdareetmesiFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.cardNovbeAc = new MaterialSkin.Controls.MaterialCard();
            this.btnNovbeAc = new MaterialSkin.Controls.MaterialButton();
            this.txtBaslangicMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cardNovbeBagla = new MaterialSkin.Controls.MaterialCard();
            this.btnNovbeBagla = new MaterialSkin.Controls.MaterialButton();
            this.txtFaktikiMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblNovbeMelumat = new MaterialSkin.Controls.MaterialLabel();
            this.cardNovbeAc.SuspendLayout();
            this.cardNovbeBagla.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardNovbeAc
            // 
            this.cardNovbeAc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardNovbeAc.Controls.Add(this.btnNovbeAc);
            this.cardNovbeAc.Controls.Add(this.txtBaslangicMebleg);
            this.cardNovbeAc.Controls.Add(this.materialLabel1);
            this.cardNovbeAc.Depth = 0;
            this.cardNovbeAc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardNovbeAc.Location = new System.Drawing.Point(40, 90);
            this.cardNovbeAc.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardNovbeAc.Name = "cardNovbeAc";
            this.cardNovbeAc.Padding = new System.Windows.Forms.Padding(14);
            this.cardNovbeAc.Size = new System.Drawing.Size(600, 200);
            this.cardNovbeAc.TabIndex = 0;
            // 
            // btnNovbeAc
            // 
            this.btnNovbeAc.AutoSize = false; this.btnNovbeAc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default; this.btnNovbeAc.Depth = 0; this.btnNovbeAc.HighEmphasis = true;
            this.btnNovbeAc.Location = new System.Drawing.Point(200, 130); this.btnNovbeAc.MouseState = MaterialSkin.MouseState.HOVER; this.btnNovbeAc.Name = "btnNovbeAc"; this.btnNovbeAc.Size = new System.Drawing.Size(200, 45); this.btnNovbeAc.TabIndex = 2; this.btnNovbeAc.Text = "Növbəni Aç";
            this.btnNovbeAc.Click += new System.EventHandler(this.btnNovbeAc_Click);
            // 
            // txtBaslangicMebleg
            // 
            this.txtBaslangicMebleg.Hint = "Kassadakı ilkin məbləğ"; this.txtBaslangicMebleg.Location = new System.Drawing.Point(150, 60); this.txtBaslangicMebleg.Name = "txtBaslangicMebleg"; this.txtBaslangicMebleg.Size = new System.Drawing.Size(300, 48); this.txtBaslangicMebleg.TabIndex = 1; this.txtBaslangicMebleg.Text = "0";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true; this.materialLabel1.Depth = 0; this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel); this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(220, 14); this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER; this.materialLabel1.Name = "materialLabel1"; this.materialLabel1.Size = new System.Drawing.Size(164, 29); this.materialLabel1.TabIndex = 0; this.materialLabel1.Text = "Yeni Növbə Aç";
            // 
            // cardNovbeBagla
            // 
            this.cardNovbeBagla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardNovbeBagla.Controls.Add(this.btnNovbeBagla);
            this.cardNovbeBagla.Controls.Add(this.txtFaktikiMebleg);
            this.cardNovbeBagla.Controls.Add(this.lblNovbeMelumat);
            this.cardNovbeBagla.Depth = 0;
            this.cardNovbeBagla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardNovbeBagla.Location = new System.Drawing.Point(40, 90);
            this.cardNovbeBagla.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardNovbeBagla.Name = "cardNovbeBagla";
            this.cardNovbeBagla.Padding = new System.Windows.Forms.Padding(14);
            this.cardNovbeBagla.Size = new System.Drawing.Size(600, 200);
            this.cardNovbeBagla.TabIndex = 1;
            this.cardNovbeBagla.Visible = false;
            // 
            // btnNovbeBagla
            // 
            this.btnNovbeBagla.AutoSize = false; this.btnNovbeBagla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default; this.btnNovbeBagla.Depth = 0; this.btnNovbeBagla.HighEmphasis = true; this.btnNovbeBagla.Location = new System.Drawing.Point(175, 130); this.btnNovbeBagla.MouseState = MaterialSkin.MouseState.HOVER; this.btnNovbeBagla.Name = "btnNovbeBagla"; this.btnNovbeBagla.Size = new System.Drawing.Size(250, 45); this.btnNovbeBagla.TabIndex = 2; this.btnNovbeBagla.Text = "Növbəni Bağla və Hesabat al";
            this.btnNovbeBagla.Click += new System.EventHandler(this.btnNovbeBagla_Click);
            // 
            // txtFaktikiMebleg
            // 
            this.txtFaktikiMebleg.Hint = "Kassada sayılan yekun məbləğ"; this.txtFaktikiMebleg.Location = new System.Drawing.Point(150, 60); this.txtFaktikiMebleg.Name = "txtFaktikiMebleg"; this.txtFaktikiMebleg.Size = new System.Drawing.Size(300, 48); this.txtFaktikiMebleg.TabIndex = 1; this.txtFaktikiMebleg.Text = "0";
            // 
            // lblNovbeMelumat
            // 
            this.lblNovbeMelumat.AutoSize = true; this.lblNovbeMelumat.Depth = 0; this.lblNovbeMelumat.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNovbeMelumat.Location = new System.Drawing.Point(20, 20); this.lblNovbeMelumat.MouseState = MaterialSkin.MouseState.HOVER; this.lblNovbeMelumat.Name = "lblNovbeMelumat"; this.lblNovbeMelumat.Size = new System.Drawing.Size(1, 0); this.lblNovbeMelumat.TabIndex = 0;
            // 
            // NovbeIdareetmesiFormu
            // 
            this.ClientSize = new System.Drawing.Size(680, 350);
            this.Controls.Add(this.cardNovbeBagla);
            this.Controls.Add(this.cardNovbeAc);
            this.Name = "NovbeIdareetmesiFormu";
            this.Text = "Növbə İdarəetməsi";
            this.cardNovbeAc.ResumeLayout(false); this.cardNovbeAc.PerformLayout();
            this.cardNovbeBagla.ResumeLayout(false); this.cardNovbeBagla.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private MaterialSkin.Controls.MaterialCard cardNovbeAc;
        private MaterialSkin.Controls.MaterialButton btnNovbeAc;
        private MaterialSkin.Controls.MaterialTextBox2 txtBaslangicMebleg;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCard cardNovbeBagla;
        private MaterialSkin.Controls.MaterialButton btnNovbeBagla;
        private MaterialSkin.Controls.MaterialTextBox2 txtFaktikiMebleg;
        private MaterialSkin.Controls.MaterialLabel lblNovbeMelumat;
    }
}