// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
using System;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    public partial class AnaMenuFormu : BazaForm
    {
        public AnaMenuFormu()
        {
            InitializeComponent();
            this.Load += AnaMenuFormu_Load;
        }

        private void AnaMenuFormu_Load(object sender, EventArgs e)
        {
            IcazeleriYoxla();
            mdiTabControl.TabPages.Clear();
        }

        private void UsaqFormuAc<T>() where T : Form, new()
        {
           
            var mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>().FirstOrDefault(p => p.Tag is T);

            if (mövcudSehife != null)
            {
                mdiTabControl.SelectedTab = mövcudSehife;
            }
            else
            {
                var yeniForm = new T
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None, 
                    Dock = DockStyle.Fill 
                };

                var yeniSehife = new TabPage(yeniForm.Text) 
                {
                    Tag = yeniForm 
                };

                yeniSehife.Controls.Add(yeniForm); 
                mdiTabControl.TabPages.Add(yeniSehife);
                mdiTabControl.SelectedTab = yeniSehife;
                yeniForm.Show(); 
            }
        }

        
        private void mdiTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < mdiTabControl.TabCount; i++)
                {
                    Rectangle r = mdiTabControl.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        mdiTabControl.SelectedIndex = i;
                        tabContextMenu.Show(mdiTabControl, e.Location);
                    }
                }
            }
        }

        private void baglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdiTabControl.SelectedIndex != -1)
            {
                var secilmisSehife = mdiTabControl.SelectedTab;
               
                if (secilmisSehife.Controls.Count > 0 && secilmisSehife.Controls[0] is Form form)
                {
                    form.Close();
                }
                
                mdiTabControl.TabPages.Remove(secilmisSehife);
            }
        }

        #region Düymə Klik Hadisələri (dəyişməyib)
        private void IcazeleriYoxla()
        {
            var istifadeci = AktivSessiya.AktivIstifadeci;
            if (istifadeci == null)
            {
                MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı. Tətbiq bağlanır.", "Kritik Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }

            this.Text = $"AzAgroPOS - (İstifadəçi: {istifadeci.TamAd})";
            btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;

            if (istifadeci.RolAdi == "Admin") return;

            if (istifadeci.RolAdi == "Kassir")
            {
                btnMehsulIdareetme.Enabled = false;
                btnNisyeIdareetme.Enabled = false;
                btnTemirIdareetme.Enabled = false;
                btnIstifadeciIdareetme.Enabled = false;
            }
            else
            {
                foreach (Control c in pnlMenu.Controls)
                {
                    if (c is MaterialButton) c.Enabled = false;
                }
            }
        }

        private void btnMehsulIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulIdareetmeFormu>();
        private void btnYeniSatis_Click(object sender, EventArgs e) => UsaqFormuAc<SatisFormu>();
        private void btnNisyeIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<NisyeIdareetmeFormu>();
        private void btnTemirIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<TemirIdareetmeFormu>();
        private void btnNovbeIdareetme_Click(object sender, EventArgs e)
        {
            using (var form = new NovbeIdareetmesiFormu()) { form.ShowDialog(); }
            IcazeleriYoxla();
        }
        private void btnIstifadeciIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<IstifadeciIdareetmeFormu>();
        private void btnHesabatlar_Click(object sender, EventArgs e) => UsaqFormuAc<HesabatFormu>();
        private void btnMehsulSatisHesabati_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulSatisHesabatFormu>();
        private void btnZHesabatArxivi_Click(object sender, EventArgs e) => UsaqFormuAc<ZHesabatArxivFormu>();
        private void btnBarkodCapi_Click(object sender, EventArgs e) => UsaqFormuAc<BarkodCapiFormu>();
        #endregion
    }
}