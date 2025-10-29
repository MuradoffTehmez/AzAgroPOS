using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Teqdimat
{
    public partial class AlisSenedFormu : BazaForm, IAlisSenedView
    {
        private readonly AlisSenedPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;
        private List<AlisSenedSetiriDto> _senedSetirleri = new List<AlisSenedSetiriDto>();

        public AlisSenedFormu(AlisManager alisManager, MehsulManager mehsulManager, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _presenter = new AlisSenedPresenter(this, alisManager, mehsulManager);

            // Form yüklənəndə Presenter-ə xəbər veririk
            this.Load += (s, e) =>
            {
                FormYuklendi?.Invoke(this, EventArgs.Empty);
                SetupTooltips();
            };

            StilVerDataGridView(dgvSenetler);
            StilVerDataGridView(dgvSenedSetirleri);
        }

        private void SetupTooltips()
        {
            toolTip1.SetToolTip(txtSenedNomresi, "Sənədin nömrəsini daxil edin");
            toolTip1.SetToolTip(cmbTedarukcu, "Tədarükçü seçin");
            toolTip1.SetToolTip(dtpYaradilmaTarixi, "Sənədin yaradılma tarixini seçin");
            toolTip1.SetToolTip(dtpTehvilTarixi, "Malın təhvil alınma tarixini seçin");
            toolTip1.SetToolTip(txtQeydler, "Əlavə qeydlər və şərhlər daxil edin");
            toolTip1.SetToolTip(btnYeni, "Yeni sənəd yaratmaq üçün formanı təmizləyin");
            toolTip1.SetToolTip(btnYaddaSaxla, "Sənədi yadda saxlayın");
            toolTip1.SetToolTip(btnSil, "Seçilmiş sənədi silin");
        }

        #region IAlisSenedView Implementasiyası

        public int SenedId { get; set; }
        public string SenedNomresi
        {
            get => txtSenedNomresi.Text;
            set => txtSenedNomresi.Text = value;
        }

        public DateTime YaradilmaTarixi
        {
            get => dtpYaradilmaTarixi.Value;
            set => dtpYaradilmaTarixi.Value = value;
        }

        public int TedarukcuId
        {
            get => cmbTedarukcu.SelectedValue is int id ? id : 0;
            set => cmbTedarukcu.SelectedValue = value;
        }

        public DateTime TehvilTarixi
        {
            get => dtpTehvilTarixi.Value;
            set => dtpTehvilTarixi.Value = value;
        }

        public decimal UmumiMebleg
        {
            get => _senedSetirleri.Sum(s => s.CemiMebleg);
            set { } // Hesablanır
        }

        public string? Qeydler
        {
            get => txtQeydler.Text;
            set => txtQeydler.Text = value ?? string.Empty;
        }

        public event EventHandler FormYuklendi;
        public event EventHandler SenedYarat_Istek;
        public event EventHandler SenedYenile_Istek;
        public event EventHandler SenedSil_Istek;
        public event EventHandler FormuTemizle_Istek;

        public void TedarukculeriGoster(List<TedarukcuDto> tedarukculer)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => TedarukculeriGoster(tedarukculer)));
                return;
            }

            cmbTedarukcu.DataSource = tedarukculer;
            cmbTedarukcu.DisplayMember = "Ad";
            cmbTedarukcu.ValueMember = "Id";
        }

        public void SenetleriGoster(List<AlisSenedDto> senetler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SenetleriGoster(senetler)));
                return;
            }

            dgvSenetler.SelectionChanged -= dgvSenetler_SelectionChanged;
            dgvSenetler.DataSource = senetler;

            if (dgvSenetler.Columns.Count > 0)
            {
                dgvSenetler.Columns["Id"].Visible = false;
                dgvSenetler.Columns["TedarukcuId"].Visible = false;
                dgvSenetler.Columns["SenedSetirleri"].Visible = false;
                dgvSenetler.Columns["SenedNomresi"].HeaderText = "Sənəd №";
                dgvSenetler.Columns["YaradilmaTarixi"].HeaderText = "Yaradılma Tarixi";
                dgvSenetler.Columns["TedarukcuAdi"].HeaderText = "Tədarükçü";
                dgvSenetler.Columns["TehvilTarixi"].HeaderText = "Təhvil Tarixi";
                dgvSenetler.Columns["UmumiMebleg"].HeaderText = "Ümumi Məbləğ";
                dgvSenetler.Columns["Status"].HeaderText = "Status";
                dgvSenetler.Columns["Qeydler"].HeaderText = "Qeydlər";

                // Format tarixi
                dgvSenetler.Columns["YaradilmaTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvSenetler.Columns["TehvilTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy";

                // Format məbləğ
                dgvSenetler.Columns["UmumiMebleg"].DefaultCellStyle.Format = "N2";
                dgvSenetler.Columns["UmumiMebleg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvSenetler.SelectionChanged += dgvSenetler_SelectionChanged;
        }

        public void SenedSetirleriniGoster(List<AlisSenedSetiriDto> setirler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SenedSetirleriniGoster(setirler)));
                return;
            }

            _senedSetirleri = setirler;
            dgvSenedSetirleri.DataSource = null;
            dgvSenedSetirleri.DataSource = _senedSetirleri;

            if (dgvSenedSetirleri.Columns.Count > 0)
            {
                dgvSenedSetirleri.Columns["Id"].Visible = false;
                dgvSenedSetirleri.Columns["AlisSenedId"].Visible = false;
                dgvSenedSetirleri.Columns["MehsulId"].Visible = false;
                dgvSenedSetirleri.Columns["AlisSifarisSetiriId"].Visible = false;
                dgvSenedSetirleri.Columns["AlisSifarisSetiriNomresi"].Visible = false;
                dgvSenedSetirleri.Columns["MehsulAdi"].HeaderText = "Məhsul";
                dgvSenedSetirleri.Columns["Miqdar"].HeaderText = "Miqdar";
                dgvSenedSetirleri.Columns["BirVahidQiymet"].HeaderText = "Vahid Qiyməti";
                dgvSenedSetirleri.Columns["CemiMebleg"].HeaderText = "Cəmi Məbləğ";

                // Format
                dgvSenedSetirleri.Columns["Miqdar"].DefaultCellStyle.Format = "N2";
                dgvSenedSetirleri.Columns["BirVahidQiymet"].DefaultCellStyle.Format = "N2";
                dgvSenedSetirleri.Columns["CemiMebleg"].DefaultCellStyle.Format = "N2";

                dgvSenedSetirleri.Columns["Miqdar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenedSetirleri.Columns["BirVahidQiymet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenedSetirleri.Columns["CemiMebleg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Ümumi məbləği göstər
            lblUmumiMebleg.Text = $"Ümumi: {UmumiMebleg:N2} AZN";
        }

        public void MehsullariGoster(List<MehsulDto> mehsullar)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MehsullariGoster(mehsullar)));
                return;
            }

            cmbMehsul.DataSource = mehsullar;
            cmbMehsul.DisplayMember = "Ad";
            cmbMehsul.ValueMember = "Id";
        }

        public void MesajGoster(string mesaj, bool xetadir = false)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MesajGoster(mesaj, xetadir)));
                return;
            }

            MessageBox.Show(mesaj,
                xetadir ? "Xəta" : "Məlumat",
                MessageBoxButtons.OK,
                xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void FormuTemizle()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(FormuTemizle));
                return;
            }

            SenedId = 0;
            txtSenedNomresi.Clear();
            dtpYaradilmaTarixi.Value = DateTime.Now;
            dtpTehvilTarixi.Value = DateTime.Now;
            txtQeydler.Clear();
            if (cmbTedarukcu.Items.Count > 0)
                cmbTedarukcu.SelectedIndex = 0;

            _senedSetirleri.Clear();
            SenedSetirleriniGoster(_senedSetirleri);

            txtSenedNomresi.Focus();
        }

        #endregion

        #region Event Handlers

        private void dgvSenetler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSenetler.CurrentRow?.DataBoundItem is AlisSenedDto sened)
            {
                SenedId = sened.Id;
                SenedNomresi = sened.SenedNomresi;
                YaradilmaTarixi = sened.YaradilmaTarixi;
                TedarukcuId = sened.TedarukcuId;
                TehvilTarixi = sened.TehvilTarixi;
                Qeydler = sened.Qeydler;
                SenedSetirleriniGoster(sened.SenedSetirleri);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(SenedNomresi))
            {
                MesajGoster("Sənəd nömrəsini daxil edin!", true);
                txtSenedNomresi.Focus();
                return;
            }

            if (TedarukcuId <= 0)
            {
                MesajGoster("Tədarükçü seçin!", true);
                cmbTedarukcu.Focus();
                return;
            }

            if (_senedSetirleri.Count == 0)
            {
                MesajGoster("Ən azı bir məhsul əlavə edin!", true);
                return;
            }

            // Sənəd yarat və ya yenilə
            if (SenedId > 0)
            {
                SenedYenile_Istek?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                SenedYarat_Istek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (SenedId <= 0)
            {
                MesajGoster("Silmək üçün sənəd seçin!", true);
                return;
            }

            var result = MessageBox.Show(
                "Seçilmiş sənədi silmək istədiyinizdən əminsiniz?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SenedSil_Istek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnMehsulElaveEt_Click(object sender, EventArgs e)
        {
            if (cmbMehsul.SelectedValue is not int mehsulId || mehsulId <= 0)
            {
                MesajGoster("Məhsul seçin!", true);
                return;
            }

            if (!decimal.TryParse(txtMiqdar.Text, out decimal miqdar) || miqdar <= 0)
            {
                MesajGoster("Düzgün miqdar daxil edin!", true);
                txtMiqdar.Focus();
                return;
            }

            if (!decimal.TryParse(txtQiymet.Text, out decimal qiymet) || qiymet <= 0)
            {
                MesajGoster("Düzgün qiymət daxil edin!", true);
                txtQiymet.Focus();
                return;
            }

            var mehsulDto = cmbMehsul.SelectedItem as MehsulDto;
            var setir = new AlisSenedSetiriDto
            {
                MehsulId = mehsulId,
                MehsulAdi = mehsulDto?.Ad ?? "",
                Miqdar = miqdar,
                BirVahidQiymet = qiymet,
                CemiMebleg = miqdar * qiymet
            };

            _senedSetirleri.Add(setir);
            SenedSetirleriniGoster(_senedSetirleri);

            // Təmizlə
            txtMiqdar.Clear();
            txtQiymet.Clear();
            cmbMehsul.Focus();
        }

        private void btnSetirSil_Click(object sender, EventArgs e)
        {
            if (dgvSenedSetirleri.CurrentRow?.DataBoundItem is AlisSenedSetiriDto setir)
            {
                _senedSetirleri.Remove(setir);
                SenedSetirleriniGoster(_senedSetirleri);
            }
        }

        private void txtAxtaris_TextChanged(object sender, EventArgs e)
        {
            // Axtarış funksionallığı əlavə edilə bilər
        }

        #endregion
    }
}
