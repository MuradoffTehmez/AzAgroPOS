// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    public partial class AnaMenuFormu : BazaForm
    {
        // Aktiv düyməni izləmək üçün düymələri və onlara bağlı form tiplərini saxlayaq
        private readonly Dictionary<Type, MaterialButton> _formButtonMap;

        public AnaMenuFormu()
        {
            InitializeComponent();
            this.Load += AnaMenuFormu_Load;

            // Form tiplərini müvafiq düymələrlə əlaqələndiririk
            _formButtonMap = new Dictionary<Type, MaterialButton>
            {
                { typeof(MehsulIdareetmeFormu), btnMehsulIdareetme },
                { typeof(SatisFormu), btnYeniSatis },
                { typeof(NisyeIdareetmeFormu), btnNisyeIdareetme },
                { typeof(TemirIdareetmeFormu), btnTemirIdareetme },
                { typeof(IstifadeciIdareetmeFormu), btnIstifadeciIdareetme },
                { typeof(HesabatFormu), btnHesabatlar },
                { typeof(MehsulSatisHesabatFormu), btnMehsulSatisHesabati },
                { typeof(AnbarQaliqHesabatFormu), btnAnbarQaliqHesabati },
                { typeof(ZHesabatArxivFormu), btnZHesabatArxivi },
                { typeof(BarkodCapiFormu), btnBarkodCapi }
            };
        }

        private void AnaMenuFormu_Load(object sender, EventArgs e)
        {
            IcazeleriYoxla();
            mdiTabControl.TabPages.Clear();
            UpdateActiveButtonHighlight();
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
                    if (mdiTabControl.GetTabRect(i).Contains(e.Location))
                    {
                        mdiTabControl.SelectedIndex = i;
                        tabContextMenu.Show(mdiTabControl, e.Location);
                        break;
                    }
                }
            }
        }

        private void baglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdiTabControl.SelectedTab != null)
            {
                var secilmisSehife = mdiTabControl.SelectedTab;
                if (secilmisSehife.Controls.Count > 0 && secilmisSehife.Controls[0] is Form form)
                {
                    form.Close();
                }
                mdiTabControl.TabPages.Remove(secilmisSehife);
            }
        }

        private void mdiTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateActiveButtonHighlight();
        }

        private void UpdateActiveButtonHighlight()
        {
            // Bütün düymələrin vurğulanmasını sıfırlayırıq
            foreach (var btn in _formButtonMap.Values)
            {
                btn.HighEmphasis = false;
                btn.Type = MaterialButton.MaterialButtonType.Text;
            }

            // Əgər aktiv tab varsa, ona uyğun düyməni vurğulayırıq
            if (mdiTabControl.SelectedTab?.Tag is Form aktivForm)
            {
                var formTipi = aktivForm.GetType();
                if (_formButtonMap.ContainsKey(formTipi))
                {
                    var aktivButton = _formButtonMap[formTipi];
                    aktivButton.HighEmphasis = true;
                    aktivButton.Type = MaterialButton.MaterialButtonType.Contained;
                }
            }
        }

        #region Düymə Klik Hadisələri və İcazələr
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
            lblUserName.Text = istifadeci.TamAd;
            // Burada bir istifadəçi ikonasını resurslardan yükləyə bilərsiniz
            // picUserIcon.Image = Properties.Resources.user_icon;

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
                    if (c is MaterialButton button) button.Enabled = false;
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