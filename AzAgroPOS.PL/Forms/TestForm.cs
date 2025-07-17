using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TestForm : BaseForm
    {
        public TestForm() : base()
        {
            InitializeComponent(); 
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}