using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

namespace AzAgroPOS.Teqdimat
{
    public partial class TemirIdareetmeFormu : BazaForm, ITemirView
    {
        private TemirPresenter _presenter;

        public TemirIdareetmeFormu()
        {
            InitializeComponent();
            StilVerDataGridView(dgvSifarisler);
        }

        public void InitializePresenter(TemirPresenter presenter)
        {
            _presenter = presenter;
        }

        #region ITemirView Implementasiyası

        public string MusteriAdi
        {
            get => txtMusteriAdi.Text;
            set => txtMusteriAdi.Text = value;
        }

        public string MusteriTelefonu
        {
            get => txtMusteriTelefonu.Text;
            set => txtMusteriTelefonu.Text = value;
        }

        public string CihazAdi
        {
            get => txtCihazAdi.Text;
            set => txtCihazAdi.Text = value;
        }

        public string SeriyaNomresi
        {
            get => txtSeriyaNomresi.Text;
            set => txtSeriyaNomresi.Text = value;
        }

        public string ProblemTesviri
        {
            get => txtProblemTesviri.Text;
            set => txtProblemTesviri.Text = value;
        }

        public int? UstaId
        {
            get => (int?)cmbUsta.SelectedValue > 0 ? (int?)cmbUsta.SelectedValue : null;
            set => cmbUsta.SelectedValue = value;
        }

        public decimal TemirXerci
        {
            get => decimal.TryParse(txtTemirXerci.Text, out var xerc) ? xerc : 0;
            set => txtTemirXerci.Text = value.ToString("N2");
        }

        public decimal ServisHaqqi
        {
            get => decimal.TryParse(txtServisHaqqi.Text, out var haqq) ? haqq : 0;
            set => txtServisHaqqi.Text = value.ToString("N2");
        }

        public decimal YekunMebleg
        {
            get => decimal.TryParse(txtYekunMebleg.Text, out var mebleg) ? mebleg : 0;
            set => txtYekunMebleg.Text = value.ToString("N2");
        }

        public int SecilmisSifarisId
        {
            get
            {
                if (dgvSifarisler.CurrentRow?.DataBoundItem is TemirDto sifaris)
                {
                    return sifaris.Id;
                }
                return 0;
            }
        }

        public event EventHandler FormYuklendi;
        public event EventHandler YeniSifarisYarat_Istek;
        public event EventHandler SifarisYenile_Istek;
        public event EventHandler SifarisSil_Istek;
        public event EventHandler FormuTemizle_Istek;
        public event EventHandler EhtiyatHissəsiElaveEt_Istek;
        public event EventHandler ÖdənişiTamamla_Istek;

        public void SifarisleriGoster(List<TemirDto> sifarisler)
        {
            dgvSifarisler.SelectionChanged -= dgvSifarisler_SelectionChanged;
            dgvSifarisler.DataSource = sifarisler;
            dgvSifarisler.SelectionChanged += dgvSifarisler_SelectionChanged;

            if (dgvSifarisler.Columns.Count > 0)
            {
                dgvSifarisler.Columns["Id"].Visible = false;
                dgvSifarisler.Columns["MusteriAdi"].HeaderText = "Müştəri Adı";
                dgvSifarisler.Columns["MusteriTelefonu"].HeaderText = "Telefon";
                dgvSifarisler.Columns["CihazAdi"].HeaderText = "Cihaz Adı";
                dgvSifarisler.Columns["ProblemTesviri"].HeaderText = "Problem Təsviri";
                dgvSifarisler.Columns["QebulTarixi"].HeaderText = "Qəbul Tarixi";
                dgvSifarisler.Columns["Status"].HeaderText = "Status";
                dgvSifarisler.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ";
            }
        }

