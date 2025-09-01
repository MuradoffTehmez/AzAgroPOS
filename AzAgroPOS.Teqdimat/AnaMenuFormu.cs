// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    public partial class AnaMenuFormu : BazaForm
    {
        private int animationStep = 0;
        private MaterialButton activeButton = null;
        private bool isAnimating = false;

        public AnaMenuFormu()
        {
            InitializeComponent();
            this.Load += AnaMenuFormu_Load;
            InitializeCustomDesign();
        }

        private void AnaMenuFormu_Load(object sender, EventArgs e)
        {
            IcazeleriYoxla();
            mdiTabControl.TabPages.Clear();
            LoadUserAvatar();
            StartWelcomeAnimation();
        }

        private void InitializeCustomDesign()
        {
            // Sidebar'ın gölgə efekti üçün
            this.pnlSidebar.Paint += PnlSidebar_Paint;

            // Tab kontrol üçün xüsusi rənglər
            this.mdiTabControl.Appearance = TabAppearance.Buttons;
            this.mdiTabControl.SizeMode = TabSizeMode.Fixed;
            this.mdiTabControl.ItemSize = new Size(150, 35);

            // User avatar-ı dairəvi etmək üçün
            MakeCircularPictureBox(picUserAvatar);

            // Logo üçün default şəkil
            SetDefaultLogo();
        }

        private void PnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            // Sidebar'ın sağ tərəfində incə bir xətt çəkmək
            using (Pen pen = new Pen(Color.FromArgb(60, 60, 63), 1))
            {
                e.Graphics.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            }
        }

        private void MakeCircularPictureBox(PictureBox picBox)
        {
            // PictureBox-u dairəvi etmək
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, picBox.Width - 1, picBox.Height - 1);
            Region rg = new Region(gp);
            picBox.Region = rg;
            picBox.BackColor = Color.FromArgb(63, 81, 181);
        }

        private void SetDefaultLogo()
        {
            // Logo üçün default bitmap yaratmaq
            Bitmap logoBitmap = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(logoBitmap))
            {
                g.Clear(Color.FromArgb(63, 81, 181));
                using (Font font = new Font("Roboto", 18, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.DrawString("Az", font, brush, 8, 15);
                }
            }
            picLogo.Image = logoBitmap;
        }

        private void LoadUserAvatar()
        {
            // İstifadəçi avatar-ı yaratmaq
            Bitmap avatarBitmap = new Bitmap(45, 45);
            using (Graphics g = Graphics.FromImage(avatarBitmap))
            {
                g.Clear(Color.FromArgb(63, 81, 181));
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var istifadeci = AktivSessiya.AktivIstifadeci;
                string initials = istifadeci?.TamAd?.Length > 0
                    ? istifadeci.TamAd.Substring(0, 1).ToUpper()
                    : "?";

                using (Font font = new Font("Roboto", 16, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.White))
                {
                    var size = g.MeasureString(initials, font);
                    float x = (45 - size.Width) / 2;
                    float y = (45 - size.Height) / 2;
                    g.DrawString(initials, font, brush, x, y);
                }
            }
            picUserAvatar.Image = avatarBitmap;
        }

        private void StartWelcomeAnimation()
        {
            // Sidebar elementlərinin tədricən görünməsi animasiyası
            animationStep = 0;
            isAnimating = true;
            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (!isAnimating) return;

            animationStep++;

            // Elementləri tədricən göstərmək
            var controls = pnlSidebar.Controls.OfType<Control>()
                .Where(c => c is MaterialButton)
                .OrderBy(c => c.Top)
                .ToArray();

            if (animationStep <= controls.Length)
            {
                for (int i = 0; i < Math.Min(animationStep, controls.Length); i++)
                {
                    controls[i].Visible = true;
                    // Fade-in efekti simulasiyası
                    controls[i].BackColor = Color.FromArgb(
                        Math.Min(255, 37 + (animationStep - i) * 5),
                        Math.Min(255, 37 + (animationStep - i) * 5),
                        Math.Min(255, 38 + (animationStep - i) * 5));
                }
            }
            else
            {
                animationTimer.Stop();
                isAnimating = false;
                // Bütün düymələrin rənglərini normal hala gətirmək
                foreach (var btn in controls)
                {
                    btn.BackColor = Color.FromArgb(37, 37, 38);
                }
            }
        }

        private void UsaqFormuAc<T>() where T : Form, new()
        {
            // Mövcud səhifəni yoxlamaq
            var mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>()
                .FirstOrDefault(p => p.Tag is T);

            if (mövcudSehife != null)
            {
                mdiTabControl.SelectedTab = mövcudSehife;
                // Aktiv düymə efekti
                HighlightActiveButton();
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
                    Tag = yeniForm,
                    BackColor = Color.White
                };

                // Tab səhifəsinə form əlavə etmək
                yeniSehife.Controls.Add(yeniForm);
                mdiTabControl.TabPages.Add(yeniSehife);
                mdiTabControl.SelectedTab = yeniSehife;
                yeniForm.Show();

                // Form bağlandıqda tab-ı da silmək
                yeniForm.FormClosed += (s, e) =>
                {
                    if (mdiTabControl.TabPages.Contains(yeniSehife))
                        mdiTabControl.TabPages.Remove(yeniSehife);
                };

                // Aktiv düymə efekti
                HighlightActiveButton();
            }
        }

        private void HighlightActiveButton()
        {
            // Əvvəlki aktiv düyməni normal vəziyyətə gətirmək
            if (activeButton != null)
            {
                ResetButtonStyle(activeButton);
            }

            // Yeni aktiv düyməni müəyyən etmək
            var selectedTab = mdiTabControl.SelectedTab;
            if (selectedTab?.Tag is Form form)
            {
                string formType = form.GetType().Name;
                activeButton = GetButtonByFormType(formType);

                if (activeButton != null)
                {
                    SetActiveButtonStyle(activeButton);
                }
            }
        }

        private MaterialButton GetButtonByFormType(string formType)
        {
            return formType switch
            {
                "MehsulIdareetmeFormu" => btnMehsulIdareetme,
                "SatisFormu" => btnYeniSatis,
                "NisyeIdareetmeFormu" => btnNisyeIdareetme,
                "TemirIdareetmeFormu" => btnTemirIdareetme,
                "IstifadeciIdareetmeFormu" => btnIstifadeciIdareetme,
                "HesabatFormu" => btnHesabatlar,
                "MehsulSatisHesabatFormu" => btnMehsulSatisHesabati,
                "ZHesabatArxivFormu" => btnZHesabatArxivi,
                "BarkodCapiFormu" => btnBarkodCapi,
                _ => null
            };
        }

        private void SetActiveButtonStyle(MaterialButton btn)
        {
            btn.BackColor = Color.FromArgb(63, 81, 181);
            btn.UseAccentColor = true;
        }

        private void ResetButtonStyle(MaterialButton btn)
        {
            btn.BackColor = Color.FromArgb(37, 37, 38);
            btn.UseAccentColor = false;
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
                        break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                // Sol klik zamanı aktiv düyməni vurğulamaq
                HighlightActiveButton();
            }
        }

        private void baglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseSelectedTab();
        }

        private void hamisiCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Bütün tabları bağlamaq
            while (mdiTabControl.TabCount > 0)
            {
                var tab = mdiTabControl.TabPages[0];
                if (tab.Controls.Count > 0 && tab.Controls[0] is Form form)
                {
                    form.Close();
                }
                mdiTabControl.TabPages.Remove(tab);
            }

            // Aktiv düyməni sıfırlamaq
            if (activeButton != null)
            {
                ResetButtonStyle(activeButton);
                activeButton = null;
            }
        }

        private void CloseSelectedTab()
        {
            if (mdiTabControl.SelectedIndex != -1)
            {
                var secilmisSehife = mdiTabControl.SelectedTab;

                if (secilmisSehife.Controls.Count > 0 && secilmisSehife.Controls[0] is Form form)
                {
                    form.Close();
                }

                mdiTabControl.TabPages.Remove(secilmisSehife);

                // Əgər bu aktiv düymənin səhifəsi idisə, düyməni sıfırlamaq
                HighlightActiveButton();
            }
        }

        #region İcazə İdarəetməsi və İstifadəçi Məlumatları

        private void IcazeleriYoxla()
        {
            var istifadeci = AktivSessiya.AktivIstifadeci;
            if (istifadeci == null)
            {
                MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı. Tətbiq bağlanır.",
                    "Kritik Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }

            // İstifadəçi məlumatlarını yeniləmək
            UpdateUserInfo(istifadeci);

            this.Text = $"AzAgroPOS - (İstifadəçi: {istifadeci.TamAd})";
            btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;

            // Satış düyməsini xüsusi vurğulamaq əgər növbə açıqdırsa
            if (AktivSessiya.AktivNovbeId.HasValue)
            {
                btnYeniSatis.BackColor = Color.FromArgb(76, 175, 80); // Yaşıl rəng
            }

            if (istifadeci.RolAdi == "Admin") return;

            ApplyRoleBasedPermissions(istifadeci.RolAdi);
        }

        private void UpdateUserInfo(dynamic istifadeci)
        {
            lblUserName.Text = istifadeci.TamAd ?? "İstifadəçi";
            lblUserRole.Text = istifadeci.RolAdi ?? "Rol";

            // Rol rəngini dəyişmək
            lblUserRole.ForeColor = istifadeci.RolAdi switch
            {
                "Admin" => Color.FromArgb(244, 67, 54), // Qırmızı
                "Kassir" => Color.FromArgb(255, 193, 7), // Sarı
                _ => Color.FromArgb(180, 180, 180) // Default
            };
        }

        private void ApplyRoleBasedPermissions(string rolAdi)
        {
            if (rolAdi == "Kassir")
            {
                // Kassir üçün məhdudiyyətlər
                btnMehsulIdareetme.Enabled = false;
                btnNisyeIdareetme.Enabled = false;
                btnTemirIdareetme.Enabled = false;
                btnIstifadeciIdareetme.Enabled = false;

                // Deaktiv düymələrin görünüşünü dəyişmək
                SetDisabledButtonStyle(btnMehsulIdareetme);
                SetDisabledButtonStyle(btnNisyeIdareetme);
                SetDisabledButtonStyle(btnTemirIdareetme);
                SetDisabledButtonStyle(btnIstifadeciIdareetme);
            }
            else
            {
                // Digər rollər üçün bütün düymələri deaktiv etmək
                foreach (Control c in pnlSidebar.Controls)
                {
                    if (c is MaterialButton btn)
                    {
                        btn.Enabled = false;
                        SetDisabledButtonStyle(btn);
                    }
                }
            }
        }

        private void SetDisabledButtonStyle(MaterialButton btn)
        {
            btn.ForeColor = Color.FromArgb(100, 100, 100);
            btn.BackColor = Color.FromArgb(50, 50, 50);
        }

        #endregion

        #region Düymə Klik Hadisələri

        private void btnMehsulIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulIdareetmeFormu>();
        private void btnYeniSatis_Click(object sender, EventArgs e) => UsaqFormuAc<SatisFormu>();
        private void btnNisyeIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<NisyeIdareetmeFormu>();
        private void btnTemirIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<TemirIdareetmeFormu>();
        private void btnIstifadeciIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<IstifadeciIdareetmeFormu>();
        private void btnHesabatlar_Click(object sender, EventArgs e) => UsaqFormuAc<HesabatFormu>();
        private void btnMehsulSatisHesabati_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulSatisHesabatFormu>();
        private void btnZHesabatArxivi_Click(object sender, EventArgs e) => UsaqFormuAc<ZHesabatArxivFormu>();
        private void btnBarkodCapi_Click(object sender, EventArgs e) => UsaqFormuAc<BarkodCapiFormu>();

        private void btnNovbeIdareetme_Click(object sender, EventArgs e)
        {
            using (var form = new NovbeIdareetmesiFormu())
            {
                form.ShowDialog();
            }
            IcazeleriYoxla(); // Növbə vəziyyətini yeniləmək
        }

        #endregion

        #region Form Yaşam Dövrü

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Resursları təmizləmək
            animationTimer?.Stop();
            animationTimer?.Dispose();

            // Bütün açıq formları bağlamaq
            while (mdiTabControl.TabCount > 0)
            {
                CloseSelectedTab();
            }

            base.OnFormClosed(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Form ölçüsü dəyişdikdə UI elementlərini yeniləmək
            if (WindowState == FormWindowState.Minimized)
            {
                animationTimer?.Stop();
            }
            else if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
            {
                this.Refresh();
            }
        }

        #endregion
    }
}