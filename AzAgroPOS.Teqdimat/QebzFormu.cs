using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class QebzFormu : Form
    {
        public QebzFormu()
        {
            InitializeComponent();
        }
        
        public void QebzMelumatlariniGoster(string basliq, Dictionary<string, string> melumatlar)
        {
            lblBasliq.Text = basliq;
            
            // Mevcud satırları təmizləyirik
            tblMelumatlar.Controls.Clear();
            tblMelumatlar.RowStyles.Clear();
            
            // Yeni məlumatları əlavə edirik
            int satir = 0;
            foreach (var melumat in melumatlar)
            {
                tblMelumatlar.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                
                var lblAcar = new Label();
                lblAcar.Text = melumat.Key + ":";
                lblAcar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                lblAcar.Dock = DockStyle.Fill;
                lblAcar.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblAcar, 0, satir);
                
                var lblDeyer = new Label();
                lblDeyer.Text = melumat.Value;
                lblDeyer.Font = new Font("Microsoft Sans Serif", 10F);
                lblDeyer.Dock = DockStyle.Fill;
                lblDeyer.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblDeyer, 1, satir);
                
                satir++;
            }
        }
        
        private void btnCapEt_Click(object sender, EventArgs e)
        {
            // Çap funksionallığını tətbiq edin
            MessageBox.Show("Çap funksionallığı hələ tətbiq edilməyib.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnBagla_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}