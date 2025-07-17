using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label label;
        private Button button;
        private PictureBox pictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            label = new Label();
            button = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label.ForeColor = System.Drawing.Color.DarkBlue;
            label.Location = new System.Drawing.Point(50, 50);
            label.Name = "label";
            label.Size = new System.Drawing.Size(300, 50);
            label.TabIndex = 0;
            label.Text = "Test Form - Forms are working!";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button
            // 
            button.BackColor = System.Drawing.Color.White;
            button.Font = new System.Drawing.Font("Arial", 10F);
            button.Location = new System.Drawing.Point(150, 150);
            button.Name = "button";
            button.Size = new System.Drawing.Size(100, 30);
            button.TabIndex = 1;
            button.Text = "Close";
            button.UseVisualStyleBackColor = false;
            button.Click += button_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = (System.Drawing.Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new System.Drawing.Point(180, 103);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(32, 32);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // TestForm
            // 
            BackColor = System.Drawing.Color.LightGray;
            ClientSize = new System.Drawing.Size(400, 300);
            Controls.Add(label);
            Controls.Add(button);
            Controls.Add(pictureBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TestForm";
            Text = "Test Form";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}