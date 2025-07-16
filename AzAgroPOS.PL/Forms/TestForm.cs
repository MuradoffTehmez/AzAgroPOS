using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Test Form";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            var label = new Label
            {
                Text = "Test Form - Forms are working!",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(300, 50)
            };
            
            var button = new Button
            {
                Text = "Close",
                Location = new System.Drawing.Point(150, 150),
                Size = new System.Drawing.Size(100, 30)
            };
            button.Click += (s, e) => this.Close();
            
            this.Controls.Add(label);
            this.Controls.Add(button);
        }
    }
}