        public void UstaSiyahisiniGoster(List<IstifadeciDto> ustalar)
        {
            var listDataSource = new List<object> { new { Id = 0, TamAd = "Seçilməyib" } };
            listDataSource.AddRange(ustalar.Select(u => new { u.Id, TamAd = u.TamAd }).ToList());

            cmbUsta.DataSource = listDataSource;
            cmbUsta.DisplayMember = "TamAd";
            cmbUsta.ValueMember = "Id";
        }

        public void MesajGoster(string mesaj, string basliq)
        {
            MessageBox.Show(mesaj, basliq);
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }

        /// <summary>
        /// Shows a validation error on a control
        /// </summary>
        /// <param name="control">Control to show error on</param>
        /// <param name="message">Error message</param>
        public void XetaGoster(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(control, 2);
        }

        /// <summary>
        /// Clears validation error from a control
        /// </summary>
        /// <param name="control">Control to clear error from</param>
        public void XetaniTemizle(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }

        /// <summary>
        /// Clears all validation errors
        /// </summary>
        public void ButunXetalariTemizle()
        {
            // Clear errors from all controls
            foreach (Control control in this.Controls)
            {
                ClearErrorsRecursive(control);
            }
        }

        /// <summary>
        /// Recursively clears errors from all controls
        /// </summary>
        /// <param name="control">Control to clear errors from</param>
        private void ClearErrorsRecursive(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
            foreach (Control child in control.Controls)
            {
                ClearErrorsRecursive(child);
            }
        }

        public void FormuTemizle()
        {
            txtMusteriAdi.Clear();
            txtMusteriTelefonu.Clear();
            txtCihazAdi.Clear();
            txtSeriyaNomresi.Clear();
            txtProblemTesviri.Clear();
            txtTemirXerci.Clear();
            txtServisHaqqi.Clear();
            txtYekunMebleg.Clear();

            // Safely set the selected index only if there are items in the ComboBox
            if (cmbUsta.Items.Count > 0)
            {
                cmbUsta.SelectedIndex = 0;
            }

            dgvSifarisler.ClearSelection();
            txtMusteriAdi.Focus();
        }

        #endregion

        private void TemirIdareetmeFormu_Load(object sender, EventArgs e)
        {
            FormYuklendi?.Invoke(this, EventArgs.Empty);
            FormuTemizle();
        }

        private void btnYarat_Click(object sender, EventArgs e)
        {
            YeniSifarisYarat_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            SifarisYenile_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SifarisSil_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnEhtiyatHissəsiElaveEt_Click(object sender, EventArgs e)
        {
            EhtiyatHissəsiElaveEt_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void txtTemirXerci_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTemirXerci.Text, out var xerc) && decimal.TryParse(txtServisHaqqi.Text, out var haqq))
            {
                txtYekunMebleg.Text = (xerc + haqq).ToString("N2");
            }
        }

        private void txtServisHaqqi_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTemirXerci.Text, out var xerc) && decimal.TryParse(txtServisHaqqi.Text, out var haqq))
            {
                txtYekunMebleg.Text = (xerc + haqq).ToString("N2");
            }
        }

        private void btnÖdənişiTamamla_Click(object sender, EventArgs e)
        {
            ÖdənişiTamamla_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void dgvSifarisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSifarisler.CurrentRow?.DataBoundItem is TemirDto sifaris)
            {
                txtMusteriAdi.Text = sifaris.MusteriAdi;
                txtMusteriTelefonu.Text = sifaris.MusteriTelefonu;
                txtCihazAdi.Text = sifaris.CihazAdi;
                txtSeriyaNomresi.Text = sifaris.SeriyaNomresi;
                txtProblemTesviri.Text = sifaris.ProblemTesviri;
                txtTemirXerci.Text = sifaris.TemirXerci.ToString("N2");
                txtServisHaqqi.Text = sifaris.ServisHaqqi.ToString("N2");
                txtYekunMebleg.Text = sifaris.YekunMebleg.ToString("N2");
                cmbUsta.SelectedValue = sifaris.IsciId ?? 0;
            }
        }
    }
}