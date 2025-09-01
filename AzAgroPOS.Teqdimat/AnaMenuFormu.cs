// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    // Demo üçün AktivSessiya sinifi (əgər mövcud deyilsə)
    public static class AktivSessiya
    {
        public static dynamic AktivIstifadeci { get; set; } = new
        {
            TamAd = "Demo İstifadəçi",
            RolAdi = "Admin"
        };
        public static long? AktivNovbeId { get; set; } = null;
    }

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
            try
            {
                // Mövcud səhifəni yoxlamaq
                var mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>()
                    .FirstOrDefault(p => p.Tag?.GetType() == typeof(T));

                if (mövcudSehife != null)
                {
                    mdiTabControl.SelectedTab = mövcudSehife;
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

                    var yeniSehife = new TabPage(yeniForm.Text ?? typeof(T).Name)
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

                    HighlightActiveButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açılarkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Demo formu yaratmaq üçün helper metod
        private void DemoFormuAc(string formAdi)
        {
            try
            {
                // Mövcud səhifəni yoxlamaq
                var mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>()
                    .FirstOrDefault(p => p.Text == formAdi);

                if (mövcudSehife != null)
                {
                    mdiTabControl.SelectedTab = mövcudSehife;
                    HighlightActiveButton();
                }
                else
                {
                    // Demo form yaratmaq
                    var demoForm = CreateDemoForm(formAdi);

                    var yeniSehife = new TabPage(formAdi)
                    {
                        Tag = demoForm,
                        BackColor = Color.White
                    };

                    yeniSehife.Controls.Add(demoForm);
                    mdiTabControl.TabPages.Add(yeniSehife);
                    mdiTabControl.SelectedTab = yeniSehife;
                    demoForm.Show();

                    HighlightActiveButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Demo form açılarkən xəta: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form CreateDemoForm(string formAdi)
        {
            var demoForm = new Form
            {
                Text = formAdi,
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Demo məzmun əlavə etmək
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            var titleLabel = new Label
            {
                Text = formAdi,
                Font = new Font("Roboto", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            var descLabel = new Label
            {
                Text = $"Bu {formAdi} bölməsidir.\nBurada əlaqədar əməliyyatlar həyata keçirilə bilər.",
                Font = new Font("Roboto", 12),
                ForeColor = Color.FromArgb(117, 117, 117),
                AutoSize = true,
                Location = new Point(20, 70)
            };

            var demoButton = new MaterialButton
            {
                Text = "Demo Əməliyyat",
                Size = new Size(150, 40),
                Location = new Point(20, 130),
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained,
                UseAccentColor = true
            };

            demoButton.Click += (s, e) =>
            {
                MessageBox.Show($"{formAdi} bölməsində demo əməliyyat yerinə yetirildi!",
                    "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Xüsusi məzmun əlavə etmək
            AddSpecificContent(formAdi, mainPanel);

            mainPanel.Controls.AddRange(new Control[] { titleLabel, descLabel, demoButton });
            demoForm.Controls.Add(mainPanel);

            return demoForm;
        }

        private void AddSpecificContent(string formAdi, Panel mainPanel)
        {
            switch (formAdi)
            {
                case "Növbəni İdarə Et":
                    AddNovbeContent(mainPanel);
                    break;
                case "Məhsullar":
                    AddMehsulContent(mainPanel);
                    break;
                case "Yeni Satış":
                    AddSatisContent(mainPanel);
                    break;
                case "Nisyə / Borc":
                    AddNisyeContent(mainPanel);
                    break;
                case "Təmir":
                    AddTemirContent(mainPanel);
                    break;
                case "İstifadəçilər":
                    AddIstifadeciContent(mainPanel);
                    break;
                default:
                    AddDefaultContent(mainPanel, formAdi);
                    break;
            }
        }

        private void AddNovbeContent(Panel panel)
        {
            var statusLabel = new Label
            {
                Text = $"Növbə Vəziyyəti: {(AktivSessiya.AktivNovbeId.HasValue ? "Açıq" : "Bağlı")}",
                Font = new Font("Roboto", 14, FontStyle.Bold),
                ForeColor = AktivSessiya.AktivNovbeId.HasValue ? Color.Green : Color.Red,
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(statusLabel);
        }

        private void AddMehsulContent(Panel panel)
        {
            var infoLabel = new Label
            {
                Text = "• Məhsul əlavə et\n• Məhsul məlumatlarını yenilə\n• Qiymətləri idarə et\n• Kateqoriya təyin et",
                Font = new Font("Roboto", 11),
                ForeColor = Color.FromArgb(85, 85, 85),
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(infoLabel);
        }

        private void AddSatisContent(Panel panel)
        {
            var enabledText = AktivSessiya.AktivNovbeId.HasValue
                ? "Satış əməliyyatları mövcuddur"
                : "Əvvəlcə növbə açın";

            var statusLabel = new Label
            {
                Text = enabledText,
                Font = new Font("Roboto", 12),
                ForeColor = AktivSessiya.AktivNovbeId.HasValue ? Color.Green : Color.Orange,
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(statusLabel);
        }

        private void AddNisyeContent(Panel panel)
        {
            var infoLabel = new Label
            {
                Text = "• Müştəri borc məlumatları\n• Ödəniş tarixçəsi\n• Nisyə limitləri\n• Xatırlatmalar",
                Font = new Font("Roboto", 11),
                ForeColor = Color.FromArgb(85, 85, 85),
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(infoLabel);
        }

        private void AddTemirContent(Panel panel)
        {
            var infoLabel = new Label
            {
                Text = "• Təmir sifarişləri\n• Təmir tarixçəsi\n• Ehtiyat hissələri\n• Xərc hesabatları",
                Font = new Font("Roboto", 11),
                ForeColor = Color.FromArgb(85, 85, 85),
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(infoLabel);
        }

        private void AddIstifadeciContent(Panel panel)
        {
            var infoLabel = new Label
            {
                Text = "• Yeni istifadəçi əlavə et\n• İcazələri idarə et\n• Parol dəyişikliyi\n• Aktivlik logları",
                Font = new Font("Roboto", 11),
                ForeColor = Color.FromArgb(85, 85, 85),
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(infoLabel);
        }

        private void AddDefaultContent(Panel panel, string formAdi)
        {
            var infoLabel = new Label
            {
                Text = $"{formAdi} bölməsi hazırlanır...\nTezliklə istifadəyə veriləcək.",
                Font = new Font("Roboto", 11),
                ForeColor = Color.FromArgb(117, 117, 117),
                Location = new Point(20, 180),
                AutoSize = true
            };
            panel.Controls.Add(infoLabel);
        }

        //private void HighlightActiveButton()
        //{
        //    // Əvvəlki aktiv düyməni normal vəziyyətə gətirmək
        //    if (activeButton != null)
        //    {
        //        ResetButtonStyle(activeButton);
        //    }

        //    // Yeni aktiv düyməni müəyyən etmək
        //    var selectedTab = mdiTabControl.SelectedTab;
        //    if (selectedTab?.Tag is Form form)
        //    {
        //        string formType = form.GetType().Name;
        //        activeButton = GetButtonByFormType(formType);

        //        if (activeButton != null)
        //        {
        //            SetActiveButtonStyle(activeButton);
        //        }
        //    }
        //}

        private MaterialButton GetButtonByFormType(string formType)
        {
            return formType switch
            {
                "Məhsullar" => btnMehsulIdareetme,
                "Yeni Satış" => btnYeniSatis,
                "Nisyə / Borc" => btnNisyeIdareetme,
                "Təmir" => btnTemirIdareetme,
                "İstifadəçilər" => btnIstifadeciIdareetme,
                "Günlük Hesabat" => btnHesabatlar,
                "Məhsul Hesabatı" => btnMehsulSatisHesabati,
                "Z-Hesabat Arxivi" => btnZHesabatArxivi,
                "Barkod Çapı" => btnBarkodCapi,
                "Anbar Qalığı" => btnAnbarQaliqHesabati,
                _ => null
            };
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
            if (selectedTab != null)
            {
                string tabText = selectedTab.Text;
                activeButton = GetButtonByFormType(tabText);

                if (activeButton != null)
                {
                    SetActiveButtonStyle(activeButton);
                }
            }
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