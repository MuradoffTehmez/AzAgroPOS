// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
using System;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;

namespace AzAgroPOS.Teqdimat
{
    public partial class AnaMenuFormu : BazaForm
    {
        public AnaMenuFormu()
        {
            InitializeComponent();
            this.Load += AnaMenuFormu_Load;

            // Formu MDI Konteynerinə çeviririk
            this.IsMdiContainer = true;
        }

        private void AnaMenuFormu_Load(object sender, EventArgs e)
        {
            IcazeleriYoxla();
        }

        private void UsaqFormuAc<T>() where T : Form, new()
        {
            var aciqForm = this.MdiChildren.FirstOrDefault(f => f is T);

            if (aciqForm != null)
            {
                aciqForm.BringToFront();
            }
            else
            {
                T yeniForm = new T
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                yeniForm.Show();
                this.LayoutMdi(MdiLayout.Cascade);
            }
        }

        private void IcazeleriYoxla()
        {
            var istifadeci = AktivSessiya.AktivIstifadeci;
            if (istifadeci == null)
            {
                MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı. Tətbiq bağlanır.", "Kritik Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }

            this.Text = $"AzAgroPOS - Ana Menyu (İstifadəçi: {istifadeci.TamAd})";
            btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;

            if (istifadeci.RolAdi == "Admin")
            {
                return;
            }

            if (istifadeci.RolAdi == "Kassir")
            {
                btnMehsulIdareetme.Enabled = false;
                btnNisyeIdareetme.Enabled = false;
                btnTemirIdareetme.Enabled = false;
                btnIstifadeciIdareetme.Enabled = false;
            }
            else
            {
                btnMehsulIdareetme.Enabled = false;
                btnYeniSatis.Enabled = false;
                btnNisyeIdareetme.Enabled = false;
                btnTemirIdareetme.Enabled = false;
                btnNovbeIdareetme.Enabled = false;
                btnIstifadeciIdareetme.Enabled = false;
            }
        }

        private void btnMehsulIdareetme_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<MehsulIdareetmeFormu>();
        }

        private void btnYeniSatis_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<SatisFormu>();
        }

        private void btnNisyeIdareetme_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<NisyeIdareetmeFormu>();
        }

        private void btnTemirIdareetme_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<TemirIdareetmeFormu>();
        }

        private void btnNovbeIdareetme_Click(object sender, EventArgs e)
        {
            using (var form = new NovbeIdareetmesiFormu())
            {
                form.ShowDialog();
            }
            IcazeleriYoxla();
        }

        private void btnIstifadeciIdareetme_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<IstifadeciIdareetmeFormu>();
        }

        private void btnHesabatlar_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<HesabatFormu>();
        }

        private void btnMehsulSatisHesabati_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<MehsulSatisHesabatFormu>();
        }

        private void btnZHesabatArxivi_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<ZHesabatArxivFormu>();
        }

        private void btnBarkodCapi_Click(object sender, EventArgs e)
        {
            UsaqFormuAc<BarkodCapiFormu>();
        }
    }
}